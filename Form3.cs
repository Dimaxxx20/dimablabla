using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(); // This is bad
            f.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Книга добавлена!");
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Data\MyDatabase.accdb;";
            string query = "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", txtName.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            LoadData();
            txtName.Clear();
            txtEmail.Clear();
        }

        private void LoadData()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\3 курс\Тимонина\Проект!!!";
            string query = "SELECT * FROM Users";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView.DataSource = table;
                }
            }
        }
    }
}