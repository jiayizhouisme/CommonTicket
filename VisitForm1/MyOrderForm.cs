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
        private const int RefundedStatus = 3;
        private Guid _exhibitionId;
        private TabControl tabControl;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private List<GroupBox> groups = new List<GroupBox>();
        private int _currentPage = 1;
        private int _totalPages;
        private Label lblPageNumber;

        public MyOrderForm(Guid exhibitionId) : this()
        {
            
            _exhibitionId = exhibitionId;
            InitializePagingControls();
            LoadAppointments();
            LoadUnusedAppointments();
            UpdatePageNumberLabel(); 
        }    
        private void InitializePagingControls()
        {
            btnPrevious = new System.Windows.Forms.Button();
            btnPrevious.Text = "<";
            btnPrevious.AutoSize = false;
            btnPrevious.Location = new Point(3, 450);
            btnPrevious.Click += btnPrevious_Click;

            btnNext = new System.Windows.Forms.Button();
            btnNext.Text = ">";
            btnNext.AutoSize = false;
            btnNext.Location = new Point(221, 450);
            btnNext.Click += btnNext_Click;

            lblPageNumber = new Label();
            lblPageNumber.AutoSize = true;
            lblPageNumber.Location = new Point(130, 450);
            lblPageNumber.TextAlign = ContentAlignment.MiddleCenter;

            tabPage1.Controls.Add(btnPrevious);
            tabPage1.Controls.Add(btnNext);
            tabPage1.Controls.Add(lblPageNumber);

            tabPage4.Controls.Add(btnPrevious);
            tabPage4.Controls.Add(btnNext);
            tabPage4.Controls.Add(lblPageNumber);
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
                var orders = db.Orders.Include(o => o.Appointment)
                                      .Where(o => o.Appointment.ObjectId == _exhibitionId && o.Status != RefundedStatus)
                                      .ToList();

                int maxOrdersPerPage = 2;
                _totalPages = (int)Math.Ceiling(orders.Count / (double)maxOrdersPerPage);
                _currentPage = Math.Min(_currentPage, _totalPages);
                int startIndex = (_currentPage - 1) * maxOrdersPerPage;
                int endIndex = Math.Min(startIndex + maxOrdersPerPage, orders.Count);

                int verticalSpacing = 30;
                for (int b = startIndex; b < endIndex; b++)
                {
                    var order = orders[b];
                    GroupBox groupBox = new GroupBox();
                    groupBox.Size = new Size(627, 180);
                    int yPosition = 17 + (b - startIndex) * (groupBox.Height + verticalSpacing);
                    groupBox.Location = new Point(6, yPosition);
                    groupBox.Text = "";


                    Label orderIdLabel = new Label
                    {
                        AutoSize = true,
                        Location = new Point(6, 20),
                        Text = $"订单号: {order.Id} 状态: {order.Status}"
                    };
                    Label stockNameLabel = new Label
                    {
                        AutoSize = true,
                        Location = new Point(6, 50),
                        Text = $"门票名称 {order.Appointment?.StockName}"
                    };
                    Label amountLabel = new Label
                    {
                        AutoSize = true,
                        Location = new Point(6, 80),
                        Text = $"票数: {order.Amount}"
                    };
                    Label totalPriceLabel = new Label
                    {
                        AutoSize = true,
                        Location = new Point(6, 110),
                        Text = $"总价: ￥{order.PayedAmount:F2}"
                    };

                    if (order.Status != RefundedStatus)
                    {
                        System.Windows.Forms.Button useButton = new System.Windows.Forms.Button
                        {
                            Text = "去使用",
                            Location = new Point(6, 140),
                            AutoSize = true
                        };
                        useButton.Click += (sender, e) => UseButtonClick(order);

                        System.Windows.Forms.Button refundButton = new System.Windows.Forms.Button
                        {
                            Text = "去退票",
                            Location = new Point(useButton.Right + 10, 140),
                            AutoSize = true
                        };
                        refundButton.Click += (sender, e) => RefundButtonClick(order);
                        groupBox.Controls.Add(useButton);
                        groupBox.Controls.Add(refundButton);
                    }
                    groupBox.Controls.Add(orderIdLabel);
                    groupBox.Controls.Add(stockNameLabel);
                    groupBox.Controls.Add(amountLabel);
                    groupBox.Controls.Add(totalPriceLabel);

                    tabPage1.Controls.Add(groupBox);
                    groups.Add(groupBox);
                }
               
                if (orders.Count == 0)
                {
                    MessageBox.Show("没有找到相关订单", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                lblPageNumber.Text = $"{_currentPage} / {_totalPages}";
            }      
    }    
        private void LoadUnusedAppointments()//未使用
        {
            var groupBoxesToRemove = tabPage4.Controls.OfType<GroupBox>().ToList();
            foreach (var groupBox in groupBoxesToRemove)
            {
                tabPage4.Controls.Remove(groupBox);
            }
            groups.Clear(); 
            using (var db = new MyDbContext())
            {
                var orders = db.Orders.Include(o => o.Appointment)
                                      .Where(o => o.Appointment.ObjectId == _exhibitionId && o.Status != RefundedStatus)
                                      .ToList();

                int maxOrdersPerPage = 2;
                _totalPages = (int)Math.Ceiling(orders.Count / (double)maxOrdersPerPage);
                int startIndex = (_currentPage - 1) * maxOrdersPerPage;
                int endIndex = Math.Min(startIndex + maxOrdersPerPage, orders.Count);

                int verticalSpacing = 30;
                for (int b = startIndex; b < endIndex; b++)
                {
                    var order = orders[b];
                    GroupBox groupBox = new GroupBox();
                    groupBox.Size = new Size(627, 180);
                    int yPosition = 17 + (b - startIndex) * (groupBox.Height + verticalSpacing);
                    groupBox.Location = new Point(6, yPosition);
                    groupBox.Text = "";

             
                    Label orderIdLabel = new Label
                    {
                        AutoSize = true,
                        Location = new Point(6, 20),
                        Text = $"订单号: {order.Id} 状态: {order.Status}"
                    };
                    Label stockNameLabel = new Label
                    {
                        AutoSize = true,
                        Location = new Point(6, 50),
                        Text = $"门票名称 {order.Appointment?.StockName}"
                    };
                    Label amountLabel = new Label
                    {
                        AutoSize = true,
                        Location = new Point(6, 80),
                        Text = $"票数: {order.Amount}"
                    };
                    Label totalPriceLabel = new Label
                    {
                        AutoSize = true,
                        Location = new Point(6, 110),
                        Text = $"总价: ￥{order.PayedAmount:F2}"
                    };

                    if (order.Status != RefundedStatus)
                    {
                        System.Windows.Forms.Button useButton = new System.Windows.Forms.Button
                        {
                            Text = "去使用",
                            Location = new Point(6, 140),
                            AutoSize = true
                        };
                        useButton.Click += (sender, e) => UseButtonClick(order);

                        System.Windows.Forms.Button refundButton = new System.Windows.Forms.Button
                        {
                            Text = "去退票",
                            Location = new Point(useButton.Right + 10, 140),
                            AutoSize = true
                        };
                        refundButton.Click += (sender, e) => RefundButtonClick(order);

                        groupBox.Controls.Add(useButton);
                        groupBox.Controls.Add(refundButton);
                    }

                    groupBox.Controls.Add(orderIdLabel);
                    groupBox.Controls.Add(stockNameLabel);
                    groupBox.Controls.Add(amountLabel);
                    groupBox.Controls.Add(totalPriceLabel);

                    tabPage4.Controls.Add(groupBox);
                    groups.Add(groupBox);
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
                LoadUnusedAppointments();
                UpdatePageNumberLabel();
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadAppointments();
                LoadUnusedAppointments();
                UpdatePageNumberLabel();
            }
        }
        private void UpdatePageNumberLabel()
        {
            lblPageNumber.Text = $"{_currentPage} / {_totalPages}";
        }
        private void UseButtonClick(Order order)
        {
            UseOrderForm useOrderForm = new UseOrderForm(order);
            useOrderForm.Show();
        }
        private void RefundButtonClick(Order order)//去退票
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var dbOrder = db.Orders.Include(o => o.Appointment).FirstOrDefault(o => o.Id == order.Id);
                    if (dbOrder != null)
                    {
                        dbOrder.Status = RefundedStatus;
                        db.SaveChanges();
                        GroupBox groupBoxToRemove = null;
                        foreach (var groupBox in groups)
                        {
                            foreach (var control in groupBox.Controls.OfType<Label>())
                            {
                                if (control.Text.Contains($"订单号: {order.Id}"))
                                {
                                    groupBoxToRemove = groupBox;
                                    break;
                                }
                            }

                            if (groupBoxToRemove != null)
                            {
                                groupBox.Controls.OfType<System.Windows.Forms.Button>().ToList().ForEach(btn => groupBox.Controls.Remove(btn));
                                //tabPage1.Controls.Remove(groupBoxToRemove);
                                //groups.Remove(groupBoxToRemove);
                                //groupBoxToRemove.Dispose();
                                break;
                            }
                        }
                        if (groupBoxToRemove != null)
                        {
                            tabPage4.Controls.Remove(groupBoxToRemove);
                            groups.Remove(groupBoxToRemove);
                            groupBoxToRemove.Dispose();
                        }

                        LoadAppointments();
                        LoadUnusedAppointments();

                        MessageBox.Show("退票成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("订单未找到，无法退票。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"退票失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }         
        private void tabPage4_Click(object sender, EventArgs e)
        {
            LoadUnusedAppointments();
        }
        
    }
}