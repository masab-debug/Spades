using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace spades
{
    public partial class Form2 : Form
    {
        public string session_login = Login.session;
        public int session_id = Login.session_id;
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand emp_data = new SqlCommand("SELECT * FROM signup WHERE ID = '"+ session_id +"'", connection);
            SqlDataReader emp_data_1 = emp_data.ExecuteReader();
            while (emp_data_1.Read())
            {
                textBox1.Text = emp_data_1.GetValue(1).ToString();
                textBox2.Text = emp_data_1.GetValue(2).ToString();
                textBox3.Text = emp_data_1.GetValue(3).ToString();
                textBox4.Text = emp_data_1.GetValue(4).ToString();
                textBox6.Text = emp_data_1.GetValue(5).ToString();
                textBox7.Text = emp_data_1.GetValue(6).ToString();
            }
            connection.Close();
        }


        

        //update button
        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            
            
            

                SqlCommand commands = connection.CreateCommand();
                commands.CommandType = CommandType.Text;

                if(!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrEmpty(textBox8.Text))
                {
                    if (textBox5.Text == textBox8.Text)
                    {
                        commands.CommandText = "UPDATE signup SET Firstname = '" + textBox1.Text + "', Lastname = '" + textBox2.Text + "', Username = '" + textBox3.Text + "', Email = '" + textBox4.Text + "', Address_employee = '" + textBox6.Text + "', City_employee = '" + textBox7.Text + "', Password_employee = '" + textBox5.Text + "' WHERE ID = '" + session_id + "'";
                        commands.ExecuteNonQuery();
                        MessageBox.Show("Successful, Please Login Again with new updated credientials");
                        this.Hide();
                        dashboardemp demp = new dashboardemp();
                        demp.Hide();
                        Login open = new Login();
                        open.ShowDialog();
                        connection.Close();


                    }
                    else
                    {
                        MessageBox.Show("Please type valid confirm password");
                    connection.Close();
                }
                }
                else
                {
                    MessageBox.Show("Fields can not be empty!");
                    connection.Close();
            }
            

        }
        // delete
        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;
            commands.CommandText = "DELETE FROM signup WHERE ID = '"+session_id+"'";
            commands.ExecuteNonQuery();
            present_delete();
            leave_delete();
            MessageBox.Show("Account Deleted");
            this.Hide();
            this.Close();
            this.Close();
            staff_signup signup = new staff_signup();
            signup.Show();
            connection.Close();


        }
        private void present_delete()
        {
            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;
            commands.CommandText = "DELETE FROM present WHERE Emp_id = '" + session_id + "'";
            commands.ExecuteNonQuery();
        }
        private void leave_delete()
        {
            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;
            commands.CommandText = "DELETE FROM leave_emp WHERE Emp_id = '" + session_id + "'";
            commands.ExecuteNonQuery();
        }
    }
}
