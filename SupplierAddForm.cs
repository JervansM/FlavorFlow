using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FlavorFlowIT13
{
    public partial class SupplierAddForm : Form
    {
        private int? supplierId;

        private readonly string cloudConnectionString =
           "Server=db28059.public.databaseasp.net; Database=db28059; User Id=db28059; Password=12345678; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        private readonly string localConnectionString =
            "Data Source=DESKTOP-45BU4B5;Initial Catalog=FlavorFlowDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        private string activeConnectionString;
        public SupplierAddForm()
        {
            InitializeComponent();
        }
        public SupplierAddForm(int supplierId) : this()
        {
            this.supplierId = supplierId;
        }

        private void SupplierAddForm_Load(object sender, EventArgs e)
        {

            activeConnectionString = GetAvailableConnection();

            if (supplierId.HasValue)
            {
                LoadSupplierData(supplierId.Value);
                this.Text = "Edit Supplier";
            }
            else
            {
                this.Text = "Add Supplier";
            }
        }
    
        private void LoadSupplierData(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(activeConnectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Supplier WHERE SupplierID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            supplliernametxt.Text = reader["Name"].ToString();
                            suppliercontacttxt.Text = reader["Contact"].ToString();
                            supplieraddresstxt.Text = reader["Address"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading supplier: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void suppliersavebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(supplliernametxt.Text))
            {
                MessageBox.Show("Supplier name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(activeConnectionString))
                {
                    conn.Open();

                    if (supplierId.HasValue)
                    {
                        // Update existing supplier
                        string updateQuery = @"UPDATE Supplier 
                                       SET Name=@name, Contact=@contact, Address=@address 
                                       WHERE SupplierID=@id";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", supplliernametxt.Text.Trim());
                            cmd.Parameters.AddWithValue("@contact", suppliercontacttxt.Text.Trim());
                            cmd.Parameters.AddWithValue("@address", supplieraddresstxt.Text.Trim());
                            cmd.Parameters.AddWithValue("@id", supplierId.Value);

                            cmd.ExecuteNonQuery();
                        }

                      
                    }
                    else
                    {
                        // Insert new supplier
                        string insertQuery = @"INSERT INTO Supplier (Name, Contact, Address, ItemsSupplied)
                                       OUTPUT INSERTED.SupplierID
                                       VALUES (@name, @contact, @address, '')";

                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", supplliernametxt.Text.Trim());
                            cmd.Parameters.AddWithValue("@contact", suppliercontacttxt.Text.Trim());
                            cmd.Parameters.AddWithValue("@address", supplieraddresstxt.Text.Trim());

                            int newId = (int)cmd.ExecuteScalar();
                            supplierId = newId; // store for later use

                        }
                    }
                }

                MessageBox.Show("Supplier saved successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK; // closes form and signals success
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving supplier: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
