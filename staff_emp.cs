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
    public partial class staff_emp : Form
    {
        public string dept = staff_login.staff_dept;
        public staff_emp()
        {
            InitializeComponent();
        }

       

        private void staff_emp_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
            connection.Open();
            SqlDataAdapter data = new SqlDataAdapter("SELECT * FROM signup WHERE Department = '"+ dept + "'", connection);
            DataTable dtbl = new DataTable();
            data.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }
        //update
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
            connection.Open();
            int ID = int.Parse(textBox1.Text);
            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;
            commands.CommandText = "UPDATE signup SET Firstname = '" + textBox10.Text + "', Lastname = '" + textBox11.Text + "', Username = '" + textBox2.Text + "', Email = '" + textBox3.Text + "', Address_employee = '" + textBox4.Text + "', City_employee = '" + textBox5.Text + "', Password_employee = '" + textBox5.Text + "', Department = '" + textBox6.Text + "' WHERE ID = '" + ID + "' AND Department = '"+ dept +"'";
            commands.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Successfully Updated");
            staff_emp_Load(sender, e);
        }
        //delete
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
            connection.Open();
            int ID = int.Parse(textBox1.Text);
            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;
            commands.CommandText = "DELETE FROM signup WHERE ID = '" + ID + "' AND Department = '"+ dept +"'";
            commands.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Deleted");
            staff_emp_Load(sender, e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
