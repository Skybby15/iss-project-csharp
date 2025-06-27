namespace Hospital_App
{
    partial class AdminForm
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
            selectedMedNameTB = new TextBox();
            modifyMedButton = new Button();
            selectedMedDescriptionTB = new TextBox();
            label1 = new Label();
            deleteMedButton = new Button();
            addMedButton = new Button();
            addMedDescriptionTB = new TextBox();
            addMedNameTB = new TextBox();
            medsListView = new ListView();
            tabPage2 = new TabPage();
            userTypeCB = new ComboBox();
            label2 = new Label();
            userVerifTB = new TextBox();
            userPassTB = new TextBox();
            userNameTB = new TextBox();
            createAccButton = new Button();
            button3 = new Button();
            usersListView = new ListView();
            userTypeCol = new ColumnHeader();
            userNameCol = new ColumnHeader();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(1, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(798, 451);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(selectedMedNameTB);
            tabPage1.Controls.Add(modifyMedButton);
            tabPage1.Controls.Add(selectedMedDescriptionTB);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(deleteMedButton);
            tabPage1.Controls.Add(addMedButton);
            tabPage1.Controls.Add(addMedDescriptionTB);
            tabPage1.Controls.Add(addMedNameTB);
            tabPage1.Controls.Add(medsListView);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(790, 418);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Meds";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // selectedMedNameTB
            // 
            selectedMedNameTB.Location = new Point(244, 52);
            selectedMedNameTB.Name = "selectedMedNameTB";
            selectedMedNameTB.Size = new Size(188, 27);
            selectedMedNameTB.TabIndex = 8;
            // 
            // modifyMedButton
            // 
            modifyMedButton.Location = new Point(382, 271);
            modifyMedButton.Name = "modifyMedButton";
            modifyMedButton.Size = new Size(78, 30);
            modifyMedButton.TabIndex = 7;
            modifyMedButton.Text = "Modifica";
            modifyMedButton.UseVisualStyleBackColor = true;
            modifyMedButton.Click += modifyMedButton_Click;
            // 
            // selectedMedDescriptionTB
            // 
            selectedMedDescriptionTB.Location = new Point(244, 91);
            selectedMedDescriptionTB.Multiline = true;
            selectedMedDescriptionTB.Name = "selectedMedDescriptionTB";
            selectedMedDescriptionTB.Size = new Size(216, 174);
            selectedMedDescriptionTB.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(84, 20);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 5;
            label1.Text = "Medicamente";
            // 
            // deleteMedButton
            // 
            deleteMedButton.Location = new Point(151, 365);
            deleteMedButton.Name = "deleteMedButton";
            deleteMedButton.Size = new Size(94, 29);
            deleteMedButton.TabIndex = 4;
            deleteMedButton.Text = "Sterge";
            deleteMedButton.UseVisualStyleBackColor = true;
            deleteMedButton.Click += deleteMedButton_Click;
            // 
            // addMedButton
            // 
            addMedButton.Location = new Point(609, 365);
            addMedButton.Name = "addMedButton";
            addMedButton.Size = new Size(94, 29);
            addMedButton.TabIndex = 3;
            addMedButton.Text = "Adauga";
            addMedButton.UseVisualStyleBackColor = true;
            addMedButton.Click += addMedButton_Click;
            // 
            // addMedDescriptionTB
            // 
            addMedDescriptionTB.Location = new Point(506, 114);
            addMedDescriptionTB.Multiline = true;
            addMedDescriptionTB.Name = "addMedDescriptionTB";
            addMedDescriptionTB.PlaceholderText = "descriere";
            addMedDescriptionTB.Size = new Size(278, 222);
            addMedDescriptionTB.TabIndex = 2;
            // 
            // addMedNameTB
            // 
            addMedNameTB.Location = new Point(510, 61);
            addMedNameTB.Name = "addMedNameTB";
            addMedNameTB.PlaceholderText = "medicament";
            addMedNameTB.Size = new Size(179, 27);
            addMedNameTB.TabIndex = 1;
            // 
            // medsListView
            // 
            medsListView.Location = new Point(26, 52);
            medsListView.MultiSelect = false;
            medsListView.Name = "medsListView";
            medsListView.Size = new Size(219, 298);
            medsListView.TabIndex = 0;
            medsListView.UseCompatibleStateImageBehavior = false;
            medsListView.View = View.Tile;
            medsListView.SelectedIndexChanged += medsListView_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(userTypeCB);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(userVerifTB);
            tabPage2.Controls.Add(userPassTB);
            tabPage2.Controls.Add(userNameTB);
            tabPage2.Controls.Add(createAccButton);
            tabPage2.Controls.Add(button3);
            tabPage2.Controls.Add(usersListView);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(790, 418);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Conturi";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // userTypeCB
            // 
            userTypeCB.AutoCompleteMode = AutoCompleteMode.Suggest;
            userTypeCB.FormattingEnabled = true;
            userTypeCB.Location = new Point(428, 204);
            userTypeCB.Name = "userTypeCB";
            userTypeCB.Size = new Size(151, 28);
            userTypeCB.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(128, 9);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 7;
            label2.Text = "Lista conturi";
            // 
            // userVerifTB
            // 
            userVerifTB.Location = new Point(405, 148);
            userVerifTB.Name = "userVerifTB";
            userVerifTB.PasswordChar = '*';
            userVerifTB.PlaceholderText = "verificare parola";
            userVerifTB.Size = new Size(189, 27);
            userVerifTB.TabIndex = 6;
            // 
            // userPassTB
            // 
            userPassTB.Location = new Point(405, 102);
            userPassTB.Name = "userPassTB";
            userPassTB.PasswordChar = '*';
            userPassTB.PlaceholderText = "parola";
            userPassTB.Size = new Size(189, 27);
            userPassTB.TabIndex = 5;
            // 
            // userNameTB
            // 
            userNameTB.Location = new Point(405, 60);
            userNameTB.Name = "userNameTB";
            userNameTB.PlaceholderText = "nume";
            userNameTB.Size = new Size(189, 27);
            userNameTB.TabIndex = 3;
            // 
            // createAccButton
            // 
            createAccButton.Location = new Point(425, 256);
            createAccButton.Name = "createAccButton";
            createAccButton.Size = new Size(155, 29);
            createAccButton.TabIndex = 2;
            createAccButton.Text = "Create Account";
            createAccButton.UseVisualStyleBackColor = true;
            createAccButton.Click += createAccButton_Click;
            // 
            // button3
            // 
            button3.Location = new Point(202, 380);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 1;
            button3.Text = "Del Acc";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // usersListView
            // 
            usersListView.Columns.AddRange(new ColumnHeader[] { userTypeCol, userNameCol });
            usersListView.Location = new Point(20, 38);
            usersListView.MultiSelect = false;
            usersListView.Name = "usersListView";
            usersListView.Size = new Size(290, 331);
            usersListView.TabIndex = 0;
            usersListView.UseCompatibleStateImageBehavior = false;
            usersListView.View = View.Details;
            // 
            // userTypeCol
            // 
            userTypeCol.Text = "User Type";
            userTypeCol.Width = 100;
            // 
            // userNameCol
            // 
            userNameCol.Text = "Name";
            userNameCol.TextAlign = HorizontalAlignment.Center;
            userNameCol.Width = 185;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "AdminForm";
            Text = "Admin";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button addMedButton;
        private TextBox addMedDescriptionTB;
        private TextBox addMedNameTB;
        private ListView medsListView;
        private TabPage tabPage2;
        private Label label1;
        private Button deleteMedButton;
        private Label label2;
        private TextBox userVerifTB;
        private TextBox userPassTB;
        private TextBox userNameTB;
        private Button createAccButton;
        private Button button3;
        private ListView usersListView;
        private ComboBox userTypeCB;
        private ColumnHeader userTypeCol;
        private ColumnHeader userNameCol;
        private Button modifyMedButton;
        private TextBox selectedMedDescriptionTB;
        private TextBox selectedMedNameTB;
    }
}