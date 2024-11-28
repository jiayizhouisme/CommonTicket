using _222222;
using _222222.Model;
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
    public partial class MainAppointmentForm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CommonTicket1;user id=sa;password=Aa123456;TrustServerCertificate=true");
        private Guid id;

        public MainAppointmentForm()
        {
            InitializeComponent();    
        }

        public MainAppointmentForm(Guid id)//构造函数
        {
            this.id = id;
            InitializeComponent();
        }
        private void Submit_Click(object sender, EventArgs e)
        {     
            using (var db = new MyDbContext())
            {
                var appointments = db.Appointments.ToList();
                var sortedAppointments = appointments.Where(a =>a.ObjectId == id).OrderBy(appointment => appointment.Day).ToList();
                dataGridView1.Rows.Clear(); 
                foreach (var appointment in sortedAppointments)
                {
                    int Addrow = dataGridView1.Rows.Add();
                    dataGridView1.Rows[Addrow].Cells[IDColumn.Index].Value =appointment.Id;
                     dataGridView1.Rows[Addrow].Cells[Column1.Index].Value = appointment.Day;  
                    dataGridView1.Rows[Addrow].Cells[Column2.Index].Value = appointment.StartTime; 
                    dataGridView1.Rows[Addrow].Cells[Column3.Index].Value = appointment.EndTime;
                    dataGridView1.Rows[Addrow].Cells[Column6.Index].Value = appointment.ObjectId;
                }
            }
        }
        private void AdddataGirdView1_CellContentClick(object sender, EventArgs e)
        {
            AddAppointmentForm addappointmentForm = new AddAppointmentForm(this.id);
            addappointmentForm.ShowDialog();
        }
        private void UpdateGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            object cellValue = dataGridView1.Rows[e.RowIndex].Cells[IDColumn.Index].Value;
            if (cellValue != null && Guid.TryParse(cellValue.ToString(), out Guid id))
            {
                UpdateAppointmentForm appointmentForm = new UpdateAppointmentForm(id);
                appointmentForm.ShowDialog();
            }
        }
        private void DeletedataGridView1_CellContentClick(object sender, EventArgs e)
        {           
        }
        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Column4.Index)
            {
                UpdateGridView1_CellContentClick(sender, e);
                return;
            }
            if (e.ColumnIndex == Column5.Index)
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
                        var appointmentToDelete = ctx.Appointments.SingleOrDefault(ex => ex.Id == id.Value);
                        if (appointmentToDelete != null)
                        {
                            ctx.Appointments.Remove(appointmentToDelete);
                            await ctx.SaveChangesAsync();
                        }
                    }
                }
            }
            else if ((e.ColumnIndex == Column4.Index))
            {
                DataGridView gridView = sender as DataGridView;
                if (e.RowIndex >= 0 && e.RowIndex < gridView.Rows.Count)
                {
                    Guid Id = Guid.Parse(gridView.Rows[e.RowIndex].Cells[IDColumn.Index].Value.ToString());
                    UpdateAppointmentForm appointmentForm = new UpdateAppointmentForm(Id);
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
            int j = dataGridView1.Rows.Add(row);
            return j;
        }     
    }
}
