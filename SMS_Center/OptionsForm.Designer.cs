namespace SMS_Center
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitButtons = new System.Windows.Forms.SplitContainer();
            this.splitOptions = new System.Windows.Forms.SplitContainer();
            this.grpURL = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.picErrorInputURL = new System.Windows.Forms.PictureBox();
            this.chkAutoConnect = new System.Windows.Forms.CheckBox();
            this.cmbHTTP_METHOD = new System.Windows.Forms.ComboBox();
            this.grpModem = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picErrorTimeout = new System.Windows.Forms.PictureBox();
            this.cboBaud = new System.Windows.Forms.ComboBox();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.cboStop = new System.Windows.Forms.ComboBox();
            this.cboData = new System.Windows.Forms.ComboBox();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.splitButtons.Panel1.SuspendLayout();
            this.splitButtons.Panel2.SuspendLayout();
            this.splitButtons.SuspendLayout();
            this.splitOptions.Panel1.SuspendLayout();
            this.splitOptions.Panel2.SuspendLayout();
            this.splitOptions.SuspendLayout();
            this.grpURL.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorInputURL)).BeginInit();
            this.grpModem.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorTimeout)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitButtons
            // 
            this.splitButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitButtons.Location = new System.Drawing.Point(0, 0);
            this.splitButtons.Name = "splitButtons";
            this.splitButtons.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitButtons.Panel1
            // 
            this.splitButtons.Panel1.Controls.Add(this.splitOptions);
            // 
            // splitButtons.Panel2
            // 
            this.splitButtons.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitButtons.Size = new System.Drawing.Size(587, 355);
            this.splitButtons.SplitterDistance = 318;
            this.splitButtons.TabIndex = 0;
            this.splitButtons.TabStop = false;
            // 
            // splitOptions
            // 
            this.splitOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitOptions.Location = new System.Drawing.Point(0, 0);
            this.splitOptions.Name = "splitOptions";
            this.splitOptions.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitOptions.Panel1
            // 
            this.splitOptions.Panel1.Controls.Add(this.grpURL);
            // 
            // splitOptions.Panel2
            // 
            this.splitOptions.Panel2.Controls.Add(this.grpModem);
            this.splitOptions.Size = new System.Drawing.Size(587, 318);
            this.splitOptions.SplitterDistance = 117;
            this.splitOptions.TabIndex = 1;
            this.splitOptions.TabStop = false;
            // 
            // grpURL
            // 
            this.grpURL.Controls.Add(this.tableLayoutPanel2);
            this.grpURL.Location = new System.Drawing.Point(12, 12);
            this.grpURL.Name = "grpURL";
            this.grpURL.Size = new System.Drawing.Size(564, 98);
            this.grpURL.TabIndex = 0;
            this.grpURL.TabStop = false;
            this.grpURL.Text = "SMS Server Settings";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.48438F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.51563F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtURL, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.picErrorInputURL, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkAutoConnect, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.cmbHTTP_METHOD, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(558, 79);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(48, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "Method:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(68, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL:";
            // 
            // txtURL
            // 
            this.txtURL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtURL.Location = new System.Drawing.Point(113, 3);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(395, 20);
            this.txtURL.TabIndex = 0;
            this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
            // 
            // picErrorInputURL
            // 
            this.picErrorInputURL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picErrorInputURL.Image = global::SMS_Center.Resource.error;
            this.picErrorInputURL.Location = new System.Drawing.Point(518, 3);
            this.picErrorInputURL.Name = "picErrorInputURL";
            this.picErrorInputURL.Size = new System.Drawing.Size(32, 19);
            this.picErrorInputURL.TabIndex = 7;
            this.picErrorInputURL.TabStop = false;
            this.picErrorInputURL.Visible = false;
            // 
            // chkAutoConnect
            // 
            this.chkAutoConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAutoConnect.AutoSize = true;
            this.chkAutoConnect.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAutoConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.chkAutoConnect.Location = new System.Drawing.Point(113, 58);
            this.chkAutoConnect.Name = "chkAutoConnect";
            this.chkAutoConnect.Size = new System.Drawing.Size(262, 19);
            this.chkAutoConnect.TabIndex = 2;
            this.chkAutoConnect.Text = "Auto Connect when application starts";
            this.chkAutoConnect.UseVisualStyleBackColor = true;
            // 
            // cmbHTTP_METHOD
            // 
            this.cmbHTTP_METHOD.FormattingEnabled = true;
            this.cmbHTTP_METHOD.Items.AddRange(new object[] {
            "POST",
            "GET"});
            this.cmbHTTP_METHOD.Location = new System.Drawing.Point(113, 28);
            this.cmbHTTP_METHOD.Name = "cmbHTTP_METHOD";
            this.cmbHTTP_METHOD.Size = new System.Drawing.Size(96, 21);
            this.cmbHTTP_METHOD.TabIndex = 1;
            // 
            // grpModem
            // 
            this.grpModem.Controls.Add(this.tableLayoutPanel3);
            this.grpModem.Location = new System.Drawing.Point(15, 12);
            this.grpModem.Name = "grpModem";
            this.grpModem.Size = new System.Drawing.Size(561, 176);
            this.grpModem.TabIndex = 0;
            this.grpModem.TabStop = false;
            this.grpModem.Text = "Modem Settings";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.08108F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.91892F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.picErrorTimeout, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.cboBaud, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.cboParity, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.cboStop, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.cboData, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtTimeout, 1, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(555, 157);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(11, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "SMS timeout:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(36, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Stop Bits:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(35, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Data Bits:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(57, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Parity:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(30, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "BaudRate:";
            // 
            // picErrorTimeout
            // 
            this.picErrorTimeout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picErrorTimeout.Image = global::SMS_Center.Resource.error;
            this.picErrorTimeout.Location = new System.Drawing.Point(511, 127);
            this.picErrorTimeout.Name = "picErrorTimeout";
            this.picErrorTimeout.Size = new System.Drawing.Size(41, 27);
            this.picErrorTimeout.TabIndex = 14;
            this.picErrorTimeout.TabStop = false;
            this.picErrorTimeout.Visible = false;
            // 
            // cboBaud
            // 
            this.cboBaud.FormattingEnabled = true;
            this.cboBaud.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "28800",
            "36000",
            "115000"});
            this.cboBaud.Location = new System.Drawing.Point(110, 3);
            this.cboBaud.Name = "cboBaud";
            this.cboBaud.Size = new System.Drawing.Size(121, 21);
            this.cboBaud.TabIndex = 0;
            // 
            // cboParity
            // 
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Location = new System.Drawing.Point(110, 34);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(121, 21);
            this.cboParity.TabIndex = 1;
            // 
            // cboStop
            // 
            this.cboStop.FormattingEnabled = true;
            this.cboStop.Location = new System.Drawing.Point(110, 96);
            this.cboStop.Name = "cboStop";
            this.cboStop.Size = new System.Drawing.Size(121, 21);
            this.cboStop.TabIndex = 3;
            // 
            // cboData
            // 
            this.cboData.FormattingEnabled = true;
            this.cboData.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cboData.Location = new System.Drawing.Point(110, 65);
            this.cboData.Name = "cboData";
            this.cboData.Size = new System.Drawing.Size(121, 21);
            this.cboData.TabIndex = 2;
            // 
            // txtTimeout
            // 
            this.txtTimeout.Location = new System.Drawing.Point(110, 127);
            this.txtTimeout.MaxLength = 10;
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(121, 20);
            this.txtTimeout.TabIndex = 4;
            this.txtTimeout.TextChanged += new System.EventHandler(this.txtTimeout_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(587, 33);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(109, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(402, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(587, 355);
            this.Controls.Add(this.splitButtons);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.splitButtons.Panel1.ResumeLayout(false);
            this.splitButtons.Panel2.ResumeLayout(false);
            this.splitButtons.ResumeLayout(false);
            this.splitOptions.Panel1.ResumeLayout(false);
            this.splitOptions.Panel2.ResumeLayout(false);
            this.splitOptions.ResumeLayout(false);
            this.grpURL.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorInputURL)).EndInit();
            this.grpModem.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picErrorTimeout)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitButtons;
        private System.Windows.Forms.GroupBox grpURL;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.CheckBox chkAutoConnect;
        private System.Windows.Forms.PictureBox picErrorInputURL;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.ComboBox cboStop;
        private System.Windows.Forms.ComboBox cboData;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.ComboBox cmbHTTP_METHOD;
        private System.Windows.Forms.SplitContainer splitOptions;
        private System.Windows.Forms.GroupBox grpModem;
        private System.Windows.Forms.PictureBox picErrorTimeout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboBaud;
        private System.Windows.Forms.Label label7;
    }
}