using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;
using System.Windows;

namespace Ufiles.Email
{
    public partial class UFileRibbon
    {
        private void UFileRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            
        }

        private void btnSendFiles_Click(object sender, RibbonControlEventArgs e)
        {
            
           UFiles.Current.FileUploadComplete += new UFiles.FileUploadCompleteHandler(Current_FileUploadComplete);
           UFiles.Current.Start();


        }

        void Current_FileUploadComplete(UFiles.FileUploadCompleteArgs args)
        {
            var messageWindow = Globals.ThisAddIn.Application.ActiveInspector().CurrentItem as MailItem;
            messageWindow.HTMLBody += string.Format("Files are located here: http://localhost:58348/Transmittal/View/{0}", args.TransmittalId);
        }
    }
}
