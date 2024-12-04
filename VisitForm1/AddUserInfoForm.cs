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
using VisitForm1._222222.Model;

namespace VisitForm1
{
    public partial class AddUserInfoForm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CommonTicket1;user id=sa;password=Aa123456;TrustServerCertificate=true");
        public AddUserInfoForm()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                var userInfo = new UserInfos
                {                
                    Name = textBox2.Text,
                    IdCard = textBox3.Text,
                    PhoneNumber = textBox4.Text,
                    UserId =LogInInfo.id,
                };
                try
                {
                    context.UserInfos.Add(userInfo);
                    context.SaveChanges();
                    MessageBox.Show("添加成功");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("添加失败");

                }
            }
        }
    }
}
