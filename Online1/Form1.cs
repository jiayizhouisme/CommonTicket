using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing.Text;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;

namespace Online1
{
    public partial class Form1 : Form
    {
        private SqlConnection connection;
        private string connectionString = "Data Source=.;Initial Catalog=MyBBSDb;user id=sa;password=Aa123456;TrustServerCertificate=true;Max Pool Size=64";
        public Form1()
        {
            //��װ����
            InitializeComponent();
            connection = new SqlConnection(connectionString);//�������ݿ�����
        

            DataGridViewRow row = new DataGridViewRow();
            int j = dataGridView1.Rows.Add(row);//����µ�һ��
            dataGridView1.Rows[j].Cells[0].Value="��ǫ��ٳ";//����
            dataGridView1.Rows[j].Cells[1].Value = "18252111111"; //�ֻ� 
            dataGridView1.Rows[j].Cells[2].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);//��������Ӵ�

            row = new DataGridViewRow();//����µ�һ��
            j = dataGridView1.Rows.Add(row);//j���÷������1
            dataGridView1.Rows[j].Cells[0].Value = "��������";
            dataGridView1.Rows[j].Cells[1].Value = "18252111112";
            dataGridView1.Rows[j].Cells[2].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);//��������Ӵ�
        }    
       
        private void Form1_Load(object sender, EventArgs e)
        {
            Type.Items.Add("��ҵ�������Ʊ");
            Type.Items.Add("�¹��Ŵ徰����Ʊ");
            Type.SelectedIndex = 0;
        }
        private void Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = Type.SelectedItem.ToString();
          
            MessageBox.Show("" + selectedOption);
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

