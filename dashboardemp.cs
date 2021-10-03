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
    public partial class dashboardemp : Form
    {
        
        public dashboardemp()
        {
            InitializeComponent();
        }

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 dashboard = new Form1();
            dashboard.Show();


        }

        private void profile_Click(object sender, EventArgs e)
        {

            Form2 profile_form = new Form2();
            profile_form.Show();

        }

        private void attendance_Click(object sender, EventArgs e)
        {

            Form3 attendance_form = new Form3();
            attendance_form.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
