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
    public partial class staff_emp_leave : Form
    {
        public string dept = staff_login.staff_dept;
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
        public staff_emp_leave()
        {
            InitializeComponent();
        }

        private void staff_emp_leave_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
            connection.Open();
            SqlDataAdapter data = new SqlDataAdapter("SELECT * FROM leave_emp WHERE Department = '"+ dept + "'", connection);
            DataTable dtbl = new DataTable();
            data.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }
        //leave
        private void button1_Click(object sender, EventArgs e)
        {

            string approve = "Approve";
            connection.Open();
            int ID = int.Parse(textBox1.Text);
            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;
            commands.CommandText = "UPDATE leave_emp  SET Status_emp = '" + approve + "' WHERE ID = '" + ID + "' AND Department = '" + dept + "'";
            commands.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Updated");
            staff_emp_leave_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            string approve = "Approve";
            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;
            string sqlstate = commands.CommandText = "SELECT Status_emp FROM leave_emp WHERE(Status_emp = '" + approve + "' AND Department = '" + dept + "')";
            SqlDataAdapter fetcher = new SqlDataAdapter(sqlstate, connection);
            DataTable validator = new DataTable();
            fetcher.Fill(validator);
            if (validator.Rows.Count <= 0)
            {

                int ID = int.Parse(textBox1.Text);
                commands.CommandText = "DELETE FROM leave_emp WHERE ID = '" + ID + "' AND Department = '" + dept + "'";
                commands.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Successfully Updated");
                staff_emp_leave_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Approved can not delete");
            }
        }
    }
}
