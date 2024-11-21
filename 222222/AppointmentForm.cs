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

namespace _222222
{
    public partial class AppointmentForm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CommonTicket2;user id=sa;password=Aa123456;TrustServerCertificate=true");
        public AppointmentForm(Guid id,int day,TimeSpan startTime,TimeSpan endTime)
        {
            InitializeComponent();
            ID.Text =id.ToString();
            Day.Text = day.ToString();
            StartTime.Text = startTime.ToString();
            EndTime.Text = endTime.ToString();
            Submit.Click += Submit_Click;
            //dateTimePicker1.Format = DateTimePickerFormat.Time;
            //dateTimePicker1.ShowUpDown = true;
            //dateTimePicker2.Format = DateTimePickerFormat.Time;
            //dateTimePicker2.ShowUpDown = true;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            
            using (var ctx = new MyDbContext())
            {
               
            }
            }
    }
}
