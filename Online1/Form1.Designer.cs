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
            Column1 = new DataGridViewButtonColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Type
            // 
            Type.FormattingEnabled = true;
            Type.Location = new Point(19, 26);
            Type.Name = "Type";
            Type.Size = new Size(139, 28);
            Type.TabIndex = 0;
            Type.Text = "请选择类型";
            Type.SelectedIndexChanged += Type_SelectedIndexChanged;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(179, 27);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(173, 27);
            dateTimePicker.TabIndex = 1;
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // State
            // 
            State.FormattingEnabled = true;
            State.Location = new Point(376, 27);
            State.Name = "State";
            State.Size = new Size(151, 28);
            State.TabIndex = 2;
            State.Text = "请选择门票状态";
            State.SelectedIndexChanged += State_SelectedIndexChanged;
            // 
            // textBox
            // 
            textBox.Location = new Point(547, 29);
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column5, Column3, Column4, Column2 });
            dataGridView1.Location = new Point(35, 80);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(663, 337);
            dataGridView1.TabIndex = 5;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Resizable = DataGridViewTriState.True;
            Column1.SortMode = DataGridViewColumnSortMode.Automatic;
            Column1.Width = 125;
            // 
            // Column5
            // 
            Column5.HeaderText = "Column5";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "Column3";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "Column4";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "Column2";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(Search);
            Controls.Add(textBox);
            Controls.Add(State);
            Controls.Add(dateTimePicker);
            Controls.Add(Type);
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
        private DataGridViewButtonColumn Column1;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column2;
    }
}
