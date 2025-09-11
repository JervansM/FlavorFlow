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
    public partial class StaffOnlineOrders : Form
    {
        public StaffOnlineOrders()
        {
            InitializeComponent();
        }

        private void menubtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffDashboard());
        }

        private void tablemapbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffTableMap());
        }


        private void takeoutbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffTakeOut());
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
