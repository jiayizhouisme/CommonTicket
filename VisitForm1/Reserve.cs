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
        private int _currentTouristCount = 1;//选择     
        private int _addedTouristCount = 0;
        private int _selectedTouristCount = 0;
        private CheckBox checkBox ;
        private Guid _exhibitionId;
        //  private Control label;
        private Appointment _selectedAppointment;
        private List<Label> labels = new List<Label>();
        private List<GroupBox> groups = new List<GroupBox>();
        private List<CheckBox> checkboxes = new List<CheckBox>();        
        public Reserve(Guid exhibitionId) : this()
        {
            _exhibitionId = exhibitionId;
            VisitorCount.Value = _currentTouristCount;
            UpdateLabelText();
            LoadUserInfo();
            SelectDate.ValueChanged += SelectDate_ValueChanged;
            LoadAppointments();
            //ClearLabels();
            ClearGroupBoxs();
            LoadAppointments();
        }
        private void LoadAppointments()
        {
            ClearGroupBoxs();
            using (var db = new MyDbContext())
            {
                var day = SelectDate.Value.Date.Subtract(DateTime.Now.Date).TotalDays;
                var appointments = db.Appointments.AsQueryable().Where(a => a.ObjectId == _exhibitionId && a.Day == day).ToArray();
                var exhibitions = db.Exhibitions.AsQueryable().Where(i => i.id == _exhibitionId).FirstOrDefault();

                for (int b = 0; b < appointments.Length; b++)
                {
                    GroupBox groupBox = new GroupBox();
                    groupBox.Size = new Size(600, 40);
                    groupBox.Location = new Point(12, b * 35 + 147);
                    groupBox.Text = "";
                    CheckBox checkBox = new CheckBox();
                    checkBox.AutoSize = true;
                    checkBox.Location = new Point(430, 10);
                    checkBox.Text = "选择";
                    checkBox.Tag = appointments[b];
                    checkBox.CheckedChanged += CheckBox_CheckedChanged;
                    Label label = new Label();
                    label.AutoSize = true;
                    label.Location = new Point(0, 10);
                    label.Text = string.Format("时间{0} 余票{1} ￥{2:F2}",
                    appointments[b].StartTime.ToShortTimeString() + " " + appointments[b].EndTime.ToShortTimeString(), appointments[b].amount, exhibitions.basicPrice);
                    groupBox.Controls.Add(label);
                    labels.Add(label);
                    checkboxes.Add(checkBox);
                    groupBox.Controls.Add(checkBox);
                    groups.Add(groupBox);
                    this.Controls.Add(groupBox);

                }
            }
        }
        public Reserve()
        {
            InitializeComponent();
            SelectDate.ValueChanged += SelectDate_ValueChanged;
        }

        //private void CheckBox_CheckedChanged(object sender, EventArgs e)
        //{

        //    //if (checkBox1.Checked)
        //    //{
        //    //    checkBox2.Checked = false;
        //    //    checkBox3.Checked = false;
        //    //}
        //}
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null && checkBox.Checked)
            {              
                foreach (var cb in checkboxes)
                {
                    if (cb != checkBox)
                    {
                        cb.Checked = false;
                    }
                    
                }
                _selectedAppointment = checkBox.Tag as Appointment;
            }
        
        else
        {            
            _selectedAppointment = null;
        }
}

    
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox3.Checked)
            //{
            //    checkBox1.Checked = false;
            //    checkBox2.Checked = false;
            //}
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == Column4.Index)
            {
                EditUserInfoForm editUserInfoForm = new EditUserInfoForm();
                editUserInfoForm.ShowDialog();
            }
            else if (e.ColumnIndex == Column5.Index)
            {

                DataGridViewCell idCell = dataGridView1.Rows[e.RowIndex].Cells["IDColumn"];               
                if (idCell.Value != null)
                {
                    long userIdToDelete = (long)idCell.Value;
                    DialogResult a = MessageBox.Show("确定要删除吗", "", MessageBoxButtons.OKCancel);
                    if (a == DialogResult.OK)
                    {
                        using (DeleteUseInfoForm deleteUseInfoForm = new DeleteUseInfoForm(userIdToDelete))
                        {
                            deleteUseInfoForm.ExecuteDelete();
                        }
                    }
                    else if (a == DialogResult.Cancel)
                    {
                        MessageBox.Show("已取消删除操作");
                    }

                    }
                }
            }
        
        private void Submit_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = SelectDate.Value;
            DateTime? startTime = null;
            DateTime? endTime = null;
            String selectedTime = "";
            int selectedTouristCount = 0;
            bool isTimeSlotSelected = false;
           
            foreach (var cb in checkboxes) 
            {
                if (cb.Checked)
                {
                  this. checkBox = cb;
                    
                    isTimeSlotSelected = true;
                    break;
                }
            }
            if (!isTimeSlotSelected)
            {
                MessageBox.Show("请选择一个时间段。");
                return;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Column6"].Value is bool && (bool)row.Cells["Column6"].Value)
                {
                    selectedTouristCount++;
                }
            }
            //if (checkBox1.Checked)
            //{
            //    selectedTime = "8:00-11:00";
            //    startTime = selectedDate.Date.AddHours(8);
            //    endTime = selectedDate.Date.AddHours(11);
            //}         
            //else
            //{
            //    MessageBox.Show("请选择一个时间段。");
            //    return;
            //}

            using (var context = new MyDbContext())
            {
                List<Appointment> appointmentsToAdd = new List<Appointment>();
                if (selectedTouristCount != VisitorCount.Value)
                {
                    MessageBox.Show("新增游客的数量必须等于选择游客的数量。");
                    return;
                }
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    if (row.Cells["Column6"].Value is bool && (bool)row.Cells["Column6"].Value)
                    {
                      
                        long userId = Convert.ToInt64(row.Cells["IDColumn"].Value);
                        Appointment appointment = new Appointment
                        {
                            Id = Guid.Empty,
                            CreateTime = selectedDate,

                            StartTime = ((Appointment)this.checkBox.Tag).StartTime,
                            EndTime = ((Appointment)this.checkBox.Tag).EndTime,
                        };
                        appointmentsToAdd.Add(appointment);
                    }
                }
                try
                {
                    context.Appointments.AddRange(appointmentsToAdd);
                    context.SaveChanges();
                    MessageBox.Show($"成功预约了 {appointmentsToAdd.Count} 个游客。");
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
            //  LoadUserInfo();
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
                    dataGridView1.Rows[Addrow].Cells[IDColumn.Index].Value=userInfo.Id;
                    dataGridView1.Rows[Addrow].Cells[Column1.Index].Value = userInfo.Name;
                    dataGridView1.Rows[Addrow].Cells[Column2.Index].Value = userInfo.IdCard.ToString();
                    dataGridView1.Rows[Addrow].Cells[Column3.Index].Value = userInfo.PhoneNumber;
                }
            }
        }
        //private void ClearLabels()
        //{
        //    checkboxes.Clear();
        //    labels.Clear();
        //}
        //private void ClearGroupBoxs()
        //{
        //    foreach (var groupBox in groups)
        //    {
        //        this.Controls.Remove(groupBox);
        //        groupBox.Controls.Clear();
        //    }
        //    groups.Clear();
        //}
        private void ClearGroupBoxs()
        {
            foreach (var groupBox in groups)
            {
                this.Controls.Remove(groupBox);
                groupBox.Dispose(); 
            }
            groups.Clear();
            labels.Clear();
            checkboxes.Clear();
        }
        private void SelectDate_ValueChanged(object sender, EventArgs e)
        {
            //ClearLabels();
            //ClearGroupBoxs();
            LoadAppointments();
            //    using (var db = new MyDbContext())
            //    {
            //        var day = SelectDate.Value.Date.Subtract(DateTime.Now.Date).TotalDays;
            //        var appointments = db.Appointments.AsQueryable().Where(a => a.ObjectId == _exhibitionId && a.Day == day).ToArray();
            //        var exhibitions = db.Exhibitions.AsQueryable().Where(i => i.id == _exhibitionId).FirstOrDefault();
            //        if (exhibitions != null)
            //        {

            //            for (int b = 0; b < appointments.Length; b++)
            //            {
            //                GroupBox groupBox = new GroupBox();

            //                groupBox.Location = new Point(12, b * 35 + 147);
            //                groupBox.Size = new Size(600,40);
            //                groupBox.Text = "";
            //                CheckBox checkBox = new CheckBox();
            //                checkBox.AutoSize = true;
            //                checkBox.Location = new Point(430,10);
            //                checkBox.Text = "选择";

            //                Label label = new Label();
            //                label.AutoSize = true;
            //                label.Location = new Point(0, 10);
            //                label.Text = string.Format("时间{0} 余票{1} ￥{2:F2}",
            //                appointments[b].StartTime.ToShortTimeString() + " " + appointments[b].EndTime.ToShortTimeString(), appointments[b].amount, exhibitions.basicPrice);

            //                groupBox.Controls.Add(label);
            //                labels.Add(label);
            //                checkboxes.Add(checkBox);
            //                groupBox.Controls.Add(checkBox);
            //                groups.Add(groupBox);
            //                this.Controls.Add(groupBox);

            //            }

            //        }

            //    }
            //}

        }
    }
}


   
