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
    public partial class HrPayrollMain : Form
    {
        private readonly string connectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public HrPayrollMain()
        {
            InitializeComponent();
        }


        private void LoadContent(Form form)
        {
            foreach (Control ctrl in systempanelcontents.Controls)
            {
                ctrl.Dispose();
            }

            systempanelcontents.Controls.Clear();

            // Prepare the new form
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Add to panel
            systempanelcontents.Controls.Add(form);
            form.Show();

        }

        private void systempanelcontents_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HrPayrollMain_Load(object sender, EventArgs e)
        {

        }

        private void hrpayrollmainpayrollperiodsbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new HrPayrollPeriods());
        }

        private void hrpayrollmaingeneratepayrollpsbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new HrGeneratePayroll());
        }

        private void hrpayrollmainallowanceanddeductionsbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new HrAllowanceandDeductions());
        }

        private void hrpayrollmainovertimesrecordsbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new HrOvertimeRecords());
        }
    }
}
