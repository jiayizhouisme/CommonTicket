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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Search);
            Controls.Add(textBox);
            Controls.Add(State);
            Controls.Add(dateTimePicker);
            Controls.Add(Type);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox Type;
        private DateTimePicker dateTimePicker;
        private ComboBox State;
        private TextBox textBox;
        private Button Search;
    }
}
