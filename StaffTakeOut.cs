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
    public partial class StaffTakeOut : Form
    {
        public StaffTakeOut()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void onlineordersbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffOnlineOrders());
        }

        private void tablemapbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffTableMap());
        }

        private void deliverybtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffDelivery());
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
