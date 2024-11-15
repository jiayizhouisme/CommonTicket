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
            "SET [name]='1' AND [description]=2  AND [status]=3 AND  [beforeDays]=5 AND  [totalAmount]=6 " +
            "WHERE [id]=0";
          
            var updatesql = string.Format(sql, Guid.NewGuid().ToString(),ID.Text, Name.Text, Description.Text, Status.Text, BasicPrice.Text, BeforeDays.Text, TotalAmount.Text);

            using (SqlCommand command = new SqlCommand(updatesql, conn))
            {
                conn.Open();
                command.ExecuteNonQuery();

            }
        }
    }
}

