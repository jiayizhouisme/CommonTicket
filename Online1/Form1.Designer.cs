namespace Online1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Type = new ComboBox();
            dateTimePicker = new DateTimePicker();
            State = new ComboBox();
            textBox = new TextBox();
            Search = new Button();
            dataGridView1 = new DataGridView();
            姓名 = new DataGridViewTextBoxColumn();
            身份证 = new DataGridViewTextBoxColumn();
            电话 = new DataGridViewTextBoxColumn();
            开始时间 = new DataGridViewTextBoxColumn();
            结束时间 = new DataGridViewTextBoxColumn();
            预约日期 = new DataGridViewTextBoxColumn();
            状态 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            checkBox1 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Type
            // 
            Type.FormattingEnabled = true;
            Type.Items.AddRange(new object[] { "全部" });
            Type.Location = new Point(19, 26);
            Type.Margin = new Padding(3, 4, 3, 4);
            Type.Name = "Type";
            Type.Size = new Size(139, 28);
            Type.TabIndex = 0;
            Type.Text = "全部";
            Type.SelectedIndexChanged += Type_SelectedIndexChanged;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(179, 27);
            dateTimePicker.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(172, 27);
            dateTimePicker.TabIndex = 1;
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // State
            // 
            State.FormattingEnabled = true;
            State.Items.AddRange(new object[] { "全部", "已使用", "未使用" });
            State.Location = new Point(375, 27);
            State.Margin = new Padding(3, 4, 3, 4);
            State.Name = "State";
            State.Size = new Size(151, 28);
            State.TabIndex = 2;
            State.Text = "全部";
            State.SelectedIndexChanged += State_SelectedIndexChanged;
            // 
            // textBox
            // 
            textBox.Location = new Point(546, 29);
            textBox.Margin = new Padding(3, 4, 3, 4);
            textBox.Name = "textBox";
            textBox.Size = new Size(125, 27);
            textBox.TabIndex = 3;
            textBox.Text = "请输入姓名";
            textBox.TextChanged += textBox_TextChanged;
            // 
            // Search
            // 
            Search.BackColor = SystemColors.ActiveCaption;
            Search.Location = new Point(678, 29);
            Search.Margin = new Padding(3, 4, 3, 4);
            Search.Name = "Search";
            Search.Size = new Size(94, 29);
            Search.TabIndex = 4;
            Search.Text = "搜索";
            Search.UseVisualStyleBackColor = false;
            Search.Click += Search_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { 姓名, 身份证, 电话, 开始时间, 结束时间, 预约日期, 状态, Column1 });
            dataGridView1.Location = new Point(19, 77);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1087, 366);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // 姓名
            // 
            姓名.HeaderText = "姓名";
            姓名.MinimumWidth = 6;
            姓名.Name = "姓名";
            姓名.Resizable = DataGridViewTriState.True;
            姓名.Width = 125;
            // 
            // 身份证
            // 
            身份证.HeaderText = "身份证";
            身份证.MinimumWidth = 6;
            身份证.Name = "身份证";
            身份证.Width = 125;
            // 
            // 电话
            // 
            电话.HeaderText = "电话";
            电话.MinimumWidth = 6;
            电话.Name = "电话";
            电话.Width = 125;
            // 
            // 开始时间
            // 
            开始时间.HeaderText = "开始时间";
            开始时间.MinimumWidth = 6;
            开始时间.Name = "开始时间";
            开始时间.Width = 125;
            // 
            // 结束时间
            // 
            结束时间.HeaderText = "结束时间";
            结束时间.MinimumWidth = 6;
            结束时间.Name = "结束时间";
            结束时间.Width = 125;
            // 
            // 预约日期
            // 
            预约日期.HeaderText = "预约日期";
            预约日期.MinimumWidth = 6;
            预约日期.Name = "预约日期";
            预约日期.Width = 125;
            // 
            // 状态
            // 
            状态.HeaderText = "状态";
            状态.MinimumWidth = 6;
            状态.Name = "状态";
            状态.Width = 125;
            // 
            // Column1
            // 
            Column1.HeaderText = "展馆";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(799, 34);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(106, 24);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "按时间查询";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1130, 466);
            Controls.Add(checkBox1);
            Controls.Add(dataGridView1);
            Controls.Add(Search);
            Controls.Add(textBox);
            Controls.Add(State);
            Controls.Add(dateTimePicker);
            Controls.Add(Type);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Type_SelectedIndexChanged;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox Type;
        private DateTimePicker dateTimePicker;
        private ComboBox State;
        private TextBox textBox;
        private Button Search;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn 姓名;
        private DataGridViewTextBoxColumn 身份证;
        private DataGridViewTextBoxColumn 电话;
        private DataGridViewTextBoxColumn 开始时间;
        private DataGridViewTextBoxColumn 结束时间;
        private DataGridViewTextBoxColumn 预约日期;
        private DataGridViewTextBoxColumn 状态;
        private DataGridViewTextBoxColumn Column1;
        private CheckBox checkBox1;
    }
}
