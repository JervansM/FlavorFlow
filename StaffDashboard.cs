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
    public partial class StaffDashboard : Form
    {
        public DataGridView OrderGrid => orderDataGridView;
        private string connectionString = "Data Source=DESKTOP-2SPCOE3;Initial Catalog=FlavorFlowDB;Integrated Security=True;Trust Server Certificate=True";
        private int currentStaffId;

        // Add this field to store the current order before saving
        private List<OrderItem> currentOrderItems = new List<OrderItem>();

        public StaffDashboard(int staffId)

        {
            InitializeComponent();
            currentStaffId = staffId;
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

            //8E9A57//

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
            orderDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            orderDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            orderDataGridView.DefaultCellStyle.BackColor = Color.White;
            orderDataGridView.DefaultCellStyle.ForeColor = Color.Black;
            orderDataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            orderDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            orderDataGridView.RowHeadersVisible = false;
            orderDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            orderDataGridView.MultiSelect = false;
            orderDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            orderDataGridView.BorderStyle = BorderStyle.FixedSingle;
            orderDataGridView.GridColor = Color.LightGray;
            orderDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            orderDataGridView.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            orderDataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
            orderDataGridView.BackgroundColor = Color.WhiteSmoke;

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
            var tableMapForm = new StaffTableMapOrder();
            tableMapForm.TableSelected += OnTableSelected;
            LoadContent(tableMapForm); // Shows table map in panelContent
        }

        private void takeoutbtn_Click(object sender, EventArgs e)
        {

        }

        private void applydiscountbtn_Click(object sender, EventArgs e)
        {
            StaffDashboardDiscountForm staffDashboardDiscountForm = new StaffDashboardDiscountForm();
            staffDashboardDiscountForm.Show();

        }


        private void printbillbtn_Click(object sender, EventArgs e)
        {

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
            decimal total = 0;
            decimal billing = 0;


            decimal.TryParse(fixedamounttxt.Text.Replace("₱", "").Trim(), out total);
            decimal.TryParse(biilingamounttxt.Text.Replace("₱", "").Trim(), out billing);

            decimal change = billing - total;


            if (change < 0)
                changetxt.Text = "₱0.00";
            else
                changetxt.Text = "₱" + change.ToString("0.00");
        }

        private void cashbtn_Click(object sender, EventArgs e)
        {

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
        private void DeductInventory(SqlConnection con, int inventoryId, int qtyToDeduct)
        {
            string updateQuery = @"UPDATE Inventory
                           SET Quantity = Quantity - @QtyToDeduct
                           WHERE InventoryID = @InventoryID";

            using (SqlCommand cmd = new SqlCommand(updateQuery, con))
            {
                cmd.Parameters.AddWithValue("@QtyToDeduct", qtyToDeduct);
                cmd.Parameters.AddWithValue("@InventoryID", inventoryId);
                cmd.ExecuteNonQuery();
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
        SELECT o.TableID AS TableName, oi.OrderItemID,  m.Name AS MenuName,  oi.Qty,   oi.Price,  oi.Subtotal
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
            // Extract number from "Table 1", "Table 2", etc.
            var match = System.Text.RegularExpressions.Regex.Match(tableIdStr, @"\d+");
            if (!match.Success || !int.TryParse(match.Value, out int tableId))
            {
                MessageBox.Show("Invalid table ID.");
                return;
            }

            int orderId = GetOrCreateOrderIdForTable(tableId);

            var menuForm = new StaffDashboardMenuFormOrder(tableIdStr);
            menuForm.MenuItemClicked += (item) =>
            {
                string qtyStr = Microsoft.VisualBasic.Interaction.InputBox($"Enter quantity for {item.Name}:", "Quantity", "1");
                if (int.TryParse(qtyStr, out int qty) && qty > 0)
                {
                    item.Qty = qty;

                    // 1️⃣ Place the order in DB
                    PlaceOrder(orderId, item.MenuId, item.Qty);

                    // 2️⃣ Add item to DataGridView including table name
                    AddItemToOrderSummary(new OrderItem
                    {
                        Table = tableIdStr,
                        MenuId = item.MenuId,
                        Name = item.Name,
                        Qty = item.Qty,
                        Price = item.Price,
                        Subtotal = item.Qty * item.Price
                    });

                    // 3️⃣ Refresh the summary from DB (optional)
                    RefreshOrderSummary(orderId);
                }
                else
                {
                    MessageBox.Show("Invalid quantity.");
                }
            };

            LoadContent(menuForm);
            RefreshOrderSummary(orderId); // ensure table name shows immediately
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

        }

        private void cardbtn_Click(object sender, EventArgs e)
        {

        }

        private void changetxt_TextChanged(object sender, EventArgs e)
        {
        }

        private void voidbtn_Click(object sender, EventArgs e)
        {
            if (orderDataGridView.DataSource is DataTable dt)
            {
                dt.Clear();
                orderDataGridView.DataSource = null; 
            }
            else
            {
                orderDataGridView.Rows.Clear();
            }

            currentOrderItems.Clear();

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

        private void fixedamounttxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class OrderItem
    {
        public string Table { get; set; }
        public int MenuId { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Subtotal { get; set; }
    }
}
