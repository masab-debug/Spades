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
    public partial class staff_login : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
        public static int staff_id;
        public static string staff_dept;
        public static string staff_user;



        public staff_login()
        {
            InitializeComponent();
        }

        private void Signup_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;

            string Username_valid = Username.Text;
            string Email_valid = Email.Text;
            string Password_valid = Password.Text;
            string Deparment_valid = comboBox1.Text;

            if (!string.IsNullOrEmpty(Username_valid) && !string.IsNullOrEmpty(Email_valid) && !string.IsNullOrEmpty(Password_valid) && !string.IsNullOrEmpty(Deparment_valid))
            {
                Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                if (reg.IsMatch(Email_valid))
                {
                    string sqlstate = commands.CommandText = "SELECT * FROM signup_staff WHERE(Username = '" + Username_valid + "' AND Email = '" + Email_valid + "' AND Password_staff = '" + Password_valid + "' AND Deparment_head = '" + Deparment_valid + "')";
                    SqlDataAdapter fetcher = new SqlDataAdapter(sqlstate, connection);
                    DataTable validator = new DataTable();
                    fetcher.Fill(validator);
                    if (validator.Rows.Count == 1)
                    {
                        Class1.staff_dept_session = Deparment_valid;
                        staff_dept = Class1.staff_dept_session;
                        Class1.staff_username_session = Username_valid;
                        staff_user = Class1.staff_username_session;
                        int retrieve = Convert.ToInt32(commands.ExecuteScalar());
                        Class1.staff_session = retrieve;
                        staff_id = Class1.staff_session;
                        MessageBox.Show("Welcome " + staff_user + " Staff Member");
                        this.Hide();
                        staff_dashboard dashboard = new staff_dashboard();
                        dashboard.Show();
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
            else
            {
                MessageBox.Show("Please fill all fields");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            staff_signup signup = new staff_signup();
            signup.Show();
        }

        private void staff_login_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }
        //placeholder winfrm
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
            if (Email.Text == "email@email.com")
            {
                Email.Text = "";
                Email.ForeColor = Color.White;
            }
        }

        private void email_leave(object sender, EventArgs e)
        {
            if (Email.Text == "")
            {
                Email.Text = "email@email.com";
                Email.ForeColor = Color.White;
            }
        }
    }
}
