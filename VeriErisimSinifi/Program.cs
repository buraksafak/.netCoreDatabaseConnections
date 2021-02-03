using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace VeriErisimSinifi
{
    interface IProductDal
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void Create(Product p);
        void Update(Product p);
        void Delete(int ProductId);
    }
    public class MySQLProductDal : IProductDal
    {
        private MySqlConnection GetMySqlConnection()
        {
            string connectionString = @"server=localhost;
                                       port=3306;
                                       database=northwind;
                                       user=root;
                                       password=Burak9595!;";

            return new MySqlConnection(connectionString);
        }
        public void Create(Product p)
        {
            throw new NotImplementedException();
        }

        public void Delete(int ProductId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
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

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product p)
        {
            throw new NotImplementedException();
        }
    }
   
   public class MsSQLProductDal : IProductDal
    {
        private SqlConnection GetMsSqlConnection()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS01;
                                        Initial Catalog=Northwind;
                                        Integrated Security=SSPI;";

            return new SqlConnection(connectionString);
        }
        public void Create(Product p)
        {
            throw new NotImplementedException();
        }

        public void Delete(int ProductId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = null;
            using (var connection = GetMsSqlConnection())
            {
                try
                {
                    //bağlantıyı açar.
                    connection.Open();

                    //Sql satırımızı taşıyan String
                    string sql = "SELECT * from products ";

                    //SQL sorgusuna göre gerekli verileri isteyen satır.
                    SqlCommand command = new SqlCommand(sql, connection);

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
                    Console.WriteLine("MsSQL Bağlantı başarısız, hata mesajı ;");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return products;
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product p)
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var productDal = new MySQLProductDal();

            var products = productDal.GetAllProducts();

            foreach (var item in products)
            {
                Console.WriteLine($"{item.Name}");
            }
        }
    }
}
