namespace VisitForm1
{
    partial class MainAppointmentForm
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
            dateTimePicker1 = new DateTimePicker();
            Date = new Label();
            Time = new Label();
            numericUpDown1 = new NumericUpDown();
            Count = new Label();
            UserInfo = new Label();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewButtonColumn();
            Submit = new Button();
            Add = new Button();
            Time2 = new Label();
            Time3 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            Time4 = new Label();
            checkBox3 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(21, 44);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(257, 27);
            dateTimePicker1.TabIndex = 0;
            // 
            // Date
            // 
            Date.AutoSize = true;
            Date.Location = new Point(21, 9);
            Date.Name = "Date";
            Date.Size = new Size(69, 20);
            Date.TabIndex = 1;
            Date.Text = "选择日期";
            // 
            // Time
            // 
            Time.AutoSize = true;
            Time.Location = new Point(21, 89);
            Time.Name = "Time";
            Time.Size = new Size(69, 20);
            Time.TabIndex = 2;
            Time.Text = "选择时间";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(21, 302);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(250, 27);
            numericUpDown1.TabIndex = 4;
            // 
            // Count
            // 
            Count.AutoSize = true;
            Count.Location = new Point(21, 266);
            Count.Name = "Count";
            Count.Size = new Size(99, 20);
            Count.TabIndex = 5;
            Count.Text = "选择游客数量";
            // 
            // UserInfo
            // 
            UserInfo.AutoSize = true;
            UserInfo.Location = new Point(21, 355);
            UserInfo.Name = "UserInfo";
            UserInfo.Size = new Size(69, 20);
            UserInfo.TabIndex = 6;
            UserInfo.Text = "游客信息";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1 });
            dataGridView1.Location = new Point(21, 416);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(373, 76);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "编辑";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Text = "编辑";
            Column1.UseColumnTextForButtonValue = true;
            Column1.Width = 125;
            // 
            // Submit
            // 
            Submit.Location = new Point(21, 522);
            Submit.Name = "Submit";
            Submit.Size = new Size(94, 29);
            Submit.TabIndex = 8;
            Submit.Text = "提交订单";
            Submit.UseVisualStyleBackColor = true;
            Submit.Click += Submit_Click;
            // 
            // Add
            // 
            Add.Location = new Point(267, 351);
            Add.Name = "Add";
            Add.Size = new Size(94, 29);
            Add.TabIndex = 9;
            Add.Text = "新增游客";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // Time2
            // 
            Time2.Location = new Point(21, 126);
            Time2.Name = "Time2";
            Time2.Size = new Size(284, 24);
            Time2.TabIndex = 10;
            Time2.Text = "时间 8:00-11:00    余票 5000   ￥0.00";
            // 
            // Time3
            // 
            Time3.Location = new Point(21, 168);
            Time3.Name = "Time3";
            Time3.Size = new Size(273, 25);
            Time3.TabIndex = 11;
            Time3.Text = "时间 11:00-15:00   余票 5000   ￥0.00";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(300, 126);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(61, 24);
            checkBox1.TabIndex = 12;
            checkBox1.Text = "选择";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(300, 167);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(61, 24);
            checkBox2.TabIndex = 13;
            checkBox2.Text = "选择";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // Time4
            // 
            Time4.AutoSize = true;
            Time4.Location = new Point(21, 210);
            Time4.Name = "Time4";
            Time4.Size = new Size(269, 20);
            Time4.TabIndex = 14;
            Time4.Text = "时间 15:00-18:30   余票 5000   ￥0.00";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(300, 210);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(61, 24);
            checkBox3.TabIndex = 15;
            checkBox3.Text = "选择";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // MainAppointmentForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 612);
            Controls.Add(checkBox3);
            Controls.Add(Time4);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(Time3);
            Controls.Add(Time2);
            Controls.Add(Add);
            Controls.Add(Submit);
            Controls.Add(dataGridView1);
            Controls.Add(UserInfo);
            Controls.Add(Count);
            Controls.Add(numericUpDown1);
            Controls.Add(Time);
            Controls.Add(Date);
            Controls.Add(dateTimePicker1);
            Name = "MainAppointmentForm";
            Text = "MainAppointmentForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private Label Date;
        private Label Time;
        private NumericUpDown numericUpDown1;
        private Label Count;
        private Label UserInfo;
        private DataGridView dataGridView1;
        private Button Submit;
        private Button Add;
        private Label Time2;
        private Label Time3;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Label Time4;
        private CheckBox checkBox3;
        private DataGridViewButtonColumn Column1;
    }
}