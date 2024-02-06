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

namespace DatabaserUppgift1VSTuanMinhLuu
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        AccountManager accountManager = new AccountManager();
        LoggedInScreen loggedInScreen = new LoggedInScreen();
        public LoginWindow()
        {
            InitializeComponent();
            loggedInScreen.LoginWindow = this;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameInput.Text;
            string password = passwordInput.Password;
            int renterId = accountManager.LoginAuthenticator(username, password);

            if (renterId > 0)
            {
                infoLabel.Content = "";
                loggedInScreen.Show();
                loggedInScreen.SetCurrentId(renterId);
                loggedInScreen.SetOrUpdateListBox();
                Hide();
            }

            else
            {
                infoLabel.Content = "Your username or password was incorrect";
            }

            passwordInput.Password = "";
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();

        }
    }
}
