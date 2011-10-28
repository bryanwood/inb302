using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using UFiles.Email.UFilesService;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Outlook;

namespace UFiles.Email
{
    public class UFilesHandler
    {
        public int UserId{get;set;}

        private UFileServiceClient client;

        private LoginWindow loginWindow;
        private FilesWindow fileWindow;

        public ObservableCollection<UploadFile> Files { get; private set; }

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
            
            
            //show Restriction dialog

            
        }

        void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var openFileDialog = sender as OpenFileDialog;
            var fileInfo = new FileInfo(openFileDialog.FileName);
            this.Files.Add(new UploadFile
            {
                ContentType = "application/octet-stream",
                FileName = openFileDialog.SafeFileName,
                FilePath = openFileDialog.FileName,
                FileSize = (int)fileInfo.Length
            });
        }
        void UploadFiles()
        {
            var transmittalId = client.NewTransmittal(UserId);   
            foreach(var file in Files){
                var fileInfo = new FileInfo(file.FilePath);
                var buffer = new byte[fileInfo.Length];
                var handler = fileInfo.OpenRead();
                handler.Read(buffer, 0, (int)fileInfo.Length);
                client.AddFile(UserId, transmittalId, file.FileName, file.ContentType, buffer);
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
    }
}
