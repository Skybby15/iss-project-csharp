using log4net.Config;
using log4net;
using System.Reflection;
using Model_Persistence.Domain;
using System.Collections.Specialized;
using System.Configuration;
using Networking.Server;
using System.Runtime;

namespace Server
{
    internal class StartServer
    {
        private static int defaultPort = 55555;
        private static ILog log = LogManager.GetLogger(typeof(StartServer));

        static void Main(string[] args)
        {
            string basePath = AppContext.BaseDirectory;
            string databasePath = Path.Combine(basePath, "HospitalDB.db");

            var logRepository = LogManager.GetRepository(Assembly.GetExecutingAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            log.Info("Application starting");


            NameValueCollection networkSettings = ConfigurationManager.AppSettings;

            if (networkSettings != null)
            {
                log.Info("Initializing props");
                IDictionary<string, string> props = new SortedList<String, String>();
                props.Add("ServerPort", networkSettings["Port"]);
                props.Add("ServerHost", networkSettings["Host"]);

                Console.WriteLine(databasePath);
                HospitalDbContext.Path = databasePath;
                NetServices mainService = new NetServices();

                AbstractServer server = new JsonConcurrentServer(props["ServerHost"], int.Parse(props["ServerPort"]), mainService);

                try
                {
                    server.Start();
                }
                catch (Exception e)
                {
                    log.Error("Server start error", e);
                }
            }
            else
            {
                log.Error("Server start error");
                return;
            }
        }

    }
}

