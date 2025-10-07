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
    public partial class HrCompliancesContent : Form
    {
        public HrCompliancesContent()
        {
            InitializeComponent();
        }

        private void LoadContent(Form form)
        {
            foreach (Control ctrl in panelContent.Controls)
            {
                ctrl.Dispose();
            }

            panelContent.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panelContent.Controls.Add(form);
            form.Show();
        }

        private void hrcompliancesrenewdocumentsbtn_Click(object sender, EventArgs e)
        {

        }

        private void HrCompliances_Load(object sender, EventArgs e)
        {

        }

        private void HrCompliances_Load_1(object sender, EventArgs e)
        {

        }

        private void hrcompliancespoliciesbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new HrPolicies());
        }

        private void hrcompliancescompliancesbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new HrCompliancesContent());

        }

    }
}
