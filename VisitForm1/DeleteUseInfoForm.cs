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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VisitForm1
{
    public partial class DeleteUseInfoForm : Form
    {
        private long _userId;       
        public DeleteUseInfoForm(long userId) : this()
        {
            _userId = userId;
            InitializeComponent();
           // this.Delete.Click += new EventHandler(Delete_Click);
        }
        public DeleteUseInfoForm()
        {
            InitializeComponent();
        }

        public void ExecuteDelete()
        {
            DeleteUserInfo();
        }
        private void DeleteUserInfo()
        {
            using (var context = new MyDbContext())
            {
                var userInfo = context.UserInfos.FirstOrDefault(u => u.UserId == LogInInfo.id);

                if (userInfo == null)
                {
                    MessageBox.Show("未找到对应的用户信息");
                    return;
                }

                try
                {
                    context.UserInfos.Remove(userInfo);
                    context.SaveChanges();
                    MessageBox.Show("删除成功");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除失败: " + ex.Message);
                }
            }
        }
    }
}




