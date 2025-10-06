using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;  // use Microsoft.Data.SqlClient

namespace FlavorFlowIT13
{
    public partial class HrGeneratePayroll : Form
    {
        private readonly string connString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        private int selectedPayrollId = 0;
        private bool isEditMode = false;
        private bool isProgrammaticChange = false;

        public HrGeneratePayroll()
        {
            InitializeComponent();
        }

        private void HrGeneratePayroll_Load(object sender, EventArgs e)
        {
            LoadPayrollData();
            LoadEmployeesToComboBox();

            RoundButton(createpayrollbtn, 20);


            createpayrollbtn.UseVisualStyleBackColor = false;
            createpayrollbtn.FlatStyle = FlatStyle.Flat;
            createpayrollbtn.FlatAppearance.BorderSize = 0;
            createpayrollbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            createpayrollbtn.ForeColor = Color.White;
            createpayrollbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            createpayrollbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");


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

        private void LoadPayrollData()
        {

            string query = @"
SELECT 
    p.PayrollID,
    e.EmployeeID,
    (e.FirstName + ' ' + e.LastName) AS [Full Name],
    e.Position,
    e.BasicSalary,
    ISNULL(p.Overtime, 0) AS Overtime,
    ISNULL(p.DeductionsTotal, 
        (SELECT SUM(ad.Amount)
         FROM AllowanceDeduction ad
         WHERE ad.EmployeeID = e.EmployeeID 
           AND (p.PeriodID IS NULL OR ad.PeriodID = p.PeriodID)
           AND ad.Reason NOT LIKE '%Overtime%')) AS Deductions,
    ISNULL(p.NetPay, 0) AS NetPay,
    p.PeriodID
FROM Employee e
LEFT JOIN Payroll p ON e.EmployeeID = p.EmployeeID;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    datageneratepayroll.DataSource = dt;

                    if (datageneratepayroll.Columns.Contains("PayrollID"))
                        datageneratepayroll.Columns["PayrollID"].Visible = false;

                    if (datageneratepayroll.Columns.Contains("PeriodID"))
                        datageneratepayroll.Columns["PeriodID"].Visible = false;

                    datageneratepayroll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    datageneratepayroll.ReadOnly = true;
                    datageneratepayroll.CellDoubleClick -= datageneratepayroll_CellDoubleClick;
                    datageneratepayroll.CellDoubleClick += datageneratepayroll_CellDoubleClick;

                    StyleUserGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading payroll: " + ex.Message);
            }
        }
        private void LoadEmployeesToComboBox()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT EmployeeID, (FirstName + ' ' + LastName) AS FullName FROM Employee";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    employeenametxt.DataSource = dt;
                    employeenametxt.DisplayMember = "FullName";  // what the user sees
                    employeenametxt.ValueMember = "EmployeeID";  // what you can use internally
                    employeenametxt.SelectedIndex = -1;          // no preselected item
                    employeenametxt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    employeenametxt.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee names: " + ex.Message);
            }
        }


        private void FormatGrid()
        {
            if (datageneratepayroll.Columns.Count > 0)
            {
                datageneratepayroll.Columns[0].HeaderText = "Employee ID";
                datageneratepayroll.Columns[1].HeaderText = "Name";
                datageneratepayroll.Columns[2].HeaderText = "Position";
                datageneratepayroll.Columns[3].HeaderText = "Basic Pay";
                datageneratepayroll.Columns[4].HeaderText = "Overtime";
                datageneratepayroll.Columns[5].HeaderText = "Total Deductions";
                datageneratepayroll.Columns[6].HeaderText = "Net Pay";

                datageneratepayroll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                datageneratepayroll.ReadOnly = true;
                datageneratepayroll.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Default cell style
                datageneratepayroll.DefaultCellStyle.ForeColor = Color.Black;
                datageneratepayroll.DefaultCellStyle.BackColor = Color.White;
                datageneratepayroll.DefaultCellStyle.SelectionForeColor = Color.White;
                datageneratepayroll.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;

                // 🔶 Header row style (like your screenshot)
                datageneratepayroll.EnableHeadersVisualStyles = false; // allow custom style
                datageneratepayroll.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
                datageneratepayroll.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                datageneratepayroll.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                datageneratepayroll.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }

        private void StyleUserGrid()
        {
            datageneratepayroll.EnableHeadersVisualStyles = false;
            datageneratepayroll.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;


            datageneratepayroll.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            datageneratepayroll.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            datageneratepayroll.DefaultCellStyle.BackColor = Color.White;
            datageneratepayroll.DefaultCellStyle.ForeColor = Color.Black;
            datageneratepayroll.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            datageneratepayroll.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            datageneratepayroll.RowHeadersVisible = false;
            datageneratepayroll.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datageneratepayroll.MultiSelect = false;
            datageneratepayroll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datageneratepayroll.BorderStyle = BorderStyle.None;
            datageneratepayroll.CellBorderStyle = DataGridViewCellBorderStyle.None;
            datageneratepayroll.GridColor = Color.White;
            datageneratepayroll.ClearSelection();
            datageneratepayroll.GridColor = Color.LightGray;
            datageneratepayroll.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            datageneratepayroll.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            datageneratepayroll.DefaultCellStyle.SelectionForeColor = Color.Black;
            datageneratepayroll.BackgroundColor = Color.WhiteSmoke;
        }

        private void hrpayrollperiodsgeneratepayrolltxt_Click(object sender, EventArgs e)
        {
            LoadPayrollData();
        }

        private void hrpayrollperiodsallowanceanddeductionstxt_Click(object sender, EventArgs e)
        {
        }

        private void datageneratepayroll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void netlbl_Click(object sender, EventArgs e)
        {

        }

        private void payrollperiodidtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void employeenametxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (employeenametxt.SelectedIndex == -1) return;
            if (employeenametxt.SelectedValue == null || employeenametxt.SelectedValue is DataRowView)
                return;

            int employeeId = Convert.ToInt32(employeenametxt.SelectedValue);

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string empQuery = @"SELECT Position, BasicSalary 
                                FROM Employee 
                                WHERE EmployeeID = @EmployeeID";

                    SqlCommand empCmd = new SqlCommand(empQuery, conn);
                    empCmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                    using (SqlDataReader reader = empCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isProgrammaticChange = true; // start programmatic changes

                            positiontxt.Text = reader["Position"].ToString();

                            if (decimal.TryParse(reader["BasicSalary"].ToString(), out decimal basicSalary))
                            {
                                salarytxt.Text = basicSalary.ToString("0.00");

                                daystxt.Text = "26";

                                decimal dailyRate = basicSalary / 26;
                                ratetxt.Text = dailyRate.ToString("0.00");

                                overtimetxt.Text = "0.00";
                                deductionstxt.Text = "0.00";

                                CalculateNet();
                            }

                            isProgrammaticChange = false; // done
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee details: " + ex.Message);
            }

        }
        private bool ValidatePayrollPeriod(string periodId)
        {
            if (string.IsNullOrWhiteSpace(periodId))
            {
                MessageBox.Show("Please enter a Payroll Period ID.");
                return false;
            }

            string query = "SELECT Status FROM PayrollPeriod WHERE PeriodID = @id";
            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", periodId);
                conn.Open();
                var status = cmd.ExecuteScalar()?.ToString();

                if (status == null)
                {
                    MessageBox.Show("Invalid Payroll Period ID.");
                    return false;
                }

                if (status.Equals("Closed", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("This Payroll Period is closed. Cannot create payroll.");
                    return false;
                }

                return true;
            }
        }


        private void positiontxt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void daystxt_TextChanged(object sender, EventArgs e)
        {
            CalculateNet();
        }

        private void ratetxt_TextChanged(object sender, EventArgs e)
        {
            CalculateNet();
        }

        private void deductionstxt_TextChanged(object sender, EventArgs e)
        {
            CalculateNet();

        }
        private void CalculateNet()
        {
            if (!ValidateDays(out decimal daysWorked)) return;

            // Parse other numeric values safely
            decimal.TryParse(ratetxt.Text, out decimal dailyRate);
            decimal.TryParse(overtimetxt.Text, out decimal overtime);
            decimal.TryParse(deductionstxt.Text, out decimal deductions);

            // Salary = RatePerDay × DaysWorked
            decimal salary = dailyRate * daysWorked;
            salarytxt.Text = salary.ToString("0.00");

            // NetPay = Salary + Overtime - Deductions
            decimal netPay = salary + overtime - deductions;
            nettxt.Text = netPay.ToString("0.00");
        }
        private void ClearFields()
        {
            employeenametxt.SelectedIndex = -1;
            positiontxt.SelectedIndex = -1;
            ratetxt.Clear();
            overtimetxt.Clear();
            deductionstxt.Clear();
            salarytxt.Clear();
            nettxt.Clear();
            payrollperiodidtxt.Clear();
            createpayrollbtn.Text = "Create Payroll";
            isEditMode = false;
        }
        private void overtimetxt_TextChanged(object sender, EventArgs e)
        {
            CalculateNet();
        }

        private void nettxt_TextChanged(object sender, EventArgs e)
        {
            CalculateNet();
        }

        private void createpayrollbtn_Click(object sender, EventArgs e)
        {
            string periodId = payrollperiodidtxt.Text.Trim();
            if (!ValidatePayrollPeriod(periodId)) return;

            if (employeenametxt.SelectedValue == null)
            {
                MessageBox.Show("Please select an employee.");
                return;
            }

            int empId = Convert.ToInt32(employeenametxt.SelectedValue);
            decimal salary = Convert.ToDecimal(salarytxt.Text);
            decimal overtime = Convert.ToDecimal(overtimetxt.Text);
            decimal deductions = Convert.ToDecimal(deductionstxt.Text);


            decimal net = Convert.ToDecimal(nettxt.Text);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = isEditMode
                    ? @"UPDATE Payroll 
        SET Salary=@Salary, Overtime=@Overtime, DeductionsTotal=@Deductions, NetPay=@NetPay 
        WHERE PayrollID=@Id"
                    : @"INSERT INTO Payroll (EmployeeID, PeriodID, Salary, Overtime, DeductionsTotal, NetPay) 
        VALUES (@EmployeeID,@PeriodID,@Salary,@Overtime,@Deductions,@NetPay)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (isEditMode)
                        cmd.Parameters.AddWithValue("@Id", selectedPayrollId);

                    cmd.Parameters.AddWithValue("@EmployeeID", empId);
                    cmd.Parameters.AddWithValue("@PeriodID", periodId);
                    cmd.Parameters.AddWithValue("@Salary", salary);
                    cmd.Parameters.AddWithValue("@Overtime", overtime);
                    cmd.Parameters.AddWithValue("@Deductions", deductions);
                    cmd.Parameters.AddWithValue("@NetPay", net);

                    cmd.ExecuteNonQuery();

                }

                MessageBox.Show(isEditMode ? "Payroll updated successfully!" : "Payroll created successfully!");
                ClearFields();
                LoadPayrollData();
            }
        }
        private void datageneratepayroll_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = datageneratepayroll.Rows[e.RowIndex];

            // store selected payroll ID
            if (row.Cells["PayrollID"].Value != DBNull.Value)
                selectedPayrollId = Convert.ToInt32(row.Cells["PayrollID"].Value);
            else
                selectedPayrollId = 0;

            // Fill inputs
            employeenametxt.Text = row.Cells["Full Name"].Value.ToString();
            positiontxt.Text = row.Cells["Position"].Value.ToString();

            salarytxt.Text = row.Cells["BasicSalary"].Value.ToString();
            overtimetxt.Text = row.Cells["Overtime"].Value.ToString();
            deductionstxt.Text = row.Cells["Deductions"].Value.ToString();
            nettxt.Text = row.Cells["NetPay"].Value.ToString();


            // ✅ Calculate rate
            UpdateRatePerDay();

            // switch to edit mode
            isEditMode = true;
            createpayrollbtn.Text = "Update Payroll";
        }


        private void salarytxt_TextChanged(object sender, EventArgs e)
        {
            UpdateRatePerDay();

        }
        private void UpdateRatePerDay()
        {
            {
                if (!decimal.TryParse(salarytxt.Text, out decimal salary)) salary = 0;
                if (!ValidateDays(out decimal daysWorked)) daysWorked = 1;

                decimal rate = salary / daysWorked;
                ratetxt.Text = rate.ToString("0.00");

                // Recalculate net pay after updating rate
                CalculateNet();
            }
        }
        private bool ValidateDays(out decimal daysWorked)
        {
            daysWorked = 0;

            if (!decimal.TryParse(daystxt.Text, out daysWorked))
            {
                if (!isProgrammaticChange)
                    MessageBox.Show("Invalid number of days. Please enter a numeric value.");

                daystxt.Text = "1";
                daysWorked = 1;
                return false;
            }

            if (daysWorked <= 0)
            {
                if (!isProgrammaticChange)
                    MessageBox.Show("Days worked must be at least 1.");

                daystxt.Text = "1";
                daysWorked = 1;
                return false;
            }

            if (daysWorked > 31)
            {
                if (!isProgrammaticChange)
                    MessageBox.Show("Days worked cannot exceed 26.");

                daystxt.Text = "26";
                daysWorked = 26;
                return false;
            }

            return true;

        }
    }
}