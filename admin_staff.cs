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
using Microsoft.Office.Interop.Excel;

namespace spades
{
    public partial class admin_staff : Form
    {
        public admin_staff()
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
            commands.CommandText = "UPDATE signup_staff SET Firstname = '" + textBox10.Text + "', Lastname = '" + textBox11.Text + "', Username = '" + textBox2.Text + "', Email = '" + textBox3.Text + "', Address_staff = '" + textBox4.Text + "', City_staff = '" + textBox5.Text + "', Password_staff = '" + textBox5.Text + "', Deparment_head = '" + textBox6.Text + "' WHERE ID = '" + ID + "'";
            commands.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Updated");
            admin_staff_Load(sender, e);
        }

        private void admin_staff_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
            connection.Open();
            SqlDataAdapter data = new SqlDataAdapter("SELECT * FROM signup_staff", connection);
            System.Data.DataTable dtbl = new System.Data.DataTable();
            data.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }
        //delete
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
            connection.Open();
            int ID = int.Parse(textBox1.Text);
            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;
            commands.CommandText = "DELETE FROM signup_staff WHERE ID = '" + ID + "'";
            commands.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Deleted");
            admin_staff_Load(sender, e);
        }
        //atten
        private void button3_Click(object sender, EventArgs e)
        {
            admin_staff_atten atten = new admin_staff_atten();
            atten.Show();

        }
        //leave
        private void button4_Click(object sender, EventArgs e)
        {
            admin_staff_leave leave = new admin_staff_leave();
            leave.Show();
        }

        private void excel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = excel.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)excel.ActiveSheet;
            excel.Visible = true;
            for (int j = 1; j < dataGridView1.Columns.Count + 1; j++)
            {
                ws.Cells[1, j] = dataGridView1.Columns[j - 1].HeaderText;
            }

            for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)
            {
                for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)
                {
                    ws.Cells[j + 2, i + 1] = dataGridView1.Rows[j].Cells[i].Value.ToString();
                }
            }
        }
    }
}
