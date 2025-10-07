using iTextSharp.text;
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
using System.Drawing;
namespace FlavorFlowIT13
{
    public partial class FinanceDashboard : Form
    {
        private readonly string cloudConnectionString = "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";


        public FinanceDashboard()
        {
            InitializeComponent();
            Refresh();
        }

        private void adlogoutbtn_Click(object sender, EventArgs e)
        {
            Login loginform = new Login();
            loginform.Show();
            this.Close();
        }

        private void FinanceDashboard_Load(object sender, EventArgs e)
        {
            dashaddate.Text = DateTime.Now.ToString("d");
            dashtimetxt.Text = DateTime.Now.ToString("t");

            RoundPanel(panel2, 25);
            RoundPanel(panelNav, 25);
            RoundPanel(panel1, 25);
            RoundButton(processpaymentbtn, 20);
            RoundButton(generatereportbtn, 20);
            RoundButton(adlogoutbtn, 20);

            LoadPayrollData();

            processpaymentbtn.UseVisualStyleBackColor = false;
            processpaymentbtn.FlatStyle = FlatStyle.Flat;
            processpaymentbtn.FlatAppearance.BorderSize = 0;
            processpaymentbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            processpaymentbtn.ForeColor = Color.White;
            processpaymentbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            processpaymentbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            generatereportbtn.UseVisualStyleBackColor = false;
            generatereportbtn.FlatStyle = FlatStyle.Flat;
            generatereportbtn.FlatAppearance.BorderSize = 0;
            generatereportbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            generatereportbtn.ForeColor = Color.White;
            generatereportbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            generatereportbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            adlogoutbtn.FlatStyle = FlatStyle.Flat;
            adlogoutbtn.FlatAppearance.BorderSize = 0;
          
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

        private void refreshicon_Click(object sender, EventArgs e)
        {
            RefreshUI();
        }
        private void RefreshUI()
        {

            this.Hide();
            FinanceDashboard newForm = new FinanceDashboard();
            newForm.Show();
            this.Close();

        }

        private void dgvpayroll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadPayrollData()
        {
            StyleUserGrid();
            if (string.IsNullOrEmpty(cloudConnectionString)) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(cloudConnectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT p.PayrollID,
                               p.EmployeeID,
                               s.Name AS EmployeeName,
                               p.Salary,
                               p.DeductionsTotal,
                               p.NetPay,
                               p.DatePaid,
                               p.Overtime,
                               p.PeriodID,
                               ps.PaymentStatus
                        FROM dbo.Payroll p
                        INNER JOIN dbo.Staff s ON p.EmployeeID = s.StaffID
                        LEFT JOIN dbo.PayrollStatus ps ON p.PayrollID = ps.PayrollID
                        ORDER BY p.PayrollID ASC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvpayroll.DataSource = dt;

                    // Optional formatting
                    if (dgvpayroll.Columns.Contains("DatePaid"))
                        dgvpayroll.Columns["DatePaid"].DefaultCellStyle.Format = "yyyy-MM-dd";

                    dgvpayroll.AutoResizeColumns();

                    // Hide EmployeeID if not needed
                    if (dgvpayroll.Columns.Contains("EmployeeID"))
                        dgvpayroll.Columns["EmployeeID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading payroll data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void StyleUserGrid()
        {
            dgvpayroll.EnableHeadersVisualStyles = false;
            dgvpayroll.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvpayroll.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvpayroll.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvpayroll.DefaultCellStyle.BackColor = Color.White;
            dgvpayroll.DefaultCellStyle.ForeColor = Color.Black;
            dgvpayroll.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Regular);
            dgvpayroll.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 13F, FontStyle.Bold);
            dgvpayroll.RowHeadersVisible = false;
            dgvpayroll.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvpayroll.MultiSelect = false;
            dgvpayroll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvpayroll.BorderStyle = BorderStyle.None;
            dgvpayroll.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvpayroll.GridColor = Color.LightGray;
            dgvpayroll.ClearSelection();
            dgvpayroll.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvpayroll.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            dgvpayroll.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvpayroll.BackgroundColor = Color.WhiteSmoke;

            // Add Paint event to draw rounded border
            dgvpayroll.Paint += Dgvpayroll_Paint;
        }

        private void Dgvpayroll_Paint(object sender, PaintEventArgs e)
        {

            int radius = 20; // corner roundness
            int thickness = 2; // border thickness
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(
                thickness / 2,
                thickness / 2,
                dgvpayroll.Width - thickness,
                dgvpayroll.Height - thickness);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90); // top-left
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90); // top-right
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90); // bottom-right
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90); // bottom-left
                path.CloseFigure();

                using (Pen pen = new Pen(Color.Black, thickness))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
        
        private void processpaymentbtn_Click(object sender, EventArgs e)
        {
            if (dgvpayroll.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a payroll to process.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvpayroll.SelectedRows[0];
            int payrollId = Convert.ToInt32(row.Cells["PayrollID"].Value);
            decimal netPay = Convert.ToDecimal(row.Cells["NetPay"].Value);
            string currentStatus = row.Cells["PaymentStatus"].Value?.ToString() ?? "Pending";

            if (currentStatus == "Paid")
            {
                MessageBox.Show("This payroll is already marked as Paid.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Form prompt = new Form()
            {
                Width = 350,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Process Payment",
                StartPosition = FormStartPosition.CenterParent,
                MinimizeBox = false,
                MaximizeBox = false
            };

            Label lblInstruction = new Label() { Left = 20, Top = 20, Width = 300, Text = "Enter Payroll ID:" };
            TextBox txtPayrollID = new TextBox() { Left = 20, Top = 50, Width = 200 };
            Label lblNetPay = new Label() { Left = 20, Top = 90, Width = 300, Text = "NetPay: " };
            Button btnConfirm = new Button() { Text = "Confirm", Left = 50, Width = 100, Top = 130, DialogResult = DialogResult.OK, Enabled = false };
            Button btnCancel = new Button() { Text = "Cancel", Left = 180, Width = 100, Top = 130, DialogResult = DialogResult.Cancel };

            prompt.Controls.Add(lblInstruction);
            prompt.Controls.Add(txtPayrollID);
            prompt.Controls.Add(lblNetPay);
            prompt.Controls.Add(btnConfirm);
            prompt.Controls.Add(btnCancel);

            prompt.AcceptButton = btnConfirm;
            prompt.CancelButton = btnCancel;



            // Validate input and fetch NetPay
            txtPayrollID.TextChanged += (s, ev) =>
            {
                if (int.TryParse(txtPayrollID.Text.Trim(), out int id))
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(cloudConnectionString))
                        {
                            conn.Open();
                            string query = "SELECT p.NetPay, ps.PaymentStatus FROM dbo.Payroll p LEFT JOIN dbo.PayrollStatus ps ON p.PayrollID = ps.PayrollID WHERE p.PayrollID = @PayrollID";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@PayrollID", id);
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        string status = reader["PaymentStatus"]?.ToString();
                                        if (status == "Paid")
                                        {
                                            lblNetPay.Text = "This payroll is already Paid.";
                                            btnConfirm.Enabled = false;
                                            payrollId = 0;
                                            netPay = 0;
                                            return;
                                        }
                                        payrollId = id;
                                        netPay = Convert.ToDecimal(reader["NetPay"]);
                                        lblNetPay.Text = $"NetPay: {netPay:N2}";
                                        btnConfirm.Enabled = true;
                                    }
                                    else
                                    {
                                        lblNetPay.Text = "Invalid Payroll ID";
                                        btnConfirm.Enabled = false;
                                        payrollId = 0;
                                        netPay = 0;
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        lblNetPay.Text = "Error fetching NetPay";
                        btnConfirm.Enabled = false;
                        payrollId = 0;
                        netPay = 0;
                    }
                }
                else
                {
                    lblNetPay.Text = "Enter a valid integer ID";
                    btnConfirm.Enabled = false;
                    payrollId = 0;
                    netPay = 0;
                }
            };

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                if (payrollId == 0)
                {
                    MessageBox.Show("Invalid Payroll ID, cannot process payment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    using (SqlConnection conn = new SqlConnection(cloudConnectionString))
                    {
                        conn.Open();
                        using (SqlTransaction tran = conn.BeginTransaction())
                        {
                            // 1. Update PayrollStatus or insert if not exists
                            string payrollStatusQuery = @"
                        UPDATE dbo.PayrollStatus
                        SET PaymentStatus = 'Paid',
                            DateReceived = GETDATE()
                        WHERE PayrollID = @PayrollID;

                        IF NOT EXISTS (SELECT 1 FROM dbo.PayrollStatus WHERE PayrollID = @PayrollID)
                        BEGIN
                            INSERT INTO dbo.PayrollStatus (PayrollID, EmployeeID, NetPay, DateReceived, PaymentStatus)
                            SELECT PayrollID, EmployeeID, NetPay, GETDATE(), 'Paid'
                            FROM dbo.Payroll
                            WHERE PayrollID = @PayrollID
                        END";

                            using (SqlCommand cmd = new SqlCommand(payrollStatusQuery, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@PayrollID", payrollId);
                                cmd.ExecuteNonQuery();
                            }

                            // 2. Update DatePaid in Payroll table
                            string payrollUpdateQuery = "UPDATE dbo.Payroll SET DatePaid = GETDATE() WHERE PayrollID = @PayrollID";
                            using (SqlCommand cmdUpdate = new SqlCommand(payrollUpdateQuery, conn, tran))
                            {
                                cmdUpdate.Parameters.AddWithValue("@PayrollID", payrollId);
                                cmdUpdate.ExecuteNonQuery();
                            }

                            // 3. Insert into Expenses
                            string expenseQuery = @"
                        INSERT INTO dbo.Expenses (Category, Amount, Date, Notes)
                        SELECT 'Payroll', NetPay, GETDATE(), CONCAT('Payroll payment for EmployeeID ', EmployeeID, ', PayrollID ', PayrollID)
                        FROM dbo.Payroll
                        WHERE PayrollID = @PayrollID";
                            using (SqlCommand cmdExp = new SqlCommand(expenseQuery, conn, tran))
                            {
                                cmdExp.Parameters.AddWithValue("@PayrollID", payrollId);
                                cmdExp.ExecuteNonQuery();
                            }

                            tran.Commit();
                        }
                    }

                    MessageBox.Show("Payment processed successfully, Payroll updated, and recorded in Expenses!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPayrollData(); // Refresh grid
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error processing payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void generatereportbtn_Click(object sender, EventArgs e)
        {
            Form prompt = new Form()
            {
                Width = 350,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Generate Payroll Report",
                StartPosition = FormStartPosition.CenterParent,
                MinimizeBox = false,
                MaximizeBox = false
            };

            Label lblInstruction = new Label() { Left = 20, Top = 20, Width = 300, Text = "Enter PayrollStatus ID:" };
            TextBox txtPayrollStatusID = new TextBox() { Left = 20, Top = 50, Width = 200 };
            Button btnConfirm = new Button() { Text = "Generate", Left = 50, Width = 100, Top = 90, DialogResult = DialogResult.OK, Enabled = false };
            Button btnCancel = new Button() { Text = "Cancel", Left = 180, Width = 100, Top = 90, DialogResult = DialogResult.Cancel };

            prompt.Controls.Add(lblInstruction);
            prompt.Controls.Add(txtPayrollStatusID);
            prompt.Controls.Add(btnConfirm);
            prompt.Controls.Add(btnCancel);

            prompt.AcceptButton = btnConfirm;
            prompt.CancelButton = btnCancel;

            int payrollStatusId = 0;

            txtPayrollStatusID.TextChanged += (s, ev) =>
            {
                if (int.TryParse(txtPayrollStatusID.Text.Trim(), out int id))
                {
                    // Validate if PayrollStatusID exists
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(cloudConnectionString))
                        {
                            conn.Open();
                            string query = "SELECT COUNT(1) FROM dbo.PayrollStatus WHERE PayrollStatusID = @ID";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@ID", id);
                                int count = Convert.ToInt32(cmd.ExecuteScalar());
                                if (count > 0)
                                {
                                    payrollStatusId = id;
                                    btnConfirm.Enabled = true;
                                }
                                else
                                {
                                    payrollStatusId = 0;
                                    btnConfirm.Enabled = false;
                                }
                            }
                        }
                    }
                    catch
                    {
                        payrollStatusId = 0;
                        btnConfirm.Enabled = false;
                    }
                }
                else
                {
                    payrollStatusId = 0;
                    btnConfirm.Enabled = false;
                }
            };

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                if (payrollStatusId == 0)
                {
                    MessageBox.Show("Invalid PayrollStatus ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Fetch payroll status details
                try
                {
                    DataTable dt = new DataTable();
                    using (SqlConnection conn = new SqlConnection(cloudConnectionString))
                    {
                        conn.Open();
                        string query = @"
                    SELECT ps.PayrollStatusID, ps.PayrollID, ps.EmployeeID, ps.NetPay, ps.DateReceived, ps.PaymentStatus,
                           s.Name AS EmployeeName, p.Salary, p.DeductionsTotal, p.DatePaid
                    FROM dbo.PayrollStatus ps
                    INNER JOIN dbo.Payroll p ON ps.PayrollID = p.PayrollID
                    INNER JOIN dbo.Staff s ON ps.EmployeeID = s.StaffID
                    WHERE ps.PayrollStatusID = @ID";
                        using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                        {
                            da.SelectCommand.Parameters.AddWithValue("@ID", payrollStatusId);
                            da.Fill(dt);
                        }
                    }

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("PayrollStatus record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Generate PDF using iTextSharp
                    var row = dt.Rows[0];
                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.Filter = "PDF files (*.pdf)|*.pdf";
                        sfd.FileName = $"PayrollReport_{row["PayrollID"]}.pdf";

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            using (var fs = new System.IO.FileStream(sfd.FileName, System.IO.FileMode.Create))
                            {
                                iTextSharp.text.Document doc = new iTextSharp.text.Document();
                                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fs);
                                doc.Open();
                                doc.Add(new iTextSharp.text.Paragraph($"Payroll Report for Employee: {row["EmployeeName"]}"));
                                doc.Add(new iTextSharp.text.Paragraph($"PayrollStatus ID: {row["PayrollStatusID"]}"));
                                doc.Add(new iTextSharp.text.Paragraph($"Payroll ID: {row["PayrollID"]}"));
                                doc.Add(new iTextSharp.text.Paragraph($"NetPay: {Convert.ToDecimal(row["NetPay"]):N2}"));
                                doc.Add(new iTextSharp.text.Paragraph($"Salary: {Convert.ToDecimal(row["Salary"]):N2}"));
                                doc.Add(new iTextSharp.text.Paragraph($"Deductions: {Convert.ToDecimal(row["DeductionsTotal"]):N2}"));
                                doc.Add(new iTextSharp.text.Paragraph($"Payment Status: {row["PaymentStatus"]}"));
                                doc.Add(new iTextSharp.text.Paragraph($"Date Paid: {row["DatePaid"]}"));
                                doc.Add(new iTextSharp.text.Paragraph($"Date Received: {row["DateReceived"]}"));
                                doc.Close();
                            }

                            MessageBox.Show("PDF saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generating report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        }
    }

