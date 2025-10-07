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
    public partial class WebAppCheckout : Form
    {
        public WebAppCheckout()
        {
            InitializeComponent();
        }

        private void WebAppCheckout_Load(object sender, EventArgs e)
        {

        }

        private void webappbackbtn_Click(object sender, EventArgs e)
        {
            WebAppMenu webAppMenu = new WebAppMenu();
            this.Hide();
            webAppMenu.Show();

        }

        private void webappproceedcheckoutbtn_Click(object sender, EventArgs e)
        {
            WebAppConfirmation webAppConfirmation = new WebAppConfirmation();
            this.Hide();
            webAppConfirmation.Show();

        }

        private void webappconfirmationorderitemspanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
