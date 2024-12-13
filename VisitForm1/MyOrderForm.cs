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
        private List<Label> labels = new List<Label>();
        private List<GroupBox> groups = new List<GroupBox>();

       

        public MyOrderForm(Guid exhibitionId):this()
        {
            _exhibitionId = exhibitionId;
            LoadAppointments();
        }
      
        private void LoadAppointments()
        {
            tabPage1.Controls.Clear();
            using (var db = new MyDbContext())
            {
                var orders = db.Orders.Include(o => o.Appointment).AsQueryable() .Where(a => a.AppointmentId == _exhibitionId.ToString()) .ToList();
                int maxOrdersToLoad = 5;
              
                for (int b = 0; b < orders.Count; b++)
                {
                    GroupBox groupBox = new GroupBox();
                    Size = new Size(627, 55);
                    Location = new Point(6, b * 77 + 17);
                    Text = $"订单 {orders[b].Id}";
                    Label label = new Label();
                    label.AutoSize = true;
                    label.Location = new Point(0, 23);
                    label.Text = string.Format("订单号{0} .状态{1},景区名称{2},票数{3},￥{4:F2}", orders[b].Id,orders[b].Status, orders[b].Appointment?.StockName,   orders[b].Amount,orders[b].PayedAmount);
                    groupBox.Controls.Add(label);
                    tabPage1.Controls.Add(groupBox);               
                }

            }
        }
        public MyOrderForm()
        {
            InitializeComponent();
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {               

        }
    }
}
