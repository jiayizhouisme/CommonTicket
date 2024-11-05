using System;
using System.Reflection.Metadata.Ecma335;

namespace Online1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DataGridViewRow row = new DataGridViewRow(); 
            int j = dataGridView1.Rows.Add(row);//添加新的一行
            dataGridView1.Rows[j].Cells[0].Value = "赵谦孙俪";//姓名
            dataGridView1.Rows[j].Cells[1].Value = "18252111111"; //手机 
            dataGridView1.Rows[j].Cells[2].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);//设置字体加粗

            row = new DataGridViewRow();//添加新的一行
            j = dataGridView1.Rows.Add(row);//j调用方法后加1
            dataGridView1.Rows[j].Cells[0].Value = "周武正王";
            dataGridView1.Rows[j].Cells[1].Value = "18252111112";
            dataGridView1.Rows[j].Cells[2].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);//设置字体加粗
        }

        private void Type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            string selectedDateTime = dateTimePicker.Value.ToString("year-month-day ");
            MessageBox.Show("您选择的日期和时间是：" + selectedDateTime);
        }

        private void State_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show("请输入姓名");
                return;
            }
        }
        private void Search_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

