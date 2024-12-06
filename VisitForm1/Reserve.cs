using _222222;
using _222222.Model;
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
        private const int MaxTourists = 5;
        private int _currentTouristCount = 1;
        private int _addedTouristCount = 0;
        private Guid _exhibitionId;
        //  private Control label;
        private List<Label> labels = new List<Label>();
        public Reserve(Guid exhibitionid) : this()
        {
            _exhibitionId = exhibitionid;
            VisitorCount.Value = _currentTouristCount;
            UpdateLabelText();
            LoadUserInfo();
            SelectDate.ValueChanged += SelectDate_ValueChanged;
            ClearLabels();
            using (var db = new MyDbContext())
            {
                var day = SelectDate.Value.Date.Subtract(DateTime.Now.Date).TotalDays;

                var appointments = db.Appointments.AsQueryable().Where(a => a.ObjectId == exhibitionid && a.Day == day).ToArray();
                var exhibitions = db.Exhibitions.AsQueryable().Where(i => i.id == exhibitionid).FirstOrDefault();
                for (int a = 0; a < appointments.Length; a++)
                {

                    Label label = new Label();
                    //this.label = label;
                    label.AutoSize = true;
                    label.Location = new Point(12, a * 35 + 147);
                    label.Text = string.Format("时间{0} 余票{1} ￥{2:F2}",
                    appointments[a].StartTime.ToShortTimeString() + " " + appointments[a].EndTime.ToShortTimeString(), appointments[a].amount, exhibitions.basicPrice);
                    this.Controls.Add(label);
                    labels.Add(label);

                }
              
            }

        }
        public Reserve()
        {
            InitializeComponent();
            SelectDate.ValueChanged += SelectDate_ValueChanged;
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
        private void DeletedataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Column5.Index)
            {
                DeleteUseInfoForm deleteUseInfoForm = new DeleteUseInfoForm();
                deleteUseInfoForm.ShowDialog();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Column4.Index)
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

                selectedTime = "8:00-11:00";
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
                if (_addedTouristCount != _currentTouristCount)
                {
                    MessageBox.Show("新增游客的数量必须等于选择游客的数量。");
                    return;
                }
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
                    MessageBox.Show("预约失败！");
                }

            }

        }
        private void AddCount_Click(object sender, EventArgs e)
        {
            AddUserInfoForm addUserInfoForm = new AddUserInfoForm();

            addUserInfoForm.ShowDialog();
        }

        private void SetInitialTouristCount(int count)
        {
            _currentTouristCount = count;
            VisitorCount.Value = count;
            UpdateLabelText();
        }
        private void VisitorCount_ValueChanged(object sender, EventArgs e)
        {
            _currentTouristCount = (int)VisitorCount.Value;
            UpdateLabelText();
        }

        private void UpdateLabelText()
        {

            if (_currentTouristCount < MaxTourists)
            {
                lblNeedMoreTourists.Text = $"！需增加{_currentTouristCount}位游客";
            }
            else
            {
                lblNeedMoreTourists.Text = $"!当前游客数已达到最大限制";
            }
        }

        private void LoadUserInfo()
        {
            using (var db = new MyDbContext())
            {
                var userInfos = db.UserInfos.AsQueryable().Where(a => a.UserId == LogInInfo.id).ToList();

                dataGridView1.Rows.Clear();
                foreach (var userInfo in userInfos)
                {
                    int Addrow = dataGridView1.Rows.Add();
                    dataGridView1.Rows[Addrow].Cells[Column1.Index].Value = userInfo.Name;
                    dataGridView1.Rows[Addrow].Cells[Column2.Index].Value = userInfo.IdCard.ToString();
                    dataGridView1.Rows[Addrow].Cells[Column3.Index].Value = userInfo.PhoneNumber;
                }
            }
        }
        private void ClearLabels()
        {
            foreach (var label in labels)
            {
                this.Controls.Remove(label);
            }
            labels.Clear();
        }
        private void SelectDate_ValueChanged(object sender, EventArgs e)
        {       
            ClearLabels();
            using (var db = new MyDbContext())
            {
                var day = SelectDate.Value.Date.Subtract(DateTime.Now.Date).TotalDays;
                var appointments = db.Appointments.AsQueryable().Where(a => a.ObjectId == _exhibitionId && a.Day == day).ToArray();
                var exhibitions = db.Exhibitions.AsQueryable().Where(i => i.id == _exhibitionId).FirstOrDefault();
                if (exhibitions != null)
                {
                    for (int a = 0; a < appointments.Length; a++)
                    {
                        var appointment = appointments[a];
                        Guid appointmentId = appointment.Id;
                        Label label = new Label();
                        label.AutoSize = true;
                        label.Location = new Point(12, a * 35 + 147);
                        label.Text = string.Format("时间{0} 余票{1} ￥{2:F2}",
                        appointments[a].StartTime.ToShortTimeString() + " " + appointments[a].EndTime.ToShortTimeString(), appointments[a].amount, exhibitions.basicPrice);
                        this.Controls.Add(label);
                        labels.Add(label);
                        // this.Controls.Remove(this.label);
                    }
                }
            }
        }
           
        }
    }


   
