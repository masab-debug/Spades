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
    public partial class staff_dashboard : Form
    {
        public staff_dashboard()
        {
            InitializeComponent();
        }
        //staff
        

        private void dashboard_Click(object sender, EventArgs e)
        {
            
        }

        private void profile_Click(object sender, EventArgs e)
        {
            staff_profile profile = new staff_profile();
            profile.Show();
        }

        private void attendance_Click(object sender, EventArgs e)
        {
            staff_attendance atten = new staff_attendance();
            atten.Show();
        }
        //emp
        private void button1_Click(object sender, EventArgs e)
        {
            staff_emp emp = new staff_emp();
            emp.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            staff_emp_atten atten_emp = new staff_emp_atten();
            atten_emp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            staff_emp_leave leave_emp = new staff_emp_leave();
            leave_emp.Show();
        }
    }
}
