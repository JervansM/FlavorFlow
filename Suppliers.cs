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
    public partial class Suppliers : Form
    {
        private readonly string cloudConnectionString =
            "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        private readonly string localConnectionString =
            "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        private string activeConnectionString;
        public Suppliers()
        {
            InitializeComponent();
            RoundPanel(panelContent, 25);
            RoundPanel(supplierpanelcontents, 25);
            RoundButton(addnewsupplierbtn, 20);
            RoundPanel(systemsearchbarpanel, 25);


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
        private void LoadSupplierData()
        {
            if (string.IsNullOrEmpty(activeConnectionString))
                return;

            try
            {
                using (var conn = new SqlConnection(activeConnectionString))
                using (var cmd = new SqlCommand(@"
            SELECT 
                s.SupplierID,
                s.Name,
                s.Contact,
                s.Address,
                ISNULL(STUFF((
                    SELECT ', ' + i.ItemName
                    FROM Inventory i
                    WHERE i.SupplierID = s.SupplierID
                    FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, ''), 'No items') AS ItemsSupplied
            FROM Supplier s
            ORDER BY s.Name", conn))
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    supplierdataflowpanel.SuspendLayout();
                    supplierdataflowpanel.Controls.Clear();

                    foreach (DataRow row in dt.Rows)
                    {
                        int supplierId = Convert.ToInt32(row["SupplierID"]);

                        Panel card = new Panel
                        {
                            Width = supplierdataflowpanel.ClientSize.Width - 40, // auto adjust width
                            Height = 120,
                            BackColor = Color.White,
                            Margin = new Padding(10),
                            Padding = new Padding(10),
                            BorderStyle = BorderStyle.FixedSingle,
                            Tag = supplierId
                        };

                        Label nameLabel = new Label
                        {
                            Text = row["Name"].ToString(),
                            Font = new Font("Segoe UI", 12, FontStyle.Bold),
                            AutoSize = true,
                            ForeColor = Color.Black,
                            Location = new Point(10, 10)
                        };

                        Label contactLabel = new Label
                        {
                            Text = $"📞 {row["Contact"]}",
                            Font = new Font("Segoe UI", 10, FontStyle.Regular),
                            AutoSize = true,
                            ForeColor = Color.DimGray,
                            Location = new Point(10, 35)
                        };

                        Label addressLabel = new Label
                        {
                            Text = $"🏠 {row["Address"]}",
                            Font = new Font("Segoe UI", 9, FontStyle.Regular),
                            AutoSize = true,
                            ForeColor = Color.Gray,
                            Location = new Point(10, 55)
                        };

                        Label itemsLabel = new Label
                        {
                            Text = $"📦 {row["ItemsSupplied"]}",
                            Font = new Font("Segoe UI", 9, FontStyle.Italic),
                            AutoSize = true,
                            ForeColor = Color.DarkGreen,
                            Location = new Point(10, 75)
                        };

                        card.Controls.Add(nameLabel);
                        card.Controls.Add(contactLabel);
                        card.Controls.Add(addressLabel);
                        card.Controls.Add(itemsLabel);

                        // DOUBLE-CLICK EDIT
                        card.DoubleClick += (s, e) =>
                        {
                            int id = (int)((Panel)s).Tag;
                            using (var editForm = new SupplierAddForm(id))
                            {
                                if (editForm.ShowDialog() == DialogResult.OK)
                                {
                                    LoadSupplierData();
                                }
                            }
                        };

                        supplierdataflowpanel.Controls.Add(card);
                    }

                    supplierdataflowpanel.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading suppliers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void Suppliers_Load(object sender, EventArgs e)
        {
            addnewsupplierbtn.UseVisualStyleBackColor = false;
            addnewsupplierbtn.FlatStyle = FlatStyle.Flat;
            addnewsupplierbtn.FlatAppearance.BorderSize = 0;
            addnewsupplierbtn.BackColor = ColorTranslator.FromHtml("Coral");
            addnewsupplierbtn.ForeColor = Color.White;
            addnewsupplierbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#51A135");
            addnewsupplierbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#51A135");


            LoadSupplierData();

        }

        private void addnewsupplierbtn_Click(object sender, EventArgs e)
        {
            using (var addForm = new SupplierAddForm()) // no ID = Add mode
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadSupplierData();
                }
            }
        }

        private void supplierpanelcontents_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void supplierdataflowpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void systemsearchbar_TextChanged(object sender, EventArgs e)
        {
            string keyword = systemsearchbar.Text.Trim();
            LoadSupplierData(keyword);
        }
        private void LoadSupplierData(string keyword = "")
        {
            if (string.IsNullOrEmpty(activeConnectionString))
                return;

            try
            {
                using (var conn = new SqlConnection(activeConnectionString))
                {
                    string query = @"
                        SELECT 
                            s.SupplierID,
                            s.Name,
                            s.Contact,
                            s.Address,
                            ISNULL(STUFF((
                                SELECT ', ' + i.ItemName
                                FROM Inventory i
                                WHERE i.SupplierID = s.SupplierID
                                FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, ''), 'No items') AS ItemsSupplied
                        FROM Supplier s";

                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        query += @"
                            WHERE 
                                s.Name LIKE @keyword OR 
                                s.Contact LIKE @keyword OR 
                                s.Address LIKE @keyword";
                    }

                    query += " ORDER BY s.Name";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(keyword))
                            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);

                            supplierdataflowpanel.SuspendLayout();
                            supplierdataflowpanel.Controls.Clear();

                            foreach (DataRow row in dt.Rows)
                            {
                                int supplierId = Convert.ToInt32(row["SupplierID"]);

                                Panel card = new Panel
                                {
                                    Width = supplierdataflowpanel.ClientSize.Width - 40,
                                    Height = 120,
                                    BackColor = Color.White,
                                    Margin = new Padding(10),
                                    Padding = new Padding(10),
                                    BorderStyle = BorderStyle.FixedSingle,
                                    Tag = supplierId
                                };

                                Label nameLabel = new Label
                                {
                                    Text = row["Name"].ToString(),
                                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                                    AutoSize = true,
                                    ForeColor = Color.Black,
                                    Location = new Point(10, 10)
                                };

                                Label contactLabel = new Label
                                {
                                    Text = $"📞 {row["Contact"]}",
                                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                                    AutoSize = true,
                                    ForeColor = Color.DimGray,
                                    Location = new Point(10, 35)
                                };

                                Label addressLabel = new Label
                                {
                                    Text = $"🏠 {row["Address"]}",
                                    Font = new Font("Segoe UI", 9, FontStyle.Regular),
                                    AutoSize = true,
                                    ForeColor = Color.Gray,
                                    Location = new Point(10, 55)
                                };

                                Label itemsLabel = new Label
                                {
                                    Text = $"📦 {row["ItemsSupplied"]}",
                                    Font = new Font("Segoe UI", 9, FontStyle.Italic),
                                    AutoSize = true,
                                    ForeColor = Color.DarkGreen,
                                    Location = new Point(10, 75)
                                };

                                card.Controls.Add(nameLabel);
                                card.Controls.Add(contactLabel);
                                card.Controls.Add(addressLabel);
                                card.Controls.Add(itemsLabel);

                                // DOUBLE-CLICK = EDIT
                                card.DoubleClick += (s, e) =>
                                {
                                    int id = (int)((Panel)s).Tag;
                                    using (var editForm = new SupplierAddForm(id))
                                    {
                                        if (editForm.ShowDialog() == DialogResult.OK)
                                        {
                                            LoadSupplierData(systemsearchbar.Text.Trim());
                                        }
                                    }
                                };

                                supplierdataflowpanel.Controls.Add(card);
                            }

                            supplierdataflowpanel.ResumeLayout();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading suppliers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
