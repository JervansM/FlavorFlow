using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace FlavorFlowIT13
{
    public partial class StaffDashboard : Form
    {
        public DataGridView OrderGrid => orderDataGridView;
        private readonly string localConnectionString =
          "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        private readonly string cloudConnectionString =
            "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        private string connectionString;


        private int currentStaffId;

        private List<OrderItem> currentOrderItems = new List<OrderItem>();

        // Payment method tracking
        private string? selectedPaymentMethod = null;

        // Order type tracking
        private string? selectedOrderType = null;

        public StaffDashboard(int staffId)

        {
            InitializeComponent();
            currentStaffId = staffId;

            if (CanConnect(cloudConnectionString))
            {
                connectionString = cloudConnectionString;
                Console.WriteLine("✅ Using Cloud Database");
            }
            else
            {
                connectionString = localConnectionString;
                Console.WriteLine("⚡ Using Local Database (cloud not reachable)");
            }

        }
        private bool CanConnect(string connStr)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void StaffDashboard_Load(object sender, EventArgs e)
        {
            this.Text = "FlavorFlow - Staff Dashboard";
            UpdateDateTime();

            LoadContent(new StaffDashboardMenuForm());
            RoundPanel(panelContent, 15);
            RoundPanel(panel1, 15);
            RoundPanel(panel2, 15);
            RoundPanel(panel3, 15);
            RoundPanel(panel17, 15);
            RoundButton(allitembtn, 19);
            RoundButton(appetizerbtn, 19);
            RoundButton(maincoursesbtn, 19);
            RoundButton(beveragebtn, 19);
            RoundButton(essertbtn, 19);
            RoundButton(dineinbtn, 10);
            RoundButton(tablemapbtn, 19);
            RoundButton(takeoutbtn, 19);
            RoundButton(onlineordersbtn, 19);
            RoundButton(deliverybtn, 19);
            RoundButton(menubtn, 19);
            RoundButton(takeoutbtn2, 10);
            RoundButton(applydiscountbtn, 19);
            RoundButton(saveorderbtn, 19);
            RoundButton(voidbtn, 19);
            RoundButton(addorderbtn, 19);
            RoundButton(sendtokitchenbtn, 19);
            RoundButton(printbillbtn, 19);
            RoundButton(okbtn, 19);
            RoundButton(staffdashlogout, 19);

            //8E9A57//
            staffdashlogout.FlatStyle = FlatStyle.Flat;
            staffdashlogout.FlatAppearance.BorderSize = 0;
            staffdashlogout.UseVisualStyleBackColor = false;
            staffdashlogout.BackColor = ColorTranslator.FromHtml("Maroon");
            staffdashlogout.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            staffdashlogout.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            tablemapbtn.FlatStyle = FlatStyle.Flat;
            tablemapbtn.FlatAppearance.BorderSize = 0;
            tablemapbtn.UseVisualStyleBackColor = false;
            tablemapbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            tablemapbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            tablemapbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            takeoutbtn.FlatStyle = FlatStyle.Flat;
            takeoutbtn.FlatAppearance.BorderSize = 0;
            takeoutbtn.UseVisualStyleBackColor = false;
            takeoutbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            takeoutbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            takeoutbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            onlineordersbtn.FlatStyle = FlatStyle.Flat;
            onlineordersbtn.FlatAppearance.BorderSize = 0;
            onlineordersbtn.UseVisualStyleBackColor = false;
            onlineordersbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            onlineordersbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            onlineordersbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            deliverybtn.FlatStyle = FlatStyle.Flat;
            deliverybtn.FlatAppearance.BorderSize = 0;
            deliverybtn.UseVisualStyleBackColor = false;
            deliverybtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            deliverybtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            deliverybtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            menubtn.FlatStyle = FlatStyle.Flat;
            menubtn.FlatAppearance.BorderSize = 0;
            menubtn.UseVisualStyleBackColor = false;
            menubtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            menubtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            menubtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");


            allitembtn.FlatStyle = FlatStyle.Flat;
            allitembtn.FlatAppearance.BorderSize = 0;
            allitembtn.UseVisualStyleBackColor = false;
            allitembtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            allitembtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            allitembtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");



            appetizerbtn.FlatStyle = FlatStyle.Flat;
            appetizerbtn.FlatAppearance.BorderSize = 0;
            appetizerbtn.UseVisualStyleBackColor = false;
            appetizerbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            appetizerbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            appetizerbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            maincoursesbtn.FlatStyle = FlatStyle.Flat;
            maincoursesbtn.FlatAppearance.BorderSize = 0;
            maincoursesbtn.UseVisualStyleBackColor = false;
            maincoursesbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            maincoursesbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            maincoursesbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            beveragebtn.FlatStyle = FlatStyle.Flat;
            beveragebtn.FlatAppearance.BorderSize = 0;
            beveragebtn.UseVisualStyleBackColor = false;
            beveragebtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            beveragebtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            beveragebtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            essertbtn.FlatStyle = FlatStyle.Flat;
            essertbtn.FlatAppearance.BorderSize = 0;
            essertbtn.UseVisualStyleBackColor = false;
            essertbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            essertbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            essertbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            dineinbtn.FlatStyle = FlatStyle.Flat;
            dineinbtn.FlatAppearance.BorderSize = 0;
            dineinbtn.UseVisualStyleBackColor = false;
            dineinbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            dineinbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            dineinbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            takeoutbtn2.FlatStyle = FlatStyle.Flat;
            takeoutbtn2.FlatAppearance.BorderSize = 0;
            takeoutbtn2.UseVisualStyleBackColor = false;
            takeoutbtn2.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            takeoutbtn2.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            takeoutbtn2.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            applydiscountbtn.FlatStyle = FlatStyle.Flat;
            applydiscountbtn.FlatAppearance.BorderSize = 0;
            applydiscountbtn.UseVisualStyleBackColor = false;
            applydiscountbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            applydiscountbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            applydiscountbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            saveorderbtn.FlatStyle = FlatStyle.Flat;
            saveorderbtn.FlatAppearance.BorderSize = 0;
            saveorderbtn.UseVisualStyleBackColor = false;
            saveorderbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            saveorderbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            saveorderbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            voidbtn.FlatStyle = FlatStyle.Flat;
            voidbtn.FlatAppearance.BorderSize = 0;
            voidbtn.UseVisualStyleBackColor = false;
            voidbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            voidbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            voidbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            addorderbtn.FlatStyle = FlatStyle.Flat;
            addorderbtn.FlatAppearance.BorderSize = 0;
            addorderbtn.UseVisualStyleBackColor = false;
            addorderbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            addorderbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            addorderbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            sendtokitchenbtn.FlatStyle = FlatStyle.Flat;
            sendtokitchenbtn.FlatAppearance.BorderSize = 0;
            sendtokitchenbtn.UseVisualStyleBackColor = false;
            sendtokitchenbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            sendtokitchenbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            sendtokitchenbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");

            printbillbtn.FlatStyle = FlatStyle.Flat;
            printbillbtn.FlatAppearance.BorderSize = 0;
            printbillbtn.UseVisualStyleBackColor = false;



            okbtn.FlatStyle = FlatStyle.Flat;
            okbtn.FlatAppearance.BorderSize = 0;
            okbtn.UseVisualStyleBackColor = false;
            okbtn.BackColor = ColorTranslator.FromHtml("#2f2f2f");
            okbtn.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#3a3a3a");
            okbtn.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e1e1e");


            cashbtn.FlatStyle = FlatStyle.Flat;
            cashbtn.FlatAppearance.BorderSize = 0;
            cashbtn.UseVisualStyleBackColor = false;

            gcashbtn.FlatStyle = FlatStyle.Flat;
            gcashbtn.FlatAppearance.BorderSize = 0;
            gcashbtn.UseVisualStyleBackColor = false;

            cardbtn.FlatStyle = FlatStyle.Flat;
            cardbtn.FlatAppearance.BorderSize = 0;
            cardbtn.UseVisualStyleBackColor = false;



            discounttxt.TextChanged += discounttxt_TextChanged;
            orderDataGridView.CellValueChanged += orderDataGridView_CellValueChanged;
            biilingamounttxt.Text = "₱0.00";

            UpdateTotals();
        }

        private void StyleUserGrid()
        {
            orderDataGridView.EnableHeadersVisualStyles = false;
        

            orderDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215);
            orderDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            orderDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            orderDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            orderDataGridView.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 6, 8, 6);
            orderDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);

            orderDataGridView.DefaultCellStyle.BackColor = Color.White;
            orderDataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            orderDataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            orderDataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            orderDataGridView.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);

            orderDataGridView.DefaultCellStyle.SelectionBackColor = orderDataGridView.DefaultCellStyle.BackColor;
            orderDataGridView.DefaultCellStyle.SelectionForeColor = orderDataGridView.DefaultCellStyle.ForeColor;
            orderDataGridView.AlternatingRowsDefaultCellStyle.SelectionBackColor =
                orderDataGridView.AlternatingRowsDefaultCellStyle.BackColor;
            orderDataGridView.AlternatingRowsDefaultCellStyle.SelectionForeColor =
                orderDataGridView.AlternatingRowsDefaultCellStyle.ForeColor;

            orderDataGridView.RowHeadersVisible = false;
            orderDataGridView.MultiSelect = false;
            orderDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            orderDataGridView.BorderStyle = BorderStyle.None;
            orderDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            orderDataGridView.GridColor = Color.FromArgb(230, 230, 230);

            orderDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            orderDataGridView.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);

            orderDataGridView.BackgroundColor = Color.FromArgb(248, 249, 250);

            orderDataGridView.RowTemplate.Height = 30;

            orderDataGridView.ScrollBars = ScrollBars.Vertical;

            orderDataGridView.ReadOnly = true;
            orderDataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;

            orderDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            orderDataGridView.ClearSelection();
            orderDataGridView.SelectionChanged += (s, e) => orderDataGridView.ClearSelection();

            orderDataGridView.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    orderDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
                }
            };

            orderDataGridView.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    orderDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                        e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(250, 250, 250);
                }
            };
        }




        private void StyleTextBox(TextBox textBox)
        {
            if (textBox != null)
            {
                textBox.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
                textBox.BackColor = Color.White;
                textBox.ForeColor = Color.FromArgb(50, 50, 50);
                textBox.BorderStyle = BorderStyle.FixedSingle;
                textBox.Padding = new Padding(6, 4, 6, 4);

                // Add focus effects
                textBox.Enter += (s, e) =>
                {
                    textBox.BackColor = Color.FromArgb(240, 248, 255);
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                };

                textBox.Leave += (s, e) =>
                {
                    textBox.BackColor = Color.White;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                };
            }
        }

        private void StyleLabel(Label label)
        {
            if (label != null)
            {
                label.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
                label.ForeColor = Color.FromArgb(50, 50, 50);
                label.BackColor = Color.Transparent;
            }
        }

        private void ClearOrderCompletely()
        {
            // Clear the data grid completely
            orderDataGridView.DataSource = null;
            orderDataGridView.Rows.Clear();
            orderDataGridView.Refresh();

            // Clear order items list
            currentOrderItems.Clear();

            // Reset payment method and order type completely
            selectedPaymentMethod = null;
            selectedOrderType = null;
            ResetPaymentButtonStyles();

            // Clear all text fields
            fixedamounttxt.Text = "0.00";
            biilingamounttxt.Text = "₱0.00";
            discounttxt.Clear();
            qtytxt.Text = "0";
            totaltxt.Text = "0.00";
            taxtxt.Text = "0.00";
            netamounttxt.Text = "0.00";
            changetxt.Text = "₱0.00";

            UpdateTotals();
        }

        private void UpdateDateTime()
        {
            dashaddate.Text = DateTime.Now.ToString("d");
            dashadtime.Text = DateTime.Now.ToString("t");

        }
        private void dashaddate_Click(object sender, EventArgs e) { }

        private void dashadtime_Click(object sender, EventArgs e) { }

        private void RefreshIcon_Click(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            this.Hide();
            StaffDashboard newForm = new StaffDashboard(currentStaffId); // Pass the required staffId argument
            newForm.Show();
            this.Close();
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

        private void dashadrefreshicon_Click(object sender, EventArgs e)
        {
            RefreshUI();

        }

        private void staffdashlogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void tablemapbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffTableMap());

        }
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            if (panelContent.Controls.Count > 0 && panelContent.Controls[0] is StaffTableMap tableMap)
            {
                tableMap.RefreshTableStatuses();
            }
        }

        private void onlineordersbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffOnlineOrders());
        }

        private void deliverybtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffDelivery());
        }


        private void menubtn_Click(object sender, EventArgs e)
        {

            LoadContent(new MenuManagement());
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menubtn_Click_1(object sender, EventArgs e)
        {
            LoadContent(new StaffDashboardMenuForm());
        }


        private void RefreshContent()
        {
            panelContent.SuspendLayout(); // stop layout updates
            panelContent.Visible = false; // temporarily hide to reduce flicker

            try
            {
                panelContent.Controls.Clear();
                LoadContent(new StaffDashboardMenuForm()); // reload your menu cards
            }
            finally
            {
                panelContent.Visible = true;
                panelContent.ResumeLayout(); // resume layout updates
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void maincoursesbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffDashboardMenuMainCourses());
        }

        private void essertbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffDashboardDessert());
        }

        private void allitembtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffDashboardMenuForm());
        }

        private void beveragebtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffDashboardBeverages());
        }

        private void appetizerbtn_Click(object sender, EventArgs e)
        {
            LoadContent(new StaffDashboardMenuFormAppetizer());
        }

        private void dineinbtn_Click(object sender, EventArgs e)
        {
            selectedOrderType = "Dine In";
            System.Diagnostics.Debug.WriteLine($"Dine In button clicked. selectedOrderType set to: {selectedOrderType}");

            var tableMapForm = new StaffTableMapOrder();
            tableMapForm.TableSelected += OnTableSelected;
            LoadContent(tableMapForm); // Shows table map in panelContent
            ClearOrder();
            // Clear existing columns and data
            orderDataGridView.Columns.Clear();
            orderDataGridView.Rows.Clear();
            StyleUserGrid();
        }

        private void takeoutbtn_Click(object sender, EventArgs e)
        {
            selectedOrderType = "Takeout";
            System.Diagnostics.Debug.WriteLine($"Takeout button clicked. selectedOrderType set to: {selectedOrderType}");

            ClearOrder();
            InitializeDataGridViewForTakeout();


          

            var menuForm = new StaffDashboardMenuFormOrder("Takeout");

            // Subscribe to menu item clicks for takeout
            menuForm.MenuItemClicked += OnTakeoutMenuItemClicked;

            LoadContent(menuForm);
        }

        // Public method that can be called from menu forms to add takeout items
        public void AddTakeoutItem(string menuItemName, decimal price)
        {
            if (selectedOrderType == "Takeout")
            {
                // Show quantity input dialog for takeout orders
                int quantity = ShowQuantityInputDialog(menuItemName);

                if (quantity > 0)
                {
                    // Create a temporary OrderItem for takeout
                    var orderItem = new OrderItem
                    {
                        Name = menuItemName,
                        Price = price,
                        Qty = quantity,
                        Table = "Takeout", // Use "Takeout" as table identifier
                        Subtotal = price * quantity
                    };

                    // Add to current order items
                    currentOrderItems.Add(orderItem);

                    // Add to DataGridView
                    AddOrderItemToGrid(orderItem);

                    // Update totals
                    UpdateTotals();
                }
            }
        }

        private void OnTakeoutMenuItemClicked(StaffDashboardMenuFormOrder.OrderItem item)
        {
            // Use the custom quantity input dialog
            int qty = ShowQuantityInputDialog(item.Name);

            if (qty <= 0)
            {
                // User cancelled or entered invalid quantity
                return;
            }

            // Update the item quantity
            item.Qty = qty;

            // Create a temporary OrderItem for takeout
            var orderItem = new OrderItem
            {
                MenuId = item.MenuId,
                Name = item.Name,
                Price = item.Price,
                Qty = item.Qty,
                Table = "Takeout", // Use "Takeout" as table identifier
                Subtotal = item.Subtotal
            };

            // Add to current order items
            currentOrderItems.Add(orderItem);

            // Add to DataGridView
            AddOrderItemToGrid(orderItem);

            // Update totals
            UpdateTotals();
        }

        private int ShowQuantityInputDialog(string menuItemName)
        {
            // Create a custom form
            Form quantityForm = new Form()
            {
                Text = "",
                Size = new Size(400, 220),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.None,
                BackColor = Color.FromArgb(248, 249, 250),
                TopMost = true
            };

            // Header panel
            Panel headerPanel = new Panel()
            {
                BackColor = Color.FromArgb(0, 120, 215),
                Dock = DockStyle.Top,
                Height = 60
            };

            Label headerLabel = new Label()
            {
                Text = $"Select quantity for {menuItemName}",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 15),
                AutoSize = true
            };
            headerPanel.Controls.Add(headerLabel);

            // Numeric input
            NumericUpDown quantityInput = new NumericUpDown()
            {
                Minimum = 1,
                Maximum = 100,
                Value = 1,
                Font = new Font("Segoe UI", 12F),
                Location = new Point(30, 80),
                Size = new Size(100, 30),
                TextAlign = HorizontalAlignment.Center
            };

            // Buttons panel
            Panel buttonPanel = new Panel()
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.Transparent
            };

            Button okButton = new Button()
            {
                Text = "Add to Order",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(120, 35),
                DialogResult = DialogResult.OK,
                Cursor = Cursors.Hand
            };
            okButton.FlatAppearance.BorderSize = 0;
            okButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 100, 180);
            okButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 80, 160);

            Button cancelButton = new Button()
            {
                Text = "Cancel",
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                BackColor = Color.FromArgb(200, 200, 200),
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 35),
                DialogResult = DialogResult.Cancel,
                Cursor = Cursors.Hand
            };
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(180, 180, 180);
            cancelButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(160, 160, 160);

            okButton.Location = new Point(200, 12);
            cancelButton.Location = new Point(310, 12);
            buttonPanel.Controls.Add(okButton);
            buttonPanel.Controls.Add(cancelButton);

            // Add controls to form
            quantityForm.Controls.Add(headerPanel);
            quantityForm.Controls.Add(quantityInput);
            quantityForm.Controls.Add(buttonPanel);

            // Optional: Add a subtle border
            quantityForm.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(200, 200, 200), 1),
                    0, 0, quantityForm.Width - 1, quantityForm.Height - 1);
            };

            return quantityForm.ShowDialog() == DialogResult.OK ? (int)quantityInput.Value : 0;
        }


        private void InitializeDataGridViewForTakeout()
        {
            // Clear existing columns and data
            orderDataGridView.Columns.Clear();
            orderDataGridView.Rows.Clear();

            // Add columns to match dine-in structure
            orderDataGridView.Columns.Add("TableName", "Table");
            orderDataGridView.Columns.Add("MenuId", "MenuId");
            orderDataGridView.Columns.Add("MenuName", "Name");
            orderDataGridView.Columns.Add("Qty", "Qty");
            orderDataGridView.Columns.Add("Price", "Price");
            orderDataGridView.Columns.Add("Subtotal", "Subtotal");

            // Hide MenuId column (for internal use only)
            orderDataGridView.Columns["MenuId"].Visible = false;

            // Set column widths to match dine-in
            orderDataGridView.Columns["TableName"].Width = 80;
            orderDataGridView.Columns["MenuName"].Width = 150;
            orderDataGridView.Columns["Qty"].Width = 50;
            orderDataGridView.Columns["Price"].Width = 80;
            orderDataGridView.Columns["Subtotal"].Width = 80;

            // Apply styling
            StyleUserGrid();
        }

        private void AddOrderItemToGrid(OrderItem item)
        {
            // Check if item already exists in the DataGridView
            foreach (DataGridViewRow row in orderDataGridView.Rows)
            {
                if (!row.IsNewRow && row.Cells["MenuName"]?.Value?.ToString() == item.Name)
                {
                    // Update existing item quantity and subtotal
                    int currentQty = Convert.ToInt32(row.Cells["Qty"]?.Value ?? 0);
                    row.Cells["Qty"].Value = currentQty + item.Qty;
                    row.Cells["Subtotal"].Value = Convert.ToDecimal(row.Cells["Qty"].Value) * item.Price;
                    return;
                }
            }

            // Add new row if item doesn't exist
            int rowIndex = orderDataGridView.Rows.Add();
            orderDataGridView.Rows[rowIndex].Cells["TableName"].Value = item.Table; // "Takeout"
            orderDataGridView.Rows[rowIndex].Cells["MenuId"].Value = item.MenuId;
            orderDataGridView.Rows[rowIndex].Cells["MenuName"].Value = item.Name;
            orderDataGridView.Rows[rowIndex].Cells["Price"].Value = item.Price;
            orderDataGridView.Rows[rowIndex].Cells["Qty"].Value = item.Qty;
            orderDataGridView.Rows[rowIndex].Cells["Subtotal"].Value = item.Subtotal;
        }

        private void applydiscountbtn_Click(object sender, EventArgs e)
        {
            StaffDashboardDiscountForm staffDashboardDiscountForm = new StaffDashboardDiscountForm();
            staffDashboardDiscountForm.Show();

        }


        private void printbillbtn_Click(object sender, EventArgs e)
        {
            // Show options for printing bill
            var result = MessageBox.Show("Choose print option:\n\nYes - Print Recent Order\nNo - Enter Order ID\nCancel - Cancel",
                                      "Print Bill Options",
                                      MessageBoxButtons.YesNoCancel,
                                      MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Print recent order
                PrintRecentOrder();
            }
            else if (result == DialogResult.No)
            {
                // Get order ID from user
                string orderIdInput = Microsoft.VisualBasic.Interaction.InputBox("Enter Order ID:", "Print Bill", "");
                if (int.TryParse(orderIdInput, out int orderId))
                {
                    PrintOrderById(orderId);
                }
                else
                {
                    MessageBox.Show("Invalid Order ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        // Calculate subtotal, discount, total
        private void UpdateTotals()
        {
            int totalQty = 0;
            decimal subtotal = 0m;

            foreach (DataGridViewRow row in orderDataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    totalQty += Convert.ToInt32(row.Cells["Qty"].Value);
                    subtotal += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                }
            }

            decimal tax = subtotal * 0.12m;
            decimal netAmount = subtotal + tax;

            decimal discount = 0;
            decimal.TryParse(discounttxt.Text, out discount);

            decimal fixedAmount = netAmount - discount;

            qtytxt.Text = totalQty.ToString();
            totaltxt.Text = subtotal.ToString("0.00");
            taxtxt.Text = tax.ToString("12%");
            netamounttxt.Text = netAmount.ToString("0.00");
            fixedamounttxt.Text = fixedAmount.ToString("0.00");

        }

        // When discount changes
        private void discounttxt_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;

            // REMOVE NON-NUMERIC
            string clean = new string(tb.Text.Where(c => char.IsDigit(c) || c == '.').ToArray());

            if (tb.Text != clean)
            {
                int selStart = tb.SelectionStart - (tb.Text.Length - clean.Length);
                tb.Text = clean;
                tb.SelectionStart = Math.Max(0, selStart);
            }

            UpdateTotals();
        }
        private void discounttxt_Clicked(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void okbtn_Click(object sender, EventArgs e)
        {
            // Check if payment method is selected
            if (string.IsNullOrEmpty(selectedPaymentMethod))
            {
                ShowCustomMessageBox("Please select a payment method (Cash, GCash, or Card) before proceeding.", "Payment Method Required");
                return;
            }

            decimal total = 0;
            decimal billing = 0;

            decimal.TryParse(fixedamounttxt.Text.Replace("₱", "").Trim(), out total);
            decimal.TryParse(biilingamounttxt.Text.Replace("₱", "").Trim(), out billing);

            decimal change = billing - total;

            if (change < 0)
                changetxt.Text = "₱0.00";
            else
                changetxt.Text = "₱" + change.ToString("0.00");

            // Save payment data to Payments table
            SavePaymentToDatabase(total, billing, change);

            // Show confirmation message with payment method
            ShowCustomMessageBox($"Transaction Details\nPayment Method: {selectedPaymentMethod}\nTotal: ₱{total:0.00}\nAmount Received: ₱{billing:0.00}\nChange: {changetxt.Text}",
                          "Transaction Info");
        }

        private void cashbtn_Click(object sender, EventArgs e)
        {
            selectedPaymentMethod = "Cash";
            ResetPaymentButtonStyles();
            cashbtn.BackColor = Color.DarkGreen;
            cashbtn.FlatAppearance.MouseOverBackColor = Color.DarkGreen;
        }

        private void orderDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTotals();
        }
        private void AddItemToOrderGrid(StaffDashboardMenuFormOrder.OrderItem item)
        {
            // Check if item already exists
            foreach (DataGridViewRow row in orderDataGridView.Rows)
            {
                if ((int)row.Cells["MenuId"].Value == item.MenuId)
                {
                    row.Cells["Qty"].Value = (int)row.Cells["Qty"].Value + item.Qty;
                    row.Cells["Subtotal"].Value = Convert.ToDecimal(row.Cells["Qty"].Value) * item.Price;
                    return;
                }
            }

            // Add new row
            orderDataGridView.Rows.Add(item.MenuId, item.Name, item.Qty, item.Price, item.Subtotal);
        }
        private void OpenMenuForm(string tableName, int orderId)
        {
            var menuForm = new StaffDashboardMenuFormOrder(tableName);

            // Subscribe to menu item clicks
            menuForm.MenuItemClicked += (item) =>
            {
                // 1. Call PlaceOrder to insert into database and deduct inventory
                PlaceOrder(orderId, item.MenuId, item.Qty);

                // 2. Refresh the DataGridView showing the current order summary
                RefreshOrderSummary(orderId);

            };

            menuForm.ShowDialog();
        }
        private void InsertOrderItem(SqlConnection con, int orderId, int menuId, int qty)
        {
            string insertQuery = @"INSERT INTO OrderItems 
                   (OrderID, MenuID, Qty, Price)
                   VALUES
                   (@OrderID, @MenuID, @Qty,
                    (SELECT Price FROM Menu WHERE MenuID = @MenuID))";
            using (SqlCommand cmd = new SqlCommand(insertQuery, con))
            {
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                cmd.Parameters.AddWithValue("@MenuID", menuId);
                cmd.Parameters.AddWithValue("@Qty", qty);
                cmd.ExecuteNonQuery();
            }
        }
        private void DeductInventory(SqlConnection con, int inventoryId, int qtyToDeduct, int? relatedOrderId = null)
        {
            // 1️⃣ Deduct quantity from Inventory
            string updateQuery = @"
        UPDATE Inventory
        SET Quantity = Quantity - @QtyToDeduct
        WHERE InventoryID = @InventoryID";

            using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
            {
                updateCmd.Parameters.AddWithValue("@QtyToDeduct", qtyToDeduct);
                updateCmd.Parameters.AddWithValue("@InventoryID", inventoryId);
                updateCmd.ExecuteNonQuery();
            }

            // 2️⃣ Insert record into InventoryUsage for tracking
            string insertUsageQuery = @"
        INSERT INTO InventoryUsage (InventoryID, QtyUsed, Date, RelatedOrderID)
        VALUES (@InventoryID, @QtyUsed, @Date, @RelatedOrderID)";

            using (SqlCommand insertCmd = new SqlCommand(insertUsageQuery, con))
            {
                insertCmd.Parameters.AddWithValue("@InventoryID", inventoryId);
                insertCmd.Parameters.AddWithValue("@QtyUsed", qtyToDeduct);
                insertCmd.Parameters.AddWithValue("@Date", DateTime.Now);

                // Allow NULL for RelatedOrderID if no order is linked
                if (relatedOrderId.HasValue)
                    insertCmd.Parameters.AddWithValue("@RelatedOrderID", relatedOrderId.Value);
                else
                    insertCmd.Parameters.AddWithValue("@RelatedOrderID", DBNull.Value);

                insertCmd.ExecuteNonQuery();
            }
        }


        private void PlaceOrder(int orderId, int menuId, int qty)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Insert the menu item into OrderItems
                InsertOrderItem(con, orderId, menuId, qty);

                // Gather inventory deduction data first
                string inventoryQuery = @"SELECT InventoryID, QuantityUsed
                                  FROM MenuInventory
                                  WHERE MenuID = @MenuID";

                var inventoryItems = new List<(int inventoryId, decimal quantityNeeded)>();

                using (SqlCommand cmd = new SqlCommand(inventoryQuery, con))
                {
                    cmd.Parameters.AddWithValue("@MenuID", menuId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int inventoryId = reader.GetInt32(0);
                            decimal quantityNeeded = reader.GetDecimal(1);
                            inventoryItems.Add((inventoryId, quantityNeeded));
                        }
                    }
                }

                // Now the reader is closed, safe to execute other commands
                foreach (var item in inventoryItems)
                {
                    int totalDeduct = (int)(item.quantityNeeded * qty);
                    DeductInventory(con, item.inventoryId, totalDeduct);
                }
            }
        }
        private void RefreshOrderSummary(int orderId)
        {
            StyleUserGrid();
            string query = @"
        SELECT o.TableID AS TableName, oi.OrderItemID, oi.MenuID, m.Name AS MenuName, oi.Qty, oi.Price, oi.Subtotal
        FROM OrderItems oi
        INNER JOIN Menu m ON oi.MenuID = m.MenuID
        INNER JOIN Orders o ON oi.OrderID = o.OrderID
        WHERE oi.OrderID = @OrderID";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                DataTable dt = new DataTable();


                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    orderDataGridView.DataSource = dt;
                    orderDataGridView.Columns["MenuID"].Visible = false;

                    orderDataGridView.Columns["TableName"].HeaderText = "Table";
                    orderDataGridView.Columns["OrderItemID"].HeaderText = "OrderItem ID";
                    orderDataGridView.Columns["MenuName"].HeaderText = "Menu Item";
                    orderDataGridView.Columns["Qty"].HeaderText = "Quantity";
                    orderDataGridView.Columns["Price"].HeaderText = "Price";
                    orderDataGridView.Columns["Subtotal"].HeaderText = "Subtotal";

                    UpdateTotals();
                }
            }
        }

        private void OnTableSelected(string tableIdStr)
        {
            // Clear any existing data first
            ClearOrder();

            // Extract number from "Table 1", "Table 2", etc.
            var match = System.Text.RegularExpressions.Regex.Match(tableIdStr, @"\d+");
            if (!match.Success || !int.TryParse(match.Value, out int tableId))
            {
                MessageBox.Show("Invalid table ID.");
                return;
            }

            // Clear any existing unsaved orders for this table
            ClearUnsavedOrdersForTable(tableId);

            var menuForm = new StaffDashboardMenuFormOrder(tableIdStr);
            menuForm.MenuItemClicked += (item) =>
            {
                // Replace the InputBox with your custom dialog
                int qty = ShowQuantityInputDialog(item.Name);
                if (qty > 0)
                {
                    item.Qty = qty;

                    // Only add to DataGridView, don't save to database yet
                    AddItemToOrderSummary(new OrderItem
                    {
                        Table = tableIdStr,
                        MenuId = item.MenuId,
                        Name = item.Name,
                        Qty = item.Qty,
                        Price = item.Price,
                        Subtotal = item.Qty * item.Price
                    });
                }
                else
                {
                    MessageBox.Show("Invalid quantity.");
                }
            };

            LoadContent(menuForm);
        }
        private int GetOrCreateOrderIdForTable(int tableId) 
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                // Try to get existing order for the table that is not completed
                string selectQuery = @"SELECT TOP 1 OrderID FROM Orders WHERE TableID = @TableID AND Status = 'Available'";
                using (SqlCommand cmd = new SqlCommand(selectQuery, con))
                {
                    cmd.Parameters.AddWithValue("@TableID", tableId);
                    object result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int existingOrderId))
                    {
                        return existingOrderId;
                    }
                }

                // If not found, create a new order (add StaffID)
                string insertQuery = @"INSERT INTO Orders (TableID, Status, StaffID) OUTPUT INSERTED.OrderID VALUES (@TableID, 'Available', @StaffID)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@TableID", tableId);
                    cmd.Parameters.AddWithValue("@StaffID", currentStaffId); // Make sure this is set
                    int newOrderId = (int)cmd.ExecuteScalar();
                    return newOrderId;
                }
            }
        }

        // When adding an item (after quantity input)
        private void AddItemToOrderSummary(OrderItem item)
        {
            // Check if item already exists
            var existing = currentOrderItems.FirstOrDefault(x => x.MenuId == item.MenuId && x.Table == item.Table);
            if (existing != null)
            {
                existing.Qty += item.Qty;
                existing.Subtotal = existing.Qty * existing.Price;
            }
            else
            {
                item.Subtotal = item.Qty * item.Price;
                currentOrderItems.Add(item);
            }

            orderDataGridView.DataSource = null;
            orderDataGridView.DataSource = currentOrderItems;
            UpdateTotals();
        }


        private void biilingamounttxt_TextChanged(object sender, EventArgs e)
        {
            // TEMP UNSCRUBSCRIBE
            biilingamounttxt.TextChanged -= biilingamounttxt_TextChanged;

            string raw = biilingamounttxt.Text.Replace("₱", "").Trim();

            if (decimal.TryParse(raw, out decimal billing))
            {
                // UPDATE CHANGE
                if (decimal.TryParse(fixedamounttxt.Text.Replace("₱", "").Trim(), out decimal fixedAmount))
                {
                    changetxt.Text = "₱" + (billing - fixedAmount).ToString("0.00");
                }

                // PESO
                biilingamounttxt.Text = "₱" + raw;
                biilingamounttxt.SelectionStart = biilingamounttxt.Text.Length;
            }
            else
            {
                // PESO
                biilingamounttxt.Text = "₱";
                biilingamounttxt.SelectionStart = biilingamounttxt.Text.Length;
                changetxt.Text = "₱0.00";
            }

            // RESUBSCRIBE
            biilingamounttxt.TextChanged += biilingamounttxt_TextChanged;
        }

        private void biilingamounttxt_Leave(object sender, EventArgs e)
        {
            string raw = biilingamounttxt.Text.Replace("₱", "").Trim();
            if (decimal.TryParse(raw, out decimal value))
            {
                biilingamounttxt.Text = "₱" + value.ToString("0.00");
            }
            else
            {
                biilingamounttxt.Text = "₱0.00";
            }
        }
        private void qtytxt_Click(object sender, EventArgs e)
        {

        }

        private void totaltxt_Click(object sender, EventArgs e)
        {

        }

        private void taxtxt_Click(object sender, EventArgs e)
        {

        }

        private void netamounttxt_Click(object sender, EventArgs e)
        {

        }
        private void orderDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTotals();
        }

        private void gcashbtn_Click(object sender, EventArgs e)
        {
            selectedPaymentMethod = "GCash";
            ResetPaymentButtonStyles();
            gcashbtn.BackColor = Color.DarkBlue;
            gcashbtn.FlatAppearance.MouseOverBackColor = Color.DarkBlue;
        }

        private void cardbtn_Click(object sender, EventArgs e)
        {
            selectedPaymentMethod = "Card";
            ResetPaymentButtonStyles();
            cardbtn.BackColor = Color.DarkOrange;
            cardbtn.FlatAppearance.MouseOverBackColor = Color.DarkOrange;
        }

        private void changetxt_TextChanged(object sender, EventArgs e)
        {
        }

        private void ResetPaymentButtonStyles()
        {
            cashbtn.BackColor = Color.Green;
            gcashbtn.BackColor = Color.Blue;
            cardbtn.BackColor = Color.Coral;
        }

        private void voidbtn_Click(object sender, EventArgs e)
        {
            // Use the same clearing mechanism as ClearOrder
            ClearOrder();
        }

        private void fixedamounttxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveorderbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if there are items in the order
                if (orderDataGridView.Rows.Count == 0 || (orderDataGridView.Rows.Count == 1 && orderDataGridView.Rows[0].IsNewRow))
                {
                    ShowCustomMessageBox("Please add items to the order before saving.", "No Items");
                    return;
                }

                // Check if payment method is selected
                if (string.IsNullOrEmpty(selectedPaymentMethod))
                {
                    ShowCustomMessageBox("Please select a payment method (Cash, GCash, or Card) before saving the order.", "Payment Method Required");
                    return;
                }

                if (string.IsNullOrEmpty(selectedOrderType))
                {
                    ShowCustomMessageBox("Please select an order type (Dine In or Takeout) before saving the order.", "Order Type Required");
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"About to save order. Current selectedOrderType: {selectedOrderType}");

                decimal totalAmount = 0;
                if (decimal.TryParse(fixedamounttxt.Text.Replace("₱", "").Trim(), out totalAmount))
                {
                    decimal billingAmount = 0;
                    decimal.TryParse(biilingamounttxt.Text.Replace("₱", "").Trim(), out billingAmount);

                    decimal changeAmount = billingAmount - totalAmount;
                    if (changeAmount < 0) changeAmount = 0;

                    int orderId = SaveOrderToDatabase(totalAmount, selectedPaymentMethod);

                    SavePaymentToDatabase(totalAmount, billingAmount, changeAmount);

                    ShowOrderAndTransactionSummary(orderId, totalAmount, billingAmount, changeAmount);

                    ClearOrder();

                    RefreshDataGridView();
                }
                else
                {
                    ShowCustomMessageBox("Invalid total amount. Please check the order totals.", "Invalid Amount");
                }
            }
            catch (Exception ex)
            {
                ShowCustomMessageBox($"Error saving order: {ex.Message}", "Error");
            }
        }

        private void SavePaymentToDatabase(decimal totalAmount, decimal amountPaid, decimal changeAmount)
        {
            try
            {
                // Get the most recent order ID for this session
                int orderId = GetMostRecentOrderId();

                if (orderId > 0)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        string paymentQuery = @"
                            INSERT INTO Payments (OrderID, AmountPaid, ChangeAmount, PaymentDate, PaymentMethod)
                            VALUES (@OrderID, @AmountPaid, @ChangeAmount, @PaymentDate, @PaymentMethod)";

                        using (SqlCommand cmd = new SqlCommand(paymentQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@OrderID", orderId);
                            cmd.Parameters.AddWithValue("@AmountPaid", amountPaid);
                            cmd.Parameters.AddWithValue("@ChangeAmount", changeAmount);
                            cmd.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@PaymentMethod", selectedPaymentMethod);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving payment: {ex.Message}", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetMostRecentOrderId()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT TOP 1 OrderID FROM Orders WHERE StaffID = @StaffID ORDER BY Date DESC";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@StaffID", currentStaffId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        return Convert.ToInt32(result);
                }
            }
            return 0;
        }

        private int SaveOrderToDatabase(decimal totalAmount, string paymentMethod)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // Get the current table ID from the order items or use a default
                        int tableId = GetCurrentTableId();

                        // Get discount amount from discounttxt
                        decimal discountAmount = 0;
                        if (!string.IsNullOrEmpty(discounttxt.Text))
                        {
                            decimal.TryParse(discounttxt.Text, out discountAmount);
                        }

                        // Validate and set order type
                        string orderType = selectedOrderType ?? "Dine In";

                        // Debug: Show what order type is being saved
                        System.Diagnostics.Debug.WriteLine($"Saving order with OrderType: {orderType}");
                        System.Diagnostics.Debug.WriteLine($"selectedOrderType value: {selectedOrderType}");

                        // Create the main order record
                        string orderQuery = @"
                            INSERT INTO Orders (TableID, Status, StaffID, TotalAmount, PaymentMethod, Date, OrderType, DiscountAmount, PaymentStatus)
                            VALUES (@TableID, 'Completed', @StaffID, @TotalAmount, @PaymentMethod, @Date, @OrderType, @DiscountAmount, 'Paid')
                            SELECT SCOPE_IDENTITY()";

                        int orderId;
                        using (SqlCommand cmd = new SqlCommand(orderQuery, con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@TableID", tableId);
                            cmd.Parameters.AddWithValue("@StaffID", currentStaffId);
                            cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                            cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                            cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@OrderType", orderType);
                            cmd.Parameters.AddWithValue("@DiscountAmount", discountAmount);

                            orderId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Insert order items with safety checks
                        if (orderDataGridView.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in orderDataGridView.Rows)
                            {
                                if (row != null && !row.IsNewRow)
                                {
                                    try
                                    {
                                        // Get values from the row, handling different column name scenarios
                                        int menuId = GetMenuIdFromRow(row);
                                        int qty = Convert.ToInt32(GetCellValue(row, "Qty"));
                                        decimal price = Convert.ToDecimal(GetCellValue(row, "Price"));

                                        // Only insert if we have valid data
                                        if (menuId > 0 && qty > 0 && price > 0)
                                        {
                                            string itemQuery = @"
                                                INSERT INTO OrderItems (OrderID, MenuID, Qty, Price)
                                                VALUES (@OrderID, @MenuID, @Qty, @Price)";

                                            using (SqlCommand cmd = new SqlCommand(itemQuery, con, transaction))
                                            {
                                                cmd.Parameters.AddWithValue("@OrderID", orderId);
                                                cmd.Parameters.AddWithValue("@MenuID", menuId);
                                                cmd.Parameters.AddWithValue("@Qty", qty);
                                                cmd.Parameters.AddWithValue("@Price", price);

                                                cmd.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Exception($"Error processing row: {ex.Message}", ex);
                                    }
                                }
                            }
                        }

                        transaction.Commit();

                        // Clear order items from the current table after successful save
                        ClearTableOrderItems(tableId);

                        return orderId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private int GetCurrentTableId()
        {
            // Check if this is a takeout order
            if (selectedOrderType == "Takeout")
            {
                return 1; // Use Table 1 for takeout orders (since TableID = 0 doesn't exist)
            }

            // Check if we have order items with table information
            if (currentOrderItems.Count > 0 && !string.IsNullOrEmpty(currentOrderItems[0].Table))
            {
                // Check if it's a takeout order
                if (currentOrderItems[0].Table == "Takeout")
                {
                    return 1; // Use Table 1 for takeout orders
                }

                // Extract table number from "Table 1", "Table 2", etc.
                var match = System.Text.RegularExpressions.Regex.Match(currentOrderItems[0].Table ?? "", @"\d+");
                if (match.Success && int.TryParse(match.Value, out int tableId))
                {
                    return tableId;
                }
            }

            // Check if DataGridView has table information
            if (orderDataGridView.Rows.Count > 0 && !orderDataGridView.Rows[0].IsNewRow)
            {
                if (orderDataGridView.Columns.Contains("TableName") && orderDataGridView.Rows[0].Cells["TableName"].Value != null)
                {
                    string? tableName = orderDataGridView.Rows[0].Cells["TableName"].Value?.ToString();
                    if (!string.IsNullOrEmpty(tableName))
                    {
                        // Check if it's a takeout order
                        if (tableName == "Takeout")
                        {
                            return 1; // Use Table 1 for takeout orders
                        }

                        var match = System.Text.RegularExpressions.Regex.Match(tableName, @"\d+");
                        if (match.Success && int.TryParse(match.Value, out int tableId))
                        {
                            return tableId;
                        }
                    }
                }
            }

            // Default to Table 1 if no specific table is found
            return 1;
        }

        private int GetMenuIdFromRow(DataGridViewRow row)
        {
            try
            {
                if (row == null || row.Cells == null)
                {
                    return 0;
                }

                // Debug: List available columns
                string availableColumns = "";
                if (row.DataGridView != null && row.DataGridView.Columns != null)
                {
                    availableColumns = string.Join(", ", row.DataGridView.Columns.Cast<DataGridViewColumn>().Select(c => c.Name));
                }

                // Try different possible column names for MenuID
                try
                {
                    if (row.Cells["MenuId"] != null && row.Cells["MenuId"].Value != null)
                    {
                        return Convert.ToInt32(row.Cells["MenuId"].Value ?? 0);
                    }
                }
                catch { }

                try
                {
                    if (row.Cells["MenuID"] != null && row.Cells["MenuID"].Value != null)
                    {
                        return Convert.ToInt32(row.Cells["MenuID"].Value);
                    }
                }
                catch { }

                try
                {
                    if (row.Cells["OrderItemID"] != null && row.Cells["OrderItemID"].Value != null)
                    {
                        return Convert.ToInt32(row.Cells["OrderItemID"].Value);
                    }
                }
                catch { }

                // If we can't find MenuID directly, we need to get it from the MenuName
                // This happens when the DataGridView is populated from RefreshOrderSummary
                string menuName = GetCellValue(row, "MenuName");
                if (!string.IsNullOrEmpty(menuName))
                {
                    return GetMenuIdByName(menuName);
                }

                Console.WriteLine($"Could not determine MenuID from the DataGridView row. Available columns: {availableColumns}");
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting MenuID from row: {ex.Message}");
                return 0;
            }
        }

        private string GetCellValue(DataGridViewRow row, string columnName)
        {
            try
            {
                if (row != null && row.Cells != null)
                {
                    var cell = row.Cells[columnName];
                    if (cell != null && cell.Value != null)
                        return cell.Value.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting cell value for column '{columnName}': {ex.Message}");
            }
            return "";
        }

        private int GetMenuIdByName(string menuName)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT MenuID FROM Menu WHERE Name = @MenuName";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@MenuName", menuName);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        return Convert.ToInt32(result);
                }
            }
            throw new InvalidOperationException($"Menu not found: {menuName}");
        }

        private void ClearUnsavedOrdersForTable(int tableId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            // First, get the OrderIDs that need to be deleted
                            List<int> orderIdsToDelete = new List<int>();
                            string getOrderIdsQuery = "SELECT OrderID FROM Orders WHERE TableID = @TableID AND Status = 'Available'";
                            using (SqlCommand cmd = new SqlCommand(getOrderIdsQuery, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@TableID", tableId);
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        orderIdsToDelete.Add(reader.GetInt32("OrderID"));
                                    }
                                }
                            }

                            // Delete in the correct order to respect foreign key constraints
                            foreach (int orderId in orderIdsToDelete)
                            {
                                // 1. Delete payments first (if any)
                                string deletePaymentsQuery = "DELETE FROM Payments WHERE OrderID = @OrderID";
                                using (SqlCommand cmd = new SqlCommand(deletePaymentsQuery, con, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                                    cmd.ExecuteNonQuery();
                                }

                                // 2. Delete order items
                                string deleteOrderItemsQuery = "DELETE FROM OrderItems WHERE OrderID = @OrderID";
                                using (SqlCommand cmd = new SqlCommand(deleteOrderItemsQuery, con, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                                    cmd.ExecuteNonQuery();
                                }

                                // 3. Delete the order itself
                                string deleteOrderQuery = "DELETE FROM Orders WHERE OrderID = @OrderID";
                                using (SqlCommand cmd = new SqlCommand(deleteOrderQuery, con, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error but don't crash the application
                Console.WriteLine($"Error clearing unsaved orders for table {tableId}: {ex.Message}");
            }
        }

        private void ClearTableOrderItems(int tableId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Update table status to Available
                string updateTableQuery = "UPDATE Tables SET Status = 'Available' WHERE TableID = @TableID";
                using (SqlCommand cmd = new SqlCommand(updateTableQuery, con))
                {
                    cmd.Parameters.AddWithValue("@TableID", tableId);
                    cmd.ExecuteNonQuery();
                }
            }

            // Also clear the DataGridView and refresh UI
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            // Force clear and refresh the DataGridView
            orderDataGridView.DataSource = null;
            orderDataGridView.Rows.Clear();
            orderDataGridView.Refresh();
        }

        private void PrintRecentOrder()
        {
            try
            {
                int orderId = GetMostRecentOrderId();
                if (orderId > 0)
                {
                    PrintOrderById(orderId);
                }
                else
                {
                    MessageBox.Show("No recent orders found.", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing recent order: {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintOrderById(int orderId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Get order details
                    string orderQuery = @"
                        SELECT o.OrderID, o.TableID, o.TotalAmount, o.PaymentMethod, o.Date, o.OrderType, o.DiscountAmount,
                               s.Name as StaffName
                        FROM Orders o
                        INNER JOIN Staff s ON o.StaffID = s.StaffID
                        WHERE o.OrderID = @OrderID";

                    using (SqlCommand cmd = new SqlCommand(orderQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Create a copy of the data for printing
                                var orderData = new
                                {
                                    OrderID = reader["OrderID"],
                                    TableID = reader["TableID"],
                                    TotalAmount = reader["TotalAmount"],
                                    PaymentMethod = reader["PaymentMethod"],
                                    Date = reader["Date"],
                                    OrderType = reader["OrderType"],
                                    DiscountAmount = reader["DiscountAmount"],
                                    StaffName = reader["StaffName"]
                                };

                                reader.Close();
                                PrintReceipt(orderId, orderData);
                            }
                            else
                            {
                                MessageBox.Show("Order not found.", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing order: {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintReceipt(int orderId, dynamic orderData)
        {
            try
            {
                // Create receipt content
                string receipt = GenerateReceiptContent(orderId, orderData);

                // Print the receipt
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += (sender, e) =>
                {
                    Font font = new Font("Arial", 10);
                    e.Graphics.DrawString(receipt, font, Brushes.Black, 10, 10);
                };

                printDoc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing receipt: {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateReceiptContent(int orderId, dynamic orderData)
        {
            StringBuilder receipt = new StringBuilder();

            receipt.AppendLine("==========================================");
            receipt.AppendLine("           FLAVOR FLOW RESTAURANT");
            receipt.AppendLine("==========================================");
            receipt.AppendLine($"Order ID: {orderId}");
            receipt.AppendLine($"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            receipt.AppendLine($"Staff: {orderData.StaffName}");
            receipt.AppendLine($"Order Type: {orderData.OrderType}");
            receipt.AppendLine($"Table: {orderData.TableID}");
            receipt.AppendLine("------------------------------------------");

            // Get order items
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string itemsQuery = @"
                    SELECT m.Name, oi.Qty, oi.Price, oi.Subtotal
                    FROM OrderItems oi
                    INNER JOIN Menu m ON oi.MenuID = m.MenuID
                    WHERE oi.OrderID = @OrderID";

                using (SqlCommand cmd = new SqlCommand(itemsQuery, con))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            receipt.AppendLine($"{reader["Name"]} x{reader["Qty"]} @ ₱{reader["Price"]:0.00} = ₱{reader["Subtotal"]:0.00}");
                        }
                    }
                }
            }

            receipt.AppendLine("------------------------------------------");
            receipt.AppendLine($"Subtotal: ₱{orderData.TotalAmount:0.00}");
            receipt.AppendLine($"Discount: ₱{orderData.DiscountAmount:0.00}");

            // Calculate tax if needed (you can modify this based on your tax calculation logic)
            decimal taxAmount = 0;
            if (orderData.TotalAmount > 0)
            {
                taxAmount = orderData.TotalAmount * 0.12m; // Assuming 12% tax rate
            }
            receipt.AppendLine($"Tax: ₱{taxAmount:0.00}");

            receipt.AppendLine($"Payment Method: {orderData.PaymentMethod}");
            receipt.AppendLine("==========================================");
            receipt.AppendLine("           THANK YOU FOR YOUR ORDER!");
            receipt.AppendLine("==========================================");

            return receipt.ToString();
        }

        private void ShowOrderAndTransactionSummary(int orderId, decimal totalAmount, decimal billingAmount, decimal changeAmount)
        {
            // Create a detailed summary form
            Form summaryForm = new Form()
            {
                Text = "Order & Transaction Summary",
                Size = new Size(500, 400),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowInTaskbar = false,
                BackColor = Color.White
            };

            // Title label
            Label titleLabel = new Label()
            {
                Text = "Order & Transaction Summary",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(45, 45, 45),
                Location = new Point(20, 20),
                Size = new Size(450, 35),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Order details section
            Label orderSectionLabel = new Label()
            {
                Text = "ORDER DETAILS",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 120, 215),
                Location = new Point(20, 70),
                Size = new Size(450, 25),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Order information - safely calculate items count
            int itemsCount = 0;
            if (orderDataGridView.Rows.Count > 0)
            {
                itemsCount = orderDataGridView.Rows.Count;
                // Subtract 1 if the last row is a new row
                if (orderDataGridView.Rows.Count > 0 && orderDataGridView.Rows[orderDataGridView.Rows.Count - 1].IsNewRow)
                {
                    itemsCount--;
                }
            }

            string orderInfo = $"Order ID: {orderId}\n" +
                               $"Order Type: {selectedOrderType ?? "Dine In"}\n" +
                               $"Table: {GetCurrentTableId()}\n" +
                               $"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n" +
                              $"Items Count: {itemsCount}";

            Label orderInfoLabel = new Label()
            {
                Text = orderInfo,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(20, 100),
                Size = new Size(450, 80),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Transaction details section
            Label transactionSectionLabel = new Label()
            {
                Text = "TRANSACTION DETAILS",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 120, 215),
                Location = new Point(20, 190),
                Size = new Size(450, 25),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Transaction information
            string transactionInfo = $"Payment Method: {selectedPaymentMethod}\n" +
                                   $"Total Amount: ₱{totalAmount:0.00}\n" +
                                   $"Amount Paid: ₱{billingAmount:0.00}\n" +
                                   $"Change: ₱{changeAmount:0.00}\n" +
                                   $"Status: Completed";

            Label transactionInfoLabel = new Label()
            {
                Text = transactionInfo,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(20, 220),
                Size = new Size(450, 80),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // OK button
            Button okButton = new Button()
            {
                Text = "OK",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 40),
                Location = new Point(380, 320),
                DialogResult = DialogResult.OK
            };

            okButton.FlatAppearance.BorderSize = 0;
            okButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 100, 180);

            summaryForm.Controls.Add(titleLabel);
            summaryForm.Controls.Add(orderSectionLabel);
            summaryForm.Controls.Add(orderInfoLabel);
            summaryForm.Controls.Add(transactionSectionLabel);
            summaryForm.Controls.Add(transactionInfoLabel);
            summaryForm.Controls.Add(okButton);

            summaryForm.ShowDialog();
        }

        private void ShowCustomMessageBox(string message, string title, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            // Create a custom form for better message box design
            Form customMessageBox = new Form()
            {
                Text = "",
                Size = new Size(450, 250),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.None,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowInTaskbar = false,
                BackColor = Color.FromArgb(248, 249, 250),
                TopMost = true
            };

            // Add shadow effect
            customMessageBox.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(200, 200, 200), 1), 0, 0, customMessageBox.Width - 1, customMessageBox.Height - 1);
            };

            // Header panel with gradient effect
            Panel headerPanel = new Panel()
            {
                BackColor = Color.FromArgb(0, 120, 215),
                Location = new Point(0, 0),
                Size = new Size(450, 60),
                Dock = DockStyle.Top
            };

            // Icon based on message type
            Label iconLabel = new Label()
            {
                Text = GetIconText(icon),
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 15),
                Size = new Size(40, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Title label
            Label titleLabel = new Label()
            {
                Text = title,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(70, 20),
                Size = new Size(350, 30),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Message label with better formatting
            Label messageLabel = new Label()
            {
                Text = message,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(30, 80),
                Size = new Size(390, 100),
                TextAlign = ContentAlignment.TopLeft
            };

            // Button panel
            Panel buttonPanel = new Panel()
            {
                BackColor = Color.Transparent,
                Location = new Point(0, 200),
                Size = new Size(450, 50),
                Dock = DockStyle.Bottom
            };

            // OK button with modern design
            Button okButton = new Button()
            {
                Text = "OK",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 35),
                Location = new Point(325, 8),
                DialogResult = DialogResult.OK,
                Cursor = Cursors.Hand
            };

            okButton.FlatAppearance.BorderSize = 0;
            okButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 100, 180);
            okButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 80, 160);

            // Add controls
            headerPanel.Controls.Add(iconLabel);
            headerPanel.Controls.Add(titleLabel);
            customMessageBox.Controls.Add(headerPanel);
            customMessageBox.Controls.Add(messageLabel);
            buttonPanel.Controls.Add(okButton);
            customMessageBox.Controls.Add(buttonPanel);

            customMessageBox.ShowDialog();
        }

        private string GetIconText(MessageBoxIcon icon)
        {
            return icon switch
            {
                MessageBoxIcon.Information => "ℹ",
                MessageBoxIcon.Warning => "⚠",
                MessageBoxIcon.Error => "✕",
                MessageBoxIcon.Question => "?",
                _ => "ℹ"
            };
        }

        private void ClearOrder()
        {
            // Clear the data grid completely
            orderDataGridView.DataSource = null;
            orderDataGridView.Rows.Clear();
            orderDataGridView.Refresh();

            // Clear order items list
            currentOrderItems.Clear();

            // Reset payment method but preserve order type
            selectedPaymentMethod = null;
            // selectedOrderType = null; // Don't reset order type here
            ResetPaymentButtonStyles();

            // Clear all text fields
            fixedamounttxt.Text = "0.00";
            biilingamounttxt.Text = "₱0.00";
            discounttxt.Clear();
            qtytxt.Text = "0";
            totaltxt.Text = "0.00";
            taxtxt.Text = "0.00";
            netamounttxt.Text = "0.00";
            changetxt.Text = "₱0.00";

            UpdateTotals();
        }


    }
    public class OrderItem
    {
        public string? Table { get; set; }
        public int MenuId { get; set; }
        public string? Name { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Subtotal { get; set; }
    }
}
