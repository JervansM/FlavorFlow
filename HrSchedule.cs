using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

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

        private void StyleUserGrid()
        {
            scheduleGrid.EnableHeadersVisualStyles = false;
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
            scheduleGrid.BorderStyle = BorderStyle.FixedSingle;
            scheduleGrid.GridColor = Color.LightGray;
            scheduleGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            scheduleGrid.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            scheduleGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            scheduleGrid.BackgroundColor = Color.WhiteSmoke;
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
    }
}
