using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using log4net;
using Model_Persistence.Domain;
using Services;

namespace Networking
{
    internal class ClientWorker : IClientObserver
    {
        private IServices server;
        private TcpClient connection;

        private StreamReader input;
        private StreamWriter output;

        private volatile bool connected;

        private static readonly ILog log = LogManager.GetLogger(typeof(ClientWorker));

        public ClientWorker(IServices server, TcpClient connection)
        {
            log.Info("Creating worker\n");
            this.server = server;
            try
            {
                this.connection = connection;
                input = new StreamReader(connection.GetStream());
                output = new StreamWriter(connection.GetStream());

                connected = true;
            }
            catch (Exception e)
            {
                log.Error("Error: " + e.Message + "\n");
            }
        }

        public virtual void run()
        {
            while (connected)
            {
                try
                {
                    string? requestLine = input.ReadLine();
                    log.Info("Request line received: " + requestLine + "\n");
                    Request? request = JsonSerializer.Deserialize<Request>(requestLine);
                    Response? response = handleRequest(request);
                    if (response != null)
                    {
                        sendResponse((Response)response);
                    }
                }
                catch (Exception e)
                {
                    log.Error("Error: " + e.Message);
                }

                try
                {
                    Thread.Sleep(200);
                }
                catch (Exception e)
                {
                    log.Error("Error ThreadSleep: " + e.Message);
                }
            }
            input.Close();
            output.Close();
            connection.Close();
        }

        
        private Response? handleRequest(Request request)
        {
            log.Info("Handling request: "+request.Type+"\n");
            if (request.Type == RequestType.GetUserType)
            {
                string userType;

                try
                {
                    lock (server)
                    {
                        userType = server.GetUserType(request.User);
                    }

                    log.InfoFormat("Handled GetUserType succesful, sending usertype {0}", userType);
                    connected = false;
                    return JsonUtils.CreateUserTypeResponse(userType);
                }
                catch (Exception exc)
                {
                    log.ErrorFormat("Error while handling GetUserType Request: {0}", exc.Message);
                    connected = false;
                    return JsonUtils.CreateErrorResponse(exc.Message);
                }
            }
            else if (request.Type == RequestType.Login)
            {
                try
                {
                    lock (server)
                    {
                        server.Login(request.User, this);
                    }
                    log.Info("Handled Login succesful");
                    return JsonUtils.CreateOkResponse();

                }
                catch (Exception exc)
                {
                    log.ErrorFormat("Error handling login , message : {0}", exc.Message);
                    connected = false;
                    return JsonUtils.CreateErrorResponse(exc.Message);
                }
            }
            else if (request.Type == RequestType.Logout)
            {
                try
                {
                    lock (server)
                    {
                        server.Logout(request.User, this);
                    }
                    connected = false;
                    log.Info("Handled Logout succesful");
                    return JsonUtils.CreateOkResponse();
                }
                catch (Exception exc)
                {
                    log.ErrorFormat("Error handling logout , message : {0}", exc.Message);
                    return JsonUtils.CreateErrorResponse(exc.Message);
                }
            }
            else if (request.Type == RequestType.GetAllAccounts)
            {
                try
                {
                    List<User> users;
                    lock (server)
                    {
                        users = server.GetAllAccounts();
                    }
                    log.Info("Handled GetAllAccounts succesful");
                    return JsonUtils.CreateGetAllAccountsResponse(users);
                }
                catch (Exception exc)
                {
                    log.ErrorFormat("Error handling GetAllAccounts , message: {0}", exc.Message);
                    return JsonUtils.CreateErrorResponse(exc.Message);
                }
            }
            else if (request.Type == RequestType.AddAccount)
            {
                try
                {
                    lock (server)
                    {
                        server.AddAccount(request.User);
                    }

                    log.Info("Handled AddAccount succesful");
                    return JsonUtils.CreateOkResponse();
                }
                catch (Exception exc)
                {
                    log.ErrorFormat("Error handling AddAccount , message: {0}", exc.Message);
                    return JsonUtils.CreateErrorResponse(exc.Message);
                }
            }
            else if (request.Type == RequestType.DelAccount)
            {
                try
                {
                    lock (server)
                    {
                        server.DelAccount(request.User);
                    }

                    log.Info("Handled DelAccount succesful");
                    return JsonUtils.CreateOkResponse();
                }
                catch (Exception exc)
                {
                    log.ErrorFormat("Error handling DelAccount , message: {0}", exc.Message);
                    return JsonUtils.CreateErrorResponse(exc.Message);
                }
            }
            else if (request.Type == RequestType.GetAllMedicines)
            {
                try
                {
                    List<Medicine> medicines;
                    lock (server)
                    {
                        medicines = server.GetAllMedicines();
                    }
                    log.Info("Handled GetAllMedicines succesful");
                    return JsonUtils.CreateGetAllMedicinesResponse(medicines);
                }
                catch (Exception exc)
                {
                    log.ErrorFormat("Error handling GetAllMedicines , message: {0}", exc.Message);
                    return JsonUtils.CreateErrorResponse(exc.Message);
                }
            }
            else if (request.Type == RequestType.AddMedicine)
            {
                try
                {
                    lock (server)
                    {
                        server.AddMedicine(request.Medicine);
                    }
                    log.Info("Handled AddMedicine succesful");
                    return JsonUtils.CreateOkResponse();
                }
                catch (Exception exc)
                {
                    log.ErrorFormat("Error handling AddMedicine , message: {0}", exc.Message);
                    return JsonUtils.CreateErrorResponse(exc.Message);
                }
            }
            else if (request.Type == RequestType.DelMedicine)
            {
                try
                {
                    lock (server)
                    {
                        server.DelMedicine(request.Medicine);
                    }
                    log.Info("Handled DelMedicine succesful");
                    return JsonUtils.CreateOkResponse();
                }
                catch (Exception exc)
                {
                    log.ErrorFormat("Error handling DelMedicine , message: {0}", exc.Message);
                    return JsonUtils.CreateErrorResponse(exc.Message);
                }
            }
            else if (request.Type == RequestType.ModifyMedicine)
            {
                try
                {
                    lock (server)
                    {
                        server.ModifyMedicine(request.Medicine, request.OldMedName);
                    }
                    log.Info("Handled ModifyMedicine succesful");
                    return JsonUtils.CreateOkResponse();
                }
                catch (Exception exc)
                {
                    log.ErrorFormat("Error handling ModifyMedicine , message: {0}", exc.Message);
                    return JsonUtils.CreateErrorResponse(exc.Message);
                }
            }
            else if (request.Type == RequestType.SendOrder)
            {
                try
                {
                    lock (server)
                    {
                        server.SendOrder(request.Order);
                    }
                    log.Info("Handled SendOrder succesfully");
                    return JsonUtils.CreateOkResponse();
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                    log.ErrorFormat("Error handling SendOrder , message: {0}", exc.Message);
                    return JsonUtils.CreateErrorResponse(exc.Message);
                }
            }
            else if (request.Type == RequestType.GetAllOrders)
            {
                try
                {
                    List<Order> orders;
                    lock (server)
                    {
                        orders = server.GetAllOrders();
                    }
                    log.Info("Handled GetAllOrders succesfully");
                    return JsonUtils.CreateGetAllOrdersResponse(orders);
                }
                catch (Exception exc)
                {
                    log.ErrorFormat("Error handling GetAllOrders, message: {0}", exc.Message);
                    return JsonUtils.CreateErrorResponse(exc.Message);
                }
            }
            else if (request.Type == RequestType.GetAllPendingOrders)
            {
                try
                {
                    List<Order> orders;
                    lock (server)
                    {
                        orders = server.GetAllPendingOrders();
                    }
                    log.Info("Handled GetAllOrders succesfully");
                    return JsonUtils.CreateGetAllPendingOrdersResponse(orders);
                }
                catch (Exception exc)
                {
                    log.ErrorFormat("Error handling GetAllOrders, message: {0}", exc.Message);
                    return JsonUtils.CreateErrorResponse(exc.Message);
                }
            }
            else if (request.Type == RequestType.SolveOrder)
            {
                try
                {
                    lock(server)
                    {
                        server.SolveOrder(request.OrderId, request.Status);
                    }

                    return JsonUtils.CreateOkResponse();
                }
                catch(Exception exc)
                {
                    return JsonUtils.CreateErrorResponse(exc.Message);
                }
            }
            else
                log.Error("Unknown request type: " + request.Type + "\n");

            return null;
        }

        private void sendResponse(Response response)
        {
            log.Info("Sending response: " + JsonSerializer.Serialize(response) + "\n");
            lock (output)
            {
                output.WriteLine(JsonSerializer.Serialize(response));
                output.Flush();
            }
        }

        public void AccountAdded(User acc)
        {
            sendResponse(JsonUtils.CreateAccountAddedResponse(acc));
        }

        public void AccountDeleted(User acc)
        {
            sendResponse(JsonUtils.CreateAccountDeletedResponse(acc));
        }

        public void MedicineAdded(Medicine med)
        {
            sendResponse(JsonUtils.CreateMedicineAddedResponse(med));
        }

        public void MedicineDeleted(Medicine med)
        {
            sendResponse(JsonUtils.CreateMedicineDeletedResponse(med));
        }

        public void MedicineModified(Medicine med, string oldMedName)
        {
            sendResponse(JsonUtils.CreateMedicineModifiedResponse(med, oldMedName));
        }

        public void OrderSent(Order order)
        {
            sendResponse(JsonUtils.CreateOrderSentResponse(order));
        }

        public void OrderSolved(Order order)
        {
            sendResponse(JsonUtils.CreateOrderSolvedResponse(order));
        }
    }
}
