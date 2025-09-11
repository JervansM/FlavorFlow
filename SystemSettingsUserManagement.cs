using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Logging;
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
    public partial class SystemSettingsUserManagement : Form
    {
        public SystemSettingsUserManagement()
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
            systemgeneralsettings.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            systemgeneralsettings.ForeColor = Color.White;
            systemgeneralsettings.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            systemgeneralsettings.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            systemusermanagement.UseVisualStyleBackColor = false;
            systemusermanagement.FlatStyle = FlatStyle.Flat;
            systemusermanagement.FlatAppearance.BorderSize = 0;
            systemusermanagement.BackColor = ColorTranslator.FromHtml("#6C6868");
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

        private void systemsettingsuseraddicon_Click(object sender, EventArgs e)
        {

            CreateUserAdmin createuseradmin = new CreateUserAdmin();
            createuseradmin.Show();

        }
        private void LoadUsers()
        {
            string connectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
            string query = "SELECT UserID, Username, Role, Password, IsLocked FROM [User]";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvUsers.DataSource = dt;
            }


        }
        private void ToggleLock(int userId, bool lockAccount)
        {
            string connectionString = "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
            string query = "UPDATE [User] SET IsLocked = @IsLocked WHERE UserID = @UserID";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@IsLocked", lockAccount);
                cmd.Parameters.AddWithValue("@UserID", userId);
                con.Open();
                cmd.ExecuteNonQuery();
                LoadUsers();
            }
        }


        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUsers.Columns[e.ColumnIndex].Name == "LockUnlock")
            {
                int userId = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["UserID"].Value);
                bool isLocked = Convert.ToBoolean(dgvUsers.Rows[e.RowIndex].Cells["IsLocked"].Value);

                ToggleLock(userId, !isLocked); // flip value
            }

        }

        private void SystemSettingsUserManagement_Load(object sender, EventArgs e)
        {

            LoadUsers();

        }

        private void systemsettingssavebtn_Click(object sender, EventArgs e)
        {

        }
    }
}
