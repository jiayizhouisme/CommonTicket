using _222222;
using Microsoft.EntityFrameworkCore;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VisitForm1
{
    public partial class MyOrderForm : Form
    {
        private Guid _exhibitionId;
        private TabControl tabControl;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        // private List<Label> labels = new List<Label>();
        private List<GroupBox> groups = new List<GroupBox>();
        private int _currentPage = 1;
        private int _totalPages;
        private Label lblPageNumber;
        public MyOrderForm(Guid exhibitionId) : this()
        {
            _exhibitionId = exhibitionId;
            InitializePagingControls();
            LoadAppointments();
            UpdatePageNumberLabel();
        }
        private void InitializePagingControls()
        {
            btnPrevious = new System.Windows.Forms.Button();
            btnPrevious.Text = "<";
            AutoSize = true;
            btnPrevious.Location = new Point(3, 450); 
            btnPrevious.Click += btnPrevious_Click;
             

            btnNext = new System.Windows.Forms.Button();
            btnNext.Text = ">";
            AutoSize = true;
            btnNext.Location = new Point(221,450); 
            btnNext.Click += btnNext_Click;
            

            lblPageNumber = new Label();
            lblPageNumber.AutoSize = true;
            lblPageNumber.Location = new Point(130,450);
            lblPageNumber.TextAlign = ContentAlignment.MiddleCenter;

            tabPage1.Controls.Add(btnPrevious);
            tabPage1.Controls.Add(btnNext);
            tabPage1.Controls.Add(lblPageNumber);
        }
            private void LoadAppointments()
        {
            var groupBoxesToRemove = tabPage1.Controls.OfType<GroupBox>().ToList();
            foreach (var groupBox in groupBoxesToRemove)
            {
                tabPage1.Controls.Remove(groupBox);
            }
            groups.Clear();
            using (var db = new MyDbContext())
            {
                var b0 = db.Orders.Include(o => o.Appointment).Where(o => o.Appointment.ObjectId == _exhibitionId);
                var orders = db.Orders.Include(o => o.Appointment).Where(o => o.Appointment.ObjectId == _exhibitionId).ToList();
                int maxOrdersPerPage = 2;
                _totalPages = (int)Math.Ceiling(orders.Count / (double)maxOrdersPerPage);
                int startIndex = (_currentPage - 1) * maxOrdersPerPage;
                int endIndex = Math.Min(startIndex + maxOrdersPerPage, orders.Count);
                int verticalSpacing = 30;
                for (int b = startIndex; b < endIndex; b++)
                {
                    var order = orders[b];
                    GroupBox groupBox = new GroupBox();
                  //  groupBox.Size = new Size(627, 140);
                    groupBox.Size = new Size(627, 180);
                    int yPosition = 17 + (b - startIndex) * (groupBox.Height + verticalSpacing);
                    groupBox.Location = new Point(6, yPosition);
                    // groupBox.Location = new Point(6, b * 77 + 17);
                    //groupBox.Text = $"订单 {orders[b].Id}";
                    groupBox.Text = "";

                    Label orderIdLabel = new Label();
                    orderIdLabel.AutoSize = true;
                    orderIdLabel.Location = new Point(6, 20);
                    orderIdLabel.Text = $"订单号: {order.Id} 状态: {order.Status}";

                    Label stockNameLabel = new Label();
                    stockNameLabel.AutoSize = true;
                    stockNameLabel.Location = new Point(6, 50);
                    stockNameLabel.Text = $"门票名称 {order.Appointment?.StockName}";

                    Label amountLabel = new Label();
                    amountLabel.AutoSize = true;
                    amountLabel.Location = new Point(6, 80);
                    amountLabel.Text = $"票数: {order.Amount}";
                   
                    Label totalPriceLabel = new Label();
                    totalPriceLabel.AutoSize = true;
                    totalPriceLabel.Location = new Point(6, 110);
                    totalPriceLabel.Text = $"总价: ￥{order.PayedAmount:F2}";

                    System.Windows.Forms.Button useButton = new System.Windows.Forms.Button
                    {               
                        Text = "去使用",
                        Location = new Point(6, 140), 
                        AutoSize = true
                    };
                    useButton.Click += (sender, e) => HandleUseButtonClick(order);
                    System.Windows.Forms.Button refundButton = new System.Windows.Forms.Button
                    {
                        Text = "去退款",
                        Location = new Point(useButton.Right + 10, 140),
                        AutoSize = true
                    };
                    refundButton.Click += (sender, e) => HandleRefundButtonClick(order);

                    groupBox.Controls.Add(orderIdLabel);
                    groupBox.Controls.Add(stockNameLabel);
                    groupBox.Controls.Add(amountLabel);
                    groupBox.Controls.Add(totalPriceLabel);
                    groupBox.Controls.Add(useButton);
                    groupBox.Controls.Add(refundButton);

                    tabPage1.Controls.Add(groupBox);
                    groups.Add(groupBox);//
                }
                if (orders.Count == 0)
                {
                    MessageBox.Show("没有找到相关订单", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                lblPageNumber.Text = $"{_currentPage} / {_totalPages}";
            }
        }
        public MyOrderForm()
        {
        InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadAppointments();
                UpdatePageNumberLabel();
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadAppointments();
                UpdatePageNumberLabel();
            }
        }
        private void UpdatePageNumberLabel()
        {
            lblPageNumber.Text = $"{_currentPage} / {_totalPages}";
        }
        private void HandleUseButtonClick(Order order)
        {
          
        }

        private void HandleRefundButtonClick(Order order)
        {
                                                                         
        }
    }
}                                                             
