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

            DataGridViewRow row = new DataGridViewRow(); 
            int j = dataGridView1.Rows.Add(row);//����µ�һ��
            dataGridView1.Rows[j].Cells[0].Value = "��ǫ��ٳ";//����
            dataGridView1.Rows[j].Cells[1].Value = "18252111111"; //�ֻ� 
            dataGridView1.Rows[j].Cells[2].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);//��������Ӵ�

            row = new DataGridViewRow();//����µ�һ��
            j = dataGridView1.Rows.Add(row);//j���÷������1
            dataGridView1.Rows[j].Cells[0].Value = "��������";
            dataGridView1.Rows[j].Cells[1].Value = "18252111112";
            dataGridView1.Rows[j].Cells[2].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);//��������Ӵ�
        }

        private void Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            //��ȡ���еı���
            tables = Sql("SELECT TABLE_NAME FROM  INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'");
            //������Ʊ
            DataRow dr = Type.NewRow();
            dr["TABLE_NAME"] = "��ҵ�������Ʊ";
            tables.Rows.InsertAt(dr, 0);
            //�������˵�
            cbxTables.DataSource = tables;
            cbxTables.DisplayMember = "TABLE_NAME";
            cbxTables.ValueMember = "TABLE_NAME";
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
            if (textBox.Text == "")
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

