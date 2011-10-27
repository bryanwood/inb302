using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using UFiles.Email.UFilesService;
using System.Windows.Forms;
using System.IO;

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
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;
            openFileDialog.ShowDialog();
            var fileInfo = new FileInfo(openFileDialog.FileName);
            this.Files.Add(new UploadFile
            {
                ContentType = "application/octet-stream",
                FileName = openFileDialog.SafeFileName,
                FilePath = openFileDialog.FileName,
                FileSize = (int)fileInfo.Length
            });
            //show Restriction dialog

            
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
        }
    }
}
