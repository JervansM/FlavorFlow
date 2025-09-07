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
    public partial class DashboardContentForm : Form
    {
        public DashboardContentForm()
        {
            InitializeComponent();

            RoundPanel(panelContent, 25);
            RoundPanel(dashtotalsales, 25);
            RoundPanel(dashactive, 25);
            RoundPanel(dashnetprofit, 25);
            RoundPanel(dashinventorystatus, 25);
            RoundPanel(dashtotalexpense, 25);
            RoundPanel(dashinventoryusage, 25);
            RoundPanel(dashnotif, 25);
            RoundPanel(dashvisuals, 25);



            dashtotalsales.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            dashactive.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            dashnetprofit.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            dashinventorystatus.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            dashtotalexpense.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            dashinventoryusage.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            dashactive.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            dashnotif.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            dashvisuals.BackColor = ColorTranslator.FromHtml("#1e1e1e");
        }


        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashtotalsales_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadContent(Form form)
        {
            // Dispose old form(s) before clearing
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
        private bool isToggled = true;


        private void dashactiveon_Click(object sender, EventArgs e)
        {
            isToggled = !isToggled;
            dashactiveon.Image = isToggled
                ? Properties.Resources.toggleon_removebg_preview
                : Properties.Resources.toggleoff_removebg_preview;

            if (isToggled)
            {
                // toggle on

            }
            else
            {
                // toggle off

            }
        }

        private void panelContent_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void DashboardContentForm_Load(object sender, EventArgs e)
        {

        }
    }
}

