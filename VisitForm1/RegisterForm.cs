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
using VisitForm1._222222;

namespace VisitForm1
{
    public partial class RegisterForm : Form
    {
        private readonly MyDbContext _context;       
        public RegisterForm()
        {
            InitializeComponent();
            _context = new MyDbContext();
        }
        private string HashPassword(string password)
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

        private void Login_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;
            string hashedPassword = HashPassword(password);

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("用户名和密码不能为空");
                return;
            }

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("确认密码不能为空!");
                return;
            }

            if (password != textBox3.Text)
            {
                MessageBox.Show("密码和确认密码不相符!");
                textBox2.Clear();
                textBox3.Clear();
                return;
            }
            var existingUser =  _context.Users.FirstOrDefaultAsync(u => u.username == userName && u.password == hashedPassword);

            if (existingUser == null)
            {
                var newUser = new Users
                {
                    username = userName,
                    password = hashedPassword
                };
                try
                {
                    _context.Users.AddAsync(newUser);
                    _context.SaveChangesAsync();
                    MessageBox.Show("注册成功！");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("注册失败: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("用户已存在，请登录！");
            }
        }
    }
}





