using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Table;

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
            if (password == null)
            {
                return;
            }
            if (txtMail.Text.Length == 0 || password.Length == 0 || txtMail.Text.Length == 0 || txtPhoneNumber.Text.Length == 0)
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
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (password == null)
            {
                return;
            }
            if (txtMail.Text.Length == 0 || password.Length == 0 || txtMail.Text.Length == 0 || txtPhoneNumber.Text.Length == 0)
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

            if (DBConnection.DeleteUser(txtName.Text))
            {
                infoText.Visibility = Visibility.Visible; // opening visibility of info text
                infoText.Content = "Deleted user from Members"; // info text message
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
                infoText.Content = "No such as this user"; // info text message
                if (!_isTimerRunning) // Statement for thread. If the thread is running, it will not run again.
                {
                    DispatcherTimer timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(2);
                    timer.Tick += Timer_Tick; // listening for event
                    timer.Start();
                    _isTimerRunning = true;
                }
            }
            var item = (sender as FrameworkElement).DataContext;
            membersDataGrid.Items.Remove(item);
            //DBConnection.ListAllUsers(membersDataGrid);

        }

        private void Timer_Tick(object sender, EventArgs e) // For timer
        {
            infoText.Visibility = Visibility.Collapsed;
            (sender as DispatcherTimer).Stop();
            _isTimerRunning = false;
        }

        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            //// Excel paketi oluştur
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //ExcelPackage package = new ExcelPackage();
            //// Çalışma sayfası oluştur
            //ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
            //// Datagrid verilerini çalışma sayfasına kopyala
            //for (int i = 0; i < membersDataGrid.Columns.Count; i++)
            //{
            //    worksheet.Cells[1, i + 1].Value = membersDataGrid.Columns[i].Header;
            //}
            //for (int i = 0; i < membersDataGrid.Items.Count; i++)
            //{
            //    for (int j = 0; j < membersDataGrid.Columns.Count; j++)
            //    {
            //        var cell = membersDataGrid.Columns[j].GetCellContent(membersDataGrid.Items[i]);
            //        if (cell is TextBlock textBlock)
            //        {
            //            worksheet.Cells[i + 2, j + 1].Value = textBlock.Text;
            //        }
            //        else if (cell is System.Windows.Controls.CheckBox checkBox)
            //        {
            //            worksheet.Cells[i + 2, j + 1].Value = checkBox.IsChecked;
            //        }
            //        // Diğer kontrol türleri için de benzer şekilde yazabilirsiniz
            //    }
            //}
            //// Paketi bir dosya akışına yaz
            //MemoryStream stream = new MemoryStream();
            //package.SaveAs(stream);
            //// Dosya akışını indirmek için bir SaveFileDialog kullan
            //SaveFileDialog saveDialog = new SaveFileDialog();
            //saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            //saveDialog.FileName = "datagrid.xlsx";
            //if (saveDialog.ShowDialog() == true)
            //{
            //    stream.Position = 0;
            //    using (FileStream fileStream = File.Create(saveDialog.FileName))
            //    {
            //        stream.CopyTo(fileStream);
            //    }
            //}

            string filePath = "";
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (dialog.ShowDialog() == true)
            {
                filePath = dialog.FileName;
            }
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Link is not valid");
                return;
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ObservableCollection<Member> members = new ObservableCollection<Member>();
            members = (ObservableCollection<Member>)membersDataGrid.ItemsSource;
            DataTable dt = members.ToDataTable();
            using (ExcelPackage pck = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Data");
                ws.Cells["A1"].LoadFromDataTable(dt, true);
                pck.Save();
            }






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
    public static class Test
    {
        public static DataTable ToDataTable<T>(this ObservableCollection<T> collection)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                dt.Columns.Add(prop.Name, prop.PropertyType);
            }
            foreach (var item in collection)
            {
                DataRow row = dt.NewRow();
                foreach (var prop in props)
                {
                    row[prop.Name] = prop.GetValue(item, null);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
    } }
