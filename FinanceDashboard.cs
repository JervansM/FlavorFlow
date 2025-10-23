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
    SELECT 
        p.PayrollID,
        p.EmployeeID,
        (e.FirstName + ' ' + e.LastName) AS EmployeeName,
        p.Salary,
        p.DeductionsTotal,
        p.NetPay,
        p.DatePaid,
        p.Overtime,
        p.PeriodID,
        ps.PaymentStatus
    FROM dbo.Payroll p
    INNER JOIN dbo.Employee e ON p.EmployeeID = e.EmployeeID
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

            // Backgrounds and colors
            dgvpayroll.BackgroundColor = Color.WhiteSmoke;
            dgvpayroll.GridColor = Color.LightGray;
            dgvpayroll.DefaultCellStyle.BackColor = Color.White;
            dgvpayroll.DefaultCellStyle.ForeColor = Color.Black;
            dgvpayroll.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvpayroll.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            dgvpayroll.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Fonts — larger and consistent
            dgvpayroll.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 13.5F, FontStyle.Bold);
            dgvpayroll.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12.5F, FontStyle.Regular);

            // Column headers
            dgvpayroll.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvpayroll.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvpayroll.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // left align for cleaner flow
            dgvpayroll.ColumnHeadersHeight = 52;
            dgvpayroll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvpayroll.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 0, 0, 0); // left margin matches cell padding

            // Rows — balanced spacing and consistent margins
            dgvpayroll.RowHeadersVisible = false;
            dgvpayroll.RowTemplate.Height = 50;
            dgvpayroll.DefaultCellStyle.Padding = new Padding(12, 6, 12, 6); // equal left/right padding matching header
            dgvpayroll.AllowUserToResizeRows = false;
            dgvpayroll.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // match header alignment

            // Behavior
            dgvpayroll.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvpayroll.MultiSelect = false;
            dgvpayroll.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvpayroll.BorderStyle = BorderStyle.None;
            dgvpayroll.CellBorderStyle = DataGridViewCellBorderStyle.None;

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
                ShowCustomMessage("Already Paid", "This payroll is already marked as Paid.", MessageBoxIcon.Information); return;
            }

            Form prompt = new Form()
            {
                Width = 400,
                Height = 240,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.FromArgb(35, 35, 35)
            };

            // Rounded corners
            int radius = 20;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(prompt.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(prompt.Width - radius, prompt.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, prompt.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            prompt.Region = new Region(path);

            // Header bar
            Label lblTitle = new Label()
            {
                Text = "Process Payment",
                Dock = DockStyle.Top,
                Height = 50,
                Font = new System.Drawing.Font("Segoe UI", 14, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(45, 45, 45),
                ForeColor = Color.White
            };
            prompt.Controls.Add(lblTitle);

            // Instruction label
            Label lblInstruction = new Label()
            {
                Text = "Enter Payroll ID to confirm:",
                Left = 40,
                Top = 70,
                Width = 300,
                ForeColor = Color.White,
                Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular)
            };

            // Payroll ID textbox
            TextBox txtPayrollID = new TextBox()
            {
                Left = 40,
                Top = 100,
                Width = 300,
                Font = new System.Drawing.Font("Segoe UI", 11),
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // NetPay label
            Label lblNetPay = new Label()
            {
                Text = "Net Pay: ₱0.00",
                Left = 40,
                Top = 135,
                Width = 300,
                ForeColor = Color.FromArgb(0, 200, 100),
                Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Bold)
            };

            // Confirm button
            Button btnConfirm = new Button()
            {
                Text = "Confirm",
                Left = 70,
                Top = 175,
                Width = 110,
                Height = 35,
                DialogResult = DialogResult.OK,
                Enabled = false,
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 150, 255);

            // Cancel button
            Button btnCancel = new Button()
            {
                Text = "Cancel",
                Left = 220,
                Top = 175,
                Width = 110,
                Height = 35,
                DialogResult = DialogResult.Cancel,
                BackColor = Color.FromArgb(64, 64, 64),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 90, 90);

            // Add controls
            prompt.Controls.Add(lblInstruction);
            prompt.Controls.Add(txtPayrollID);
            prompt.Controls.Add(lblNetPay);
            prompt.Controls.Add(btnConfirm);
            prompt.Controls.Add(btnCancel);

            prompt.AcceptButton = btnConfirm;
            prompt.CancelButton = btnCancel;

            // Validation logic
           




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

                    ShowCustomMessage("Success", "Payment processed successfully, Payroll updated, and recorded in Expenses!", MessageBoxIcon.Information);
                    dgvpayroll.DataSource = null;
                    LoadPayrollData();
                    dgvpayroll.Refresh(); // Refresh grid

                }
                catch (Exception ex)
                {
                    ShowCustomMessage("Error", "Error processing payment: " + ex.Message, MessageBoxIcon.Error);
                }
            }

        }
        private DialogResult ShowCustomMessage(string title, string message, MessageBoxIcon icon = MessageBoxIcon.Information, MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            Form msgForm = new Form()
            {
                Width = 400,
                Height = 220,
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.FromArgb(35, 35, 35),
                ForeColor = Color.White,
                FormBorderStyle = FormBorderStyle.None,
                ShowInTaskbar = false
            };

            // Rounded corners
            int radius = 20;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(msgForm.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(msgForm.Width - radius, msgForm.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, msgForm.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            msgForm.Region = new Region(path);

            Label lblTitle = new Label()
            {
                Text = title,
                Font = new System.Drawing.Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Top,
                Height = 50,
                Padding = new Padding(20, 0, 0, 0),
                BackColor = Color.FromArgb(45, 45, 45)
            };

            Label lblMessage = new Label()
            {
                Text = message,
                Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };

            Panel buttonPanel = new Panel()
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                Padding = new Padding(0, 10, 0, 10),
                BackColor = Color.FromArgb(40, 40, 40)
            };

            Button btnOK = new Button()
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Width = 100,
                Height = 35,
                BackColor = Color.FromArgb(70, 70, 70),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 90, 90);

            Button btnCancel = new Button()
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Width = 100,
                Height = 35,
                BackColor = Color.FromArgb(70, 70, 70),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 90, 90);

            // Center buttons dynamically
            if (buttons == MessageBoxButtons.OK)
            {
                btnOK.Location = new Point((msgForm.Width - btnOK.Width) / 2, 10);
                buttonPanel.Controls.Add(btnOK);
                msgForm.AcceptButton = btnOK;
            }
            else if (buttons == MessageBoxButtons.OKCancel)
            {
                btnOK.Location = new Point((msgForm.Width / 2) - 110, 10);
                btnCancel.Location = new Point((msgForm.Width / 2) + 10, 10);
                buttonPanel.Controls.Add(btnOK);
                buttonPanel.Controls.Add(btnCancel);
                msgForm.AcceptButton = btnOK;
                msgForm.CancelButton = btnCancel;
            }

            msgForm.Controls.Add(lblMessage);
            msgForm.Controls.Add(lblTitle);
            msgForm.Controls.Add(buttonPanel);

            // Optional icon
            if (icon != MessageBoxIcon.None)
            {
                PictureBox pb = new PictureBox()
                {
                    Size = new Size(48, 48),
                    Location = new Point(25, 70),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                switch (icon)
                {
                    case MessageBoxIcon.Error:
                        pb.Image = SystemIcons.Error.ToBitmap();
                        break;
                    case MessageBoxIcon.Warning:
                        pb.Image = SystemIcons.Warning.ToBitmap();
                        break;
                    case MessageBoxIcon.Information:
                        pb.Image = SystemIcons.Information.ToBitmap();
                        break;
                    case MessageBoxIcon.Question:
                        pb.Image = SystemIcons.Question.ToBitmap();
                        break;
                }

                msgForm.Controls.Add(pb);
                lblMessage.Padding = new Padding(80, 20, 20, 20);
                lblMessage.TextAlign = ContentAlignment.MiddleLeft;
            }

            return msgForm.ShowDialog();
        }

        private void generatereportbtn_Click(object sender, EventArgs e)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 220,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.FromArgb(35, 35, 35)
            };

            // Rounded corners
            int radius = 20;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(prompt.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(prompt.Width - radius, prompt.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, prompt.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            prompt.Region = new Region(path);

            // Title bar
            Label lblTitle = new Label()
            {
                Text = "Generate Payslip",
                Dock = DockStyle.Top,
                Height = 50,
                Font = new System.Drawing.Font("Segoe UI", 14, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(45, 45, 45),
                ForeColor = Color.White
            };
            prompt.Controls.Add(lblTitle);

            // Instruction label
            Label lblInstruction = new Label()
            {
                Text = "Enter PayrollStatus ID:",
                Left = 40,
                Top = 70,
                Width = 300,
                ForeColor = Color.White,
                Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular)
            };

            // Input box
            TextBox txtPayrollStatusID = new TextBox()
            {
                Left = 40,
                Top = 100,
                Width = 300,
                Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular),
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Confirm button
            Button btnConfirm = new Button()
            {
                Text = "Generate",
                Left = 70,
                Top = 150,
                Width = 110,
                Height = 35,
                DialogResult = DialogResult.OK,
                Enabled = false,
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 150, 255);

            // Cancel button
            Button btnCancel = new Button()
            {
                Text = "Cancel",
                Left = 220,
                Top = 150,
                Width = 110,
                Height = 35,
                DialogResult = DialogResult.Cancel,
                BackColor = Color.FromArgb(64, 64, 64),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 90, 90);

            // Add controls
            prompt.Controls.Add(lblInstruction);
            prompt.Controls.Add(txtPayrollStatusID);
            prompt.Controls.Add(btnConfirm);
            prompt.Controls.Add(btnCancel);

            prompt.AcceptButton = btnConfirm;
            prompt.CancelButton = btnCancel;

            int payrollStatusId = 0;

            // === TEXT VALIDATION & BUTTON ENABLE ===
            txtPayrollStatusID.TextChanged += (s, ev) =>
            {
                if (int.TryParse(txtPayrollStatusID.Text.Trim(), out int id))
                {
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
                                btnConfirm.Enabled = count > 0;
                                payrollStatusId = count > 0 ? id : 0;
                            }
                        }
                    }
                    catch
                    {
                        btnConfirm.Enabled = false;
                        payrollStatusId = 0;
                    }
                }
                else
                {
                    btnConfirm.Enabled = false;
                    payrollStatusId = 0;
                }
            };

            // === DISPLAY PROMPT ===
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
                                    doc.Add(new iTextSharp.text.Paragraph($"Payslip Report for Employee: {row["EmployeeName"]}"));
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

                            ShowCustomMessage("PDF saved successfully!", "Success.", MessageBoxIcon.Information); return;

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

