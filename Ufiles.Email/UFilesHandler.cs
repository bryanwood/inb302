using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using UFiles.Email.UFilesService;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Outlook;
using System.ComponentModel;
using UFiles.Domain.Entities;

namespace UFiles.Email
{
    public class UFilesHandler : INotifyPropertyChanged
    {
        public int UserId{get;set;}

        private UFileServiceClient client;

        private BackgroundWorker worker;

        private LoginWindow loginWindow;
        private FilesWindow fileWindow;

        private UploadFile currentFile;
        public UploadFile CurrentFile
        {

            get
            {
                return currentFile;
            }
            set
            {
                if (value != currentFile)
                {
                    currentFile = value;
                    NotifyPropertyChanged("CurrentFile");
                }
            }
        }

        public ObservableCollection<UploadFile> Files { get; private set; }
        private ObservableCollection<Group> groups;
        public ObservableCollection<Group> Groups
        {
            get
            {
                if (groups == null)
                {
                    groups = new ObservableCollection<Group>(client.GetGroups(UserId));
                }
                return groups;
            }
        }

        

        public UFilesHandler()
        {
            //UserId = 2; //For Debugging, skips login
            client = new UFileServiceClient();
            Files = new ObservableCollection<UploadFile>();
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
           
            var transmittalId = client.NewTransmittal(UserId);
           
            int total = Files.Count;
            int progress = 0;
            worker.ReportProgress(0);
            foreach (var file in Files)
            {
                var fileInfo = new FileInfo(file.FilePath);
                var buffer = new byte[fileInfo.Length];
                var handler = fileInfo.OpenRead();
                handler.Read(buffer, 0, (int)fileInfo.Length);
                var fileId = client.AddFile(UserId, transmittalId, file.FileName, file.ContentType, buffer);
                if (file.Emails.Count > 0)
                    client.AddUserRestriction(fileId, file.Emails.ToArray());
                if (file.Groups.Count > 0)
                    client.AddGroupRestriction(fileId, file.Groups.ToArray());
                if (file.TimeRanges.Count > 0)
                    client.AddTimeRangeRestriction(fileId, file.TimeRanges.ToArray());
                if (file.IPs.Count > 0)
                    client.AddIPRestriction(fileId, file.IPs.ToArray());
                progress++;
                worker.ReportProgress((int)(((double)progress / (double)total)*100));
            }
            List<string> emails = new List<string>();
            ThisAddIn.MailItem.Save();
            foreach (Recipient r in ThisAddIn.MailItem.Recipients)
            {
                emails.Add(r.Address);
            }
            client.AddRecipients(transmittalId, emails.ToArray());
            client.SendTransmittal(transmittalId);
            e.Result = transmittalId;
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Complete((int)e.Result);
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            fileWindow.ViewModel.Progress = e.ProgressPercentage;
        }
        public void Complete(int transmittalId)
        {
            ThisAddIn.MailItem.Body += string.Format("\r\nFiles are available here: http://ufiles.bryanwood.com.au/transmittal/view/{0}", transmittalId);
            fileWindow.Close();
        }
        public void Start()
        {
            ThisAddIn.MailItem.Save();
            if (UserId == 0)
            {
                loginWindow = new LoginWindow();
                
                loginWindow.ShowDialog();
            }
            fileWindow = new FilesWindow(this);
            fileWindow.ViewModel.AddFileClick += new FilesViewModel.AddFileClickHandler(ViewModel_AddFileClick);
            fileWindow.ViewModel.UploadFileClick += new FilesViewModel.UploadFileClickHandler(ViewModel_UploadFileClick);
            fileWindow.ShowDialog();

        }

        void ViewModel_UploadFileClick()
        {
            UploadFiles();
        }

        void ViewModel_AddFileClick()
        {

            //Browse for file
            var openFileDialog = new OpenFileDialog();
            openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialog_FileOk);
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;
            openFileDialog.ShowDialog();
           
        }

        void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var openFileDialog = sender as OpenFileDialog;
            var fileInfo = new FileInfo(openFileDialog.FileName);
            var file = new UploadFile
            {
                ContentType = "application/octet-stream",
                FileName = openFileDialog.SafeFileName,
                FilePath = openFileDialog.FileName,
                FileSize = (int)fileInfo.Length,
                Groups = new List<int>(),
                Emails = new List<string>(),
                TimeRanges = new List<TimeRange>(),
                IPs = new List<string>()
            };
            this.Files.Add(file);
            this.CurrentFile = file;
            var rw = new RestrictionWindow(this);
            rw.ShowDialog();
        }
        void UploadFiles()
        {
            fileWindow.ViewModel.UploadReady = false;
            worker.RunWorkerAsync();
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
