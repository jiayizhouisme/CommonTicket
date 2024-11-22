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

        public AppointmentForm()
        {
        }

        public AppointmentForm(Guid id)
        {
            InitializeComponent();
            ID.Text = id.ToString();                   
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            object rawIdValue = ID.Text;
            Guid? id = null;
            if (Guid.TryParse(rawIdValue?.ToString(), out Guid parsedGuid))
            {
                id = parsedGuid;
            }
            if (id.HasValue)
            {
                using (var ctx = new MyDbContext())
                {                  
                    var appointment =  ctx.Appointments.FirstOrDefault(a => a.Id ==id.Value);
                    if (appointment != null)
                    {
                        if (int.TryParse(Day.Text, out int day))
                        {
                            appointment.Day = day;
                        }
                        if (DateTime.TryParse(StartTime.Text, out DateTime startTime) &&
                    DateTime.TryParse(EndTime.Text, out DateTime endTime))
                        {
                            appointment.StartTime = startTime;
                            appointment.EndTime = endTime;
                            try
                            {
                                ctx.SaveChanges();
                                MessageBox.Show("添加时间成功");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("添加时间失败: ");
                            }
                        }
                    }
                }
            }
        }
    }
}
