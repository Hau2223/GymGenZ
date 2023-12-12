using GymGenZ.PModels;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymGenZ.PControls
{
    internal class CDiscount
    {
        private SQLiteConnection _conn;

        public CDiscount(string connectionString)
        {
            _conn = new SQLiteConnection(connectionString);
        }


        public List<MDiscount> LoadAllDiscount()
        {
            List<MDiscount> discounts = new List<MDiscount>();

            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                con.Open();
                string query = "SELECT Discount.id AS ID, " +
                               "Discount.timeStart AS TimeStart, Discount.timeEnd AS TimeEnd, " +
                               "Discount.status AS Status " +
                               "FROM Discount";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MDiscount discount = new MDiscount
                            {
                                id = reader["ID"].ToString(),
                                timeStart = reader["TimeStart"].ToString(),
                                timeEnd = reader["TimeEnd"].ToString(),
                                status = reader["Status"].ToString(),
                            };
                            discounts.Add(discount);
                        }
                    }
                }
            }
            return discounts;
        }
        public List<MDiscount> SearchDiscount(string searchText)
        {
            List<MDiscount> allDiscount = LoadAllDiscount();
            List<MDiscount> filteredStaff = allDiscount.Where(discount =>
                discount.id.Contains(searchText)
            ).ToList();

            return filteredStaff;
        }

        /*public List<MDiscount> SearchDiscount(string searchText)
        {
            List<MDiscount> staffs = new List<MDiscount>();

            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                con.Open();
                string query = "SELECT Discount.id AS ID, " +
                               "Discount.timeStart AS TimeStart, Discount.timeEnd AS TimeEnd, " +
                               "Discount.status AS Status " +
                               "FROM Discount " +
                               "WHERE Discount.id LIKE @searchText OR Discount.timeStart LIKE @searchText OR " +
                               "Discount.timeENd LIKE @searchText";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@searchText", $"%{searchText}%");
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MDiscount discount = new MDiscount
                            {
                                id = reader["ID"].ToString(),
                                timeStart = reader["TimeStart"].ToString(),
                                timeEnd = reader["TimeEnd"].ToString(),
                                status = reader["Status"].ToString(),
                            };
                            staffs.Add(discount);
                        }
                    }
                }
            }
            return staffs;
        }*/
        public bool CheckIDDiscount(string id)
        {
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM Discount WHERE id = @id";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public bool AddDiscount(MDiscount newDiscount)
        {
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                string insertQuery = "INSERT INTO Discount (id, timeStart, timeEnd, status) " +
                                     "VALUES (@id, @timeStart, @timeEnd, @status)";
                using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, con))
                {
                    insertCmd.Parameters.AddWithValue("@id", newDiscount.id);
                    insertCmd.Parameters.AddWithValue("@timeStart", newDiscount.timeStart);
                    insertCmd.Parameters.AddWithValue("@timeEnd", newDiscount.timeEnd);
                    insertCmd.Parameters.AddWithValue("@status", newDiscount.status);
                    con.Open();
                    int rowsAffected = insertCmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public bool UpdateDiscount(MDiscount updatedDiscount)
        {
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                string updateQuery = "UPDATE Discount SET id = @id, " +
                                     "timeStart = @timeStart, timeEnd = @timeEnd, " +
                                     "status = @status WHERE id = @id";
                using (SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, con))
                {
                    updateCmd.Parameters.AddWithValue("@timeStart", updatedDiscount.timeStart);
                    updateCmd.Parameters.AddWithValue("@timeEnd", updatedDiscount.timeEnd);
                    updateCmd.Parameters.AddWithValue("@status", updatedDiscount.status);
                    updateCmd.Parameters.AddWithValue("@id", updatedDiscount.id);
                    con.Open();
                    int rowsAffected = updateCmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public bool DeleteDiscount(string discountID)
        {
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                string deleteQuery = "DELETE FROM Discount WHERE id = @id";
                using (SQLiteCommand deleteCmd = new SQLiteCommand(deleteQuery, con))
                {
                    deleteCmd.Parameters.AddWithValue("@id", discountID);

                    con.Open();
                    int rowsAffected = deleteCmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
