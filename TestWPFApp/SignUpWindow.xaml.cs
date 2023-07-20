using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestWPFApp
{
    /// <summary>
    /// SignUpWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            if (txtUser.Text.Length==0 || txtPass.Password.ToString().Length ==0 || txtMail.Text.Length == 0 || txtPhoneNumber.Text.Length == 0)
            {
                infoText.Visibility = Visibility.Visible;
                infoText.Text = "Fill all required fields";
                return;
            }
            if (!IsValid(txtMail.Text))
            {
                infoText.Visibility = Visibility.Visible;
                infoText.Text = "Email format is invalid";
                return;
            }
            if (DBConnection.AddNewUser(txtUser.Text, txtPass.Password.ToString(),txtMail.Text,txtPhoneNumber.Text))
            {
                infoText.Visibility = Visibility.Visible;
                infoText.Text = "Registration is succesful";
            }
            else
            {
                infoText.Visibility = Visibility.Visible;
                infoText.Text = "This username is already taken.";
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            LogInOrSignUpWindow logInOrSignUpWindow = new LogInOrSignUpWindow();
            logInOrSignUpWindow.Show();
            this.Close();

        }

        private void txtMail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private static bool IsValid(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }
    }
}
