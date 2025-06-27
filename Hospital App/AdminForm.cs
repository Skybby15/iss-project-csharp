using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hospital_App.Domain;
using Hospital_App.ServiceNameSpace;
using Hospital_App.Utils;

namespace Hospital_App
{
    public partial class AdminForm : Form, Subscriber
    {
        private readonly Service service;

        public AdminForm(Service service)
        {
            this.service = service;
            service.AddSubscriber(this);
            InitializeComponent();


            //accounts
            usersListView.Items.Clear();

            foreach (var user in this.service.GetAllAccounts())
            {
                ListViewItem item = new ListViewItem(user.UserType);
                item.SubItems.Add(user.Name);
                usersListView.Items.Add(item);
            }

            userTypeCB.Items.AddRange(["Pharmacist", "MedicalStaff", "Admin"]);

            //meds

            medsListView.Items.Clear();

            foreach (var med in this.service.GetAllMedicine())
            {
                ListViewItem item = new ListViewItem(med.Name);
                item.SubItems.Add(med.Description);
                medsListView.Items.Add(item);
            }

            selectedMedNameTB.Visible = false;
            selectedMedDescriptionTB.Visible = false;
            modifyMedButton.Visible = false;



        }

        public void GetNotified(UpdateEvent upEvent)
        {
            if (upEvent == UpdateEvent.AccountDeleted ||
                upEvent == UpdateEvent.AccountAdded ||
                upEvent == UpdateEvent.AccountUpdated)
            {
                usersListView.Items.Clear();

                foreach (var user in this.service.GetAllAccounts())
                {
                    ListViewItem item = new ListViewItem(user.UserType);
                    item.SubItems.Add(user.Name);
                    usersListView.Items.Add(item);
                }
            }
            else if (upEvent == UpdateEvent.MedicineDeleted ||
                upEvent == UpdateEvent.MedicineUpdated ||
                upEvent == UpdateEvent.MedicineAdded)
            {
                medsListView.Items.Clear();

                foreach (var med in this.service.GetAllMedicine())
                {
                    ListViewItem item = new ListViewItem(med.Name);
                    item.SubItems.Add(med.Description);
                    medsListView.Items.Add(item);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (usersListView.SelectedItems.Count == 0)
                return;
            else
            {
                string selectedName = usersListView.SelectedItems[0].SubItems[1].Text;
                try
                {
                    service.DelAccount(new User() { Name = selectedName });
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

                service.AddAccount(newAcc);
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
                service.DeleteMedicine(new Medicine() { Name = medName });
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
                service.ModifyMedicine(new Medicine() { Name = selectedName,Description = selectedDescription }, medName);

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

                service.AddMedicine(new Medicine() { Name = name, Description = desc });

                MessageBox.Show("Medicine added succesfully");
            }catch(Exception exc)
            { MessageBox.Show(exc.Message); }
        }
    }
}
