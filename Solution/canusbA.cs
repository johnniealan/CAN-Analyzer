using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using canAnalyzer;
using Lawicel;
using System.Threading;
using System.Diagnostics;

namespace WindowsFormsApplication2
{
    public partial class CANUSB_A : Form
    {
        enum opsMode{
            RECEIVE_ONLY_MODE = 1,
            TX_RX_FILE_FIXED,
            TX_RX_FILE_CONT
        };
        struct cfgCan_t
        {
            public string deviceName;
            public string bitrate;
            public opsMode userMode;
            public int txTimeout;
            public int rxTimeout;
            public uint handle;
        };
        struct cfgTxFrame_t
        {
            public CANUSB.CANMsg canTxMsg;
            public string ID;
            public string data;
        };
        double msgTimeCalc;
        double msgDirectionCalc;
        double msgHeaderFormatCalc;
        double msgIDCalc;
        double msgLengthCalc;
        double msgDataCalc;
        double msgFrameTypeCalc;
        string str;  
        cfgCan_t canConfiguration;
        CANUSB.CANMsg rcvdCanMsg;
        CANUSB.CANMsg sentCanMsg;
        cfgTxFrame_t []canTxMsg;
        private BackgroundWorker canMessageBck;

        private string strCanFrameFilePath ;
        private string strCanMode;
        private string strCanOperation;
        private int iSelectedIndex;
        private bool bInfinite;
        private string parseErrorString;
        private int waitAnyMessage(int timeout, out CANUSB.CANMsg r_canMsg)
        {
            int readResult = 0;
            int nrOfWait = 0;
            while (nrOfWait < timeout)
            {
                readResult = CANUSB.canusb_Read(canConfiguration.handle, out r_canMsg);
                if (readResult == CANUSB.ERROR_CANUSB_OK)
                {
                    return 1;
                }
                else if (readResult == CANUSB.ERROR_CANUSB_NO_MESSAGE)
                {
                    Thread.Sleep(1);
                    nrOfWait++;
                }
            }
            r_canMsg = new CANUSB.CANMsg();
            return 0;
        }
        private void canMessageBck_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (canConfiguration.userMode == opsMode.RECEIVE_ONLY_MODE ||
                canConfiguration.userMode == opsMode.TX_RX_FILE_CONT)
            {
                bInfinite = true;
            }

            //obj1.canMsgView.Items.Add(row);
            worker.ReportProgress(1);
            
            do
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                switch (canConfiguration.userMode)
                {
                    case opsMode.RECEIVE_ONLY_MODE:
                    {
                           int rv = CANUSB.canusb_Read(canConfiguration.handle, out rcvdCanMsg);
                            
                            if (CANUSB.ERROR_CANUSB_OK == rv)
                            {
                                worker.ReportProgress(2);
                            }
                            else if (CANUSB.ERROR_CANUSB_NO_MESSAGE == rv)
                            {
                                str = "No Message to read";
                            }
                            else if (CANUSB.ERROR_CANUSB_INVALID_HARDWARE == rv)
                            {
                                str = "**** Invalid Hardware ****";
                                e.Result = "error";
                                break;
                            }
                            else
                            {
                                str = "**** Failed to read message. ****";
                                //  worker.ReportProgress(1);
                            }
                    }
                    break;
                    case opsMode.TX_RX_FILE_CONT:
                    case opsMode.TX_RX_FILE_FIXED:
                    {
                            for (int i = 0; i < canTxMsg.Count(); i++)
                            {
                                CANUSB.canusb_SetTimeouts(canConfiguration.handle, (uint)canConfiguration.txTimeout, (uint)canConfiguration.rxTimeout);
                                int rv = CANUSB.canusb_Write(canConfiguration.handle, ref canTxMsg[i].canTxMsg);
                                sentCanMsg = canTxMsg[i].canTxMsg;
                                if (CANUSB.ERROR_CANUSB_OK == rv)
                                {
                                    worker.ReportProgress(3);
                                    Thread.Sleep(700);
                                    int ret = waitAnyMessage(canConfiguration.rxTimeout, out rcvdCanMsg);
                                    if (ret != 0 )
                                    {
                                        worker.ReportProgress(2);
                                        Thread.Sleep(700);
                                    }
                                    else if (ret == 0)
                                    {
                                        str = "Error";
                                    }                              
                                }
                                else
                                {
                                    str = "**** Failed to write message. ****";
                                    //  worker.ReportProgress(1);
                                }
                            }
                       
                    }
                    break;
                }
            } while (bInfinite);
        }

        private void canMessageBck_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statusText.Text = str; 
            ListViewItem row = new ListViewItem();
            string[] itemStr = new string[7];
            CANUSB.CANMsg msg = new CANUSB.CANMsg();
            itemStr[0] = DateTime.Now.ToString("dd-HH:mm:ss");
            if (e.ProgressPercentage == 2)
            {
                itemStr[1] = "IN";
                msg = rcvdCanMsg;
            }
            else if (e.ProgressPercentage == 3)
            {
                msg = sentCanMsg;
                itemStr[1] = "OUT";
            }
            else
            {
                return;
            }
            itemStr[3] = msg.id.ToString("X8");
            itemStr[4] = msg.len.ToString();

            for (int i = 0; i < msg.len; i++) // Data Frame
            {
                itemStr[5] += "0x" + ((byte)(msg.data >> i * 8)).ToString("X2") + " ";
            }
            if (msg.len == 0)
            {
                itemStr[5] = "<null>";
            }
            if (0 != (msg.flags & CANUSB.CANMSG_EXTENDED))
            {
                itemStr[2] = "29 Bit";
                itemStr[6] = "Extended";
            }
            else
            {
                itemStr[2] = "11 Bit";
            }
            if (0 != (msg.flags & CANUSB.CANMSG_RTR))
            {
                itemStr[6] = "RTR";
            }
            row.SubItems.AddRange(itemStr);
            canMsgView.Items.Add(row);

        }

        // This event handler deals with the results of the background operation.
        private void canMessageBck_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                statusText.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                statusText.Text = "Error: " + e.Error.Message;
            }
            else
            {
                statusText.Text = "Done!";
            }
            closeCan();
        }

        public CANUSB_A()
        {
            InitializeComponent();
            this.msgTimeCalc = (double)this.msgTime.Width / this.canMsgView.Width;
            this.msgDirectionCalc = (double)this.msgDirect.Width / this.canMsgView.Width;      
            this.msgHeaderFormatCalc = (double)this.msgHeaderFormat.Width / this.canMsgView.Width;
            this.msgIDCalc = (double)this.msgID.Width / this.canMsgView.Width;
            this.msgLengthCalc = (double)this.msgLength.Width / this.canMsgView.Width;
            this.msgDataCalc = (double)this.msgData.Width / this.canMsgView.Width;
            this.msgFrameTypeCalc = (double)this.msgFrameType.Width / this.canMsgView.Width;
            this.captureStopMnu.Enabled = false;

            strCanFrameFilePath = "";
            strCanMode = "Rx";
            strCanOperation = "Fixed";
            iSelectedIndex = 0;
            bInfinite = false;
            canConfiguration.txTimeout = 2000;
            canConfiguration.rxTimeout = 2000;
            // Back ground task for read and write
            canMessageBck = new System.ComponentModel.BackgroundWorker();
            canMessageBck.WorkerReportsProgress = true;
            canMessageBck.WorkerSupportsCancellation = true;
            canMessageBck.DoWork += 
                new DoWorkEventHandler(canMessageBck_DoWork);
            canMessageBck.RunWorkerCompleted += 
                new RunWorkerCompletedEventHandler(
            canMessageBck_RunWorkerCompleted);
            canMessageBck.ProgressChanged += 
                new ProgressChangedEventHandler(
            canMessageBck_ProgressChanged);

        }
        private void listView1_ClientSizeChanged(object sender, EventArgs e)
        {
            double d1 = this.msgDirectionCalc * this.canMsgView.Width;
            double d2 = this.msgHeaderFormatCalc * this.canMsgView.Width;
            double d3 = this.msgIDCalc * this.canMsgView.Width;
            double d4 = this.msgLengthCalc * this.canMsgView.Width;
            double d5 = this.msgDataCalc * this.canMsgView.Width;
            double d6 = this.msgFrameTypeCalc * this.canMsgView.Width;
            double d7 = this.msgTimeCalc * this.canMsgView.Width;

            this.msgDirect.Width = Convert.ToInt32(d1);
            this.msgHeaderFormat.Width = Convert.ToInt32(d2);
            this.msgID.Width = Convert.ToInt32(d3);
            this.msgLength.Width = Convert.ToInt32(d4);
            this.msgData.Width = Convert.ToInt32(d5);
            this.msgFrameType.Width = Convert.ToInt32(d6);
            this.msgTime.Width = Convert.ToInt32(d7);
            Debug.WriteLine("Resize");
        }

        private void captureSettingMnu_Click(object sender, EventArgs e)
        {
            string input ="g";
            using (settingsDlg dialog = new settingsDlg(canConfiguration.deviceName, iSelectedIndex, strCanMode, strCanOperation, canConfiguration.txTimeout, canConfiguration.rxTimeout))
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Get all information
                    strCanFrameFilePath = dialog.strCanFrameFilePath;
                    strCanMode = dialog.strMode;
                    strCanOperation = dialog.strOperation;
                    iSelectedIndex = dialog.bitrateCB.SelectedIndex;
                    Debug.WriteLine("strCanMode =" + strCanMode);
                    Debug.WriteLine("strCanOperation =" + strCanOperation);
                    Debug.WriteLine("iSelectedIndex =" + iSelectedIndex);
                    canConfiguration.txTimeout = dialog.iTxTimeout;
                    canConfiguration.rxTimeout = dialog.iRxTimeout;
                    if ((strCanMode == "Tx and Rx") && (strCanFrameFilePath != null))
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(dialog.strCanFrameFilePath))
                        {
                            input = sr.ReadToEnd();
                            sr.Close();
                        }
                        if (parseFile(input) == false)
                        {
                            parseErrorString += "\nPlease check the contents of  " + dialog.strCanFrameFilePath;
                            MessageBox.Show(parseErrorString);
                            return;
                        }
                    }
                    else if ( (strCanMode == "Tx and Rx") && (strCanFrameFilePath == null) )
                    {
                        string str = "No file path provided";
                        MessageBox.Show(str);
                        return;
                    }
                    //canConfiguration.deviceName = "XXXXXXXX";
                   
                    if (dialog.deviceListCB.SelectedIndex >= 0)
                    {
                        canConfiguration.deviceName = dialog.deviceListCB.Items[dialog.deviceListCB.SelectedIndex].ToString();
                    }
                    canConfiguration.bitrate = dialog.bitrateCB.Items[dialog.bitrateCB.SelectedIndex].ToString();
                }
            }
        }

        private void fileMnuSave_Click(object sender, EventArgs e)
        {
            DialogResult result = saveMsgDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(saveMsgDlg.FileName))
                {
                    foreach (ListViewItem item in canMsgView.Items)
                    {
                        sw.WriteLine("{0}:{1}:{2}:{3}:{4}", item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text,
                            item.SubItems[4].Text, item.SubItems[5].Text);
                    }
                    statusText.Text = "Dumping CAN message in File";
                    sw.Close();
                }
            }
            statusText.Text = "";
        }

        private void captureClearMnu_Click(object sender, EventArgs e)
        {
            this.canMsgView.Items.Clear();
        }

        private void captureStartMnu_Click(object sender, EventArgs e)
        {
            canConfiguration.handle = CANUSB.canusb_Open(canConfiguration.deviceName,
                                               canConfiguration.bitrate,
                                               CANUSB.CANUSB_ACCEPTANCE_CODE_ALL,
                                               CANUSB.CANUSB_ACCEPTANCE_MASK_ALL,
                                               CANUSB.CANUSB_FLAG_TIMESTAMP);
            if (canConfiguration.handle == 0)
            {
                string str = "Unable to open " + canConfiguration.deviceName + "For bitrate" + canConfiguration.bitrate;
                MessageBox.Show(str);
                statusText.Text = "Check if CAN USB is connected";
                return;
            }
            statusText.Text = "CAN USB successfully opened for " + canConfiguration.deviceName + " Bitrate = " + canConfiguration.bitrate + " Kbps";
            this.captureStartMnu.Enabled = false;
            this.captureStopMnu.Enabled = true;
            this.captureSettingMnu.Enabled = false;
            this.fileMnuSave.Enabled = false;
            if (strCanMode == "Rx")
            {
                this.canConfiguration.userMode = opsMode.RECEIVE_ONLY_MODE;
            }
            else
            {
                if (strCanOperation == "Fixed")
                {
                    bInfinite = false;
                    statusText.Text = "Running in Fixed file mode";
                    this.canConfiguration.userMode = opsMode.TX_RX_FILE_FIXED;
                }
                else
                {
                    this.canConfiguration.userMode = opsMode.TX_RX_FILE_CONT;
                }
            }
           
            if (canMessageBck.IsBusy != true)
            {
                canMessageBck.RunWorkerAsync();
            }
        }
        private void closeCan()
        {
            int res = CANUSB.canusb_Close(canConfiguration.handle);
            if (CANUSB.ERROR_CANUSB_OK == res)
            {
                statusText.Text = "Closed OK";
            }
            else
            {
                statusText.Text = "Failed to Close CANUSB";
            }
            canConfiguration.handle = 0;
            this.captureStartMnu.Enabled = true;
            this.captureSettingMnu.Enabled = true;
            this.captureStopMnu.Enabled = false;
            this.fileMnuSave.Enabled = true;

        }
        private void captureStopMnu_Click(object sender, EventArgs e)
        {
            if (canMessageBck.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                canMessageBck.CancelAsync();
            }
        }

        private void helpAboutMnu_Click(object sender, EventArgs e)
        {
            AboutBox1 abtDlg = new AboutBox1();
            abtDlg.ShowDialog();
        }
        private bool OnlyHexInString(string test)
        {
            // For C-style hex notation (0xFF) you can use @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z"
            if (System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z") == false)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b(0[xX])[0-9a-fA-F]+\b\Z") == false)
                    return false;
            }
            return true;
        }

        private bool parseFile(string input)
        {
            bool bRet = false;
            int tempLen = 0;
            string sData = "";
            parseErrorString = "";
            string[] words = input.Split('\n');
            Debug.WriteLine("Send to debug output.");
            Debug.WriteLine(input);
            if (words.Count() > 0)
            {
                canTxMsg = new cfgTxFrame_t[words.Count()];
                for (int i = 0; i < words.Count(); i++)
                {
                    string[] parse = words[i].Split(':');
                    if (parse.Count() > 4 ||
                         parse.Count() < 0)
                    {
                        bRet = false;
                        Debug.WriteLine("Ha");
                        parseErrorString = "Invalid number of values in CAN Frames" + "\n" +
                                            "Provided is " + parse.Count() + " Needed is 4 in frame No:" + i + " ";
                        canTxMsg = null;
                        break;
                    }
                    if (parse[0] == "Extended")
                    {
                        canTxMsg[i].canTxMsg.flags = CANUSB.CANMSG_EXTENDED;
                    }
                    else if (parse[0] == "Base")
                    {
                        canTxMsg[i].canTxMsg.flags = 0;
                    }
                    else
                    {
                        bRet = false;
                        canTxMsg = null;
                        parseErrorString = "Missing Frame type \"Extended or Base\" in Frame No:" + i + " ";
                        break;
                    }
                    if (OnlyHexInString(parse[1]) == true)
                    {
                        tempLen = parse[1].Length - 2;
                        canTxMsg[i].canTxMsg.id = uint.Parse(parse[1].Substring(2, tempLen), System.Globalization.NumberStyles.HexNumber);
                        canTxMsg[i].ID = parse[1];
                        Debug.WriteLine(parse[1]);
                        Debug.WriteLine(parse[2]);
                    }
                    else
                    {
                        bRet = false;
                        canTxMsg = null;
                        parseErrorString = "Invalid CAN id for Frame No:" + i + "\nIt should hexadecimel value starting with \"0x\"  ";
                        Debug.WriteLine("Invalid Hex" + parse[1]);
                        break;
                    }
                    if (byte.TryParse(parse[2], out canTxMsg[i].canTxMsg.len) == false)
                    {
                        bRet = false;
                        canTxMsg = null;
                        parseErrorString = "Invalid Length for Frame No:" + i + "\nShould be any unsigned integer ";
                        Debug.WriteLine("Invalid byte" + parse[2]);
                        break;
                    }
                    Debug.WriteLine(canTxMsg[i].canTxMsg.len);
                    canTxMsg[i].data = parse[3];
                    if (parse[3][parse[3].Length-1] == '\r')
                    {
                        parse[3] = parse[3].Substring(0, parse[3].Length - 1);
                    }
                    Debug.WriteLine(parse[3]);
                    string[] dataParse = parse[3].Split(',');
                    Debug.WriteLine(dataParse.Count());
                    
                    if ( dataParse.Count() != 0 )
                    {
                        if (dataParse[0].Contains("RTR") == true )
                        {
                            canTxMsg[i].canTxMsg.flags |= CANUSB.CANMSG_RTR;
                            Debug.WriteLine("Re-try flag");
                        }
                        else if (canTxMsg[i].canTxMsg.len != 0)
                        {
                            for (int j = dataParse.Count() - 1; j >= 0; j--)
                            {
                                Debug.WriteLine(dataParse[j]);
                                if (OnlyHexInString(dataParse[j]) == false)
                                {
                                    bRet = false;
                                    canTxMsg = null;
                                    parseErrorString = "Invalid Hexadecimel value in Frame No:" + i + "\n Provided is " + dataParse[j] + " ";
                                    Debug.WriteLine("Invalid data" + dataParse[j]);
                                    break;
                                }
                                if (dataParse[j].Contains("0x"))
                                {
                                    if (dataParse[j].Length != 4)
                                    {
                                        bRet = false;
                                        canTxMsg = null;
                                        parseErrorString = "Invalid Hexadecimel value in Frame No:" + i +
                                            "\nThe Data provided is " + dataParse[j] + ",But valid value are 0xXX/XX Ex: \"0x04\" or \"04\"";
                                        Debug.WriteLine("Invalid data" + dataParse[j]);
                                        break;
                                    }
                                    Debug.WriteLine("conatins 0x" + dataParse[j].Substring(2, dataParse[j].Length - 2));
                                    sData += dataParse[j].Substring(2, dataParse[j].Length - 2);
                                }
                                else
                                {
                                    if (dataParse[j].Length != 2)
                                    {
                                        bRet = false;
                                        canTxMsg = null;
                                        Debug.WriteLine("Invalid data" + dataParse[j]);
                                        parseErrorString = "Invalid Hexadecimel value in Frame No:" + i +
                                         "\nThe Data provided is " + dataParse[j] + ",But valid value are 0xXX or XX Ex: \"0x04\" or \"04\"";
                                        break;
                                    }
                                    sData += dataParse[j];
                                }
                            }
                            Debug.WriteLine(sData);
                            if (canTxMsg == null)
                            {
                                break;
                            }
                            canTxMsg[i].canTxMsg.data = UInt64.Parse(sData, System.Globalization.NumberStyles.HexNumber);
                        }
                        else
                        {
                            canTxMsg[i].canTxMsg.len = 0;
                            canTxMsg[i].canTxMsg.data =0;
                        }
                    }
                   
                    Debug.WriteLine(canTxMsg[i].canTxMsg.data);
                    sData = "";
                    bRet = true;
                }
            }
            return bRet;
        }
        private void fileMnuOpen_Click(object sender, EventArgs e)
        {
            //canTxMsg;
            string input = "g";
            DialogResult result = openTxMsg.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(openTxMsg.FileName))
                {
                    input = sr.ReadToEnd();
                    sr.Close();
                }
            }
            if (parseFile(input) == false)
            {
                parseErrorString += "\n Please check the contents of  " + openTxMsg.FileName;
                MessageBox.Show(parseErrorString);
            }
        }

        private void eventLog1_EntryWritten(object sender, EntryWrittenEventArgs e)
        {

        }

        private void canMsgView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fileMnuQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
