using System;
using MySql.Data.MySqlClient;//MySQL kütüphanesi

namespace VerileriListeleme
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAllProducts();
        }
        //tüm ürün bilgilerini getiren metot.
        static void GetAllProducts()
        {
            using (var connection = GetMySqlConnection())
            {
                try
                {
                    //bağlantıyı açar.
                    connection.Open();

                    //Sql satırımızı taşıyan String
                    string sql = "SELECT * from products ";

                    //SQL sorgusuna göre gerekli verileri isteyen satır.
                    MySqlCommand command = new MySqlCommand(sql,connection);
                   
                    //Gelen verileri okuyan satır.
                    MySqlDataReader reader = command.ExecuteReader();

                    //Verileri yazdırdığımız while döngüsü
                    while(reader.Read())
                    {
                        Console.WriteLine($" Name : {reader[3]} Price : {reader[6]}");
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

        //MsSQL Server Connection
        // static void GetSqlConnection()
        // {
        //     string connectionString = @"Data Source=.\SQLEXPRESS01;
        //                                 Initial Catalog=Northwind;
        //                                 Integrated Security=SSPI;";
        //     //driver provider

        //     using (var connection = new SqlConnection(connectionString))
        //     {
        //         try
        //         {
        //             connection.Open();
        //             Console.WriteLine(" MSSQL Bağlantı sağlandı");
        //         }
        //         catch (Exception e)
        //         {
        //             Console.WriteLine("MSSQL Bağlantı başarısız, hata mesajı ;");
        //             Console.WriteLine(e.Message);
        //         }
        //         finally
        //         {
        //             connection.Close();
        //         }
        //     }

        // }
    }
}
