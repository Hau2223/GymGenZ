using System;
using System.Data.SQLite;

namespace GymGenZ.PControls
{
    internal class CPayment
    {
        private string _connectionString;

        public CPayment(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool PaymentPackage(int idCustomer, string paymentDay, string paymentMethod, int packageID, int amount)
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(_connectionString))
                {
                    con.Open();

                    string insertQuery = "INSERT INTO Payment (customerID, paymentDate, paymentMethod, packageID, amount) " +
                                         "VALUES (@idCustomer, @paymentDay, @paymentMethod, @packageID, @amount)";

                    using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, con))
                    {
                        insertCmd.Parameters.AddWithValue("@idCustomer", idCustomer);
                        insertCmd.Parameters.AddWithValue("@paymentDay", paymentDay);
                        insertCmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                        insertCmd.Parameters.AddWithValue("@packageID", packageID);
                        insertCmd.Parameters.AddWithValue("@amount", amount);

                        int rowsAffected = insertCmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in PaymentPackage: {e.Message}");
                return false;
            }
        }
    }
}
