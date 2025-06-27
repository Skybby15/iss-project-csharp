
using Model_Persistence.Domain;
using Services;

namespace Client
{
    public partial class AdminForm : Form, IClientObserver
    {
        private readonly IServices server;

        public AdminForm(IServices proxy)
        {
            this.server = proxy;
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            usersListView.Items.Clear();

            foreach (var user in this.server.GetAllAccounts())
            {
                ListViewItem item = new ListViewItem(user.UserType);
                item.SubItems.Add(user.Name);
                usersListView.Items.Add(item);
            }

            userTypeCB.Items.AddRange(["Pharmacist", "MedicalStaff", "Admin"]);

            //meds

            medsListView.Items.Clear();

            foreach (var med in this.server.GetAllMedicines())
            {
                ListViewItem item = new ListViewItem(med.Name);
                item.SubItems.Add(med.Description);
                medsListView.Items.Add(item);
            }

            selectedMedNameTB.Visible = false;
            selectedMedDescriptionTB.Visible = false;
            modifyMedButton.Visible = false;
        }

        //------------------Updates-------------------
        public void AccountAdded(User acc)
        {
            ListViewItem item = new ListViewItem(acc.UserType);
            item.SubItems.Add(acc.Name);
            usersListView.Items.Add(item);
        }

        public void AccountDeleted(User acc)
        {
            foreach (var item in usersListView.Items)
            { 
                if (item is ListViewItem listItem && listItem.SubItems[1].Text == acc.Name)
                {
                    usersListView.Items.Remove(listItem);
                    break;
                }
            }
        }

        public void MedicineAdded(Medicine med)
        {
            ListViewItem item = new ListViewItem(med.Name);
            item.SubItems.Add(med.Description);
            medsListView.Items.Add(item);
        }

        public void MedicineDeleted(Medicine med)
        {
            foreach (var item in medsListView.Items)
            {
                if (item is ListViewItem listItem && listItem.SubItems[0].Text == med.Name)
                {
                    medsListView.Items.Remove(listItem);
                    break;
                }
            }
        }

        public void MedicineModified(Medicine med, string oldMedName)
        {
            foreach (var item in medsListView.Items)
            {
                if (item is ListViewItem listItem && listItem.SubItems[0].Text == oldMedName)
                {
                    listItem.SubItems[0].Text = med.Name;
                    listItem.SubItems[1].Text = med.Description;
                    break;
                }
            }
        }

        public void OrderSent(Order order) {}
        public void OrderSolved(Order order) {}
        //--------------------------------------------

        private void deleteAccButton_Click(object sender, EventArgs e)
        {
            if (usersListView.SelectedItems.Count == 0)
                return;
            else
            {
                string selectedName = usersListView.SelectedItems[0].SubItems[1].Text;
                try
                {
                    server.DelAccount(new User() { Name = selectedName });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void createAccButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(userVerifTB.Text) || !userPassTB.Text.Equals(userVerifTB.Text))
                    throw new Exception("Password verification failed!");

                User newAcc = new User()
                {
                    Name = userNameTB.Text,
                    Password = userPassTB.Text,
                    UserType = userTypeCB.Text,
                };

                server.AddAccount(newAcc);
                MessageBox.Show("Account added succesfully!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void medsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (medsListView.SelectedItems.Count != 0)
            {
                selectedMedNameTB.Visible = true;
                selectedMedDescriptionTB.Visible = true;
                modifyMedButton.Visible = true;

                deleteMedButton.Enabled = true;

                selectedMedNameTB.Text = medsListView.SelectedItems[0].SubItems[0].Text;
                selectedMedDescriptionTB.Text = medsListView.SelectedItems[0].SubItems[1].Text;
            }
            else
            {
                selectedMedNameTB.Visible = false;
                selectedMedDescriptionTB.Visible = false;
                modifyMedButton.Visible = false;

                deleteMedButton.Enabled = false;
            }
        }


        

    private void deleteMedButton_Click(object sender, EventArgs e)
    {
       string medName = medsListView.SelectedItems[0].SubItems[0].Text;
       try
       {
           server.DelMedicine(new Medicine() { Name = medName });
       }
       catch (Exception exc)
       { MessageBox.Show(exc.Message); }
    }

    private void modifyMedButton_Click(object sender, EventArgs e)
    {
       string medName = medsListView.SelectedItems[0].SubItems[0].Text;
       string selectedName = selectedMedNameTB.Text;
       string selectedDescription = selectedMedDescriptionTB.Text;
       try
       {
           server.ModifyMedicine(new Medicine() { Name = selectedName,Description = selectedDescription }, medName);

           selectedMedNameTB.Visible = false;
           selectedMedDescriptionTB.Visible = false;
           modifyMedButton.Visible = false;

           deleteMedButton.Enabled = false;
       }
       catch (Exception exc)
       { MessageBox.Show(exc.Message); }
    }

    private void addMedButton_Click(object sender, EventArgs e)
    {
       try {
           string name = addMedNameTB.Text;
           string desc = addMedDescriptionTB.Text;

           server.AddMedicine(new Medicine() { Name = name, Description = desc });

           MessageBox.Show("Medicine added succesfully");
       }catch(Exception exc)
       { MessageBox.Show(exc.Message); }
    }

    }
}
