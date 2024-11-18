namespace Online1
{
    partial class Form2
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
            
           Status1 = new TextBox();
            BasicPrice1 = new TextBox();
            Description1 = new TextBox();
            BeforeDays1 = new TextBox();
            TotalAmount1 = new TextBox();
            Name1 = new TextBox();
            ID1 = new TextBox();
            Status = new Label();
            BasicPrice = new Label();
            Description = new Label();
            BeforeDays = new Label();
            TotalAmount = new Label();
            Name = new Label();
            ID = new Label();
            Submit = new Button();
            SuspendLayout();
            // 
            // Status1
            // 
            Status1.Location = new Point(135, 34);
            Status1.Name = "Status1";
            Status1.Size = new Size(125, 27);
            Status1.TabIndex = 1;
            // 
            // BasicPrice1
            // 
            BasicPrice1.Location = new Point(135, 80);
            BasicPrice1.Name = "BasicPrice1";
            BasicPrice1.Size = new Size(125, 27);
            BasicPrice1.TabIndex = 2;
            // 
            // Description1
            // 
            Description1.Location = new Point(135, 133);
            Description1.Name = "Description1";
            Description1.Size = new Size(125, 27);
            Description1.TabIndex = 3;
            // 
            // BeforeDays1
            // 
            BeforeDays1.Location = new Point(135, 189);
            BeforeDays1.Name = "BeforeDays1";
            BeforeDays1.Size = new Size(125, 27);
            BeforeDays1.TabIndex = 4;
            // 
            // TotalAmount1
            // 
            TotalAmount1.Location = new Point(135, 246);
            TotalAmount1.Name = "TotalAmount1";
            TotalAmount1.Size = new Size(125, 27);
            TotalAmount1.TabIndex = 5;
            // 
            // Name1
            // 
            Name1.Location = new Point(135, 306);
            Name1.Name = "Name1";
            Name1.Size = new Size(125, 27);
            Name1.TabIndex = 6;


            ID1.Location = new Point(135, 0);
            ID1.Name = "ID1";
            ID1.Size = new Size(125, 27);
            ID1.TabIndex = 6;
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


           ID.AutoSize = true;
           ID.Location = new Point(30, 10);
           ID.Name = "ID";
           ID.Size = new Size(69, 20);
           ID.TabIndex = 12;
           ID.Text = "id";
            // 
            // Submit
            // 
            Submit.Location = new Point(30, 356);
            Submit.Name = "Submit";
            Submit.Size = new Size(94, 29);
            Submit.TabIndex = 13;
            Submit.Text = "提交";
            Submit.UseVisualStyleBackColor = true;
            //Submit.Click += Submit_Click;
            // 
            // AddExhibitionForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 450);
            Controls.Add(Submit);
            Controls.Add(ID);
            Controls.Add(Name);
            Controls.Add(TotalAmount);
            Controls.Add(BeforeDays);
            Controls.Add(Description);
            Controls.Add(BasicPrice);
            Controls.Add(Status);
            Controls.Add(ID1);
            Controls.Add(Name1);
            Controls.Add(TotalAmount1);
            Controls.Add(BeforeDays1);
            Controls.Add(Description1);
            Controls.Add(BasicPrice1);
            Controls.Add(Status1);

            Text = "UpdateExhibitionForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Status1;
        private TextBox BasicPrice1;
        private TextBox Description1;
        private TextBox BeforeDays1;
        private TextBox TotalAmount1;
        private TextBox Name1;
        private TextBox ID1;
        private Label Status;
        private Label BasicPrice;
        private Label Description;
        private Label BeforeDays;
        private Label TotalAmount;
        private Label Name;
        private Label ID;
        private Button Submit;
    }
}