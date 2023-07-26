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

namespace TestWPFApp
{
    /// <summary>
    /// MembersUserControl.xaml etkileşim mantığı
    /// </summary>
    public partial class MembersUserControl : UserControl
    {
        string password;
        string name;
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
            DBConnection.AddNewAdmin(txtName.Text, password, txtMail.Text, txtPhoneNumber.Text);

        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DBConnection.UpdateUser(txtName.Text, password, txtMail.Text, txtPhoneNumber.Text);
            DBConnection.ListAllUsers(membersDataGrid);


        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DBConnection.DeleteUser(txtName.Text);
            DBConnection.ListAllUsers(membersDataGrid);
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
