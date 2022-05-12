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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            depart_r();
        }

        private static SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=localhost; Integrated Security=SSPI; Initial Catalog=Publish_house;");
        }

        SqlConnection connect = GetConnection();
        SqlDataAdapter adapter;

        void depart_r()
        {
            connect.Open();
            DataTable dataTable = new DataTable();
            adapter = new SqlDataAdapter("select respons_emp_id as Ответственный_сотрудник, e.name as Сотрудник, e.post as Должность from depart_r d join employee e on e.employee_id=d.employee_id;", connect);
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
            depart_r();
        }
    }
}
