namespace Online1
{
    partial class ExhibitionForm
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
            Insert = new Button();
            Delete = new Button();
            Update = new Button();
            dataGridView1 = new DataGridView();
            Select = new Button();
            IDColumn = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewButtonColumn();
            Column5 = new DataGridViewButtonColumn();
            预约 = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Insert
            // 
            Insert.Location = new Point(50, 30);
            Insert.Name = "Insert";
            Insert.Size = new Size(94, 29);
            Insert.TabIndex = 0;
            Insert.Text = "增加";
            Insert.UseVisualStyleBackColor = true;
            Insert.Click += AdddataGirdView1_CellContentClick;
            // 
            // Delete
            // 
            Delete.Location = new Point(186, 30);
            Delete.Name = "Delete";
            Delete.Size = new Size(94, 29);
            Delete.TabIndex = 1;
            Delete.Text = "删除";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += DeletedataGridView1_CellContentClick;
            // 
            // Update
            // 
            Update.Location = new Point(326, 30);
            Update.Name = "Update";
            Update.Size = new Size(94, 29);
            Update.TabIndex = 2;
            Update.Text = "修改";
            Update.UseVisualStyleBackColor = true;
            Update.Click += Update_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IDColumn, Column1, Column2, Column3, Column4, Column5, 预约 });
            dataGridView1.Location = new Point(33, 81);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(930, 357);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Select
            // 
            Select.Location = new Point(460, 30);
            Select.Name = "Select";
            Select.Size = new Size(94, 29);
            Select.TabIndex = 4;
            Select.Text = "查询";
            Select.UseVisualStyleBackColor = true;
            Select.Click += Select_Click;
            // 
            // IDColumn
            // 
            IDColumn.HeaderText = "ID";
            IDColumn.MinimumWidth = 6;
            IDColumn.Name = "IDColumn";
            IDColumn.Resizable = DataGridViewTriState.True;
            IDColumn.Width = 125;
            // 
            // Column1
            // 
            Column1.HeaderText = "名称";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Resizable = DataGridViewTriState.True;
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "简介";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "提前天数";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "删除";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Text = "删除";
            Column4.ToolTipText = "删除";
            Column4.UseColumnTextForButtonValue = true;
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.HeaderText = "修改";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Text = "修改";
            Column5.ToolTipText = "修改";
            Column5.UseColumnTextForButtonValue = true;
            Column5.Width = 125;
            // 
            // 预约
            // 
            预约.HeaderText = "预约设置";
            预约.MinimumWidth = 6;
            预约.Name = "预约";
            预约.Text = "预约";
            预约.ToolTipText = "预约";
            预约.UseColumnTextForButtonValue = true;
            预约.Width = 125;
            // 
            // ExhibitionForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 450);
            Controls.Add(Select);
            Controls.Add(dataGridView1);
            Controls.Add(Update);
            Controls.Add(Delete);
            Controls.Add(Insert);
            Name = "ExhibitionForm";
            Text = "ExhibitionForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button Insert;
        private Button Delete;
        private Button Update;
        private DataGridView dataGridView1;
        private Button Select;
        private DataGridViewTextBoxColumn IDColumn;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewButtonColumn Column4;
        private DataGridViewButtonColumn Column5;
        private DataGridViewButtonColumn 预约;
    }
}