namespace MakePhoneList
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.grpTransmitter = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.picTransmitterStatus = new System.Windows.Forms.PictureBox();
            this.labelStatusTransmiter = new System.Windows.Forms.Label();
            this.cmbComPort = new System.Windows.Forms.ComboBox();
            this.labelTransmiter = new System.Windows.Forms.Label();
            this.btnConnectTtransmitter = new System.Windows.Forms.Button();
            this.dataGridPhones = new System.Windows.Forms.DataGridView();
            this.bgwSend = new System.ComponentModel.BackgroundWorker();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingPhonesXML = new System.Windows.Forms.BindingSource(this.components);
            this.phones = new Users();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.grpTransmitter.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTransmitterStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPhones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPhonesXML)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phones)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(657, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(137, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.progressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 346);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(657, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "Status:";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(38, 17);
            this.statusLabel.Text = "Status";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 16);
            this.progressBar.Visible = false;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.Info;
            this.splitContainer.Panel1.Controls.Add(this.grpTransmitter);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dataGridPhones);
            this.splitContainer.Size = new System.Drawing.Size(657, 322);
            this.splitContainer.SplitterDistance = 265;
            this.splitContainer.TabIndex = 2;
            // 
            // grpTransmitter
            // 
            this.grpTransmitter.Controls.Add(this.tableLayoutPanel3);
            this.grpTransmitter.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTransmitter.Location = new System.Drawing.Point(0, 0);
            this.grpTransmitter.Name = "grpTransmitter";
            this.grpTransmitter.Size = new System.Drawing.Size(265, 142);
            this.grpTransmitter.TabIndex = 3;
            this.grpTransmitter.TabStop = false;
            this.grpTransmitter.Text = "Transmitter";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.17188F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.82813F));
            this.tableLayoutPanel3.Controls.Add(this.picTransmitterStatus, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelStatusTransmiter, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.cmbComPort, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelTransmiter, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnConnectTtransmitter, 0, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(259, 123);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // picTransmitterStatus
            // 
            this.picTransmitterStatus.Image = global::MakePhoneList.Properties.Resources.off;
            this.picTransmitterStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picTransmitterStatus.Location = new System.Drawing.Point(135, 40);
            this.picTransmitterStatus.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.picTransmitterStatus.Name = "picTransmitterStatus";
            this.picTransmitterStatus.Size = new System.Drawing.Size(26, 21);
            this.picTransmitterStatus.TabIndex = 10;
            this.picTransmitterStatus.TabStop = false;
            // 
            // labelStatusTransmiter
            // 
            this.labelStatusTransmiter.AutoSize = true;
            this.labelStatusTransmiter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelStatusTransmiter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelStatusTransmiter.Location = new System.Drawing.Point(3, 42);
            this.labelStatusTransmiter.Margin = new System.Windows.Forms.Padding(3, 9, 3, 0);
            this.labelStatusTransmiter.Name = "labelStatusTransmiter";
            this.labelStatusTransmiter.Size = new System.Drawing.Size(47, 13);
            this.labelStatusTransmiter.TabIndex = 9;
            this.labelStatusTransmiter.Text = "Status:";
            // 
            // cmbComPort
            // 
            this.cmbComPort.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbComPort.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbComPort.FormattingEnabled = true;
            this.cmbComPort.Location = new System.Drawing.Point(135, 3);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(100, 21);
            this.cmbComPort.TabIndex = 8;
            this.cmbComPort.SelectedIndexChanged += new System.EventHandler(this.cmbComPort_SelectedIndexChanged);
            // 
            // labelTransmiter
            // 
            this.labelTransmiter.AutoSize = true;
            this.labelTransmiter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelTransmiter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelTransmiter.Location = new System.Drawing.Point(3, 7);
            this.labelTransmiter.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.labelTransmiter.Name = "labelTransmiter";
            this.labelTransmiter.Size = new System.Drawing.Size(65, 13);
            this.labelTransmiter.TabIndex = 7;
            this.labelTransmiter.Text = "COM Port:";
            // 
            // btnConnectTtransmitter
            // 
            this.btnConnectTtransmitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnectTtransmitter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnConnectTtransmitter.Location = new System.Drawing.Point(3, 98);
            this.btnConnectTtransmitter.Name = "btnConnectTtransmitter";
            this.btnConnectTtransmitter.Size = new System.Drawing.Size(126, 22);
            this.btnConnectTtransmitter.TabIndex = 11;
            this.btnConnectTtransmitter.Text = "&Send";
            this.btnConnectTtransmitter.UseVisualStyleBackColor = true;
            this.btnConnectTtransmitter.Click += new System.EventHandler(this.btnConnectTtransmitter_Click);
            // 
            // dataGridPhones
            // 
            this.dataGridPhones.AllowUserToOrderColumns = true;
            this.dataGridPhones.AutoGenerateColumns = false;
            this.dataGridPhones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPhones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userIDDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.dataGridPhones.DataSource = this.bindingPhonesXML;
            this.dataGridPhones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPhones.Location = new System.Drawing.Point(0, 0);
            this.dataGridPhones.Name = "dataGridPhones";
            this.dataGridPhones.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridPhones.Size = new System.Drawing.Size(388, 322);
            this.dataGridPhones.TabIndex = 0;
            this.dataGridPhones.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridPhones_DataError);
            // 
            // bgwSend
            // 
            this.bgwSend.WorkerReportsProgress = true;
            this.bgwSend.WorkerSupportsCancellation = true;
            this.bgwSend.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSend_DoWork);
            this.bgwSend.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSend_RunWorkerCompleted);
            this.bgwSend.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwSend_ProgressChanged);
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "UserID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "UserID";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            this.userIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.userIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
            this.phoneDataGridViewTextBoxColumn.MaxInputLength = 20;
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MaxInputLength = 20;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ToolTipText = "The name can\'t be blank";
            // 
            // bindingPhonesXML
            // 
            this.bindingPhonesXML.DataMember = "User";
            this.bindingPhonesXML.DataSource = this.phones;
            // 
            // phones
            // 
            this.phones.DataSetName = "Users";
            this.phones.Locale = new System.Globalization.CultureInfo("en");
            this.phones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 368);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.Text = "Make Phone List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.grpTransmitter.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTransmitterStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPhones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPhonesXML)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox grpTransmitter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PictureBox picTransmitterStatus;
        private System.Windows.Forms.Label labelStatusTransmiter;
        private System.Windows.Forms.ComboBox cmbComPort;
        private System.Windows.Forms.Label labelTransmiter;
        private System.Windows.Forms.Button btnConnectTtransmitter;
        private System.Windows.Forms.DataGridView dataGridPhones;
        private System.Windows.Forms.BindingSource bindingPhonesXML;
        private Users phones;
        private System.ComponentModel.BackgroundWorker bgwSend;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    }
}

