using System;
using System.Windows.Forms;

namespace FlavorFlowIT13
{
    public partial class WebAppMenu : Form
    {
        public WebAppMenu()
        {
            InitializeComponent();
        }



        private void WebAppMenu_Load(object sender, EventArgs e)
        {
            // You can initialize any data or settings here when the form loads.
            // For example, load menu items or initial settings.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Assuming button1 is for checking out
            LoadContent(new WebAppCheckOuts());
        }

        private void maincoursebtn_Click(object sender, EventArgs e)
        {

        }

        private void LoadContent(Form form)
        {
            try
            {
                // Clear previous content
                this.Controls.Clear();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                this.Controls.Add(form);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading content: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}