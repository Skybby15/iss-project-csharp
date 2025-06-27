using Hospital_App.ServiceNameSpace;

namespace Hospital_App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Service service = new Service();

            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm(service));
        }
    }
}