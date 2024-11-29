namespace VisitForm1
{
    partial class UpdatePwdForm
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
            NewPwd = new Label();
            NewPwd2 = new Label();
            Submit = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            UserId = new Label();
            OldPwd = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            SuspendLayout();
            // 
            // NewPwd
            // 
            NewPwd.AutoSize = true;
            NewPwd.Location = new Point(172, 211);
            NewPwd.Name = "NewPwd";
            NewPwd.Size = new Size(114, 20);
            NewPwd.TabIndex = 0;
            NewPwd.Text = "请输入新密码：";
            // 
            // NewPwd2
            // 
            NewPwd2.AutoSize = true;
            NewPwd2.Location = new Point(172, 277);
            NewPwd2.Name = "NewPwd2";
            NewPwd2.Size = new Size(84, 20);
            NewPwd2.TabIndex = 1;
            NewPwd2.Text = "再次输入：";
            // 
            // Submit
            // 
            Submit.Location = new Point(172, 338);
            Submit.Name = "Submit";
            Submit.Size = new Size(94, 29);
            Submit.TabIndex = 2;
            Submit.Text = "确定";
            Submit.UseVisualStyleBackColor = true;
            Submit.Click += Submit_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(319, 204);
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '*';
            textBox1.Size = new Size(151, 27);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(319, 270);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(151, 27);
            textBox2.TabIndex = 4;
            // 
            // label1
            // 
            label1.Location = new Point(205, 20);
            label1.Name = "label1";
            label1.Size = new Size(218, 42);
            label1.TabIndex = 5;
            label1.Text = "修改密码";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UserId
            // 
            UserId.AutoSize = true;
            UserId.Location = new Point(172, 92);
            UserId.Name = "UserId";
            UserId.Size = new Size(103, 20);
            UserId.TabIndex = 6;
            UserId.Text = "请输入用户名:";
            // 
            // OldPwd
            // 
            OldPwd.AutoSize = true;
            OldPwd.Location = new Point(172, 151);
            OldPwd.Name = "OldPwd";
            OldPwd.Size = new Size(99, 20);
            OldPwd.TabIndex = 7;
            OldPwd.Text = "请输入密码：";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(319, 85);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(151, 27);
            textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(319, 144);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(151, 27);
            textBox4.TabIndex = 9;
            // 
            // UpdatePwdForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(OldPwd);
            Controls.Add(UserId);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(Submit);
            Controls.Add(NewPwd2);
            Controls.Add(NewPwd);
            Name = "UpdatePwdForm";
            Text = "UpdatePwdForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NewPwd;
        private Label NewPwd2;
        private Button Submit;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label UserId;
        private Label OldPwd;
        private TextBox textBox3;
        private TextBox textBox4;
    }
}