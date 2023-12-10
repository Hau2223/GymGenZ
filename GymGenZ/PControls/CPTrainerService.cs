using GymGenZ.PModels;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymGenZ.PControls
{
    internal class CPTrainerService
    {
        private SQLiteConnection _conn;

        public CPTrainerService(string connectionString)
        {
            _conn = new SQLiteConnection(connectionString);
            _conn.Open();
        }

        public List<MPTrainerService> getAllPTrainerService()
        {
            List<MPTrainerService> s = new List<MPTrainerService>();

            using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM PTrainerService", _conn))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("id"));
                        string name = reader.GetString(reader.GetOrdinal("name"));
                        int time = reader.GetInt32(reader.GetOrdinal("time"));
                        int price = reader.GetInt32(reader.GetOrdinal("price"));
                        s.Add(new MPTrainerService(id, name, time, price));
                    }
                }
            }
            return s;
        }

        public Tuple<int, string, int, int> getServiceTrainer(string idService)
        {
            Tuple<int, string, int, int> serviceInfo = null;

            using (SQLiteConnection connection = new SQLiteConnection(_conn))
            {
                string query = $"SELECT * FROM PTrainerService WHERE id = {idService}";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            int time = reader.GetInt32(2);
                            int price = reader.GetInt32(3);

                            serviceInfo = Tuple.Create(id, name, time, price);
                        }
                        else
                        {
                            Console.WriteLine("Service not found.");
                        }
                    }
                }
            }
            return serviceInfo;
        }
    }
}
