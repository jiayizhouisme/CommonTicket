using _222222;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisitForm1._222222.Model;

namespace VisitForm1
{
    public partial class Reserve : Form
    {
        public Reserve()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Column1.Index)
            {
                EditUserInfoForm editUserInfoForm = new EditUserInfoForm();
                editUserInfoForm.ShowDialog();
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = SelectDate.Value;
            DateTime? startTime = null;
            DateTime? endTime = null;
            String selectedTime = "";
           
            if (checkBox1.Checked)
            {
                selectedTime= "8:00-11:00";
                startTime = selectedDate.Date.AddHours(8);
                endTime = selectedDate.Date.AddHours(11);
            }
            else if (checkBox2.Checked)
            {
                selectedTime = "11:00-15:00";
                startTime = selectedDate.Date.AddHours(11);
                endTime = selectedDate.Date.AddHours(15);
            }
            else if (checkBox3.Checked)
            {
                selectedTime = "15:00-18:00";
                startTime = selectedDate.Date.AddHours(15);
                endTime = selectedDate.Date.AddHours(18);
            }
            else
            {
                MessageBox.Show("请选择一个时间段。");
                return;
            }
            using (var context = new MyDbContext())
            {
                try
                {                   
                  Appointment appointment = new Appointment
                  {
                      CreateTime = selectedDate,
                      StartTime = startTime.Value,
                      EndTime = endTime.Value

                  };
                    context.Appointments.Add(appointment);
                    context.SaveChanges();
                    MessageBox.Show("预约成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("预约失败！" );
                }
            }
        
    }
            

        private void AddCount_Click(object sender, EventArgs e)
        {
            AddUserInfoForm addUserInfoForm = new AddUserInfoForm();
            addUserInfoForm.ShowDialog();
        }
    }
}
