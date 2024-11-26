namespace Online1
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
            dataGridView1 = new DataGridView();
            Submit = new Button();
            Add = new Button();
            IDColumn = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewButtonColumn();
            Column5 = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IDColumn, Column6, Column1, Column2, Column3, Column4, Column5 });
            dataGridView1.Location = new Point(21, 81);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(941, 357);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Submit
            // 
            Submit.Location = new Point(21, 24);
            Submit.Name = "Submit";
            Submit.Size = new Size(94, 29);
            Submit.TabIndex = 5;
            Submit.Text = "查询";
            Submit.UseVisualStyleBackColor = true;
            Submit.Click += Submit_Click;
            // 
            // Add
            // 
            Add.Location = new Point(132, 24);
            Add.Name = "Add";
            Add.Size = new Size(94, 29);
            Add.TabIndex = 6;
            Add.Text = "增加";
            Add.UseVisualStyleBackColor = true;
            Add.Click += AdddataGirdView1_CellContentClick;
            // 
            // IDColumn
            // 
            IDColumn.HeaderText = "Id";
            IDColumn.MinimumWidth = 6;
            IDColumn.Name = "IDColumn";
            IDColumn.Resizable = DataGridViewTriState.True;
            IDColumn.Width = 125;
            // 
            // Column6
            // 
            Column6.HeaderText = "ObjectId";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.Width = 125;
            // 
            // Column1
            // 
            Column1.HeaderText = "天数";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Resizable = DataGridViewTriState.True;
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "开始时间";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "结束时间";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "修改";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Text = "修改";
            Column4.ToolTipText = "修改";
            Column4.UseColumnTextForButtonValue = true;
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.HeaderText = "删除";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Text = "删除";
            Column5.ToolTipText = "删除";
            Column5.UseColumnTextForButtonValue = true;
            Column5.Width = 125;
            // 
            // MainAppointmentForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1119, 450);
            Controls.Add(Add);
            Controls.Add(Submit);
            Controls.Add(dataGridView1);
            Name = "MainAppointmentForm";
            Text = "MainAppointmentForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView1;
        private Button Submit;
        private Button Add;
        private DataGridViewTextBoxColumn IDColumn;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewButtonColumn Column4;
        private DataGridViewButtonColumn Column5;
    }
}