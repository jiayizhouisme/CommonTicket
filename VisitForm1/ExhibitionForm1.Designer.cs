namespace VisitForm1
{
    partial class ExhibitionForm1
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
            Select = new Button();
            Column1 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column3, Column2 });
            dataGridView1.Location = new Point(51, 108);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(450, 281);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Select
            // 
            Select.Location = new Point(51, 37);
            Select.Name = "Select";
            Select.Size = new Size(94, 29);
            Select.TabIndex = 1;
            Select.Text = "查询";
            Select.UseVisualStyleBackColor = true;
            Select.Click += Select_Click;
            // 
            // Column1
            // 
            Column1.HeaderText = "门票";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column3
            // 
            Column3.DataPropertyName = "BasicPrice";
            Column3.HeaderText = "价格";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "预约";
            Column2.HeaderText = "预约";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Text = "预约";
            Column2.ToolTipText = "预约";
            Column2.UseColumnTextForButtonValue = true;
            Column2.Width = 125;
            // 
            // ExhibitionForm1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Select);
            Controls.Add(dataGridView1);
            Name = "ExhibitionForm1";
            Text = "ExhibitionForm1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button Select;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewButtonColumn Column2;
    }
}