namespace Online
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
            Tickettype = new ComboBox();
            dateTime = new DateTimePicker();
            Ticketstatus = new ComboBox();
            Name = new Button();
            Search = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // Tickettype
            // 
            Tickettype.FormattingEnabled = true;
            Tickettype.Location = new Point(27, 41);
            Tickettype.Name = "Tickettype";
            Tickettype.Size = new Size(151, 28);
            Tickettype.TabIndex = 0;
            Tickettype.Text = "请选择类型";
            Tickettype.SelectedIndexChanged += Tickettype_SelectedIndexChanged;
            // 
            // dateTime
            // 
            dateTime.Location = new Point(184, 42);
            dateTime.Name = "dateTime";
            dateTime.Size = new Size(168, 27);
            dateTime.TabIndex = 1;
            dateTime.ValueChanged += dateTime_ValueChanged;
            // 
            // Ticketstatus
            // 
            Ticketstatus.FormattingEnabled = true;
            Ticketstatus.Location = new Point(372, 41);
            Ticketstatus.Name = "Ticketstatus";
            Ticketstatus.Size = new Size(151, 28);
            Ticketstatus.TabIndex = 2;
            Ticketstatus.Text = "请选择门票状态";
            Ticketstatus.SelectedIndexChanged += Ticketstatus_SelectedIndexChanged;
            // 
            // Name
            // 
            Name.Location = new Point(542, 41);
            Name.Name = "Name";
            Name.Size = new Size(94, 29);
            Name.TabIndex = 3;
            Name.Text = "请输入姓名";
            Name.UseVisualStyleBackColor = true;
            Name.Click += Name_Click;
            // 
            // Search
            // 
            Search.BackColor = SystemColors.ActiveCaption;
            Search.Cursor = Cursors.SizeAll;
            Search.Location = new Point(664, 41);
            Search.Name = "Search";
            Search.Size = new Size(94, 29);
            Search.TabIndex = 4;
            Search.Text = "搜索";
            Search.UseVisualStyleBackColor = false;
            Search.Click += Search_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(27, 104);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 5;
            textBox1.Text = "请输入姓名";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(Search);
            Controls.Add(Name);
            Controls.Add(Ticketstatus);
            Controls.Add(dateTime);
            Controls.Add(Tickettype);
         
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox Tickettype;
        private DateTimePicker dateTime;
        private ComboBox Ticketstatus;
        private Button Name;
        private Button Search;
        private TextBox textBox1;
    }
}
