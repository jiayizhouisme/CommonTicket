using _222222;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace VisitForm1
{
    public partial class LogonForm : Form
    {

        public LogonForm()
        {
            InitializeComponent();
    }

        private void Register_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }
        private void Logon_Click(object sender, EventArgs e)
        {
            string UserName = textBox1.Text;
            string PassWord = textBox2.Text;
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("用户名和密码不能为空");
                return;
            }
        
            using (var context = new MyDbContext())
            {
                string hashedPassword = HashPassword(textBox2.Text);

               
                var user = context.Users .FirstOrDefaultAsync(u => u.username == UserName && u.password == hashedPassword);

                if (user != null)
                {                  
                    MessageBox.Show(this, "恭喜你，成功登录");
                    ExhibitionForm exhibitionForm = new ExhibitionForm();
                    exhibitionForm.Show();
                }
                else
                {                  
                    MessageBox.Show(this, "用户名或密码不正确，请重新输入！");
                }
            }
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

        private void Updatepassword_Click(object sender, EventArgs e)
        {
            UpdatePwdForm updatePwdForm = new UpdatePwdForm();
            updatePwdForm.ShowDialog();
        }
    }
}
