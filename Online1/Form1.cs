using System;
using System.Reflection.Metadata.Ecma335;

namespace Online1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            string selectedDateTime = dateTimePicker.Value.ToString("year-month-day ");
            MessageBox.Show("��ѡ������ں�ʱ���ǣ�" + selectedDateTime);
        }

        private void State_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if(textBox.Text == "")
            {
                MessageBox.Show("����������");
                return;
            }
        }
        private void Search_Click(object sender, EventArgs e)
        {

        }
    }
}

