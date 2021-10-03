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
    public partial class Form3 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
        public string session_login = Login.session;
        public int session_id = Login.session_id;
        public string session_dept = Login.session_dept;
        static DateTime now = DateTime.Now;
        string date = now.GetDateTimeFormats('d')[0];
        string time = now.GetDateTimeFormats('T')[0];

       
        public Form3()
        {
            InitializeComponent();
            connection.Open();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // check in 
        private void button1_Click(object sender, EventArgs e)
        {

            // do validations
            /*SqlCommand commands_validate = connection.CreateCommand();
            commands_validate.CommandType = CommandType.Text;
            commands_validate.CommandText = "SELECT Emp_id, From_date, To_date FROM leave_emp WHERE (Emp_id = '" + session_id + "' AND Current_date_emp = '" + date + "')";
            SqlDataAdapter fetcher_validate = new SqlDataAdapter(commands_validate.CommandText, connection);
            DataTable validator_validate = new DataTable();
            fetcher_validate.Fill(validator_validate);
            if (validator_validate.Rows.Count == 1)
            {*/
                SqlCommand commands = connection.CreateCommand();
                commands.CommandType = CommandType.Text;

                string present = "Present";

                if (present == "Present")
                {
                    // still needs validations.
                    commands.CommandText = "SELECT Current_date_emp, Emp_id FROM present WHERE (Emp_id = '" + session_id + "' AND Current_date_emp = '" + date + "')";
                    SqlDataAdapter fetcher = new SqlDataAdapter(commands.CommandText, connection);
                    DataTable validator = new DataTable();
                    fetcher.Fill(validator);
                    if (validator.Rows.Count <= 0)
                    {
                        commands.CommandText = "INSERT INTO present ( Emp_id , Status_emp , Current_date_emp, Current_time_emp, Department) values ('" + session_id + "','" + present + "','" + date + "', '" + time + "', '" + session_dept + "')";
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
            /*}
            else
            {

            }*/
            


        }
        // check out
        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;

            string present = "Present";

            if (present == "Present")
            {
                this.Close();
                // still needs validations.

                
                    //put here if exittime is empty then update otherwise not.
                    commands.CommandText = "UPDATE present SET Exist_time_emp = '" + time + "' WHERE Current_date_emp = '" + date + "' AND Emp_id = '" + session_id + "'";
                    commands.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Successfully Done");
                    this.Hide();
                    dashboardemp dash = new dashboardemp();
                
            }
            else
            {
                MessageBox.Show("ERROR!");
            }


        }
        // leave 
        private void button2_Click(object sender, EventArgs e)
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
                    commands.CommandText = "INSERT INTO leave_emp ( Emp_id , Status_emp , Approval_emp, Reason_emp, From_date, To_date, Current_date_emp, Department) values ('" + session_id + "', '" + approve + "','" + leave + "','" + reason + "', '" + From_date + "', '" + To_date + "', '" + date + "', '" + session_dept + "')";
                    commands.ExecuteNonQuery();
                    MessageBox.Show("Leave is inserted");
                }
                else
                {
                    MessageBox.Show("ERROR!!");
                }
            }
            else
            {
                MessageBox.Show("Please Select Valid Dates");
            }
            
            


        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
