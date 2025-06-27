

using Model_Persistence.Domain;
using Services;

namespace Hospital_App
{
    public partial class StaffForm : Form, IClientObserver
    {
        private IServices server;

        public StaffForm(IServices proxy)
        {
            this.server = proxy;

            InitializeComponent();
        }

        private void StaffForm_Load(object sender, EventArgs e)
        {
            medDescriptionTB.Visible = false;

            medsListView.Items.Clear();

            foreach (var med in this.server.GetAllMedicines())
            {
                ListViewItem item = new ListViewItem(med.Name);
                item.SubItems.Add(med.Description);
                medsListView.Items.Add(item);

                med1CB.Items.Add(med.Name);
                med2CB.Items.Add(med.Name);
                med3CB.Items.Add(med.Name);
                med4CB.Items.Add(med.Name);
            }

            myOrdersList.Items.Clear();


            foreach (var order in server.GetAllOrders())
            {
                ListViewItem itemT = new ListViewItem(order.Id.ToString());

                DateTime actualOrderTime = new DateTime(1970, 1, 1).AddSeconds(order.OrderTime.Value);
                itemT.SubItems.Add(actualOrderTime.ToString());

                itemT.SubItems.Add(order.Status);

                if (order.SolutionTime != null)
                {
                    //calculate solution time and add it
                    DateTime actualSolutionTime = new DateTime(1970, 1, 1).AddSeconds(order.SolutionTime.Value);
                    itemT.SubItems.Add(actualSolutionTime.ToString());
                }
                else
                    itemT.SubItems.Add("N/A");
                itemT.SubItems.Add(order.Details);//5th item -> [4]
                myOrdersList.Items.Add(itemT);
            }
        }

        //----------------------Updates-------------------
        public void AccountAdded(User acc) { }
        public void AccountDeleted(User acc) { }

        public void MedicineAdded(Medicine med)
        {
            ListViewItem item = new ListViewItem(med.Name);
            item.SubItems.Add(med.Description);
            medsListView.Items.Add(item);

            med1CB.Items.Add(med.Name);
            med2CB.Items.Add(med.Name);
            med3CB.Items.Add(med.Name);
            med4CB.Items.Add(med.Name);
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

            med1CB.Items.Remove(med.Name);
            med2CB.Items.Remove(med.Name);
            med3CB.Items.Remove(med.Name);
            med4CB.Items.Remove(med.Name);
        }

        public void MedicineModified(Medicine med, string oldMedName)
        {
            foreach(var item in medsListView.Items)
            {
                if (item is ListViewItem listItem && listItem.SubItems[0].Text == oldMedName)
                {
                    listItem.SubItems[0].Text = med.Name;
                    listItem.SubItems[1].Text = med.Description;
                    break;
                }
            }

            List<ComboBox> cblist = [med1CB, med2CB, med3CB, med4CB];
            foreach (var cb in cblist)
            {
                foreach (var item in cb.Items)
                {
                    if (item.ToString() == oldMedName)
                    {
                        cb.Items.Remove(item);
                        cb.Items.Add(med.Name);
                        break;
                    }
                }
            }
        }

        public void OrderSent(Order order)
        {
            ListViewItem itemT = new ListViewItem(order.Id.ToString());

            DateTime actualOrderTime = new DateTime(1970, 1, 1).AddSeconds(order.OrderTime.Value);
            itemT.SubItems.Add(actualOrderTime.ToString());

            itemT.SubItems.Add(order.Status);

            if (order.SolutionTime != null)
            {
                DateTime actualSolutionTime = new DateTime(1970, 1, 1).AddSeconds(order.SolutionTime.Value);
                itemT.SubItems.Add(actualSolutionTime.ToString());
            }
            else
                itemT.SubItems.Add("N/A");
            itemT.SubItems.Add(order.Details);
            myOrdersList.Items.Add(itemT);
        }

        public void OrderSolved(Order order)
        {
            foreach (var item in myOrdersList.Items)
            {
                if (item is ListViewItem listItem && listItem.SubItems[0].Text == order.Id.ToString())
                {
                    listItem.SubItems[2].Text = order.Status;
                    DateTime actualSolutionTime = new DateTime(1970, 1, 1).AddSeconds(order.SolutionTime.Value);
                    listItem.SubItems[3].Text = actualSolutionTime.ToString();
                    break;
                }
            }
        }

        //------------------------------------------------

        private void sendOrder_Click(object sender, EventArgs e)
        {
            Order newOrder = new Order();
            newOrder.OrderMedicines = new List<OrderMedicine>();

            Dictionary<ComboBox, NumericUpDown> medsCBs = new Dictionary<ComboBox, NumericUpDown>()
            {
                { med1CB, med1Numeric },
                { med2CB, med2Numeric },
                { med3CB, med3Numeric },
                { med4CB, med4Numeric }
            };

            newOrder.Details += "Details: \n";

            foreach (var pair in medsCBs)
                if (pair.Key.Text != "" && pair.Value.Value != 0)
                {
                    OrderMedicine orderMed = new OrderMedicine();
                    orderMed.Medicine = new Medicine() { Name = pair.Key.Text };
                    orderMed.Quantity = (int)pair.Value.Value;
                    newOrder.OrderMedicines.Add(orderMed);
                    newOrder.Details += "Medicine: " + pair.Key.Text + " Quantity: " + pair.Value.Value.ToString() + " pills.  \n";
                }

            if (newOrder.OrderMedicines.Count == 0)
            {
                MessageBox.Show("You need to add at least 1 medicine ");
                return;
            }

            newOrder.OrderTime = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            newOrder.Status = "Pending";
            try
            {
                server.SendOrder(newOrder);
                MessageBox.Show("Order sent succesfully!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void medsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (medsListView.SelectedItems.Count != 0)
            {
                medDescriptionTB.Visible = true;
                string selectedDesc = medsListView.SelectedItems[0].SubItems[1].Text;
                medDescriptionTB.Text = selectedDesc;
            }
            else
            {
                medDescriptionTB.Visible = false;
            }
        }

        private void addSecondMedButton_Click(object sender, EventArgs e)
        {
            med2CB.Visible = true;
            med2Numeric.Visible = true;

            addThirdMedButton.Visible = true;
            delSecondMedButton.Visible = true;


            addSecondMedButton.Visible = false;
        }

        private void delSecondMedButton_Click(object sender, EventArgs e)
        {
            med2CB.Text = "";
            med2Numeric.Value = 0;

            med2CB.Visible = false;
            med2Numeric.Visible = false;

            addThirdMedButton.Visible = false;
            delSecondMedButton.Visible = false;

            addSecondMedButton.Visible = true;
        }

        private void addThirdMedButton_Click(object sender, EventArgs e)
        {
            med3CB.Visible = true;
            med3Numeric.Visible = true;
            addFourthMedButton.Visible = true;
            delThirdMedButton.Visible = true;

            addThirdMedButton.Visible = false;
            delSecondMedButton.Visible = false;
        }

        private void delThirdMedButton_Click(object sender, EventArgs e)
        {
            med3CB.Text = "";
            med3Numeric.Value = 0;

            med3CB.Visible = false;
            med3Numeric.Visible = false;

            addFourthMedButton.Visible = false;
            delThirdMedButton.Visible = false;

            addThirdMedButton.Visible = true;
            delSecondMedButton.Visible = true;
        }

        private void addFourthMedButton_Click(object sender, EventArgs e)
        {
            med4CB.Visible = true;
            med4Numeric.Visible = true;

            delForthMedButton.Visible = true;

            delThirdMedButton.Visible = false;
            addFourthMedButton.Visible = false;
        }

        private void delForthMedButton_Click(object sender, EventArgs e)
        {
            med4CB.Text = "";
            med4Numeric.Value = 0;

            med4CB.Visible = false;
            med4Numeric.Visible = false;

            delForthMedButton.Visible = false;

            addFourthMedButton.Visible = true;
            delThirdMedButton.Visible = true;
        }

        private void myOrdersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (myOrdersList.SelectedItems.Count != 0)
            {
                orderDetailsTB.Visible = true;
                string selectedDesc = myOrdersList.SelectedItems[0].SubItems[4].Text;
                orderDetailsTB.Text = selectedDesc;
            }
            else
            {
                orderDetailsTB.Visible = false;
            }
        }
    }
}
