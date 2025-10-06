using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            RoundPanel(systempanelcontents, 25);
            RoundButton(hrpayrollmainpayrollperiodsbtn, 20);
            RoundButton(hrpayrollmaingeneratepayrollpsbtn, 20);
            RoundButton(hrpayrollmainallowanceanddeductionsbtn, 20);
            RoundButton(hrpayrollmainovertimesrecordsbtn, 20);

            hrpayrollmainpayrollperiodsbtn.UseVisualStyleBackColor = false;
            hrpayrollmainpayrollperiodsbtn.FlatStyle = FlatStyle.Flat;
            hrpayrollmainpayrollperiodsbtn.FlatAppearance.BorderSize = 0;
            hrpayrollmainpayrollperiodsbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            hrpayrollmainpayrollperiodsbtn.ForeColor = Color.White;
            hrpayrollmainpayrollperiodsbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            hrpayrollmainpayrollperiodsbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            hrpayrollmaingeneratepayrollpsbtn.UseVisualStyleBackColor = false;
            hrpayrollmaingeneratepayrollpsbtn.FlatStyle = FlatStyle.Flat;
            hrpayrollmaingeneratepayrollpsbtn.FlatAppearance.BorderSize = 0;
            hrpayrollmaingeneratepayrollpsbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            hrpayrollmainpayrollperiodsbtn.ForeColor = Color.White;
            hrpayrollmaingeneratepayrollpsbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            hrpayrollmaingeneratepayrollpsbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            hrpayrollmainallowanceanddeductionsbtn.UseVisualStyleBackColor = false;
            hrpayrollmainallowanceanddeductionsbtn.FlatStyle = FlatStyle.Flat;
            hrpayrollmainallowanceanddeductionsbtn.FlatAppearance.BorderSize = 0;
            hrpayrollmainallowanceanddeductionsbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            hrpayrollmainallowanceanddeductionsbtn.ForeColor = Color.White;
            hrpayrollmainallowanceanddeductionsbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            hrpayrollmainallowanceanddeductionsbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            hrpayrollmainovertimesrecordsbtn.UseVisualStyleBackColor = false;
            hrpayrollmainovertimesrecordsbtn.FlatStyle = FlatStyle.Flat;
            hrpayrollmainovertimesrecordsbtn.FlatAppearance.BorderSize = 0;
            hrpayrollmainovertimesrecordsbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            hrpayrollmainovertimesrecordsbtn.ForeColor = Color.White;
            hrpayrollmainovertimesrecordsbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            hrpayrollmainovertimesrecordsbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");
        }
        private void RoundButton(Button button, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(button.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(button.Width - radius, button.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, button.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            button.Region = new System.Drawing.Region(path);
        }

        private void RoundPanel(Panel pnl, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pnl.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(pnl.Width - radius, pnl.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, pnl.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            pnl.Region = new Region(path);
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
