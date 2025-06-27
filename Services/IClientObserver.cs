using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_Persistence.Domain;

namespace Services
{
    public interface IClientObserver
    {
        public void AccountAdded(User acc);
        public void AccountDeleted(User acc);

        public void MedicineAdded(Medicine med);
        public void MedicineDeleted(Medicine med);
        public void MedicineModified(Medicine med,string oldMedName);

        public void OrderSent(Order order);

        public void OrderSolved(Order order);
    }
}
