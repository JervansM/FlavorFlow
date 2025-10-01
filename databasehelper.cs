using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FlavorFlowIT13
{
    public static class DatabaseHelper
    {

        public static void UpdateItemsSupplied(string connectionString, int supplierId, List<int> itemIds)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string deleteQuery = "DELETE FROM SupplierItems WHERE SupplierID = @sid";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@sid", supplierId);
                        deleteCmd.ExecuteNonQuery();
                    }

                    // 2. Insert new mappings
                    foreach (int itemId in itemIds)
                    {
                        string insertQuery = "INSERT INTO SupplierItems (SupplierID, ItemID) VALUES (@sid, @iid)";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@sid", supplierId);
                            insertCmd.Parameters.AddWithValue("@iid", itemId);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating SupplierItems: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        public static List<string> GetSupplierItems(string connectionString, int supplierId)
        {
            List<string> items = new List<string>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT i.ItemName
                        FROM SupplierItems si
                        INNER JOIN Inventory i ON si.ItemID = i.InventoryID
                        WHERE si.SupplierID = @sid";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@sid", supplierId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                items.Add(reader["ItemName"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching Supplier items: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return items;
        }
    }
}
