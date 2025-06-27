using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_Persistence.Domain;

namespace Networking
{
    public class JsonUtils
    {
        //-----------------------Requests--------------------------
        public static Request CreateRequest()
        {
            return new Request();
        }

        public static Request CreateGetUserTypeRequest(User acc)
        {
            return new Request() 
            { 
                Type = RequestType.GetUserType,
                User = acc
            };
        }

        public static Request CreateLoginRequest(User acc)
        {
            return new Request()
            {
                Type = RequestType.Login,
                User = acc
            };
        }

        public static Request CreateLogoutRequest(User acc)
        {
            return new Request()
            {
                Type = RequestType.Logout,
                User = acc
            };
        }

        public static Request CreateGetAllAccountsRequest()
        {
            return new Request()
            {
                Type = RequestType.GetAllAccounts,
            };
        }

        public static Request CreateAddAccountRequest(User acc)
        { 
            return new Request()
            {
                Type = RequestType.AddAccount,
                User = acc
            };
        }

        public static Request CreateDelAccountRequest(User acc)
        { 
            return new Request()
            {
                Type = RequestType.DelAccount,
                User = acc
            };
        }

        public static Request CreateGetAllMedicinesRequest()
        {
            return new Request()
            {
                Type = RequestType.GetAllMedicines,
            };
        }

        public static Request CreateAddMedicineRequest(Medicine med)
        {
            return new Request()
            {
                Type = RequestType.AddMedicine,
                Medicine = med
            };
        }

        public static Request CreateDelMedicineRequest(Medicine med)
        {
            return new Request()
            {
                Type = RequestType.DelMedicine,
                Medicine = med
            };
        }

        public static Request CreateModifyMedicineRequest(Medicine med, string oldMedName)
        {
            return new Request()
            {
                Type = RequestType.ModifyMedicine,
                Medicine = med,
                OldMedName = oldMedName
            };
        }

        public static Request CreateSendOrderRequest(Order order)
        { 
            return new Request()
            { 
                Type = RequestType.SendOrder,
                Order = order,
            };
        }

        public static Request CreateGetAllOrdersRequest()
        {
            return new Request()
            {
                Type = RequestType.GetAllOrders,
            };
        }

        public static Request CreateGetAllPendingOrdersRequest()
        {
            return new Request()
            {
                Type = RequestType.GetAllPendingOrders,
            };
        }

        public static Request CreateSolveOrderRequest(int orderId, string status)
        {
            return new Request()
            {
                Type = RequestType.SolveOrder,
                OrderId = orderId,
                Status = status
            };
        }

        //----------------------Responses---------------------------
        public static Response CreateResponse()
        {
            return new Response();
        }

        public static Response CreateUserTypeResponse(string userType)
        {
            return new Response()
            {
                Type = ResponseType.GetUserType,
                UserType = userType
            };
        }

        public static Response CreateOkResponse()
        {
            return new Response()
            {
                Type = ResponseType.Ok,
            };
        }

        public static Response CreateErrorResponse(string message)
        {
            return new Response() 
            { 
                Type = ResponseType.Error,
                Message = message
            };
        }

        public static Response CreateGetAllAccountsResponse(List<User> accounts)
        {
            return new Response()
            {
                Type = ResponseType.GetAllAccounts,
                Users = accounts
            };
        }

        public static Response CreateAccountAddedResponse(User acc)
        {
            return new Response()
            {
                Type = ResponseType.AccountAdded,
                User = acc,
            };
        }

        public static Response CreateAccountDeletedResponse(User acc)
        {
            return new Response()
            {
                Type = ResponseType.AccountDeleted,
                User = acc,
            };
        }

        public static Response CreateGetAllMedicinesResponse(List<Medicine> medicines)
        {
            return new Response()
            {
                Type = ResponseType.GetAllMedicines,
                Medicines = medicines
            };
        }

        public static Response CreateMedicineAddedResponse(Medicine medicine)
        {
            return new Response()
            {
                Type = ResponseType.MedicineAdded,
                Medicine = medicine
            };
        }

        public static Response CreateMedicineDeletedResponse(Medicine medicine)
        {
            return new Response()
            {
                Type = ResponseType.MedicineDeleted,
                Medicine = medicine
            };
        }

        public static Response CreateMedicineModifiedResponse(Medicine medicine, string oldMedName)
        {
            return new Response()
            {
                Type = ResponseType.MedicineModified,
                Medicine = medicine,
                OldMedName = oldMedName
            };
        }

        public static Response CreateOrderSentResponse(Order order)
        {
            return new Response()
            {
                Type = ResponseType.OrderSent,
                Order = order,
            };
        }

        public static Response CreateGetAllOrdersResponse(List<Order> orders)
        {
            return new Response()
            {
                Type = ResponseType.GetAllOrders,
                Orders = orders
            };
        }

        public static Response CreateGetAllPendingOrdersResponse(List<Order> orders)
        {
            return new Response()
            {
                Type = ResponseType.GetAllPendingOrders,
                Orders = orders
            };
        }

        public static Response CreateOrderSolvedResponse(Order order)
        {
            return new Response()
            {
                Type = ResponseType.OrderSolved,
                Order = order
            };
        }
    }
}
