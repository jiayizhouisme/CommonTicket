namespace VisitForm1
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
            dataGridView1 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Name = new DataGridViewTextBoxColumn();
            description = new DataGridViewTextBoxColumn();
            beforeDays = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewButtonColumn();
            Select = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, Name, description, beforeDays, Column5 });
            dataGridView1.Location = new Point(53, 66);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(698, 356);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.Width = 125;
            // 
            // Name
            // 
            Name.HeaderText = "名称";
            Name.MinimumWidth = 6;
            Name.Name = "Name";
            Name.Width = 125;
            // 
            // description
            // 
            description.HeaderText = "简介";
            description.MinimumWidth = 6;
            description.Name = "description";
            description.Width = 125;
            // 
            // beforeDays
            // 
            beforeDays.HeaderText = "提前天数";
            beforeDays.MinimumWidth = 6;
            beforeDays.Name = "beforeDays";
            beforeDays.Width = 125;
            // 
            // Column5
            // 
            Column5.HeaderText = "预约设置";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Text = "预约";
            Column5.ToolTipText = "预约";
            Column5.Width = 125;
            // 
            // Select
            // 
            Select.Location = new Point(53, 12);
            Select.Name = "Select";
            Select.Size = new Size(94, 29);
            Select.TabIndex = 1;
            Select.Text = "查询";
            Select.UseVisualStyleBackColor = true;
            Select.Click += Select_Click;
            // 
            // ExhibitionForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Select);
            Controls.Add(dataGridView1);
          
            Text = "ExhibitionForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button Select;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn description;
        private DataGridViewTextBoxColumn beforeDays;
        private DataGridViewButtonColumn Column5;
    }
}