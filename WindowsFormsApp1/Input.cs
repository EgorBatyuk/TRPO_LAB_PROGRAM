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
    public partial class Input : Form
    {
        public Input()
        {
            InitializeComponent();
        }

        private void LoadHintLogin(object sender, EventArgs e)
        {
            if (inputLogin.Text == "")
            {
                inputLogin.Text = "логин";//подсказка
                inputLogin.ForeColor = Color.Gray;
            }

            if (inputPassword.Text == "")
            {
                inputPassword.Text = "пароль";//подсказка
                inputPassword.ForeColor = Color.Gray;
            }
        }

        private void HideLoadHintLogin(object sender, EventArgs e)
        {
            if (inputLogin.Text == "логин")
            {
                inputLogin.Text = null;
                inputLogin.ForeColor = Color.Black;
            }

        }

        //private void ShowLoginHintLeave(object sender, EventArgs e)
        //{
        //    if (inputPassword.Text == "")
        //    {
        //        inputLogin.Text = "логин";//подсказка
        //        inputLogin.ForeColor = Color.Gray;
        //    }
        //}

        private void HideLoadHintPassword(object sender, EventArgs e)
        {
            if (inputPassword.Text == "пароль")
            {
                inputPassword.Text = null;
                inputPassword.ForeColor = Color.Black;
            }

        }

        private void ShowPasswordHintLeave(object sender, EventArgs e)
        {
            if (inputPassword.Text == "")
            {
                inputPassword.Text = "пароль";//подсказка
                inputPassword.ForeColor = Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=E:\LABS\WINDOWSFORMSAPP1\WINDOWSFORMSAPP1\DATABASE1.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            var loginUser = inputLogin.Text;
            var passwordUser = inputPassword.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string query = $"SELECT Login, Password From Users Where Login = '{loginUser}' AND Password = '{passwordUser}'";
            
            SqlCommand command = new SqlCommand(query, connection);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли", "Успешно", MessageBoxButtons.OK);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            this.Hide();

            Register register = new Register();
            register.Show();
        }
    }
}
