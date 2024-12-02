using _222222;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisitForm1
{
    public partial class ExhibitionForm1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CommonTicket1;user id=sa;password=Aa123456;TrustServerCertificate=true");
        public ExhibitionForm1()
        {
            InitializeComponent();
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
                    dataGridView1.Rows[Addrow].Cells[Column1.Index].Value = exhibition.name;
                    dataGridView1.Rows[Addrow].Cells[Column3.Index].Value = exhibition.basicPrice;
                }
                if (dataGridView1.Columns.Contains(Column3) && dataGridView1.Columns[Column3.Index].DataPropertyName == "BasicPrice")
                {
                    dataGridView1.Sort(dataGridView1.Columns[Column3.Index], System.ComponentModel.ListSortDirection.Ascending);
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == Column2.Index))
            {
                MainAppointmentForm mainForm = new MainAppointmentForm();
                mainForm.ShowDialog();
            }
        }
    

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
}
}
