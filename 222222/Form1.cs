using _222222;
using Furion.DatabaseAccessor;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.Drawing.Text;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Online1
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CommonTicket1;user id=sa;password=Aa123456;TrustServerCertificate=true");
        private string? theRowExhibition_name;
        public Form1()
        {
            InitializeComponent();
            using (var db = new MyDbContext())
            {
                var exhibitions = db.Exhibitions.ToList();
                foreach (var exhibition in exhibitions)
                {
                    Type.Items.Add(exhibition.name);
                }
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private DataSet Query(string sql) {
            var sda = new SqlDataAdapter(sql, conn);
            DataSet queryTableDataSet = new DataSet();

            sda.Fill(queryTableDataSet);
            return queryTableDataSet;
        }
        private void Type_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            string selectedDateTime = dateTimePicker.Value.Date.ToString();
        }
        private void State_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
        }
        private void Search_Click(object sender, EventArgs e)
        {    
                using (var context = new MyDbContext())
                {
                    string state = State.Text;
                    string type = Type.Text;
                    DateTime? selectedDate = checkBox1.Checked ? (DateTime?)DateTime.Parse(dateTimePicker.Text) : null;

                    var query = context.Orders
                        .Include(order => order.Tickets)
                        .ThenInclude(ticket => ticket.UserInfo)
                
                        .SelectMany(order => order.Tickets)
                        .Where(ticket =>
                            (state == "全部" || (ticket.Status == "3" && state == "已使用") || (ticket.Status == "1" && state == "未使用") || ticket.Status == state) &&
                            (type == "全部" || ticket.Appointment.StockName == type) &&
                            (!checkBox1.Checked || (selectedDate != null && ticket.StartTime.Date == selectedDate.Value.Date))
                        ).Select(ticket => new
                        {
                            UserInfoName = ticket.UserInfo.Name,
                            UserInfoPhoneNumber = ticket.UserInfo.PhoneNumber,
                            UserInfoIdCard = ticket.UserInfo.IdCard,
                            TicketStartTime = ticket.StartTime,
                            TicketEndTime = ticket.EndTime,
                            TicketCreateTime = ticket.CreateTime,
                            TicketStatus = ticket.Status == "3" ? "已使用" : ticket.Status == "1" ? "未使用" : ticket.Status,
                            AppointmentStockName = ticket.Appointment.StockName
                        }).ToList();
                    dataGridView1.Rows.Clear();
                foreach (var item in query)
                {
                    int Addrow = dataGridView1.Rows.Add();
                    dataGridView1.Rows[Addrow].Cells[姓名.Index].Value = item.UserInfoName;
                    dataGridView1.Rows[Addrow].Cells[电话.Index].Value = item.UserInfoPhoneNumber;
                    dataGridView1.Rows[Addrow].Cells[身份证.Index].Value = item.UserInfoIdCard;
                    dataGridView1.Rows[Addrow].Cells[开始时间.Index].Value = item.TicketStartTime;
                    dataGridView1.Rows[Addrow].Cells[结束时间.Index].Value = item.TicketEndTime;
                    dataGridView1.Rows[Addrow].Cells[预约日期.Index].Value = item.TicketCreateTime;
                    dataGridView1.Rows[Addrow].Cells[状态.Index].Value = item.TicketStatus;
                    dataGridView1.Rows[Addrow].Cells[Column1.Index].Value = item.AppointmentStockName;
                }
            }

        }
            /// <summary>
            /// 在相应的列当中添加一个数据
            /// </summary>
            /// <param name="col">列</param>
            /// <param name="value">值</param>
            ///  <param name="row">行</param>

            private void NewCol(int row, int col, string value)
        {
            dataGridView1.Rows[row].Cells[col].Value = value;
        }
        public int NewRow()
        {
            DataGridViewRow row = new DataGridViewRow();
            int j = dataGridView1.Rows.Add(row);
            return j;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}


