using System.Net.Sockets;
using System.Text.Json;
using log4net;
using Model_Persistence.Domain;
using Services;

namespace Networking
{
    public class ProxyServices : IServices
    {
        private string host;
        private int port;

        private IClientObserver client;

        private TcpClient connection;

        private StreamReader input;
        private StreamWriter output;

        private Queue<Response> responses;
        private volatile bool finished;
        private EventWaitHandle _waitHandle;

        private static readonly ILog log = LogManager.GetLogger(typeof(ProxyServices));

        public ProxyServices(string host, int port)
        {
            log.Info("Creating Proxy...");
            this.host = host;
            this.port = port;
            responses = new Queue<Response>();
            finished = false;
            _waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
        }

        ///----- INTERFACE IMPLEMENTATIONS-----
        public string GetUserType(User acc)
        {
            log.Info("Proxy level <GETTING USER TYPE>\n");
            initializeConnection();
            sendRequest(JsonUtils.CreateGetUserTypeRequest(acc));
            Response response = readResponse();
            if (response.Type == ResponseType.GetUserType)
            {
                closeConnection();
                log.InfoFormat("Proxy returning user type {0} \n", response.UserType);
                return response.UserType;
            }
            else
            {
                closeConnection();
                log.InfoFormat("Proxy getting user type failed , error : {0} \n", response.Message);
                throw new Exception("Error: " + response.Message);
            }

        }

        public void Login(User acc, IClientObserver client)
        {
            log.Info("Proxy level <LOGIN>\n");
            initializeConnection();
            sendRequest(JsonUtils.CreateLoginRequest(acc));
            Response response = readResponse();
            if (response.Type == ResponseType.Ok)
            {
                this.client = client;
                log.Info("Proxy level login succesfull\n");
                return;
            }else
            {
                closeConnection();
                log.Info("Proxy level loggin failed" + response.Message);
                throw new Exception("Error: " + response.Message);
            }
        }

        public void Logout(User acc, IClientObserver client)
        {
            log.Info("Proxy level <LOGOUT>\n");
            sendRequest(JsonUtils.CreateLogoutRequest(acc));
            Response response = readResponse();
            closeConnection();
            if (response.Type == ResponseType.Error)
            {
                log.ErrorFormat("Proxy level logout error , message: {0}\n", response.Message);
                throw new Exception("Error " + response.Message);
                
            }
            log.Info("Proxy level logout succesfull\n");
        }

        public List<User> GetAllAccounts()
        {
            log.Info("Proxy level <GetAllAccounts>\n");
            sendRequest(JsonUtils.CreateGetAllAccountsRequest());
            Response response = readResponse();
            if (response.Type == ResponseType.GetAllAccounts)
            {
                log.InfoFormat("Proxy level GetAllAccounts succesfull, returning {0} accounts\n", response.Users.Count);
                return response.Users;
            }
            else
            { 
                log.ErrorFormat("Proxy level GetAllAccounts error, message: {0}\n", response.Message);
                throw new Exception("Error: " + response.Message);
            }
        }

        public void AddAccount(User acc)
        {
            log.Info("Proxy level <ADD ACCOUNT>\n");
            sendRequest(JsonUtils.CreateAddAccountRequest(acc));
            Response response = readResponse();
            if (response.Type == ResponseType.Error)
            {
                log.ErrorFormat("Proxy level AddAccount error, message: {0}\n", response.Message);
                throw new Exception("Error: " + response.Message);
            }
        }

        public void DelAccount(User acc)
        {
            log.Info("Proxy level <DELETE ACCOUNT>\n");
            sendRequest(JsonUtils.CreateDelAccountRequest(acc));
            Response response = readResponse();
            if (response.Type == ResponseType.Error)
            {
                log.ErrorFormat("Proxy level DelAccount error, message: {0}\n", response.Message);
                throw new Exception("Error: " + response.Message);
            }
        }

        public List<Medicine> GetAllMedicines()
        {
            log.Info("Proxy level <GetAllMedicines>\n");
            sendRequest(JsonUtils.CreateGetAllMedicinesRequest());
            Response response = readResponse();
            if (response.Type == ResponseType.GetAllMedicines)
            {
                log.InfoFormat("Proxy level GetAllMedicines succesfull, returning {0} medicines\n", response.Medicines.Count);
                return response.Medicines;
            }
            else
            {
                log.ErrorFormat("Proxy level GetAllMedicines error, message: {0}\n", response.Message);
                throw new Exception("Error: " + response.Message);
            }
        }

        public void AddMedicine(Medicine medicine)
        {
            log.Info("Proxy level <AddMedicine>");
            sendRequest(JsonUtils.CreateAddMedicineRequest(medicine));
            Response response = readResponse();
            if (response.Type == ResponseType.Error)
            {
                log.ErrorFormat("Proxy level AddMedicine error, message: {0}\n", response.Message);
                throw new Exception("Error: " + response.Message);
            }
        }

        public void DelMedicine(Medicine medicine)
        {
            log.Info("Proxy level <DelMedicine>");
            sendRequest(JsonUtils.CreateDelMedicineRequest(medicine));
            Response response = readResponse();
            if (response.Type == ResponseType.Error)
            {
                log.ErrorFormat("Proxy level DelMedicine error, message: {0}\n", response.Message);
                throw new Exception("Error: " + response.Message);
            }
        }

        public void ModifyMedicine(Medicine medicine, string oldMedName)
        {
            log.Info("Proxy level <ModifyMedicine>");
            sendRequest(JsonUtils.CreateModifyMedicineRequest(medicine, oldMedName));
            Response response = readResponse();
            if (response.Type == ResponseType.Error)
            {
                log.ErrorFormat("Proxy level ModifyMedicine error, message: {0}\n", response.Message);
                throw new Exception("Error: " + response.Message);
            }
        }

        public void SendOrder(Order order)
        {
            log.Info("Proxy level <SendOrder>");
            sendRequest(JsonUtils.CreateSendOrderRequest(order));
            Response response = readResponse();
            if (response.Type == ResponseType.Error)
            { 
                log.ErrorFormat("Proxy level SendOrder error, message: {0}\n", response.Message);
                throw new Exception("Error: " + response.Message);
            }
        }

        public List<Order> GetAllOrders()
        {
            log.Info("Proxy level <GetAllOrders>");
            sendRequest(JsonUtils.CreateGetAllOrdersRequest());
            Response response = readResponse();
            if (response.Type == ResponseType.GetAllOrders)
            {
                log.InfoFormat("Proxy level GetAllOrders succesfull, returning {0} orders\n", response.Orders.Count);
                return response.Orders;
            }
            else
            {
                log.ErrorFormat("Proxy level GetAllOrders error, message: {0}\n", response.Message);
                throw new Exception("Error: " + response.Message);
            }
        }

        public List<Order> GetAllPendingOrders()
        {
            log.Info("Proxy level <GetAllPendingOrders>");
            sendRequest(JsonUtils.CreateGetAllPendingOrdersRequest());
            Response response = readResponse();
            if (response.Type == ResponseType.GetAllPendingOrders)
            { 
                return response.Orders;
            }else
                throw new Exception("Error: " + response.Message);
        }

        public void SolveOrder(int orderId, string status)
        {
            sendRequest(JsonUtils.CreateSolveOrderRequest(orderId, status));
            Response response = readResponse();
            if (response.Type == ResponseType.Error)
            {
                log.ErrorFormat("Proxy level SolveOrder error, message: {0}\n", response.Message);
                throw new Exception("Error: " + response.Message);
            }
        }

        ///--------------------------------------



        private void initializeConnection()
        {
            log.Info("proxy initializing connection");
            try
            {
                connection = new TcpClient(host, port);
                input = new StreamReader(connection.GetStream());
                output = new StreamWriter(connection.GetStream());
                finished = false;
                _waitHandle = new AutoResetEvent(false);
                startReader();
            }
            catch (SocketException e)
            {
                log.Error("Error: " + e.Message);
            }
            catch (IOException e)
            {
                log.Error("Error: " + e.Message);
            }
            log.Info("connection initialized succesfully");

        }

        private void startReader()
        {
            log.Info("starting reader");
            Thread thread = new Thread(run);
            thread.Start();
            log.Info("started reader");
        }

        private void closeConnection()
        {
            finished = true;
            try
            {
                input.Close();
                output.Close();
                connection.Close();
                _waitHandle.Close();
            }
            catch (IOException e)
            {
                log.Error("Error: " + e.Message);
            }
        }

        private void sendRequest(Request request)
        {
            string reqLine = JsonSerializer.Serialize(request);
            log.Info("Request Line: " + reqLine);
            try
            {
                output.WriteLine(reqLine);
                output.Flush();
            }
            catch (IOException e)
            {
                throw new Exception("Error sending object " + e);
            }
        }

        private Response readResponse()
        {
            log.Info("Reading respone ...");
            Response response = null;
            try
            {
                _waitHandle.WaitOne();
                lock (responses)
                {
                    response = responses.Dequeue();
                }
            }
            catch (Exception e)
            {
                log.Error("Error: " + e.Message);
            }
            log.Info("Returning response ...");
            return response;
        }

        private void handleUpdate(Response updateR)
        {
            log.InfoFormat("Handling update {0}", updateR);
            if (updateR.Type == ResponseType.AccountAdded)
            {
                try
                {
                    client.AccountAdded(updateR.User);
                }
                catch (Exception e)
                {
                    log.Error("Error: " + e.Message);
                }
            }
            else if (updateR.Type == ResponseType.AccountDeleted)
            {
                try
                {
                    client.AccountDeleted(updateR.User);
                }
                catch (Exception e)
                {
                    log.Error("Error: " + e.Message);
                }
            }
            else if (updateR.Type == ResponseType.MedicineAdded)
            {
                try
                {
                    client.MedicineAdded(updateR.Medicine);
                }
                catch (Exception e)
                {
                    log.Error("Error: " + e.Message);
                }
            }
            else if (updateR.Type == ResponseType.MedicineDeleted)
            {
                try
                {
                    client.MedicineDeleted(updateR.Medicine);
                }
                catch (Exception e)
                {
                    log.Error("Error: " + e.Message);
                }
            }
            else if (updateR.Type == ResponseType.MedicineModified)
            {
                try
                {
                    client.MedicineModified(updateR.Medicine, updateR.OldMedName);
                }
                catch (Exception e)
                {
                    log.Error("Error: " + e.Message);
                }
            }
            else if (updateR.Type == ResponseType.OrderSent)
            {
                try 
                {
                    client.OrderSent(updateR.Order);
                }catch(Exception e)
                {
                    log.Error("Error: " + e.Message);
                }
            }
            else if (updateR.Type == ResponseType.OrderSolved)
            {
                try
                {
                    client.OrderSolved(updateR.Order);
                }
                catch (Exception e)
                {
                    log.Error("Error: " + e.Message);
                }
            }
                log.InfoFormat("Handling finished for update {0}", updateR);
        }

        public bool isUpdateResponse(Response response)
        {
            return response.Type == ResponseType.AccountAdded || response.Type == ResponseType.AccountDeleted
                || response.Type == ResponseType.MedicineAdded || response.Type == ResponseType.MedicineDeleted
                || response.Type == ResponseType.MedicineModified || response.Type == ResponseType.OrderSent ||
                response.Type == ResponseType.OrderSolved;
        }

        public virtual void run()
        {
            while (!finished)
            {
                try
                {
                    string responseLine = input.ReadLine();
                    Response response = JsonSerializer.Deserialize<Response>(responseLine);
                    if (isUpdateResponse(response) && client != null)
                    {
                        handleUpdate(response);
                    }
                    else
                    {
                        lock (responses)
                        {
                            responses.Enqueue(response);
                        }
                        _waitHandle.Set();
                    }
                }
                catch (Exception e)
                {
                    log.Error("Error reading" + e.Message);
                }
            }
        }
    }
}
