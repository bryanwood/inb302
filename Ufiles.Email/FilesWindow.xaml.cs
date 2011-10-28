using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UFiles.Email
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FilesWindow : Window
    {
        public FilesViewModel ViewModel;
        

        public FilesWindow(UFilesHandler handler)
        {
            InitializeComponent();
            
            ViewModel = new FilesViewModel(handler);
            DataContext = ViewModel;
            
        }

        private void btnUploadFiles_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.UploadFileClicked();
        }

        private void btnAddFile_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddFileClicked();
        }

        private void btnRemoveFile_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveFile();
        }
    }
}
