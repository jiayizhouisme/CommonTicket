using _222222;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace VisitForm1
{
    public partial class LogonForm : Form
    {
        private MyDbContext _context;
        private int _currentUserId;
      

        public LogonForm(MyDbContext context, int currentUserId) : this()
        {

            _context = context;
            _currentUserId = currentUserId;
        }
        public LogonForm()
        {
            InitializeComponent();
            _context = new MyDbContext();
          
        }
       

        private void Register_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }
        private async void Logon_Click(object sender, EventArgs e)
        {
            string UserName = textBox1.Text;
            string PassWord = textBox2.Text;
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(PassWord))
            {
                MessageBox.Show("用户名和密码不能为空");
                return;
            }
            string hashedPassword = HashPassword(PassWord);
            using (_context = new MyDbContext())
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.username == UserName && u.password == hashedPassword);
                if (user != null)
                {
                    LogInInfo.username = UserName;
                    LogInInfo.id = user.id;
                    MessageBox.Show(this, "成功登录！");
                    ExhibitionForm1 exhibitionForm1 = new ExhibitionForm1();
                    exhibitionForm1.Show();
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
            UpdatePwdForm updatePwdForm = new UpdatePwdForm(_currentUserId, _context);
            updatePwdForm.ShowDialog();
        }
      
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}
