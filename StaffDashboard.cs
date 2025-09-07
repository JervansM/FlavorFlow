using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlavorFlowIT13
{
    public partial class StaffDashboard : Form
    {
        public StaffDashboard()
        {
            InitializeComponent();
        }
        private void StaffDashboard_Load(object sender, EventArgs e)
        {
            this.Text = "FlavorFlow - Staff Dashboard";


        }

        private void RefreshIcon_Click(object sender, EventArgs e)
        {
            RefreshUI();
        }
        private void RefreshUI()
        {

            this.Hide();
            StaffDashboard newForm = new StaffDashboard();
            newForm.Show();
            this.Close();

        }
        private void StaffDashboard_Load_1(object sender, EventArgs e)
        {
            dashaddate.Text = DateTime.Now.ToString("d");
            dashadtime.Text = DateTime.Now.ToString("t");
        }

        private void dashaddate_Click(object sender, EventArgs e)
        {

        }

        private void dashadtime_Click(object sender, EventArgs e)
        {

        }

        private void dashadrefreshicon_Click(object sender, EventArgs e)
        {
            RefreshUI();

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void adminicon_Click(object sender, EventArgs e)
        {

        }

        private void staffdashlogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
