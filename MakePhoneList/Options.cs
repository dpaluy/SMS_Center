using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MakePhoneList
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        #region Buttons
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.start_command = this.txtStartCommand.Text;
            Properties.Settings.Default.end_command = this.txtEndCommand.Text;
            Properties.Settings.Default.separator = this.txtSeparator.Text;
            Properties.Settings.Default.end_phone = this.txtEndPhone.Text;
            Properties.Settings.Default.eol = this.chkEOL.Checked;
            try
            {
                Properties.Settings.Default.timeout = Int32.Parse(txtTimeout.Text);
            }
            catch (Exception)
            {
            }
            Properties.Settings.Default.output = (chkOutput.Checked) ? this.txtOutput.Text : string.Empty;
            Properties.Settings.Default.Save();
            this.Close();
        }
        #endregion

        #region Form Load
        private void Options_Load(object sender, EventArgs e)
        {
            this.txtStartCommand.Text = Properties.Settings.Default.start_command;
            this.txtEndCommand.Text = Properties.Settings.Default.end_command;
            this.txtSeparator.Text = Properties.Settings.Default.separator;
            this.txtEndPhone.Text = Properties.Settings.Default.end_phone;
            this.txtOutput.Text = Properties.Settings.Default.output;
            this.txtTimeout.Text = Properties.Settings.Default.timeout.ToString();
            this.chkEOL.Checked = Properties.Settings.Default.eol;
            if (txtOutput.Text.Length > 0)
                this.chkOutput.Checked = true;
        }
        #endregion

    }
}