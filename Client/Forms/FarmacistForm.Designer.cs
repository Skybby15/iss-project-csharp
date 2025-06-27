namespace Client
{
    partial class FarmacistForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pendingOrdersList = new ListView();
            idCol = new ColumnHeader();
            sentTime = new ColumnHeader();
            label1 = new Label();
            solveButton = new Button();
            refuzeButton = new Button();
            orderDescTB = new RichTextBox();
            SuspendLayout();
            // 
            // pendingOrdersList
            // 
            pendingOrdersList.Columns.AddRange(new ColumnHeader[] { idCol, sentTime });
            pendingOrdersList.Location = new Point(115, 80);
            pendingOrdersList.Name = "pendingOrdersList";
            pendingOrdersList.Size = new Size(220, 369);
            pendingOrdersList.TabIndex = 0;
            pendingOrdersList.UseCompatibleStateImageBehavior = false;
            pendingOrdersList.View = View.Details;
            pendingOrdersList.SelectedIndexChanged += pendingOrdersList_SelectedIndexChanged;
            // 
            // idCol
            // 
            idCol.Text = "Id";
            idCol.Width = 50;
            // 
            // sentTime
            // 
            sentTime.Text = "Sent At";
            sentTime.TextAlign = HorizontalAlignment.Center;
            sentTime.Width = 165;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(153, 42);
            label1.Name = "label1";
            label1.Size = new Size(149, 20);
            label1.TabIndex = 2;
            label1.Text = "Comenzi in asteptare";
            // 
            // solveButton
            // 
            solveButton.Location = new Point(460, 389);
            solveButton.Name = "solveButton";
            solveButton.Size = new Size(94, 29);
            solveButton.TabIndex = 4;
            solveButton.Text = "Rezolva";
            solveButton.UseVisualStyleBackColor = true;
            solveButton.Click += solveButton_Click;
            // 
            // refuzeButton
            // 
            refuzeButton.Location = new Point(647, 389);
            refuzeButton.Name = "refuzeButton";
            refuzeButton.Size = new Size(94, 29);
            refuzeButton.TabIndex = 5;
            refuzeButton.Text = "Refuza";
            refuzeButton.UseVisualStyleBackColor = true;
            refuzeButton.Click += refuzeButton_Click;
            // 
            // orderDescTB
            // 
            orderDescTB.Location = new Point(426, 100);
            orderDescTB.Name = "orderDescTB";
            orderDescTB.Size = new Size(351, 260);
            orderDescTB.TabIndex = 6;
            orderDescTB.Text = "";
            // 
            // FarmacistForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(orderDescTB);
            Controls.Add(refuzeButton);
            Controls.Add(solveButton);
            Controls.Add(label1);
            Controls.Add(pendingOrdersList);
            Name = "FarmacistForm";
            Text = "Pharmacist";
            Load += FarmacistForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView pendingOrdersList;
        private Label label1;
        private Button solveButton;
        private Button refuzeButton;
        private RichTextBox orderDescTB;
        private ColumnHeader idCol;
        private ColumnHeader sentTime;
    }
}