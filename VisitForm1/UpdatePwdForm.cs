using _222222;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisitForm1
{
    public partial class UpdatePwdForm : Form
    {
        private readonly int _currentUserId;
        private  MyDbContext _context;
        public UpdatePwdForm(int currentUserId, MyDbContext context)
        {
            InitializeComponent();
            _currentUserId = currentUserId;
            _context = context;
        }
        private bool ValidateOldPassword(string username, string oldPwd)
        {
            var user = _context.Users.FirstOrDefault(u => u.username == username && u.password == HashPassword(oldPwd));
            return user != null;
        }
        private bool UpdatePassword(string username, string newPwd)
        {
            using (var db = new MyDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.username == username);
                if (user != null)
                {
                    user.password = HashPassword(newPwd);
                    int result = db.SaveChanges();
                    return result > 0;
                }
                return false;
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {

            string OldPwd = textBox4.Text;
            string NewPwd = textBox1.Text;
            string NewPwd2 = textBox2.Text;

            if (NewPwd == OldPwd)
            {
                MessageBox.Show("新旧密码不能相同，请重新输入");
                return;
            }
            if (!string.IsNullOrEmpty(NewPwd) && NewPwd == NewPwd2)
            {
                using ( _context = new MyDbContext())
                {
                    bool isValid = ValidateOldPassword(LogInInfo.username, OldPwd);
                    if (isValid)
                    {
                        bool updateSuccess = UpdatePassword(LogInInfo.username, NewPwd);
                        if (updateSuccess)
                        {
                            MessageBox.Show("密码修改成功！");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("密码修改失败，请重试");
                        }
                    }
                    else
                    {
                        MessageBox.Show("用户ID无效，请重试");
                    }
                }
            }
            else
            {
                MessageBox.Show("用户名或旧密码错误，请重试");
            }         
        
        }
        private static string HashPassword(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
    


}
    }


