using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace UFiles.Email
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private UFilesService.UFileServiceClient client;
        public LoginViewModel()
        {
            this.client = ClientSingleton.Client;
        }
        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (value != username)
                {
                    username = value;
                    NotifyPropertyChanged("Username");
                }
            }
        }
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (value != password)
                {
                    password = value;
                    NotifyPropertyChanged("Password");
                }
            }
        }
        public void Login()
        {
            if (username != null && password != null)
            {
                client.Login(username, password);
                LoginComplete();
                return;
            }
            throw new InvalidOperationException();
        }
        public delegate void LoginCompleteHandler();
        public event LoginCompleteHandler LoginComplete;
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
