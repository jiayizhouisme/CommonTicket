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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Online1
{
    public partial class DeleteAppointmentForm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CommonTicket2;user id=sa;password=Aa123456;TrustServerCertificate=true");
        public DeleteAppointmentForm()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                Guid appointmentId;
                if (Guid.TryParse(ID.Text, out appointmentId))
                {
                    var appointment= context.Appointments.Find(appointmentId);
                    if (appointment != null)
                    {
                        context.Appointments.Remove(appointment);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}












