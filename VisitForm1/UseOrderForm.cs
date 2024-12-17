using _222222;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisitForm1._222222.Model;

namespace VisitForm1
{
    public partial class UseOrderForm : Form
    {
        private Order _order;
        private Form qrCodeForm;
        private Label qrCodeLabel;
        private Label scanInstructions;
        //  private Guid _exhibitionId;
        private List<GroupBox> groups = new List<GroupBox>();
        public UseOrderForm(Order order) : this()
        {
            // _exhibitionId = exhibitionId;
            _order = order;
            LoadOrderDetails();
        }
        private void LoadOrderDetails()
        {
            // groups.Clear();
            // this.Controls.Clear();
            using (var db = new MyDbContext())
            {
                //var orders = db.Orders.Include(o => o.Appointment).Where(o => o.Appointment.ObjectId == _exhibitionId).ToList();
                //for (int a = 0; a < orders.Count; a++)
                //{
              //  var order = orders[a];
                GroupBox groupBox = new GroupBox();
                groupBox.Size = new Size(627, 450);
                groupBox.Location = new Point(6, 18);
                groupBox.Text = "";

                Label totalPriceLabel = new Label();
                totalPriceLabel.AutoSize = true;
                totalPriceLabel.Location = new Point(6, 20);
                totalPriceLabel.Width = 300;
                totalPriceLabel.Text = $" 状态:{_order.Status} 总价:￥{_order.PayedAmount:F2}";

                Label stockNameLabel = new Label();
                stockNameLabel.AutoSize = true;
                stockNameLabel.Location = new Point(6, 50);
                stockNameLabel.Text = $"{_order.Appointment?.StockName}";

                Label InfoLabel = new Label();
                InfoLabel.AutoSize = true;
                InfoLabel.Location = new Point(6, 80);
                InfoLabel.Text = "订单信息";

                Label orderIdLabel = new Label();
                orderIdLabel.AutoSize = true;
                orderIdLabel.Location = new Point(6, 110);
                orderIdLabel.Text = $"订单号: {_order.Id}";
                orderIdLabel.ForeColor = Color.Gray;

                Label timeLabel = new Label();
                timeLabel.AutoSize = true;
                timeLabel.Location = new Point(6, 140);
                timeLabel.Text = $"支付时间:{_order.CreateTime}";
                timeLabel.ForeColor = Color.Gray;

                Button refundButton = new Button();
                refundButton.Text = "退款";
                refundButton.AutoSize = true;
                refundButton.Location = new Point(totalPriceLabel.Right + 10, totalPriceLabel.Top); 
                refundButton.Click += RefundButton_Click;

                int qrCodeSize = 100;
                Bitmap qrCodeImage = GenerateQrCodeImage(_order.Id.ToString(), qrCodeSize * 2);
                qrCodeLabel = new Label
                {
                    Size = new Size(qrCodeSize, qrCodeSize),
                    Location = new Point(6, timeLabel.Bottom + 10), 
                    Image = qrCodeImage,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand,
                    BorderStyle = BorderStyle.FixedSingle
                };
                qrCodeLabel.Click += QrCodeLabel_Click;
              
                int estimatedScanInstructionsHeight = 20;
                scanInstructions = new Label
                {
                    AutoSize = true,
                    Location = new Point(qrCodeLabel.Right + 10, qrCodeLabel.Top + (qrCodeLabel.Height - estimatedScanInstructionsHeight) / 2),
                    Text = "请携带证件或凭证码扫码入园"
                };
                groupBox.Controls.Add(totalPriceLabel);
                groupBox.Controls.Add(stockNameLabel);
                groupBox.Controls.Add(InfoLabel);
                groupBox.Controls.Add(orderIdLabel);
                groupBox.Controls.Add(timeLabel);
                groupBox.Controls.Add(refundButton);
                groupBox.Controls.Add(qrCodeLabel);
                groupBox.Controls.Add(scanInstructions);

                this.Controls.Add(groupBox);
                groups.Add(groupBox);
            }
        }
        private Bitmap GenerateQrCodeImage(string text, int size)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            //return qrCode.GetGraphic(size / 2, Color.Black, Color.White, false);
            return qrCode.GetGraphic(size / 2);
        }
        private void QrCodeLabel_Click(object sender, EventArgs e)
        {
            ShowQrCodeFullScreen();
        }
        private void ShowQrCodeFullScreen()
        {
            if (qrCodeForm == null || qrCodeForm.IsDisposed)
            {
                qrCodeForm = new Form
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    Size = new Size(450, 350)
                };
                Label identityLabel = new Label
                {
                    Location = new Point(10, 5), 
                    Text = "身份信息:",
                    AutoSize = true
                };
                Label userLabel = new Label
                {
                    Location = new Point(10, 10),
                    Text = $"用户姓名: {_order.Name}",
                    AutoSize = true
                };           
                Label qrCodeFullLabel = new Label
                {
                    Location = new Point(10, 40),
                    Size = new Size(200, 200),
                    Image = GenerateQrCodeImage(_order.Id.ToString(), 200 * 2), 
                    TextAlign = ContentAlignment.MiddleCenter
                };
                StringBuilder ticketInfo = new StringBuilder();
                ticketInfo.AppendLine($"票数: {_order.Amount ?? 0}");   
                ticketInfo.AppendLine($"入园时间: {_order.CreateTime?.ToString()}");

                Label ticketInfoLabel = new Label
                {
                    Location = new Point(10, 250),
                    Text = ticketInfo.ToString(),
                    AutoSize = true,
                    Size = new Size(qrCodeForm.ClientSize.Width - 20, 50),
                    ForeColor = Color.Gray
                };
                qrCodeForm.Controls.Add(userLabel);
                qrCodeForm.Controls.Add(qrCodeFullLabel);
                qrCodeForm.Controls.Add(ticketInfoLabel);
            }
            qrCodeForm.ShowDialog();
        }
        private void RefundButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否确认退款吗？", "确认退款", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("退款成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public UseOrderForm()
            {
                InitializeComponent();
            }
        }
    }

