using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\WindowsFormsApp1\WindowsFormsApp1\Database.mdf;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // SqlCommand command = new SqlCommand("SELECT * From Movie", connection);
            //connection.Open();

            //SqlDataReader reader = command.ExecuteReader();

            //dataGridView1.Columns.Add("column-1", "id");
            //dataGridView1.Columns.Add("column-2", "Название фильма");
            //dataGridView1.Columns.Add("column-3", "Жанр");
            //dataGridView1.Columns.Add("column-4", "Продолжительность");
            //dataGridView1.Columns.Add("column-5", "Дата старта показа");
            //dataGridView1.Columns.Add("column-6", "Дата завершения показа");
            //dataGridView1.Columns.Add("column-7", "Возрастные ограничения");

            //while (reader.Read())
            //{
            //    dataGridView1.Rows.Add(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6));
            //}
            //reader.Close();
            //connection.Close();
            Move();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query = $"Insert into Movie (Name) values ('{dataGridView1.CurrentRow.Cells[1].Value}')";
            SqlCommand sqlCommand = new SqlCommand(query, connection);   
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            Move();

        }

        void Move()
        {
            connection.Open();
            string query = "SELECT Id, Name as [Название] From Movie";
            SqlDataAdapter adapter = new SqlDataAdapter(query,connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            connection.Close();
            dataGridView1.DataSource = dataTable;
        }
    }
}
 