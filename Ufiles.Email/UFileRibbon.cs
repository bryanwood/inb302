using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;
using System.Windows;

namespace UFiles.Email
{
    public partial class UFileRibbon
    {
        private void UFileRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            
        }

        private void btnSendFiles_Click(object sender, RibbonControlEventArgs e)
        {

          //  FilesModel.Current.FileUploadComplete += new FilesModel.FileUploadCompleteHandler(Current_FileUploadComplete);
            //FilesModel.Current.Start();
            var handler = new UFilesHandler();
            handler.Start();

        }

      
    }
}
