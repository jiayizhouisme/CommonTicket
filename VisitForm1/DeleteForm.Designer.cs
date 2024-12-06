namespace VisitForm1
{
    partial class DeleteForm
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
            Submit = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            Id = new Label();
            IdtextBox = new TextBox();
            SuspendLayout();
            // 
            // Name
            // 
            Name.AutoSize = true;
            Name.Location = new Point(100, 104);
            Name.Name = "Name";
            Name.Size = new Size(39, 20);
            Name.TabIndex = 0;
            Name.Text = "姓名";
            // 
            // IdCard
            // 
            IdCard.AutoSize = true;
            IdCard.Location = new Point(100, 168);
            IdCard.Name = "IdCard";
            IdCard.Size = new Size(54, 20);
            IdCard.TabIndex = 1;
            IdCard.Text = "身份证";
            // 
            // PhoneNumber
            // 
            PhoneNumber.AutoSize = true;
            PhoneNumber.Location = new Point(100, 228);
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.Size = new Size(54, 20);
            PhoneNumber.TabIndex = 2;
            PhoneNumber.Text = "手机号";
            // 
            // Submit
            // 
            Submit.Location = new Point(100, 278);
            Submit.Name = "Submit";
            Submit.Size = new Size(94, 29);
            Submit.TabIndex = 3;
            Submit.Text = "删除";
            Submit.UseVisualStyleBackColor = true;
            Submit.Click += Submit_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(197, 97);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(197, 161);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(197, 221);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 6;
            // 
            // Id
            // 
            Id.AutoSize = true;
            Id.Location = new Point(100, 42);
            Id.Name = "Id";
            Id.Size = new Size(27, 20);
            Id.TabIndex = 7;
            Id.Text = "id ";
            // 
            // IdtextBox
            // 
            IdtextBox.Location = new Point(197, 35);
            IdtextBox.Name = "IdtextBox";
            IdtextBox.Size = new Size(125, 27);
            IdtextBox.TabIndex = 8;
            // 
            // DeleteForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(IdtextBox);
            Controls.Add(Id);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(Submit);
            Controls.Add(PhoneNumber);
            Controls.Add(IdCard);
            Controls.Add(Name);
          
            Text = "DeleteForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Name;
        private Label IdCard;
        private Label PhoneNumber;
        private Button Submit;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label Id;
        private TextBox IdtextBox;
    }
}