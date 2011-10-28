using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace UFiles.Email
{
    public partial class ThisAddIn
    {
        Outlook.Inspectors inspectors;
        public static Outlook.MailItem MailItem;
        
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            
            inspectors = this.Application.Inspectors;
            inspectors.NewInspector += new Outlook.InspectorsEvents_NewInspectorEventHandler(inspectors_NewInspector);
        }

        void inspectors_NewInspector(Outlook.Inspector Inspector)
        {
            var mailItem = Inspector.CurrentItem as Outlook.MailItem;
            if (mailItem != null)
            {
                MailItem = mailItem;
            }
        }

      
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
