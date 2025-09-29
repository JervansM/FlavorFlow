using System;
using System.Windows.Forms;

namespace FlavorFlowIT13
{
    public partial class WebAppCheckOuts : Form
    {
        public WebAppCheckOuts()
        {
            InitializeComponent();
        }

        private void LoadContent(Form form)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Dispose();
            }

            panel1.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panel1.Controls.Add(form);
            form.Show();
        }

        private void webappproceedcheckoutbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new WebAppConfirmation());
        }

        private void webappbackbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new WebAppMenu());
        }
    }
}