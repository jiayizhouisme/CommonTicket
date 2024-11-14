using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online1
{
    public partial class Form2 : Form
    {
        public Form2(string name,string description,string beforeDays)
        {
            InitializeComponent();
            Name1.Text= name;    
            Description1.Text= description;
            BeforeDays1.Text= beforeDays;    

        }
    }
}
