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
        private Guid _exhibitionId;
        private TabControl tabControl;
        private List<GroupBox> groups = new List<GroupBox>();
        private Dictionary<TabPage, OrderPageState> tabPageStates = new Dictionary<TabPage, OrderPageState>();
        private Action<Order> onRefundSuccess;

        public EventHandler TabControl1_Selected { get; }

        public MyOrderForm(Guid exhibitionId) : this()
        {
            _exhibitionId = exhibitionId;

            if (LogInInfo.id != 0) 
            {
                LoadTabPageOrders(tabPage1);
                LoadTabPageOrders(tabPage2);
                LoadTabPageOrders(tabPage3);
                LoadTabPageOrders(tabPage4);
                LoadTabPageOrders(tabPage5);
            }
            else
            {
                MessageBox.Show("请先登录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void InitializePagingControls()
        {
            AddPagingControls(tabPage1);
            AddPagingControls(tabPage2);
            AddPagingControls(tabPage3);
            AddPagingControls(tabPage4);
            AddPagingControls(tabPage5);
        }

        private void ShowUseOrderForm(Order order)
        {
            UseOrderForm useOrderForm = new UseOrderForm(order, order => LoadOrders(tabPage5, o => o.Status == OrderStatus.已退款));
            useOrderForm.ShowDialog();
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
            if (!tabPageStates.ContainsKey(tabPage))
            {
                AddPagingControls(tabPage);
            }
            var state = tabPageStates[tabPage];
            Func<Order, bool> shouldDisplayOrder = GetFilterForTabPage(tabPage);
            LoadOrders(tabPage, shouldDisplayOrder);
            UpdatePageNumberLabel(tabPage);

            //Func<Order, bool> shouldDisplayOrder = order => true;
            //LoadOrders(tabPage, shouldDisplayOrder);
            //state.PageNumberLabel.Text = $"{state.CurrentPage} / {state.TotalPages}";


        }//分页?
        private Func<Order, bool> GetFilterForTabPage(TabPage tabPage)
        {
            switch (tabPage.Name)
            {
                case "tabPage1":
                    return order => true; 
                case "tabPage2":
                    return order => order.Status == OrderStatus.未付款;
                case "tabPage3":
                    return order => order.UseStatus != TicketStatus.已使用 && order.Status == OrderStatus.已退款;
                case "tabPage4":
                    return order => order.Status != OrderStatus.未付款;
                //case "tabPage4":
                //    return order => order.UseStatus != TicketStatus.未使用 && order.Status == OrderStatus.已退款;
                case "tabPage5":
                    return order => order.Status == OrderStatus.已退款;
                default:
                    return order => false; 
            }
        }
        private void LoadOrders(TabPage tabPage, Func<Order, bool> shouldDisplayOrder = null)
        {
            if (!tabPageStates.ContainsKey(tabPage))
            {
                MessageBox.Show("TabPage not found in tabPageStates", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var state = tabPageStates[tabPage];
            var groupBoxesToRemove = tabPage.Controls.OfType<GroupBox>()
                .Where(gb => gb.Tag?.ToString() == tabPage.Name).ToList();
            groupBoxesToRemove.ForEach(gb =>
            {
                tabPage.Controls.Remove(gb);
                gb.Dispose();
            });
            try
            {
                using (var db = new MyDbContext())
                {
                    var orders = db.Orders
                     .Include(o => o.Appointment)
                     .Where(o => o.UserId == LogInInfo.id) 
                     .OrderBy(o => o.Id)
                     .ToList();

                    if (orders.Count == 0)
                    {
                        MessageBox.Show("没有找到相关订单", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (shouldDisplayOrder != null)
                    {
                        orders = orders.Where(order => shouldDisplayOrder(order)).ToList();
                    }
                    if (orders.Count == 0)
                    {
                        return;
                    }
                    int maxOrdersPerPage = 2;
                    state.TotalPages = (int)Math.Ceiling(orders.Count / (double)maxOrdersPerPage);
                    state.CurrentPage = Math.Min(state.CurrentPage, state.TotalPages);
                    int startIndex = (state.CurrentPage - 1) * maxOrdersPerPage;
                    int endIndex = Math.Min(startIndex + maxOrdersPerPage, orders.Count);
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        var order = orders[i];
                        var groupBox = CreateGroupBoxForOrder(order, tabPage);
                        groupBox.Tag = tabPage.Name;
                        groupBox.Location = new Point(6, 6 + (i - startIndex) * (groupBox.Height + 30));
                        groupBox.Visible = true;
                        tabPage.Controls.Add(groupBox);
                    }

                    state.PageNumberLabel.Text = $"{state.CurrentPage} / {state.TotalPages}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载订单时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private GroupBox CreateGroupBoxForOrder(Order order, TabPage tabPage)
        {
            GroupBox groupBox = new GroupBox
            {
                Size = new Size(627, 180),
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
            if (order.Status != OrderStatus.已退款)
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
                refundButton.Click += (sender, e) => RefundButtonClick(order, tabPage);
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
            LoadOrders(tabPage, order => order.Status != OrderStatus.已退款);
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
        private void UseButtonClick(Order order)
        {
            UseOrderForm useOrderForm = new UseOrderForm(order, onRefundSuccess);
            useOrderForm.Show();
        }
        private void RefundButtonClick(Order order, TabPage tabPage)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var dbOrder = db.Orders.Include(o => o.Appointment).FirstOrDefault(o => o.Id == order.Id);
                    if (dbOrder != null)
                    {
                        dbOrder.Status = OrderStatus.已退款;
                      
                        db.SaveChanges();
                       // LoadOrders(tabPage5, order => order.Status == OrderStatus.已退款);
                        UpdateOrderDisplayInTabPage(tabPage, order, hideButtons: true);

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
        private void UpdateOrderDisplayInTabPage(TabPage tabPage, Order order, bool hideButtons)
        {
            foreach (var groupBox in tabPage.Controls.OfType<GroupBox>())
            {
                if (groupBox.Tag?.ToString() == tabPage.Name)               
                {
                    Label orderLabel = null;
                    foreach (var control in groupBox.Controls.OfType<Label>())
                    {
                        if (control.Text.Contains($"订单号: {order.Id}"))
                        {
                            orderLabel = control;
                            break;
                        }
                    }
                    if (orderLabel != null)
                    {
                        if (hideButtons)
                        {
                            var buttons = groupBox.Controls.OfType<System.Windows.Forms.Button>().ToList();
                            if (hideButtons && buttons.Any()) 
                            {
                                buttons.ForEach(b => b.Visible = false);
                            }

                        } 
                    }
                }
            }
        }
     
        private void tabPage4_Click(object sender, EventArgs e)
        {
        }
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            LoadTabPageOrders(e.TabPage);
            //if (e.TabPage == tabPage2)
            //{
            //    Func<Order, bool> shouldDisplayOrder = order => order.Status == OrderStatus.未付款;
            //    LoadOrders(tabPage4, shouldDisplayOrder);
            //}
            // else if (e.TabPage == tabPage3)
            //{
            //    Func<Order, bool> shouldDisplayOrder = order => order.UseStatus != TicketStatus.已使用 && order.Status == OrderStatus.已退款;
            //    LoadOrders(tabPage4, shouldDisplayOrder);
            //}
            //else if (e.TabPage == tabPage4)
            //{
            //    Func<Order, bool> shouldDisplayOrder = order => order.UseStatus != TicketStatus.未使用&& order.Status == OrderStatus.已退款;
            //    LoadOrders(tabPage4, shouldDisplayOrder);
            //}
            //else if (e.TabPage == tabPage5)
            //{
            //    Func<Order, bool> shouldDisplayOrder = order => order.Status == OrderStatus.已退款;
            //    LoadOrders(tabPage5, shouldDisplayOrder);
            // }

        }
    }
    }
