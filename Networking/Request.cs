using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Model_Persistence.Domain;

namespace Networking
{
    public class Request
    {
        public RequestType Type { get; set; }

        public User User { get; set; }//GetUserType, Login, AddAccount, DelAccount
        public Medicine Medicine { get; set; } //AddMedicine, DelMedicine, ModifyMedicine
        public string OldMedName { get; set; } //                           ModifyMedicine

        public Order Order { get; set; } //SendOrder ,
        public int OrderId { get; set; } //           SolveOrder
        public string Status { get; set; } //           SolveOrder
    }
}
