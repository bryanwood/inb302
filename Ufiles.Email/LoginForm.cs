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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public string Username { get; private set; }
        public string Password { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Username = textBox1.Text;
            Password = textBox2.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
