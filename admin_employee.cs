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
    public partial class admin_employee : Form
    {
        static int session = Login.session_id;
        
        public admin_employee()
        {
            InitializeComponent();
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
            connection.Open();
            if(textBox1.Text != "")
            {
                int ID = int.Parse(textBox1.Text);
                SqlCommand commands = new SqlCommand("SELECT * FROM signup WHERE ID = '" + ID + "'", connection);
                SqlDataReader fetcher = commands.ExecuteReader();
                while (fetcher.Read())
                {
                    textBox10.Text = fetcher.GetValue(1).ToString();
                    textBox11.Text = fetcher.GetValue(2).ToString();
                    textBox2.Text = fetcher.GetValue(3).ToString();
                    textBox3.Text = fetcher.GetValue(4).ToString();
                    textBox4.Text = fetcher.GetValue(5).ToString();
                    textBox5.Text = fetcher.GetValue(6).ToString();
                    textBox6.Text = fetcher.GetValue(8).ToString();
                    textBox7.Text = fetcher.GetValue(7).ToString();

                }
                connection.Close();
            }*/
        }
        //update button
        private void button1_Click(object sender, EventArgs e)
        {
                SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
                connection.Open();
                int ID = int.Parse(textBox1.Text);
                SqlCommand commands = connection.CreateCommand();
                commands.CommandType = CommandType.Text;
                commands.CommandText = "UPDATE signup SET Firstname = '" + textBox10.Text + "', Lastname = '" + textBox11.Text + "', Username = '" + textBox2.Text + "', Email = '" + textBox3.Text + "', Address_employee = '" + textBox4.Text + "', City_employee = '" + textBox5.Text + "', Password_employee = '" + textBox5.Text + "', Department = '" + textBox6.Text + "' WHERE ID = '" + ID + "'";
                commands.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Successfully Updated");
                admin_employee_Load(sender, e);
        }

        private void admin_employee_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
            connection.Open();
            SqlDataAdapter data = new SqlDataAdapter("SELECT * FROM signup", connection);
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
            commands.CommandText = "DELETE FROM signup WHERE ID = '" + ID + "'";
            commands.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Deleted");
            admin_employee_Load(sender, e);
        }
        //leave
        private void button4_Click(object sender, EventArgs e)
        {
            admin_leave leave = new admin_leave();
            leave.Show();
        }
        //atten
        private void button3_Click(object sender, EventArgs e)
        {
            admin_emp_atten atten = new admin_emp_atten();
            atten.Show();
        }

        private void excel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = excel.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)excel.ActiveSheet;
            excel.Visible = true;
            
            for (int j = 1; j < dataGridView1.Columns.Count + 1 ; j++)
            {
                ws.Cells[1, j] = dataGridView1.Columns[j - 1].HeaderText;
            }

            for(int j = 0; j < dataGridView1.Columns.Count; j++)
            {
                for(int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    ws.Cells[j + 2, i + 1] = dataGridView1.Rows[j].Cells[i].Value.ToString();
                }
            }
        }
    }
}
