namespace Online1
{
    partial class UpdateExhibitionForm
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
            Status = new TextBox();
            BasicPrice = new TextBox();
            Description = new TextBox();
            BeforeDays = new TextBox();
            TotalAmount = new TextBox();
            Name = new TextBox();
            Submit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 0;
            label1.Text = "状态";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 58);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 1;
            label2.Text = "价格";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 106);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 2;
            label3.Text = "简介";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 159);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 3;
            label4.Text = "提前天数";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 206);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 4;
            label5.Text = "预约人数";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 257);
            label6.Name = "label6";
            label6.Size = new Size(39, 20);
            label6.TabIndex = 5;
            label6.Text = "姓名";
            // 
            // Status
            // 
            Status.Location = new Point(114, 12);
            Status.Name = "Status";
            Status.Size = new Size(125, 27);
            Status.TabIndex = 6;
            // 
            // BasicPrice
            // 
            BasicPrice.Location = new Point(114, 58);
            BasicPrice.Name = "BasicPrice";
            BasicPrice.Size = new Size(125, 27);
            BasicPrice.TabIndex = 7;
            // 
            // Description
            // 
            Description.Location = new Point(114, 106);
            Description.Name = "Description";
            Description.Size = new Size(125, 27);
            Description.TabIndex = 8;
            // 
            // BeforeDays
            // 
            BeforeDays.Location = new Point(114, 159);
            BeforeDays.Name = "BeforeDays";
            BeforeDays.Size = new Size(125, 27);
            BeforeDays.TabIndex = 9;
            // 
            // TotalAmount
            // 
            TotalAmount.Location = new Point(114, 206);
            TotalAmount.Name = "TotalAmount";
            TotalAmount.Size = new Size(125, 27);
            TotalAmount.TabIndex = 10;
            // 
            // Name
            // 
            Name.Location = new Point(114, 257);
            Name.Name = "Name";
            Name.Size = new Size(125, 27);
            Name.TabIndex = 11;
            // 
            // Submit
            // 
            Submit.Location = new Point(14, 310);
            Submit.Name = "Submit";
            Submit.Size = new Size(94, 29);
            Submit.TabIndex = 12;
            Submit.Text = "提交";
            Submit.UseVisualStyleBackColor = true;
            Submit.Click += Submit_Click;
            // 
            // UpdateExhibitionForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Submit);
            Controls.Add(Name);
            Controls.Add(TotalAmount);
            Controls.Add(BeforeDays);
            Controls.Add(Description);
            Controls.Add(BasicPrice);
            Controls.Add(Status);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
          
            Text = "UpdateExhibitionForm";
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
        private TextBox Status;
        private TextBox BasicPrice;
        private TextBox Description;
        private TextBox BeforeDays;
        private TextBox TotalAmount;
        private TextBox Name;
        private Button Submit;
    }
}