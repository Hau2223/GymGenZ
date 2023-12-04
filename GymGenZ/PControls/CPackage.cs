using GymGenZ.PModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymGenZ.PControls
{
    internal class CPackage
    {
        private SQLiteConnection _conn;

        public CPackage(string connectionString)
        {
            _conn = new SQLiteConnection(connectionString);
            _conn.Open();
        }

        public List<MPackage> getAllPakage()
        {
            List<MPackage> packages = new List<MPackage>();

            using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Package", _conn))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("id"));
                        string name = reader.GetString(reader.GetOrdinal("name"));
                        int time = reader.GetInt32(reader.GetOrdinal("time"));
                        packages.Add(new MPackage(id, name, time));
                    }
                }
            }
            return packages;
        }


    }
}
