using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lawicel;
using System.Diagnostics;

namespace canAnalyzer
{
    public partial class settingsDlg : Form
    {
        public String strCanFrameFilePath;
        public String strMode;
        public String strOperation;
        public int iTxTimeout;
        public int iRxTimeout;
        public settingsDlg(string devicename, int bitrate, string mode, string operation, int iTxTimeout, int iRxTimeout)
        {
            InitializeComponent();
            if (mode == "Rx")
            {
                modeRx.Select();
                Tx_Rx_Grp.Enabled = false;
            }
            else
            {
                modeTxRx.Select();
                Tx_Rx_Grp.Enabled = true;
            }
            if (operation == "Fixed")
            {
                operationFixed.Select();
            }
            else
            {
                operationCont.Select();
            }
            bitrateCB.Text = bitrateCB.Items[bitrate].ToString();
            deviceListCB.Text = devicename;
            transTimeout.Text = iTxTimeout.ToString();
            rcvTimeout.Text = iRxTimeout.ToString();
        }

        private void comboBox1_Dropdown(object sender, EventArgs e)
        {
            StringBuilder buf = new StringBuilder(32);
            int i, cnt;
            this.deviceListCB.Items.Clear();

            // Fill the listbox with data
            cnt = CANUSB.canusb_getFirstAdapter(buf, 32);
            this.deviceListCB.Items.Add(buf);
            for (i = 1; i < cnt; i++)
            {
                if (CANUSB.canusb_getNextAdapter(buf, 32) > 0)
                {
                    this.deviceListCB.Items.Add(buf);
                }
            }
        }
        private RadioButton GetCheckedRadio(Control container)
        {
            foreach (var control in container.Controls)
            {
                RadioButton radio = control as RadioButton;
                if (radio != null && radio.Checked)
                {
                    return radio;
                }
            }

            return null;
        }
        private void modeOfOperation_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            strMode = radio.Text;
            switch (radio.Text )
            {
                case "Rx":
                    Tx_Rx_Grp.Enabled = false;
                    break;
                case "Tx and Rx":
                    Tx_Rx_Grp.Enabled = true;
                    break;
            }
        }

        private void txFilePathBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = txFileOpenDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                strCanFrameFilePath = txFileOpenDlg.FileName;
                txFilePath.Text = txFileOpenDlg.FileName;
            }
            
        }

       private void operationType_Changed(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            Debug.WriteLine("radio.Text=" + radio.Text);
            strOperation = radio.Text;
        }

       private void validate_text(object sender, EventArgs e)
       {
        
       }

       private void dlgOkButton_Click(object sender, EventArgs e)
       {
           bool iserror = false;
           string error ="Invalid timeout entered";

           if ((System.Text.RegularExpressions.Regex.IsMatch(transTimeout.Text, @"\A\b[0-9]+\b\Z")) == false)
           {
               Debug.WriteLine("Conatins invalid value");
               error += " For TX(" + transTimeout.Text + ")";
               iTxTimeout = 2000;
               iserror = true;
           }
           else
           {
               iTxTimeout = int.Parse(transTimeout.Text);
           }
           if ((System.Text.RegularExpressions.Regex.IsMatch(rcvTimeout.Text, @"\A\b[0-9]+\b\Z")) == false)
           {
               Debug.WriteLine("Conatins invalid value");
               if (iserror == true)
                   error += " and";
               error += " For RX(" + rcvTimeout.Text + ")";
               iserror = true;
               iRxTimeout = 2000;
           }
           else
           {
               iRxTimeout = int.Parse(rcvTimeout.Text);
           }
           error += ", Setting to default (2000)";
           if (iserror == true)
               MessageBox.Show(error);           
       }
    }
}
