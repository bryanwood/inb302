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
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl1 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl2 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl3 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl4 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl5 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl6 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl7 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl8 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl9 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl10 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl11 = this.Factory.CreateRibbonDropDownItem();
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl12 = this.Factory.CreateRibbonDropDownItem();
            this.uFile = this.Factory.CreateRibbonTab();
            this.manageuFile = this.Factory.CreateRibbonGroup();
            this.upload = this.Factory.CreateRibbonButton();
            this.addLink = this.Factory.CreateRibbonButton();
            this.deleteButton = this.Factory.CreateRibbonButton();
            this.separator2 = this.Factory.CreateRibbonSeparator();
            this.uFileMenu = this.Factory.CreateRibbonMenu();
            this.manageAccount = this.Factory.CreateRibbonGroup();
            this.createUserButton = this.Factory.CreateRibbonButton();
            this.changeUser = this.Factory.CreateRibbonButton();
            this.signInButton = this.Factory.CreateRibbonButton();
            this.signOutButton = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.usernameEditBox = this.Factory.CreateRibbonEditBox();
            this.passwordEditBox = this.Factory.CreateRibbonEditBox();
            this.userStatus = this.Factory.CreateRibbonLabel();
            this.manageServerGroup = this.Factory.CreateRibbonGroup();
            this.connectButton = this.Factory.CreateRibbonButton();
            this.disconnectButton = this.Factory.CreateRibbonButton();
            this.separator4 = this.Factory.CreateRibbonSeparator();
            this.box1 = this.Factory.CreateRibbonBox();
            this.serverIPEditBox1 = this.Factory.CreateRibbonEditBox();
            this.serverIPEditBox2 = this.Factory.CreateRibbonEditBox();
            this.serverIPEditBox3 = this.Factory.CreateRibbonEditBox();
            this.serverIPEditBox4 = this.Factory.CreateRibbonEditBox();
            this.box7 = this.Factory.CreateRibbonBox();
            this.IPButton = this.Factory.CreateRibbonButton();
            this.URLButton = this.Factory.CreateRibbonButton();
            this.serverConnectlabel = this.Factory.CreateRibbonLabel();
            this.uploaduFile = new System.Windows.Forms.OpenFileDialog();
            this.uFileRestrictions = this.Factory.CreateRibbonTab();
            this.restrictionsGroup = this.Factory.CreateRibbonGroup();
            this.presetDropDown = this.Factory.CreateRibbonDropDown();
            this.savePresetButton = this.Factory.CreateRibbonButton();
            this.deletePresetButton = this.Factory.CreateRibbonButton();
            this.timeRestrictionGroup = this.Factory.CreateRibbonGroup();
            this.box4 = this.Factory.CreateRibbonBox();
            this.startTimeIncludeCheckBox = this.Factory.CreateRibbonCheckBox();
            this.label1 = this.Factory.CreateRibbonLabel();
            this.startTimeDayDropDownBox = this.Factory.CreateRibbonDropDown();
            this.startTimeMonthDropDownBox = this.Factory.CreateRibbonDropDown();
            this.startTimeYearTextBox = this.Factory.CreateRibbonEditBox();
            this.box3 = this.Factory.CreateRibbonBox();
            this.endTimeIncludeCheckBox = this.Factory.CreateRibbonCheckBox();
            this.label2 = this.Factory.CreateRibbonLabel();
            this.endTimeDayDropDownBox = this.Factory.CreateRibbonDropDown();
            this.endTimeMonthDropDownBox = this.Factory.CreateRibbonDropDown();
            this.endTimeYearEditBox = this.Factory.CreateRibbonEditBox();
            this.separator3 = this.Factory.CreateRibbonSeparator();
            this.box5 = this.Factory.CreateRibbonBox();
            this.startTimeHoursEditBox = this.Factory.CreateRibbonEditBox();
            this.startTimeMinutesEditBox = this.Factory.CreateRibbonEditBox();
            this.box6 = this.Factory.CreateRibbonBox();
            this.endTimeHoursEditBox = this.Factory.CreateRibbonEditBox();
            this.endTimeMinutesEditBox = this.Factory.CreateRibbonEditBox();
            this.otherRestrictionGroup = this.Factory.CreateRibbonGroup();
            this.ipRestrictionComboBox = this.Factory.CreateRibbonComboBox();
            this.locationMenu = this.Factory.CreateRibbonMenu();
            this.groupMenu = this.Factory.CreateRibbonMenu();
            this.uFile.SuspendLayout();
            this.manageuFile.SuspendLayout();
            this.manageAccount.SuspendLayout();
            this.manageServerGroup.SuspendLayout();
            this.box1.SuspendLayout();
            this.box7.SuspendLayout();
            this.uFileRestrictions.SuspendLayout();
            this.restrictionsGroup.SuspendLayout();
            this.timeRestrictionGroup.SuspendLayout();
            this.box4.SuspendLayout();
            this.box3.SuspendLayout();
            this.box5.SuspendLayout();
            this.box6.SuspendLayout();
            this.otherRestrictionGroup.SuspendLayout();
            // 
            // uFile
            // 
            this.uFile.Groups.Add(this.manageuFile);
            this.uFile.Groups.Add(this.manageAccount);
            this.uFile.Groups.Add(this.manageServerGroup);
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
            this.manageAccount.Items.Add(this.createUserButton);
            this.manageAccount.Items.Add(this.changeUser);
            this.manageAccount.Items.Add(this.signInButton);
            this.manageAccount.Items.Add(this.signOutButton);
            this.manageAccount.Items.Add(this.separator1);
            this.manageAccount.Items.Add(this.usernameEditBox);
            this.manageAccount.Items.Add(this.passwordEditBox);
            this.manageAccount.Items.Add(this.userStatus);
            this.manageAccount.Label = "Manage Account";
            this.manageAccount.Name = "manageAccount";
            // 
            // createUserButton
            // 
            this.createUserButton.Label = "Create User";
            this.createUserButton.Name = "createUserButton";
            // 
            // changeUser
            // 
            this.changeUser.Label = "Change User";
            this.changeUser.Name = "changeUser";
            this.changeUser.ScreenTip = "Change the user currently logged into uFile";
            // 
            // signInButton
            // 
            this.signInButton.Label = "Sign In";
            this.signInButton.Name = "signInButton";
            this.signInButton.ScreenTip = "Sign In";
            this.signInButton.Visible = false;
            this.signInButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.signInButton_Click);
            // 
            // signOutButton
            // 
            this.signOutButton.Label = "Sign Out";
            this.signOutButton.Name = "signOutButton";
            this.signOutButton.ScreenTip = "Sign Out";
            this.signOutButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.signOutButton_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // usernameEditBox
            // 
            this.usernameEditBox.Label = "User Name";
            this.usernameEditBox.Name = "usernameEditBox";
            this.usernameEditBox.Text = null;
            // 
            // passwordEditBox
            // 
            this.passwordEditBox.Label = "Password";
            this.passwordEditBox.Name = "passwordEditBox";
            this.passwordEditBox.Text = null;
            // 
            // userStatus
            // 
            this.userStatus.Label = "Guest Account";
            this.userStatus.Name = "userStatus";
            this.userStatus.ScreenTip = "What type of account you are currently using";
            // 
            // manageServerGroup
            // 
            this.manageServerGroup.Items.Add(this.connectButton);
            this.manageServerGroup.Items.Add(this.disconnectButton);
            this.manageServerGroup.Items.Add(this.separator4);
            this.manageServerGroup.Items.Add(this.box1);
            this.manageServerGroup.Items.Add(this.box7);
            this.manageServerGroup.Items.Add(this.serverConnectlabel);
            this.manageServerGroup.Label = "Manage Server";
            this.manageServerGroup.Name = "manageServerGroup";
            // 
            // connectButton
            // 
            this.connectButton.Label = "Connect";
            this.connectButton.Name = "connectButton";
            this.connectButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Label = "Disconnect";
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Visible = false;
            // 
            // separator4
            // 
            this.separator4.Name = "separator4";
            // 
            // box1
            // 
            this.box1.Items.Add(this.serverIPEditBox1);
            this.box1.Items.Add(this.serverIPEditBox2);
            this.box1.Items.Add(this.serverIPEditBox3);
            this.box1.Items.Add(this.serverIPEditBox4);
            this.box1.Name = "box1";
            // 
            // serverIPEditBox1
            // 
            this.serverIPEditBox1.Label = "Server Address:";
            this.serverIPEditBox1.Name = "serverIPEditBox1";
            this.serverIPEditBox1.ScreenTip = "Designate the IP/URL of the uFile server";
            this.serverIPEditBox1.Text = null;
            // 
            // serverIPEditBox2
            // 
            this.serverIPEditBox2.Label = ".";
            this.serverIPEditBox2.Name = "serverIPEditBox2";
            this.serverIPEditBox2.Text = null;
            // 
            // serverIPEditBox3
            // 
            this.serverIPEditBox3.Label = ".";
            this.serverIPEditBox3.Name = "serverIPEditBox3";
            this.serverIPEditBox3.Text = null;
            // 
            // serverIPEditBox4
            // 
            this.serverIPEditBox4.Label = ".";
            this.serverIPEditBox4.Name = "serverIPEditBox4";
            this.serverIPEditBox4.Text = null;
            // 
            // box7
            // 
            this.box7.Items.Add(this.IPButton);
            this.box7.Items.Add(this.URLButton);
            this.box7.Name = "box7";
            // 
            // IPButton
            // 
            this.IPButton.Label = "IP";
            this.IPButton.Name = "IPButton";
            this.IPButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.IPButton_Click_1);
            // 
            // URLButton
            // 
            this.URLButton.Label = "URL";
            this.URLButton.Name = "URLButton";
            this.URLButton.Visible = false;
            // 
            // serverConnectlabel
            // 
            this.serverConnectlabel.Label = "Disconnected";
            this.serverConnectlabel.Name = "serverConnectlabel";
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
            this.savePresetButton.Label = "Add Preset";
            this.savePresetButton.Name = "savePresetButton";
            // 
            // deletePresetButton
            // 
            this.deletePresetButton.Label = "Delete Preset";
            this.deletePresetButton.Name = "deletePresetButton";
            // 
            // timeRestrictionGroup
            // 
            this.timeRestrictionGroup.Items.Add(this.box4);
            this.timeRestrictionGroup.Items.Add(this.box3);
            this.timeRestrictionGroup.Items.Add(this.separator3);
            this.timeRestrictionGroup.Items.Add(this.box5);
            this.timeRestrictionGroup.Items.Add(this.box6);
            this.timeRestrictionGroup.Label = "Time Restriction";
            this.timeRestrictionGroup.Name = "timeRestrictionGroup";
            // 
            // box4
            // 
            this.box4.Items.Add(this.startTimeIncludeCheckBox);
            this.box4.Items.Add(this.label1);
            this.box4.Items.Add(this.startTimeDayDropDownBox);
            this.box4.Items.Add(this.startTimeMonthDropDownBox);
            this.box4.Items.Add(this.startTimeYearTextBox);
            this.box4.Name = "box4";
            // 
            // startTimeIncludeCheckBox
            // 
            this.startTimeIncludeCheckBox.Label = "Include";
            this.startTimeIncludeCheckBox.Name = "startTimeIncludeCheckBox";
            this.startTimeIncludeCheckBox.ScreenTip = "Incude the start time within the restructions";
            // 
            // label1
            // 
            this.label1.Label = "Start Time:";
            this.label1.Name = "label1";
            // 
            // startTimeDayDropDownBox
            // 
            this.startTimeDayDropDownBox.Label = "Day";
            this.startTimeDayDropDownBox.Name = "startTimeDayDropDownBox";
            // 
            // startTimeMonthDropDownBox
            // 
            ribbonDropDownItemImpl1.Label = "January";
            ribbonDropDownItemImpl2.Label = "February";
            ribbonDropDownItemImpl3.Label = "March";
            ribbonDropDownItemImpl4.Label = "April";
            ribbonDropDownItemImpl5.Label = "May";
            ribbonDropDownItemImpl6.Label = "June";
            ribbonDropDownItemImpl7.Label = "July";
            ribbonDropDownItemImpl8.Label = "August";
            ribbonDropDownItemImpl9.Label = "September";
            ribbonDropDownItemImpl10.Label = "October";
            ribbonDropDownItemImpl11.Label = "November";
            ribbonDropDownItemImpl12.Label = "December";
            this.startTimeMonthDropDownBox.Items.Add(ribbonDropDownItemImpl1);
            this.startTimeMonthDropDownBox.Items.Add(ribbonDropDownItemImpl2);
            this.startTimeMonthDropDownBox.Items.Add(ribbonDropDownItemImpl3);
            this.startTimeMonthDropDownBox.Items.Add(ribbonDropDownItemImpl4);
            this.startTimeMonthDropDownBox.Items.Add(ribbonDropDownItemImpl5);
            this.startTimeMonthDropDownBox.Items.Add(ribbonDropDownItemImpl6);
            this.startTimeMonthDropDownBox.Items.Add(ribbonDropDownItemImpl7);
            this.startTimeMonthDropDownBox.Items.Add(ribbonDropDownItemImpl8);
            this.startTimeMonthDropDownBox.Items.Add(ribbonDropDownItemImpl9);
            this.startTimeMonthDropDownBox.Items.Add(ribbonDropDownItemImpl10);
            this.startTimeMonthDropDownBox.Items.Add(ribbonDropDownItemImpl11);
            this.startTimeMonthDropDownBox.Items.Add(ribbonDropDownItemImpl12);
            this.startTimeMonthDropDownBox.Label = "Month";
            this.startTimeMonthDropDownBox.Name = "startTimeMonthDropDownBox";
            // 
            // startTimeYearTextBox
            // 
            this.startTimeYearTextBox.Label = "Year";
            this.startTimeYearTextBox.Name = "startTimeYearTextBox";
            this.startTimeYearTextBox.Text = null;
            // 
            // box3
            // 
            this.box3.Items.Add(this.endTimeIncludeCheckBox);
            this.box3.Items.Add(this.label2);
            this.box3.Items.Add(this.endTimeDayDropDownBox);
            this.box3.Items.Add(this.endTimeMonthDropDownBox);
            this.box3.Items.Add(this.endTimeYearEditBox);
            this.box3.Name = "box3";
            // 
            // endTimeIncludeCheckBox
            // 
            this.endTimeIncludeCheckBox.Label = "Include";
            this.endTimeIncludeCheckBox.Name = "endTimeIncludeCheckBox";
            this.endTimeIncludeCheckBox.ScreenTip = "Incude the start time within the restructions";
            // 
            // label2
            // 
            this.label2.Label = "End Time: ";
            this.label2.Name = "label2";
            // 
            // endTimeDayDropDownBox
            // 
            this.endTimeDayDropDownBox.Label = "Day";
            this.endTimeDayDropDownBox.Name = "endTimeDayDropDownBox";
            // 
            // endTimeMonthDropDownBox
            // 
            this.endTimeMonthDropDownBox.Label = "Month";
            this.endTimeMonthDropDownBox.Name = "endTimeMonthDropDownBox";
            // 
            // endTimeYearEditBox
            // 
            this.endTimeYearEditBox.Label = "Year";
            this.endTimeYearEditBox.Name = "endTimeYearEditBox";
            this.endTimeYearEditBox.Text = null;
            this.endTimeYearEditBox.TextChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.endTimeYearTextBox_TextChanged);
            // 
            // separator3
            // 
            this.separator3.Name = "separator3";
            // 
            // box5
            // 
            this.box5.Items.Add(this.startTimeHoursEditBox);
            this.box5.Items.Add(this.startTimeMinutesEditBox);
            this.box5.Name = "box5";
            // 
            // startTimeHoursEditBox
            // 
            this.startTimeHoursEditBox.Label = "Hour";
            this.startTimeHoursEditBox.Name = "startTimeHoursEditBox";
            this.startTimeHoursEditBox.Text = null;
            // 
            // startTimeMinutesEditBox
            // 
            this.startTimeMinutesEditBox.Label = "Minutes";
            this.startTimeMinutesEditBox.Name = "startTimeMinutesEditBox";
            this.startTimeMinutesEditBox.Text = null;
            // 
            // box6
            // 
            this.box6.Items.Add(this.endTimeHoursEditBox);
            this.box6.Items.Add(this.endTimeMinutesEditBox);
            this.box6.Name = "box6";
            // 
            // endTimeHoursEditBox
            // 
            this.endTimeHoursEditBox.Label = "Hour";
            this.endTimeHoursEditBox.Name = "endTimeHoursEditBox";
            this.endTimeHoursEditBox.Text = null;
            // 
            // endTimeMinutesEditBox
            // 
            this.endTimeMinutesEditBox.Label = "Minutes";
            this.endTimeMinutesEditBox.Name = "endTimeMinutesEditBox";
            this.endTimeMinutesEditBox.Text = null;
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
            this.locationMenu.Label = "PostCode";
            this.locationMenu.Name = "locationMenu";
            // 
            // groupMenu
            // 
            this.groupMenu.Label = "Group";
            this.groupMenu.Name = "groupMenu";
            // 
            // ComposeRibbon
            // 
            this.Name = "ComposeRibbon";
            this.RibbonType = "Microsoft.Outlook.Mail.Compose, Microsoft.Outlook.Mail.Read, Microsoft.Outlook.Po" +
                "st.Compose, Microsoft.Outlook.Post.Read";
            this.Tabs.Add(this.uFile);
            this.Tabs.Add(this.uFileRestrictions);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.ComposeRibbon_Load);
            this.uFile.ResumeLayout(false);
            this.uFile.PerformLayout();
            this.manageuFile.ResumeLayout(false);
            this.manageuFile.PerformLayout();
            this.manageAccount.ResumeLayout(false);
            this.manageAccount.PerformLayout();
            this.manageServerGroup.ResumeLayout(false);
            this.manageServerGroup.PerformLayout();
            this.box1.ResumeLayout(false);
            this.box1.PerformLayout();
            this.box7.ResumeLayout(false);
            this.box7.PerformLayout();
            this.uFileRestrictions.ResumeLayout(false);
            this.uFileRestrictions.PerformLayout();
            this.restrictionsGroup.ResumeLayout(false);
            this.restrictionsGroup.PerformLayout();
            this.timeRestrictionGroup.ResumeLayout(false);
            this.timeRestrictionGroup.PerformLayout();
            this.box4.ResumeLayout(false);
            this.box4.PerformLayout();
            this.box3.ResumeLayout(false);
            this.box3.PerformLayout();
            this.box5.ResumeLayout(false);
            this.box5.PerformLayout();
            this.box6.ResumeLayout(false);
            this.box6.PerformLayout();
            this.otherRestrictionGroup.ResumeLayout(false);
            this.otherRestrictionGroup.PerformLayout();

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
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box4;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox startTimeIncludeCheckBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label1;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown startTimeDayDropDownBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown startTimeMonthDropDownBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox startTimeYearTextBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box3;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox endTimeIncludeCheckBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel label2;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown endTimeDayDropDownBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown endTimeMonthDropDownBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox endTimeYearEditBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator3;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box5;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox startTimeHoursEditBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox startTimeMinutesEditBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box6;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox endTimeHoursEditBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox endTimeMinutesEditBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton createUserButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel userStatus;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox passwordEditBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup manageServerGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton connectButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton disconnectButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator4;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box1;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox serverIPEditBox1;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox serverIPEditBox2;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox serverIPEditBox3;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox serverIPEditBox4;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box7;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton IPButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton URLButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel serverConnectlabel;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox usernameEditBox;
    }

    partial class ThisRibbonCollection
    {
        internal ComposeRibbon ComposeRibbon
        {
            get { return this.GetRibbon<ComposeRibbon>(); }
        }
    }
}
