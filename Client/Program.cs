using log4net.Config;
using log4net;
using Services;
using System.Reflection;
using Networking;

namespace Client
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        private static ILog log = LogManager.GetLogger(typeof(Program));

        [STAThread]
        static void Main()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetExecutingAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            IServices proxy = new ProxyServices("127.0.0.1", 5006);


            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm(proxy));
        }
    }
}