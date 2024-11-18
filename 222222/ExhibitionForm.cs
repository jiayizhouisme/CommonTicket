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
            using (var db = new TestDbContext())
            {
                var exhibitions = db.Exhibition.ToList();
                dataGridView1.Rows.Clear();
                foreach (var exhibition in exhibitions)
                {
                    int Addrow = dataGridView1.Rows.Add();                  
                    dataGridView1.Rows[Addrow].Cells[IDColumn.Index].Value = exhibition.id;
                    dataGridView1.Rows[Addrow].Cells[Column1.Index].Value = exhibition.name;
                    dataGridView1.Rows[Addrow].Cells[Column2.Index].Value = exhibition.description;
                    dataGridView1.Rows[Addrow].Cells[Column3.Index].Value = exhibition.beforeDays;

                }
            }

            //DataTable dt = (DataTable)dataGridView1.DataSource;


            //string queryExhibition = "select * from [Exhibition] ";

            //dataGridView1.Rows.Clear();
            //DataSet exhibitions = Query(queryExhibition);

            //for (int j = 0; j < exhibitions.Tables[0].Rows.Count; j++)
            //{
            //    int Addrow = NewRow();
            //    var theRowExhibition_id = exhibitions.Tables[0].Rows[j]["id"].ToString();
            //    var theRowExhibition_name = exhibitions.Tables[0].Rows[j]["name"].ToString();
            //    var theRowExhibition_description = exhibitions.Tables[0].Rows[j]["description"].ToString();
            //    var theRowExhibition_beforeDays = exhibitions.Tables[0].Rows[j]["beforeDays"].ToString();

            //NewCol(Addrow, IDColumn.Index, theRowExhibition_id);
            //NewCol(Addrow, Column1.Index, theRowExhibition_name);
            //NewCol(Addrow, Column2.Index, theRowExhibition_description);
            //NewCol(Addrow, Column3.Index, theRowExhibition_beforeDays);
        }
    
        private  void AdddataGirdView1_CellContentClick(object sender, EventArgs e)
        {
            AddExhibitionForm addExhibitionForm = new AddExhibitionForm( );
            addExhibitionForm.ShowDialog();
        }
        private  void DeletedataGridView1_CellContentClick(object sender, EventArgs e)
        {
            DeleteExhibitionForm form11 = new DeleteExhibitionForm();
            form11.ShowDialog(); 

        }
        private async void UpdatedataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Form2 form2 = new Form2(dataGridView1.Rows[e.RowIndex].Cells[IDColumn.Index].Value.ToString(),
                dataGridView1.Rows[e.RowIndex].Cells[Column1.Index].Value.ToString(),
                dataGridView1.Rows[e.RowIndex].Cells[Column2.Index].Value.ToString(),
                dataGridView1.Rows[e.RowIndex].Cells[Column3.Index].Value.ToString());

            // 显示Form2，可以选择Modeless或Modal方式
            // form2.Show(); // 非模态窗口，可以同时与Form1交互
            form2.ShowDialog(); // 模态窗口，必须先关闭Form2才能与Form1交


        }



        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Column5.Index)
            {
                UpdatedataGridView1_CellContentClick(sender, e);
                return;
            }
            else if (e.ColumnIndex == Column4.Index)
            {
                //var dr = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                // var id = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                object rawIdValue = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                Guid? id = null;
                if (Guid.TryParse(rawIdValue?.ToString(), out Guid parsedGuid))
                {
                    id = parsedGuid;
                }

                if (id.HasValue)
                {
                    using (TestDbContext ctx = new TestDbContext())
                    {

                        var exhibitionToDelete = ctx.Exhibition.SingleOrDefault(ex => ex.id == id.Value);
                        if (exhibitionToDelete != null)
                        {
                            ctx.Exhibition.Remove(exhibitionToDelete);
                            await ctx.SaveChangesAsync();
                        }
                    }
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
