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
    public partial class staff_profile : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
        public int session_id = staff_login.staff_id;
        public staff_profile()
        {
            InitializeComponent();
        }
        
        
        //update
        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            /*try
            {*/
            /*MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
            byte[] img = ms.ToArray();*/



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
            }
            /*}
            catch (Exception)
            {
                MessageBox.Show("Please fill every fiels and choose image");
            }*/
        }

        private void staff_profile_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand emp_data = new SqlCommand("SELECT * FROM signup_staff WHERE ID = '" + session_id + "'", connection);
            SqlDataReader emp_data_1 = emp_data.ExecuteReader();
            while (emp_data_1.Read())
            {
                firstname.Text = emp_data_1.GetValue(1).ToString();
                lastname.Text = emp_data_1.GetValue(2).ToString();
                username.Text = emp_data_1.GetValue(3).ToString();
                email.Text = emp_data_1.GetValue(4).ToString();
                address.Text = emp_data_1.GetValue(5).ToString();
                city.Text = emp_data_1.GetValue(6).ToString();
                
            }
            connection.Close();
        }

        
        //delete account
        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;
            commands.CommandText = "DELETE FROM signup_staff WHERE ID = '" + session_id + "'";
            commands.ExecuteNonQuery();
            present_delete();
            leave_delete();
            MessageBox.Show("Account Deleted");
            this.Close();
            this.Close();
            this.Close();
            staff_signup signup = new staff_signup();
            signup.Show();
            
            
        }
        private void present_delete()
        {
            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;
            commands.CommandText = "DELETE FROM present_staff WHERE Staff_id = '" + session_id + "'";
            commands.ExecuteNonQuery();
        }
        private void leave_delete()
        {
            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;
            commands.CommandText = "DELETE FROM leave_staff WHERE Staff_id = '" + session_id + "'";
            commands.ExecuteNonQuery();
        }
    }
}
