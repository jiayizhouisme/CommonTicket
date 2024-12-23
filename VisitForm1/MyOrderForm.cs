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
        private class OrderPageState
        {
            public int CurrentPage { get; set; }
            public int TotalPages { get; set; }
            public Label PageNumberLabel { get; set; }
        }
        private const int RefundedStatus = 3;
        private Guid _exhibitionId;
        private TabControl tabControl;
        //private System.Windows.Forms.Button btnPrevious;
        //private System.Windows.Forms.Button btnNext;
        private List<GroupBox> groups = new List<GroupBox>();
        //private int _currentPage ;
        //private int _totalPages;
        //private Label lblPageNumber;
        private Dictionary<TabPage, OrderPageState> tabPageStates = new Dictionary<TabPage, OrderPageState>();


        public MyOrderForm(Guid exhibitionId) : this()
        {          
            _exhibitionId = exhibitionId;
            InitializePagingControls();
            //LoadAppointments();
            //LoadUnusedAppointments();
            //UpdatePageNumberLabel(); 
            LoadTabPageOrders(tabPage1);
            LoadTabPageOrders(tabPage4);
        }
        private void InitializePagingControls()
        {
            AddPagingControls(tabPage1);
            AddPagingControls(tabPage4);
          
        }
        private void AddPagingControls(TabPage tabPage)
        {
            var btnPrevious = new System.Windows.Forms.Button { Text = "<", AutoSize = false, Location = new Point(3, 450) };
            var btnNext = new System.Windows.Forms.Button { Text = ">", AutoSize = false, Location = new Point(221, 450) };
            var lblPageNumber = new Label { AutoSize = true, Location = new Point(130, 450), TextAlign = ContentAlignment.MiddleCenter };

            btnPrevious.Click += (sender, e) => btnPrevious_Click(sender, e, tabPage);
            btnNext.Click += (sender, e) => btnNext_Click(sender, e, tabPage);

            tabPage.Controls.Add(btnPrevious);
            tabPage.Controls.Add(btnNext);
            tabPage.Controls.Add(lblPageNumber);

            tabPageStates[tabPage] = new OrderPageState
            {
                CurrentPage = 1,
                PageNumberLabel = lblPageNumber
            };
        }
        private void LoadTabPageOrders(TabPage tabPage)
        {
            var state = tabPageStates[tabPage];
            Func<Order, bool> shouldDisplayOrder = order => true; 
            LoadOrders(tabPage, shouldDisplayOrder);
            state.PageNumberLabel.Text = $"{state.CurrentPage} / {state.TotalPages}";
        }     
        private void LoadOrders(TabPage tabPage, Func<Order, bool> shouldDisplayOrder)
        {
            var state = tabPageStates[tabPage];
            var groupBoxesToRemove = tabPage.Controls.OfType<GroupBox>()
                .Where(gb => gb.Tag?.ToString() == tabPage.Name).ToList();
            groupBoxesToRemove.ForEach(gb => tabPage.Controls.Remove(gb));
            groupBoxesToRemove.ForEach(gb => gb.Dispose());
            foreach (var groupBox in groupBoxesToRemove)
            {
                tabPage.Controls.Remove(groupBox);
            }

            using (var db = new MyDbContext())
            {
                var orders = db.Orders.Include(o => o.Appointment)
                    .Where(o => o.Appointment.ObjectId == _exhibitionId && o.Status != RefundedStatus)
                    .ToList();

                if (shouldDisplayOrder != null)
                {
                    orders = orders.Where(shouldDisplayOrder).ToList();
                }

                int maxOrdersPerPage = 2;
                state.TotalPages = (int)Math.Ceiling(orders.Count / (double)maxOrdersPerPage);
                state.CurrentPage = Math.Min(state.CurrentPage, state.TotalPages);

                int startIndex = (state.CurrentPage - 1) * maxOrdersPerPage;
                int endIndex = Math.Min(startIndex + maxOrdersPerPage, orders.Count);
                int yPosition = 6;//
                for (int i = startIndex; i < endIndex; i++)
                {
                    var order = orders[i];
                    var groupBox = CreateGroupBoxForOrder(order);
                    groupBox.Tag = tabPage.Name;
                    groupBox.Location = new Point(6, yPosition);//
                    tabPage.Controls.Add(groupBox);
                    yPosition += groupBox.Height + 30;//
                }
                state.PageNumberLabel.Text = $"{state.CurrentPage} / {state.TotalPages}";             
                if (orders.Count == 0)
                {
                    MessageBox.Show("没有找到相关订单", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private GroupBox CreateGroupBoxForOrder(Order order)
        {
            GroupBox groupBox = new GroupBox
            {          
                Size = new Size(627, 180),
              //  Location = new Point(6, 17 + groups.Count * (180 + 30)), 
                Text = ""
            };
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
            return groupBox;
        }
        private void LoadAllOrders(TabPage tabPage)
        {
            LoadOrders(tabPage, order => true);
        }
        private void LoadUnusedAppointments(TabPage tabPage)
        {
            LoadOrders(tabPage, order => order.Status != RefundedStatus);
        }
        public MyOrderForm()
        {
            InitializeComponent();
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
        }
      
        private void btnPrevious_Click(object sender, EventArgs e, TabPage tabPage)
        {
            var state = tabPageStates[tabPage];
            if (state.CurrentPage > 1)
            {
                state.CurrentPage--;
                LoadTabPageOrders(tabPage);
            }
        }
        private void btnNext_Click(object sender, EventArgs e, TabPage tabPage)
        {
            var state = tabPageStates[tabPage];
            if (state.CurrentPage < state.TotalPages)
            {
                state.CurrentPage++;
                LoadTabPageOrders(tabPage);
            }
        }
        private void UpdatePageNumberLabel(TabPage tabPage)
        {
            var state = tabPageStates[tabPage];
            state.PageNumberLabel.Text = $"{state.CurrentPage} / {state.TotalPages}";
        }
        //private void UpdatePageNumberLabel()
        //{
        //    lblPageNumber.Text = $"{_currentPage} / {_totalPages}";
        //}
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
                        LoadTabPageOrders(tabPage1);
                        LoadTabPageOrders(tabPage4);
                        //LoadAllOrders();
                        //LoadUnusedAppointments();              
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
           // LoadUnusedAppointments();
        }        
    }
}