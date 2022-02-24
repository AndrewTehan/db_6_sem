using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucking
{
    class Company : SqlCrud
    {
        public Company(Db db)
        {
            _db = db;
        }

        public override bool Delete(int id)
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"delete from companies where id = {id}",
                Connection = _db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            _db.closeConnection();

            bool is_deleted = changedRows == 1;
            string message = is_deleted ? "Компания удалена" : "Компания не удалена";
            Console.WriteLine(message);
            return is_deleted;
        }

        public override void GetAll()
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = "select * from companies",
                Connection = _db.Connection
            };

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                string columnName1 = reader.GetName(0);
                string columnName2 = reader.GetName(1);
                string columnName3 = reader.GetName(2);
                string columnName4 = reader.GetName(3);

                Console.WriteLine($"{columnName1}\t {columnName2}\t {columnName3}\t {columnName4}\t");

                while (reader.Read())
                {
                    object id = reader.GetValue(0);
                    object Driver_id = reader.GetValue(1);
                    object name = reader.GetValue(2);                    

                    Console.WriteLine($"\t{id}: \t{Driver_id} \t{name} ...");
                }
            }

            reader.Close();
            _db.closeConnection();

            Console.WriteLine($"------------------------------------");
        }

        public bool Insert(int Driver_id, string name, string email)
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"insert into companies(id, Driver_id, name, email)" +
                               $"values ({LastId() + 1}, {Driver_id}, '{name}', '{email}')",
                Connection = _db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            _db.closeConnection();

            bool is_inserted = changedRows == 1;
            string message = changedRows == 1 ? "Компания добавлена" : "Компания не добавлена";
            Console.WriteLine(message);
            return is_inserted;
        }

        public bool Update(int id, string name)
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"update companies set name = '{name}' where id = {id}",
                Connection = _db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            _db.closeConnection();

            bool is_updated = changedRows == 1;
            string message = is_updated ? "Компания обновлена" : "Компания не обновлена";
            Console.WriteLine(message);
            return is_updated;
        }

        public override int LastId()
        {
            SqlCommand command = new SqlCommand
            {
                CommandText = "select top 1 * from companies order by id desc",
                Connection = _db.Connection
            };

            int res = (int)command.ExecuteScalar();

            return res;
        }
    }
}
