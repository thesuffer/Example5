using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Publish_home
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            author();
        }

        private static SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=localhost; Integrated Security=SSPI; Initial Catalog=Publish_house;");
        }

        SqlConnection connect = GetConnection();
        SqlDataAdapter adapter;

        void author()
        {
            connect.Open();
            DataTable dataTable = new DataTable();
            adapter = new SqlDataAdapter("select name as ФИО, psev as Псевдоним, phone_number as Номер_телефона, email as Электронная_почта from author;", connect);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connect.Close();
        }

        void Insert()
        {
            connect.Open();
            DataTable dataTable = new DataTable();
            adapter = new SqlDataAdapter("insert into author(name, psev, phone_number, email) values('"+textBox1.Text+ "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "'); select name as ФИО, psev as Псевдоним, phone_number as Номер_телефона, email as Электронная_почта from author;", connect);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connect.Close();
        }

        void delete()
        {
            connect.Open();
            DataTable dataTable = new DataTable();
            adapter = new SqlDataAdapter("delete author where name='"+comboBox1.Text+ "'; select name as ФИО, psev as Псевдоним, phone_number as Номер_телефона, email as Электронная_почта from author;", connect);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connect.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            //this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            author();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Insert();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }

}
