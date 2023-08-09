using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
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
using Aspose.Cells;

namespace TestWPFApp
{
    /// <summary>
    /// MembersUserControl.xaml etkileşim mantığı
    /// </summary>
    public partial class LibraryUserControl : UserControl
    {
        public string[] comboboxLibraryContex { get; set; }
        private bool _isTimerRunning = false; // bool variable for thread

        public LibraryUserControl()
        {
            InitializeComponent();
            comboboxLibraryContex = new string[] { "Table", "Chair", "Cupboard" };
            DataContext = this;
            //DBConnection.ListAllLibraryDatas(librariesDataGrid,txtDatabaseName.Text);
        }

        #region Functions for db 
        private void membersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (membersDataGrid.SelectedItem != null)
            //{
            //    Member member = membersDataGrid.SelectedItem as Member;
            //    txtName.Text = member.UserName;
            //    txtMail.Text = member.Email;
            //    txtPhoneNumber.Text = member.PhoneNumber;
            //    password = member.Password;
            //}

        }



        private void btnSetAdmin_Click(object sender, RoutedEventArgs e)
        {
            //if (password == null)
            //{
            //    return;
            //}
            //if (txtMail.Text.Length == 0 || password.Length == 0 || txtMail.Text.Length == 0 || txtPhoneNumber.Text.Length == 0)
            //{
            //    infoText.Visibility = Visibility.Visible; // opening visibility of info text
            //    infoText.Content = "Fill all required fields"; // info text message
            //    if (!_isTimerRunning) // Statement for thread. If the thread is running, it will not run again.
            //    {
            //        DispatcherTimer timer = new DispatcherTimer();
            //        timer.Interval = TimeSpan.FromSeconds(2);
            //        timer.Tick += Timer_Tick; // listening for event
            //        timer.Start();
            //        _isTimerRunning = true;
            //    }
            //    return;
            //}
            //if (DBConnection.AddNewAdmin(txtName.Text, password, txtMail.Text, txtPhoneNumber.Text))
            //{
            //    infoText.Visibility = Visibility.Visible; // opening visibility of info text
            //    infoText.Content = "User is now admin"; // info text message
            //    if (!_isTimerRunning) // Statement for thread. If the thread is running, it will not run again.
            //    {
            //        DispatcherTimer timer = new DispatcherTimer();
            //        timer.Interval = TimeSpan.FromSeconds(2);
            //        timer.Tick += Timer_Tick; // listening for event
            //        timer.Start();
            //        _isTimerRunning = true;
            //    }
            //}
            //else
            //{
            //    infoText.Visibility = Visibility.Visible; // opening visibility of info text
            //    infoText.Content = "User is already admin"; // info text message
            //    if (!_isTimerRunning) // Statement for thread. If the thread is running, it will not run again.
            //    {
            //        DispatcherTimer timer = new DispatcherTimer();
            //        timer.Interval = TimeSpan.FromSeconds(2);
            //        timer.Tick += Timer_Tick; // listening for event
            //        timer.Start();
            //        _isTimerRunning = true;
            //    }
            //}
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //    DBConnection.UpdateUser(txtName.Text, password, txtMail.Text, txtPhoneNumber.Text);
            //    DBConnection.ListAllUsers(membersDataGrid);
            //    infoText.Visibility = Visibility.Visible; // opening visibility of info text
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //if (password == null)
            //{
            //    return;
            //}
            //if (txtMail.Text.Length == 0 || password.Length == 0 || txtMail.Text.Length == 0 || txtPhoneNumber.Text.Length == 0)
            //{
            //    infoText.Visibility = Visibility.Visible; // opening visibility of info text
            //    infoText.Content = "Fill all required fields"; // info text message
            //    if (!_isTimerRunning) // Statement for thread. If the thread is running, it will not run again.
            //    {
            //        DispatcherTimer timer = new DispatcherTimer();
            //        timer.Interval = TimeSpan.FromSeconds(2);
            //        timer.Tick += Timer_Tick; // listening for event
            //        timer.Start();
            //        _isTimerRunning = true;
            //    }
            //    return;
            //}

            //if (DBConnection.DeleteUser(txtName.Text))
            //{
            //    infoText.Visibility = Visibility.Visible; // opening visibility of info text
            //    infoText.Content = "Deleted user from Members"; // info text message
            //    if (!_isTimerRunning) // Statement for thread. If the thread is running, it will not run again.
            //    {
            //        DispatcherTimer timer = new DispatcherTimer();
            //        timer.Interval = TimeSpan.FromSeconds(2);
            //        timer.Tick += Timer_Tick; // listening for event
            //        timer.Start();
            //        _isTimerRunning = true;
            //    }
            //}
            //else
            //{
            //    infoText.Visibility = Visibility.Visible; // opening visibility of info text
            //    infoText.Content = "No such as this user"; // info text message
            //    if (!_isTimerRunning) // Statement for thread. If the thread is running, it will not run again.
            //    {
            //        DispatcherTimer timer = new DispatcherTimer();
            //        timer.Interval = TimeSpan.FromSeconds(2);
            //        timer.Tick += Timer_Tick; // listening for event
            //        timer.Start();
            //        _isTimerRunning = true;
            //    }
            //}
            ////var item = (sender as FrameworkElement).DataContext;
            ////membersDataGrid.Items.Remove(item);
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

            //string filePath = "";
            //SaveFileDialog dialog = new SaveFileDialog();
            //dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
            //dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //if (dialog.ShowDialog() == true)
            //{
            //    filePath = dialog.FileName;
            //}
            //if (string.IsNullOrEmpty(filePath))
            //{
            //    MessageBox.Show("Link is not valid");
            //    return;
            //}
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //ObservableCollection<Member> members = new ObservableCollection<Member>();
            //members = (ObservableCollection<Member>)membersDataGrid.ItemsSource;
            //DataTable dt = members.ConvertDataTable();
            //using (ExcelPackage pck = new ExcelPackage(new FileInfo(filePath)))
            //{
            //    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Data");
            //    ws.Cells["A1"].LoadFromDataTable(dt, true);
            //    pck.Save();
            //}






        }

        private void btnOpenExcelLibreOffice_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //// Sadece excel dosyalarını göster
            //openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            //// İletişim kutusunu göster ve sonucu al
            //bool? result = openFileDialog.ShowDialog();
            //// Eğer kullanıcı bir dosya seçtiyse
            //if (result == true)
            //{
            //    // Seçilen dosyanın yolunu al
            //    string filePath = openFileDialog.FileName;
            //    try
            //    {
            //        // Kayıt defterinden libreoffice programının pathini al
            //        //string libreOfficePath = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\LibreOffice\UNO\InstallPath", "", null) as string;
            //        string libreOfficePath = "C:\\Program Files\\LibreOffice\\program\\soffice.exe";


            //        // string libreOfficePath = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\LibreOffice\UNO\InstallPath", "", null) as string;
            //        // Pathi soffice.exe ile birleştir
            //        //libreOfficePath = Path.Combine(libreOfficePath, "soffice.exe");
            //        // Libreoffice programını ve seçilen dosyayı parametre olarak vererek çalıştır
            //        Process.Start(libreOfficePath, filePath);
            //    }
            //    catch (System.ComponentModel.Win32Exception ex)
            //    {
            //        // Hata mesajını göster
            //        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //}






            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //// Sadece excel dosyalarını göster
            //openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            //// İletişim kutusunu göster ve sonucu al
            //bool? result = openFileDialog.ShowDialog();
            //// Eğer kullanıcı bir dosya seçtiyse
            //if (result == true)
            //{
            //    // Seçilen dosyanın yolunu al
            //    string filePath = openFileDialog.FileName;
            //    try
            //    {
            //        test test = new test();
            //        test.path = filePath;
            //        test.Show();
            //    }
            //    catch (System.ComponentModel.Win32Exception ex)
            //    {
            //        // Hata mesajını göster
            //        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //}




        }


        public void Save()
        {
            test a = new test();
            // Excel dosyasını kaydetmek isteyip istemediğinizi soran bir dialog oluşturun

        }
        #endregion
        private void btnAddData_Click(object sender, RoutedEventArgs e)
        {

            if (txtProductName.Text.Length == 0 || txtPrice.Text.Length == 0 || txtColor.Text.Length == 0)
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

            if (comboBoxLibraryData.SelectedItem == null)
            {
                infoText.Visibility = Visibility.Visible; // opening visibility of info text
                infoText.Content = "Plase Select a category"; // info text message
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

            if (comboBoxLibraryData.SelectedItem.ToString() == "Table")
            {
                DBConnection.AddNewLibraryData("TablesForLibrary", txtProductName.Text, txtPrice.Text, txtColor.Text, txtDatabaseName.Text);
            }
            else if (comboBoxLibraryData.SelectedItem.ToString() == "Chair")
            {
                DBConnection.AddNewLibraryData("ChairsForLibrary", txtProductName.Text, txtPrice.Text, txtColor.Text, txtDatabaseName.Text);
            }
            if (comboBoxLibraryData.SelectedItem.ToString() == "Cupboard")
            {
                DBConnection.AddNewLibraryData("CupBoardsForLibrary", txtProductName.Text, txtPrice.Text, txtColor.Text, txtDatabaseName.Text);
            }


            DBConnection.ListAllLibraryDatas(librariesDataGrid, txtDatabaseName.Text);

        }

        private void comboBoxLibraryData_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void txtDatabaseName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnNewatabase_Click(object sender, RoutedEventArgs e)
        {
            DBConnection.NewDatabase(txtDatabaseName.Text);
        }

        private void btnCopyDatabase_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxTables_Copy.SelectedItem.ToString().Length == 0 || comboBoxTables_Copy.SelectedItem.ToString() == "All")
            {
                if (DBConnection.CopyDataBase(comboBoxDatabases.SelectedValue.ToString(), comboBoxDatabasesForCopied_Copy.SelectedValue.ToString().Remove(comboBoxDatabasesForCopied_Copy.SelectedValue.ToString().Length-3)))
                {
                    infoText.Visibility = Visibility.Visible; // opening visibility of info text
                    infoText.Content = "Copied"; // info text message
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
                else
                {

                    infoText.Visibility = Visibility.Visible; // opening visibility of info text
                    infoText.Content = "Not copied"; // info text message
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
            }
            else
            {
                DBConnection.CopyTable(comboBoxDatabases.SelectedValue.ToString(), comboBoxDatabasesForCopied_Copy.SelectedValue.ToString().Remove(comboBoxDatabasesForCopied_Copy.SelectedValue.ToString().Length - 3), comboBoxTables_Copy.SelectedValue.ToString());

            }



        }



        private void btnGetDataBaseForList_Click(object sender, RoutedEventArgs e)
        {
           // DBConnection.ListDataForNewStates(librariesDataGrid, txtDataBaseNameForList.Text);
            DBConnection.ListDataForNewStates(librariesDataGrid, comboBoxDatabasesForList_Copy.SelectedValue.ToString().Remove(comboBoxDatabasesForList_Copy.SelectedValue.ToString().Length -3));

        }



        private void comboBoxDatabases_DropDownOpened(object sender, EventArgs e)
        {
            string[] files = System.IO.Directory.GetFiles(@"C:\Users\Ali\Desktop\Databases", "*.db");
            List<string> fileNames = new List<string>();
            foreach (string file in files)
            {
                fileNames.Add(System.IO.Path.GetFileName(file));
            }
            comboBoxDatabases.ItemsSource = fileNames;
        }

        private void btnCopyTable_Click(object sender, RoutedEventArgs e)
        {

        }

        private void comboBoxTables_DropDownOpened(object sender, EventArgs e)
        {
            if (comboBoxDatabases.SelectedItem  !=null)
            {
                DBConnection.GetTables(comboBoxDatabases.SelectedItem.ToString(), comboBoxTables_Copy);

            }
        }

        private void checkboxData_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("test");
            
            
            
        }

        private void comboBoxDatabasesForList(object sender, EventArgs e)
        {

            string[] files = System.IO.Directory.GetFiles(@"C:\Users\Ali\Desktop\Databases", "*.db");
            List<string> fileNames = new List<string>();
            foreach (string file in files)
            {
                fileNames.Add(System.IO.Path.GetFileName(file));
            }
            comboBoxDatabasesForList_Copy.ItemsSource = fileNames;
        }

        private void comboBoxDatabasesForCopied_CopyDropDownOpened(object sender, EventArgs e)
        {
            string[] files = System.IO.Directory.GetFiles(@"C:\Users\Ali\Desktop\Databases", "*.db");
            List<string> fileNames = new List<string>();
            foreach (string file in files)
            {
                fileNames.Add(System.IO.Path.GetFileName(file));
            }
            comboBoxDatabasesForCopied_Copy.ItemsSource = fileNames;
        }
        ObservableCollection<Library> selectedCustomers = new ObservableCollection<Library>();

        private void checkBoxData_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void checkBoxData_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void librariesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        
            

        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            // Tıklanan checkboxı bulma
            CheckBox cb = sender as CheckBox;

            // Tıklanan checkboxın bağlı olduğu Library nesnesini bulma
            Library item = cb.DataContext as Library;

            // Library nesnesinin checkbox özelliğini güncelleme
            item.Checkbox = cb.IsChecked.Value;
        }

        private void testCopied_Click(object sender, RoutedEventArgs e)
        {
            DBConnection.CopySelectedRows(librariesDataGrid, "test.db", "test2.db", "ChairsForLibrary");
        }
    }

    public class Library
    {
        public string Character { get; set; }
        public Brush BgColor { get; set; }
        public string Color { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Email { get; set; }
        public bool Checkbox { get; set; }


    }

}
