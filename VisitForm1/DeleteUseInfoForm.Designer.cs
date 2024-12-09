namespace VisitForm1
{
    partial class DeleteUseInfoForm
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
            Name = new Label();
            IdCard = new Label();
            PhoneNumber = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            Delete = new Button();
            Id = new Label();
            UserId = new TextBox();
            SuspendLayout();
            // 
            // Name
            // 
            Name.AutoSize = true;
            Name.Location = new Point(76, 95);
            Name.Name = "Name";
            Name.Size = new Size(39, 20);
            Name.TabIndex = 0;
            Name.Text = "姓名";
            // 
            // IdCard
            // 
            IdCard.AutoSize = true;
            IdCard.Location = new Point(76, 156);
            IdCard.Name = "IdCard";
            IdCard.Size = new Size(54, 20);
            IdCard.TabIndex = 1;
            IdCard.Text = "身份证";
            // 
            // PhoneNumber
            // 
            PhoneNumber.AutoSize = true;
            PhoneNumber.Location = new Point(76, 221);
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.Size = new Size(54, 20);
            PhoneNumber.TabIndex = 2;
            PhoneNumber.Text = "手机号";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(179, 88);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(179, 153);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(179, 214);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 5;
            // 
            // Delete
            // 
            Delete.Location = new Point(76, 288);
            Delete.Name = "Delete";
            Delete.Size = new Size(94, 29);
            Delete.TabIndex = 6;
            Delete.Text = "删除";
            Delete.UseVisualStyleBackColor = true;
           // Delete.Click += Delete_Click;
            // 
            // Id
            // 
            Id.AutoSize = true;
            Id.Location = new Point(76, 35);
            Id.Name = "Id";
            Id.Size = new Size(23, 20);
            Id.TabIndex = 7;
            Id.Text = "Id";
            // 
            // UserId
            // 
            UserId.Location = new Point(179, 32);
            UserId.Name = "UserId";
            UserId.Size = new Size(125, 27);
            UserId.TabIndex = 8;
            // 
            // DeleteUseInfoForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(UserId);
            Controls.Add(Id);
            Controls.Add(Delete);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(PhoneNumber);
            Controls.Add(IdCard);
            Controls.Add(Name);
         
            Text = "DeleteUseInfoForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Name;
        private Label IdCard;
        private Label PhoneNumber;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button Delete;
        private Label Id;
        private TextBox UserId;
    }
}