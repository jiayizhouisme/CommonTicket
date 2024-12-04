namespace VisitForm1
{
    partial class Reserve
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
            SelectDate = new DateTimePicker();
            label2 = new Label();
            SelectTime1 = new Label();
            SelectTime3 = new Label();
            SelectTime2 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            label3 = new Label();
            VisitorCount = new NumericUpDown();
            label4 = new Label();
            AddCount = new Button();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewButtonColumn();
            Submit = new Button();
            label5 = new Label();
            lblNeedMoreTourists = new Label();
            Select = new Button();
            ((System.ComponentModel.ISupportInitialize)VisitorCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 0;
            label1.Text = "选择日期";
            // 
            // SelectDate
            // 
            SelectDate.Location = new Point(12, 46);
            SelectDate.Name = "SelectDate";
            SelectDate.Size = new Size(339, 27);
            SelectDate.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 101);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 2;
            label2.Text = "选择时间";
            // 
            // SelectTime1
            // 
            SelectTime1.Location = new Point(12, 147);
            SelectTime1.Name = "SelectTime1";
            SelectTime1.Size = new Size(339, 25);
            SelectTime1.TabIndex = 3;
            SelectTime1.Text = "时间 8:00-11:00           余票 5000          ￥0.00";
            // 
            // SelectTime3
            // 
            SelectTime3.Location = new Point(12, 222);
            SelectTime3.Name = "SelectTime3";
            SelectTime3.Size = new Size(339, 25);
            SelectTime3.TabIndex = 5;
            SelectTime3.Text = "时间 15:00-18:00         余票 5000         ￥0.00";
            // 
            // SelectTime2
            // 
            SelectTime2.Location = new Point(12, 185);
            SelectTime2.Name = "SelectTime2";
            SelectTime2.Size = new Size(339, 25);
            SelectTime2.TabIndex = 6;
            SelectTime2.Text = "时间 11:00-15:00         余票 5000         ￥0.00";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(357, 146);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(61, 24);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "选择";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(357, 184);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(61, 24);
            checkBox2.TabIndex = 8;
            checkBox2.Text = "选择";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(357, 221);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(61, 24);
            checkBox3.TabIndex = 9;
            checkBox3.Text = "选择";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 274);
            label3.Name = "label3";
            label3.Size = new Size(99, 20);
            label3.TabIndex = 10;
            label3.Text = "选择游客数量";
            // 
            // VisitorCount
            // 
            VisitorCount.Location = new Point(12, 312);
            VisitorCount.Name = "VisitorCount";
            VisitorCount.Size = new Size(339, 27);
            VisitorCount.TabIndex = 11;
            VisitorCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            VisitorCount.ValueChanged += VisitorCount_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 366);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 12;
            label4.Text = "游客信息";
            // 
            // AddCount
            // 
            AddCount.Location = new Point(324, 362);
            AddCount.Name = "AddCount";
            AddCount.Size = new Size(94, 29);
            AddCount.TabIndex = 13;
            AddCount.Text = "新增游客";
            AddCount.UseVisualStyleBackColor = true;
            AddCount.Click += AddCount_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGridView1.Location = new Point(12, 408);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(569, 134);
            dataGridView1.TabIndex = 14;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "姓名";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "身份证";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "手机号";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "编辑";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // Submit
            // 
            Submit.Location = new Point(257, 561);
            Submit.Name = "Submit";
            Submit.Size = new Size(94, 29);
            Submit.TabIndex = 15;
            Submit.Text = "提交订单";
            Submit.UseVisualStyleBackColor = true;
            Submit.Click += Submit_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 570);
            label5.Name = "label5";
            label5.Size = new Size(105, 20);
            label5.TabIndex = 16;
            label5.Text = "总价    ￥ 0.00";
            // 
            // lblNeedMoreTourists
            // 
            lblNeedMoreTourists.AutoSize = true;
            lblNeedMoreTourists.Location = new Point(97, 366);
            lblNeedMoreTourists.Name = "lblNeedMoreTourists";
            lblNeedMoreTourists.Size = new Size(122, 20);
            lblNeedMoreTourists.TabIndex = 17;
            lblNeedMoreTourists.Text = "  ！需增加位游客";
            // 
            // Select
            // 
            Select.Location = new Point(487, 366);
            Select.Name = "Select";
            Select.Size = new Size(94, 29);
            Select.TabIndex = 18;
            Select.Text = "查询";
            Select.UseVisualStyleBackColor = true;
            Select.Click += Select_Click;
            // 
            // Reserve
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 602);
            Controls.Add(Select);
            Controls.Add(lblNeedMoreTourists);
            Controls.Add(label5);
            Controls.Add(Submit);
            Controls.Add(dataGridView1);
            Controls.Add(AddCount);
            Controls.Add(label4);
            Controls.Add(VisitorCount);
            Controls.Add(label3);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(SelectTime2);
            Controls.Add(SelectTime3);
            Controls.Add(SelectTime1);
            Controls.Add(label2);
            Controls.Add(SelectDate);
            Controls.Add(label1);
            Name = "Reserve";
            Text = "在线预约";
            ((System.ComponentModel.ISupportInitialize)VisitorCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker SelectDate;
        private Label label2;
        private Label SelectTime1;
        private Label SelectTime3;
        private Label SelectTime2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private Label label3;
        private NumericUpDown VisitorCount;
        private Label label4;
        private Button AddCount;
        private DataGridView dataGridView1;
        private Button Submit;
        private Label label5;
        private Label lblNeedMoreTourists;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewButtonColumn Column4;
        private Button Select;
    }
}