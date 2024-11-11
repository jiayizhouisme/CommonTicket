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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Online1
{
    public partial class AddExhibitionForm : Form
    {
        public AddExhibitionForm()
        {
            InitializeComponent();



        }

        private void Submit_Click(object sender, EventArgs e)
        {
            var sql = "INSERT [dbo].[Exhibition] ([id], [name], [description], [imgs], [status], [isDeleted], [createTime], [basicPrice], [passType], [isMultiPart], [exhibitions], [beforeDays], [forbiddenRule], [totalAmount])" +
                  " VALUES (N'{0}', N'{1}', N'{2}', NULL, {3}, 0, CAST(N'2024-01-23T14:56:48.5729222' AS DateTime2), CAST({4} AS Decimal(18, 2)), 1, 0, NULL, {5}, NULL, {6})";
            var insertsql = string.Format(sql, Guid.NewGuid().ToString(), "测试展馆", "uhuhdu", "1", "10.00", "0", "1000");
 
        }
     
    }
    }

