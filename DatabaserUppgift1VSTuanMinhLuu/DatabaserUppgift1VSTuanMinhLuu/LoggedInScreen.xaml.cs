using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// Interaction logic for LoggedInScreen.xaml
    /// </summary>
    public partial class LoggedInScreen : Window
    {
        string connectionString = "server=localhost;database=bankdb;user=root;password=passwordword;";
        int currentId;

        RentalManager rentalManager = new RentalManager();
        AccountManager accountManager = new AccountManager();
        private LoginWindow loginWindow;

        public LoginWindow LoginWindow
        {
            set
            {
                if (loginWindow != value)
                { 
                    loginWindow = value; 
                }
            }
        }

        List<Cars> carList = new List<Cars>();
        List<ActiveRentals> activeRentalList = new List<ActiveRentals>();
        public LoggedInScreen()
        {
            InitializeComponent();
            addDetailsPanel.Visibility = Visibility.Collapsed;
            changePasswordPanel.Visibility = Visibility.Collapsed;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            Hide();
            e.Cancel = true;
            loginWindow.Show();
        }

        public void SetCurrentId(int renterId)
        {
            currentId = renterId;
        }
        public void SetOrUpdateListBox()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                carList.Clear();
                string query = "SELECT * FROM availableCars";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int carId = reader.GetInt32(0);
                            string carBrand = reader.GetString(1);
                            string carModel = reader.GetString(2);
                            string carType = reader.GetString(3);
                            string carFuelType = reader.GetString(4);
                            int numberOfSeats = reader.GetInt32(5);
                            bool carAvailable = reader.GetBoolean(6);

                            Cars newCar = new Cars(carId, carBrand, carModel, carType, carFuelType, numberOfSeats, carAvailable);
                            carList.Add(newCar);
                        }
                    }

                    activeRentalList.Clear();
                    string query2 = "SELECT * FROM rented_cars JOIN cars ON rented_cars.car_id = cars.car_id WHERE renter_id = @renterId";
                    using (MySqlCommand command2 = new MySqlCommand(query2, connection))
                    {
                        command2.Parameters.AddWithValue("@renterId", currentId);

                        using (MySqlDataReader reader2 = command2.ExecuteReader())
                        {
                            while (reader2.Read())
                            {
                                int rentalId = reader2.GetInt32(0);
                                int renterId = reader2.GetInt32(1);
                                int carId = reader2.GetInt32(2);
                                string carBrand = reader2.GetString(4);
                                string carModel = reader2.GetString(5);

                                ActiveRentals newActiveRental = new ActiveRentals(rentalId, renterId, carId, carBrand, carModel);
                                activeRentalList.Add(newActiveRental);
                            }
                        }
                    }
                    connection.Close();
                }
            }

            carsToRent.Items.Clear();
            foreach (Cars cars in carList)
            {
                carsToRent.Items.Add(cars.CarBrand + " " + cars.CarModel);
            }

            rentedCars.Items.Clear();
            foreach (ActiveRentals activeRentals in activeRentalList)
            {
                if(activeRentals.RenterId == currentId)
                {
                    rentedCars.Items.Add(activeRentals.CarBrand + " " + activeRentals.CarModel);
                }
            }
        }

        private void carsToRent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = carsToRent.SelectedItem?.ToString();

            if (selected != null)
            {
                foreach (Cars cars in carList)
                {
                    if (selected.Contains(cars.CarModel))
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.AppendLine("Brand: " + cars.CarBrand);
                        stringBuilder.AppendLine("Model: " + cars.CarModel);
                        stringBuilder.AppendLine("Type: " + cars.CarType);
                        stringBuilder.AppendLine("Fueltype: " + cars.CarFuelType);
                        stringBuilder.AppendLine("Seats: " + Convert.ToString(cars.CarNumberOfSeats));

                        string result = stringBuilder.ToString();

                        carInfoLabel.Content = result;
                        break;
                    }
                }
            }
        }

        private void rentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selected = carsToRent.SelectedItem.ToString();

                foreach (Cars cars in carList)
                {
                    if (selected.Contains(cars.CarModel))
                    {
                        rentalManager.Rent(cars.CarId, currentId);
                        SetOrUpdateListBox();
                        break;
                    }
                }
            }

            catch
            {

            }
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selected = rentedCars.SelectedItem.ToString();

                foreach (ActiveRentals activeRentals in activeRentalList)
                {
                    if (selected.Contains(activeRentals.CarModel))
                    {
                        rentalManager.Return(activeRentals.RentalId);
                        SetOrUpdateListBox();
                        break;
                    }
                }
            }

            catch
            {

            }
        }

        private void rentedCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            loginWindow.Show();
        }

        private void editInfoButton_Click(object sender, RoutedEventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM renter_info WHERE renter_id = @renterId";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@renterId", currentId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            firstnameInput.Text = reader.GetString(1);
                            lastnameInput.Text = reader.GetString(2);
                            addressInput.Text = reader.GetString(3);
                            zipCodeInput.Text = Convert.ToString(reader.GetInt32(4));
                            cityInput.Text = reader.GetString(5);
                            countryInput.Text = reader.GetString(6);
                            emailInput.Text = reader.GetString(7);
                        }
                    }
                }
                connection.Close();
            }
            addDetailsPanel.Visibility = Visibility.Visible;
        }

        private void changePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            changePasswordPanel.Visibility = Visibility.Visible;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            addDetailsPanel.Visibility = Visibility.Collapsed;
            editSavedLabel.Content = "";
        }

        private void saveEditButton_Click(object sender, RoutedEventArgs e)
        {
            string firstname = firstnameInput.Text;
            string lastname = lastnameInput.Text;
            string address = addressInput.Text;
            int zipcode = Convert.ToInt32(zipCodeInput.Text);
            string city = cityInput.Text;
            string country = countryInput.Text;
            string email = emailInput.Text;
            int renterId = currentId;
            accountManager.EditInfo(firstname, lastname, address, zipcode, city, country, email, renterId);
            editSavedLabel.Content = "Your changes has been saved.";
        }

        private void searchbar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = searchbar.Text;
            
            if(searchText.Length == 0)
            {
                SetOrUpdateListBox();
            }

            else
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    carList.Clear();
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand("searching", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("p_searchtext", searchText);
                        
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int carId = reader.GetInt32(0);
                                string carBrand = reader.GetString(1);
                                string carModel = reader.GetString(2);
                                string carType = reader.GetString(3);
                                string carFuelType = reader.GetString(4);
                                int numberOfSeats = reader.GetInt32(5);
                                bool carAvailable = reader.GetBoolean(6);

                                Cars newCar = new Cars(carId, carBrand, carModel, carType, carFuelType, numberOfSeats, carAvailable);
                                carList.Add(newCar);
                            }
                            
                            carsToRent.Items.Clear();
                            foreach (Cars cars in carList)
                            {
                                carsToRent.Items.Add(cars.CarBrand + " " + cars.CarModel);
                            }
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void exitButton2_Click(object sender, RoutedEventArgs e)
        {
            changePasswordPanel.Visibility = Visibility.Collapsed;
        }

        private void changePasswordConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            string oldPassword = oldPasswordInput.Password;
            string newPassword = newPasswordInput.Password;
            string confirmPassword = confirmPasswordInput.Password;

            int outcome = accountManager.ChangePassword(oldPassword, newPassword, confirmPassword, currentId);

            if (outcome == 1)
            {
                changedPasswordLabel.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                changedPasswordLabel.Content = "Your current password is incorrect";
            }

            if (outcome == 2)
            {
                changedPasswordLabel.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                changedPasswordLabel.Content = "You did not enter your new password or confirm your new password";
            }

            if (outcome == 3)
            {
                changedPasswordLabel.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                changedPasswordLabel.Content = "The passwords did not match";
            }

            if (outcome == 4)
            {
                changedPasswordLabel.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                changedPasswordLabel.Content = "You have sucessfully changed your password";
            }

            oldPasswordInput.Password = "";
            newPasswordInput.Password = "";
            confirmPasswordInput.Password = "";
        }
    }
}
