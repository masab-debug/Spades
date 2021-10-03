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
    public partial class admin_emp_atten : Form
    {
        public admin_emp_atten()
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
            commands.CommandText = "UPDATE present SET Status_emp = '" + textBox11.Text + "', Current_time_emp = '" + textBox3.Text + "', Exist_time_emp = '" + textBox5.Text + "' WHERE ID = '" + ID + "'";
            commands.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Updated");
            admin_emp_atten_Load(sender, e);
        }
        //delete
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
            connection.Open();
            int ID = int.Parse(textBox1.Text);
            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;
            commands.CommandText = "DELETE FROM present WHERE ID = '" + ID + "'";
            commands.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Deleted");
            admin_emp_atten_Load(sender, e);
        }

        private void admin_emp_atten_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
            connection.Open();
            SqlDataAdapter data = new SqlDataAdapter("SELECT * FROM present", connection);
            System.Data.DataTable dtbl = new System.Data.DataTable();
            data.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
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

            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    ws.Cells[j + 2, i + 1] = dataGridView1.Rows[j].Cells[i].Value.ToString();
                }
            }
        }
    }
}
