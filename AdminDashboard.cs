using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FlavorFlowIT13
{
    public partial class AdminDashboard : Form
    {
        string connectionString = "Data Source=MONTERO-JV;Initial Catalog=FlavorFlowDB;Integrated Security=True;Trust Server Certificate=True";

        public AdminDashboard()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            Refresh();

        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            this.Text = "Admin Dashboard";
            Refresh();

            dashaddate.Text = DateTime.Now.ToString("d");
            dashadtime.Text = DateTime.Now.ToString("t");

            






            RoundButton(dashbtn, 19);
            RoundButton(adsalesbtn, 19);
            RoundButton(adinventorybtn, 19);
            RoundButton(admenubtn, 19);
            RoundButton(adstaffbtn, 19);
            RoundButton(adfinancebtn, 19);
            RoundButton(adsystembtn, 19);
            RoundButton(adlogsbtn, 19);
            RoundButton(adlogoutbtn, 19);
            RoundPanel(panelTop, 30);
            RoundPanel(panelNav, 25);
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





            dashbtn.UseVisualStyleBackColor = false;
            dashbtn.FlatStyle = FlatStyle.Flat;
            dashbtn.FlatAppearance.BorderSize = 0;
            dashbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            dashbtn.ForeColor = Color.White;
            dashbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            dashbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");



            adsalesbtn.UseVisualStyleBackColor = false;
            adsalesbtn.FlatStyle = FlatStyle.Flat;
            adsalesbtn.FlatAppearance.BorderSize = 0;
            adsalesbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            adsalesbtn.ForeColor = Color.White;
            adsalesbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            adsalesbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            adinventorybtn.UseVisualStyleBackColor = false;
            adinventorybtn.FlatStyle = FlatStyle.Flat;
            adinventorybtn.FlatAppearance.BorderSize = 0;
            adinventorybtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            adinventorybtn.ForeColor = Color.White;
            adinventorybtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            adinventorybtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            admenubtn.UseVisualStyleBackColor = false;
            admenubtn.FlatStyle = FlatStyle.Flat;
            admenubtn.FlatAppearance.BorderSize = 0;
            admenubtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            admenubtn.ForeColor = Color.White;
            admenubtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            admenubtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            adstaffbtn.UseVisualStyleBackColor = false;
            adstaffbtn.FlatStyle = FlatStyle.Flat;
            adstaffbtn.FlatAppearance.BorderSize = 0;
            adstaffbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            adstaffbtn.ForeColor = Color.White;
            adstaffbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            adstaffbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");


            adsupplybtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            adsupplybtn.ForeColor = Color.White;

            adfinancebtn.UseVisualStyleBackColor = false;
            adfinancebtn.FlatStyle = FlatStyle.Flat;
            adfinancebtn.FlatAppearance.BorderSize = 0;
            adfinancebtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            adfinancebtn.ForeColor = Color.White;
            adfinancebtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            adfinancebtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            adsystembtn.UseVisualStyleBackColor = false;
            adsystembtn.FlatStyle = FlatStyle.Flat;
            adsystembtn.FlatAppearance.BorderSize = 0;
            adsystembtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            adsystembtn.ForeColor = Color.White;
            adsystembtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            adsystembtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            adlogsbtn.UseVisualStyleBackColor = false;
            adlogsbtn.FlatStyle = FlatStyle.Flat;
            adlogsbtn.FlatAppearance.BorderSize = 0;
            adlogsbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            adlogsbtn.ForeColor = Color.White;
            adlogsbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            adlogsbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            adlogoutbtn.UseVisualStyleBackColor = false;
            adlogoutbtn.FlatStyle = FlatStyle.Flat;
            adlogoutbtn.FlatAppearance.BorderSize = 0;
            adlogoutbtn.BackColor = ColorTranslator.FromHtml("Coral");
            adlogoutbtn.ForeColor = Color.White;
            adlogoutbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("Maroon");
            adlogoutbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("Maroon");


        }
        private void RefreshIcon_Click(object sender, EventArgs e)
        {
            RefreshUI();
        }
        private void RefreshUI()
        {

            this.Hide();
            AdminDashboard newForm = new AdminDashboard();
            newForm.Show();
            this.Close();

        }


        private void adminicon_Click(object sender, EventArgs e)
        {

        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("DarkSlateGray");
            this.ForeColor = Color.White;

        }

        private void adlogoutbtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
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
       

        private void dashbtn_Click(object sender, EventArgs e)
        {
          
           LoadContent(new DashboardContentForm());
          
        }

        private void panelNav_Paint(object sender, PaintEventArgs e)
        {
            panelNav.BackColor = ColorTranslator.FromHtml("Silver");


        }

        private void adsalesbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new SalesPOS());
        }

        private void adinventorybtn_Click(object sender, EventArgs e)
        {
            LoadContent(new InventoryManagement());
        }

        private void admenubtn_Click(object sender, EventArgs e)
        {
            LoadContent(new MenuManagement());
        }

        private void adstaffbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffManagement());
        }

        private void adsupplybtn_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = adsupplybtn.SelectedItem.ToString();

            switch (selected)
            {

                case "Suppliers":
                    LoadContent(new Suppliers());
                    break;
                case "Purchase orders":
                    LoadContent(new Purchaseorders());
                    break;
               
                default:
                    panelContent.Controls.Clear();
                    break;




            }
                

        }

        private void adfinancebtn_Click(object sender, EventArgs e)
        {
            LoadContent(new FinanceExpenses());
        }

        private void adsystembtn_Click(object sender, EventArgs e)
        {
            LoadContent(new SystemSettings());
        }

        private void adlogsbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new AuditsLogsSecurity());
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

        private void userwelcome_Click(object sender, EventArgs e)
        {

        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashnetprofit_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashtotalsales_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashactive_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashnotif_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dashaddate_Click(object sender, EventArgs e)
        {

        }

        private void dashsalestxt_Click(object sender, EventArgs e)
        {

        }

        private void dashrefreshicon_Click(object sender, EventArgs e)
        {

        }

        private void dashadrefreshicon_Click(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void dashadtime_Click(object sender, EventArgs e)
        {

        }




        private bool isToggled = true;
        private void dashactiveon_Click_(object sender, EventArgs e)
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

        private void dashsalescontent_Click(object sender, EventArgs e)
        {

        }
    }
}
    


