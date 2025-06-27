namespace Hospital_App
{
    partial class StaffForm
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            med4Numeric = new NumericUpDown();
            med3Numeric = new NumericUpDown();
            delForthMedButton = new Button();
            delThirdMedButton = new Button();
            addFourthMedButton = new Button();
            addSecondMedButton = new Button();
            delSecondMedButton = new Button();
            addThirdMedButton = new Button();
            med4CB = new ComboBox();
            med3CB = new ComboBox();
            label7 = new Label();
            med2CB = new ComboBox();
            med1CB = new ComboBox();
            medDescriptionTB = new RichTextBox();
            button3 = new Button();
            med2Numeric = new NumericUpDown();
            med1Numeric = new NumericUpDown();
            medsListView = new ListView();
            tabPage2 = new TabPage();
            label1 = new Label();
            myOrdersList = new ListView();
            idCol = new ColumnHeader();
            timeSentCol = new ColumnHeader();
            statusCol = new ColumnHeader();
            timeSolvedCol = new ColumnHeader();
            orderDetailsTB = new RichTextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)med4Numeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)med3Numeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)med2Numeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)med1Numeric).BeginInit();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(-2, -1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(806, 456);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(med4Numeric);
            tabPage1.Controls.Add(med3Numeric);
            tabPage1.Controls.Add(delForthMedButton);
            tabPage1.Controls.Add(delThirdMedButton);
            tabPage1.Controls.Add(addFourthMedButton);
            tabPage1.Controls.Add(addSecondMedButton);
            tabPage1.Controls.Add(delSecondMedButton);
            tabPage1.Controls.Add(addThirdMedButton);
            tabPage1.Controls.Add(med4CB);
            tabPage1.Controls.Add(med3CB);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(med2CB);
            tabPage1.Controls.Add(med1CB);
            tabPage1.Controls.Add(medDescriptionTB);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(med2Numeric);
            tabPage1.Controls.Add(med1Numeric);
            tabPage1.Controls.Add(medsListView);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(798, 423);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Inregistrare";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // med4Numeric
            // 
            med4Numeric.Location = new Point(216, 220);
            med4Numeric.Name = "med4Numeric";
            med4Numeric.Size = new Size(47, 27);
            med4Numeric.TabIndex = 21;
            med4Numeric.Visible = false;
            // 
            // med3Numeric
            // 
            med3Numeric.Location = new Point(216, 167);
            med3Numeric.Name = "med3Numeric";
            med3Numeric.Size = new Size(47, 27);
            med3Numeric.TabIndex = 20;
            med3Numeric.Visible = false;
            // 
            // delForthMedButton
            // 
            delForthMedButton.Location = new Point(138, 281);
            delForthMedButton.Name = "delForthMedButton";
            delForthMedButton.Size = new Size(25, 30);
            delForthMedButton.TabIndex = 19;
            delForthMedButton.Text = "-";
            delForthMedButton.UseVisualStyleBackColor = true;
            delForthMedButton.Visible = false;
            delForthMedButton.Click += delForthMedButton_Click;
            // 
            // delThirdMedButton
            // 
            delThirdMedButton.Location = new Point(138, 228);
            delThirdMedButton.Name = "delThirdMedButton";
            delThirdMedButton.Size = new Size(25, 30);
            delThirdMedButton.TabIndex = 18;
            delThirdMedButton.Text = "-";
            delThirdMedButton.UseVisualStyleBackColor = true;
            delThirdMedButton.Visible = false;
            delThirdMedButton.Click += delThirdMedButton_Click;
            // 
            // addFourthMedButton
            // 
            addFourthMedButton.Location = new Point(38, 228);
            addFourthMedButton.Name = "addFourthMedButton";
            addFourthMedButton.Size = new Size(25, 30);
            addFourthMedButton.TabIndex = 17;
            addFourthMedButton.Text = "+";
            addFourthMedButton.UseVisualStyleBackColor = true;
            addFourthMedButton.Visible = false;
            addFourthMedButton.Click += addFourthMedButton_Click;
            // 
            // addSecondMedButton
            // 
            addSecondMedButton.Location = new Point(37, 117);
            addSecondMedButton.Name = "addSecondMedButton";
            addSecondMedButton.Size = new Size(25, 30);
            addSecondMedButton.TabIndex = 16;
            addSecondMedButton.Text = "+";
            addSecondMedButton.UseVisualStyleBackColor = true;
            addSecondMedButton.Click += addSecondMedButton_Click;
            // 
            // delSecondMedButton
            // 
            delSecondMedButton.Location = new Point(138, 172);
            delSecondMedButton.Name = "delSecondMedButton";
            delSecondMedButton.Size = new Size(25, 30);
            delSecondMedButton.TabIndex = 6;
            delSecondMedButton.Text = "-";
            delSecondMedButton.UseVisualStyleBackColor = true;
            delSecondMedButton.Visible = false;
            delSecondMedButton.Click += delSecondMedButton_Click;
            // 
            // addThirdMedButton
            // 
            addThirdMedButton.Location = new Point(38, 172);
            addThirdMedButton.Name = "addThirdMedButton";
            addThirdMedButton.Size = new Size(25, 30);
            addThirdMedButton.TabIndex = 5;
            addThirdMedButton.Text = "+";
            addThirdMedButton.UseVisualStyleBackColor = true;
            addThirdMedButton.Visible = false;
            addThirdMedButton.Click += addThirdMedButton_Click;
            // 
            // med4CB
            // 
            med4CB.DropDownStyle = ComboBoxStyle.DropDownList;
            med4CB.FormattingEnabled = true;
            med4CB.Location = new Point(29, 219);
            med4CB.Name = "med4CB";
            med4CB.Size = new Size(151, 28);
            med4CB.TabIndex = 15;
            med4CB.Visible = false;
            // 
            // med3CB
            // 
            med3CB.DropDownStyle = ComboBoxStyle.DropDownList;
            med3CB.FormattingEnabled = true;
            med3CB.Location = new Point(29, 166);
            med3CB.Name = "med3CB";
            med3CB.Size = new Size(151, 28);
            med3CB.TabIndex = 14;
            med3CB.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(24, 18);
            label7.Name = "label7";
            label7.Size = new Size(156, 20);
            label7.TabIndex = 13;
            label7.Text = "Adauga medicamente";
            // 
            // med2CB
            // 
            med2CB.DropDownStyle = ComboBoxStyle.DropDownList;
            med2CB.FormattingEnabled = true;
            med2CB.Location = new Point(29, 112);
            med2CB.Name = "med2CB";
            med2CB.Size = new Size(151, 28);
            med2CB.TabIndex = 12;
            med2CB.Visible = false;
            // 
            // med1CB
            // 
            med1CB.DropDownStyle = ComboBoxStyle.DropDownList;
            med1CB.FormattingEnabled = true;
            med1CB.Location = new Point(29, 59);
            med1CB.Name = "med1CB";
            med1CB.Size = new Size(151, 28);
            med1CB.TabIndex = 11;
            // 
            // medDescriptionTB
            // 
            medDescriptionTB.Location = new Point(304, 0);
            medDescriptionTB.Name = "medDescriptionTB";
            medDescriptionTB.ReadOnly = true;
            medDescriptionTB.Size = new Size(223, 191);
            medDescriptionTB.TabIndex = 10;
            medDescriptionTB.Text = "descriere med selectat";
            // 
            // button3
            // 
            button3.Location = new Point(83, 340);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 7;
            button3.Text = "Trimite Comanda";
            button3.UseVisualStyleBackColor = true;
            button3.Click += sendOrder_Click;
            // 
            // med2Numeric
            // 
            med2Numeric.Location = new Point(216, 113);
            med2Numeric.Name = "med2Numeric";
            med2Numeric.Size = new Size(47, 27);
            med2Numeric.TabIndex = 4;
            med2Numeric.Visible = false;
            // 
            // med1Numeric
            // 
            med1Numeric.Location = new Point(216, 60);
            med1Numeric.Name = "med1Numeric";
            med1Numeric.Size = new Size(47, 27);
            med1Numeric.TabIndex = 2;
            // 
            // medsListView
            // 
            medsListView.Location = new Point(527, 0);
            medsListView.Name = "medsListView";
            medsListView.Size = new Size(271, 423);
            medsListView.TabIndex = 0;
            medsListView.UseCompatibleStateImageBehavior = false;
            medsListView.View = View.Tile;
            medsListView.SelectedIndexChanged += medsListView_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(orderDetailsTB);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(myOrdersList);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(798, 423);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Verificare";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(144, 21);
            label1.Name = "label1";
            label1.Size = new Size(148, 20);
            label1.TabIndex = 1;
            label1.Text = "Lista comenzi trimise";
            // 
            // myOrdersList
            // 
            myOrdersList.Columns.AddRange(new ColumnHeader[] { idCol, timeSentCol, statusCol, timeSolvedCol });
            myOrdersList.Location = new Point(0, 59);
            myOrdersList.Name = "myOrdersList";
            myOrdersList.Size = new Size(465, 364);
            myOrdersList.TabIndex = 0;
            myOrdersList.UseCompatibleStateImageBehavior = false;
            myOrdersList.View = View.Details;
            myOrdersList.SelectedIndexChanged += myOrdersList_SelectedIndexChanged;
            // 
            // idCol
            // 
            idCol.Text = "Id";
            idCol.Width = 40;
            // 
            // timeSentCol
            // 
            timeSentCol.Text = "Sent At";
            timeSentCol.Width = 165;
            // 
            // statusCol
            // 
            statusCol.Text = "Status";
            statusCol.Width = 90;
            // 
            // timeSolvedCol
            // 
            timeSolvedCol.Text = "Solved At";
            timeSolvedCol.Width = 165;
            // 
            // orderDetailsTB
            // 
            orderDetailsTB.Location = new Point(471, 59);
            orderDetailsTB.Name = "orderDetailsTB";
            orderDetailsTB.ReadOnly = true;
            orderDetailsTB.Size = new Size(321, 274);
            orderDetailsTB.TabIndex = 3;
            orderDetailsTB.Text = "";
            // 
            // StaffForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "StaffForm";
            Text = "Medical Staff";
            Load += StaffForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)med4Numeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)med3Numeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)med2Numeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)med1Numeric).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button3;
        private Button delSecondMedButton;
        private Button addThirdMedButton;
        private NumericUpDown med2Numeric;
        private NumericUpDown med1Numeric;
        private ListView medsListView;
        private Label label1;
        private ListView myOrdersList;
        private RichTextBox medDescriptionTB;
        private Label label7;
        private ComboBox med2CB;
        private ComboBox med1CB;
        private NumericUpDown med4Numeric;
        private NumericUpDown med3Numeric;
        private Button delForthMedButton;
        private Button delThirdMedButton;
        private Button addFourthMedButton;
        private Button addSecondMedButton;
        private ComboBox med4CB;
        private ComboBox med3CB;
        private ColumnHeader idCol;
        private ColumnHeader timeSentCol;
        private ColumnHeader statusCol;
        private ColumnHeader timeSolvedCol;
        private RichTextBox orderDetailsTB;
    }
}