using _222222;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisitForm1._222222.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VisitForm1
{
    public partial class DeleteUseInfoForm : Form
    {
        public DeleteUseInfoForm()
        {
            InitializeComponent();
            this.Delete.Click += new EventHandler(Delete_Click);
        }

        private void Delete_Click(object sender, EventArgs e)
        {

        }
    }
}
           

