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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using _222222;
using 通用订票.Core.Entity;

namespace Online1
{
    public partial class AddExhibitionForm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CommonTicket2;user id=sa;password=Aa123456;TrustServerCertificate=true");
        public AddExhibitionForm()
        {
            InitializeComponent();         
            Submit.Click += Submit_Click;
        }
        private void Submit_Click(object sender, EventArgs e)
        {          
            using (var context = new MyDbContext())
            {
                var exhibition = new Exhibition
                {
                    id = Guid.NewGuid(),
                    name = Name1.Text,
                    description = Description1.Text,
                    status = int.Parse(Status1.Text),
                    createTime = DateTime.Parse("2024-01-23T14:56:48.5729222"),
                    basicPrice = decimal.Parse(BasicPrice1.Text),
                    passType = (PassTemplate)1,
                    isMultiPart = false,
                    beforeDays = int.Parse(BeforeDays1.Text),
                    totalAmount = int.Parse(TotalAmount1.Text)
                };               
                try
                {
                    context.Exhibitions.Add(exhibition);
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












