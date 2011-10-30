using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using UFiles.Email.UFilesService;

namespace UFiles.Email
{
    public class RestrictionViewModel : INotifyPropertyChanged
    {
        private UFilesHandler handler;
        public RestrictionViewModel(UFilesHandler handler)
        {
            this.handler = handler;
            Emails = new ObservableCollection<string>();
            Groups = new ObservableCollection<Group>();
        }
        private string selectedEmail;
        public string SelectedEmail
        {
            get
            {
                return selectedEmail;
            }
            set
            {
                if (value != selectedEmail)
                {
                    selectedEmail = value;
                    NotifyPropertyChanged("SelectedEmail");
                }
            }
        }


        private string emailToAdd;
        public string EmailToAdd
        {
            get
            {
                return emailToAdd;
            }
            set
            {
                if (emailToAdd != value)
                {
                    emailToAdd = value;
                    NotifyPropertyChanged("EmailToAdd");
                }
            }
        }

        private Group groupToAdd;
        public Group GroupToAdd
        {
            get
            {
                return groupToAdd;
            }
            set
            {
                if (value != groupToAdd)
                {
                    groupToAdd = value;
                    NotifyPropertyChanged("GroupToAdd");
                }
            }
        }

        private DateTime startDateToAdd;
        public DateTime StartDateToAdd
        {
            get
            {
                return startDateToAdd;
            }
            set
            {
                if (value != startDateToAdd)
                {
                    startDateToAdd = value;
                    NotifyPropertyChanged("StartDateToAdd");
                }
            }
        }

        private DateTime endDateToAdd;
        public DateTime EndDateToAdd
        {
            get
            {
                return endDateToAdd;
            }
            set
            {
                if (value != endDateToAdd)
                {
                    endDateToAdd = value;
                    NotifyPropertyChanged("EndDateToAdd");
                }
            }
        }

        public ObservableCollection<string> Emails { get; private set; }
        public ObservableCollection<Group> Groups { get; private set; }

        public void AddEmail()
        {
            Emails.Add(emailToAdd);
            EmailToAdd = null;
        }
        public void RemoveEmail()
        {
            Emails.Remove(SelectedEmail);
        }
        public void AddGroup()
        {
            if (!Groups.Contains(groupToAdd))
            {
                Groups.Add(groupToAdd);
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
  
    
}
