using Microsoft.Data.SqlClient;
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
    public partial class RegisterForm : Form
    {
        private const string ConnectionString = "Data Source=.;Initial Catalog=CommonTicket1;user id=sa;password=Aa123456;TrustServerCertificate=true";
        private const string CheckUserQuery = "SELECT COUNT(*) FROM [User] WHERE userName=@userName AND Password=@passwordHash";
        private const string InsertUserQuery = "INSERT INTO [User] (userName, Password) VALUES (@userName, @passwordHash)";
        public RegisterForm()
        {
            InitializeComponent();

        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password ));
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

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using (SqlCommand checkCmd = new SqlCommand(CheckUserQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@userName", userName);
                    checkCmd.Parameters.AddWithValue("@passwordHash", hashedPassword);

                    int userCount = (int)checkCmd.ExecuteScalar();

                    if (userCount == 0)
                    {
                        using (SqlCommand insertCmd = new SqlCommand("INSERT INTO [User] (userName, Password) VALUES (@userName, @passwordHash)", conn))
                        {
                            insertCmd.Parameters.AddWithValue("@userName", userName);
                            insertCmd.Parameters.AddWithValue("@passwordHash", hashedPassword);            
                            try
                            {
                                insertCmd.ExecuteNonQuery();
                                MessageBox.Show("注册成功！");
                                this.Close();
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show("注册失败!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("用户已存在，请登录！");
                    }
                }
            }
        }
        
    }
}


