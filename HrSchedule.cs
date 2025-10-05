using Microsoft.Data.SqlClient;
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
    public partial class HrSchedule : Form
    {
        private readonly string connectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public HrSchedule()
        {
            InitializeComponent();
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

        private void HrSchedule_Load(object sender, EventArgs e)
        {
            LoadSchedule();

            RoundPanel(systempanelcontents, 25);
            RoundPanel(systemsearchbarpanel, 25);
            RoundButton(hrscheduledailyttendancebtn, 19);
            RoundButton(hrscheduleschedulebtn, 19);


            hrscheduledailyttendancebtn.UseVisualStyleBackColor = false;
            hrscheduledailyttendancebtn.FlatStyle = FlatStyle.Flat;
            hrscheduledailyttendancebtn.FlatAppearance.BorderSize = 0;
            hrscheduledailyttendancebtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            hrscheduledailyttendancebtn.ForeColor = Color.White;
            hrscheduledailyttendancebtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            hrscheduledailyttendancebtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            hrscheduleschedulebtn.UseVisualStyleBackColor = false;
            hrscheduleschedulebtn.FlatStyle = FlatStyle.Flat;
            hrscheduleschedulebtn.FlatAppearance.BorderSize = 0;
            hrscheduleschedulebtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            hrscheduleschedulebtn.ForeColor = Color.White;
            hrscheduleschedulebtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            hrscheduleschedulebtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

        }

        private void LoadSchedule()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            ss.ScheduleID,
                            e.FirstName + ' ' + e.LastName AS EmployeeName,
                            e.Position AS Role,
                            sh.Name AS ShiftName,
                            sh.StartTime,
                            sh.EndTime,
                            ss.EffectiveDate,
                            ss.ExpiryDate
                        FROM ShiftSchedule ss
                        INNER JOIN Employee e ON ss.EmployeeID = e.EmployeeID
                        INNER JOIN Shift sh ON ss.ShiftID = sh.ShiftID";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Use the DataGridView from the designer (NOT create a new one)
                    scheduleGrid.DataSource = dt;

                    StyleUserGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading schedule: " + ex.Message);
            }
        }



        private void scheduleGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void hrscheduleschedulebtn_Click(object sender, EventArgs e)
        {
            // Refresh schedule data
            LoadContent(new HrSchedule());
        }

        private void hrscheduledailyttendancebtn_Click(object sender, EventArgs e)
        {
            // Open HrAttendance form and hide current
            LoadContent(new HrAttendance());
        }

        private void scheduleGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click if needed
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void systempanelcontents_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hrSchedule_ValueChanged(object sender, EventArgs e)
        {
            // Your logic when datetimepicker value changes
        }

        private void hrscheduledailyattendancebtn_Click(object sender, EventArgs e)
        {
            // Your logic when clicking attendance button
        }

        private void panelContent_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void systemsearchbar_TextChanged(object sender, EventArgs e)
        {

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

        private void StyleUserGrid()
        {
            scheduleGrid.EnableHeadersVisualStyles = false;
            scheduleGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;


            scheduleGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            scheduleGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            scheduleGrid.DefaultCellStyle.BackColor = Color.White;
            scheduleGrid.DefaultCellStyle.ForeColor = Color.Black;
            scheduleGrid.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            scheduleGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            scheduleGrid.RowHeadersVisible = false;
            scheduleGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            scheduleGrid.MultiSelect = false;
            scheduleGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            scheduleGrid.BorderStyle = BorderStyle.None;
            scheduleGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            scheduleGrid.GridColor = Color.White;
            scheduleGrid.ClearSelection();
            scheduleGrid.GridColor = Color.LightGray;
            scheduleGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            scheduleGrid.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            scheduleGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            scheduleGrid.BackgroundColor = Color.WhiteSmoke;
        }

        private void systemsearchbar_TextChanged_1(object sender, EventArgs e)
        {
            string searchText = systemsearchbar.Text.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT 
                    ss.ScheduleID,
                    e.FirstName + ' ' + e.LastName AS EmployeeName,
                    e.Position AS Role,
                    sh.Name AS ShiftName,
                    sh.StartTime,
                    sh.EndTime,
                    ss.EffectiveDate,
                    ss.ExpiryDate
                FROM ShiftSchedule ss
                INNER JOIN Employee e ON ss.EmployeeID = e.EmployeeID
                INNER JOIN Shift sh ON ss.ShiftID = sh.ShiftID
                WHERE 
                    e.FirstName LIKE @search OR
                    e.LastName LIKE @search OR
                    e.Position LIKE @search OR
                    sh.Name LIKE @search";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        scheduleGrid.DataSource = dt;

                        StyleUserGrid(); // reapply styling
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching schedule: " + ex.Message);
            }
        }

    }
}
