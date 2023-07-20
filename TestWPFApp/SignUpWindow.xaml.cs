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
            InitializeComponent();// Initialize this window
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) // Drag and drop function for window
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e) // Minimize button for window
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) // Close button for window
        {
            Application.Current.Shutdown();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e) // Sign Up button
        {
            if (txtUser.Text.Length==0 || txtPass.Password.ToString().Length ==0 || txtMail.Text.Length == 0 || txtPhoneNumber.Text.Length == 0) // All values must be entered.
            {
                infoText.Visibility = Visibility.Visible; // opening visibility of info text
                infoText.Text = "Fill all required fields"; // info text message
                return;
            }
            if (!IsValid(txtMail.Text)) // Control for valid format e-mail
            {
                infoText.Visibility = Visibility.Visible;
                infoText.Text = "Email format is invalid";
                return;

            }
            if (DBConnection.AddNewUser(txtUser.Text, txtPass.Password.ToString(),txtMail.Text,txtPhoneNumber.Text)) // If this function is true, Sign Up is running.
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

        private void btnBack_Click(object sender, RoutedEventArgs e) // Close function for back
        {
            LogInOrSignUpWindow logInOrSignUpWindow = new LogInOrSignUpWindow(); // Reference for new window
            logInOrSignUpWindow.Show();
            this.Close();

        }

        private void txtMail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private static bool IsValid(string email) // Control function for valid e-mail with regex
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }
    }
}
