using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace UFiles.Email
{
    public class FileBrowseViewModel : INotifyPropertyChanged
    {
        public string FileName { get; private set; }

        public void BrowseForFile()
        {
            OpenFileDialog filePicker = new OpenFileDialog();
            filePicker.ShowDialog();
            FileName = filePicker.SafeFileName;
            NotifyPropertyChanged("FileName");
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
