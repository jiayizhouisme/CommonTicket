using _222222;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public AddUserInfoForm()
        {
            InitializeComponent();         
        }
        private void Submitt_Click(object sender, EventArgs e)
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
                var validationResults = new List<ValidationResult>();
                if (!Validator.TryValidateObject(userInfo, new ValidationContext(userInfo, null, null), validationResults, true))
                {
                    foreach (var result in validationResults)
                    {
                        MessageBox.Show(result.ErrorMessage);
                    }
                    return;
                }
                try
                {
                    context.UserInfos.Add(userInfo);
                    context.SaveChanges();               
                    MessageBox.Show("添加成功");                  
                    this.Close();
                }              
                catch (Exception ex)
                {
                    MessageBox.Show("添加失败");
                }
               
                }
               
            }
        }
    }

