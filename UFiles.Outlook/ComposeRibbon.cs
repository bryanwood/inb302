using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace UFiles.Outlook
{


    public partial class ComposeRibbon
    {
        private String userName;
        private String password;

        private void ComposeRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            this.upload.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.upload_Click);
            this.signOutButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.signOut_Click);
            this.signInButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.signIn_Click);


            updateuFileGallery();
        }//Called when the ribbon is loaded


        #region uFile ribbon section
        #region misc. methods
        private void updateuFileGallery()
        {
            string[] fileList = loadFileList();
            RibbonDropDownItem RDDI;
            if (fileList != null)
            {
                uFileMenu.Items.Clear();
                for (int i = 0; i >= fileList.Length; i++)
                {
                    RDDI = this.Factory.CreateRibbonDropDownItem();
                    RDDI.Label = fileList[i];
                    uFileMenu.Items.Add((Microsoft.Office.Tools.Ribbon.RibbonControl)RDDI);
                }
            }
        }
        private string[] loadFileList()
        {
            return null;
        }

        private String signIn()
        {
            return "passed";
        }

        #endregion
        #region Event Handlers

        private void upload_Click(object sender, RibbonControlEventArgs e)
        {
            this.uploaduFile.ShowDialog();

        }//called when the uFile upload button is clicked
        void signOut_Click(object sender, RibbonControlEventArgs e)
        {
            this.signOutButton.Visible = false;
            this.signInButton.Visible = true;
            //Swap the sign in buttons

            this.usernameEditBox.Text = "";
            this.usernameEditBox.Enabled = true;
            //clear and enable the username edit box

            this.passwordEditBox.Text = "";
            this.passwordEditBox.Enabled = true;
            //clear and enable the apssword edit box

            this.userStatus.Label = "Not Signed In";
        }//called when the sign out button is clicked
        void signIn_Click(object sender, RibbonControlEventArgs e)
        {
            switch (signIn())
            {
                case "passed":

                    this.usernameEditBox.Enabled = false;
                    this.passwordEditBox.Enabled = false;

                    this.userStatus.Label = "Guest Account";
                    //if username and password passed the login
                    break;
                case "invalid":
                    this.userStatus.Label = "Invalid User Name/Password";
                    //if the username/password is invalid
                    return;
                case "noserver":
                    this.userStatus.Label = "No server connection";
                    //if no server connection in one form or another is detected
                    return;
            }
            this.signInButton.Visible = false;
            this.signOutButton.Visible = true;
            //Swap the sign in buttons

            if (passwordEditBox.Text != "****")
            {
                password = passwordEditBox.Text;
                passwordEditBox.Text = "****";

            }
            //retrieve and protect the user's password

            userName = usernameEditBox.Text;

            //retrieve the user's username




        }
        private void signOutButton_Click(object sender, RibbonControlEventArgs e)
        {
            userName.Remove(0);
            password.Remove(0);
            this.usernameEditBox.Text = "";
            this.passwordEditBox.Text = "";
            this.usernameEditBox.Enabled = true;
            this.passwordEditBox.Enabled = true;
        }




        private void addLink_Click(object sender, RibbonControlEventArgs e)
        {

        }

        #endregion
        #endregion

        #region Restrictions ribbon section
        #region Supporting methods
        public RestrictionPreset getCurrentPreset()
        {
            RestrictionPreset RP = new RestrictionPreset();
            int startYear, startMonth, startDay, startHour, startMinute;

            RP.includeStartTime = this.startTimeIncludeCheckBox.Checked;
            RP.includeFinishTime = this.endTimeIncludeCheckBox.Checked;

            if (!int.TryParse(this.startTimeYearTextBox.Text, out startYear))
            {
                startYear = System.DateTime.Now.Year;
            }
            if (!int.TryParse(this.startTimeMonthDropDownBox.SelectedItem.Label, out startMonth))
            {
                startYear = System.DateTime.Now.Month;
            }
            if (!int.TryParse(this.startTimeDayDropDownBox.SelectedItem.Label, out startDay))
            {
                startYear = System.DateTime.Now.Day;
            }
            if (!int.TryParse(this.startTimeHoursEditBox.Text, out startHour))
            {
                startYear = System.DateTime.Now.Hour;
            }
            if (!int.TryParse(this.startTimeMinutesEditBox.Text, out startMinute))
            {
                startYear = System.DateTime.Now.Minute;
            }

            //RP.startTime = new DateTime(int year, int month, int day, int hour, int minute, int second);
            //RP.finishTime = new DateTime(int year, int month, int day, int hour, int minute, int second);
            return RP;
        }//returns the current state of the preset reibbon tab as a RestrictionPreset class
        #endregion
        #region events
        private void presetDropDown_SelectionChanged(object sender, RibbonControlEventArgs e)
        {

        }
        #endregion
        #endregion


    }

    public class RestrictionPreset
    {
        public string name;

        public Boolean includeStartTime = false;
        public Boolean includeFinishTime = false;
        public DateTime startTime;
        public DateTime finishTime;
        public String serverIP;
        public String Group;
        public String Location;

        public RestrictionPreset()
        {
        }

    }
}
