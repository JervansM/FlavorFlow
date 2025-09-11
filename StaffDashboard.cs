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
            UpdateDateTime();
        }

        private void UpdateDateTime()
        {
            dashaddate.Text = DateTime.Now.ToString("d");
            dashadtime.Text = DateTime.Now.ToString("t");
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

        private void dashaddate_Click(object sender, EventArgs e) { }

        private void dashadtime_Click(object sender, EventArgs e) { }

        private void dashadrefreshicon_Click(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void staffdashlogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void tablemapbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffTableMap());
        }

        private void onlineordersbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffOnlineOrders());
        }

        private void deliverybtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffDelivery());
        }

        private void LoadContent(Form form)
        {
            form.Show();
            this.Hide(); // Optionally hide the current form
        }
    }
}