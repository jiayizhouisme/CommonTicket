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

namespace Online1
{
    public partial class Form2 : Form
    {
        string oldname;
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CommonTicket2;user id=sa;password=Aa123456;TrustServerCertificate=true");
        public Form2(  string id,string name, string description, string beforeDays)
        {
            InitializeComponent();
            ID1.Text=id;
            Name1.Text = name;
            oldname = name;//更新数据库之前的值
            Description1.Text = description;
            BeforeDays1.Text = beforeDays;
            Submit.Click += Submit_Click;
        }
        private void Submit_Click(object sender, EventArgs e)
        {        

            var sql = "UPDATE Exhibition SET description='{1}',beforeDays='{2}',name='{3}' WHERE id ='{0}'";
            var updatesql = string.Format(sql, ID1.Text, Description1.Text,BeforeDays1.Text,Name1.Text);
            using (SqlCommand command = new SqlCommand(updatesql, conn))
            {
                conn.Open();
                command.ExecuteNonQuery();

                conn.Close();
            }
        }
    }
}
