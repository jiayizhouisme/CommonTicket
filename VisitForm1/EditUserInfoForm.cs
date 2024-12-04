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

namespace VisitForm1
{
    public partial class EditUserInfoForm : Form
    {

        public EditUserInfoForm()
        {
            InitializeComponent();
        }
        private void Submit_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                int userIdToUpdate = LogInInfo.id;           
                var userInfo = context.UserInfos.FirstOrDefault(u => u.UserId == userIdToUpdate);
                if (userInfo == null)
                {
                    MessageBox.Show("未找到用户");
                    return;
                }              
                userInfo.Name = textBox2.Text;
                userInfo.IdCard = textBox3.Text;
                userInfo.PhoneNumber = textBox4.Text;
                try
                {                  
                    context.SaveChanges();
                    MessageBox.Show("修改成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("修改失败");                  
                }
            }
        }
    }
}

