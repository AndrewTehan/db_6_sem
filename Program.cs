using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace TechnicsParService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string technicsParkServiceConnectionString = @"Data Source=LAPTOP-SN6OS1NR\MSSQLSERVER01;Initial Catalog=TechnicsParkService;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(technicsParkServiceConnectionString);
            try
            {                
                await connection.OpenAsync();
                Console.WriteLine("Подключение открыто");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {                    
                    connection.Close();
                    Console.WriteLine("Подключение закрыто...");
                }
            }

            Console.WriteLine("Программа завершила работу.");
            Console.Read();
        }
    }
}
