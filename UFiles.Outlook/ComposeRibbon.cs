using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace UFiles.Outlook
{
    public partial class ComposeRibbon
    {
        private void ComposeRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            this.upload.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.upload_Click);
            this.signOut.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.signOut_Click);
            this.signIn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.signIn_Click);

        }//Called when the ribbon is loaded

        #region Event Handlers

        private void upload_Click(object sender, RibbonControlEventArgs e)
        {
            this.uploaduFile.ShowDialog();

        }//called when the uFile upload button is clicked
        void signOut_Click(object sender, RibbonControlEventArgs e)
        {
            this.signOut.Visible = false;
            this.signIn.Visible = true;
            this.userNameOutput.Label = "";
            this.userStatus.Label = "Not Signed In";
        }//called when the sign out button is clicked

        void signIn_Click(object sender, RibbonControlEventArgs e)
        {
            this.signIn.Visible = false;
            this.signOut.Visible = true;
            this.userNameOutput.Label = "email@email.com";
            this.userStatus.Label = "Guest Account";
        }//called when the sign in button is clicked

        #endregion




    }
}
