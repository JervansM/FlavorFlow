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
    public partial class SystemSettingsGeneral : Form
    {
        public SystemSettingsGeneral()
        {
            InitializeComponent();
            RoundPanel(panelContent, 25);
            RoundPanel(systemsearchbarpanel, 25);
            RoundButton(systemgeneralsettings, 25);
            RoundButton(systemusermanagement, 25);
            RoundButton(systemappconfigure, 25);
            RoundButton(systemsettingssavebtn, 25);
            RoundButton(systemsettingscancelbtn, 25);
            RoundPanel(systempanelcontents, 25);

            systemgeneralsettings.UseVisualStyleBackColor = false;
            systemgeneralsettings.FlatStyle = FlatStyle.Flat;
            systemgeneralsettings.FlatAppearance.BorderSize = 0;
            systemgeneralsettings.BackColor = ColorTranslator.FromHtml("#6C6868");
            systemgeneralsettings.ForeColor = Color.White;
            systemgeneralsettings.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            systemgeneralsettings.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            systemusermanagement.UseVisualStyleBackColor = false;
            systemusermanagement.FlatStyle = FlatStyle.Flat;
            systemusermanagement.FlatAppearance.BorderSize = 0;
            systemusermanagement.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            systemusermanagement.ForeColor = Color.White;
            systemusermanagement.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            systemusermanagement.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            systemappconfigure.UseVisualStyleBackColor = false;
            systemappconfigure.FlatStyle = FlatStyle.Flat;
            systemappconfigure.FlatAppearance.BorderSize = 0;
            systemappconfigure.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            systemappconfigure.ForeColor = Color.White;
            systemappconfigure.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            systemappconfigure.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            systemsettingssavebtn.UseVisualStyleBackColor = false;
            systemsettingssavebtn.FlatStyle = FlatStyle.Flat;
            systemsettingssavebtn.FlatAppearance.BorderSize = 0;
            systemsettingssavebtn.BackColor = ColorTranslator.FromHtml("#5CC536");
            systemsettingssavebtn.ForeColor = Color.White;
            systemsettingssavebtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            systemsettingssavebtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            systemsettingscancelbtn.UseVisualStyleBackColor = false;
            systemsettingscancelbtn.FlatStyle = FlatStyle.Flat;
            systemsettingscancelbtn.FlatAppearance.BorderSize = 0;
            systemsettingscancelbtn.BackColor = ColorTranslator.FromHtml("#9A1010");
            systemsettingscancelbtn.ForeColor = Color.White;
            systemsettingscancelbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            systemsettingscancelbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

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



        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void systemgeneralsettings_Click(object sender, EventArgs e)
        {
            LoadContent(new SystemSettingsGeneral());
        }

        private void systemusermanagement_Click(object sender, EventArgs e)
        {
            LoadContent(new SystemSettingsUserManagement());
        }

        private void systemappconfigure_Click(object sender, EventArgs e)
        {
            LoadContent(new SystemSettingsAppConfigure());
        }
    }
}
