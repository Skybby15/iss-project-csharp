using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    public enum ResponseType
    {
        //trivial
        Ok,Error,
        //normal
        GetUserType,GetAllAccounts,GetAllMedicines,GetAllOrders,GetAllPendingOrders,
        //update
        AccountAdded, AccountDeleted,MedicineAdded,MedicineDeleted, MedicineModified,OrderSent,OrderSolved

    }
}
