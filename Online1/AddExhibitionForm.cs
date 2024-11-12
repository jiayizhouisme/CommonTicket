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

namespace Online1
{
    public partial class AddExhibitionForm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CommonTicket2;user id=sa;password=Aa123456;TrustServerCertificate=true");
        public AddExhibitionForm()
        {
            InitializeComponent();
        }
        private void Submit_Click(object sender, EventArgs e)
        {
            var sql = "INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount])" +
            " VALUES (N'{0}', N'{1}', N'{2}', NULL, {3}, 0, CAST(N'2024-01-23T14:56:48.5729222' AS DateTime2), CAST({4} AS Decimal(18, 2)), 1, 0, NULL, {5}, NULL, {6})";
            var insertsql = string.Format(sql, Guid.NewGuid().ToString(), Name1.Text, Description1.Text, Status1.Text, BasicPrice1.Text, BeforeDays1.Text, TotalAmount1.Text);

            using (SqlCommand command = new SqlCommand(insertsql, conn))
            {
                conn.Open();
                 command.ExecuteNonQuery();
               
                }
            }
        }
    }

          
    




