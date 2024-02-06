using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Org.BouncyCastle.Bcpg.OpenPgp;
using MySql.Data.MySqlClient;

namespace DatabaserUppgift1VSTuanMinhLuu
{
    public class PasswordManager
    {
        string connectionString = "server=localhost;database=bankdb;user=root;password=passwordword;";
        public string PasswordHasher(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashbytes = sha256.ComputeHash(passwordBytes);

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hashbytes.Length; i++)
                {
                    stringBuilder.Append(hashbytes[i]);
                }

                return stringBuilder.ToString();
            }
        }

        public bool PasswordAuthenticator(int currentId, string hashedPassword)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM rental_account WHERE renter_id = @renterId AND password = @password";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@renterId", currentId);
                    command.Parameters.AddWithValue("@password", hashedPassword);

                    int row = Convert.ToInt32(command.ExecuteScalar());

                    if (row > 0)
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }
            }
        }

        public void ChangePassword(string hashedPassword, int currentId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE rental_account SET password = @password WHERE renter_id = @rentalId";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@password", hashedPassword);
                    command.Parameters.AddWithValue("@rentalId", currentId);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
