using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace VerileriNesneListeleme
{
    class Program
    {
        static void Main(string[] args)
        {
            //burada verileri nesneden kullanıp foreach ile ekrana bastırıyoruz.
           var products =  GetAllProducts();

           foreach (var pr in products)
           {
               Console.WriteLine($"Name: {pr.Name} Price: {pr.Price}");
           }
        }
        static List<Product> GetAllProducts()
        {
            List<Product> products = null;
            using (var connection = GetMySqlConnection())
            {
                try
                {
                    //bağlantıyı açar.
                    connection.Open();

                    //Sql satırımızı taşıyan String
                    string sql = "SELECT * from products ";

                    //SQL sorgusuna göre gerekli verileri isteyen satır.
                    MySqlCommand command = new MySqlCommand(sql, connection);

                    //Gelen verileri okuyan satır.
                    MySqlDataReader reader = command.ExecuteReader();

                    products = new List<Product>();

                    //Verileri aktardığımız while döngüsü
                    while (reader.Read())
                    {
                        products.Add(
                            new Product
                            {
                                ProductId = int.Parse(reader["id"].ToString()),
                                Name = reader["product_name"].ToString(),
                                Price = double.Parse(reader["list_price"]?.ToString())
                            }
                        );
                    }

                    reader.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine("MySQL Bağlantı başarısız, hata mesajı ;");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return products;
        }
       
        //MySQL Server Connection
        static MySqlConnection GetMySqlConnection()
        {
            string connectionString = @"server=localhost;
                                       port=3306;
                                       database=northwind;
                                       user=root;
                                       password=Burak9595!;";

            return new MySqlConnection(connectionString);
        }
    }
}

