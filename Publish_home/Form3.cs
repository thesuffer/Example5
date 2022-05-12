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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            author_workr();
        }

        private static SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=localhost; Integrated Security=SSPI; Initial Catalog=Publish_house;");
        }

        SqlConnection connect = GetConnection();
        SqlDataAdapter adapter;

        void author_workr()
        {
            connect.Open();
            DataTable dataTable = new DataTable();
            adapter = new SqlDataAdapter("select a.name as Автор, aw.name as Наименование_произведения, aw.type as Тип_произведения from author_work aw join author a on aw.author_id=a.author_id;", connect);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connect.Close();
        }

        void Insert()
        {
            connect.Open();
            DataTable dataTable = new DataTable();
            adapter = new SqlDataAdapter("insert into author_work(author_id, name, type) values(" + textBox1.Text + ", '" + textBox2.Text + "', '" + textBox3.Text + "'); select a.name as Автор, aw.name as Наименование_произведения, aw.type as Тип_произведения from author_work aw join author a on aw.author_id=a.author_id;", connect);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            connect.Close();
        }

        void delete()
        {
            connect.Open();
            DataTable dataTable = new DataTable();
            adapter = new SqlDataAdapter("delete author_work where name='" + comboBox1.Text + "'; select a.name as Автор, aw.name as Наименование_произведения, aw.type as Тип_произведения from author_work aw join author a on aw.author_id=a.author_id;", connect);
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
            author_workr();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Insert();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delete();
        }
    }
}
