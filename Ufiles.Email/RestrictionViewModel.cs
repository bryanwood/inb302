using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using UFiles.Email.UFilesService;
using UFiles.Domain.Entities;

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
            TimeRanges = new ObservableCollection<TimeRange>();
            IPs = new ObservableCollection<string>();
            endDateToAdd = DateTime.Now;
            startDateToAdd = DateTime.Now.AddMinutes(5);
        }

        public ObservableCollection<Group> PossibleGroups
        {
            get
            {
                return handler.Groups;
            }
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

        private TimeRange selectedTimeRange;
        public TimeRange SelectedTimeRange
        {
            get
            {
                return selectedTimeRange;
            }
            set
            {
                if (value != selectedTimeRange)
                {
                    selectedTimeRange = value;
                    NotifyPropertyChanged("SelectedTimeRange");
                }
            }
        }

        private Group selectedGroup;
        public Group SelectedGroup
        {
            get
            {
                return selectedGroup;
            }
            set
            {
                if (value != selectedGroup)
                {
                    selectedGroup = value;
                    NotifyPropertyChanged("SelectedGroup");
                }
            }
        }

        private string selectedIP;
        public string SelectedIP
        {
            get
            {
                return selectedIP;
            }
            set
            {
                if (value != selectedIP)
                {
                    selectedIP = value;
                    NotifyPropertyChanged("SelectedIP");
                }
            }
        }

        private string iPToAdd;
        public string IPToAdd
        {
            get
            {
                return iPToAdd;
            }
            set
            {
                if (value != iPToAdd)
                {
                    iPToAdd = value;
                    NotifyPropertyChanged("IPToAdd");
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
        public ObservableCollection<TimeRange> TimeRanges { get; private set; }
        public ObservableCollection<string> IPs { get; private set; }
        public void AddEmail()
        {
            if (!string.IsNullOrWhiteSpace(emailToAdd))
            {
                Emails.Add(emailToAdd);
                EmailToAdd = null;
            }
        }
        public void RemoveEmail()
        {
            if (selectedEmail != null)
            {
                Emails.Remove(SelectedEmail);
                selectedEmail = null;
            }
        }
        public void AddGroup()
        {
            if (!Groups.Contains(groupToAdd))
            {
                Groups.Add(groupToAdd);
            }
        }
        public void RemoveGroup()
        {
            if (selectedGroup != null)
            {
                Groups.Remove(selectedGroup);
                selectedGroup = null;
            }
        }
        public void AddTimeRange()
        {
            TimeRanges.Add(new TimeRange
            {
                End = EndDateToAdd,
                Start = StartDateToAdd
            });
        }
        public void RemoveTimeRange()
        {
            if (selectedTimeRange != null)
            {
                TimeRanges.Remove(selectedTimeRange);
                selectedTimeRange = null;
            }
        }
        public void AddIP()
        {
            IPs.Add(iPToAdd);
            
            IPToAdd = "";
        }
        public void RemoveIP()
        {
            if (selectedIP != null)
            {
                IPs.Remove(selectedIP);
                SelectedIP = null;
            }
        }
        public void Finish()
        {
            handler.CurrentFile.Emails.AddRange(Emails);
            handler.CurrentFile.Groups.AddRange(Groups.Select(x=>x.GroupId));
            handler.CurrentFile.TimeRanges.AddRange(TimeRanges);
            handler.CurrentFile.IPs.AddRange(IPs);
            if (Finished != null)
            {
                Finished();
            }
        }
        public delegate void FinishEvent();
        public event FinishEvent Finished;


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
