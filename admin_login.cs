using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Drawing;

namespace spades
{
    public partial class admin_login : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
        public static string session_admin;
        public static int session_id_admin;
        public admin_login()
        {
            InitializeComponent();
        }
        //admin button click
        private void Login_emp_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;

            string Username_valid = Username.Text;
            string Email_valid = Email.Text;
            string Password_valid = Password.Text;

            if (!string.IsNullOrWhiteSpace(Username_valid) && !string.IsNullOrWhiteSpace(Email_valid) && !string.IsNullOrWhiteSpace(Password_valid))
            {
                Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                if (reg.IsMatch(Email_valid))
                {
                    string sqlstate = commands.CommandText = "SELECT * FROM admin_signup WHERE(Username_admin = '" + Username_valid + "' AND Email_admin = '" + Email_valid + "' AND Password_admin = '" + Password_valid + "')";
                    SqlDataAdapter fetcher = new SqlDataAdapter(sqlstate, connection);
                    DataTable validator = new DataTable();
                    fetcher.Fill(validator);
                    if (validator.Rows.Count == 1)
                    {

                        Class1.Session = Username_valid;
                        session_admin = Class1.Session;
                        int retrieve = Convert.ToInt32(commands.ExecuteScalar());
                        Class1.Session_id = retrieve;
                        session_id_admin = Class1.Session_id;
                        MessageBox.Show(session_admin + " Welcome");
                        admin_dashboard admin = new admin_dashboard();
                        admin.Show();
                        this.Hide();
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error!");
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please Input Valid Email");
                }
            }
        }

        private void admin_login_Load(object sender, EventArgs e)
        {

        }
    }
}
