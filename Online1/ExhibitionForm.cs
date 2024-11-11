using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Online1
{
    public partial class ExhibitionForm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CommonTicket2;user id=sa;password=Aa123456;TrustServerCertificate=true");
        public ExhibitionForm()
        {
            InitializeComponent();

        }


        private void Insert_Click(object sender, EventArgs e)
        {
           

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            //DataBase db = new DataBase();
            //SqlConnection conn = db.getConn();
            //conn.Open();
            //int rowindex = dataGridView1.CurrentRow.Index;
            //String value0 = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            //String sql = "delete from test1 where id='" + value0 + "'";
            //SqlCommand comm = new SqlCommand(sql, conn);
            //comm.ExecuteNonQuery();
            //MessageBox.Show("删除成功！");
            //conn.Close();
            //

        }

        private void Update_Click(object sender, EventArgs e)
        {
            //Database db = new Database();
            //SqlConnection conn = db.getConn();
            conn.Open();
            int rowindex = dataGridView1.CurrentRow.Index;
            String value0 = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            String value1 = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            String value2 = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
            String sql = "update Exhibition set name='" + value1 + "description',='" + value2 + "'beforeDays'" + value0 + "'";
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            MessageBox.Show("修改成功！");
            conn.Close();

        }


        private void Select_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;


            string queryExhibition = "select * from [Exhibition] ";


            var sda = new SqlDataAdapter(queryExhibition, conn);

            DataSet queryExhibitionDataSet = new DataSet();
            sda.Fill(queryExhibitionDataSet);
            for (int j = 0; j < queryExhibitionDataSet.Tables[0].Rows.Count; j++)
            {
                int Addrow = NewRow();
                var theRowExhibition_name = queryExhibitionDataSet.Tables[0].Rows[j]["name"].ToString();
                var theRowExhibition_description = queryExhibitionDataSet.Tables[0].Rows[j]["description"].ToString();
                var theRowExhibition_beforeDays = queryExhibitionDataSet.Tables[0].Rows[j]["beforeDays"].ToString();
                NewCol(Addrow, 0, theRowExhibition_name);
                NewCol(Addrow, 1, theRowExhibition_description);
                NewCol(Addrow, 2, theRowExhibition_beforeDays);
            }
        }
            
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
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
    }
}
