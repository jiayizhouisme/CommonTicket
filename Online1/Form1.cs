using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing.Text;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Online1
{
    public partial class Form1 : Form
    {
        // private SqlConnection connection;
        // private string connectionString = "Data Source=192.168.51.109;Initial Catalog=Common;user id=admin;password=Aa123456;TrustServerCertificate=true;";
        public Form1()
        {

            InitializeComponent();

           // Person();
        }

        //private void Person()
        //{
        //    DataGridViewRow row = new DataGridViewRow();
        //    int j = dataGridView1.Rows.Add(row);//����µ�һ��
        //    dataGridView1.Rows[j].Cells[0].Value = "��ǫ��ٳ";//����
        //    dataGridView1.Rows[j].Cells[1].Value = "18252111111"; //�ֻ� 
        //    dataGridView1.Rows[j].Cells[2].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);//��������Ӵ�

        //    row = new DataGridViewRow();//����µ�һ��
        //    j = dataGridView1.Rows.Add(row);//j���÷������1
        //    dataGridView1.Rows[j].Cells[0].Value = "��������";
        //    dataGridView1.Rows[j].Cells[1].Value = "18252111112";
        //    dataGridView1.Rows[j].Cells[2].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);//��������Ӵ�
        //}

        private void Type_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Type.Items.Cast<object>().All(x => x.ToString() != "��ҵ�������Ʊ"))
                Type.Items.Add("��ҵ�������Ʊ");
            if (Type.Items.Cast<object>().All(x => x.ToString() != "�¹��Ŵ徰����Ʊ"))
                Type.Items.Add("�¹��Ŵ徰����Ʊ");


        }
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            string selectedDateTime = dateTimePicker.Value.ToString("year-month-day ");
            MessageBox.Show("��ѡ������ں�ʱ���ǣ�" + selectedDateTime);
        }

        private void State_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show("����������");
                return;
            }
        }
        private void Search_Click(object sender, EventArgs e)
        {
            string name =this.textBox.Text;
            string sqlOrder = "select * from [Order] " ;
            string queryTicket = "select * from [Ticket] where objectId = ";
            SqlConnection conn = new SqlConnection("Data Source=192.168.51.109;Initial Catalog=CommonTicket2;user id=admin;password=Aa123456;TrustServerCertificate=true;");
            // SqlDataAdapter sda = new SqlDataAdapter("select * from dbo.Order where userid=" + Type.Text, conn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlOrder, conn);
            
            DataSet sqlOrderDataSet = new DataSet();
            sda.Fill(sqlOrderDataSet);
            //DataRow theRow = ds.Tables[0].Rows[0];
            //DataRow theRow = ds.Tables[0].Rows[1];
            //DataRow theRow = ds.Tables[0].Rows[2];
            //DataRow theRow = ds.Tables[0].Rows[3];
            //DataRow theRow = ds.Tables[0].Rows[4];
            //DataRow theRow = ds.Tables[0].Rows[5];
            //DataRow theRow = ds.Tables[0].Rows[6];
            for (int i = 0; i < sqlOrderDataSet.Tables[0].Rows.Count ;i++)
            {
                var theRowOrder_trade_no = sqlOrderDataSet.Tables[0].Rows[i]["trade_no"];

                sda = new SqlDataAdapter(queryTicket + theRowOrder_trade_no, conn);
                DataSet queryTicketDataSet = new DataSet();
                sda.Fill(queryTicketDataSet);
                for(int j = 0;j< queryTicketDataSet.Tables[0].Rows.Count; j++) 
                {
                    var theRowTicket_startTime = queryTicketDataSet.Tables[0].Rows[j]["startTime"];
                    var theRowTicket_endTime = queryTicketDataSet.Tables[0].Rows[j]["endTime"];
                }
            }
            
            //foreach (DataRow theRow in ds.Tables[0].Rows)
            //{


            //}


           // dataGridView1.DataSource = ds;
            // dataGridView1.DataBind();
        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
            
        }
                       
          private  void Person()
            {
                DataGridViewRow row = new DataGridViewRow();
                int j = dataGridView1.Rows.Add(row);//����µ�һ��
                dataGridView1.Rows[j].Cells[0].Value = "";//����
                dataGridView1.Rows[j].Cells[1].Value = ""; //�ֻ� 
                dataGridView1.Rows[j].Cells[2].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);//��������Ӵ�

                row = new DataGridViewRow();//����µ�һ��
                j = dataGridView1.Rows.Add(row);//j���÷������1
                dataGridView1.Rows[j].Cells[0].Value = "";
                dataGridView1.Rows[j].Cells[1].Value = "";
                dataGridView1.Rows[j].Cells[2].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);//��������Ӵ�
            }
        }
    }


