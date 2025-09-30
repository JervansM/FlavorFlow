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
    public partial class WebAppMyOrdersPending : Form
    {
        public WebAppMyOrdersPending()
        {
            InitializeComponent();
        }

        private void LoadContent(Form form)
        {
            try
            {
                // Clear previous content
                this.Controls.Clear();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                this.Controls.Add(form);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading content: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void webappoutfordeliverybtn_Click(object sender, EventArgs e)
        {
            LoadContent(new WebAppMyOrdersOutforDelivery());
        }

        private void webappcompletebtn_Click(object sender, EventArgs e)
        {
            LoadContent(new WebAppMyOrdersComplete());
        }

        private void webapppastordersbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new WebAppMyOrdersPastOrders());
        }

        private void webapppendingbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new WebAppMyOrdersPending());
        }
    }
}
