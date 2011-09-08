namespace UFiles.Outlook
{
    partial class ComposeRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ComposeRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uFile = this.Factory.CreateRibbonTab();
            this.manageuFile = this.Factory.CreateRibbonGroup();
            this.upload = this.Factory.CreateRibbonButton();
            this.addLink = this.Factory.CreateRibbonButton();
            this.manageAccount = this.Factory.CreateRibbonGroup();
            this.userStatus = this.Factory.CreateRibbonLabel();
            this.changeUser = this.Factory.CreateRibbonButton();
            this.signOut = this.Factory.CreateRibbonButton();
            this.serverIP = this.Factory.CreateRibbonEditBox();
            this.uploaduFile = new System.Windows.Forms.OpenFileDialog();
            this.signIn = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.box1 = this.Factory.CreateRibbonBox();
            this.userName = this.Factory.CreateRibbonLabel();
            this.userNameOutput = this.Factory.CreateRibbonLabel();
            this.uFile.SuspendLayout();
            this.manageuFile.SuspendLayout();
            this.manageAccount.SuspendLayout();
            this.box1.SuspendLayout();
            // 
            // uFile
            // 
            this.uFile.Groups.Add(this.manageuFile);
            this.uFile.Groups.Add(this.manageAccount);
            this.uFile.Label = "uFile";
            this.uFile.Name = "uFile";
            // 
            // manageuFile
            // 
            this.manageuFile.Items.Add(this.upload);
            this.manageuFile.Items.Add(this.addLink);
            this.manageuFile.Label = "Manage uFiles";
            this.manageuFile.Name = "manageuFile";
            // 
            // upload
            // 
            this.upload.Label = "Create a uFile";
            this.upload.Name = "upload";
            this.upload.ScreenTip = "Choose a file to upload to the uFile server";
            // 
            // addLink
            // 
            this.addLink.Label = "Insert a uFile Link";
            this.addLink.Name = "addLink";
            this.addLink.ScreenTip = "Insert a link to an existing file";
            // 
            // manageAccount
            // 
            this.manageAccount.Items.Add(this.changeUser);
            this.manageAccount.Items.Add(this.signOut);
            this.manageAccount.Items.Add(this.signIn);
            this.manageAccount.Items.Add(this.separator1);
            this.manageAccount.Items.Add(this.serverIP);
            this.manageAccount.Items.Add(this.box1);
            this.manageAccount.Items.Add(this.userStatus);
            this.manageAccount.Label = "Manage Account";
            this.manageAccount.Name = "manageAccount";
            // 
            // userStatus
            // 
            this.userStatus.Label = "Guest Account";
            this.userStatus.Name = "userStatus";
            this.userStatus.ScreenTip = "What type of account you are currently using";
            // 
            // changeUser
            // 
            this.changeUser.Label = "Change User";
            this.changeUser.Name = "changeUser";
            this.changeUser.ScreenTip = "Change the user currently logged into uFile";
            // 
            // signOut
            // 
            this.signOut.Label = "Sign Out";
            this.signOut.Name = "signOut";
            this.signOut.ScreenTip = "Sign Out";
            // 
            // serverIP
            // 
            this.serverIP.Label = "Server IP:";
            this.serverIP.Name = "serverIP";
            this.serverIP.ScreenTip = "Designate the IP/URL of the uFile server";
            this.serverIP.Text = null;
            // 
            // uploaduFile
            // 
            this.uploaduFile.Title = "Upload uFile";
            // 
            // signIn
            // 
            this.signIn.Label = "Sign In";
            this.signIn.Name = "signIn";
            this.signIn.ScreenTip = "Sign In";
            this.signIn.Visible = false;
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // box1
            // 
            this.box1.Items.Add(this.userName);
            this.box1.Items.Add(this.userNameOutput);
            this.box1.Name = "box1";
            // 
            // userName
            // 
            this.userName.Label = "UserName:";
            this.userName.Name = "userName";
            // 
            // userNameOutput
            // 
            this.userNameOutput.Label = "email@email.com";
            this.userNameOutput.Name = "userNameOutput";
            this.userNameOutput.ScreenTip = "Username";
            // 
            // ComposeRibbon
            // 
            this.Name = "ComposeRibbon";
            this.RibbonType = "Microsoft.Outlook.Mail.Compose";
            this.Tabs.Add(this.uFile);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.ComposeRibbon_Load);
            this.uFile.ResumeLayout(false);
            this.uFile.PerformLayout();
            this.manageuFile.ResumeLayout(false);
            this.manageuFile.PerformLayout();
            this.manageAccount.ResumeLayout(false);
            this.manageAccount.PerformLayout();
            this.box1.ResumeLayout(false);
            this.box1.PerformLayout();

        }

        #endregion

        private Microsoft.Office.Tools.Ribbon.RibbonTab uFile;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup manageuFile;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton upload;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton addLink;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup manageAccount;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel userStatus;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton signOut;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox serverIP;
        private System.Windows.Forms.OpenFileDialog uploaduFile;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton changeUser;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton signIn;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box1;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel userName;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel userNameOutput;
    }

    partial class ThisRibbonCollection
    {
        internal ComposeRibbon ComposeRibbon
        {
            get { return this.GetRibbon<ComposeRibbon>(); }
        }
    }
}
