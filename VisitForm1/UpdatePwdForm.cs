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
        private static readonly string connectionString = "Data Source=.;Initial Catalog=CommonTicket1;User Id=sa;Password=Aa123456;TrustServerCertificate=true";
        private readonly MyDbContext _context;
        public UpdatePwdForm()
        {
            InitializeComponent();
            _context = new MyDbContext();
        }
       
        private static bool SimulatePasswordUpdate(string NewPwd2)
        {
            bool updateSuccess = false;
            string hashedPassword = HashPassword(NewPwd2);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string updateQuery = "UPDATE Users SET Password = @NewPwd WHERE UserId = @UserId";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NewPassword", hashedPassword);

                        int rowsAffected = command.ExecuteNonQuery();
                        updateSuccess = rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine("更新密码时发生错误: ");

                }
            }
            return true;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string UserId =textBox3.Text;
            string OldPwd =textBox4.Text;
            string NewPwd = textBox1.Text;
            string NewPwd2 = textBox2.Text;
            string hashedPassword = HashPassword(textBox2.Text);
            if (!string.IsNullOrEmpty(NewPwd) && NewPwd == NewPwd2)
            {
                bool updateSuccess = SimulatePasswordUpdate(NewPwd2);

                if (updateSuccess)
                {
                    MessageBox.Show("密码修改成功！");

                    this.Close();
                }
                else
                {
                    MessageBox.Show("密码修改失败，请重试。");
                }
            }
            else
            {
                MessageBox.Show("新密码两次输入不一致，请重新输入");
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


