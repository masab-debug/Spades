using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Drawing;

namespace spades
{
    public partial class Spades : Form
    {

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
        public Spades()
        {
            InitializeComponent();
            connection.Open();
        }
        private void Lastname_Text(object sender, EventArgs e)
        {

        }
        private void Spades_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        //firstname
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Signup_Click(object sender, EventArgs e)
        {
            

            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;

            // data passing to variables

            string Firstname_valid = Firstname.Text;
            string Lastname_valid = Lastname.Text;
            string Username_valid = Username.Text;
            string Email_valid = Email.Text;
            string Password_valid = Password.Text;
            string Password_confirm = Password_cf.Text;
            string Department = comboBox1.Text;

            // validations

            if ( !string.IsNullOrWhiteSpace(Firstname_valid) && !string.IsNullOrWhiteSpace(Lastname_valid) && !string.IsNullOrWhiteSpace(Username_valid) && !string.IsNullOrWhiteSpace(Email_valid) && !string.IsNullOrWhiteSpace(Password_valid) && !string.IsNullOrWhiteSpace(Password_confirm) )
            {
                //email validation
                Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                if (reg.IsMatch(Email_valid))
                {
                    if (Password_valid == Password_confirm)
                    {
                        commands.CommandText = "INSERT INTO signup ( Firstname , Lastname , Username , Email , Password_employee , Department) values ('" + Firstname_valid + "','" + Lastname_valid + "','" + Username_valid + "','" + Email_valid + "','" + Password_valid + "','" + Department + "')";
                        commands.ExecuteNonQuery();
                        
                        MessageBox.Show("Successfully Registered");
                    }
                    else
                    {
                        MessageBox.Show("Confirm Password is invalid");
                    }
                }
                else
                {
                    MessageBox.Show("Please Input Valid Email");
                }
                
            }
            else
            {
                
                MessageBox.Show("Don't Leave Empty Boxes");
            }


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login login_form = new Login();
            login_form.ShowDialog();
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
            if (Username.Text == "Username")
            {
                Username.Text = "";
                Username.ForeColor = Color.Black;
            }
        }

        private void Email_TextChanged(object sender, EventArgs e)
        {
            if (Email.Text == "something@like.this")
            {
                Email.Text = "";
                Email.ForeColor = Color.Black;
            }
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            if (Password.Text == "*******")
            {
                Password.Text = "";
                Password.ForeColor = Color.Black;
            }
        }

        private void Password_cf_TextChanged(object sender, EventArgs e)
        {
            if (Password_cf.Text == "*******")
            {
                Password_cf.Text = "";
                Password_cf.ForeColor = Color.Black;
            }
        }
        //placeholder validation
        private void firstname_enter(object sender, EventArgs e)
        {
            if (Firstname.Text == "First Name")
            {
                Firstname.Text = "";
                Firstname.ForeColor = Color.White;
            }
        }

        private void firstname_leave(object sender, EventArgs e)
        {
            if (Firstname.Text == "")
            {
                Firstname.Text = "First Name";
                Firstname.ForeColor = Color.White;
            }
        }

        private void lastname_enter(object sender, EventArgs e)
        {
            if (Lastname.Text == "Last Name")
            {
                Lastname.Text = "";
                Lastname.ForeColor = Color.White;
            }
        }

        private void lastname_leave(object sender, EventArgs e)
        {
            if (Lastname.Text == "")
            {
                Lastname.Text = "Last Name";
                Lastname.ForeColor = Color.White;
            }
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
            if (Email.Text == "something@like.this")
            {
                Email.Text = "";
                Email.ForeColor = Color.White;
            }
        }

        private void email_leave(object sender, EventArgs e)
        {
            if (Email.Text == "")
            {
                Email.Text = "something@like.this";
                Email.ForeColor = Color.White;
            }
        }

        private void pass_enter(object sender, EventArgs e)
        {
            if (Password.Text == "*******")
            {
                Password.Text = "";
                Password.ForeColor = Color.White;
            }
        }

        private void pass_leave(object sender, EventArgs e)
        {
            if (Password.Text == "")
            {
                Password.Text = "*******";
                Password.ForeColor = Color.White;
            }
        }

        private void pass_cf_enter(object sender, EventArgs e)
        {
            if (Password_cf.Text == "*******")
            {
                Password_cf.Text = "";
                Password_cf.ForeColor = Color.White;
            }
        }

        private void pass_cf_leave(object sender, EventArgs e)
        {
            if (Password_cf.Text == "")
            {
                Password_cf.Text = "*******";
                Password_cf.ForeColor = Color.White;
            }
        }
    }
}
