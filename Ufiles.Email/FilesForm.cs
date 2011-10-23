using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ufiles.Email
{
    public partial class FilesForm : Form
    {
        private UFilesService.UFileServiceClient client;
        public FilesForm()
        {
            InitializeComponent();
            client = new UFilesService.UFileServiceClient();
            BindGroupsListBox();
        }
        private void BindGroupsListBox(){
            var groups = client.GetGroups();
            
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






    }
}
