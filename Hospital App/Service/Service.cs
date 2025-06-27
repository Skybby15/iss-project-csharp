using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Hospital_App.Domain;
using Hospital_App.Utils;

namespace Hospital_App.ServiceNameSpace
{
    public class Service : Observer
    {
        public Service() { 
        
        }

        public int Login(User acc)
        {
            ////functional add
            //    User admin1 = new User() { Name = "Admin1", Password="Pass", Salt = GenerateSalt(), UserType="Admin"};
            //    admin1.Password = HashPassword(admin1.Password, admin1.Salt);
            //using (var context1 = new HospitalDbContext()) { 
            //    context1.Users.Add(admin1);
            //    context1.SaveChanges();
            //}
            ////

            if (string.IsNullOrEmpty(acc.Password) || string.IsNullOrEmpty(acc.Name))
                throw new Exception("Please fill in all credentials!");

            using var context = new HospitalDbContext();
            User? tryingToLog = context.Users.Where(usr => usr.Name == acc.Name).FirstOrDefault();


            if (tryingToLog == null || tryingToLog.Password == null)
                throw new Exception("Service Exception : Logging user not found!");
            if (!tryingToLog.Password.Equals(HashPassword(acc.Password, tryingToLog.Salt)))
                throw new Exception("Invalid credentials!");
                

            if (tryingToLog.UserType == "Admin")
            {
                return 0;
            }
            else if (tryingToLog.UserType == "Pharmacist")
            {
                return 1;
            }
            else if (tryingToLog.UserType == "MedicalStaff") 
            {
                return 2;
            }

            return -1;
        }

        //Admin
        public List<User> GetAllAccounts()
        {
            using var context = new HospitalDbContext();
            return context.Users.ToList();
        }

        public void AddAccount(User acc)
        {
            if (string.IsNullOrEmpty(acc.Name))
                throw new Exception("Name cannot be empty!");
            if (string.IsNullOrEmpty(acc.Password))
                throw new Exception("Password cannot be empty!");
            if (string.IsNullOrEmpty(acc.UserType))
                throw new Exception("Please give a user type!");
            
            using var context = new HospitalDbContext();
            User? search = context.Users.Where(user => user.Name == acc.Name).FirstOrDefault() as User;


            if (search == null)
            {
                byte[] salt = GenerateSalt();
                string hashedPassword = HashPassword(acc.Password, salt);
                acc.Salt = salt;
                acc.Password = hashedPassword;

                context.Users.Add(acc);
                context.SaveChanges();

                NotifySubscribers(UpdateEvent.AccountAdded);
            }
            else
                throw new Exception("Name already exists");
        }

        public void DelAccount(User acc)
        {
            using var context = new HospitalDbContext();
            User? search = context.Users.Where(user => user.Name == acc.Name).FirstOrDefault();
            if (search != null)
            {
                if (search.UserType == "Admin")
                    throw new Exception("You cannot delete an admin account!");
                context.Users.Remove(search);
                context.SaveChanges();

                NotifySubscribers(UpdateEvent.AccountDeleted);
            }
            else
                throw new Exception("User does not exist!");
        }

        public List<Medicine> GetAllMedicine()
        {
            using var context = new HospitalDbContext();
            return context.Medicines.ToList();
        }

        public void DeleteMedicine(Medicine medicament)
        {
            if (string.IsNullOrEmpty(medicament.Name))
                throw new Exception("Empty medicine name?");

            using var context = new HospitalDbContext();
            Medicine? search = context.Medicines.Where(med => med.Name == medicament.Name).FirstOrDefault();
            if (search != null)
            {
                context.Medicines.Remove(search);
                context.SaveChanges();

                NotifySubscribers(UpdateEvent.MedicineDeleted);
            }
            else
                throw new Exception("Medicine does not exist!");
        }

        public void AddMedicine(Medicine medicine)
        {
            if (string.IsNullOrEmpty(medicine.Name))
                throw new Exception("Please insert medicine name!");

            if (string.IsNullOrEmpty(medicine.Description))
                throw new Exception("Please insert medicine description!");

            using var context = new HospitalDbContext();
            Medicine? search = context.Medicines.Where(med => med.Name == medicine.Name).FirstOrDefault();
            if (search == null)
            {
                context.Medicines.Add(medicine);
                context.SaveChanges();

                NotifySubscribers(UpdateEvent.MedicineAdded);
            }
            else
                throw new Exception("Medicine name already exists");
        }

        public void ModifyMedicine(Medicine medicine, string medName)
        {
            if (string.IsNullOrEmpty(medicine.Name))
                throw new Exception("Medicine name cannot be empty!");
            if (string.IsNullOrEmpty(medicine.Description))
                throw new Exception("Medicine description cannot be empty!");
            if (string.IsNullOrEmpty(medName))
                throw new Exception("Old medicine name Empty ???!");

            using var context = new HospitalDbContext();
            Medicine? search = context.Medicines.Where(med => med.Name == medName).FirstOrDefault();
            if (search == null)
            {
                throw new Exception("Old medicine name doesnt exist ??!!");
            }
            else
            {   
                search.Description = medicine.Description;
                search.Name = medicine.Name;
                context.Medicines.Update(search);
                context.SaveChanges();

                NotifySubscribers(UpdateEvent.MedicineUpdated);
            }
        }


        //Pharmacist
        public void SolveOrder(long orderId, string status)
        { 
            using var context = new HospitalDbContext();
            Order? searched = context.Orders.Where(order => order.Id == orderId).FirstOrDefault();
            if (searched != null)
                throw new Exception("Order with such id does not exist!");
            else {
                context.Orders.Where(order => order.Id == orderId).First().Status = status;
                context.SaveChanges();

                NotifySubscribers(UpdateEvent.OrderUpdated);
            }
        }

        public List<Order> GetAllOrdersFromUser(User user)
        {
            using var context = new HospitalDbContext();
            return context.Orders.Where(order => order.SolutionPharmacist == user.Id).ToList();
        }

        //StaffForm
        public void SendOrder(Order order)
        { 
            using var context = new HospitalDbContext();
            context.Orders.Add(order);

            NotifySubscribers(UpdateEvent.OrderAdded);
        }

        public static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public static string HashPassword(string password, byte[] salt)
        {

            // Generate the hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(20);

            // Combine the salt and hash
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Convert to base64 for storage
            return Convert.ToBase64String(hashBytes);
        }




    }
}
