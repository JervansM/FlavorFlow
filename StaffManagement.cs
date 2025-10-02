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
    public partial class StaffManagement : Form
    {
        public StaffManagement()
        {
            InitializeComponent();
           

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

        private void StaffManagement_Load(object sender, EventArgs e)
        {
            RoundPanel(panelContent, 25);
            RoundPanel(panelstaffcontents, 25);
            RoundButton(addnewstaffbtn, 20);

            addnewstaffbtn.UseVisualStyleBackColor = false;
            addnewstaffbtn.FlatStyle = FlatStyle.Flat;
            addnewstaffbtn.FlatAppearance.BorderSize = 0;
            addnewstaffbtn.BackColor = ColorTranslator.FromHtml("LimeGreen");
            addnewstaffbtn.ForeColor = Color.White;
            addnewstaffbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#51A135");
            addnewstaffbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#51A135");

        }
    }
}
