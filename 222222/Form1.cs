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
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CommonTicket2;user id=sa;password=Aa123456;TrustServerCertificate=true");
        private string? theRowExhibition_name;

        public Form1()
        {
            InitializeComponent();
            using (var db = new TestDbContext())
            {
                var exhibitions = db.Exhibition.ToList();
                foreach (var exhibition in exhibitions)
                {
                    Type.Items.Add(exhibition.name);
                }

                //string sqExhibition = "SELECT * FROM [Exhibition]";
                //SqlDataAdapter sda = new SqlDataAdapter(sqExhibition, conn);
                //DataSet sqExhibitionDataSet = new DataSet();
                //sda.Fill(sqExhibitionDataSet);
                //for (int i = 0; i < sqExhibitionDataSet.Tables[0].Rows.Count; i++)
                //{
                //    var theRowExhibition_name = sqExhibitionDataSet.Tables[0].Rows[i]["name"];
                //    Type.Items.Add(theRowExhibition_name);
                //}

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
            //    using (var context = new MyDbContext())
            //    {
            //        string state = State.Text;
            //        string type = Type.Text;
            //        DateTime? selectedDate = checkBox1.Checked ? (DateTime?)DateTime.Parse(dateTimePicker.Text) : null;

            //        var query = context.Orders
            //            .Include(order => order.Tickets)
            //                .ThenInclude(ticket => ticket.UserInfo)
            //                .ThenInclude(userinfo => userinfo.Appointment)
            //            .SelectMany(order => order.Tickets)
            //            .Where(ticket =>
            //                (state == "全部" || ticket.Status == (ticket.Status == "3" ? "已使用" : ticket.Status == "1" ? "未使用" : ticket.Status)  ) &&
            //                (type == "全部" || ticket.Appointment.StockName == type) &&
            //                (!checkBox1.Checked || selectedDate == null || ticket.StartTime.Date == selectedDate.Value.Date)
            //            ) .Select(ticket => new
            //            {
            //                UserInfoName = ticket.UserInfo.Name,
            //                UserInfoPhoneNumber = ticket.UserInfo.PhoneNumber,
            //                UserInfoIdCard = ticket.UserInfo.IdCard,
            //                TicketStartTime = ticket.StartTime,
            //                TicketEndTime = ticket.EndTime,
            //                TicketCreateTime = ticket.CreateTime,
            //                TicketStatus = ticket.Status == "3" ? "已使用" : ticket.Status == "1" ? "未使用" : ticket.Status,
            //                AppointmentStockName = ticket.Appointment.StockName
            //            })  .ToList();

            //        dataGridView1.Rows.Clear();
            //        foreach (var item in query)
            //        {
            //            int rowIndex = dataGridView1.Rows.Add();
            //            dataGridView1.Rows[rowIndex].Cells[0].Value = item.UserInfoName;
            //            dataGridView1.Rows[rowIndex].Cells[1].Value = item.UserInfoPhoneNumber;
            //            dataGridView1.Rows[rowIndex].Cells[2].Value = item.UserInfoIdCard;
            //            dataGridView1.Rows[rowIndex].Cells[3].Value = item.TicketStartTime;
            //            dataGridView1.Rows[rowIndex].Cells[4].Value = item.TicketEndTime;
            //            dataGridView1.Rows[rowIndex].Cells[5].Value = item.TicketCreateTime;
            //            dataGridView1.Rows[rowIndex].Cells[6].Value = item.TicketStatus;
            //            dataGridView1.Rows[rowIndex].Cells[7].Value = item.AppointmentStockName;
            //        }
            //    }
            //}


            string name = textBox.Text.Trim();
            DataTable dt = (DataTable)dataGridView1.DataSource;
            // string Type = this.textBox.Text;
            string sqlOrder = "select * from [Order] ";
            string queryAppointment = "select * from [Appointment] where id=";
            string queryTicket = "select * from [Ticket] where objectId = ";
            string sqlTicket = "select * from [Ticket] where startTime= ";
            string queryUserInfo = "select * from [UserInfo] where id = ";
            string sqlAppointment = "select * from [Appointment] ";
            string queryExhibition = "select * from [Exhibition] where name = ";
            dataGridView1.Rows.Clear();
            DataSet orders = Query(sqlOrder);
            for (int i = 0; i < orders.Tables[0].Rows.Count; i++)
            {
                var theRowOrder_trade_no = orders.Tables[0].Rows[i]["trade_no"];

                DataSet tickets = Query(queryTicket + theRowOrder_trade_no);

                for (int j = 0; j < tickets.Tables[0].Rows.Count; j++)
                {

                    var theRow_UserId = tickets.Tables[0].Rows[j]["TUserId"];

                    DataSet userInfos = Query(queryUserInfo + theRow_UserId);


                    var theRowTicket_stauts = tickets.Tables[0].Rows[j]["stauts"].ToString();
                    if (theRowTicket_stauts == "3")
                    {
                        theRowTicket_stauts = "已使用";
                    }
                    if (theRowTicket_stauts == "1")
                    {
                        theRowTicket_stauts = "未使用";
                    }
                    if (State.Text != theRowTicket_stauts && State.Text != "全部")
                    {
                        continue;
                    }

                    var theRowOrder_objectId = "'" + orders.Tables[0].Rows[i]["objectId"] + "'";
                    DataSet appointments = Query(queryAppointment + theRowOrder_objectId);

                    var theRowAppointment_stockname = appointments.Tables[0].Rows[0]["stockname"].ToString();
                    var theRowTicket_startTime = tickets.Tables[0].Rows[j]["startTime"].ToString();

                    if (Type.Text != theRowAppointment_stockname && Type.Text != "全部")
                    {
                        continue;
                    }
                    var DateTimeText = DateTime.Parse(dateTimePicker.Text);
                    if (DateTimeText.ToString() != theRowTicket_startTime && checkBox1.Checked)
                    {
                        continue;
                    }


                    int Addrow = NewRow();

                    var theRowUserInfo_name = userInfos.Tables[0].Rows[0]["name"].ToString();
                    var theRowUserInfo_phoneNumber = userInfos.Tables[0].Rows[0]["phoneNumber"].ToString();
                    var theRowUserInfo_idCard = userInfos.Tables[0].Rows[0]["idCard"].ToString();
                    NewCol(Addrow, 0, theRowUserInfo_name);
                    NewCol(Addrow, 1, theRowUserInfo_phoneNumber);
                    NewCol(Addrow, 2, theRowUserInfo_idCard);



                    var theRowTicket_endTime = tickets.Tables[0].Rows[j]["endTime"].ToString();
                    var theRowTicket_createTime = tickets.Tables[0].Rows[j]["createTime"].ToString();

                    NewCol(Addrow, 3, theRowTicket_startTime);
                    NewCol(Addrow, 4, theRowTicket_endTime);
                    NewCol(Addrow, 5, theRowTicket_createTime);
                    NewCol(Addrow, 6, theRowTicket_stauts);

                    theRowAppointment_stockname = appointments.Tables[0].Rows[0]["stockName"].ToString();
                    NewCol(Addrow, 7, theRowAppointment_stockname);
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
            int j = dataGridView1.Rows.Add(row);//添加新的一行
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


