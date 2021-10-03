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
    public partial class admin_staff_leave : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
        public admin_staff_leave()
        {
            InitializeComponent();
        }
        //approve
        private void button1_Click(object sender, EventArgs e)
        {
            string approve = "Approve";
            connection.Open();
            int ID = int.Parse(textBox1.Text);
            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;
            commands.CommandText = "UPDATE leave_staff  SET Status_staff = '" + approve + "' WHERE ID = '" + ID + "'";
            commands.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully Updated");
            admin_staff_leave_Load(sender, e);
        }

        private void admin_staff_leave_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-RT2PGHT\SQLEXPRESS;Initial Catalog=spades;Integrated Security=True");
            connection.Open();
            SqlDataAdapter data = new SqlDataAdapter("SELECT * FROM leave_staff", connection);
            System.Data.DataTable dtbl = new System.Data.DataTable();
            data.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }
        //reject
        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            string approve = "Approve";
            SqlCommand commands = connection.CreateCommand();
            commands.CommandType = CommandType.Text;
            string sqlstate = commands.CommandText = "SELECT Status_staff FROM leave_staff WHERE(Status_staff = '" + approve + "')";
            SqlDataAdapter fetcher = new SqlDataAdapter(sqlstate, connection);
            System.Data.DataTable validator = new System.Data.DataTable();
            fetcher.Fill(validator);
            if (validator.Rows.Count <= 0)
            {

                int ID = int.Parse(textBox1.Text);
                commands.CommandText = "DELETE FROM leave_staff WHERE ID = '" + ID + "'";
                commands.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Successfully Updated");
                admin_staff_leave_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Approved can not delete");
            }
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
