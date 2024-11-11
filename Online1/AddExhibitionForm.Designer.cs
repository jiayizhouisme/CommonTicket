namespace Online1
{
    partial class AddExhibitionForm
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            Status = new Label();
            BasicPrice = new Label();
            Description = new Label();
            BeforeDays = new Label();
            TotalAmount = new Label();
            Name = new Label();
            Submit = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(135, 34);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(135, 80);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(135, 133);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(135, 189);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 4;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(135, 246);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 5;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(135, 306);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(125, 27);
            textBox6.TabIndex = 6;
            // 
            // Status
            // 
            Status.AutoSize = true;
            Status.Location = new Point(30, 34);
            Status.Name = "Status";
            Status.Size = new Size(39, 20);
            Status.TabIndex = 7;
            Status.Text = "状态";
            // 
            // BasicPrice
            // 
            BasicPrice.AutoSize = true;
            BasicPrice.Location = new Point(30, 83);
            BasicPrice.Name = "BasicPrice";
            BasicPrice.Size = new Size(39, 20);
            BasicPrice.TabIndex = 8;
            BasicPrice.Text = "价格";
            // 
            // Description
            // 
            Description.AutoSize = true;
            Description.Location = new Point(30, 140);
            Description.Name = "Description";
            Description.Size = new Size(39, 20);
            Description.TabIndex = 9;
            Description.Text = "简介";
            // 
            // BeforeDays
            // 
            BeforeDays.AutoSize = true;
            BeforeDays.Location = new Point(30, 192);
            BeforeDays.Name = "BeforeDays";
            BeforeDays.Size = new Size(69, 20);
            BeforeDays.TabIndex = 10;
            BeforeDays.Text = "提前天数";
            // 
            // TotalAmount
            // 
            TotalAmount.AutoSize = true;
            TotalAmount.Location = new Point(30, 249);
            TotalAmount.Name = "TotalAmount";
            TotalAmount.Size = new Size(69, 20);
            TotalAmount.TabIndex = 11;
            TotalAmount.Text = "预约人数";
            // 
            // Name
            // 
            Name.AutoSize = true;
            Name.Location = new Point(30, 309);
            Name.Name = "Name";
            Name.Size = new Size(69, 20);
            Name.TabIndex = 12;
            Name.Text = "展馆名字";
            // 
            // Submit
            // 
            Submit.Location = new Point(30, 356);
            Submit.Name = "Submit";
            Submit.Size = new Size(94, 29);
            Submit.TabIndex = 13;
            Submit.Text = "提交";
            Submit.UseVisualStyleBackColor = true;
            Submit.Click += Submit_Click;
            // 
            // AddExhibitionForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 450);
            Controls.Add(Submit);
            Controls.Add(Name);
            Controls.Add(TotalAmount);
            Controls.Add(BeforeDays);
            Controls.Add(Description);
            Controls.Add(BasicPrice);
            Controls.Add(Status);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
         
            Text = "AddExhibitionForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label Status;
        private Label BasicPrice;
        private Label Description;
        private Label BeforeDays;
        private Label TotalAmount;
        private Label Name;
        private Button Submit;
    }
}