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
            label2 = new Label();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            listView2 = new ListView();
            tabPage2 = new TabPage();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            listView1 = new ListView();
            richTextBox1 = new RichTextBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label7 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
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
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(comboBox2);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(richTextBox1);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(numericUpDown2);
            tabPage1.Controls.Add(numericUpDown1);
            tabPage1.Controls.Add(listView2);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(798, 423);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Inregistrare";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(552, 17);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 8;
            label2.Text = "med1";
            // 
            // button3
            // 
            button3.Location = new Point(83, 340);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 7;
            button3.Text = "Trimite Comanda";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(138, 172);
            button2.Name = "button2";
            button2.Size = new Size(25, 30);
            button2.TabIndex = 6;
            button2.Text = "-";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(38, 172);
            button1.Name = "button1";
            button1.Size = new Size(25, 30);
            button1.TabIndex = 5;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(216, 117);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(47, 27);
            numericUpDown2.TabIndex = 4;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(216, 59);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(47, 27);
            numericUpDown1.TabIndex = 2;
            // 
            // listView2
            // 
            listView2.Location = new Point(527, 0);
            listView2.Name = "listView2";
            listView2.Size = new Size(271, 423);
            listView2.TabIndex = 0;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(listView1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(798, 423);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Verificare";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Firebrick;
            label6.Location = new Point(324, 199);
            label6.Name = "label6";
            label6.Size = new Size(79, 20);
            label6.TabIndex = 4;
            label6.Text = "comanda3";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(324, 145);
            label5.Name = "label5";
            label5.Size = new Size(79, 20);
            label5.TabIndex = 3;
            label5.Text = "comanda2";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.LawnGreen;
            label4.Location = new Point(324, 95);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
            label4.TabIndex = 2;
            label4.Text = "comanda1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(294, 20);
            label1.Name = "label1";
            label1.Size = new Size(148, 20);
            label1.TabIndex = 1;
            label1.Text = "Lista comenzi trimise";
            // 
            // listView1
            // 
            listView1.Location = new Point(220, 59);
            listView1.Name = "listView1";
            listView1.Size = new Size(292, 364);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(304, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(223, 191);
            richTextBox1.TabIndex = 10;
            richTextBox1.Text = "descriere med selectat";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(29, 59);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 11;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(29, 116);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 12;
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
            // StaffForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "StaffForm";
            Text = "Medical Staff";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button3;
        private Button button2;
        private Button button1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private ListView listView2;
        private Label label1;
        private ListView listView1;
        private Label label2;
        private Label label6;
        private Label label5;
        private Label label4;
        private RichTextBox richTextBox1;
        private Label label7;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
    }
}