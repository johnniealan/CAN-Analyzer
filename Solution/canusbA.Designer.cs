namespace WindowsFormsApplication2
{
    partial class CANUSB_A
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
            System.Windows.Forms.ColumnHeader dummp;
            this.canUsbMnu = new System.Windows.Forms.MenuStrip();
            this.canusbFileMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMnuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.canusbCaptureMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.captureStartMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.captureClearMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.captureStopMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.captureSettingMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.canusbHelpMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpAboutMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.canMsgView = new System.Windows.Forms.ListView();
            this.msgTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.msgDirect = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.msgHeaderFormat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.msgID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.msgLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.msgData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.msgFrameType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.saveMsgDlg = new System.Windows.Forms.SaveFileDialog();
            this.canUsbStatus = new System.Windows.Forms.StatusStrip();
            this.statusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.openTxMsg = new System.Windows.Forms.OpenFileDialog();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            dummp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.canUsbMnu.SuspendLayout();
            this.canUsbStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // dummp
            // 
            dummp.Text = "";
            dummp.Width = 0;
            // 
            // canUsbMnu
            // 
            this.canUsbMnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.canusbFileMnu,
            this.canusbCaptureMnu,
            this.canusbHelpMnu});
            this.canUsbMnu.Location = new System.Drawing.Point(0, 0);
            this.canUsbMnu.Name = "canUsbMnu";
            this.canUsbMnu.Size = new System.Drawing.Size(925, 28);
            this.canUsbMnu.TabIndex = 0;
            this.canUsbMnu.Text = "menuStrip1";
            // 
            // canusbFileMnu
            // 
            this.canusbFileMnu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMnuSave,
            this.fileMnuQuit});
            this.canusbFileMnu.Name = "canusbFileMnu";
            this.canusbFileMnu.Size = new System.Drawing.Size(44, 24);
            this.canusbFileMnu.Text = "File";
            // 
            // fileMnuSave
            // 
            this.fileMnuSave.Name = "fileMnuSave";
            this.fileMnuSave.Size = new System.Drawing.Size(109, 24);
            this.fileMnuSave.Text = "Save";
            this.fileMnuSave.Click += new System.EventHandler(this.fileMnuSave_Click);
            // 
            // fileMnuQuit
            // 
            this.fileMnuQuit.Name = "fileMnuQuit";
            this.fileMnuQuit.Size = new System.Drawing.Size(109, 24);
            this.fileMnuQuit.Text = "Quit";
            this.fileMnuQuit.Click += new System.EventHandler(this.fileMnuQuit_Click);
            // 
            // canusbCaptureMnu
            // 
            this.canusbCaptureMnu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.captureStartMnu,
            this.captureClearMnu,
            this.captureStopMnu,
            this.captureSettingMnu});
            this.canusbCaptureMnu.Name = "canusbCaptureMnu";
            this.canusbCaptureMnu.Size = new System.Drawing.Size(73, 24);
            this.canusbCaptureMnu.Text = "Capture";
            // 
            // captureStartMnu
            // 
            this.captureStartMnu.Name = "captureStartMnu";
            this.captureStartMnu.Size = new System.Drawing.Size(131, 24);
            this.captureStartMnu.Text = "Start";
            this.captureStartMnu.Click += new System.EventHandler(this.captureStartMnu_Click);
            // 
            // captureClearMnu
            // 
            this.captureClearMnu.Name = "captureClearMnu";
            this.captureClearMnu.Size = new System.Drawing.Size(131, 24);
            this.captureClearMnu.Text = "Clear";
            this.captureClearMnu.Click += new System.EventHandler(this.captureClearMnu_Click);
            // 
            // captureStopMnu
            // 
            this.captureStopMnu.Name = "captureStopMnu";
            this.captureStopMnu.Size = new System.Drawing.Size(131, 24);
            this.captureStopMnu.Text = "Stop";
            this.captureStopMnu.Click += new System.EventHandler(this.captureStopMnu_Click);
            // 
            // captureSettingMnu
            // 
            this.captureSettingMnu.Name = "captureSettingMnu";
            this.captureSettingMnu.Size = new System.Drawing.Size(131, 24);
            this.captureSettingMnu.Text = "Settings";
            this.captureSettingMnu.Click += new System.EventHandler(this.captureSettingMnu_Click);
            // 
            // canusbHelpMnu
            // 
            this.canusbHelpMnu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpAboutMnu});
            this.canusbHelpMnu.Name = "canusbHelpMnu";
            this.canusbHelpMnu.Size = new System.Drawing.Size(53, 24);
            this.canusbHelpMnu.Text = "Help";
            // 
            // helpAboutMnu
            // 
            this.helpAboutMnu.Name = "helpAboutMnu";
            this.helpAboutMnu.Size = new System.Drawing.Size(119, 24);
            this.helpAboutMnu.Text = "About";
            this.helpAboutMnu.Click += new System.EventHandler(this.helpAboutMnu_Click);
            // 
            // canMsgView
            // 
            this.canMsgView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.canMsgView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            dummp,
            this.msgTime,
            this.msgDirect,
            this.msgHeaderFormat,
            this.msgID,
            this.msgLength,
            this.msgData,
            this.msgFrameType});
            this.canMsgView.GridLines = true;
            this.canMsgView.Location = new System.Drawing.Point(0, 31);
            this.canMsgView.Name = "canMsgView";
            this.canMsgView.Size = new System.Drawing.Size(925, 386);
            this.canMsgView.TabIndex = 1;
            this.canMsgView.UseCompatibleStateImageBehavior = false;
            this.canMsgView.View = System.Windows.Forms.View.Details;
            this.canMsgView.SelectedIndexChanged += new System.EventHandler(this.canMsgView_SelectedIndexChanged);
            this.canMsgView.SizeChanged += new System.EventHandler(this.listView1_ClientSizeChanged);
            // 
            // msgTime
            // 
            this.msgTime.Text = "Time Stamp";
            this.msgTime.Width = 92;
            // 
            // msgDirect
            // 
            this.msgDirect.Text = "Direction";
            this.msgDirect.Width = 65;
            // 
            // msgHeaderFormat
            // 
            this.msgHeaderFormat.Text = "Format";
            // 
            // msgID
            // 
            this.msgID.Text = "ID";
            this.msgID.Width = 157;
            // 
            // msgLength
            // 
            this.msgLength.Text = "Length";
            // 
            // msgData
            // 
            this.msgData.Text = "Data";
            this.msgData.Width = 440;
            // 
            // msgFrameType
            // 
            this.msgFrameType.Text = "Type";
            // 
            // saveMsgDlg
            // 
            this.saveMsgDlg.Title = "Save CAN message";
            // 
            // canUsbStatus
            // 
            this.canUsbStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusText,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.canUsbStatus.Location = new System.Drawing.Point(0, 413);
            this.canUsbStatus.Name = "canUsbStatus";
            this.canUsbStatus.Size = new System.Drawing.Size(925, 29);
            this.canUsbStatus.TabIndex = 3;
            this.canUsbStatus.Text = "statusStrip1";
            // 
            // statusText
            // 
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(183, 24);
            this.statusText.Text = "Welcome to CAN analyzer";
            // 
            // openTxMsg
            // 
            this.openTxMsg.FileName = "CAN Tx Message";
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            this.eventLog1.EntryWritten += new System.Diagnostics.EntryWrittenEventHandler(this.eventLog1_EntryWritten);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(206, 24);
            this.toolStripStatusLabel2.Text = "Developed By Johnnie J. Alan";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(517, 24);
            this.toolStripStatusLabel1.Text = "                                                                                 " +
                "                                              ";
            // 
            // CANUSB_A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 442);
            this.Controls.Add(this.canUsbStatus);
            this.Controls.Add(this.canMsgView);
            this.Controls.Add(this.canUsbMnu);
            this.MainMenuStrip = this.canUsbMnu;
            this.Name = "CANUSB_A";
            this.Text = "CANUSB";
            this.canUsbMnu.ResumeLayout(false);
            this.canUsbMnu.PerformLayout();
            this.canUsbStatus.ResumeLayout(false);
            this.canUsbStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip canUsbMnu;
        private System.Windows.Forms.ToolStripMenuItem canusbFileMnu;
        private System.Windows.Forms.ToolStripMenuItem fileMnuSave;
        private System.Windows.Forms.ToolStripMenuItem fileMnuQuit;
        private System.Windows.Forms.ToolStripMenuItem canusbCaptureMnu;
        private System.Windows.Forms.ToolStripMenuItem captureStartMnu;
        private System.Windows.Forms.ToolStripMenuItem captureClearMnu;
        private System.Windows.Forms.ToolStripMenuItem captureStopMnu;
        private System.Windows.Forms.ToolStripMenuItem captureSettingMnu;
        private System.Windows.Forms.ToolStripMenuItem canusbHelpMnu;
        private System.Windows.Forms.ToolStripMenuItem helpAboutMnu;
        private System.Windows.Forms.ListView canMsgView;
        private System.Windows.Forms.ColumnHeader msgHeaderFormat;
        private System.Windows.Forms.ColumnHeader msgID;
        private System.Windows.Forms.ColumnHeader msgLength;
        private System.Windows.Forms.ColumnHeader msgData;
        private System.Windows.Forms.ColumnHeader msgFrameType;
        private System.Windows.Forms.ColumnHeader msgDirect;
        private System.Windows.Forms.SaveFileDialog saveMsgDlg;
        private System.Windows.Forms.StatusStrip canUsbStatus;
        private System.Windows.Forms.ToolStripStatusLabel statusText;
        private System.Windows.Forms.OpenFileDialog openTxMsg;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.ColumnHeader msgTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

