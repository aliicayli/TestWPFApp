using Microsoft.Win32;
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
using Aspose.Cells.GridDesktop;

namespace TestWPFApp
{
    /// <summary>
    /// test.xaml etkileşim mantığı
    /// </summary>
    public partial class test : Window
    {

        public string path;
        public test()
        {
            InitializeComponent();
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            grid.ImportExcelFile(path);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Excel dosyasını kaydetmek istiyor musunuz?", "Kaydet", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            // Dialogdan dönen sonuca göre işlem yapın
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // Evet seçilirse, dosya seçici dialog oluşturun
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog.Title = "Excel dosyasını kaydet";

                    // Dialogu gösterin ve seçilen dosya adını alın
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        grid.ExportExcelFile(saveFileDialog.FileName);
                    }
                    break;
                case MessageBoxResult.No:
                    break;
                ;
            }
        }
    }
}
