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

        private void LoadContent(Form form)
        {
            foreach (Control ctrl in panelContent.Controls)
            {
                ctrl.Dispose();
            }

            panelContent.Controls.Clear();

            // Prepare the new form
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Add to panel
            panelContent.Controls.Add(form);
            form.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dashlowstackalerts_Click(object sender, EventArgs e)
        {

        }

        private void panelNav_Paint(object sender, PaintEventArgs e)
        {

        }

        private void adstaffbtn_Click(object sender, EventArgs e)
        {

        }

        private void HrDashboard_Load_1(object sender, EventArgs e)
        {

        }

        private void dashvisuals_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashinventorytxt_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void fficonadmin_Click(object sender, EventArgs e)
        {

        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EmployeeManagement_Click(object sender, EventArgs e)
        {
            LoadContent(new HrEmployeeManagement());

        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashvisualtxtsales_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadContent(new HrAttendance());
        }

        private void hrpayrollbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new HrPayrollMain());
        }

        private void hrleavetimeoffbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new HrLeave());
        }

        private void hrcompliancepoliciesbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new HrCompliances());
        }

        private void hrreportsanalyticsbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new HrReports());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LoadContent(new HrDashboard());
        }

        private void dashtotalsales_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
