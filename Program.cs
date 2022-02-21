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
        public static void RoleExample(Role role)
        {
            role.GetAll();

            role.Insert("new");
            role.Update(3, "other role");
            role.GetAll();

            role.Delete(3);
            role.GetAll();
        }

        public static void UserExample(User user)
        {
            user.GetAll();

            user.Insert("newu", "newe", "ewqqwe", 1);
            user.Update(4, "NEWU");
            user.GetAll();

            user.Delete(4);
            user.GetAll();
        }

        public static void CompanyExample(Company company)
        {
            company.GetAll();

            company.Insert(1, "newc", "newc@gmail.com");
            company.Update(2, "NEWC");
            company.GetAll();

            company.Delete(2);
            company.GetAll();
        }

        public static void ParkExapmle(Park park)
        {
            park.GetAll();

            park.Insert(1, 20);
            park.Update(3, 40);
            park.GetAll();

            park.Delete(3);
            park.GetAll();
        }


        static void Main(string[] args)
        {
            string technicsParkServiceConnectionString = @"Data Source=LAPTOP-SN6OS1NR\MSSQLSERVER01;Initial Catalog=TechnicsParkService;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            Db db = new Db(technicsParkServiceConnectionString);

            //Role role = new Role(db);
            //RoleExample(role);

            //User user = new User(db);
            //UserExample(user);

            //Company company = new Company(db);
            //CompanyExample(company);

            Park park = new Park(db);
            ParkExapmle(park);


            Console.WriteLine("Программа завершила работу.");
            Console.Read();
        }
    }
}
