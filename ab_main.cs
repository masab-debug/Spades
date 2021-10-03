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
    public partial class ab_main : Form
    {
        public ab_main()
        {
            InitializeComponent();
        }
        
        private void ab_main_Load(object sender, EventArgs e)
        {

        }
        //employee
        private void button1_Click(object sender, EventArgs e)
        {
            Login emp = new Login();
            emp.Show();
        }       
        //admin
        private void button2_Click_1(object sender, EventArgs e)
        {
            admin_login admin = new admin_login();
            admin.Show();
        }
        //staff
        private void button3_Click_1(object sender, EventArgs e)
        {
            staff_login staff = new staff_login();
            staff.Show();
        }
    }
}
