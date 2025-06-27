using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using log4net;
using Model_Persistence.Domain;
using Networking;
using Services;

namespace Server
{
    internal class NetServices : IServices
    {
        private readonly IDictionary<long, IClientObserver> loggedClients;

        private static readonly ILog log = LogManager.GetLogger(typeof(NetServices));

        public NetServices()
        {
            log.Info("Creating NetServices");
            loggedClients = new ConcurrentDictionary<long, IClientObserver>();
        }

        public string GetUserType(User acc) {
            log.InfoFormat("Entering NetService GetUserType with name : {0}",acc.Name);

            using var context = new HospitalDbContext();
            string? userType = context.Users.FirstOrDefault(usr => usr.Name == acc.Name)?.UserType;
            if (userType == null)
            {
                log.Error("Throwing in NetServices GetUserType");
                throw new Exception("No user with such name exists!");
            }

            log.InfoFormat("Exiting NetService GetUserType with type : {0}", userType);
            return userType;
        }

        public void Login(User acc, IClientObserver client)
        {
            log.InfoFormat("Entering NetServices Login with Name: {0}",acc.Name);

            using var context = new HospitalDbContext();
            User? tryingToLog = context.Users.FirstOrDefault(usr => usr.Name == acc.Name);
            if (tryingToLog != null)
            {
                string actualPassword = HashPassword(acc.Password, tryingToLog.Salt);
                if (!tryingToLog.Password.Equals(actualPassword))
                    throw new Exception("Invalid Credentials pass");

                if (loggedClients.ContainsKey(tryingToLog.Id))
                {
                    log.Info("NetServer login error , user already logged in ");
                    throw new Exception("User already logged in!");
                }

                loggedClients.Add(tryingToLog.Id, client);
            }
            else
                throw new Exception("Invalid Credentials user");

            log.Info("Exiting NetServices Login");
        }

        public void Logout(User acc, IClientObserver client)
        {
            log.InfoFormat("Entering NetServices Logout with Name: {0}", acc.Name);
            using var context = new HospitalDbContext();
            User? tryingToLogOut = context.Users.FirstOrDefault(usr => usr.Name == acc.Name);
            if (tryingToLogOut == null)
                throw new Exception("This user does not exist !?");
            if (!loggedClients.Remove(tryingToLogOut.Id))
                throw new Exception("This user is not logged in !?");
        }

        public List<User> GetAllAccounts()
        {
            log.Info("Entering NetServices GetAllAccounts");
            using var context = new HospitalDbContext();
            return context.Users.ToList();
        }

        public void AddAccount(User acc)
        {
            log.Info("Entering NetService AddAccount");
            using var context = new HospitalDbContext();
            User? search = context.Users.FirstOrDefault(user => user.Name == acc.Name);

            if (search != null)
                throw new Exception("An account with this name already exists!");

            acc.Salt = GenerateSalt();
            acc.Password = HashPassword(acc.Password, acc.Salt);

            context.Users.Add(acc);
            context.SaveChanges();

            NotifyAccountAdded(acc);
        }

        public void DelAccount(User acc)
        {
            log.Info("Entering NetService DelAccount");
            using var context = new HospitalDbContext();
            User? search = context.Users.FirstOrDefault(user => user.Name == acc.Name);

            if (search == null)
                throw new Exception("Account does not exist!");

            context.Users.Remove(search);
            context.SaveChanges();

            
            NotifyAccountDeleted(search);
        }

        public List<Medicine> GetAllMedicines()
        {
            log.Info("Entering Net GetAllMedicines");
            using var context = new HospitalDbContext();
            List<Medicine> medicines = context.Medicines.ToList();
            log.InfoFormat("Exiting Net GetAllMedicines with {0} medicines", medicines.Count);
            return medicines;
        }

        public void AddMedicine(Medicine medicine)
        {
            log.Info("Entering NetService AddMedicine");
            using var context = new HospitalDbContext();
            Medicine? search = context.Medicines.FirstOrDefault(med => med.Name == medicine.Name);

            if (search != null)
                throw new Exception("A medicine with this name already exists!");
            context.Medicines.Add(medicine);
            context.SaveChanges();


            NotifyMedicineAdded(medicine);
            log.Info("Exiting NetService AddMedicine");
        }

        public void DelMedicine(Medicine medicine)
        {
            log.Info("Entering NetService DelMedicine");
            using var context = new HospitalDbContext();
            Medicine? search = context.Medicines.FirstOrDefault(med => med.Name == medicine.Name);
            if (search == null)
                throw new Exception("Medicine does not exist!");
            context.Medicines.Remove(search);
            context.SaveChanges();


            NotifyMedicineDeleted(search);
            log.Info("Exiting NetService DelMedicine");
        }

        public void ModifyMedicine(Medicine medicine, string oldMedName)
        {
            log.Info("Entering NetService ModifyMedicine");
            using var context = new HospitalDbContext();
            Medicine? search = context.Medicines.FirstOrDefault(med => med.Name == oldMedName);
            if (search == null)
                throw new Exception("Medicine does not exist!");
            search.Name = medicine.Name;
            search.Description = medicine.Description;
            context.SaveChanges();

            NotifyMedicineModified(search, oldMedName);
            log.Info("Exiting NetService ModifyMedicine");
        }

        public void SendOrder(Order order)
        {
            log.Info("Entering NetService SendOrder");
            using var context = new HospitalDbContext();


            foreach(var orderMed in order.OrderMedicines)
            {
                Medicine? search = context.Medicines.FirstOrDefault(med => med.Name == orderMed.Medicine.Name);
                orderMed.Medicine = search;
            }

            context.Orders.Add(order);

            context.SaveChanges();

            //because the json serializer cannot send looping references
            order.OrderMedicines = [];

            NotifyOrderSent(order);
        }

        public List<Order> GetAllOrders()
        {
            log.Info("Entering&Exiting NetService GetAllOrders");
            using var context = new HospitalDbContext();
            return context.Orders.Select(order => new Order 
            {
                Id = order.Id,
                OrderTime = order.OrderTime,
                Details = order.Details,
                Status = order.Status,
                SolutionPharmacist = order.SolutionPharmacist,
                SolutionTime = order.SolutionTime
            }).ToList();
        }

        public List<Order> GetAllPendingOrders()
        {
            log.Info("Entering&Exiting NetService GetAllOrders");
            using var context = new HospitalDbContext();
            return context.Orders.Select(order => new Order
            {
                Id = order.Id,
                OrderTime = order.OrderTime,
                Details = order.Details,
                Status = order.Status,
                SolutionPharmacist = order.SolutionPharmacist,
                SolutionTime = order.SolutionTime
            }).Where(order => order.Status == "Pending")
                .ToList();
        }

        public void SolveOrder(int orderId, string status)
        {
            log.Info("assdsds");
            using var context = new HospitalDbContext();
            Order? search = context.Orders.FirstOrDefault(order => order.Id == orderId);
            if (search == null)
                throw new Exception("Order does not exist!");
            search.Status = status;
            search.SolutionTime = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            context.SaveChanges();
            search.OrderMedicines = new List<OrderMedicine>();
            NotifyOrderSolved(search);
        }

        //------------Notifications--------------------------

        private void NotifyAccountAdded(User acc)
        {
            log.Info("Notifying account added");
            foreach (var userId in loggedClients.Keys)
            {
                if (loggedClients.ContainsKey(userId))
                {
                    IClientObserver client = loggedClients[userId];
                    Task.Run(() => client.AccountAdded(acc));
                }
            }
        }

        private void NotifyAccountDeleted(User acc)
        {
            log.Info("Notifying account deleted");
            foreach (var userId in loggedClients.Keys)
            {
                if (loggedClients.ContainsKey(userId))
                {
                    IClientObserver client = loggedClients[userId];
                    Task.Run(() => client.AccountDeleted(acc));
                }
            }
        }

        private void NotifyMedicineAdded(Medicine med)
        {
            log.Info("Notifying medicine added");
            foreach (var userId in loggedClients.Keys)
            {
                if (loggedClients.ContainsKey(userId))
                {
                    IClientObserver client = loggedClients[userId];
                    Task.Run(() => client.MedicineAdded(med));
                }
            }
        }

        private void NotifyMedicineDeleted(Medicine med)
        {
            log.Info("Notifying medicine deleted");
            foreach (var userId in loggedClients.Keys)
            {
                if (loggedClients.ContainsKey(userId))
                {
                    IClientObserver client = loggedClients[userId];
                    Task.Run(() => client.MedicineDeleted(med));
                }
            }
        }

        private void NotifyMedicineModified(Medicine med, string oldMedName)
        {
            log.Info("Notifying medicine modified");
            foreach (var userId in loggedClients.Keys)
            {
                if (loggedClients.ContainsKey(userId))
                {
                    IClientObserver client = loggedClients[userId];
                    Task.Run(() => client.MedicineModified(med, oldMedName));
                }
            }
        }

        private void NotifyOrderSent(Order order)
        {
            log.Info("Notifying order added");
            foreach (var userId in loggedClients.Keys)
            {
                if (loggedClients.ContainsKey(userId))
                {
                    IClientObserver client = loggedClients[userId];
                    Task.Run(() => client.OrderSent(order));
                }
            }
        }

        private void NotifyOrderSolved(Order order)
        {
            log.Info("Notifying order solved");
            foreach (var userId in loggedClients.Keys)
            {
                if (loggedClients.ContainsKey(userId))
                {
                    IClientObserver client = loggedClients[userId];
                    Task.Run(() => client.OrderSolved(order));
                }
            }
        }

        //---------------------------------------------------


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
