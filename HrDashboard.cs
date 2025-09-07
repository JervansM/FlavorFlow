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
    public partial class HrDashboard : Form
    {
        public HrDashboard()
        {
            InitializeComponent();
        }
        private void HrDashboard_Load(object sender, EventArgs e)
        {
            this.Text = "FlavorFlow - HR Dashboard";    
        }
    }
}
