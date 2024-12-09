namespace VisitForm1
{
    partial class AddUserInfoForm
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
            label1 = new Label();
            TypeCard = new Label();
            Name = new Label();
            IdCard = new Label();
            PhoneNumber = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            Submitt = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(209, 9);
            label1.Name = "label1";
            label1.Size = new Size(291, 64);
            label1.TabIndex = 0;
            label1.Text = "添加游客信息";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TypeCard
            // 
            TypeCard.AutoSize = true;
            TypeCard.Location = new Point(235, 85);
            TypeCard.Name = "TypeCard";
            TypeCard.Size = new Size(69, 20);
            TypeCard.TabIndex = 1;
            TypeCard.Text = "证件类型";
            // 
            // Name
            // 
            Name.AutoSize = true;
            Name.Location = new Point(235, 138);
            Name.Name = "Name";
            Name.Size = new Size(39, 20);
            Name.TabIndex = 2;
            Name.Text = "姓名";
            // 
            // IdCard
            // 
            IdCard.AutoSize = true;
            IdCard.Location = new Point(235, 194);
            IdCard.Name = "IdCard";
            IdCard.Size = new Size(54, 20);
            IdCard.TabIndex = 3;
            IdCard.Text = "证件号";
            // 
            // PhoneNumber
            // 
            PhoneNumber.AutoSize = true;
            PhoneNumber.Location = new Point(235, 246);
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.Size = new Size(54, 20);
            PhoneNumber.TabIndex = 4;
            PhoneNumber.Text = "手机号";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(355, 85);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(231, 27);
            textBox1.TabIndex = 5;
            textBox1.Text = "身份证";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(355, 138);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(231, 27);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(355, 191);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(231, 27);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(355, 239);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(231, 27);
            textBox4.TabIndex = 8;
            // 
            // Submitt
            // 
            Submitt.Location = new Point(235, 295);
            Submitt.Name = "Submitt";
            Submitt.Size = new Size(94, 29);
            Submitt.TabIndex = 9;
            Submitt.Text = "提交";
            Submitt.UseVisualStyleBackColor = true;
            Submitt.Click += Submitt_Click;
            // 
            // AddUserInfoForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Submitt);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(PhoneNumber);
            Controls.Add(IdCard);
            Controls.Add(Name);
            Controls.Add(TypeCard);
            Controls.Add(label1);
           
            Text = "AddUserForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label TypeCard;
        private Label Name;
        private Label IdCard;
        private Label PhoneNumber;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button Submitt;
    }
}