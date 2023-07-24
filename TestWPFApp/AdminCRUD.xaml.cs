using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
    /// AdminCRUD.xaml etkileşim mantığı
    /// </summary>
    public partial class AdminCRUD : Window
    {
        public AdminCRUD()
        {
            InitializeComponent();
            
        }


        private void Window_Loaded(object sender, RoutedEventArgs e) // Loadded window
        {
            DBConnection.ListAllUsers(UsersDataGrid);
        }
    }
}
