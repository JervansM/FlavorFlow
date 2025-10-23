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
using System.Globalization;


namespace FlavorFlowIT13
{
    public partial class Purchaseorders : Form
    {
        private readonly string cloudConnectionString =
            "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        private readonly string localConnectionString =
            "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        private string activeConnectionString;

        public Purchaseorders()
        {
            InitializeComponent();
            RoundPanel(panelContent, 25);
            RoundPanel(supplierpanelcontents, 25);
            RoundButton(createneworderbtn, 20);
            RoundButton(viewpendingbtn, 20);
            RoundPanel(systemsearchbarpanel, 25);
            RoundButton(paybtn, 20);

            activeConnectionString = GetAvailableConnection();
        }
        private string GetAvailableConnection()
        {
            if (TestConnection(cloudConnectionString))
                return cloudConnectionString;

            if (TestConnection(localConnectionString))
                return localConnectionString;

            MessageBox.Show("No available database connection.", "Database Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        private bool TestConnection(string connectionString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Purchaseorders_Load(object sender, EventArgs e)
        {
            createneworderbtn.UseVisualStyleBackColor = false;
            createneworderbtn.FlatStyle = FlatStyle.Flat;
            createneworderbtn.FlatAppearance.BorderSize = 0;
            createneworderbtn.BackColor = ColorTranslator.FromHtml("Coral");
            createneworderbtn.ForeColor = Color.White;
            createneworderbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#51A135");
            createneworderbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#51A135");

            viewpendingbtn.UseVisualStyleBackColor = false;
            viewpendingbtn.FlatStyle = FlatStyle.Flat;
            viewpendingbtn.FlatAppearance.BorderSize = 0;
            viewpendingbtn.BackColor = ColorTranslator.FromHtml("#E49629");
            viewpendingbtn.ForeColor = Color.White;
            viewpendingbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#A86F1F");
            viewpendingbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#A86F1F");



            paybtn.UseVisualStyleBackColor = false;
            paybtn.FlatStyle = FlatStyle.Flat;
            paybtn.FlatAppearance.BorderSize = 0;
            paybtn.BackColor = ColorTranslator.FromHtml("#2823B1");
            paybtn.ForeColor = Color.White;
            paybtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#312E94");
            paybtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#312E94");

         

            LoadPurchaseOrders();
            LoadPurchaseOrder();


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

        private void createneworderbtn_Click(object sender, EventArgs e)
        {
            SupplierCreateOrder createorder = new SupplierCreateOrder();

            createorder.OrderCreated += (s, args) =>
            {
                LoadPurchaseOrders();
            };
            createorder.Show();
        }

        private void viewpendingbtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(activeConnectionString))
            {
                string query = "SELECT PurchaseOrderID, SupplierID, OrderDate, Status, TotalAmount " +
                               "FROM PurchaseOrder WHERE Status = 'Pending'";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                supplierdatagrid.DataSource = dt;
            }
        }

        private void receivedordersbtn_Click(object sender, EventArgs e)
        {

        }

        private void supplierpanelcontents_Paint(object sender, PaintEventArgs e)
        {

        }

        private void supplierdataflowpanel_Paint(object sender, PaintEventArgs e)
        {

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

        private void supplierdatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadPurchaseOrders()
        {
            StyleUserGrid();
            string sql = @"
        SELECT 
            po.PurchaseOrderID,
            s.Name,
            po.OrderDate,
       
            poi.Quantity,
            poi.UnitCost,
            (poi.Quantity * poi.UnitCost) AS TotalCost,
            po.Status
        FROM PurchaseOrder po
        INNER JOIN PurchaseOrderItem poi ON po.PurchaseOrderID = poi.PurchaseOrderID
        INNER JOIN Supplier s ON po.SupplierID = s.SupplierID
        ORDER BY po.OrderDate DESC";

            try
            {
                using (var conn = new SqlConnection(activeConnectionString))
                using (var cmd = new SqlCommand(sql, conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    supplierdatagrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading purchase orders: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void StyleUserGrid()
        {
            supplierdatagrid.EnableHeadersVisualStyles = false;
            supplierdatagrid.EnableHeadersVisualStyles = false;
            supplierdatagrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // === COLORS & BACKGROUND ===
            supplierdatagrid.BackgroundColor = Color.WhiteSmoke;
            supplierdatagrid.GridColor = Color.LightGray;
            supplierdatagrid.DefaultCellStyle.BackColor = Color.White;
            supplierdatagrid.DefaultCellStyle.ForeColor = Color.Black;
            supplierdatagrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            supplierdatagrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 249, 196); // softer yellow
            supplierdatagrid.DefaultCellStyle.SelectionForeColor = Color.Black;

            // === FONTS — MORE READABLE (LARGER & BOLDER) ===
            supplierdatagrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            supplierdatagrid.DefaultCellStyle.Font = new Font("Segoe UI", 14F, FontStyle.Regular);

            // === COLUMN HEADERS ===
            supplierdatagrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            supplierdatagrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            supplierdatagrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            supplierdatagrid.ColumnHeadersHeight = 65; // taller header for emphasis
            supplierdatagrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            supplierdatagrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(20, 5, 20, 5); // equal margins both sides

            // === ROWS — MORE HEIGHT & EQUAL MARGINS ===
            supplierdatagrid.RowHeadersVisible = false;
            supplierdatagrid.RowTemplate.Height = 60; // taller rows for readability
            supplierdatagrid.DefaultCellStyle.Padding = new Padding(20, 10, 20, 10); // more breathing room
            supplierdatagrid.AllowUserToResizeRows = false;
            supplierdatagrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // align content with headers

            // === BEHAVIOR ===
            supplierdatagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            supplierdatagrid.MultiSelect = false;
            supplierdatagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            supplierdatagrid.BorderStyle = BorderStyle.None;
            supplierdatagrid.CellBorderStyle = DataGridViewCellBorderStyle.None;

            supplierdatagrid.ClearSelection();

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

        private void paybtn_Click(object sender, EventArgs e)
        {
            try
            {
                // === Custom dark rounded popup ===
                Form prompt = new Form()
                {
                    Width = 440, // wider for better text fitting
                    Height = 240,
                    FormBorderStyle = FormBorderStyle.None,
                    StartPosition = FormStartPosition.CenterParent,
                    BackColor = Color.FromArgb(35, 35, 35)
                };

                int radius = 20;
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(prompt.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(prompt.Width - radius, prompt.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, prompt.Height - radius, radius, radius, 90, 90);
                path.CloseAllFigures();
                prompt.Region = new Region(path);

                Label lblTitle = new Label()
                {
                    Text = "Pay Purchase Order",
                    Dock = DockStyle.Top,
                    Height = 55,
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.FromArgb(45, 45, 45),
                    ForeColor = Color.White
                };
                prompt.Controls.Add(lblTitle);

                Label lblInstruction = new Label()
                {
                    Text = "Enter Purchase Order ID:",
                    Left = 50,
                    Top = 75,
                    Width = 340,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 11, FontStyle.Regular)
                };
                prompt.Controls.Add(lblInstruction);

                TextBox txtPOID = new TextBox()
                {
                    Left = 50,
                    Top = 105,
                    Width = 340,
                    Font = new Font("Segoe UI", 11, FontStyle.Regular),
                    BackColor = Color.FromArgb(50, 50, 50),
                    ForeColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle
                };
                prompt.Controls.Add(txtPOID);

                Button btnConfirm = new Button()
                {
                    Text = "Pay",
                    Left = 90,
                    Top = 160,
                    Width = 110,
                    Height = 38,
                    DialogResult = DialogResult.OK,
                    Enabled = false,
                    BackColor = Color.FromArgb(0, 120, 215),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                btnConfirm.FlatAppearance.BorderSize = 0;
                btnConfirm.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 150, 255);
                prompt.Controls.Add(btnConfirm);

                Button btnCancel = new Button()
                {
                    Text = "Cancel",
                    Left = 240,
                    Top = 160,
                    Width = 110,
                    Height = 38,
                    DialogResult = DialogResult.Cancel,
                    BackColor = Color.FromArgb(64, 64, 64),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                btnCancel.FlatAppearance.BorderSize = 0;
                btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 90, 90);
                prompt.Controls.Add(btnCancel);

                // Enable confirm only if user types something
                txtPOID.TextChanged += (s, ev) => btnConfirm.Enabled = !string.IsNullOrWhiteSpace(txtPOID.Text);

                prompt.AcceptButton = btnConfirm;
                prompt.CancelButton = btnCancel;

                // === Show popup ===
                DialogResult result = prompt.ShowDialog();
                if (result != DialogResult.OK) return;

                string input = txtPOID.Text.Trim();
                if (string.IsNullOrEmpty(input)) return;

                if (!int.TryParse(input, out int purchaseOrderId))
                {
                    ShowCustomMessage("Invalid Input", "Please enter a valid numeric Purchase Order ID.", MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(cloudConnectionString))
                {
                    conn.Open();

                    string checkOrder = @"SELECT TotalAmount, Status FROM PurchaseOrder WHERE PurchaseOrderID = @PurchaseOrderID";
                    decimal totalAmount = 0;
                    string status = "";

                    using (SqlCommand cmd = new SqlCommand(checkOrder, conn))
                    {
                        cmd.Parameters.AddWithValue("@PurchaseOrderID", purchaseOrderId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                ShowCustomMessage("Not Found", "Purchase Order not found.", MessageBoxIcon.Error);
                                return;
                            }

                            totalAmount = reader.GetDecimal(0);
                            status = reader.GetString(1);
                        }
                    }

                    if (status == "Paid")
                    {
                        ShowCustomMessage("Already Paid", "This Purchase Order is already paid.", MessageBoxIcon.Information);
                        return;
                    }

                    // === Confirm payment with better text spacing ===
                    CultureInfo ph = new CultureInfo("en-PH");
                    string message =
                        $"Purchase Order #{purchaseOrderId}\n\n" +
                        $"Total Amount: {totalAmount.ToString("C2", ph)}\n\n" +
                        "Are you sure you want to mark this order as PAID?";

                    DialogResult confirm = ShowCustomMessage(
                        "Confirm Payment",
                        message,
                        MessageBoxIcon.Question,
                        MessageBoxButtons.OKCancel
                    );

                    if (confirm != DialogResult.OK) return;

                    // === Update status & record expense ===
                    string updateOrder = @"UPDATE PurchaseOrder
                                   SET Status = 'Paid', UpdatedAt = GETDATE()
                                   WHERE PurchaseOrderID = @PurchaseOrderID";
                    using (SqlCommand cmdUpdate = new SqlCommand(updateOrder, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@PurchaseOrderID", purchaseOrderId);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    string insertExpense = @"INSERT INTO Expenses (Category, Amount, Date, Notes)
                                     VALUES (@Category, @Amount, @Date, @Notes)";
                    using (SqlCommand cmdExpense = new SqlCommand(insertExpense, conn))
                    {
                        cmdExpense.Parameters.AddWithValue("@Category", "Purchase Order Payment");
                        cmdExpense.Parameters.AddWithValue("@Amount", totalAmount);
                        cmdExpense.Parameters.AddWithValue("@Date", DateTime.Now);
                        cmdExpense.Parameters.AddWithValue("@Notes", $"Payment for Purchase Order #{purchaseOrderId}");
                        cmdExpense.ExecuteNonQuery();
                    }

                    ShowCustomMessage("Success", "Payment successful! Expense recorded.", MessageBoxIcon.Information);
                    LoadPurchaseOrder();
                   
                }
            }
            catch (Exception ex)
            {
                ShowCustomMessage("Error", "An error occurred: " + ex.Message, MessageBoxIcon.Error);
            }
        }


        private void LoadPurchaseOrder()
        {
            using (SqlConnection conn = new SqlConnection(activeConnectionString))
            {
                string sql = @"
        SELECT 
            po.PurchaseOrderID,
            s.Name,
            po.OrderDate,
       
            poi.Quantity,
            poi.UnitCost,
            (poi.Quantity * poi.UnitCost) AS TotalCost,
            po.Status
        FROM PurchaseOrder po
        INNER JOIN PurchaseOrderItem poi ON po.PurchaseOrderID = poi.PurchaseOrderID
        INNER JOIN Supplier s ON po.SupplierID = s.SupplierID
        ORDER BY po.OrderDate DESC";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                supplierdatagrid.DataSource = dt;
            }
        }

        private void viewordersbtn_Click(object sender, EventArgs e)
        {
            LoadPurchaseOrders();
        }

        private void systemsearchbar_TextChanged(object sender, EventArgs e)
        {
            string searchText = systemsearchbar.Text.Trim();

            if (string.IsNullOrEmpty(activeConnectionString)) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(activeConnectionString))
                {
                    string query = @"
SELECT 
    po.PurchaseOrderID,
    s.Name AS SupplierName,
    po.OrderDate,
    po.Status,
    po.TotalAmount
FROM PurchaseOrder po
INNER JOIN Supplier s ON po.SupplierID = s.SupplierID
WHERE 
    CAST(po.PurchaseOrderID AS NVARCHAR) LIKE @search
    OR s.Name LIKE @search
    OR po.Status LIKE @search
ORDER BY po.OrderDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        supplierdatagrid.DataSource = dt;

                        StyleUserGrid(); // reapply DataGridView styling
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching purchase orders: " + ex.Message);
            }
        }
    }

}
