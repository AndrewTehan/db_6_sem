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

        public static void WorkExapmle(Work work)
        {
            work.GetAll();

            work.Insert("repair");
            work.Update(3, "REPAIR");
            work.GetAll();

            work.Delete(3);
            work.GetAll();
        }

        public static void TechniqueExapmle(Technique technique)
        {
            technique.GetAll();

            technique.Insert(1, "car");
            technique.Update(3, "CAR");
            technique.GetAll();

            technique.Delete(3);
            technique.GetAll();
        }

        public static void ScheduleExapmle(Schedule schedule)
        {
            schedule.GetAll();

            schedule.Insert(1, "park", "2022-02-17 22:00:00", "2022-02-24 22:10:00");
            schedule.Update(3, "2022-02-24 22:20:00");
            schedule.GetAll();

            schedule.Delete(3);
            schedule.GetAll();
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

            //Park park = new Park(db);
            //ParkExapmle(park);

            //Work work = new Work(db);
            //WorkExapmle(work);

            //Technique technique = new Technique(db);
            //TechniqueExapmle(technique);

            Schedule schedule = new Schedule(db);
            ScheduleExapmle(schedule);

            Console.WriteLine("Программа завершила работу.");
            Console.Read();
        }        
    }
}
