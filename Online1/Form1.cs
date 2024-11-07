using Microsoft.Data.SqlClient;
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
using System.Xml.Linq;

namespace Online1
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=192.168.51.109;Initial Catalog=CommonTicket2;user id=admin;password=Aa123456;TrustServerCertificate=true;");
        public Form1()
        {

            InitializeComponent();
            string sqExhibition = "SELECT * FROM [Exhibition]" ;
            SqlDataAdapter sda = new SqlDataAdapter(sqExhibition, conn);
            DataSet sqExhibitionDataSet = new DataSet();
         
            sda.Fill(sqExhibitionDataSet);

            for (int i = 0; i < sqExhibitionDataSet.Tables[0].Rows.Count; i++)
            {
                var theRowExhibition_name = sqExhibitionDataSet.Tables[0].Rows[i]["name"];
                Type.Items.Add(theRowExhibition_name);
                //sda = new SqlDataAdapter(sqExhibition, conn);
                //DataSet queryTicketDataSet = new DataSet();

                //sda.Fill(queryTicketDataSet);
            }

        }
        
        private void Type_SelectedIndexChanged(object sender, EventArgs e)
        {
             //if (Type.Items.Cast<object>().All(x => x.ToString() != ""))
            
        }
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            string selectedDateTime = dateTimePicker.Value.ToString("year-month-day ");
            MessageBox.Show("您选择的日期和时间是：" + selectedDateTime);
        }

        private void State_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            //if (textBox.Text == "")
            //{
            //    MessageBox.Show("请输入姓名");
            //    return;
            //}
        }
        private void Search_Click(object sender, EventArgs e)
        {
            string name = textBox.Text.Trim();
            DataTable dt = (DataTable)dataGridView1.DataSource;
            
            string Type = this.textBox.Text;

            
            string sqlOrder = "select * from [Order] ";
            string queryTicket = "select * from [Ticket] where objectId = ";
            string sqlTicket = "select * from [Ticket ";
            string queryUserInfo= "select * from [UserInfo] where id = ";
           
            
            SqlDataAdapter sda = new SqlDataAdapter(sqlOrder, conn);
            DataSet sqlOrderDataSet = new DataSet();
           dataGridView1.Rows.Clear();
            sda.Fill(sqlOrderDataSet);
            //DataRow theRow = ds.Tables[0].Rows[0];
            //DataRow theRow = ds.Tables[0].Rows[1];
            //DataRow theRow = ds.Tables[0].Rows[2];
            //DataRow theRow = ds.Tables[0].Rows[3];
            //DataRow theRow = ds.Tables[0].Rows[4];
            //DataRow theRow = ds.Tables[0].Rows[5];
            //DataRow theRow = ds.Tables[0].Rows[6];
            for (int i = 0; i < sqlOrderDataSet.Tables[0].Rows.Count; i++)
            {
                var theRowOrder_trade_no = sqlOrderDataSet.Tables[0].Rows[i]["trade_no"];

                sda = new SqlDataAdapter(queryTicket + theRowOrder_trade_no, conn);
                DataSet queryTicketDataSet = new DataSet();

                sda.Fill(queryTicketDataSet);

                for (int j = 0; j < queryTicketDataSet.Tables[0].Rows.Count; j++)
                {

                    var theRow_UserId = queryTicketDataSet.Tables[0].Rows[j]["TUserId"];
                    ///////////////////////////////////////////////////
                    sda = new SqlDataAdapter(queryUserInfo + theRow_UserId, conn);

                    DataSet queryUserInfoDataSet = new DataSet();
                    sda.Fill(queryUserInfoDataSet);
                    var theRowTicket_stauts = queryTicketDataSet.Tables[0].Rows[j]["stauts"].ToString();
                    if(theRowTicket_stauts == "3")
                    {
                        theRowTicket_stauts = "已使用";
                    }
                    if (theRowTicket_stauts == "1")
                    {
                        theRowTicket_stauts = "未使用";
                    }
                    if ( State.Text != theRowTicket_stauts && State.Text!="全部")
                    {                                   
                        continue;
                    }



                    int Addrow = NewRow();

                    var theRowUserInfo_name = queryUserInfoDataSet.Tables[0].Rows[0]["name"].ToString();
                    var theRowUserInfo_phoneNumber = queryUserInfoDataSet.Tables[0].Rows[0]["phoneNumber"].ToString();
                    var theRowUserInfo_idCard = queryUserInfoDataSet.Tables[0].Rows[0]["idCard"].ToString();
                    NewCol(Addrow, 0, theRowUserInfo_name);
                    NewCol(Addrow, 1, theRowUserInfo_phoneNumber);
                    NewCol(Addrow, 2, theRowUserInfo_idCard);

                  
                    var theRowTicket_startTime = queryTicketDataSet.Tables[0].Rows[j]["startTime"].ToString();
                    var theRowTicket_endTime = queryTicketDataSet.Tables[0].Rows[j]["endTime"].ToString();
                    var theRowTicket_createTime = queryTicketDataSet.Tables[0].Rows[j]["createTime"].ToString();
               
                    NewCol(Addrow, 3, theRowTicket_startTime);
                    NewCol(Addrow, 4, theRowTicket_endTime);
                    NewCol(Addrow, 5, theRowTicket_createTime);
                    NewCol(Addrow, 6, theRowTicket_stauts);


                }
            }
        }
        /// <summary>
        /// 在相应的列当中添加一个数据
        /// </summary>
        /// <param name="col">列</param>
        /// <param name="value">值</param>
        ///  <param name="row">行</param>

        private void NewCol(int row,int col,string value)
        {
            
            dataGridView1.Rows[row].Cells[col].Value=value;
            //dataGridView1.Rows[row].Cells[1].Value = "phoneNumber"; //手机 
            //dataGridView1.Rows[row].Cells[2].Value = "idCard"; //身份证
            //dataGridView1.Rows[row].Cells[3].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);//设置字体加粗

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




    }
}


