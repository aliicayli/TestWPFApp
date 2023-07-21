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

namespace TestWPFApp
{
    /// <summary>
    /// LogInOrSignUpWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class LogInOrSignUpWindow : Window
    {
        public LogInOrSignUpWindow()
        {
            InitializeComponent(); // Initialize this window
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

        private void btnLogin_Click(object sender, RoutedEventArgs e) // Open login window
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e) // Open Sign Up window
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
            this.Close();
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            LoginAdminWindow loginAdminWindow = new LoginAdminWindow();
            loginAdminWindow.Show();
            this.Close();
        }
    }
}
