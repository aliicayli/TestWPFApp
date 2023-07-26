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
        public MembersUserControl()
        {
            InitializeComponent();
            DBConnection.ListAllUsers(membersDataGrid);
        }

        private void membersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
