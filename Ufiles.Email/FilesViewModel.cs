using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using UFiles.Email.UFilesService;
namespace UFiles.Email
{
    public class FilesViewModel
    {
        private UFilesHandler handler;
        public FilesViewModel(UFilesHandler handler)
        {
            this.handler = handler;
        }
        public ObservableCollection<File> Files
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

        public delegate void UploadFileClickHandler();
        public event UploadFileClickHandler UploadFileClick;

        public delegate void AddFileClickHandler();
        public event AddFileClickHandler AddFileClick;
    }

}
