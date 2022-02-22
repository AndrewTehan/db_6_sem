using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicsParService
{
    class Schedule : SqlCrud
    {
        public Schedule(Db db)
        {
            _db = db;
        }

        public override void GetAll()
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = "select * from schedules",
                Connection = _db.Connection
            };

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                string columnName1 = reader.GetName(0);
                string columnName2 = reader.GetName(1);
                string columnName3 = reader.GetName(2);
                string columnName4 = reader.GetName(3);
                string columnName5 = reader.GetName(4);

                Console.WriteLine($"{columnName1}\t {columnName2}\t {columnName3}\t {columnName4}\t {columnName5}");

                while (reader.Read())
                {
                    object id = reader.GetValue(0);
                    object user_id = reader.GetValue(1);
                    object title = reader.GetValue(2);

                    Console.WriteLine($"\t{id}: \t{user_id}, \t{title} ...");
                }
            }

            reader.Close();
            _db.closeConnection();

            Console.WriteLine($"------------------------------------");
        }

        public bool Insert(int schedulable_id, string schedulable_type, string start_date, string end_date)
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"insert into schedules(id, schedulable_id, schedulable_type, start_date, end_date)" +
                               $"values ({LastId() + 1}, {schedulable_id}, '{schedulable_type}', '{start_date}', '{end_date}')",
                Connection = _db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            _db.closeConnection();

            bool is_inserted = changedRows == 1;
            string message = changedRows == 1 ? "Расписание добавлено" : "Расписание не добавлено";
            Console.WriteLine(message);
            return is_inserted;
        }

        public bool Update(int id, string end_date)
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"update schedules set end_date = '{end_date}' where id = {id}",
                Connection = _db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            _db.closeConnection();

            bool is_updated = changedRows == 1;
            string message = is_updated ? "Расписание обновлёно" : "Расписание не обновлёно";
            Console.WriteLine(message);
            return is_updated;
        }

        public override bool Delete(int id)
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"delete from schedules where id = {id}",
                Connection = _db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            _db.closeConnection();

            bool is_deleted = changedRows == 1;
            string message = is_deleted ? "Расписание удалёно" : "Расписание не удалёно";
            Console.WriteLine(message);
            return is_deleted;
        }

        public override int LastId()
        {
            SqlCommand command = new SqlCommand
            {
                CommandText = "select top 1 * from  schedules order by id desc",
                Connection = _db.Connection
            };

            int res = (int)command.ExecuteScalar();

            return res;
        }
    }
}
