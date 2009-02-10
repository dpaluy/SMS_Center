using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MakePhoneList
{
    public partial class mainForm : Form
    {
        #region Variables
        CommunicationManager cm_ = new CommunicationManager();
        #endregion

        #region Constructor
        public mainForm()
        {
            InitializeComponent();
            string[] ports = CommunicationManager.GetComPortNames();
            if (ports.Length > 0)
            {
                foreach (string str in ports)
                {
                    cmbComPort.Items.Add(str);
                }
            }
            else
                cmbComPort.Items.Add("NO COM PORT!");
            cmbComPort.SelectedIndex = 0;
            SetCommunicationValues();
            btnConnectTtransmitter.Focus();
        }
        #endregion

        #region Set Communication Values
        private void SetCommunicationValues()
        {
            cm_.PortName = cmbComPort.Text;
            cm_.Parity = "None";
            cm_.StopBits = "1";
            cm_.DataBits = "8";
            cm_.BaudRate = "9600";
        }
        #endregion

        #region Menu
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileSaveTo = FormTools.saveFileDialog("XML files (*.xml)|*.xml|All files (*.*)|*.*", "Save Users To File");
            phones.WriteXml(fileSaveTo, XmlWriteMode.WriteSchema);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            phones.Clear();
            string fileLoadFrom = FormTools.openFileDialog("XML files (*.xml)|*.xml|All files (*.*)|*.*", "Open Users File");
            phones.ReadXml(fileLoadFrom);
            dataGridPhones.ClearSelection();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            phones.Clear();
            dataGridPhones.ClearSelection();
        }
        #endregion

        #region Connect & Send
        private void btnConnectTtransmitter_Click(object sender, EventArgs e)
        {
            if (phones.Tables[0].Rows.Count == 0)
            {
                FormTools.ErrBox("Please add some phones, before connecting!", "Send Phones");
                return;
            }
            btnConnectTtransmitter.Enabled = false;
            StartWorkGUI();
            bgwSend.RunWorkerAsync();
        }
        #endregion

        #region bgwSend
        private void bgwSend_DoWork(object sender, DoWorkEventArgs e)
        {
            if (false == cm_.Start())
            {
                FormTools.ErrBox("Cannot open modem Port!", "Connect to Modem");
                bgwSend.CancelAsync();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                string start_command = Properties.Settings.Default.start_command;
                string end_command = Properties.Settings.Default.end_command;
                string separator = Properties.Settings.Default.separator;
                string end_phone = Properties.Settings.Default.end_phone;
                int timeout = FormTools.SEC * Properties.Settings.Default.timeout;
                string verify = Properties.Settings.Default.output;

                sb.Append(start_command);
                int progress = 10;
                ReportProgress(ref e, ref progress);
                foreach (DataRow row in phones.Tables[0].Rows)
                {
                    string phone = (string)row["phone"];
                    string name = (string)row["name"];
                    phone = RemoveNonDigitsFromString(phone).Trim();
                    if (phone.Length > 0)
                        sb.Append(phone + separator + name + end_phone);
                }
                sb.Append(end_command);
                ReportProgress(ref e, ref progress);
                try {
                    cm_.WriteData(sb.ToString());
                    progress = 50;
                    ReportProgress(ref e, ref progress);
                    if (Properties.Settings.Default.eol)
                        cm_.SendEndOfLine();
                    if (verify.Length > 0)
                    {
                        string output = cm_.ReadData(timeout);
                        if (output.CompareTo(verify) != 0)
                        {
                            string msg = "Verification failed! (" + output + ")";
                            FormTools.ErrBox(msg, "Send Phones");
                        }
                    }

                    progress = 90;
                    ReportProgress(ref e, ref progress);
                }
                catch (Exception)
                {
                    bgwSend.CancelAsync();
                }
            }
        }

        private string RemoveNonDigitsFromString(string s)
        {
            string newresult = "";
            try
            {
                foreach (char c in s)
                {
                    if (char.IsDigit(c))
                    {
                        newresult += c.ToString();
                    }
                }
            }
            catch { }
            return newresult;
        }

        private void StartWorkGUI()
        {
            this.Cursor = Cursors.WaitCursor;
            progressBar.Visible = true;
            progressBar.Value = 0;
            statusLabel.Text = "Updating Modem...";
            if (bgwSend.IsBusy) bgwSend.CancelAsync();
            dataGridPhones.Enabled = false;
            grpTransmitter.Enabled = false;
            picTransmitterStatus.Image = Properties.Resources.on;
        }
        private void bgwSend_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void bgwSend_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statusLabel.Text = (e.Cancelled) ? "Cancelled" : "Completed";
            btnConnectTtransmitter.Enabled = true;
            this.Cursor = Cursors.Default;
            dataGridPhones.Enabled = true;
            grpTransmitter.Enabled = true;
            picTransmitterStatus.Image = Properties.Resources.off;
            progressBar.Visible = false;
            cm_.Stop();
        }
        #endregion

        #region Report Progress
        private void ReportProgress(ref DoWorkEventArgs e, ref int i)
        {
            if (bgwSend.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            bgwSend.ReportProgress(i);
            i = (i + 10) % 100;
        }
        #endregion

        #region ComPort
        private void cmbComPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            cm_.PortName = cmbComPort.Text;
        }
        #endregion

        #region Menu Handlers
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options frm = new Options();
            frm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox frm = new AboutBox();
            frm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitApplication();
        }

        private void exitApplication()
        {
            cm_.Stop();
            Application.Exit();
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            exitApplication();
        }
        #endregion

        private void dataGridPhones_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            FormTools.ErrBox("The phone and name fields can't be emtpy!", "Phones List");
        }
    }
}