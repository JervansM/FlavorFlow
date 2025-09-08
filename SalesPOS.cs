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
    public partial class SalesPOS : Form
    {
        public SalesPOS()
        {
            InitializeComponent();

            RoundPanel(salesposaverageordervaluetxt, 25);
            RoundPanel(salespostotalsalessummarytxt, 25);
            RoundPanel(salespospanelcontents, 25);
            RoundPanel(salespostotalsalesdatapanel, 25);
            RoundPanel(salespostotalordersdatapanel, 25);
            RoundPanel(averageordervaluepanel, 25);
            RoundPanel(salesposgrossrevenuepanel, 25);
            RoundPanel(salesposdiscountappliedpanel, 25);
            RoundPanel(saleposrefundspanel, 25);
            RoundPanel(salespostotalsalespanel, 25);

            salespostotalsalessummarytxt.BackColor = ColorTranslator.FromHtml("#2823B1");
            salespostotalsalessummarytxt.ForeColor = Color.White;


        }



        private void panelContent_Paint(object sender, PaintEventArgs e)
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

        private void SalesPOS_Load(object sender, EventArgs e)
        {

        }

        private void systemsearchbarpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void salespospanelcontents_Paint(object sender, PaintEventArgs e)
        {

        }

        private void salespanelsalespospanelcontentsheader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void salespostotalsalessummarytxt_Click(object sender, EventArgs e)
        {

        }

        private void panelContent_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void salespostotalsalesdatapaneltxt_Click(object sender, EventArgs e)
        {

        }

        private void salespostotalordersdatapanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void salespostotalsalesdatapaneltxt_Click_1(object sender, EventArgs e)
        {

        }

        private void salespostotalsalesdatapaneltxtdata_Click(object sender, EventArgs e)
        {

        }

        private void salespostotalordersdatapaneltxt_Click(object sender, EventArgs e)
        {

        }

        private void salesposaverageordervaluetxtdata_Click(object sender, EventArgs e)
        {

        }

        private void salespostotalsalesdatapanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void averageordervaluepanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void salesposgrossrevenuepanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
