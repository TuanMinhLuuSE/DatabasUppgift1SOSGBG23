using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace DatabaserUppgift1VSTuanMinhLuu
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        string connectionString = "server=localhost;database=bankdb;user=root;password=passwordword;";

        AccountManager accountManager = new AccountManager();
        PasswordManager passwordManager = new PasswordManager();
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void registrationButton_Click(object sender, RoutedEventArgs e)
        {
            string username = newUsernameInput.Text;
            string password = newPasswordInput.Password;
            string confirmPassword = confirmNewPasswordInput.Password;
            bool existingAccount = CheckUsername(username);

            if (agreeTermsAndConditon.IsChecked == false)
            {
                registrationInfoLabel.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                registrationInfoLabel.Content = "You need to agree to our terms and conditions";
                return;
            }

            if (existingAccount == true)
            {
                registrationInfoLabel.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                registrationInfoLabel.Content = "An account with this username already exists";
            }

            if (existingAccount == false)
            {
                if (password.Equals(confirmPassword) && password != "" && confirmPassword != "")
                {
                    string hashedPassword = passwordManager.PasswordHasher(password);
                    accountManager.CreateAccount(username, hashedPassword);
                    registrationInfoLabel.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                    registrationInfoLabel.Content = "You have sucessfully registered an account";
                }

                else if (password == "" && confirmPassword == "")
                {
                    registrationInfoLabel.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    registrationInfoLabel.Content = "You did not enter a password or confirm your password";
                }

                else
                {
                    registrationInfoLabel.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    registrationInfoLabel.Content = "The passwords did not match";
                }
            }

            newPasswordInput.Password = "";
            confirmNewPasswordInput.Password = "";
            agreeTermsAndConditon.IsChecked = false;
        }

        private void returnToLogIn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private bool CheckUsername(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM rental_account WHERE username = @username";
                using (MySqlCommand command = new MySqlCommand(query, connection)) 
                {
                    command.Parameters.AddWithValue("@username", username);

                    int row = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();

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
    }
}
