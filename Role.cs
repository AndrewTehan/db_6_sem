using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicsParService
{
    static class Role
    {
        private static Db db;

        public static Db DB
        {
            set { db = value; }
        }

        public static bool insert(string name)
        {
            db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"insert into roles(id, titel) values ({lastId() + 1}, '{name}')",
                Connection = db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            db.closeConnection();

            bool is_inserted = changedRows == 1;
            string message = changedRows == 1 ? "Роль добавлена" : "Роль не добавлена";
            Console.WriteLine(message);
            return is_inserted;
        }

        public static bool delete(int id)
        {
            db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"delete from roles where id = {id}",
                Connection = db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            db.closeConnection();

            bool is_deleted = changedRows == 1;
            string message = changedRows == 1 ? "Роль удалена" : "Роль не удалена";
            Console.WriteLine(message);
            return is_deleted;
        }

        public static void getAll()
        {
            db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = "select * from roles",
                Connection = db.Connection
            };

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                string columnName1 = reader.GetName(0);                

                Console.WriteLine($"{columnName1}\t");

                while (reader.Read())
                {
                    object id = reader.GetValue(0);
                    object name = reader.GetValue(1);

                    Console.WriteLine($"\t{id}: \t{name}");
                }
            }

            reader.Close();
            db.closeConnection();

            Console.WriteLine($"------------------------------------");
        }

        private static int lastId()
        {

            SqlCommand command = new SqlCommand
            {
                CommandText = "select top 1 * from roles order by id desc",
                Connection = db.Connection
            };

            int res = (int)command.ExecuteScalar();

            return res;
        }
    }
}
