using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Windows.Forms;

namespace Bingo
{
    public partial class License : Form
    {
        public License()
        {
            InitializeComponent();
            LoadLicenseText();
        }

        private void LoadLicenseText()
        {
            try
            {
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string rtfFilePath = Path.Combine(appPath, "license.rtf");
                richTextBox1.LoadFile(rtfFilePath);
            } 
            catch (Exception)
            {
                this.DialogResult = DialogResult.Cancel;
                Application.Exit();
            }
            
        }

       
        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Application.Exit();
        }
    }
}

