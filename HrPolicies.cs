using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FlavorFlowIT13
{
    public partial class HrPolicies : Form
    {
        private string connectionString =
            "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlow;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        private List<PolicyRecord> policies;

        public HrPolicies()
        {
            InitializeComponent();
        }

        private void HrPolicies_Load(object sender, EventArgs e)
        {
            LoadPolicies();
            StyleUI();
        }

        // Loads policies from DB into memory, then renders UI cards
        // Loads policies from DB into memory, then renders UI cards
        private void LoadPolicies()
        {
            try
            {
                policies = new List<PolicyRecord>();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT PolicyID, PolicyTitle, Description, CreatedAt
                FROM HRPolicies
                ORDER BY CreatedAt DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var p = new PolicyRecord
                            {
                                PolicyID = reader["PolicyID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["PolicyID"]),
                                PolicyTitle = reader["PolicyTitle"] == DBNull.Value ? "" : reader["PolicyTitle"].ToString(),
                                Description = reader["Description"] == DBNull.Value ? "" : reader["Description"].ToString(),
                                CreatedAt = reader["CreatedAt"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["CreatedAt"]),
                                // Remove Category, EffectiveDate, FilePath since they don't exist
                            };

                            policies.Add(p);
                        }
                    }
                }

                RenderPolicies();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading policies: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Create visual "cards" inside the FlowLayoutPanel
        // Create visual "cards" inside the FlowLayoutPanel
        // Create visual "cards" inside the FlowLayoutPanel
        private void RenderPolicies()
        {
            panelPolicies.SuspendLayout();
            panelPolicies.Controls.Clear();

            // card width adapts to panel width (minus scrollbar)
            int cardWidth = Math.Max(700, panelPolicies.ClientSize.Width - 30);

            foreach (var p in policies)
            {
                // Create expandable card panel
                Panel card = new Panel
                {
                    Width = cardWidth,
                    AutoSize = false,
                    Height = 110, // Initial collapsed height
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.None,
                    Margin = new Padding(10),
                    Tag = new { IsExpanded = false, Policy = p }, // Store state and policy data
                    Cursor = Cursors.Hand
                };

                // Add shadow effect with a border
                card.Paint += (s, e) =>
                {
                    using (Pen borderPen = new Pen(Color.FromArgb(200, 200, 200), 1))
                    {
                        e.Graphics.DrawRectangle(borderPen, 0, 0, card.Width - 1, card.Height - 1);
                    }
                };

                // Title Label
                Label title = new Label
                {
                    Text = p.PolicyTitle,
                    Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(255, 128, 0),
                    AutoSize = true,
                    Location = new Point(20, 15),
                    Cursor = Cursors.Hand
                };

                // Short description (preview)
                Label descPreview = new Label
                {
                    Name = "descPreview",
                    Text = p.Description.Length > 100 ? p.Description.Substring(0, 100) + "..." : p.Description,
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = Color.FromArgb(60, 60, 60),
                    Location = new Point(20, 45),
                    Size = new Size(cardWidth - 40, 35),
                    AutoEllipsis = true,
                    Cursor = Cursors.Hand
                };

                // Full description (hidden initially)
                Label descFull = new Label
                {
                    Name = "descFull",
                    Text = p.Description,
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = Color.FromArgb(60, 60, 60),
                    Location = new Point(20, 45),
                    Size = new Size(cardWidth - 40, 200),
                    Visible = false,
                    AutoSize = false,
                    Cursor = Cursors.Hand
                };

                // Date Label
                Label dateLbl = new Label
                {
                    Text = p.CreatedAt > DateTime.MinValue ? "Created: " + p.CreatedAt.ToString("MMMM dd, yyyy") : "",
                    Font = new Font("Segoe UI", 9F, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point(20, 85),
                    Cursor = Cursors.Hand
                };

                // Expand/Collapse indicator
                Label expandIndicator = new Label
                {
                    Name = "expandIndicator",
                    Text = "▼ Click to view full details",
                    Font = new Font("Segoe UI", 8F, FontStyle.Italic),
                    ForeColor = Color.FromArgb(255, 128, 0),
                    AutoSize = true,
                    Location = new Point(cardWidth - 180, 85),
                    Cursor = Cursors.Hand
                };

                // Add all controls
                card.Controls.Add(title);
                card.Controls.Add(descPreview);
                card.Controls.Add(descFull);
                card.Controls.Add(dateLbl);
                card.Controls.Add(expandIndicator);

                // Click event to expand/collapse
                EventHandler clickHandler = (s, ev) =>
                {
                    dynamic tagData = card.Tag;
                    bool isExpanded = tagData.IsExpanded;

                    if (isExpanded)
                    {
                        // Collapse
                        card.Height = 110;
                        descPreview.Visible = true;
                        descFull.Visible = false;
                        expandIndicator.Text = "▼ Click to view full details";
                        expandIndicator.Location = new Point(cardWidth - 180, 85);
                        card.Tag = new { IsExpanded = false, Policy = tagData.Policy };
                    }
                    else
                    {
                        // Expand
                        int expandedHeight = Math.Max(250, descFull.PreferredHeight + 100);
                        card.Height = expandedHeight;
                        descPreview.Visible = false;
                        descFull.Visible = true;
                        expandIndicator.Text = "▲ Click to collapse";
                        expandIndicator.Location = new Point(cardWidth - 160, expandedHeight - 30);
                        card.Tag = new { IsExpanded = true, Policy = tagData.Policy };
                    }
                };

                // Attach click handlers to all controls
                card.Click += clickHandler;
                title.Click += clickHandler;
                descPreview.Click += clickHandler;
                descFull.Click += clickHandler;
                dateLbl.Click += clickHandler;
                expandIndicator.Click += clickHandler;

                panelPolicies.Controls.Add(card);
            }

            panelPolicies.ResumeLayout();
        }

        // Opens AddPolicyForm; refreshes on OK
        private void btnAddPolicy_Click(object sender, EventArgs e)
        {
            using (AddPolicyForm add = new AddPolicyForm())
            {
                if (add.ShowDialog() == DialogResult.OK)
                    LoadPolicies();
            }
        }

        // small UI tweaks to match the rest of app
        private void StyleUI()
        {
            btnAddPolicy.FlatStyle = FlatStyle.Flat;
            btnAddPolicy.BackColor = Color.FromArgb(255, 128, 0);
            btnAddPolicy.ForeColor = Color.White;
            btnAddPolicy.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddPolicy.Cursor = Cursors.Hand;

            // Style the policies panel
            panelPolicies.BackColor = Color.FromArgb(245, 245, 245);
            panelPolicies.AutoScroll = true;
            panelPolicies.Padding = new Padding(10);
        }
    }

    public class PolicyRecord
    {
        public int PolicyID { get; set; }
        public string PolicyTitle { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        // Removed: Category, EffectiveDate, FilePath
    }
}
