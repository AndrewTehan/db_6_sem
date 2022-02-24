using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucking
{
    class Park : SqlCrud
    {
        public Park(Db db)
        {
            _db = db;
        }

        public override bool Delete(int id)
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"delete from parks where id = {id}",
                Connection = _db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            _db.closeConnection();

            bool is_deleted = changedRows == 1;
            string message = is_deleted ? "Парк удалён" : "Парк не удалён";
            Console.WriteLine(message);
            return is_deleted;
        }

        public override void GetAll()
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = "select * from parks",
                Connection = _db.Connection
            };

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                string columnName1 = reader.GetName(0);
                string columnName2 = reader.GetName(1);
                string columnName3 = reader.GetName(2);

                Console.WriteLine($"{columnName1}\t {columnName2}\t {columnName3}\t");

                while (reader.Read())
                {
                    object id = reader.GetValue(0);
                    object company_id = reader.GetValue(1);
                    object capacity = reader.GetValue(2);

                    Console.WriteLine($"\t{id}: \t{company_id} \t{capacity} ...");
                }
            }

            reader.Close();
            _db.closeConnection();

            Console.WriteLine($"------------------------------------");
        }

        public bool Insert(int company_id, int capacity)
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"insert into parks(id, comapny_id, capacity)" +
                               $"values ({LastId() + 1}, '{company_id}', {capacity})",
                Connection = _db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            _db.closeConnection();

            bool is_inserted = changedRows == 1;
            string message = changedRows == 1 ? "Парк добавлен" : "Парк не добавлен";
            Console.WriteLine(message);
            return is_inserted;
        }

        public bool Update(int id, int capcity)
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"update parks set capacity = '{capcity}' where id = {id}",
                Connection = _db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            _db.closeConnection();

            bool is_updated = changedRows == 1;
            string message = is_updated ? "Парк обновлён" : "Парк не одновлён";
            Console.WriteLine(message);
            return is_updated;
        }

        public override int LastId()
        {
            SqlCommand command = new SqlCommand
            {
                CommandText = "select top 1 * from parks order by id desc",
                Connection = _db.Connection
            };

            int res = (int)command.ExecuteScalar();

            return res;
        }
    }
}
