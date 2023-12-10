using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymGenZ.PModels;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace GymGenZ.PControls
{
    internal class CStaff
    {
        private SQLiteConnection _conn;

        public CStaff(string connectionString)
        {
            _conn = new SQLiteConnection(connectionString);
        }

        public bool Login(string username, string password)
        {
            using (SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM Staff WHERE username = @username AND password = @password", _conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@username", username);
                da.SelectCommand.Parameters.AddWithValue("@password", password);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt.Rows.Count > 0;
            }
        }

        public List<MStaff> ShowAvailableStaff(string shiftCode, string date)
{
            List<MStaff> staffList = new List<MStaff>();

            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                con.Open();
                string query = "SELECT DISTINCT s.id AS ID, s.fullName AS FullName, s.numberPhone AS NumberPhone " +
                               "FROM Staff s " +
                               "WHERE NOT EXISTS (" +
                               "    SELECT 1 FROM TrainingSessions t " +
                               "    WHERE t.trainerID = s.id " +
                               $"      AND (t.ShiftCode = '{shiftCode}' AND t.Date = '{date}')" +
                               ")";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MStaff staff = new MStaff
                            {
                                staffID = reader["ID"].ToString(),
                                fullname = reader["FullName"].ToString(),
                                numberPhone = reader["NumberPhone"].ToString()
                            };

                            staffList.Add(staff);
                        }
                    }
                }
            }
            return staffList;
        }

        public bool CheckUSer(string username, string numberPhone)
        {
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                con.Open();
                string query = "SELECT * FROM Staff WHERE username = @username AND numberPhone = @numberPhone";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@numberPhone", numberPhone);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.Read();
                    }
                }
            }
        }

        public bool ChangePassword(string username, string newPassword)
        {
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                con.Open();
                string updateQuery = "UPDATE Staff SET password = @newPassword WHERE username = @username";
                using (SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, con))
                {
                    updateCmd.Parameters.AddWithValue("@newPassword", newPassword);
                    updateCmd.Parameters.AddWithValue("@username", username);
                    updateCmd.ExecuteNonQuery();
                    return true;
                }
            }
        }
        /*public List<MStaff> SearchStaff(string searchText)
        {
            List<MStaff> staffs = new List<MStaff>();

            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                con.Open();
                string query = "SELECT Staff.id AS StaffID, Staff.username AS UserName, " +
                               "Staff.roll AS Roll, Staff.fullName AS FullName, " +
                               "Staff.numberPhone AS NumberPhone, Staff.idCard AS IDCard, " +
                               "Staff.gender AS Gender, Staff.birth AS Birth, Staff.address AS Address " +
                               "FROM Staff " +
                               "WHERE Staff.username LIKE @searchText OR Staff.idCard LIKE @searchText OR " +
                               "Staff.fullName LIKE @searchText OR Staff.numberPhone LIKE @searchText";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@searchText", $"%{searchText}%");
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MStaff staff = new MStaff
                            {
                                staffID = reader["StaffID"].ToString(),
                                username = reader["UserName"].ToString(),
                                roll = reader["Roll"].ToString(),
                                fullname = reader["FullName"].ToString(),
                                numberPhone = reader["NumberPhone"].ToString(),
                                idCard = reader["IDCard"].ToString(),
                                gender = reader["Gender"].ToString(),
                                birth = reader["Birth"].ToString(),
                                address = reader["Address"].ToString()
                            };
                            staffs.Add(staff);
                        }
                    }
                }
            }
            return staffs;
        }*/

        public List<MStaff> LoadAllStaff()
        {
            List<MStaff> staffs = new List<MStaff>();

            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                con.Open();
                string query = "SELECT Staff.id AS StaffID, Staff.username AS UserName, " +
                               "Staff.roll AS Roll, Staff.fullName AS FullName, " +
                               "Staff.numberPhone AS NumberPhone, Staff.idCard AS IDCard, " +
                               "Staff.gender AS Gender, Staff.birth AS Birth, Staff.address AS Address " +
                               "FROM Staff";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MStaff staff = new MStaff
                            {
                                staffID = reader["StaffID"].ToString(),
                                username = reader["UserName"].ToString(),
                                roll = reader["Roll"].ToString(),
                                fullname = reader["FullName"].ToString(),
                                numberPhone = reader["NumberPhone"].ToString(),
                                idCard = reader["IDCard"].ToString(),
                                gender = reader["Gender"].ToString(),
                                birth = reader["Birth"].ToString(),
                                address = reader["Address"].ToString()
                            };
                            staffs.Add(staff);
                        }
                    }
                }
            }
            return staffs;
        }

        public List<MStaff> SearchStaff(string searchText)
        {
            List<MStaff> allStaff = LoadAllStaff();
            List<MStaff> filteredStaff = allStaff.Where(staff =>
                staff.username.Contains(searchText) ||
                staff.idCard.Contains(searchText) ||
                staff.fullname.Contains(searchText) ||
                staff.numberPhone.Contains(searchText)
            ).ToList();

            return filteredStaff;
        }


        public bool CheckPhoneNumber(string numberPhone)
        {
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM Staff WHERE numberPhone = @numberPhone";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@numberPhone", numberPhone);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        public bool CheckIDCard(string idCard){
            using (SQLiteConnection con = new SQLiteConnection(_conn)){
                con.Open();
                string query = "SELECT COUNT(*) FROM Staff WHERE idCard = @idCard";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idCard", idCard);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        public bool CheckUsername(string username){
            using (SQLiteConnection con = new SQLiteConnection(_conn)){
                con.Open();
                string query = "SELECT COUNT(*) FROM Staff WHERE username = @username";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con)){
                    cmd.Parameters.AddWithValue("@username", username);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        public bool AddStaff(MStaff newStaff)
        {
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                string insertQuery = "INSERT INTO Staff (username, password, roll, fullName, numberPhone, idCard, gender, birth, address) " +
                                     "VALUES (@username, @password, @roll, @fullName, @numberPhone, @idCard, @gender, @birth, @address)";
                using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, con)){
                    insertCmd.Parameters.AddWithValue("@username", newStaff.username);
                    insertCmd.Parameters.AddWithValue("@password", newStaff.password);
                    insertCmd.Parameters.AddWithValue("@roll", newStaff.roll);
                    insertCmd.Parameters.AddWithValue("@fullName", newStaff.fullname);
                    insertCmd.Parameters.AddWithValue("@numberPhone", newStaff.numberPhone);
                    insertCmd.Parameters.AddWithValue("@idCard", newStaff.idCard);
                    insertCmd.Parameters.AddWithValue("@gender", newStaff.gender);
                    insertCmd.Parameters.AddWithValue("@birth", newStaff.birth);
                    insertCmd.Parameters.AddWithValue("@address", newStaff.address);
                    con.Open();
                    int rowsAffected = insertCmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public bool UpdateStaff(MStaff updatedStaff)
        {
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                string updateQuery = "UPDATE Staff SET username = @username, " +
                                     "roll = @roll, fullName = @fullName, numberPhone = @numberPhone, " +
                                     "idCard = @idCard, gender = @gender, birth = @birth, address = @address WHERE ID = @staffID";
                using (SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, con))
                {
                    updateCmd.Parameters.AddWithValue("@username", updatedStaff.username);
                    updateCmd.Parameters.AddWithValue("@password", updatedStaff.password);
                    updateCmd.Parameters.AddWithValue("@roll", updatedStaff.roll);
                    updateCmd.Parameters.AddWithValue("@fullName", updatedStaff.fullname);
                    updateCmd.Parameters.AddWithValue("@numberPhone", updatedStaff.numberPhone);
                    updateCmd.Parameters.AddWithValue("@idCard", updatedStaff.idCard);
                    updateCmd.Parameters.AddWithValue("@staffID", updatedStaff.staffID);
                    updateCmd.Parameters.AddWithValue("@gender", updatedStaff.gender);
                    updateCmd.Parameters.AddWithValue("@birth", updatedStaff.birth);
                    updateCmd.Parameters.AddWithValue("@address", updatedStaff.address);
                    con.Open();
                    int rowsAffected = updateCmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public bool DeleteStaff(string staffID)
        {
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                string deleteQuery = "DELETE FROM Staff WHERE ID = @staffID";
                using (SQLiteCommand deleteCmd = new SQLiteCommand(deleteQuery, con))
                {
                    deleteCmd.Parameters.AddWithValue("@staffID", staffID);

                    con.Open();
                    int rowsAffected = deleteCmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }


    }
}
