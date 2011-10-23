using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;

namespace Ufiles.Email
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            
        }

        private void btnSendFiles_Click(object sender, RibbonControlEventArgs e)
        {
            var messageWindow = Globals.ThisAddIn.Application.ActiveInspector().CurrentItem as MailItem;
            
            var form1 = new FilesForm();
            var result = form1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                messageWindow.HTMLBody += "<p>The file adding was successful</p>";
                messageWindow.Body += "The file adding was successful";
            }
            else
            {
                MessageBox.Show("Failed to add the files, try again.", "Failure", MessageBoxButtons.OK);
            }
        }
    }
}
