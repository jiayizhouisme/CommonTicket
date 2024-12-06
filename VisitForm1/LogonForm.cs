using _222222;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using VisitForm1.Properties;
using System.Configuration;

namespace VisitForm1
{
        public partial class LogonForm : Form
        {

            private MyDbContext _context;
            private int _currentUserId;
            private string _rememberedUsername;
            private string _rememberedHashedPassword;
        public LogonForm(MyDbContext context, int currentUserId) : this()
            {
                _context = context;
                _currentUserId = currentUserId;
                LoadSettings();        
            }
            public LogonForm()
            {
                InitializeComponent();
                _context = new MyDbContext();

            }
            private void LoadSettings()
            {
                string rememberUserName = ConfigurationManager.AppSettings["RememberUserName"];
                bool shouldRemember = bool.TryParse(rememberUserName, out bool result) && result;
                if (shouldRemember)
                {
                    _rememberedUsername = ConfigurationManager.AppSettings["RememberedUsername"];
                 
                    textBox1.Text = _rememberedUsername;
                }
               
                {
                _rememberedHashedPassword = ConfigurationManager.AppSettings["HashedPassword"];
            }
            }

            private void SaveSettings(string hashedPassword, string rememberedUsername = null)
            {
                ConfigurationManager.AppSettings["HashedPassword"] = hashedPassword;
                ConfigurationManager.AppSettings["RememberUserName"] = (!string.IsNullOrEmpty(rememberedUsername)).ToString();
                if (!string.IsNullOrEmpty(rememberedUsername))
                {
                    ConfigurationManager.AppSettings["RememberedUsername"] = _rememberedUsername ?? string.Empty;
                }
                else
                {
                    ConfigurationManager.AppSettings.Remove("RememberedUsername");
                }
                ConfigurationManager.RefreshSection("appSettings");
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

                    SaveSettings(hashedPassword, UserName);
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
                _rememberedUsername = checkBox1.Checked ? textBox1.Text : null;
           
            }
            }   
        }

    


