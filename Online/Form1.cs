using System.ComponentModel;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Online
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Tickettype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTime_ValueChanged(object sender, EventArgs e)
        {
            string selectedDateTime = dateTime.Value.ToString("year-month-day ");
            MessageBox.Show("您选择的日期和时间是：" + selectedDateTime);
        }

        private void Ticketstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Name_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Name.Text))
            {
                if (Name.Text == "") MessageBox.Show("请输入姓名");
                else
                {
                    MessageBox.Show("请输入正确的姓名");
                }
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Name.Text))
            {
                if (Name.Text == "") MessageBox.Show("请输入姓名");
                else
                {
                    MessageBox.Show("请输入正确的姓名");
                }
            }
        }
    }
}

