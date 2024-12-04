namespace VisitForm1
{
    partial class LogonForm
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
            UserName = new Label();
            PassWord = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            Register = new Button();
            Logon = new Button();
            Updatepassword = new Button();
            label1 = new Label();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // UserName
            // 
            UserName.AutoSize = true;
            UserName.Location = new Point(189, 107);
            UserName.Name = "UserName";
            UserName.RightToLeft = RightToLeft.No;
            UserName.Size = new Size(69, 20);
            UserName.TabIndex = 0;
            UserName.Text = "用户名：";
            // 
            // PassWord
            // 
            PassWord.AutoSize = true;
            PassWord.Location = new Point(189, 192);
            PassWord.Name = "PassWord";
            PassWord.Size = new Size(54, 20);
            PassWord.TabIndex = 1;
            PassWord.Text = "密码：";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(340, 104);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(340, 185);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 3;
            // 
            // Register
            // 
            Register.Location = new Point(189, 305);
            Register.Name = "Register";
            Register.Size = new Size(94, 29);
            Register.TabIndex = 4;
            Register.Text = "注册";
            Register.UseVisualStyleBackColor = true;
            Register.Click += Register_Click;
            // 
            // Logon
            // 
            Logon.Location = new Point(340, 305);
            Logon.Name = "Logon";
            Logon.Size = new Size(94, 29);
            Logon.TabIndex = 5;
            Logon.Text = "登录";
            Logon.UseVisualStyleBackColor = true;
            Logon.Click += Logon_Click;
            // 
            // Updatepassword
            // 
            Updatepassword.Location = new Point(496, 305);
            Updatepassword.Name = "Updatepassword";
            Updatepassword.Size = new Size(94, 29);
            Updatepassword.TabIndex = 9;
            Updatepassword.Text = "修改密码";
            Updatepassword.UseVisualStyleBackColor = true;
            Updatepassword.Click += Updatepassword_Click;
            // 
            // label1
            // 
            label1.Location = new Point(221, 20);
            label1.Name = "label1";
            label1.Size = new Size(213, 36);
            label1.TabIndex = 10;
            label1.Text = "信息管理系统";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(189, 248);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(91, 24);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "记住密码";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // LogonForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(checkBox1);
            Controls.Add(label1);
            Controls.Add(Updatepassword);
            Controls.Add(Logon);
            Controls.Add(Register);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(PassWord);
            Controls.Add(UserName);
            Name = "LogonForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UserName;
        private Label PassWord;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button Register;
        private Button Logon;
        private Button Updatepassword;
        private Label label1;
        private CheckBox checkBox1;
    }
}
