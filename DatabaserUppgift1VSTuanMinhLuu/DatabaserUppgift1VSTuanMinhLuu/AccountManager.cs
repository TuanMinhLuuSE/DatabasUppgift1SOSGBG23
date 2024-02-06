using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DatabaserUppgift1VSTuanMinhLuu
{
    public class AccountManager
    {
        string connectionString = "server=localhost;database=bankdb;user=root;password=passwordword;";
        PasswordManager passwordManager = new PasswordManager();

        public int currentId;

        public int LoginAuthenticator(string username, string password)
        {
            string hashedPassword = passwordManager.PasswordHasher(password);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM rental_account WHERE username = @username AND password = @password";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", hashedPassword);

                    int row = Convert.ToInt32(command.ExecuteScalar());

                    if (row > 0)
                    {
                        string query2 = "SELECT * FROM rental_account";
                        using (MySqlCommand command2 = new MySqlCommand(query2, connection))
                        {
                            using (MySqlDataReader reader = command2.ExecuteReader())
                            {
                                bool foundId = false;
                                while (reader.Read() && foundId == false)
                                {
                                    int renterId = reader.GetInt32(0);
                                    string renterUsername = reader.GetString(1);
                                    if (renterUsername == username)
                                    {
                                        currentId = renterId;
                                        foundId = true; // KOLLA ÖVER DETTA OM DET ÄR PÅ RÄTT PLATS
                                    }
                                }
                            }
                        }
                        connection.Close();
                        return currentId;
                    }

                    else
                    {                       
                        return 0;
                    }
                }
            }
        }
        public void CreateAccount(string username, string hashedPassword)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO rental_account VALUES (DEFAULT, @username, @password)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", hashedPassword);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void EditInfo(string firstname, string lastname, string address, int zipcode, string city, string country, string email, int renterId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("editUserInfo", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("p_firstname", firstname);
                    command.Parameters.AddWithValue("p_lastname", lastname);
                    command.Parameters.AddWithValue("p_address", address);
                    command.Parameters.AddWithValue("p_zipcode", zipcode);
                    command.Parameters.AddWithValue("p_city", city);
                    command.Parameters.AddWithValue("p_country", country);
                    command.Parameters.AddWithValue("p_email", email);
                    command.Parameters.AddWithValue("p_renter_id", renterId);

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public int ChangePassword(string oldPassword, string newPassword, string confirmPassword, int currentId)
        {
            string hashedPassword = passwordManager.PasswordHasher(oldPassword);
            bool correct = passwordManager.PasswordAuthenticator(currentId, hashedPassword);

            if (correct == false)
            {
                return 1;
            }

            if (correct == true)
            {
                if (newPassword == "" || confirmPassword == "")
                {
                    return 2;
                }
                
                if (newPassword != confirmPassword)
                {
                    return 3;
                }
                
                string newHashedPassword = passwordManager.PasswordHasher(newPassword);
                passwordManager.ChangePassword(newHashedPassword, currentId);
                return 4;
            }

            else
            {
                return 0;
            }
        }
    }
}
