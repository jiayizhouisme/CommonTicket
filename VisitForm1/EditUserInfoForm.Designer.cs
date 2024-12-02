namespace VisitForm1
{
    partial class EditUserInfoForm
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
            label2 = new Label();
            Name = new Label();
            IdCard = new Label();
            PhoneNumber = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            Submit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(272, 19);
            label1.Name = "label1";
            label1.Size = new Size(171, 33);
            label1.TabIndex = 0;
            label1.Text = "编辑游客信息";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(238, 73);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 1;
            label2.Text = "身份证";
            // 
            // Name
            // 
            Name.AutoSize = true;
            Name.Location = new Point(238, 129);
            Name.Name = "Name";
            Name.Size = new Size(39, 20);
            Name.TabIndex = 2;
            Name.Text = "姓名";
            // 
            // IdCard
            // 
            IdCard.AutoSize = true;
            IdCard.Location = new Point(238, 189);
            IdCard.Name = "IdCard";
            IdCard.Size = new Size(54, 20);
            IdCard.TabIndex = 3;
            IdCard.Text = "证件号";
            // 
            // PhoneNumber
            // 
            PhoneNumber.AutoSize = true;
            PhoneNumber.Location = new Point(238, 246);
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.Size = new Size(54, 20);
            PhoneNumber.TabIndex = 4;
            PhoneNumber.Text = "手机号";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(349, 70);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(187, 27);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(349, 129);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(187, 27);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(349, 189);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(187, 27);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(349, 246);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(187, 27);
            textBox4.TabIndex = 8;
            // 
            // Submit
            // 
            Submit.Location = new Point(238, 310);
            Submit.Name = "Submit";
            Submit.Size = new Size(94, 29);
            Submit.TabIndex = 9;
            Submit.Text = "确定";
            Submit.UseVisualStyleBackColor = true;
            Submit.Click += Submit_Click;
            // 
            // EditUserInfoForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Submit);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(PhoneNumber);
            Controls.Add(IdCard);
            Controls.Add(Name);
            Controls.Add(label2);
            Controls.Add(label1);
         
            Text = "EditUserInfoForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label Name;
        private Label IdCard;
        private Label PhoneNumber;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button Submit;
    }
}