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
    public partial class StaffTableMap : Form
    {
        public StaffTableMap()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void sendtokitchenbtn_Click(object sender, EventArgs e)
        {

        }

        private void deliverybtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffDelivery());
        }

        private void onlineordersbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffOnlineOrders());
        }

        private void takeoutbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffTakeOut());
        }

        private void menubtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffDashboard());
        }

        private void LoadContent(Form form)
        {
            form.Show();
            this.Hide(); // Optionally hide the current form
        }

        
    }
}
