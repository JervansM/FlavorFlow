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
    public partial class MenuManagement : Form
    {
        public MenuManagement()
        {
            InitializeComponent();
            RoundPanel(panelContent, 25);
            RoundPanel(systemsearchbarpanel, 25);
            RoundButton(addmenuitembtn, 20);
            RoundButton(menuedititembtn, 20);
            RoundButton(menudeleteitembtn, 20);

            addmenuitembtn.UseVisualStyleBackColor = false;
            addmenuitembtn.FlatStyle = FlatStyle.Flat;
            addmenuitembtn.FlatAppearance.BorderSize = 0;
            addmenuitembtn.BackColor = ColorTranslator.FromHtml("#5CC536");
            addmenuitembtn.ForeColor = Color.White;
            addmenuitembtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#449925");
            addmenuitembtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#449925");

            menuedititembtn.UseVisualStyleBackColor = false;
            menuedititembtn.FlatStyle = FlatStyle.Flat;
            menuedititembtn.FlatAppearance.BorderSize = 0;
            menuedititembtn.BackColor = ColorTranslator.FromHtml("#E49629");
            menuedititembtn.ForeColor = Color.White;
            menuedititembtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#B47E32");
            menuedititembtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#B47E32");

            menudeleteitembtn.UseVisualStyleBackColor = false;
            menudeleteitembtn.FlatStyle = FlatStyle.Flat;
            menudeleteitembtn.FlatAppearance.BorderSize = 0;
            menudeleteitembtn.BackColor = ColorTranslator.FromHtml("#CE1414");
            menudeleteitembtn.ForeColor = Color.White;
            menudeleteitembtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#9A1010");
            menudeleteitembtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#AA834D");
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

        private void addmenuitembtn_Click(object sender, EventArgs e)
        {
            using (var addMenuForm = new MenuManagementAddMenuForm())
            {
                // Show as modal dialog
                var result = addMenuForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Handle data returned from modal form
                    MessageBox.Show("New menu item added!");
                }
            }
        }
        private void menuedititembtn_Click(object sender, EventArgs e)
        {

        }

        private void menudeleteitembtn_Click(object sender, EventArgs e)
        {

        }
    }
}
