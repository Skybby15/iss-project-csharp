using Model_Persistence.Domain;
using Services;

namespace Client
{
    public partial class FarmacistForm : Form, IClientObserver
    {
        private IServices server;

        public FarmacistForm(IServices proxy)
        {
            this.server = proxy;
            InitializeComponent();
        }
        //---------------------Updates---------------------
        public void AccountAdded(User acc) { }
        public void AccountDeleted(User acc) { }

        public void MedicineAdded(Medicine med) {}

        public void MedicineDeleted(Medicine med) {}

        public void MedicineModified(Medicine med, string oldMedName) {}

        public void OrderSent(Order order)
        {
            if(order.Status == "Pending")
            {
                ListViewItem item = new ListViewItem(order.Id.ToString());
                DateTime actualOrderTime = new DateTime(1970, 1, 1).AddSeconds(order.OrderTime.Value);
                item.SubItems.Add(actualOrderTime.ToString());
                item.SubItems.Add(order.Details);
                pendingOrdersList.Items.Add(item);
            }
        }

        public void OrderSolved(Order order)
        {
            foreach (var item in pendingOrdersList.Items)
            {
                if (item is ListViewItem listItem && listItem.SubItems[0].Text == order.Id.ToString())
                {
                    pendingOrdersList.Items.Remove(listItem);
                    break;
                }
            }
        }

        private void FarmacistForm_Load(object sender, EventArgs e)
        {
            orderDescTB.Visible = false;
            solveButton.Visible = false;
            refuzeButton.Visible = false;

            pendingOrdersList.Items.Clear();

            foreach (var order in server.GetAllPendingOrders())
            {
                ListViewItem item = new ListViewItem(order.Id.ToString());
                DateTime actualOrderTime = new DateTime(1970, 1, 1).AddSeconds(order.OrderTime.Value);
                item.SubItems.Add(actualOrderTime.ToString());
                item.SubItems.Add(order.Details); //[2]
                pendingOrdersList.Items.Add(item);
            }

        }

        private void pendingOrdersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pendingOrdersList.SelectedItems.Count != 0)
            {
                orderDescTB.Visible = true;
                string selectedDesc = pendingOrdersList.SelectedItems[0].SubItems[2].Text;
                orderDescTB.Text = selectedDesc;

                solveButton.Visible = true;
                refuzeButton.Visible = true;
            }
            else
            {
                orderDescTB.Visible = false;
                solveButton.Visible = false;
                refuzeButton.Visible = false;
            }
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            var selectedOrder = pendingOrdersList.SelectedItems[0];
            int orderId = int.Parse(selectedOrder.SubItems[0].Text);
            try
            {
                server.SolveOrder(orderId, "Solved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void refuzeButton_Click(object sender, EventArgs e)
        {
            var selectedOrder = pendingOrdersList.SelectedItems[0];
            int orderId = int.Parse(selectedOrder.SubItems[0].Text);
            try
            {
                server.SolveOrder(orderId, "Refused");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //-------------------------------------------------
    }
}
