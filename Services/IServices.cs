using Model_Persistence.Domain;

namespace Services
{
    public interface IServices
    {
        public string GetUserType(User acc);

        public void Login(User acc,IClientObserver client);
        public void Logout(User acc, IClientObserver client);
        
        
        public List<User> GetAllAccounts();
        public void AddAccount(User acc);
        public void DelAccount(User acc);


        
        public List<Medicine> GetAllMedicines();
        public void AddMedicine(Medicine medicine);
        public void DelMedicine(Medicine medicine);
        public void ModifyMedicine(Medicine medicine, string oldMedName);

        public void SendOrder(Order order);
        public List<Order> GetAllOrders();
        
        public List<Order> GetAllPendingOrders();
        public void SolveOrder(int orderId, string status); 
        
    }
}
