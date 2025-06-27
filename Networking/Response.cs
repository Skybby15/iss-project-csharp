using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_Persistence.Domain;

namespace Networking
{
    public class Response
    {
        public ResponseType Type { get; set; }

        public string UserType { get; set; } // GetUserType,
        public string Message { get; set; } // Error
        public List<User> Users { get; set; }// GetAllAccounts
        public User User { get; set; } // AccountAdded, AccountDeleted

        public List<Medicine> Medicines { get; set; } // GetAllMedicines
        public Medicine Medicine { get; set; } // MedicineAdded, MedicineDeleted, MedicineModified
        public string OldMedName { get; set; } //                                MedicineModified

        public Order Order { get; set; } // OrderSent, OrderSolved
        public List<Order> Orders { get; set; } // GetAllOrders, GetAllPendingOrders
    }
}
