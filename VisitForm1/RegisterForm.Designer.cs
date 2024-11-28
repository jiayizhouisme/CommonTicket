namespace VisitForm1
{
    partial class RegisterForm
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
            UserName = new Label();
            PassWord = new Label();
            PassWord2 = new Label();
            Login = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // UserName
            // 
            UserName.AutoSize = true;
            UserName.Location = new Point(253, 103);
            UserName.Name = "UserName";
            UserName.Size = new Size(69, 20);
            UserName.TabIndex = 0;
            UserName.Text = "用户名：";
            // 
            // PassWord
            // 
            PassWord.AutoSize = true;
            PassWord.Location = new Point(253, 165);
            PassWord.Name = "PassWord";
            PassWord.Size = new Size(54, 20);
            PassWord.TabIndex = 1;
            PassWord.Text = "密码：";
            // 
            // PassWord2
            // 
            PassWord2.AutoSize = true;
            PassWord2.Location = new Point(253, 230);
            PassWord2.Name = "PassWord2";
            PassWord2.Size = new Size(84, 20);
            PassWord2.TabIndex = 2;
            PassWord2.Text = "确认密码：";
            // 
            // Login
            // 
            Login.Location = new Point(253, 289);
            Login.Name = "Login";
            Login.Size = new Size(94, 29);
            Login.TabIndex = 3;
            Login.Text = "注册";
            Login.UseVisualStyleBackColor = true;
            Login.Click += Login_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(392, 103);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(392, 165);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(392, 230);
            textBox3.Name = "textBox3";
            textBox3.PasswordChar = '*';
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 6;
            // 
            // label1
            // 
            label1.Location = new Point(230, 25);
            label1.Name = "label1";
            label1.Size = new Size(272, 42);
            label1.TabIndex = 7;
            label1.Text = "信息管理系统";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(Login);
            Controls.Add(PassWord2);
            Controls.Add(PassWord);
            Controls.Add(UserName);
            Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Name = "RegisterForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UserName;
        private Label PassWord;
        private Label PassWord2;
        private Button Login;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label1;
    }
}