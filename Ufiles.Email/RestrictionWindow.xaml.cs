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
    public partial class RestrictionWindow : Window
    {
        public RestrictionViewModel ViewModel;
        public RestrictionWindow(UFilesHandler handler)
        {
            InitializeComponent();

            ViewModel = new RestrictionViewModel(handler);
            DataContext = ViewModel;
            ViewModel.Finished += new RestrictionViewModel.FinishEvent(ViewModel_Finished);
        }

        void ViewModel_Finished()
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddEmail();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveEmail();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ViewModel.Finish();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ViewModel.AddTimeRange();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveGroup();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveTimeRange();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ViewModel.AddGroup();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            ViewModel.AddIP();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            ViewModel.RemoveIP();
        }



    }
}
