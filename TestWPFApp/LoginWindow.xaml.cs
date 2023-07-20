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
using System.Windows.Threading;

namespace TestWPFApp
{
    /// <summary>
    /// LoginWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class LoginWindow : Window
    {
        private bool _isTimerRunning = false; // bool variable for thread
        public LoginWindow()
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

        private void btnLogin_Click(object sender, RoutedEventArgs e) // Login button
        {
            if (txtUser.Text.Length == 0 || txtPass.Password == null) // All values must be entered.
            {
                infoText.Visibility = Visibility.Visible; // opening visibility of info text
                infoText.Text = "Fill all required fields"; // info text message
                if (!_isTimerRunning) // Statement for thread. If the thread is running, it will not run again.
                {
                    DispatcherTimer timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(2);
                    timer.Tick += Timer_Tick; // listening for event
                    timer.Start();
                    _isTimerRunning = true;
                }
                return;
            }
            if (DBConnection.Login(txtUser.Text, txtPass.Password.ToString())) // If this function is true, Login is running.
            {
                MessageBox.Show("Login");
            }
            else
            {
                // If not logged in, a message is displayed. 
                infoText.Visibility = Visibility.Visible;
                infoText.Text = "Incorrect password or username";
                if (!_isTimerRunning)
                {
                    DispatcherTimer timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(2);
                    timer.Tick += Timer_Tick;
                    timer.Start();
                    _isTimerRunning = true;
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e) // Close function for back
        {
            LogInOrSignUpWindow logInOrSignUpWindow = new LogInOrSignUpWindow(); // Reference for new window
            logInOrSignUpWindow.Show();
            this.Close();
        }
        private void Timer_Tick(object sender, EventArgs e) // For timer
        {
            infoText.Visibility = Visibility.Collapsed;
            (sender as DispatcherTimer).Stop();
            _isTimerRunning = false;
        }

    }
}
