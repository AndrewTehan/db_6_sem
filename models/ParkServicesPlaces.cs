using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicsParService
{
    class ParkServicesPlaces
    {

        private static Db db;

        public ParkServicesPlaces(Db db)
        {
            _db = db;
        }

        public Db _db
        {
            get { return db; }
            set { db = value; }
        }

        public bool Insert(int park_service_id, int place_id)
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"insert into park_services_places(id, park_service_id, place_id)" +
                               $"values ({LastId() + 1}, {park_service_id}, {place_id})",
                Connection = _db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            _db.closeConnection();

            bool is_inserted = changedRows == 1;
            string message = changedRows == 1 ? "Запись добавлена" : "Запись не добавлена";
            Console.WriteLine(message);
            return is_inserted;
        }

        public bool Delete(int id)
        {
            _db.openConnection();

            SqlCommand command = new SqlCommand
            {
                CommandText = $"delete from park_services_places where id = {id}",
                Connection = _db.Connection
            };

            int changedRows = command.ExecuteNonQuery();

            _db.closeConnection();

            bool is_deleted = changedRows == 1;
            string message = is_deleted ? "Запись удалёна" : "Запись не удалёна";
            Console.WriteLine(message);
            return is_deleted;
        }

        public int LastId()
        {
            SqlCommand command = new SqlCommand
            {
                CommandText = "select top 1 * from park_services_places order by id desc",
                Connection = _db.Connection
            };

            int res = (int)command.ExecuteScalar();

            return res;
        }
    }
}
