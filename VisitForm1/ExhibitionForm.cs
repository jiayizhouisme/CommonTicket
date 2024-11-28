using _222222;
using _222222.Model;
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
    public partial class ExhibitionForm : Form
    {

        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CommonTicket1;user id=sa;password=Aa123456;TrustServerCertificate=true");
        public ExhibitionForm()
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
                    dataGridView1.Rows[Addrow].Cells[ID.Index].Value = exhibition.id;
                    dataGridView1.Rows[Addrow].Cells[Name.Index].Value = exhibition.name;
                    dataGridView1.Rows[Addrow].Cells[description.Index].Value = exhibition.description;
                    dataGridView1.Rows[Addrow].Cells[beforeDays.Index].Value = exhibition.beforeDays;
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == Column5.Index))
            {
                Guid Id = Guid.Parse(dataGridView1.Rows[e.RowIndex].Cells[ID.Index].Value.ToString());
                //MainAppointmentForm mainForm = new MainAppointmentForm(Id);
                //mainForm.ShowDialog();
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
