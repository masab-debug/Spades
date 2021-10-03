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
    public partial class Form1 : Form
    {
        
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
        public string session_login = Login.session;
        public int session_id = Login.session_id;
        public Form1()
        {
            InitializeComponent();
            label2.Text = session_login; //for session usage
            connection.Open();
            SqlCommand com = new SqlCommand("select count(ID) from present WHERE Emp_id = '"+ session_id +"'", connection);
            object count = com.ExecuteScalar();
            if (count != null) textBox1.Text = count.ToString();
            connection.Close();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

            // for data grid view
            /*connection.Open();
            SqlDataAdapter data = new SqlDataAdapter("SELECT * FROM signup WHERE Username = '"+ session_login + "'", connection);
            DataTable dtbl = new DataTable();
            data.Fill(dtbl);
            dataview.DataSource = dtbl;*/

            // for showing data in textbox
            connection.Open();
            SqlCommand emp_data = new SqlCommand("SELECT * FROM signup WHERE ID = '"+ session_id +"'",connection);
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


        private void delete_Click(object sender, EventArgs e)
        {
            /*SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;
            commands.CommandText = "DELETE FROM signup WHERE Username = '"+ session_login + "'";
            commands.ExecuteNonQuery();
            connection.Close();
            SqlDataAdapter data = new SqlDataAdapter("SELECT * FROM signup WHERE Username = '" + session_login + "'", connection);
            DataTable dtbl = new DataTable();
            data.Fill(dtbl);
            dataview.DataSource = dtbl;
            MessageBox.Show("Successfully Deleted");*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;
            commands.CommandText = "UPDATE signup SET Firstname = '"+ textBox1.Text +"', Lastname = '"+ textBox2.Text + "', Username = '"+ textBox3.Text + "', Email = '"+ textBox4.Text + "', Password_employee = '"+ textBox5.Text + "' WHERE Username = '"+ session_login + "'";
            commands.ExecuteNonQuery();
            connection.Close();
            SqlDataAdapter data = new SqlDataAdapter("SELECT * FROM signup WHERE Username = '" + session_login + "'", connection);
            DataTable dtbl = new DataTable();
            data.Fill(dtbl);
            dataview.DataSource = dtbl;
            MessageBox.Show("Successfully Updated");*/
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
