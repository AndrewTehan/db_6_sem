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
        static void Main(string[] args)
        {
            string technicsParkServiceConnectionString = @"Data Source=LAPTOP-SN6OS1NR\MSSQLSERVER01;Initial Catalog=TechnicsParkService;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Db db = new Db(technicsParkServiceConnectionString);

            ConsoleStep consoleStep = new ConsoleStep();
            consoleStep.Interaction(db);            

            Console.WriteLine("Программа завершила работу.");
            Console.Read();
        }        
    }
}
