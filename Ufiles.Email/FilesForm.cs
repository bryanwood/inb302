using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ufiles.Email.UFilesService;
using System.IO;

namespace Ufiles.Email
{
    public partial class FilesForm : Form
    {
        
        private List<string> emails;
        private List<int> groups;
        public FilesForm()
        {
            InitializeComponent();
            emails = new List<string>();
            groups = new List<int>();
            UFiles.Current.FileAdded += new UFiles.FileAddedHandler(Current_FileAdded);
            BindGroupsListBox();
        }

        void Current_FileAdded()
        {
            lstFiles.Items.Clear();
            foreach (var item in UFiles.Current.Files)
            {
                lstFiles.Items.Add(item);
            }
        }
        private void BindGroupsListBox(){
            var groups = UFiles.Current.GetGroups();
            chkboxlstGroups.DisplayMember = "Name";
            foreach (var group in groups)
            {
                chkboxlstGroups.Items.Add(group, false);
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            var form2 = new UploadForm();
            var result = form2.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnAddEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Length > 0)
            {
                emails.Add(txtEmail.Text);
                txtEmail.Text = "";
                updateEmailList();
            }
        }
        private void updateEmailList()
        {
            lstEmail.Items.Clear();
            foreach (var email in emails)
            {
           
                lstEmail.Items.Add(email);
            }
        }

        private void btnRemoveEmail_Click(object sender, EventArgs e)
        {
            var items = lstEmail.SelectedItems;
            foreach (var item in items)
            {
                emails.Remove((string)item);
               
            }
            updateEmailList();
        }

        private void btnAddUserRestriction_Click(object sender, EventArgs e)
        {
            UFiles.Current.AddUserRestriction(emails.ToArray());
            emails.Clear();
            updateEmailList();
            lstRestrictions.Items.Add("User Restriction");
        }

        private void btnAddGroupRestriction_Click(object sender, EventArgs e)
        {
            foreach (var item in chkboxlstGroups.SelectedItems)
            {
                var group = (Group)item;
                groups.Add(group.GroupId);
                UFiles.Current.AddGroupRestrictions(groups.ToArray());
            }
            groups.Clear();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            var fi = new FileInfo(openFileDialog.FileName);
            string contentType;
            switch (fi.Extension){
                case ".jpg":
                    contentType = "image/jpg";
                    break;
                case ".png":
                    contentType = "image/png";
                    break;
                default:
                    contentType = "application/octet-stream";
                    break;
            }
            UFiles.Current.AddFile(openFileDialog.FileName, openFileDialog.SafeFileName, contentType);

            panel1.Enabled = true;
            btnBrowse.Enabled = false;
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            btnBrowse.Enabled = true;
        }

        
    }
}
