using _222222;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
            using (var db = new MyDbContext())
            {
                var exhibitions = db.Exhibitions.ToList();
               

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

            form2.ShowDialog();

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
                object rawIdValue = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                Guid? id = null;
                if (Guid.TryParse(rawIdValue?.ToString(), out Guid parsedGuid))
                {
                    id = parsedGuid;
                }

                if (id.HasValue)
                {
                    using (MyDbContext ctx = new MyDbContext())
                    {

                        var exhibitionToDelete = ctx.Exhibitions.SingleOrDefault(ex => ex.id == id.Value);
                        if (exhibitionToDelete != null)
                        {
                            ctx.Exhibitions.Remove(exhibitionToDelete);
                            await ctx.SaveChangesAsync();
                        }
                    }
                }
            }
            else if ((e.ColumnIndex == Column6.Index))
            {
                DataGridView gridView = sender as DataGridView;
                if (e.RowIndex >= 0 && e.RowIndex < gridView.Rows.Count)
                {
                    Guid Id = Guid.Parse(gridView.Rows[e.RowIndex].Cells[IDColumn.Index].Value.ToString());

                    AppointmentForm appointmentForm = new AppointmentForm(Id);
                    appointmentForm.ShowDialog();
               
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
