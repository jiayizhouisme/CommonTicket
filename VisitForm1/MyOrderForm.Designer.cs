namespace VisitForm1
{
    partial class MyOrderForm
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            Refund = new Button();
            Use = new Button();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            Refund1 = new Button();
            Use1 = new Button();
            tabPage5 = new TabPage();
            groupBox1 = new GroupBox();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage4.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(708, 535);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(Refund);
            tabPage1.Controls.Add(Use);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(700, 502);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "全部";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // Refund
            // 
            Refund.Location = new Point(138, 455);
            Refund.Name = "Refund";
            Refund.Size = new Size(94, 29);
            Refund.TabIndex = 1;
            Refund.Text = "去退款";
            Refund.UseVisualStyleBackColor = true;
            // 
            // Use
            // 
            Use.Location = new Point(3, 455);
            Use.Name = "Use";
            Use.Size = new Size(94, 29);
            Use.TabIndex = 0;
            Use.Text = "去使用";
            Use.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(700, 502);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "待付款";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(700, 502);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "已使用";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(Refund1);
            tabPage4.Controls.Add(Use1);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(700, 502);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "未使用";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // Refund1
            // 
            Refund1.Location = new Point(133, 277);
            Refund1.Name = "Refund1";
            Refund1.Size = new Size(94, 29);
            Refund1.TabIndex = 1;
            Refund1.Text = "去退款";
            Refund1.UseVisualStyleBackColor = true;
            // 
            // Use1
            // 
            Use1.Location = new Point(6, 277);
            Use1.Name = "Use1";
            Use1.RightToLeft = RightToLeft.No;
            Use1.Size = new Size(94, 29);
            Use1.TabIndex = 0;
            Use1.Text = "去使用";
            Use1.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(700, 502);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "已退款";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(6, 16);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(623, 45);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 23);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // MyOrderForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 559);
            Controls.Add(tabControl1);
            Name = "MyOrderForm";
            Text = "订单管理";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private Button Refund;
        private Button Use;
        private Button Refund1;
        private Button Use1;
        private GroupBox groupBox1;
        private Label label1;
    }
}