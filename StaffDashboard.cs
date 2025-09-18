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
    public partial class StaffDashboard : Form
    {
        public StaffDashboard()
        {
            InitializeComponent();

        }

        private void StaffDashboard_Load(object sender, EventArgs e)
        {
            this.Text = "FlavorFlow - Staff Dashboard";
            UpdateDateTime();

            LoadContent(new StaffDashboardMenuForm());
            RoundPanel(panelContent, 15);
            RoundPanel(panel1, 15);
            RoundPanel(panel2, 15);
            RoundPanel(panel3, 15);
            RoundPanel(panel17, 15);
            RoundButton(allitembtn, 15);
            RoundButton(appetizerbtn, 15);
            RoundButton(maincoursesbtn, 15);
            RoundButton(beveragebtn, 15);
            RoundButton(essertbtn, 15);


            allitembtn.FlatStyle = FlatStyle.Flat;
            allitembtn.FlatAppearance.BorderSize = 0;
            allitembtn.UseVisualStyleBackColor = false;

            appetizerbtn.FlatStyle = FlatStyle.Flat;
            appetizerbtn.FlatAppearance.BorderSize = 0;
            appetizerbtn.UseVisualStyleBackColor = false;

            maincoursesbtn.FlatStyle = FlatStyle.Flat;
            maincoursesbtn.FlatAppearance.BorderSize = 0;
            maincoursesbtn.UseVisualStyleBackColor = false;

            beveragebtn.FlatStyle = FlatStyle.Flat;
            beveragebtn.FlatAppearance.BorderSize = 0;
            beveragebtn.UseVisualStyleBackColor = false;

            essertbtn.FlatStyle = FlatStyle.Flat;
            essertbtn.FlatAppearance.BorderSize = 0;
            essertbtn.UseVisualStyleBackColor = false;

           



        }

        private void UpdateDateTime()
        {
            dashaddate.Text = DateTime.Now.ToString("d");
            dashadtime.Text = DateTime.Now.ToString("t");

        }
        private void dashaddate_Click(object sender, EventArgs e) { }

        private void dashadtime_Click(object sender, EventArgs e) { }

        private void RefreshIcon_Click(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            this.Hide();
            StaffDashboard newForm = new StaffDashboard();
            newForm.Show();
            this.Close();


        }

        private void LoadContent(Form form)
        {
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

        private void dashadrefreshicon_Click(object sender, EventArgs e)
        {
            RefreshUI();

        }

        private void staffdashlogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void tablemapbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffTableMap());

        }
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            if (panelContent.Controls.Count > 0 && panelContent.Controls[0] is StaffTableMap tableMap)
            {
                tableMap.RefreshTableStatuses();
            }
        }

        private void onlineordersbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffOnlineOrders());
        }

        private void deliverybtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffDelivery());
        }


        private void menubtn_Click(object sender, EventArgs e)
        {

            LoadContent(new MenuManagement());
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menubtn_Click_1(object sender, EventArgs e)
        {
            LoadContent(new StaffDashboardMenuForm());
        }


        private void RefreshContent()
        {
            panelContent.SuspendLayout(); // stop layout updates
            panelContent.Visible = false; // temporarily hide to reduce flicker

            try
            {
                panelContent.Controls.Clear();
                LoadContent(new StaffDashboardMenuForm()); // reload your menu cards
            }
            finally
            {
                panelContent.Visible = true;
                panelContent.ResumeLayout(); // resume layout updates
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void maincoursesbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffDashboardMenuMainCourses());
        }

        private void essertbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffDashboardDessert());
        }

        private void allitembtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffDashboardMenuForm());
        }

        private void beveragebtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffDashboardBeverages());
        }

        private void appetizerbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffDashboardMenuFormAppetizer());
        }
    }

}