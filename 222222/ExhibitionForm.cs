using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
        private DataSet Query(string sql)
        {
            var sda = new SqlDataAdapter(sql, conn);
            DataSet queryTableDataSet = new DataSet();

            sda.Fill(queryTableDataSet);
            return queryTableDataSet;
        }

        private void Insert_Click(object sender, EventArgs e)
        {
           

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            

        }

        private void Update_Click(object sender, EventArgs e)
        {
           

        }


        private void Select_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;


            string queryExhibition = "select * from [Exhibition] ";

            DataSet exhibitions = Query(queryExhibition);
          
            for (int j = 0; j < exhibitions.Tables[0].Rows.Count; j++)
            {
                int Addrow = NewRow();
                var theRowExhibition_name = exhibitions.Tables[0].Rows[j]["name"].ToString();
                var theRowExhibition_description = exhibitions.Tables[0].Rows[j]["description"].ToString();
                var theRowExhibition_beforeDays = exhibitions.Tables[0].Rows[j]["beforeDays"].ToString();
                NewCol(Addrow, 0, theRowExhibition_name);
                NewCol(Addrow, 1, theRowExhibition_description);
                NewCol(Addrow, 2, theRowExhibition_beforeDays);
            }
        }



        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //using TestDbContext ctx = new TestDbContext();
            //var b = ctx.Exhibitions.Single(b => b.name == "");
            //ctx.Exhibitions.Remove(b);
            //await ctx.SaveChangesAsync();
             
            //if (e.ColumnIndex == dataGridView1.Columns["name"].Index && e.RowIndex >= 0)
            //{
            //    dataGridView1.Rows.RemoveAt(e.RowIndex);
            //    DataTable dataSource = (DataTable)dataGridView1.DataSource;
            //    dataSource.Rows[e.RowIndex].Delete();
            //}

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
