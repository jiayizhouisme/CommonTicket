using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json.Linq;
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
using 通用订票.Core.Entity;


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

            dataGridView1.Rows.Clear();
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

        private async void UpdatedataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Form2 form2 = new Form2( dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());

            // 显示Form2，可以选择Modeless或Modal方式
            // form2.Show(); // 非模态窗口，可以同时与Form1交互
            form2.ShowDialog(); // 模态窗口，必须先关闭Form2才能与Form1交


        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if(e.ColumnIndex == 4)
            {
                UpdatedataGridView1_CellContentClick(sender, e);
                return;
            }
            var dr=  dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            using (TestDbContext ctx = new TestDbContext())
            {                        
                var query=  ctx.Exhibition.AsQueryable().Where(ex => ex.name == dr);
                var exhibitionToDelete = ctx.Exhibition.SingleOrDefault(ex => ex.name == dr);
                if (exhibitionToDelete != null)
                {   
                    ctx.Exhibition.Remove(exhibitionToDelete);
                    await ctx.SaveChangesAsync();

                }

               

            }
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
