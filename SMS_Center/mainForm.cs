using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SMS_Center
{
    public partial class mainForm : Form
    {
        #region Variables
        private static CommunicationManager cm_ = new CommunicationManager();
        private static CellularProtocol cp_ = new CellularProtocol(cm_);
        private String operatorName = String.Empty;
        private String imei = String.Empty;
        #endregion

        #region Constructor
        public mainForm()
        {
            InitializeComponent();
            if (cm_.SetPortNameValues(cmbComPort, Settings.Default.COM_PORT) == false)
                Settings.Default.AUTO_CONNECT = false;
            cm_.DisplayWindow = null; //rtbLog;
            cm_.BaudRate = Settings.Default.BaudRate;
            cm_.Parity = Settings.Default.Parity;
            cm_.StopBits = Settings.Default.StopBits;
            cm_.DataBits = Settings.Default.DataBits;
            cm_.PortName = cmbComPort.Text;
            if (cmbComPort.Text == CommunicationManager.NO_COM_PORT)
            {
                btnConnect.Enabled = false;
                setStatusMsg("Connect SMS Receiver and restart the application!");
            }
            else
            {
                btnConnect.Select();
            }
            if (File.Exists(Settings.Default.LOG_File))
                File.Delete(Settings.Default.LOG_File);
        }
        #endregion

        #region Handle Timer Event
        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            if (true == cm_.isPortOpen)
            {
                MessageBox.Show("Modem is not Responding!\nPlease, check the modem and restart the application!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        #endregion

        #region Menu Handlers
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox frm = new AboutBox();
            frm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm optFrm = new OptionsForm(ref cm_);
            optFrm.ShowDialog();
        }
        #endregion

        #region Button Connect
        private void btnConnect_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (btnConnect.Text == "&Connect" && !bgwSetupModem.IsBusy)
            {
                toolStripProgressBar.Visible = true;
                toolStripProgressBar.Value = 0;
                toolStripStatusLabel.Text = "Registering...";
                btnConnect.Text = "&Cancel";
                bgwSetupModem.RunWorkerAsync();
            }
            else
            {
                if (cp_.Registered)
                {
                    bgwSMStoURL.CancelAsync();
                    cm_.Stop();
                    connectGUI(false);
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    bgwSetupModem.CancelAsync();
                    timer.Start();
                }
            }
        }
        #endregion

        #region Status Message
        private void setStatusMsg(string msg)
        {
            toolStripStatusLabel.Text = msg;
            toolStripStatusLabel.Visible = true;
        }
        #endregion

        #region Register Modem
        private STATUS modemSetup(ref DoWorkEventArgs e)
        {
            STATUS status = STATUS.ERROR_COM_PORT;
            try
            {
                if (false == cp_.isReady && false == cp_.Ready())
                    return STATUS.ERROR_COM_PORT;
                status = cp_.register(ref operatorName, ref imei, bgwSetupModem, ref e);
            }
            catch (Exception) {}

            return status;
        }
        #endregion

        #region Connect Disconnect GUI
        private void connectGUI(bool connected)
        {
            if (connected)
            {
                btnConnect.Text = "&Disconnect";
                statusPic.Image = Resource.on;
            }
            else
            {
                btnConnect.Text = "&Connect";
                statusPic.Image = Resource.off;
                operatorName = imei = String.Empty;
            }
            txtOperator.Text = operatorName;
            txtIMEI.Text = imei;
        }
        #endregion

        #region Modem Setup BGW
        private void bgwSetupModem_DoWork(object sender, DoWorkEventArgs e)
        {
            modemSetup(ref e);
        }

        private void bgwSetupModem_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar.Value = e.ProgressPercentage;
        }

        private void bgwSetupModem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Visible = false;
            if (!cp_.Registered)
            {
                cm_.Stop();
                connectGUI(false);
                if (e.Cancelled)
                {
                    setStatusMsg("Canceled!");
                }
                else
                {
                    MessageBox.Show("Error initializing modem!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setStatusMsg("Error initializing modem!");
                }
            }
            else
            {
                connectGUI(true);
                setStatusMsg("Waiting for SMS!");
                bgwSMStoURL.RunWorkerAsync();
            }
            this.Cursor = Cursors.Default;
        }
        #endregion

        #region Read SMS
        public void ReadSMSandForward(int index)
        {
            string from = String.Empty;
            string msg = String.Empty;
            STATUS status = cp_.readSMS(index, ref from, ref msg);

            fixMessage(ref msg);

            if (STATUS.SMS_READ == status)
            {
                if (false == forwardToURL(from, msg))
                {
                    StringBuilder sb = new StringBuilder("\n" + DateTime.Now + ": Error sending SMS");
                    sb.AppendFormat(" ({0}) from ({1}) to the Server!\n", msg, from);
                    String msgError = sb.ToString();
                    DisplayMsg(CommunicationManager.MessageType.Error, msgError);
                }
                else
                {
                    StringBuilder sb = new StringBuilder("\n" + DateTime.Now);
                    sb.AppendFormat(": SMS ({0} from {1})forwarded to Server ({2})!\n", msg, from, Settings.Default.URL);
                    String msgInfo = sb.ToString();
                    DisplayMsg(CommunicationManager.MessageType.Normal, msgInfo);
                }
            }
            else if (STATUS.NO_SMS != status)
            {
                StringBuilder sb = new StringBuilder("\n" + DateTime.Now + ": Error reading SMS");
                sb.AppendFormat(" ({0})!\n", index);
                String msgError = sb.ToString();
                DisplayMsg(CommunicationManager.MessageType.Error, msgError);
            }
        }

        private void DisplayMsg(CommunicationManager.MessageType msgType, String msg)
        {
            RichTextBox oldDisplayWindow = cm_.DisplayWindow;
            cm_.DisplayWindow = rtbLog;
            cm_.DisplayData(msgType, msg);
            cm_.DisplayWindow = oldDisplayWindow;
        }

        private void fixMessage(ref string msg)
        {
            msg = msg.TrimStart('\n');
            msg = msg.TrimEnd('\n');
            msg = msg.Replace(" ", "%20");
            msg = msg.Replace("<", "&lt;");
            msg = msg.Replace(">", "&gt;");
            msg = msg.Replace("&", "&amp; ");
            msg = msg.Replace("'", "&apos;");
            msg = msg.Replace("\n", "%0A");
            msg = msg.Replace("\r", "");
            msg = msg.Replace("\t", "");
            msg = msg.Replace("\"", "&quot;");
        }
        #endregion

        #region Send SMS to URL
        private bool forwardToURL(string from, string msg)
        {
            bool status = false;
            string postData = string.Format("through={0}&from={1}&content={2}", imei, from, msg);
            string uri = Settings.Default.URL;
            HttpRequestResponse http = new HttpRequestResponse(postData, uri);            
            string response;
            try {
                response = http.SendRequest();
                status = true;
            }
            catch (Exception) {}
            return status;
        }
        #endregion

        #region Send to URL bgw
        private void bgwSMStoURL_DoWork(object sender, DoWorkEventArgs e)
        {
            const int MaxNumberOfSMS = 20;
            bool readingSMS = true;
            while (readingSMS)
            {
                for (int i = 1; i <= MaxNumberOfSMS; i++)
                {
                    ReadSMSandForward(i);
                    CommunicationManager.Wait(Settings.Default.readSMS_timeout);
                    
                    if (bgwSMStoURL.CancellationPending)
                    {
                        e.Cancel = true;
                        readingSMS = false;
                        break;
                    }
                }
            }
        }

        private void bgwSMStoURL_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            String msgInfo = "\n" + DateTime.Now + ": SMS Server stopped!";
            DisplayMsg(CommunicationManager.MessageType.Normal, msgInfo);
            setStatusMsg("SMS Center was stopped.");
        }
        #endregion

        #region Rich Text Box Key Handles
        private void rtbLog_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!e.KeyChar.Equals('C'))
            // do nothing
            e.Handled = true;
        }

        private void rtbLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control)
                // do nothing
                e.Handled = true;
        }
        #endregion

        #region Main Form Load
        private void mainForm_Load(object sender, EventArgs e)
        {
            // start modem
            if (Settings.Default.AUTO_CONNECT == true)
            {
                btnConnect.PerformClick();
            }
        }
        #endregion

        #region Log
        private void rtbLog_TextChanged(object sender, EventArgs e)
        {
            rtbLog.SaveFile(Settings.Default.LOG_File);
            if (rtbLog.TextLength > 10485760) // 10 MB
                rtbLog.SelectAll();
        }
        #endregion
    }
}