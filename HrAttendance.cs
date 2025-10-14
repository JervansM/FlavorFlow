using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FlavorFlowIT13
{
    public partial class HrAttendance : Form
    {
        private readonly string connectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";


        public HrAttendance()
        {
            InitializeComponent();
            this.Load += HrAttendance_Load;
        }

        private void HrAttendance_Load(object sender, EventArgs e)
        {
            LoadAttendance();

            RoundPanel(systempanelcontents, 25);
            RoundPanel(systemsearchbarpanel, 25);
            RoundPanel(panel5, 19);
            RoundButton(hrattendancedailyttendancebtn, 19);
            RoundButton(hrattendanceschedulebtn, 19);
            RoundButton(hrattendanceadd, 19);



            panel5.BackColor = ColorTranslator.FromHtml("#2f2f2f");

            hrattendanceadd.UseVisualStyleBackColor = false;
            hrattendanceadd.FlatStyle = FlatStyle.Flat;
            hrattendanceadd.FlatAppearance.BorderSize = 0;
            hrattendanceadd.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            hrattendanceadd.ForeColor = Color.White;
            hrattendanceadd.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            hrattendanceadd.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");


            hrattendancedailyttendancebtn.UseVisualStyleBackColor = false;
            hrattendancedailyttendancebtn.FlatStyle = FlatStyle.Flat;
            hrattendancedailyttendancebtn.FlatAppearance.BorderSize = 0;
            hrattendancedailyttendancebtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            hrattendancedailyttendancebtn.ForeColor = Color.White;
            hrattendancedailyttendancebtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            hrattendancedailyttendancebtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            hrattendanceschedulebtn.UseVisualStyleBackColor = false;
            hrattendanceschedulebtn.FlatStyle = FlatStyle.Flat;
            hrattendanceschedulebtn.FlatAppearance.BorderSize = 0;
            hrattendanceschedulebtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            hrattendanceschedulebtn.ForeColor = Color.White;
            hrattendanceschedulebtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            hrattendanceschedulebtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            hrattendanceschedulebtn.UseVisualStyleBackColor = false;
            hrattendanceschedulebtn.FlatStyle = FlatStyle.Flat;
            hrattendanceschedulebtn.FlatAppearance.BorderSize = 0;
            hrattendanceschedulebtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            hrattendanceschedulebtn.ForeColor = Color.White;
            hrattendanceschedulebtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            hrattendanceschedulebtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

        }

        // 🔹 Load attendance data from your database
        private void LoadAttendance()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                   string query = @"
                        SELECT 
                            CONCAT(E.FirstName, ' ', E.LastName) AS EmployeeName,
                            S.Name AS ShiftName,
                            A.Date,
                            A.TimeIn,
                            A.TimeOut,
                            A.Status
                        FROM Attendance A
                        INNER JOIN Employee E ON A.EmployeeID = E.EmployeeID
                        LEFT JOIN Shift S ON A.ShiftID = S.ShiftID
                        ORDER BY A.Date DESC, A.TimeIn DESC;";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAttendance.DataSource = dt;
                }

                StyleUserGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance data: " + ex.Message);
            }
        }

        // 🔹 Save edits made in Time In / Time Out columns
        private void dgvAttendance_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvAttendance.Columns[e.ColumnIndex].HeaderText == "Time In" ||
                    dgvAttendance.Columns[e.ColumnIndex].HeaderText == "Time Out")
                {
                    string scheduleId = dgvAttendance.Rows[e.RowIndex].Cells["Schedule ID"].Value.ToString();
                    string timeIn = dgvAttendance.Rows[e.RowIndex].Cells["Time In"].Value?.ToString();
                    string timeOut = dgvAttendance.Rows[e.RowIndex].Cells["Time Out"].Value?.ToString();

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string updateQuery = "UPDATE ShiftSchedule SET ShiftStart = @timeIn, ShiftEnd = @timeOut WHERE ShiftScheduleID = @id";
                        SqlCommand cmd = new SqlCommand(updateQuery, conn);
                        cmd.Parameters.AddWithValue("@timeIn", string.IsNullOrEmpty(timeIn) ? DBNull.Value : (object)timeIn);
                        cmd.Parameters.AddWithValue("@timeOut", string.IsNullOrEmpty(timeOut) ? DBNull.Value : (object)timeOut);
                        cmd.Parameters.AddWithValue("@id", scheduleId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving edited attendance: " + ex.Message);
            }
        }

        // 🔹 Reload attendance when "Daily Attendance" button is clicked
        private void hrdailyattendancebtn_Click(object sender, EventArgs e)
        {
            LoadAttendance();
        }

        // 🔹 Open the schedule view
        private void hrschedulebtn_Click(object sender, EventArgs e)
        {
            LoadContent(new HrSchedule());
        }

        // 🔹 Reuse existing content loading logic
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



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hrattendanceschedulebtn_Click(object sender, EventArgs e)
        {
            LoadContent(new HrSchedule());
        }

        private void hrattendancedailyttendancebtn_Click(object sender, EventArgs e)
        {
            LoadContent(new HrAttendance());

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
            dgvAttendance.EnableHeadersVisualStyles = false;
            dgvAttendance.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;


            dgvAttendance.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvAttendance.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvAttendance.DefaultCellStyle.BackColor = Color.White;
            dgvAttendance.DefaultCellStyle.ForeColor = Color.Black;
            dgvAttendance.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            dgvAttendance.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            dgvAttendance.RowHeadersVisible = false;
            dgvAttendance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAttendance.MultiSelect = false;
            dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAttendance.BorderStyle = BorderStyle.None;
            dgvAttendance.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvAttendance.GridColor = Color.White;
            dgvAttendance.ClearSelection();
            dgvAttendance.GridColor = Color.LightGray;
            dgvAttendance.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvAttendance.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            dgvAttendance.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvAttendance.BackgroundColor = Color.WhiteSmoke;
        }
        private void hrattendanceadd_Click(object sender, EventArgs e)
        {

        }

        private void dgvAttendance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void systemsearchbar_TextChanged(object sender, EventArgs e)
        {
            string searchText = systemsearchbar.Text.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
SELECT 
    A.AttendanceID,
    E.EmployeeID,
    CONCAT(E.FirstName, ' ', E.LastName) AS EmployeeName,
    S.Name AS ShiftName,
    S.StartTime,
    S.EndTime,
    A.Date,
    A.TimeIn,
    A.TimeOut,
    A.Status
FROM Attendance A
INNER JOIN Employee E ON A.EmployeeID = E.EmployeeID
LEFT JOIN ShiftSchedule SS ON E.EmployeeID = SS.EmployeeID
LEFT JOIN Shift S ON SS.ShiftID = S.ShiftID
WHERE 
    (E.FirstName LIKE @search OR E.LastName LIKE @search OR CONCAT(E.FirstName,' ',E.LastName) LIKE @search OR S.Name LIKE @search)
    AND A.Date BETWEEN SS.EffectiveDate AND SS.ExpiryDate
ORDER BY A.Date DESC;
";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvAttendance.DataSource = dt;

                        StyleUserGrid(); // reapply styling
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching attendance: " + ex.Message);
            }
        }
    }
}
