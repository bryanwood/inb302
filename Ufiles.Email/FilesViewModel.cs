using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using UFiles.Email.UFilesService;
using System.ComponentModel;
using Microsoft.Office.Interop.Outlook;
namespace UFiles.Email
{
    public class FilesViewModel : INotifyPropertyChanged
    {
        private UFilesHandler handler;
        public FilesViewModel(UFilesHandler handler)
        {
            this.handler = handler;
        }

        private UploadFile selectedFile;
        public UploadFile SelectedFile
        {
            get
            {
                return selectedFile;
            }
            set
            {
                if (value != selectedFile)
                {
                    selectedFile = value;
                    NotifyPropertyChanged("SelectedFile");
                }
            }
        }
        public ObservableCollection<UploadFile> Files
        {
            get
            {
                return handler.Files;
            }
        }
        public void AddFileClicked()
        {
            
            if (AddFileClick != null)
            {
                AddFileClick();
            }
        }


        public void UploadFileClicked()
        {
            if (UploadFileClick != null)
            {
                UploadFileClick();
            }
        }

        public void RemoveFile()
        {
            if (SelectedFile != null)
            {
                var file = SelectedFile;
                SelectedFile = null;
                Files.Remove(file);
            }
        }

        public delegate void UploadFileClickHandler();
        public event UploadFileClickHandler UploadFileClick;

        public delegate void AddFileClickHandler();
        public event AddFileClickHandler AddFileClick;

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }

}
