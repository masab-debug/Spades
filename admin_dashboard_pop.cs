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

namespace spades
{
    public partial class admin_dashboard_pop : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
        public admin_dashboard_pop()
        {
            InitializeComponent();
            connection.Open();
            SqlCommand com = new SqlCommand("select count(ID) from signup_staff", connection);
            SqlCommand command = new SqlCommand("select count(Exit_time_staff) from present_staff", connection);
            SqlCommand command_1= new SqlCommand("select count(Exist_time_emp) from present", connection);
            object count = com.ExecuteScalar();
            object count_1 = command.ExecuteScalar();
            object count_2 = command_1.ExecuteScalar();
            if (count != null) textBox13.Text = count.ToString();
            if (count_1 != null) textBox5.Text = count_1.ToString();
            if (count_2 != null) textBox5.Text = count_2.ToString();
            connection.Close();
        }

        private void admin_dashboard_pop_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand com = new SqlCommand("select count(ID) from signup", connection);
            object count = com.ExecuteScalar();
            if (count != null) textBox7.Text = count.ToString();
            connection.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
        //employee number
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {/*
            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;

            if (!string.IsNullOrEmpty(firstname.Text) && !string.IsNullOrEmpty(lastname.Text) && !string.IsNullOrEmpty(username.Text) && !string.IsNullOrEmpty(email.Text) && !string.IsNullOrEmpty(address.Text) && !string.IsNullOrEmpty(city.Text) && !string.IsNullOrEmpty(password.Text) && !string.IsNullOrEmpty(password_cf.Text))
            {
                if (password.Text == password_cf.Text)
                {
                    commands.CommandText = "UPDATE signup_staff SET Firstname = '" + firstname.Text + "', Lastname = '" + lastname.Text + "', Username = '" + username.Text + "', Email = '" + email.Text + "', Address_staff = '" + address.Text + "', City_staff = '" + city.Text + "', Password_staff = '" + password.Text + "' WHERE ID = '" + session_id + "'";
                    commands.ExecuteNonQuery();
                    MessageBox.Show("Successful, Please Login Again with new updated credientials");
                    this.Hide();
                    staff_login login = new staff_login();
                    login.Show();
                    connection.Close();


                }
                else
                {
                    MessageBox.Show("Please type valid confirm password");
                }
            }
            else
            {
                MessageBox.Show("Fields can not be empty!");
            }*/
        }

        private void delete_Click(object sender, EventArgs e)
        {

        }
    }
}
