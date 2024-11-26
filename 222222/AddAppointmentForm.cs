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
using Microsoft.Data.SqlClient;

namespace _222222
{
    public partial class AddAppointmentForm : Form
    {      
        public AddAppointmentForm( Guid objectId)
        {
            InitializeComponent();                   
            textBox3.Text = objectId.ToString();           
            this.Submit.Click += new EventHandler(Submit_Click);

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            Guid? parsedId = null; 
            int? parsedDay = null;
            DateTime startTime, endTime;        
            if (Guid.TryParse(textBox1.Text, out Guid idValue))
            {
                parsedId = idValue;
            }
            else if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                parsedId = Guid.NewGuid();
            }
            if (int.TryParse(textBox2.Text, out int dayValue) && !string.IsNullOrEmpty(textBox2.Text))
            {
                parsedDay = dayValue;
            }
            startTime = dateTimePicker1.Value;
            endTime = dateTimePicker2.Value;
            using (var context = new MyDbContext())
            {
                var appointment = new Appointment
                {
                    Id = parsedId.Value,
                    Day = parsedDay ?? 0,
                    StartTime = startTime,
                    EndTime = endTime,
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

