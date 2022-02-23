using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicsParService
{
    class Section : SqlCrud
    {
        public Section(Db db)
        {
            _db = db;
        }

        public override void GetAll()
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = "select * from sections",
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

                Console.WriteLine($"{columnName1}\t {columnName2}\t {columnName3}\t {columnName4}\t {columnName4}");

                while (reader.Read())
                {
                    object id = reader.GetValue(0);
                    object name = reader.GetValue(1);
                    object capacity = reader.GetValue(2);

                    Console.WriteLine($"\t{id}: \t{name} \t{capacity} ...");
                }
            }

            reader.Close();
            _db.closeConnection();

            Console.WriteLine($"------------------------------------");
        }

        public bool Insert(string name, int capacity, int sectionable_id, string sectionable_type)
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"insert into sections(id, name, capacity, sectionable_id, sectionable_type)" +
                               $"values ({LastId() + 1}, '{name}', {capacity}, {sectionable_id}, {sectionable_type})",
                Connection = _db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            _db.closeConnection();

            bool is_inserted = changedRows == 1;
            string message = changedRows == 1 ? "Секция добавлена" : "Секция не добавлена";
            Console.WriteLine(message);
            return is_inserted;
        }

        public bool Update(int id, int capacity)
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"update works set name = {capacity} where id = {id}",
                Connection = _db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            _db.closeConnection();

            bool is_updated = changedRows == 1;
            string message = is_updated ? "Секция обновлёна" : "Секция не обновлёна";
            Console.WriteLine(message);
            return is_updated;
        }

        public override bool Delete(int id)
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"delete from sectionds where id = {id}",
                Connection = _db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            _db.closeConnection();

            bool is_deleted = changedRows == 1;
            string message = is_deleted ? "Секция удалёна" : "Секция не удалёна";
            Console.WriteLine(message);
            return is_deleted;
        }

        public override int LastId()
        {
            SqlCommand command = new SqlCommand
            {
                CommandText = "select top 1 * from sections order by id desc",
                Connection = _db.Connection
            };

            int res = (int)command.ExecuteScalar();

            return res;
        }
    }
}
