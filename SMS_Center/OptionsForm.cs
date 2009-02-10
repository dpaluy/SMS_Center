using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMS_Center
{
    public partial class OptionsForm : Form
    {
        CommunicationManager cm_ = null;

        public OptionsForm(ref CommunicationManager cm)
        {
            InitializeComponent();
            this.cm_ = cm;
            cm_.SetParityValues(cboParity);
            cm_.SetStopBitValues(cboStop);
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                Settings.Default.URL = txtURL.Text;
                Settings.Default.AUTO_CONNECT = chkAutoConnect.Checked;
                Settings.Default.BaudRate = cm_.BaudRate = cboBaud.Text;
                Settings.Default.Parity = cm_.Parity = cboParity.Text;
                Settings.Default.StopBits = cm_.StopBits = cboStop.Text;
                Settings.Default.DataBits = cm_.DataBits = cboData.Text;
                Settings.Default.HTTP_METHOD = cmbHTTP_METHOD.Text;
                int value = 100;
                try
                {
                    value = Int32.Parse(txtTimeout.Text);
                }
                catch (Exception)
                {
                }
                Settings.Default.readSMS_timeout = value;
                Settings.Default.Save();
                this.Close();
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            string StartURI = "http://";
            string StartURIs = "https://";
            if (txtURL.Text.Length > (StartURIs.Length + 4) &&
                ((txtURL.Text.StartsWith(StartURI) == true) || (txtURL.Text.StartsWith(StartURIs) == true))
                )
            {
                btnSave.Enabled = true;
                picErrorInputURL.Visible = false;
            }
            else
            {
                btnSave.Enabled = false;
                picErrorInputURL.Visible = true;
            }
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            txtURL.Text = Settings.Default.URL;
            chkAutoConnect.Checked = Settings.Default.AUTO_CONNECT;
            cboBaud.Text = Settings.Default.BaudRate;
            cboParity.Text = Settings.Default.Parity;
            cboStop.Text = Settings.Default.StopBits;
            cboData.Text = Settings.Default.DataBits;
            txtTimeout.Text = Settings.Default.readSMS_timeout.ToString();
            cmbHTTP_METHOD.Text = Settings.Default.HTTP_METHOD;
        }

        private void txtTimeout_TextChanged(object sender, EventArgs e)
        {
            bool valid = true;
            try
            {
                int value = Int32.Parse(txtTimeout.Text);
                if (value < 100 || value > 10000)
                    valid = false;
            }
            catch (Exception)
            {
                valid = false;
            }
            if (valid)
            {
                picErrorTimeout.Visible = false;
                btnSave.Enabled = true;
            }
            else
            {
                picErrorTimeout.Visible = true;
                btnSave.Enabled = false;
            }
        }
    }
}