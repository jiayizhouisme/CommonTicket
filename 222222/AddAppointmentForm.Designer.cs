namespace _222222
{
    partial class AddAppointmentForm
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
            ID = new Label();
            Day = new Label();
            StartTime = new Label();
            EndTime = new Label();
            Add = new Button();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // ID
            // 
            ID.AutoSize = true;
            ID.Location = new Point(24, 30);
            ID.Name = "ID";
            ID.Size = new Size(23, 20);
            ID.TabIndex = 0;
            ID.Text = "id";
            // 
            // Day
            // 
            Day.AutoSize = true;
            Day.Location = new Point(24, 97);
            Day.Name = "Day";
            Day.Size = new Size(35, 20);
            Day.TabIndex = 1;
            Day.Text = "day";
            // 
            // StartTime
            // 
            StartTime.AutoSize = true;
            StartTime.Location = new Point(24, 160);
            StartTime.Name = "StartTime";
            StartTime.RightToLeft = RightToLeft.No;
            StartTime.Size = new Size(78, 20);
            StartTime.TabIndex = 2;
            StartTime.Text = "startTime";
            // 
            // EndTime
            // 
            EndTime.AutoSize = true;
            EndTime.Location = new Point(24, 228);
            EndTime.Name = "EndTime";
            EndTime.RightToLeft = RightToLeft.No;
            EndTime.Size = new Size(73, 20);
            EndTime.TabIndex = 3;
            EndTime.Text = "endTime";
            // 
            // Add
            // 
            Add.Location = new Point(24, 295);
            Add.Name = "Add";
            Add.Size = new Size(94, 29);
            Add.TabIndex = 4;
            Add.Text = "增加";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "HH:mm:ss";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(116, 160);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 5;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "HH:mm:ss";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(116, 228);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(116, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(116, 90);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 8;
            // 
            // AddAppointmentForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(Add);
            Controls.Add(EndTime);
            Controls.Add(StartTime);
            Controls.Add(Day);
            Controls.Add(ID);
            Name = "AddAppointmentForm";
            Text = "AddAppointmentForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ID;
        private Label Day;
        private Label StartTime;
        private Label EndTime;
        private Button Add;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}