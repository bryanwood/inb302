using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using UFiles.Email.UFilesService;

namespace UFiles.Email
{
    public class UFilesHandler
    {
        public int UserId{get;set;}

        private LoginWindow loginWindow;
        private FilesWindow fileWindow;
        private FileBrowseWindow fileBrowseWindow;

        public ObservableCollection<File> Files { get; private set; }

        public UFilesHandler()
        {
            UserId = 2;
            Files = new ObservableCollection<File>();
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
            //Start uploading files
            throw new NotImplementedException();
        }

        void ViewModel_AddFileClick()
        {
            fileBrowseWindow = new FileBrowseWindow();
            fileBrowseWindow.ShowDialog();
            //show add file dialog

            throw new NotImplementedException();
        }
    }
}
