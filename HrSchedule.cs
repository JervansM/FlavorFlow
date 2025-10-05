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

                    // Apply nice formatting
                    scheduleGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    scheduleGrid.BackgroundColor = Color.FromArgb(45, 45, 48);
                    scheduleGrid.ForeColor = Color.White;
                    scheduleGrid.GridColor = Color.Gray;
                    scheduleGrid.DefaultCellStyle.BackColor = Color.FromArgb(62, 62, 66);
                    scheduleGrid.DefaultCellStyle.ForeColor = Color.White;
                    scheduleGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
                    scheduleGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 140, 105);
                    scheduleGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                    scheduleGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    scheduleGrid.EnableHeadersVisualStyles = false;
                    scheduleGrid.AllowUserToAddRows = false;
                    scheduleGrid.ReadOnly = true;
                    scheduleGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    scheduleGrid.RowHeadersVisible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading schedule: " + ex.Message);
            }
        }

        private void hrscheduleschedulebtn_Click(object sender, EventArgs e)
        {
            // Refresh schedule data
            LoadSchedule();
        }

        private void hrscheduledailyttendancebtn_Click(object sender, EventArgs e)
        {
            // Open HrAttendance form and hide current
            HrAttendance attendanceForm = new HrAttendance();
            attendanceForm.Show();
            this.Hide();
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
    }
}
