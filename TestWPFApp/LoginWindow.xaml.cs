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
    /// LoginWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
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

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUser.Text.Length == 0 || txtPass.Password == null)
            {
                infoText.Visibility = Visibility.Visible;
                infoText.Text = "Fill all required fields";
                return;
            }
            if (DBConnection.Login(txtUser.Text, txtPass.Password.ToString()))
            {
                MessageBox.Show("Login");
            }
            else
            {
                MessageBox.Show("Retry");

            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            LogInOrSignUpWindow logInOrSignUpWindow = new LogInOrSignUpWindow();
            logInOrSignUpWindow.Show();
            this.Close();
        }
    }
}
