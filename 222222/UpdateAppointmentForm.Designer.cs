namespace _222222
{
    partial class UpdateAppointmentForm
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            Submit = new Button();
            dateTimePicker2 = new DateTimePicker();
            SuspendLayout();
            // 
            // ID
            // 
            ID.AutoSize = true;
            ID.Location = new Point(14, 14);
            ID.Name = "ID";
            ID.Size = new Size(23, 20);
            ID.TabIndex = 0;
            ID.Text = "id";
            // 
            // Day
            // 
            Day.AutoSize = true;
            Day.Location = new Point(14, 80);
            Day.Name = "Day";
            Day.Size = new Size(35, 20);
            Day.TabIndex = 1;
            Day.Text = "day";
            // 
            // StartTime
            // 
            StartTime.AutoSize = true;
            StartTime.Location = new Point(14, 157);
            StartTime.Name = "StartTime";
            StartTime.Size = new Size(78, 20);
            StartTime.TabIndex = 2;
            StartTime.Text = "startTime";
            // 
            // EndTime
            // 
            EndTime.AutoSize = true;
            EndTime.Location = new Point(14, 229);
            EndTime.Name = "EndTime";
            EndTime.Size = new Size(73, 20);
            EndTime.TabIndex = 3;
            EndTime.Text = "endTime";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(128, 14);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 4;
            textBox1.Text = "id";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(128, 80);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "HH:mm:ss";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(128, 229);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 7;
            // 
            // Submit
            // 
            Submit.Location = new Point(14, 302);
            Submit.Name = "Submit";
            Submit.Size = new Size(94, 29);
            Submit.TabIndex = 8;
            Submit.Text = "提交";
            Submit.UseVisualStyleBackColor = true;
            Submit.Click += Submit_Click;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "HH:mm:ss";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(128, 157);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 9;
            // 
            // AppointmentForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 450);
            Controls.Add(dateTimePicker2);
            Controls.Add(Submit);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(EndTime);
            Controls.Add(StartTime);
            Controls.Add(Day);
            Controls.Add(ID);
            Name = "AppointmentForm";
            Text = "DateTimeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ID;
        private Label Day;
        private Label StartTime;
        private Label EndTime;
        private TextBox textBox1;
        private TextBox textBox2;
        private DateTimePicker dateTimePicker1;
        private Button Submit;
        private DateTimePicker dateTimePicker2;
    }
}