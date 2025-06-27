using Services;
using Model_Persistence.Domain;
using Hospital_App;

namespace Client
{
    public partial class LoginForm : Form
    {
        private readonly IServices server;

        public LoginForm(IServices proxy)
        {
            this.server = proxy;
            InitializeComponent();
            
        }

        private void login_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string pass = passwordTextBox.Text;

            try
            {
                User logging = new User() { Name = name, Password = pass };
                string userType = server.GetUserType(logging);

                IClientObserver observer = null;

                if (userType == "Admin")
                    observer = new AdminForm(server);
                else if (userType == "Pharmacist")
                    observer = new FarmacistForm(server);
                else if (userType == "MedicalStaff")
                    observer = new StaffForm(server);
                else
                    throw new Exception("Client error: user type invalid !");

                server.Login(logging,observer);

                if (observer is Form mainWindow)
                {
                    Hide();
                    mainWindow.FormClosed += (s, args) => server.Logout(logging,observer);
                    mainWindow.FormClosed += (s, args) => Close();

                    mainWindow.Show();
                }
                else
                    throw new Exception("Client error: cast did not work!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


        }
    }
}
