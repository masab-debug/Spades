using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spades
{
    public partial class admin_dashboard : Form
    {
        public admin_dashboard()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            admin_dashboard_pop dashboard = new admin_dashboard_pop();
            dashboard.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin_employee employee = new admin_employee();
            employee.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            admin_staff staff = new admin_staff();
            staff.Show();
        }
    }
}
