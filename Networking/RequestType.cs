using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    public enum RequestType
    {
        GetUserType,Login,Logout,GetAllAccounts,GetAllMedicines,GetAllOrders,GetAllPendingOrders,
        AddAccount, DelAccount,
        AddMedicine, DelMedicine, ModifyMedicine,
        SendOrder,SolveOrder
    }
}
