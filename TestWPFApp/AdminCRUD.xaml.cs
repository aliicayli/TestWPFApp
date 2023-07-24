using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace TestWPFApp
{
    /// <summary>
    /// AdminCRUD.xaml etkileşim mantığı
    /// </summary>
    public partial class AdminCRUD : Window
    {
        string password;
        public AdminCRUD()
        {
            InitializeComponent();
            
        }


        private void Window_Loaded(object sender, RoutedEventArgs e) // Loadded window
        {
            DBConnection.ListAllUsers(UsersDataGrid);
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            DBConnection.AddNewAdmin(userNameTextBox.Text, password, eMailTextBox.Text, phoneTextBox.Text);
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            DBConnection.UpdateUser(userNameTextBox.Text, password, eMailTextBox.Text, phoneTextBox.Text);
            DBConnection.ListAllUsers(UsersDataGrid);
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UsersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                DataRowView dataRowView = (DataRowView)e.AddedItems[0];
                userNameTextBox.Text = dataRowView["user_name"].ToString(); 
                password = dataRowView["password"].ToString();
                eMailTextBox.Text= dataRowView["email"].ToString();         
                phoneTextBox.Text= dataRowView["phone_number"].ToString();         

            }
        }
    }
}
