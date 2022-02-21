using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicsParService
{
    class User : SqlCrud
    {
        public User(Db db)
        {
            _db = db;
        }

        public override bool Delete(int id)
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"delete from users where id = {id}",
                Connection = _db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            _db.closeConnection();

            bool is_deleted = changedRows == 1;
            string message = is_deleted ? "Пользоавтель удалён" : "Пользоавтель не удалён";
            Console.WriteLine(message);
            return is_deleted;
        }

        public override void GetAll()
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = "select * from users",
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

                Console.WriteLine($"{columnName1}\t {columnName2}\t {columnName3}\t {columnName4}\t {columnName5}\t");

                while (reader.Read())
                {
                    object id = reader.GetValue(0);
                    object nickname = reader.GetValue(1);
                    object email = reader.GetValue(2);

                    Console.WriteLine($"\t{id}: \t{nickname} \t{email} ...");
                }
            }

            reader.Close();
            _db.closeConnection();

            Console.WriteLine($"------------------------------------");
        }

        public bool Insert(string nickname, string email, string password, int role_id)
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"insert into users(id, nickname, email, password, role_id)" +
                               $"values ({LastId() + 1}, '{nickname}', '{email}', '{password}', {role_id})",
                Connection = _db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            _db.closeConnection();

            bool is_inserted = changedRows == 1;
            string message = changedRows == 1 ? "Роль добавлена" : "Роль не добавлена";
            Console.WriteLine(message);
            return is_inserted;
        }

        public bool Update(int id, string nickname)
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"update users set nickname = '{nickname}' where id = {id}",
                Connection = _db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            _db.closeConnection();

            bool is_updated = changedRows == 1;
            string message = is_updated ? "Пользователь одновлён" : "Пользователь не одновлён";
            Console.WriteLine(message);
            return is_updated;
        }

        public override int LastId()
        {
            SqlCommand command = new SqlCommand
            {
                CommandText = "select top 1 * from users order by id desc",
                Connection = _db.Connection
            };

            int res = (int)command.ExecuteScalar();

            return res;
        }
    }
}
