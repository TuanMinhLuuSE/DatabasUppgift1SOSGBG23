using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaserUppgift1VSTuanMinhLuu
{
    public class RentalManager
    {
        string connectionString = "server=localhost;database=bankdb;user=root;password=passwordword;";
        public void Rent(int carId, int renterId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO rented_cars VALUES(DEFAULT, @renter_id, @car_id)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@renter_id", renterId);
                    command.Parameters.AddWithValue("@car_id", carId);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void Return(int rentalId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM rented_cars WHERE rental_id = @rental_id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@rental_id", rentalId);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
