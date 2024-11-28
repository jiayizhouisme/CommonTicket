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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Online1
{
    public partial class Form2 : Form
    {
        string oldname;
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CommonTicket2;user id=sa;password=Aa123456;TrustServerCertificate=true");
        public Form2(string id, string name, string description, string beforeDays)
        {
            InitializeComponent();
            ID1.Text = id;
            Name1.Text = name;
            oldname = name;
            Description1.Text = description;
            BeforeDays1.Text = beforeDays;
            Submit.Click += Submit_Click;
        }
        private void Submit_Click(object sender, EventArgs e)
        {
            object rawIdValue = ID1.Text;
            Guid? id = null;
            if (Guid.TryParse(rawIdValue?.ToString(), out Guid parsedGuid))
            {
                id = parsedGuid;
            }
            if (id.HasValue)
            {
                using (var ctx = new MyDbContext())
                {                 
                    var exhibition = ctx.Exhibitions.FirstOrDefault(e => e.id == id.Value);
                    if (exhibition != null)
                    {
                        exhibition.name = Name1.Text;
                        exhibition.description = Description1.Text;
                        exhibition.beforeDays = int.Parse(BeforeDays1.Text);
                        try
                        {
                            ctx.SaveChanges();
                            MessageBox.Show("修改成功");
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("修改失败 ");
                        }
                    }

                }
            }

        }
    }
}
    


