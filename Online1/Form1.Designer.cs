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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Type
            // 
            Type.FormattingEnabled = true;
            Type.Location = new Point(15, 22);
            Type.Margin = new Padding(2, 3, 2, 3);
            Type.Name = "Type";
            Type.Size = new Size(109, 25);
            Type.TabIndex = 0;
            Type.Text = "请选择类型";
            Type.SelectedIndexChanged += Type_SelectedIndexChanged;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(139, 23);
            dateTimePicker.Margin = new Padding(2, 3, 2, 3);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(135, 23);
            dateTimePicker.TabIndex = 1;
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // State
            // 
            State.FormattingEnabled = true;
            State.Location = new Point(292, 23);
            State.Margin = new Padding(2, 3, 2, 3);
            State.Name = "State";
            State.Size = new Size(118, 25);
            State.TabIndex = 2;
            State.Text = "请选择门票状态";
            State.SelectedIndexChanged += State_SelectedIndexChanged;
            // 
            // textBox
            // 
            textBox.Location = new Point(425, 25);
            textBox.Margin = new Padding(2, 3, 2, 3);
            textBox.Name = "textBox";
            textBox.Size = new Size(98, 23);
            textBox.TabIndex = 3;
            textBox.Text = "请输入姓名";
            textBox.TextChanged += textBox_TextChanged;
            // 
            // Search
            // 
            Search.BackColor = SystemColors.ActiveCaption;
            Search.Location = new Point(527, 25);
            Search.Margin = new Padding(2, 3, 2, 3);
            Search.Name = "Search";
            Search.Size = new Size(73, 25);
            Search.TabIndex = 4;
            Search.Text = "搜索";
            Search.UseVisualStyleBackColor = false;
            Search.Click += Search_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { 姓名, 身份证, 电话, 开始时间, 结束时间 });
            dataGridView1.Location = new Point(15, 73);
            dataGridView1.Margin = new Padding(2, 3, 2, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(679, 311);
            dataGridView1.TabIndex = 5;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 396);
            Controls.Add(dataGridView1);
            Controls.Add(Search);
            Controls.Add(textBox);
            Controls.Add(State);
            Controls.Add(dateTimePicker);
            Controls.Add(Type);
            Margin = new Padding(2, 3, 2, 3);
            Name = "Form1";
            Text = "Form1";
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
    }
}
