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
    public partial class Purchaseorders : Form
    {
        public Purchaseorders()
        {
            InitializeComponent();
            RoundPanel(panelContent, 25);
            RoundPanel(supplierpanelcontents, 25);
            RoundButton(createneworderbtn, 20);
            RoundButton(viewpendingbtn, 20);
            RoundButton(receivedordersbtn, 20);
            RoundPanel(systemsearchbarpanel, 25);
        }
     

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Purchaseorders_Load(object sender, EventArgs e)
        {
            createneworderbtn.UseVisualStyleBackColor = false;
            createneworderbtn.FlatStyle = FlatStyle.Flat;
            createneworderbtn.FlatAppearance.BorderSize = 0;
            createneworderbtn.BackColor = ColorTranslator.FromHtml("#5CC536");
            createneworderbtn.ForeColor = Color.White;
            createneworderbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#51A135");
            createneworderbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#51A135");

            viewpendingbtn.UseVisualStyleBackColor = false;
            viewpendingbtn.FlatStyle = FlatStyle.Flat;
            viewpendingbtn.FlatAppearance.BorderSize = 0;
            viewpendingbtn.BackColor = ColorTranslator.FromHtml("#E49629");
            viewpendingbtn.ForeColor = Color.White;
            viewpendingbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#A86F1F");
            viewpendingbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#A86F1F");

            receivedordersbtn.UseVisualStyleBackColor = false;
            receivedordersbtn.FlatStyle = FlatStyle.Flat;
            receivedordersbtn.FlatAppearance.BorderSize = 0;
            receivedordersbtn.BackColor = ColorTranslator.FromHtml("#1E1E1E");
            receivedordersbtn.ForeColor = Color.White;
            receivedordersbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#464646");
            receivedordersbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#464646");




        }

        private void createneworderbtn_Click(object sender, EventArgs e)
        {

        }

        private void viewpendingbtn_Click(object sender, EventArgs e)
        {

        }

        private void receivedordersbtn_Click(object sender, EventArgs e)
        {

        }

        private void supplierpanelcontents_Paint(object sender, PaintEventArgs e)
        {

        }

        private void supplierdataflowpanel_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
