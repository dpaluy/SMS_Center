using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace SMS_Center
{
    public enum STATUS { OK, CANCELED, CONNECT_9600, BUSY, NO_CARRIER, ERROR_AUTHORIZE, ERROR_COM_PORT, ERROR_AT_COMMAND, SMS_READ, NO_SMS };

    public class CellularProtocol
    {

        #region Protocol Variables
        private bool registered_ = false;
        private CommunicationManager cm_ = null;
        private const int MAX_NUMBER_OF_TRIES = 3;
        private const int DEFAULT_TIMEOUT = 100; // msec
        public const int SEC = 1000; // sec definition by msec
        private const string CR = "\r"; // End of line       
        #endregion

        #region Constructor
        public CellularProtocol(CommunicationManager cm)
        {
            this.cm_ = cm;
        }
        #endregion

        #region Port Ready
        /// <summary>
        /// Open com port
        /// </summary>
        /// <returns>true - if the port is open, otherwise - false</returns>
        public bool Ready()
        {
            bool status = false;
            try
            {
                status = cm_.Start();
            } catch (Exception)
            {}

            return status;
        }

        /// <summary>
        /// Return Protocol ready status
        /// </summary>
        public bool isReady
        {
            get { return cm_.isPortOpen; }
        }
        #endregion

        #region Register
        public bool Registered
        {
            get { return registered_; }
            set { registered_ = value; }
        }

        public STATUS register(ref string operatorName, ref string imei,
                                System.ComponentModel.BackgroundWorker bgw, ref DoWorkEventArgs e)
        {
            Registered = false;
            if (false == cm_.isPortOpen)
                return STATUS.ERROR_COM_PORT;

            int i = 1;
            STATUS status = STATUS.OK;
            ReportProgress(ref status, bgw, ref e, ref i);

            status = CommandATE();
            ReportProgress(ref status, bgw, ref e, ref i);
            if (STATUS.OK != status) return status;

            status = CommandAT();
            ReportProgress(ref status, bgw, ref e, ref i);
            if (STATUS.OK != status) return status;

            bool PDU_mode = false;
            status = CommandCMGF(PDU_mode);
            ReportProgress(ref status, bgw, ref e, ref i);
            if (STATUS.OK != status) return status;

            status = CommandCREG();
            ReportProgress(ref status, bgw, ref e, ref i);
            if (STATUS.OK != status) return status;

            string pin = "";
            status = CommandCPIN(pin);
            ReportProgress(ref status, bgw, ref e, ref i);
            if (STATUS.OK != status) return status;

            status = CommandCRC();
            ReportProgress(ref status, bgw, ref e, ref i);
            if (STATUS.OK != status) return status;

            byte te = 0;
            byte ta = 0;
            status = CommandIFC(te, ta);
            ReportProgress(ref status, bgw, ref e, ref i);
            if (STATUS.OK != status) return status;

            bool identify = true;
            status = CommandCLIP(identify);
            ReportProgress(ref status, bgw, ref e, ref i);
            if (STATUS.OK != status) return status;

            status = CommandCGSN(ref imei);
            ReportProgress(ref status, bgw, ref e, ref i);
            if (STATUS.OK != status) return status;

            status = CommandCOPS(ref operatorName);
            ReportProgress(ref status, bgw, ref e, ref i);
            if (STATUS.OK != status) return status;

            //status = CommandCLIR(0);
            //ReportProgress(ref status, bgw, ref e, ref i);
            //if (STATUS.OK != status) return status;

            // DOESN'T WORK with SMS
            //status = CommandCPMS();
            //ReportProgress(ref status, bgw, ref e, ref i);
            //if (STATUS.OK != status) return status;

            int index = 1;
            int flag = 4;
            status = CommandCMGD(index, flag);
            ReportProgress(ref status, bgw, ref e, ref i);
            if (STATUS.OK != status) return status;

            bool n = true;
            byte cmd = 1;
            byte klass = 7;
            status = CommandCCWA(n, cmd, klass);
            ReportProgress(ref status, bgw, ref e, ref i);
            if (STATUS.OK != status) return status;

            status = CommandAT();
            ReportProgress(ref status, bgw, ref e, ref i);
            if (STATUS.OK != status) return status;

            Registered = true;
            return STATUS.OK;
        }

        private void ReportProgress(ref STATUS status, System.ComponentModel.BackgroundWorker bgw, ref DoWorkEventArgs e, ref int i)
        {
            if (bgw.CancellationPending)
            {
                e.Cancel = true;
                status = STATUS.CANCELED;
                return;
            }
            bgw.ReportProgress(i);
            i = (i + 8) % 100;
        }
        #endregion

        #region AT Commands

        /// <summary>
        /// AT Command, Expect - OK
        /// </summary>
        /// <returns>Execution STATUS</returns>
        public STATUS CommandAT()
        {
            StringBuilder sb = new StringBuilder("AT");
            string atCommand = sb.ToString();
            string expectedResult = "OK";
            return sendAT_Command(atCommand, expectedResult, MAX_NUMBER_OF_TRIES, DEFAULT_TIMEOUT);
        }

        /// <summary>
        /// AT+CGSN Request Product Serial Number Identification
        /// </summary>
        /// <returns>Execution STATUS</returns>
        public STATUS CommandCGSN(ref string sn)
        {
            StringBuilder sb = new StringBuilder("AT+CGSN");
            string atCommand = sb.ToString();
            string expectedResultEnd = "\r\n\r\nOK";
            string output = string.Empty;
            bool result = false;
            int tries = 0;
            while (!result && tries < MAX_NUMBER_OF_TRIES)
            {
                output = sendData(atCommand, 180 * SEC);
                result = output.EndsWith(expectedResultEnd);
                ++tries;
            }
            int start = 0;
            int end = output.IndexOf("\r") - 1;
            if (end < start) return STATUS.ERROR_AT_COMMAND;

            sn = output.Substring(start, end);
            return ((result) ? STATUS.OK : STATUS.ERROR_AT_COMMAND);
        }

        /// <summary>
        /// AT+CMGD Command, Expect - OK
        /// </summary>
        /// <returns>Execution STATUS</returns>
        public STATUS CommandCMGD(int index, int delflag)
        {
            StringBuilder sb = new StringBuilder("AT+CMGD");
            sb.AppendFormat("={0},{1}", index, delflag);
            string atCommand = sb.ToString();
            string expectedResult1 = "OK";
            string expectedResult2 = "+CMS ERROR: 321";
            string output = string.Empty;
            bool result = false;
            int tries = 0;
            while (!result && tries < MAX_NUMBER_OF_TRIES)
            {
                output = sendData(atCommand, 15 * SEC);
                result = (output.EndsWith(expectedResult1) || output.EndsWith(expectedResult2));
                ++tries;
            }
            return ((result) ? STATUS.OK : STATUS.ERROR_AT_COMMAND);
        }

        /// <summary>
        /// AT+CLIR Command, Expect - OK
        /// </summary>
        /// <returns>Execution STATUS</returns>
        public STATUS CommandCLIR(int index)
        {
            StringBuilder sb = new StringBuilder("AT+CLIR=");
            sb.AppendFormat("{0}", index);
            string atCommand = sb.ToString();
            string expectedResult = "OK";
            return sendAT_Command(atCommand, expectedResult, MAX_NUMBER_OF_TRIES, 180 * SEC);
        }

        /// <summary>
        /// CPMS
        /// </summary>
        /// <returns>Execution STATUS</returns>
        public STATUS CommandCPMS()
        {
            StringBuilder sb = new StringBuilder("AT+CPMS=ME" + CR);
            string atCommand = sb.ToString();
            string expectedResultEnd = "OK";
            string output = string.Empty;
            bool result = SendCommandVerifyEnd(5* SEC, ref output, atCommand, expectedResultEnd);
            return ((result) ? STATUS.OK : STATUS.ERROR_AT_COMMAND);
        }

        /// <summary>
        /// ATE0 Command - Cancel Echo, Expect - OK
        /// </summary>
        /// <returns>Execution STATUS</returns>
        public STATUS CommandATE()
        {
            StringBuilder sb = new StringBuilder("ATE0");
            string atCommand = sb.ToString();
            string expectedResultEnd = "OK";
            string output = string.Empty;
            bool result = SendCommandVerifyEnd(DEFAULT_TIMEOUT, ref output, atCommand, expectedResultEnd);
            return ((result) ? STATUS.OK : STATUS.ERROR_AT_COMMAND);
        }

        /// <summary>
        /// AT+CREG? Command, Expect - OK
        /// </summary>
        /// <returns>Execution STATUS</returns>
        public STATUS CommandCREG()
        {
            StringBuilder sb = new StringBuilder("AT+CREG?");
            string atCommand = sb.ToString();
            string expectedResultEnd = "\r\n\r\nOK";
            string output = string.Empty;
            bool result = SendCommandVerifyEnd(15*SEC, ref output, atCommand, expectedResultEnd);
            return ((result) ? STATUS.OK : STATUS.ERROR_AT_COMMAND);
        }

        /// <summary>
        /// Enter PIN
        /// </summary>
        /// <param name="pin">PIN CODE</param>
        /// <returns>Execution STATUS</returns>
        public STATUS CommandCPIN(string pin)
        {
            // TODO: handle pin authorization
            StringBuilder sb = new StringBuilder("AT+CPIN?");
            string atCommand = sb.ToString();
            string expectedResult = "+CPIN: READY\r\n\r\nOK";
            return sendAT_Command(atCommand, expectedResult, MAX_NUMBER_OF_TRIES, 20 * SEC);
        }

        /// <summary>
        /// CRC - Cellular Result Codes
        /// Enables extended format reporting
        /// </summary>
        /// <returns>Execution STATUS</returns>
        public STATUS CommandCRC()
        {
            StringBuilder sb = new StringBuilder("AT+CRC=1");
            string atCommand = sb.ToString();
            string expectedResult = "OK";
            return sendAT_Command(atCommand, expectedResult, MAX_NUMBER_OF_TRIES, (int)(0.2 * SEC));
        }

        /// <summary>
        /// CLIP - Calling line identification presentation
        /// </summary>
        /// <param name="isEnable">CLI indication</param>
        /// <returns>Execution STATUS</returns>
        public STATUS CommandCLIP(bool isEnable)
        {
            StringBuilder sb = new StringBuilder("AT+CLIP=");
            sb.AppendFormat("{0}", (true == isEnable) ? 1 : 0);
            string atCommand = sb.ToString();
            string expectedResult = "OK";
            return sendAT_Command(atCommand, expectedResult, MAX_NUMBER_OF_TRIES, 180 * SEC);
        }

        /// <summary>
        /// CMGF - Message Format
        /// </summary>
        /// <param name="isPDU">true - PDU mode, false - Text mode</param>
        /// <returns>Execution STATUS</returns>
        public STATUS CommandCMGF(bool isPDU)
        {
            StringBuilder sb = new StringBuilder("AT+CMGF=");
            sb.AppendFormat("{0}", (true == isPDU) ? 0 : 1);
            string atCommand = sb.ToString();
            string expectedResult = "OK";
            return sendAT_Command(atCommand, expectedResult, MAX_NUMBER_OF_TRIES, 5 * SEC);
        }

        /// <summary>
        /// COPS - Operator Selection
        /// </summary>
        /// <returns>Execution STATUS</returns>
        public STATUS CommandCOPS(ref string operatorName)
        {
            StringBuilder sb = new StringBuilder("AT+COPS?" + CR);
            string atCommand = sb.ToString();
            string expectedResultStart = "+COPS: 0,0,";
            string expectedResultEnd = "OK";
            string output = string.Empty;
            bool result = false;
            int tries = 0;
            while (!result && tries < MAX_NUMBER_OF_TRIES)
            {
                output = sendData(atCommand, 180 * SEC);
                result = (output.StartsWith(expectedResultStart) && output.EndsWith(expectedResultEnd));
                ++tries;
            }
            int start = output.IndexOf("\"") + 1;
            int end = output.LastIndexOf("\"") - start;
            operatorName = output.Substring(start, end);
            //return sendAT_Command(atCommand, expectedResult, MAX_NUMBER_OF_TRIES, 180 * SEC);
            return ((result) ? STATUS.OK : STATUS.ERROR_AT_COMMAND);
        }

        /// <summary>
        /// Call waiting
        /// </summary>
        /// <param name="n">Enables/disables the presentation of an unsolicited result code</param>
        /// <param name="cmd">Enables(1)/Disables(0) or queries(2) the service at network level</param>
        /// <param name="klass">
        ///     Represents class of information
        ///     <ul>
        ///         <li>1 - voice(telephony)</li>    
        ///         <li>2 - data</li>
        ///         <li>4 - fax</li>
        ///         <li>7 - sum of all (voice+data+fax)</li>
        ///     </ul>
        /// </param>
        /// <returns>Execution STATUS</returns>
        public STATUS CommandCCWA(bool n, byte cmd, byte klass)
        {
            StringBuilder sb = new StringBuilder("AT+CCWA=");
            sb.AppendFormat("{0},{1},{2}", (true == n) ? 1 : 0, cmd, klass);
            string atCommand = sb.ToString();
            string expectedResult = "OK";
            return sendAT_Command(atCommand, expectedResult, MAX_NUMBER_OF_TRIES, 220 * SEC);
        }

        /// <summary>
        /// DTE-Modem Local Flow Control
        /// </summary>
        /// <param name="te"></param>
        /// <param name="ta"></param>
        /// <returns>Execution STATUS</returns>
        public STATUS CommandIFC(byte te, byte ta)
        {
            StringBuilder sb = new StringBuilder("AT+IFC=");
            sb.AppendFormat("{0},{1}", te, ta);
            string atCommand = sb.ToString();
            string expectedResult = "OK";
            return sendAT_Command(atCommand, expectedResult, MAX_NUMBER_OF_TRIES, DEFAULT_TIMEOUT);

        }

        /// <summary>
        /// Dial data call
        /// </summary>
        /// <param name="number">Phone number to be dialed</param>
        /// <returns></returns>
        public STATUS CommandATD(string number)
        {
            StringBuilder sb = new StringBuilder("ATD");
            sb.Append(number);
            string atCommand = sb.ToString();
            int tries = 0;
            STATUS status = STATUS.NO_CARRIER;
            while (tries < MAX_NUMBER_OF_TRIES && STATUS.OK != status && STATUS.CONNECT_9600 != status)
            {
                status = CommandAT();
                CommunicationManager.Wait(100);
                if (STATUS.ERROR_COM_PORT == status)
                    return status;

                if (STATUS.OK == status)
                {
                    string response;
                    cm_.ReadFullLine = true;
                    CommunicationManager.Wait(SEC);
                    cm_.ReadData(SEC); // Clear Buffer
                    response = sendData(atCommand, 60 * SEC);
                    response = cm_.ReadData(SEC);
                    CommunicationManager.Wait(300);
                    switch (response)
                    {
                        case "BUSY":
                            status = STATUS.BUSY;
                            //TODO: Thread.Sleep(waitTime);
                            break;
                        case "NO CARRIER":
                            status = STATUS.NO_CARRIER;
                            //TODO: Thread.Sleep(waitTime);
                            break;
                        case "CONNECT 9600":
                            status = STATUS.OK;
                            break;
                        case "OK":
                            status = STATUS.OK;
                            break;
                        default:
                            status = STATUS.ERROR_AT_COMMAND;
                            break;
                    }
                }
                ++tries;
            }    // end of while loop   
            return status;
        }

        /// <summary>
        /// ATH command
        /// </summary>
        /// <returns></returns>
        public STATUS CommandATH()
        {
            StringBuilder sb = new StringBuilder("ATH");
            string atCommand = sb.ToString();
            string expectedResult = "NO CARRIER";
            STATUS status = STATUS.ERROR_AT_COMMAND;
            int tries = 0;
            cm_.AutoEOL = true;
            string output;
            while (status != STATUS.OK && tries < MAX_NUMBER_OF_TRIES)
            {
                cm_.WriteData(atCommand);
                CommunicationManager.Wait(SEC);
                output = cm_.ReadData(DEFAULT_TIMEOUT);
                if (output.IndexOf(expectedResult) >= 0 || output.IndexOf("OK") >= 0)
                    status = STATUS.OK;

                ++tries;
            }
            return status;
        }

        /// <summary>
        /// Send +++
        /// and wait for OK
        /// </summary>
        /// <returns></returns>
        public STATUS CommandToCommandMode()
        {
            StringBuilder sb = new StringBuilder("+++");
            string atCommand = sb.ToString();
            string expectedResult = "OK";
            return sendAT_Command(atCommand, expectedResult, MAX_NUMBER_OF_TRIES, DEFAULT_TIMEOUT);
        }

        /// <summary>
        /// Return to On Line Mode from command mode
        /// </summary>
        /// <returns></returns>
        public STATUS CommandToOnLineMode()
        {
            StringBuilder sb = new StringBuilder("ATO");
            string atCommand = sb.ToString();
            string expectedResult = "OK";
            return sendAT_Command(atCommand, expectedResult, MAX_NUMBER_OF_TRIES, DEFAULT_TIMEOUT);
        }
        #endregion

        #region Send Data to COM Port

        private bool SendCommandVerifyEnd(int timeout, ref string output, string atCommand, string expectedResultEnd)
        {
            bool result = false;
            int tries = 0;
            while (!result && tries < MAX_NUMBER_OF_TRIES)
            {
                output = sendData(atCommand, timeout);
                result = output.EndsWith(expectedResultEnd);
                ++tries;
            } 
            return result;
        }

        /// <summary>
        /// Send Data to COM Port
        /// </summary>
        /// <param name="data">Data to be send</param>
        /// <param name="expectedResult">Expected result to be verified</param>
        /// <param name="maxNumberOfTries">Max number of tries to send this command</param>
        /// <param name="timeout">Read Max Timeout</param>
        /// <returns>Execution status</returns>
        private STATUS sendAT_Command(string data, string expectedResult, int maxNumberOfTries, int timeout)
        {
            int tries = 0;
            STATUS status = STATUS.ERROR_AT_COMMAND;
            cm_.AutoEOL = true;
            string output;
            while (status != STATUS.OK && tries < maxNumberOfTries)
            {
                cm_.WriteData(data);
                CommunicationManager.Wait(SEC);
                output = cm_.ReadData(timeout);
                output = output.Trim();
                //status = (0 == string.Compare(expectedResult, output, true)) ? STATUS.OK : STATUS.ERROR_AT_COMMAND;
                status = (output.IndexOf(expectedResult) >= 0) ? STATUS.OK : STATUS.ERROR_AT_COMMAND;
                if (STATUS.OK != status)
                    CommunicationManager.Wait(SEC * 3);
                ++tries;
            }
            return status;
        }

        /// <summary>
        /// Send Data once to the COM Port without verification
        /// </summary>
        /// <param name="data">Data to be sent</param>
        /// <param name="timeout">Read Timeout</param>
        /// <returns>Output</returns>
        public string sendData(string data, int timeout)
        {
            string output = string.Empty;
            cm_.AutoEOL = true;
            if (!cm_.isPortOpen) return output;
            cm_.WriteData(data);
            CommunicationManager.Wait(SEC);
            if (!cm_.isPortOpen) return output;
            output = cm_.ReadData(timeout);
            output = output.Trim();
            return output;
        }

        public string sendDataLN(string data, int timeout)
        {
            string output;
            cm_.AutoEOL = true;
            cm_.WriteData(data);
            CommunicationManager.Wait(SEC);
            output = ReadDataLN(timeout);
            output = output.Trim();
            return output;
        }
        #endregion

        #region Read Data
        public string ReadDataLN(int timeout)
        {
            cm_.ReadFullLine = true;
            string output = string.Empty;
            output = cm_.ReadData(timeout);
            cm_.ReadFullLine = false;
            return output;
        }
        #endregion

        #region Read SMS
        public STATUS readSMS(int index, ref string from, ref string msg)
        {
            STATUS status = CommandCMGR(index, ref from, ref msg);
            if (status == STATUS.OK)
                if (from.Length > 0)
                {
                    status = CommandCMGD(index, 0); // delete this message
                    if (status == STATUS.OK)
                        status = STATUS.SMS_READ;
                }
                else
                    status = STATUS.NO_SMS;
            return status;
        }
        #endregion

        #region SMS AT CommandCPMS
        /// <summary>
        /// Read SMS
        /// </summary>
        /// <param name="index">SMS index</param>
        /// <returns>Execution STATUS</returns>
        public STATUS CommandCMGR(int index, ref string from, ref string msg)
        {
            StringBuilder sb = new StringBuilder("AT+CMGR");
            sb.AppendFormat("={0}", index);
            string atCommand = sb.ToString();
            string expectedResultError = "+CMS ERROR: 321";
            string expectedResultOK = "OK";

            string output = string.Empty;
            bool result = false;
            int tries = 0;
            bool smsReady = false;
            bool smsError = false;
            while (!result && tries < MAX_NUMBER_OF_TRIES)
            {
                output = sendData(atCommand, 5 * SEC);
                smsError = (output.IndexOf(expectedResultError) >= 0);
                smsReady = (output.IndexOf(expectedResultOK) > 0);
                result = (smsError || smsReady);
                ++tries;
            }
            STATUS status = ((result) ? STATUS.OK : STATUS.ERROR_AT_COMMAND);
            if (smsReady && !smsError)
            {
                output = output.Substring(0, output.LastIndexOf("\r\nOK"));
                int start = output.IndexOf(",\"") + 3;
                output = output.Substring(start);
                int size = output.IndexOf("\"");
                if (size >= 0)
                    from = output.Substring(0, size);
                else
                    return STATUS.ERROR_AT_COMMAND;

                start = output.IndexOf("\r\n");
                output = output.Substring(start + 2);

                msg = output;
                status = STATUS.OK;
            }
            return status;
        }
        #endregion
    }
}
