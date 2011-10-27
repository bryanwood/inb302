using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using UFiles.Outlook.UFileService;

namespace UFiles.Outlook
{


    public partial class ComposeRibbon
    {
        private int userID = -1;
        private UFileServiceClient UClient;
        private String clientPassword;

        private void ComposeRibbon_Load(object sender, RibbonUIEventArgs e)
        {

            this.upload.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.upload_Click);
            this.signOutButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.signOutButton_Click);
            this.signInButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.signInButton_Click);

            UClient = new UFileServiceClient();
            UClient.Open();

        }//Called when the ribbon is loaded

        ~ComposeRibbon()
        {
            UClient.Close();
        }


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
            return null; //UClient.
        }


        #endregion
        #region Event Handlers


        private void connectButton_Click(object sender, RibbonControlEventArgs e)
        {
        }

        private void upload_Click(object sender, RibbonControlEventArgs e)
        {
            this.uploaduFile.ShowDialog();
            //UClient.AddFile(userID, 1 /*transmittal ID*/, uploaduFile.FileName, "uFile" /*FileType*/ ,uploaduFile.);

        }//called when the uFile upload button is clicked
        private void signInButton_Click(object sender, RibbonControlEventArgs e)
        {
            if (!passwordEditBox.Text.Equals("****"))
            {
                clientPassword = passwordEditBox.Text;
            }
            userID = UClient.Login(this.usernameEditBox.Text, clientPassword);
        }
        private void signOutButton_Click(object sender, RibbonControlEventArgs e)
        {
            if (UClient != null)
            {
                signOutButton.Visible = false;
                signInButton.Visible = true;
                userStatusLabel.Label = "Not Signed in";
            }
        }




        private void addLink_Click(object sender, RibbonControlEventArgs e)
        {
            Microsoft.Office.Interop.Outlook.MailItem currentMail = this.Context as Microsoft.Office.Interop.Outlook.MailItem;
            currentMail.Body.Insert(currentMail.Body.Length, "asdfa");
            //Outlook.ThisFormRegionCollection.
            //Outlook.Inspectors inspectors;

            //Inspector.WordEditor
        }

        #endregion
        #endregion

        #region Restrictions ribbon section
        #region Supporting methods
        public RestrictionPreset getCurrentPreset()
        {
            RestrictionPreset RP = new RestrictionPreset();
            int startYear, startMonth, startDay, startHour, startMinute;
            int endYear, endMonth, endDay, endHour, endMinute;

            RP.includeStartTime = this.startTimeIncludeCheckBox.Checked;
            RP.includeFinishTime = this.endTimeIncludeCheckBox.Checked;

            #region retrieve start time restriction times
            if (startTimeIncludeCheckBox.Checked == true)
            {
                if (!int.TryParse(this.startTimeYearTextBox.Text, out startYear))
                {
                    startYear = System.DateTime.Now.Year;
                    this.startTimeYearTextBox.Text = startYear.ToString();
                }
                else if (startYear < 2000 || startYear > 3000)
                {
                    this.startTimeYearTextBox.Text = "Invalid";
                }
                if (!int.TryParse(this.startTimeMonthDropDownBox.SelectedItem.Label, out startMonth))
                {
                    startMonth = System.DateTime.Now.Month;
                }
                if (!int.TryParse(this.startTimeDayDropDownBox.SelectedItem.Label, out startDay))
                {
                    startDay = System.DateTime.Now.Day;
                }
                if (!int.TryParse(this.startTimeHoursEditBox.Text, out startHour))
                {
                    startHour = System.DateTime.Now.Hour;
                }
                else if (startHour > 24 || startHour < 0)
                {
                    startTimeHoursEditBox.Text = "Invalid";
                }
                if (!int.TryParse(this.startTimeMinutesEditBox.Text, out startMinute))
                {
                    startMinute = System.DateTime.Now.Minute;
                }
                else if (startMinute > 60 || startMinute < 0)
                {
                    startTimeMinutesEditBox.Text = "Invalid";
                }
                RP.startTime = new DateTime(startYear, startMonth, startDay, startHour, startMinute, 0);
            }
            #endregion
            #region retrive end time restriction times
            do
            {
                Boolean invalidEndTime = false;
                if (!int.TryParse(this.startTimeYearTextBox.Text, out endYear))
                {
                    invalidEndTime = true;
                    this.endTimeYearEditBox.Text = "Invalid";
                }
                else if (endYear < 2000 || endYear > 3000)
                {
                    invalidEndTime = true;
                    this.endTimeYearEditBox.Text = "Invalid";
                }
                if (!int.TryParse(this.endTimeMonthDropDownBox.SelectedItem.Label, out endMonth))
                {
                    invalidEndTime = true;
                }
                if (!int.TryParse(this.endTimeDayDropDownBox.SelectedItem.Label, out endDay))
                {
                    invalidEndTime = true;
                }
                if (!int.TryParse(this.endTimeHoursEditBox.Text, out endHour))
                {
                    endTimeHoursEditBox.Text = "Invalid";
                    invalidEndTime = true;
                }
                else if (endHour > 24 || endHour < 0)
                {
                    endTimeHoursEditBox.Text = "Invalid";
                    invalidEndTime = true;
                }
                if (!int.TryParse(this.endTimeMinutesEditBox.Text, out endMinute))
                {
                    endTimeMinutesEditBox.Text = "Invalid";
                    invalidEndTime = true;
                }
                else if (endMinute > 60 || endMinute < 0)
                {
                    endTimeMinutesEditBox.Text = "Invalid";
                    invalidEndTime = true;
                }
                if (invalidEndTime == true)
                {
                    break;
                }
                else
                {
                    try
                    {
                        RP.finishTime = new DateTime(endYear, endMonth, endDay, endHour, endMinute, 0);
                    }
                    catch (NullReferenceException e)
                    {
                        break;
                    }
                }
            }
            while (false);

            #endregion

            return RP;
        }//returns the current state of the preset reibbon tab as a RestrictionPreset class
        #endregion
        #region events
        private void presetDropDown_SelectionChanged(object sender, RibbonControlEventArgs e)
        {

        }
        #endregion

        private void endTimeYearTextBox_TextChanged(object sender, RibbonControlEventArgs e)
        {

        }
        #endregion

        private void uploaduFile_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (UClient != null & userID != -1)
            {
                //UClient.AddFile(userID, ,uploaduFile.
            }
        }

        private void createUserButton_Click(object sender, RibbonControlEventArgs e)
        {

        }










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
