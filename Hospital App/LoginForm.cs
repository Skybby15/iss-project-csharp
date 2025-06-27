using Hospital_App.ServiceNameSpace;
using Hospital_App.Domain;

namespace Hospital_App
{
    public partial class LoginForm : Form
    {
        private Service service;

        public LoginForm(Service service)
        {
            this.service = service;
            InitializeComponent();
            
        }

        private void login_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string pass = passwordTextBox.Text;

            int res;
            try
            {
                res = service.Login(new User() { Password = pass, Name = name });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            switch (res)
            {
                case 0:
                    Form admin = new AdminForm(service);
                    admin.FormClosed += (s, args) => this.Close();
                    //this.Hide();
                    admin.Show();
                    break;
                case 1:
                    Form farmacist = new FarmacistForm(service);
                    farmacist.FormClosed += (s, args) => this.Close();
                    //this.Hide();
                    farmacist.Show();
                    break;
                case 2:
                    Form staff = new StaffForm(service);
                    staff.FormClosed += (s, args) => this.Close();
                    //this.Hide();
                    staff.Show();
                    break;
                case -1:
                    MessageBox.Show("Error while logging in!");
                    break;
            }


        }
    }
}
