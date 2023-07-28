using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TestWPFApp
{
    /// <summary>
    /// MembersUserControl.xaml etkileşim mantığı
    /// </summary>
    public partial class MembersUserControl : UserControl
    {
        string password;
        string name;
        private bool _isTimerRunning = false; // bool variable for thread

        public MembersUserControl()
        {
            InitializeComponent();
            DBConnection.ListAllUsers(membersDataGrid);
        }

        private void membersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (membersDataGrid.SelectedItem != null)
            {
                Member member = membersDataGrid.SelectedItem as Member;
                txtName.Text = member.UserName;
                txtMail.Text = member.Email;
                txtPhoneNumber.Text = member.PhoneNumber;
                password = member.Password;
            }

        }



        private void btnSetAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (txtMail.Text.Length == 0 || password.Length == 0|| txtMail.Text.Length == 0 || txtPhoneNumber.Text.Length == 0)
            {
                infoText.Visibility = Visibility.Visible; // opening visibility of info text
                infoText.Content = "Fill all required fields"; // info text message
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
            if (DBConnection.AddNewAdmin(txtName.Text, password, txtMail.Text, txtPhoneNumber.Text))
            {
                infoText.Visibility = Visibility.Visible; // opening visibility of info text
                infoText.Content = "User is now admin"; // info text message
                if (!_isTimerRunning) // Statement for thread. If the thread is running, it will not run again.
                {
                    DispatcherTimer timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(2);
                    timer.Tick += Timer_Tick; // listening for event
                    timer.Start();
                    _isTimerRunning = true;
                }
            }
            else
            {
                infoText.Visibility = Visibility.Visible; // opening visibility of info text
                infoText.Content = "User is already admin"; // info text message
                if (!_isTimerRunning) // Statement for thread. If the thread is running, it will not run again.
                {
                    DispatcherTimer timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(2);
                    timer.Tick += Timer_Tick; // listening for event
                    timer.Start();
                    _isTimerRunning = true;
                }
            }
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DBConnection.UpdateUser(txtName.Text, password, txtMail.Text, txtPhoneNumber.Text);
            DBConnection.ListAllUsers(membersDataGrid);
            infoText.Visibility = Visibility.Visible; // opening visibility of info text
            infoText.Content = "Fill all required fields"; // info text 
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DBConnection.DeleteUser(txtName.Text);
            DBConnection.ListAllUsers(membersDataGrid);
        }

        private void Timer_Tick(object sender, EventArgs e) // For timer
        {
            infoText.Visibility = Visibility.Collapsed;
            (sender as DispatcherTimer).Stop();
            _isTimerRunning = false;
        }
    }

    public class Member
    {
        public string Character { get; set; }
        public Brush BgColor { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
