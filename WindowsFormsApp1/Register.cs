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

namespace WindowsFormsApp1
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=E:\LABS\WINDOWSFORMSAPP1\WINDOWSFORMSAPP1\DATABASE1.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            string loginUser = (string)inputLogin.Text.ToString();
            string passwordUser = (string)inputPassword.Text.ToString();

            AccountVerification(loginUser, passwordUser);

            connection.Open();
            string query = $"INSERT INTO Users (Login, Password) values ('{loginUser}', '{passwordUser}')";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();

            

        }

        private void AccountVerification(string loginUser, string passwordUser)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=E:\LABS\WINDOWSFORMSAPP1\WINDOWSFORMSAPP1\DATABASE1.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string query = $"SELECT Login, Password From Users Where Login = '{loginUser}' AND Password = '{passwordUser}'";

            SqlCommand command = new SqlCommand(query, connection);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Такой аккаунт уже существует", "Провал", MessageBoxButtons.OK);
            }

            connection.Close();
        }
    }
    }

