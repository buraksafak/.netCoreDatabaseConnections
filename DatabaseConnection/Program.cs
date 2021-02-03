using System;
using System.Data.SqlClient; //MsSQL kütüphanesi
using MySql.Data.MySqlClient;//MySQL kütüphanesi

namespace DatabaseConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            GetSqlConnection();
            GetMySqlConnection();
        }

        //MySQL Server Connection
        /*View - Comment Palette - NuGet Package Manager > Mysql.Data ekliyoruz 
        Daha sonra restore diyerek projemize ekliyoruz.*/
        static void GetMySqlConnection()
        {
            string connectionString =@"server=localhost;
                                       port=3306;
                                       database=northwind;
                                       user=root;
                                       password=Burak9595!;";
            //driver provider

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("MySQL Bağlantı sağlandı");
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

        //MsSQL Server Connection
        /*View - Comment Palette - NuGet Package Manager > System.Data.SqlClient ekliyoruz 
        Daha sonra restore diyerek projemize ekliyoruz.*/
        static void GetSqlConnection()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS01;
                                        Initial Catalog=Northwind;
                                        Integrated Security=SSPI;";
            //driver provider

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine(" MSSQL Bağlantı sağlandı");
                }
                catch (Exception e)
                {
                    Console.WriteLine("MSSQL Bağlantı başarısız, hata mesajı ;");
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

        }
    }
}
