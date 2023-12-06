using GymGenZ.PModels;
using GymGenZ.PViews;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymGenZ.PControls
{
    internal class CProduct
    {
        private SQLiteConnection _conn;

        public CProduct(string connectionString)
        {
            _conn = new SQLiteConnection(connectionString);
            _conn.Open();
        }

        public bool addProduct(MProduct newProduct)
        {
            using (SQLiteConnection con = new SQLiteConnection(_conn))
            {
                string insertQuery = "INSERT INTO Product (nameProduct, count, price, idCateProduct, image) " +
                                     "VALUES (@nameProduct, @count, @price, @idCateProduct, @image)";
                using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, con))
                {
                    insertCmd.Parameters.AddWithValue("@nameProduct", newProduct.nameProduct);
                    insertCmd.Parameters.AddWithValue("@count", newProduct.count);
                    insertCmd.Parameters.AddWithValue("@price", newProduct.price);
                    insertCmd.Parameters.AddWithValue("@idCateProduct", newProduct.idCateProduct);
                    insertCmd.Parameters.AddWithValue("@image", newProduct.image);

                    //con.Open();
                    int rowsAffected = insertCmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }


        public List<MCateProduct> getAllCateProduct()
        {
            List<MCateProduct> cateProduct = new List<MCateProduct>();
            
            using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM CategoryProduct", _conn))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("id"));
                        string name = reader.GetString(reader.GetOrdinal("name"));
                        cateProduct.Add(new MCateProduct(id, name));
                    }
                }
            }
            return cateProduct;
        }


        public List<MProduct> getAllProduct(string searchText)
        {
            List<MProduct> productList = new List<MProduct>();
            string query = @"SELECT DISTINCT
                        p.id as IDProduct,
                        p.nameProduct as NameProduct,
                        p.count as Count,
                        p.price as Price,
                        ct.name as NameCateGory
                        FROM Product p
                        LEFT JOIN CategoryProduct ct ON p.idCateProduct = ct.id
                        WHERE p.nameProduct LIKE @searchText OR
                              ct.name LIKE @searchText";
            using (SQLiteCommand cmd = new SQLiteCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@searchText", $"%{searchText}%");

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MProduct product = new MProduct
                        {
                            id = int.Parse(reader["IDProduct"].ToString()),
                            nameProduct = reader["NameProduct"].ToString(),
                            count = int.Parse(reader["Count"].ToString()),
                            price = int.Parse(reader["Price"].ToString()),
                            nameCate = reader["NameCateGory"].ToString(),
                        };

                        productList.Add(product);
                    }
                }
            }

            return productList;
        }
    }
}
