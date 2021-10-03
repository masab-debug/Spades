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
    public partial class staff_attendance : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
        public string session = staff_login.staff_user;
        public string session_dept = staff_login.staff_dept;
        public int session_id = staff_login.staff_id;
        static DateTime now = DateTime.Now;
        string date = now.GetDateTimeFormats('d')[0];
        string time = now.GetDateTimeFormats('T')[0];
        public staff_attendance()
        {
            InitializeComponent();
            connection.Open();
        }

        private void Leave_Click(object sender, EventArgs e)
        {
            DateTime From_date = DateTime.Parse(this.dateTimePicker1.Text);
            DateTime To_date = DateTime.Parse(this.dateTimePicker2.Text);
            DateTime date_1 = DateTime.Parse(this.date);
            if (From_date >= date_1 && To_date >= date_1 && To_date > From_date)
            {
                SqlCommand commands = connection.CreateCommand();
                commands.CommandType = CommandType.Text;
                string leave = "Leave";
                string reason = textBox1.Text;
                string approve = "Pending";

                if (leave == "Leave")
                {
                    commands.CommandText = "INSERT INTO leave_staff ( Staff_id , Status_staff , Approval_staff, Reason_staff, From_date, To_date, Current_date_staff) values ('" + session_id + "', '" + approve + "','" + leave + "','" + reason + "', '" + From_date + "', '" + To_date + "', '" + date + "')";
                    commands.ExecuteNonQuery();
                    MessageBox.Show("Leave Done");
                }
                else
                {
                    MessageBox.Show("Error!! Occured");
                }
            }
            else
            {
                MessageBox.Show("Please Select Valid Dates");
            }
        }

        private void Checkin_Click(object sender, EventArgs e)
        {
            // do validations

            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;

            string present = "Present";

            if (present == "Present")
            {
                // still needs validations.
                commands.CommandText = "SELECT Current_date_staff, Staff_id FROM present_staff WHERE (Staff_id = '" + session_id + "' AND Current_date_staff = '" + date + "')";
                SqlDataAdapter fetcher = new SqlDataAdapter(commands.CommandText, connection);
                DataTable validator = new DataTable();
                fetcher.Fill(validator);
                if (validator.Rows.Count <= 0)
                {
                    commands.CommandText = "INSERT INTO present_staff (Staff_id , Status_staff , Current_date_staff, Current_time_staff) values ('" + session_id + "','" + present + "','" + date + "', '" + time + "')";
                    commands.ExecuteNonQuery();
                    MessageBox.Show("Marked Present");
                }
                else
                {
                    MessageBox.Show("Already Marked");
                }
            }
            else
            {
                MessageBox.Show("ERROR!");
            }
        }

        private void Checkout_Click(object sender, EventArgs e)
        {
            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;

            string present = "Present";

            if (present == "Present")
            {
                
                // still needs validations. of check out system still execute because time change dynamicly so it can validated accordingly.

                commands.CommandText = "SELECT Current_date_staff, Staff_id FROM present_staff WHERE (Staff_id = '" + session_id + "' AND Current_date_staff = '" + date + "')";
                SqlDataAdapter fetcher = new SqlDataAdapter(commands.CommandText, connection);
                DataTable validator = new DataTable();
                fetcher.Fill(validator);
                if (validator.Rows.Count == 1)
                {
                    //put here if exittime is empty then update otherwise not.
                    commands.CommandText = "SELECT Exit_time_staff FROM present_staff WHERE (Staff_id = '" + session_id + "' AND Current_date_staff = '" + date + "')";
                    SqlDataAdapter fetcher_d = new SqlDataAdapter(commands.CommandText, connection);
                    DataTable validator_d = new DataTable();
                    fetcher.Fill(validator_d);
                    if (validator_d.Rows.Count <= 1)
                    {
                        commands.CommandText = "UPDATE present_staff SET Exit_time_staff = '" + time + "' WHERE Current_date_staff = '" + date + "' AND Staff_id = '" + session_id + "'";
                        commands.ExecuteNonQuery();
                        /*connection.Close();*/
                        MessageBox.Show("Successfully Done");
                    }
                    else
                    {
                        MessageBox.Show("Check out already done");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Already Exit");
                }
            }
            else
            {
                MessageBox.Show("ERROR!");
            }
        }
    }
}
