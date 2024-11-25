using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _222222;
using _222222.Model;

namespace _222222
{
    public partial class AddAppointmentForm : Form
    {
        public AddAppointmentForm()
        {
            InitializeComponent();
            Add.Click += Add_Click;
        }

        private void Add_Click(object sender, EventArgs e)
        {         
                using (var context = new MyDbContext())
                {
                    var appointment = new Appointment
                    {                       
                        Id = Guid.Parse(textBox1.Text),
                        Day = int.Parse(textBox2.Text),
                        StartTime = DateTime.Parse(dateTimePicker1.Text),
                        EndTime = DateTime.Parse(dateTimePicker2.Text),
                    };
                    try
                    {

                        context.Appointments.Add(appointment);
                        context.SaveChanges();

                        MessageBox.Show("添加成功");

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("添加失败");

                    }
                }
            }
        }
    }

