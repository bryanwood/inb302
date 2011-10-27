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
    public partial class LoginWindow : Window
    {
        private LoginViewModel ViewModel;
        public LoginWindow()
        {
            InitializeComponent();
            this.ViewModel = new LoginViewModel();
            ViewModel.LoginComplete += new LoginViewModel.LoginCompleteHandler(ViewModel_LoginComplete);
            DataContext = ViewModel;
        }

        void ViewModel_LoginComplete()
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Password = passwordBox1.Password;
            ViewModel.Login();
        }
    }
}
