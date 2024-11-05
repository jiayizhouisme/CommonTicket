using System;
using System.Data;
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
            //获取所有的表名
            tables = Sql("SELECT TABLE_NAME FROM  INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'");
            //增加门票
            DataRow dr = Type.NewRow();
            dr["TABLE_NAME"] = "马家荡景区门票";
            tables.Rows.InsertAt(dr, 0);
            //绑定下拉菜单
            cbxTables.DataSource = tables;
            cbxTables.DisplayMember = "TABLE_NAME";
            cbxTables.ValueMember = "TABLE_NAME";
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

       
    }
}

