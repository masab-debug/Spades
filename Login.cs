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
    public partial class Login : Form
    {
        
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
        Class1 session_store = new Class1();
        public static string session;
        public static int session_id;
        public static string session_dept;

        public Login()
        {
            InitializeComponent();
        }
        
        
        private void Login_emp_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;

            string Username_valid = Username.Text;
            string Email_valid = Email.Text;
            string Password_valid = Password.Text;
            string Department_valid = comboBox1.Text;

            if (!string.IsNullOrWhiteSpace(Username_valid) && !string.IsNullOrWhiteSpace(Email_valid) && !string.IsNullOrWhiteSpace(Password_valid))
            {
                Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                if (reg.IsMatch(Email_valid))
                {
                    string sqlstate = commands.CommandText = "SELECT * FROM signup WHERE(Username = '" + Username_valid + "' AND Email = '" + Email_valid + "' AND Password_employee = '" + Password_valid + "' AND Department = '" + Department_valid + "')";
                    SqlDataAdapter fetcher = new SqlDataAdapter(sqlstate, connection);
                    DataTable validator = new DataTable();
                    fetcher.Fill(validator);
                    if (validator.Rows.Count == 1)
                    {

                        Class1.Session = Username_valid;
                        session = Class1.Session;
                        int retrieve = Convert.ToInt32(commands.ExecuteScalar());
                        Class1.Session_id = retrieve;
                        session_id = Class1.Session_id;
                        Class1.Session_dept = Department_valid;
                        session_dept = Class1.Session_dept;


                        MessageBox.Show(session + " Welcome From " + session_dept); ;
                        this.Hide();
                        dashboardemp demp = new dashboardemp();
                        demp.ShowDialog();
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid");
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Please Input Valid Email");
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Spades signup = new Spades();
            signup.ShowDialog();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void username_enter(object sender, EventArgs e)
        {
            if (Username.Text == "Username")
            {
                Username.Text = "";
                Username.ForeColor = Color.White;
            }
        }

        private void username_leave(object sender, EventArgs e)
        {
            if (Username.Text == "")
            {
                Username.Text = "Username";
                Username.ForeColor = Color.White;
            }
        }

        private void email_enter(object sender, EventArgs e)
        {
            if (Email.Text == "email@email.domain")
            {
                Email.Text = "";
                Email.ForeColor = Color.White;
            }
        }

        private void email_leave(object sender, EventArgs e)
        {
            if (Email.Text == "")
            {
                Email.Text = "email@email.domain";
                Email.ForeColor = Color.White;
            }
        }
    }
}
