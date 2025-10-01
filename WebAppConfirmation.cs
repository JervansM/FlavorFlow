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
    public partial class WebAppConfirmation : Form
    {
        public WebAppConfirmation()
        {
            InitializeComponent();
        }

        private void LoadContent(Form form)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }

            panel1.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panel1.Controls.Add(form);
            form.Show();
        }

        private void WebAppConfirmation_Load(object sender, EventArgs e)
        {

        }

        private void webappconfirmationconfimorderbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new WebAppThankYou());
        }

        private void webappconfirmationeditorderbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new WebAppCheckOuts());
        }
    }
}
