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

namespace UFiles.Email
{
    public class UFilesHandler : INotifyPropertyChanged
    {
        public int UserId{get;set;}

        private UFileServiceClient client;

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
            UserId = 2; //For Debugging, skips login
            client = new UFileServiceClient();
            Files = new ObservableCollection<UploadFile>();
            
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
                Emails = new List<string>()
            };
            this.Files.Add(file);
            this.CurrentFile = file;
            var rw = new RestrictionWindow(this);
            rw.ShowDialog();
        }
        void UploadFiles()
        {
            var transmittalId = client.NewTransmittal(UserId);   
            foreach(var file in Files){
                var fileInfo = new FileInfo(file.FilePath);
                var buffer = new byte[fileInfo.Length];
                var handler = fileInfo.OpenRead();
                handler.Read(buffer, 0, (int)fileInfo.Length);
                var fileId = client.AddFile(UserId, transmittalId, file.FileName, file.ContentType, buffer);
                if(file.Emails.Count > 0)
                    client.AddUserRestriction(fileId, file.Emails.ToArray());
                client.SendTransmittal(transmittalId);
            }
            List<string> emails = new List<string>();
            ThisAddIn.MailItem.Save();
            foreach(Recipient r in ThisAddIn.MailItem.Recipients){
                emails.Add(r.Address);
            }
            client.AddRecipients(transmittalId, emails.ToArray());
            client.SendTransmittal(transmittalId);
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
