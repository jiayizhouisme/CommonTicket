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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Online1
{
    public partial class DeleteExhibitionForm : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CommonTicket2;user id=sa;password=Aa123456;TrustServerCertificate=true");
        public DeleteExhibitionForm()
        {
            InitializeComponent();
        }
        private void Submit_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                Guid exhibitionId;
                if (Guid.TryParse(ID.Text, out exhibitionId))
                {
                    var exhibition = context.Exhibitions.Find(exhibitionId);
                    if (exhibition != null)
                    {
                        context.Exhibitions.Remove(exhibition);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}












