﻿using Microsoft.Data.SqlClient;
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
    public partial class UpdateExhibitionForm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CommonTicket2;user id=sa;password=Aa123456;TrustServerCertificate=true");
        public UpdateExhibitionForm()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            var sql = "UPDATE [dbo].[Exhibition] " +
            "SET [name]='1' AND [description]=2 AND [imgs] IS Null AND [status]=3 AND [isDeleted]=0 AND  CAST([createTime] AS DateTime2)='2024-01-23T14:56:48.5729222' AND CAST([basicPrice] AS Decimal(18, 2))=4.00  AND [passType]=1 AND [isMultiPart]=0 AND [exhibitions] IS Null AND [beforeDays]=5 AND [forbiddenRule] IS Null AND [totalAmount]=6 " +
            "WHERE [id]=0";
          
            var updatesql = string.Format(sql, Guid.NewGuid().ToString(), Name.Text, Description.Text, Status.Text, BasicPrice.Text, BeforeDays.Text, TotalAmount.Text);

            using (SqlCommand command = new SqlCommand(updatesql, conn))
            {
                conn.Open();
                command.ExecuteNonQuery();

            }
        }
    }
}

