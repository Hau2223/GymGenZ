using GymGenZ.PModels;
using GymGenZ.PViews;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GymGenZ.PControls
{
    internal class CCustomer
    {
        private string _connectionString;
        private SQLiteConnection _conn;

        public CCustomer(string connectionString)
        {
            _connectionString = connectionString;
            _conn = new SQLiteConnection(_connectionString);
        }

        public List<MCustomer> SearchCustomers(string searchText)
        {
            List<MCustomer> customers = new List<MCustomer>();

            using (SQLiteConnection con = new SQLiteConnection(_connectionString))
            {
                con.Open();

                string query = @"SELECT DISTINCT
                            c.id AS ID,
                            c.name AS CustomerName,
                            c.gender AS Gender,
                            c.cccd AS CCCD,
                            c.phone AS PhoneNumber,
                            c.start AS Start,
                            c.end AS End,
                            c.address AS Address,
                            p.name AS PackageName,
                            st.fullName AS TrainerName
                        FROM Customer c
                        LEFT JOIN Package p ON c.idPackage = p.id
                        LEFT JOIN TrainingSessions ts ON c.id = ts.customerID
                        LEFT JOIN Staff st ON ts.trainerID = st.id
                        WHERE c.name LIKE @searchText OR
                              c.phone LIKE @searchText OR
                              c.cccd LIKE @searchText";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@searchText", $"%{searchText}%");

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MCustomer customer = new MCustomer
                            {
                                customerID = reader["ID"].ToString(),
                                customerName = reader["CustomerName"].ToString(),
                                gender = reader["Gender"].ToString(),
                                CCCD = reader["CCCD"].ToString(),
                                phoneNumber = reader["PhoneNumber"].ToString(),
                                start = reader["Start"].ToString(),
                                end = reader["End"].ToString(),
                                address = reader["Address"].ToString(),
                                packageName = reader["PackageName"].ToString(),
                                trainerName = reader["TrainerName"].ToString(),
                            };

                            customers.Add(customer);
                        }
                    }
                }
            }

            return customers;
        }

        public Tuple<int, string, string, string, string, string> GetCustomerInfo(int customerId)
        {
            Tuple<int, string, string, string, string, string> customerInfo = null;

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                string query = $"SELECT * FROM Customer WHERE id = {customerId}";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customerId", customerId);

                    connection.Open();

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idCustomer = reader.GetInt32(0);
                            string nameCustomer = reader.GetString(1);
                            string packageName = reader.GetString(2);
                            string startDate = reader.IsDBNull(3) ? "N/A" : reader.GetString(3);
                            string endDate = reader.IsDBNull(4) ? "N/A" : reader.GetString(4);
                            string trainerName = reader.IsDBNull(5) ? "N/A" : reader.GetString(5);

                            customerInfo = Tuple.Create(idCustomer, nameCustomer, packageName, startDate, endDate, trainerName);
                        }
                        else
                        {
                            Console.WriteLine("Customer not found.");
                        }
                    }
                }
            }
            return customerInfo;
        }

        public int getIdMaxCustomer()
        {
            int id = 0;
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                string query = "SELECT max(id) FROM Customer";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idCustomer = reader.GetInt32(0);
                            id = idCustomer;
                        }
                        else
                        {
                            Console.WriteLine("Customer not found.");
                        }
                    }
                }
            }

            return id;
        }
        
        public bool SignPTrainer(string idCustomer, string idStaff, List<string> lstDate, string shiftCode, int idService, string dateStart,string dateEnd)
        {
            try
            {
                _conn.Open();
                try
                {
                    foreach (string date in lstDate)
                    {
                        string insertQuery = "INSERT INTO TrainingSessions (trainerID, customerID, date, shiftCode, idPTrainerService, dateStart, dateEnd) " +
                                             "VALUES (@TrainerID, @CustomerID, @Date, @ShiftCode, @idService, @dateStart, @dateEnd)";
                        using (SQLiteCommand insertPTrainer = new SQLiteCommand(insertQuery, _conn))
                        {
                            insertPTrainer.Parameters.AddWithValue("@TrainerID", idStaff);
                            insertPTrainer.Parameters.AddWithValue("@CustomerID", idCustomer);
                            insertPTrainer.Parameters.AddWithValue("@Date", date);
                            insertPTrainer.Parameters.AddWithValue("@ShiftCode", shiftCode);
                            insertPTrainer.Parameters.AddWithValue("@idService", idService);
                            insertPTrainer.Parameters.AddWithValue("@dateStart", dateStart);
                            insertPTrainer.Parameters.AddWithValue("@dateEnd", dateEnd);
                            insertPTrainer.ExecuteNonQuery();
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
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

        public bool PaymentTrainer(int idCustomer, int idTrainer, int idService, string paymentMethod)
        {
            DateTime currentDate = DateTime.Now;
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(_connectionString))
                {
                    con.Open();

                    string insertQuery = "INSERT INTO PaymentTrainer (idCustomer, idTrainer, idService, paymentMethod, paymentDay) " +
                                         "VALUES (@idCustomer, @idTrainer, @idService, @paymentMethod, @paymentDay)";

                    using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, con))
                    {
                        insertCmd.Parameters.AddWithValue("@idCustomer", idCustomer);
                        insertCmd.Parameters.AddWithValue("@idTrainer", idTrainer);
                        insertCmd.Parameters.AddWithValue("@idService", idService);
                        insertCmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                        insertCmd.Parameters.AddWithValue("@paymentDay", currentDate.ToString());
                        int rowsAffected = insertCmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in PaymentPackage: {e.Message}");
                return false;
            }
        }
        public bool CheckPhoneExist(string phone)
        {
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                con.Open();

                string query = "SELECT COUNT(*) FROM Customer WHERE phone = @phone";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@phone", phone);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count > 0;
                }
            }
        }

        public bool CheckCCCDExist(string cccd)
        {
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                con.Open();

                string query = "SELECT COUNT(*) FROM Customer WHERE cccd = @cccd";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@cccd", cccd);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count > 0;
                }
            }
        }





        public bool insertCustomer(string name, string phone, string cccd, string packageID, string address, string gender)
        {
            try
            {
                _conn.Open();
                string selectPackageQuery = "SELECT * FROM Package WHERE id = @packageID";
                using (SQLiteCommand selectPackageCmd = new SQLiteCommand(selectPackageQuery, _conn))
                {
                    selectPackageCmd.Parameters.AddWithValue("@packageID", packageID);

                    using (SQLiteDataReader packageReader = selectPackageCmd.ExecuteReader())
                    {
                        if (packageReader.Read())
                        {
                            int packageId = packageReader.GetInt32(packageReader.GetOrdinal("id"));
                            string packageName = packageReader.GetString(packageReader.GetOrdinal("name"));
                            int packageTime = packageReader.GetInt32(packageReader.GetOrdinal("time"));
                            DateTime currentDate = DateTime.Now;
                            DateTime expirationDate = currentDate.AddDays(packageTime);

                            string insertCustomerQuery = "INSERT INTO Customer(name, phone, cccd, idPackage, start, end, address, gender)"
                                                            + "VALUES(@Name, @Phone, @CCCD, @packageID, @registrationDate, @expirationDate, @address, @gender)";
                            using (SQLiteCommand insertCustomerCmd = new SQLiteCommand(insertCustomerQuery, _conn))
                            {
                                insertCustomerCmd.Parameters.AddWithValue("@Name", name);
                                insertCustomerCmd.Parameters.AddWithValue("@Phone", phone);
                                insertCustomerCmd.Parameters.AddWithValue("@CCCD", cccd);
                                insertCustomerCmd.Parameters.AddWithValue("@packageID", packageID);
                                insertCustomerCmd.Parameters.AddWithValue("@registrationDate", currentDate.ToString("yyyy-MM-dd"));
                                insertCustomerCmd.Parameters.AddWithValue("@expirationDate", expirationDate.ToString("yyyy-MM-dd"));
                                insertCustomerCmd.Parameters.AddWithValue("@address", address);
                                insertCustomerCmd.Parameters.AddWithValue("@gender", gender);
                                insertCustomerCmd.ExecuteNonQuery();

                                return true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin gói tập.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                return false;
            }
            finally
            {
                _conn.Close();
            }
        }

        public bool signCustomer(string name, string phone, string cccd, int packageID, string address, string gender, string paymentMethod ,int amount)
        {
            try
            {
                bool resultInsert = insertCustomer(name, phone, cccd, packageID.ToString(), address, gender);
                if (resultInsert)
                {
                    int idCustomer = getIdMaxCustomer();
                    DateTime currentDate = DateTime.Now;
                    bool resultPayment = PaymentPackage(idCustomer, currentDate.ToString(), paymentMethod, packageID, amount);
                    if (resultPayment)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
