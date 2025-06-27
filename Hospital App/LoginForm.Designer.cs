namespace Hospital_App
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            passwordTextBox = new TextBox();
            nameTextBox = new TextBox();
            panel2 = new Panel();
            panel1 = new Panel();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ButtonFace;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Comic Sans MS", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.LimeGreen;
            label2.Location = new Point(130, 43);
            label2.Name = "label2";
            label2.Size = new Size(161, 60);
            label2.TabIndex = 4;
            label2.Text = "Log In";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = SystemColors.ButtonFace;
            passwordTextBox.BorderStyle = BorderStyle.None;
            passwordTextBox.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passwordTextBox.ForeColor = Color.LimeGreen;
            passwordTextBox.Location = new Point(115, 286);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.PlaceholderText = "parola";
            passwordTextBox.Size = new Size(266, 21);
            passwordTextBox.TabIndex = 13;
            // 
            // nameTextBox
            // 
            nameTextBox.BackColor = SystemColors.ButtonFace;
            nameTextBox.BorderStyle = BorderStyle.None;
            nameTextBox.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameTextBox.ForeColor = Color.LimeGreen;
            nameTextBox.Location = new Point(115, 172);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.PlaceholderText = "nume";
            nameTextBox.Size = new Size(266, 21);
            nameTextBox.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(47, 313);
            panel2.Name = "panel2";
            panel2.Size = new Size(334, 2);
            panel2.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(47, 199);
            panel1.Name = "panel1";
            panel1.Size = new Size(334, 2);
            panel1.TabIndex = 10;
            // 
            // button1
            // 
            button1.BackColor = Color.LimeGreen;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Bahnschrift", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(91, 377);
            button1.Name = "button1";
            button1.Size = new Size(259, 37);
            button1.TabIndex = 14;
            button1.Text = "LOG IN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += login_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_user_48;
            pictureBox1.Location = new Point(56, 143);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(53, 54);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.icons8_password_100;
            pictureBox2.Location = new Point(56, 257);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(53, 54);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 479);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(passwordTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "LoginForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox passwordTextBox;
        private TextBox nameTextBox;
        private Panel panel2;
        private Panel panel1;
        private Button button1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}
