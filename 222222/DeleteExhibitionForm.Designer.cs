namespace Online1
{
    partial class DeleteExhibitionForm
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            Submit = new Button();
            Status = new TextBox();
            BasicPrice = new TextBox();
            Description = new TextBox();
            BeforeDays = new TextBox();
            TotalAmount = new TextBox();
            Name = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 16);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(32, 17);
            label1.TabIndex = 0;
            label1.Text = "状态";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 57);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(32, 17);
            label2.TabIndex = 1;
            label2.Text = "价格";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 100);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(32, 17);
            label3.TabIndex = 2;
            label3.Text = "简介";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 144);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(56, 17);
            label4.TabIndex = 3;
            label4.Text = "提前天数";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 184);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(56, 17);
            label5.TabIndex = 4;
            label5.Text = "预约人数";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 230);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(56, 17);
            label6.TabIndex = 5;
            label6.Text = "展馆名字";
            // 
            // Submit
            // 
            Submit.Location = new Point(19, 271);
            Submit.Margin = new Padding(2, 3, 2, 3);
            Submit.Name = "Submit";
            Submit.Size = new Size(73, 25);
            Submit.TabIndex = 12;
            Submit.Text = "提交";
            Submit.UseVisualStyleBackColor = true;
            Submit.Click += Submit_Click;
            // 
            // Status
            // 
            Status.Location = new Point(106, 16);
            Status.Margin = new Padding(2, 3, 2, 3);
            Status.Name = "Status";
            Status.Size = new Size(98, 23);
            Status.TabIndex = 13;
            // 
            // BasicPrice
            // 
            BasicPrice.Location = new Point(106, 54);
            BasicPrice.Margin = new Padding(2, 3, 2, 3);
            BasicPrice.Name = "BasicPrice";
            BasicPrice.Size = new Size(98, 23);
            BasicPrice.TabIndex = 14;
            // 
            // Description
            // 
            Description.Location = new Point(106, 98);
            Description.Margin = new Padding(2, 3, 2, 3);
            Description.Name = "Description";
            Description.Size = new Size(98, 23);
            Description.TabIndex = 15;
            // 
            // BeforeDays
            // 
            BeforeDays.Location = new Point(106, 146);
            BeforeDays.Margin = new Padding(2, 3, 2, 3);
            BeforeDays.Name = "BeforeDays";
            BeforeDays.Size = new Size(98, 23);
            BeforeDays.TabIndex = 16;
            // 
            // TotalAmount
            // 
            TotalAmount.Location = new Point(106, 184);
            TotalAmount.Margin = new Padding(2, 3, 2, 3);
            TotalAmount.Name = "TotalAmount";
            TotalAmount.Size = new Size(98, 23);
            TotalAmount.TabIndex = 17;
            // 
            // Name
            // 
            Name.Location = new Point(106, 230);
            Name.Margin = new Padding(2, 3, 2, 3);
            Name.Name = "Name";
            Name.Size = new Size(98, 23);
            Name.TabIndex = 18;
            // 
            // DeleteExhibitionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(262, 306);
            Controls.Add(Name);
            Controls.Add(TotalAmount);
            Controls.Add(BeforeDays);
            Controls.Add(Description);
            Controls.Add(BasicPrice);
            Controls.Add(Status);
            Controls.Add(Submit);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2, 3, 2, 3);
            Text = "DeleteExhibitionForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button Submit;
        private TextBox Status;
        private TextBox BasicPrice;
        private TextBox Description;
        private TextBox BeforeDays;
        private TextBox TotalAmount;
        private TextBox Name;
    }
}