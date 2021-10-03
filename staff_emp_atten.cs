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
    public partial class staff_emp_atten : Form
    {
        public string dept = staff_login.staff_dept;
        public staff_emp_atten()
        {
            InitializeComponent();
        }
        //update
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
            connection.Open();
            int ID = int.Parse(textBox1.Text);
            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;
            commands.CommandText = "UPDATE present SET Status_emp = '" + textBox11.Text + "', Current_time_emp = '" + textBox3.Text + "', Exist_time_emp = '" + textBox5.Text + "' WHERE ID = '" + ID + "' AND Department = '"+ dept + "'";
            commands.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Updated");
            staff_emp_atten_Load(sender, e);
        }

        private void staff_emp_atten_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
            connection.Open();
            SqlDataAdapter data = new SqlDataAdapter("SELECT * FROM present WHERE Department = '"+ dept + "'", connection);
            DataTable dtbl = new DataTable();
            data.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
            connection.Open();
            int ID = int.Parse(textBox1.Text);
            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;
            commands.CommandText = "DELETE FROM present WHERE ID = '" + ID + "' AND Department = '"+ dept + "'";
            commands.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Deleted");
            staff_emp_atten_Load(sender, e);
        }
    }
}
