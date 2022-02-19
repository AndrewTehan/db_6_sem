using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicsParService
{
    class Role : SqlCrud
    {
        public Role(Db db)
        {
            _db = db;
        }

        public override bool Insert(string name)
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"insert into roles(id, titel) values ({LastId() + 1}, '{name}')",
                Connection = _db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            _db.closeConnection();

            bool is_inserted = changedRows == 1;
            string message = changedRows == 1 ? "Роль добавлена" : "Роль не добавлена";
            Console.WriteLine(message);
            return is_inserted;
        }

        public override bool Delete(int id)
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"delete from roles where id = {id}",
                Connection = _db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            _db.closeConnection();

            bool is_deleted = changedRows == 1;
            string message = changedRows == 1 ? "Роль удалена" : "Роль не удалена";
            Console.WriteLine(message);
            return is_deleted;
        }

        public override void GetAll()
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = "select * from roles",
                Connection = _db.Connection
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
            _db.closeConnection();

            Console.WriteLine($"------------------------------------");
        }

        public override int LastId()
        {
            SqlCommand command = new SqlCommand
            {
                CommandText = "select top 1 * from roles order by id desc",
                Connection = _db.Connection
            };

            int res = (int)command.ExecuteScalar();

            return res;
        }
    }
}
