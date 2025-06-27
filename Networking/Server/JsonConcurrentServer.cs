using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace Networking.Server
{
    public class JsonConcurrentServer : ConcurrentServer
    {
        private IServices server;
        private ClientWorker worker;

        public JsonConcurrentServer(string host, int port, IServices server) : base(host, port)
        {
            this.server = server;
            Console.WriteLine("JsonConcurrentServer created");
        }

        protected override Thread createWorker(TcpClient client)
        {
            worker = new ClientWorker(server, client);
            return new Thread(worker.run);
        }

    }
}
