namespace canAnalyzer
{
    partial class settingsDlg
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
            this.dlgOkButton = new System.Windows.Forms.Button();
            this.dlgClButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rcvTimeout = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.transTimeout = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.deviceListCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bitrateCB = new System.Windows.Forms.ComboBox();
            this.modeGrp = new System.Windows.Forms.GroupBox();
            this.Tx_Rx_Grp = new System.Windows.Forms.GroupBox();
            this.txFilePathBrowse = new System.Windows.Forms.Button();
            this.txFilePath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.operationCont = new System.Windows.Forms.RadioButton();
            this.operationFixed = new System.Windows.Forms.RadioButton();
            this.modeTxRx = new System.Windows.Forms.RadioButton();
            this.modeRx = new System.Windows.Forms.RadioButton();
            this.txFileOpenDlg = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.modeGrp.SuspendLayout();
            this.Tx_Rx_Grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // dlgOkButton
            // 
            this.dlgOkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.dlgOkButton.Location = new System.Drawing.Point(239, 417);
            this.dlgOkButton.Name = "dlgOkButton";
            this.dlgOkButton.Size = new System.Drawing.Size(75, 25);
            this.dlgOkButton.TabIndex = 0;
            this.dlgOkButton.Text = "Ok";
            this.dlgOkButton.UseVisualStyleBackColor = true;
            this.dlgOkButton.Click += new System.EventHandler(this.dlgOkButton_Click);
            // 
            // dlgClButton
            // 
            this.dlgClButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.dlgClButton.Location = new System.Drawing.Point(139, 417);
            this.dlgClButton.Name = "dlgClButton";
            this.dlgClButton.Size = new System.Drawing.Size(75, 25);
            this.dlgClButton.TabIndex = 1;
            this.dlgClButton.Text = "Cancel";
            this.dlgClButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bitrate";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.rcvTimeout);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.transTimeout);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.deviceListCB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bitrateCB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 190);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(214, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "ms";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "ms";
            // 
            // rcvTimeout
            // 
            this.rcvTimeout.Location = new System.Drawing.Point(127, 148);
            this.rcvTimeout.Name = "rcvTimeout";
            this.rcvTimeout.Size = new System.Drawing.Size(81, 22);
            this.rcvTimeout.TabIndex = 10;
            this.rcvTimeout.Text = "2000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Rx Timeout";
            // 
            // transTimeout
            // 
            this.transTimeout.Location = new System.Drawing.Point(127, 108);
            this.transTimeout.Name = "transTimeout";
            this.transTimeout.Size = new System.Drawing.Size(81, 22);
            this.transTimeout.TabIndex = 8;
            this.transTimeout.Text = "2000";
            this.transTimeout.TextChanged += new System.EventHandler(this.validate_text);
            this.transTimeout.Validating += new System.ComponentModel.CancelEventHandler(this.validate_text);
            this.transTimeout.Validated += new System.EventHandler(this.validate_text);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tx Timeout";
            // 
            // deviceListCB
            // 
            this.deviceListCB.FormattingEnabled = true;
            this.deviceListCB.Location = new System.Drawing.Point(127, 26);
            this.deviceListCB.Name = "deviceListCB";
            this.deviceListCB.Size = new System.Drawing.Size(100, 24);
            this.deviceListCB.TabIndex = 6;
            this.deviceListCB.Text = "None";
            this.deviceListCB.DropDown += new System.EventHandler(this.comboBox1_Dropdown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Select Device";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "kbps";
            // 
            // bitrateCB
            // 
            this.bitrateCB.FormattingEnabled = true;
            this.bitrateCB.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "100",
            "250",
            "500",
            "800",
            "1000"});
            this.bitrateCB.Location = new System.Drawing.Point(127, 68);
            this.bitrateCB.Name = "bitrateCB";
            this.bitrateCB.Size = new System.Drawing.Size(81, 24);
            this.bitrateCB.TabIndex = 3;
            this.bitrateCB.Text = "500";
            // 
            // modeGrp
            // 
            this.modeGrp.Controls.Add(this.Tx_Rx_Grp);
            this.modeGrp.Controls.Add(this.modeTxRx);
            this.modeGrp.Controls.Add(this.modeRx);
            this.modeGrp.Location = new System.Drawing.Point(12, 218);
            this.modeGrp.Name = "modeGrp";
            this.modeGrp.Size = new System.Drawing.Size(302, 193);
            this.modeGrp.TabIndex = 13;
            this.modeGrp.TabStop = false;
            this.modeGrp.Text = "Mode of Operation";
            // 
            // Tx_Rx_Grp
            // 
            this.Tx_Rx_Grp.Controls.Add(this.txFilePathBrowse);
            this.Tx_Rx_Grp.Controls.Add(this.txFilePath);
            this.Tx_Rx_Grp.Controls.Add(this.label8);
            this.Tx_Rx_Grp.Controls.Add(this.operationCont);
            this.Tx_Rx_Grp.Controls.Add(this.operationFixed);
            this.Tx_Rx_Grp.Enabled = false;
            this.Tx_Rx_Grp.Location = new System.Drawing.Point(18, 57);
            this.Tx_Rx_Grp.Name = "Tx_Rx_Grp";
            this.Tx_Rx_Grp.Size = new System.Drawing.Size(267, 120);
            this.Tx_Rx_Grp.TabIndex = 16;
            this.Tx_Rx_Grp.TabStop = false;
            // 
            // txFilePathBrowse
            // 
            this.txFilePathBrowse.Location = new System.Drawing.Point(207, 72);
            this.txFilePathBrowse.Name = "txFilePathBrowse";
            this.txFilePathBrowse.Size = new System.Drawing.Size(27, 22);
            this.txFilePathBrowse.TabIndex = 19;
            this.txFilePathBrowse.UseVisualStyleBackColor = true;
            this.txFilePathBrowse.Click += new System.EventHandler(this.txFilePathBrowse_Click);
            // 
            // txFilePath
            // 
            this.txFilePath.Location = new System.Drawing.Point(14, 72);
            this.txFilePath.Name = "txFilePath";
            this.txFilePath.ReadOnly = true;
            this.txFilePath.Size = new System.Drawing.Size(185, 22);
            this.txFilePath.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(243, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Provide file path for Tx CAN message";
            // 
            // operationCont
            // 
            this.operationCont.AutoSize = true;
            this.operationCont.Location = new System.Drawing.Point(122, 12);
            this.operationCont.Name = "operationCont";
            this.operationCont.Size = new System.Drawing.Size(92, 21);
            this.operationCont.TabIndex = 16;
            this.operationCont.TabStop = true;
            this.operationCont.Text = "Continuos";
            this.operationCont.UseVisualStyleBackColor = true;
            this.operationCont.CheckedChanged += new System.EventHandler(this.operationType_Changed);
            // 
            // operationFixed
            // 
            this.operationFixed.AutoSize = true;
            this.operationFixed.Location = new System.Drawing.Point(14, 12);
            this.operationFixed.Name = "operationFixed";
            this.operationFixed.Size = new System.Drawing.Size(62, 21);
            this.operationFixed.TabIndex = 15;
            this.operationFixed.TabStop = true;
            this.operationFixed.Text = "Fixed";
            this.operationFixed.UseVisualStyleBackColor = true;
            this.operationFixed.CheckedChanged += new System.EventHandler(this.operationType_Changed);
            // 
            // modeTxRx
            // 
            this.modeTxRx.AutoSize = true;
            this.modeTxRx.Location = new System.Drawing.Point(140, 30);
            this.modeTxRx.Name = "modeTxRx";
            this.modeTxRx.Size = new System.Drawing.Size(92, 21);
            this.modeTxRx.TabIndex = 14;
            this.modeTxRx.TabStop = true;
            this.modeTxRx.Text = "Tx and Rx";
            this.modeTxRx.UseVisualStyleBackColor = true;
            this.modeTxRx.CheckedChanged += new System.EventHandler(this.modeOfOperation_CheckedChanged);
            // 
            // modeRx
            // 
            this.modeRx.AutoSize = true;
            this.modeRx.Location = new System.Drawing.Point(18, 30);
            this.modeRx.Name = "modeRx";
            this.modeRx.Size = new System.Drawing.Size(45, 21);
            this.modeRx.TabIndex = 14;
            this.modeRx.TabStop = true;
            this.modeRx.Text = "Rx";
            this.modeRx.UseVisualStyleBackColor = true;
            this.modeRx.CheckedChanged += new System.EventHandler(this.modeOfOperation_CheckedChanged);
            // 
            // txFileOpenDlg
            // 
            this.txFileOpenDlg.FileName = "openFileDialog1";
            // 
            // settingsDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 464);
            this.Controls.Add(this.modeGrp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dlgClButton);
            this.Controls.Add(this.dlgOkButton);
            this.Name = "settingsDlg";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.modeGrp.ResumeLayout(false);
            this.modeGrp.PerformLayout();
            this.Tx_Rx_Grp.ResumeLayout(false);
            this.Tx_Rx_Grp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button dlgOkButton;
        private System.Windows.Forms.Button dlgClButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox bitrateCB;
        public System.Windows.Forms.TextBox rcvTimeout;
        public System.Windows.Forms.TextBox transTimeout;
        public System.Windows.Forms.ComboBox deviceListCB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox modeGrp;
        private System.Windows.Forms.GroupBox Tx_Rx_Grp;
        private System.Windows.Forms.RadioButton operationCont;
        private System.Windows.Forms.RadioButton operationFixed;
        private System.Windows.Forms.RadioButton modeTxRx;
        private System.Windows.Forms.RadioButton modeRx;
        private System.Windows.Forms.Button txFilePathBrowse;
        private System.Windows.Forms.TextBox txFilePath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.OpenFileDialog txFileOpenDlg;
    }
}