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
            this.deleteButton = this.Factory.CreateRibbonButton();
            this.separator2 = this.Factory.CreateRibbonSeparator();
            this.uFileMenu = this.Factory.CreateRibbonMenu();
            this.manageAccount = this.Factory.CreateRibbonGroup();
            this.changeUser = this.Factory.CreateRibbonButton();
            this.signOutButton = this.Factory.CreateRibbonButton();
            this.signInButton = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.uploaduFile = new System.Windows.Forms.OpenFileDialog();
            this.uFileRestrictions = this.Factory.CreateRibbonTab();
            this.restrictionsGroup = this.Factory.CreateRibbonGroup();
            this.presetDropDown = this.Factory.CreateRibbonDropDown();
            this.savePresetButton = this.Factory.CreateRibbonButton();
            this.deletePresetButton = this.Factory.CreateRibbonButton();
            this.timeRestrictionGroup = this.Factory.CreateRibbonGroup();
            this.otherRestrictionGroup = this.Factory.CreateRibbonGroup();
            this.ipRestrictionComboBox = this.Factory.CreateRibbonComboBox();
            this.locationMenu = this.Factory.CreateRibbonMenu();
            this.groupMenu = this.Factory.CreateRibbonMenu();
            this.box1 = this.Factory.CreateRibbonBox();
            this.serverIP = this.Factory.CreateRibbonEditBox();
            this.serverConnectlabel = this.Factory.CreateRibbonLabel();
            this.box2 = this.Factory.CreateRibbonBox();
            this.userStatus = this.Factory.CreateRibbonLabel();
            this.usernameEditBox = this.Factory.CreateRibbonEditBox();
            this.passwordEditBox = this.Factory.CreateRibbonEditBox();
            this.uFile.SuspendLayout();
            this.manageuFile.SuspendLayout();
            this.manageAccount.SuspendLayout();
            this.uFileRestrictions.SuspendLayout();
            this.restrictionsGroup.SuspendLayout();
            this.otherRestrictionGroup.SuspendLayout();
            this.box1.SuspendLayout();
            this.box2.SuspendLayout();
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
            this.manageuFile.Items.Add(this.deleteButton);
            this.manageuFile.Items.Add(this.separator2);
            this.manageuFile.Items.Add(this.uFileMenu);
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
            this.addLink.Label = "Insert uFile Link";
            this.addLink.Name = "addLink";
            this.addLink.ScreenTip = "Insert a link to an existing file";
            this.addLink.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.addLink_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Label = "Delete File";
            this.deleteButton.Name = "deleteButton";
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            // 
            // uFileMenu
            // 
            this.uFileMenu.Label = "...";
            this.uFileMenu.Name = "uFileMenu";
            // 
            // manageAccount
            // 
            this.manageAccount.Items.Add(this.changeUser);
            this.manageAccount.Items.Add(this.signOutButton);
            this.manageAccount.Items.Add(this.signInButton);
            this.manageAccount.Items.Add(this.separator1);
            this.manageAccount.Items.Add(this.box1);
            this.manageAccount.Items.Add(this.box2);
            this.manageAccount.Items.Add(this.passwordEditBox);
            this.manageAccount.Label = "Manage Account";
            this.manageAccount.Name = "manageAccount";
            // 
            // changeUser
            // 
            this.changeUser.Label = "Change User";
            this.changeUser.Name = "changeUser";
            this.changeUser.ScreenTip = "Change the user currently logged into uFile";
            // 
            // signOutButton
            // 
            this.signOutButton.Label = "Sign Out";
            this.signOutButton.Name = "signOutButton";
            this.signOutButton.ScreenTip = "Sign Out";
            this.signOutButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.signOutButton_Click);
            // 
            // signInButton
            // 
            this.signInButton.Label = "Sign In";
            this.signInButton.Name = "signInButton";
            this.signInButton.ScreenTip = "Sign In";
            this.signInButton.Visible = false;
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // uploaduFile
            // 
            this.uploaduFile.Title = "Upload uFile";
            // 
            // uFileRestrictions
            // 
            this.uFileRestrictions.Groups.Add(this.restrictionsGroup);
            this.uFileRestrictions.Groups.Add(this.timeRestrictionGroup);
            this.uFileRestrictions.Groups.Add(this.otherRestrictionGroup);
            this.uFileRestrictions.Label = "uFile Restrictions";
            this.uFileRestrictions.Name = "uFileRestrictions";
            this.uFileRestrictions.Visible = false;
            // 
            // restrictionsGroup
            // 
            this.restrictionsGroup.Items.Add(this.presetDropDown);
            this.restrictionsGroup.Items.Add(this.savePresetButton);
            this.restrictionsGroup.Items.Add(this.deletePresetButton);
            this.restrictionsGroup.Label = "File Restrictions";
            this.restrictionsGroup.Name = "restrictionsGroup";
            // 
            // presetDropDown
            // 
            this.presetDropDown.Label = "Preset:";
            this.presetDropDown.Name = "presetDropDown";
            // 
            // savePresetButton
            // 
            this.savePresetButton.Label = "Save Preset";
            this.savePresetButton.Name = "savePresetButton";
            // 
            // deletePresetButton
            // 
            this.deletePresetButton.Label = "Delete Preset";
            this.deletePresetButton.Name = "deletePresetButton";
            // 
            // timeRestrictionGroup
            // 
            this.timeRestrictionGroup.Label = "Time Restriction";
            this.timeRestrictionGroup.Name = "timeRestrictionGroup";
            // 
            // otherRestrictionGroup
            // 
            this.otherRestrictionGroup.Items.Add(this.ipRestrictionComboBox);
            this.otherRestrictionGroup.Items.Add(this.locationMenu);
            this.otherRestrictionGroup.Items.Add(this.groupMenu);
            this.otherRestrictionGroup.Label = "Other";
            this.otherRestrictionGroup.Name = "otherRestrictionGroup";
            // 
            // ipRestrictionComboBox
            // 
            this.ipRestrictionComboBox.Label = "IP";
            this.ipRestrictionComboBox.Name = "ipRestrictionComboBox";
            this.ipRestrictionComboBox.Text = null;
            // 
            // locationMenu
            // 
            this.locationMenu.Label = "Location";
            this.locationMenu.Name = "locationMenu";
            // 
            // groupMenu
            // 
            this.groupMenu.Label = "Group";
            this.groupMenu.Name = "groupMenu";
            // 
            // box1
            // 
            this.box1.Items.Add(this.serverIP);
            this.box1.Items.Add(this.serverConnectlabel);
            this.box1.Name = "box1";
            // 
            // serverIP
            // 
            this.serverIP.Label = "Server IP:";
            this.serverIP.Name = "serverIP";
            this.serverIP.ScreenTip = "Designate the IP/URL of the uFile server";
            this.serverIP.Text = null;
            // 
            // serverConnectlabel
            // 
            this.serverConnectlabel.Label = "Disconnected";
            this.serverConnectlabel.Name = "serverConnectlabel";
            // 
            // box2
            // 
            this.box2.Items.Add(this.userStatus);
            this.box2.Items.Add(this.usernameEditBox);
            this.box2.Name = "box2";
            // 
            // userStatus
            // 
            this.userStatus.Label = "Guest Account";
            this.userStatus.Name = "userStatus";
            this.userStatus.ScreenTip = "What type of account you are currently using";
            // 
            // usernameEditBox
            // 
            this.usernameEditBox.Label = "User Name";
            this.usernameEditBox.Name = "usernameEditBox";
            this.usernameEditBox.Text = null;
            // 
            // passwordEditBox
            // 
            this.passwordEditBox.Label = "  Password";
            this.passwordEditBox.Name = "passwordEditBox";
            this.passwordEditBox.Text = null;
            // 
            // ComposeRibbon
            // 
            this.Name = "ComposeRibbon";
            this.RibbonType = "Microsoft.Outlook.Mail.Compose";
            this.Tabs.Add(this.uFile);
            this.Tabs.Add(this.uFileRestrictions);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.ComposeRibbon_Load);
            this.uFile.ResumeLayout(false);
            this.uFile.PerformLayout();
            this.manageuFile.ResumeLayout(false);
            this.manageuFile.PerformLayout();
            this.manageAccount.ResumeLayout(false);
            this.manageAccount.PerformLayout();
            this.uFileRestrictions.ResumeLayout(false);
            this.uFileRestrictions.PerformLayout();
            this.restrictionsGroup.ResumeLayout(false);
            this.restrictionsGroup.PerformLayout();
            this.otherRestrictionGroup.ResumeLayout(false);
            this.otherRestrictionGroup.PerformLayout();
            this.box1.ResumeLayout(false);
            this.box1.PerformLayout();
            this.box2.ResumeLayout(false);
            this.box2.PerformLayout();

        }

        #endregion

        private Microsoft.Office.Tools.Ribbon.RibbonTab uFile;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup manageuFile;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton upload;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton addLink;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup manageAccount;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton signOutButton;
        private System.Windows.Forms.OpenFileDialog uploaduFile;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton changeUser;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton signInButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton deleteButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator2;
        private Microsoft.Office.Tools.Ribbon.RibbonTab uFileRestrictions;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup restrictionsGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown presetDropDown;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton savePresetButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton deletePresetButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup timeRestrictionGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup otherRestrictionGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonComboBox ipRestrictionComboBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu locationMenu;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu groupMenu;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu uFileMenu;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box1;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox serverIP;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel serverConnectlabel;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box2;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel userStatus;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox usernameEditBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox passwordEditBox;
    }

    partial class ThisRibbonCollection
    {
        internal ComposeRibbon ComposeRibbon
        {
            get { return this.GetRibbon<ComposeRibbon>(); }
        }
    }
}
