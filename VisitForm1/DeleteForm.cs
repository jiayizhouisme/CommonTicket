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

namespace VisitForm1
{
    public partial class DeleteForm : Form
    {
        
        public DeleteForm()
        {
            InitializeComponent();
            this.Submit.Click += new EventHandler(Submit_Click);
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            Guid exhibitionId;
          
            if (Guid.TryParse(this.IdtextBox.Text, out exhibitionId))
            {
                using (var context = new MyDbContext())
                {
                    
                    var exhibition = context.Exhibitions.Find(exhibitionId);
                    if (exhibition != null)
                    {
                      
                        context.Exhibitions.Remove(exhibition);
                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("删除成功");
                           
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                           
                            MessageBox.Show("删除失败: " + ex.Message);
                        }
                    }
                }
                }
            }
        }
    }

