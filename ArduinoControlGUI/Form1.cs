using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using System.Net;         // local IP

// log4net v1.2.13.0 @ .NET Framework 4.5 
using log4net.Appender;
using log4net.Config;
using log4net.Util;
using log4net.Core;
using log4net.Filter;
using log4net.Layout;
using log4net;
using System.Diagnostics;
using System.Reflection;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SocketBase;
using CloseReason = SuperSocket.SocketBase.CloseReason;
using System.Runtime.CompilerServices;

namespace ArduinoControlGUI
{    
    public partial class Form1 : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static string Log4NetPath = Environment.CurrentDirectory + "\\TCPIP_Logs";
        private RichTextBoxAppender2 rba;

        int inc_degree;
        int ref_degree;
        bool connection = false;
        private Thread t;
        public Form1()
        {
            InitializeComponent();
            InitializeLog4netAppender();
            TCPCommandTable.Frm_ = this;
        }

        private void lb_refdegree_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*string s1 = lb_findInc.SelectedItem.ToString();
            inc_degree = Convert.ToInt16(s1.Substring(s1.LastIndexOf(" ") + 1, s1.Length - s1.LastIndexOf(" ") - 1));
            string s2 = lb_findRef.SelectedItem.ToString();
            ref_degree = Convert.ToInt16(s2.Substring(s2.LastIndexOf(" ") + 1, s2.Length - s2.LastIndexOf(" ") - 1));*/
            //ref_degree = (lb_refdegree.SelectedIndex - 5) * 10;
            //pb_phase.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "/Phase_distribution_" + ref_degree + ".png");
            //pb_degree.Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "/Polar_" + ref_degree + ".png");                
        }

        private void Form1_Load(object sender, EventArgs e)
        {          
            ListLocalIPaddrs();  // 可用 本機 IP 加入 Combobox

            //IsServerStarded = ServerStart(cboAvaiableIPaddr.Text, (int)nUpDnPort.Value);
            //if (IsServerStarded)
            //{
            //    cboAvaiableIPaddr.Enabled = false;
            //    nUpDnPort.Enabled = false;
            //    btnConnect.Enabled = false;
            //}

            pb_degree.SizeMode = PictureBoxSizeMode.Zoom;
            pb_phase.SizeMode = PictureBoxSizeMode.Zoom;
            string[] myPorts = SerialPort.GetPortNames(); //取得所有port的名字的方法

            cb_port.DataSource = myPorts;   //直接取得所有port的名字
            lb_refdegree.SelectedIndex = 0;
            lb_incdegree.SelectedIndex = 0;
            lb_findRef.SelectedIndex = 0;
            lb_findInc.SelectedIndex = 0;

            TCPCommandTable.EspIP = tb_EspIP.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] myPorts = SerialPort.GetPortNames(); //取得所有port的名字的方法

            cb_port.DataSource = myPorts;   //直接取得所有port的名字
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = cb_port.SelectedItem.ToString();
                serialPort1.Open();
                connection = true;
                t = new Thread(Receive);
                t.IsBackground = true;
                t.Start();
                cb_port.Enabled = false;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Discon_Click(object sender, EventArgs e)
        {
            connection = false;
            serialPort1.Close();
            cb_port.Enabled = true;
        }

        private void btn_gen_Click(object sender, EventArgs e)
        {
            try
            {
                string s1 = lb_incdegree.SelectedItem.ToString();
                inc_degree = Convert.ToInt16(s1.Substring(s1.LastIndexOf(" ") + 1, s1.Length - s1.LastIndexOf(" ") - 1));
                string s2 = lb_refdegree.SelectedItem.ToString();
                ref_degree = Convert.ToInt16(s2.Substring(s2.LastIndexOf(" ") + 1, s2.Length - s2.LastIndexOf(" ") - 1));
                string s3 = s2.Substring(0, s2.IndexOf(" "));
                if (s3 == "w_degree")
                {
                    serialPort1.Write(inc_degree + "_" + ref_degree + "_w;" + tb_delayTime.Text);
                }
                else
                {
                    serialPort1.Write(inc_degree + "_" + ref_degree + "_n;" + tb_delayTime.Text);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_WideBeamFind_Click(object sender, EventArgs e)
        {
            try
            {
                string s = lb_findInc.SelectedItem.ToString();
                inc_degree = Convert.ToInt16(s.Substring(s.LastIndexOf(" ") + 1, s.Length - s.LastIndexOf(" ") - 1));
                serialPort1.Write(inc_degree + "_0_wfind;" + tb_delayTime.Text);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_NarrowBeamFind_Click(object sender, EventArgs e)
        {
            try
            {
                string s1 = lb_findInc.SelectedItem.ToString();
                inc_degree = Convert.ToInt16(s1.Substring(s1.LastIndexOf(" ") + 1, s1.Length - s1.LastIndexOf(" ") - 1));
                serialPort1.Write(inc_degree + "_-60_allnfind;" + tb_delayTime.Text);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*接收*/

        private void Receive()
        {
            Byte[] buffer = new Byte[20];
            while (connection)
            {
                try
                {
                    if (serialPort1.BytesToRead > 0)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            //this.tb_com.Text += serialPort1.ReadLine() + "\r\n";
                            tb_com.AppendText(serialPort1.ReadLine() + "\r\n");
                        }));
                    }
                    Thread.Sleep(16);
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tb_com.Text = "";
        }



        // 初始化 Log4net 的輸出標的 - Richbox  & 外部.txt 
        void InitializeLog4netAppender()
        {
            // Ref to RichTextBoxAppender.cs 
            rba = new RichTextBoxAppender2(richTextBoxLog);

            rba.Threshold = Level.All;    // dd-MM-yyyy
            rba.Layout = new PatternLayout("%date{yyyy-MM-dd HH:mm:ss.fff} %5level %message %n");
            LevelTextStyle ilts = new LevelTextStyle();
            ilts.Level = Level.Info;
            ilts.TextColor = Color.Blue;
            ilts.PointSize = 12.0f;

            rba.AddMapping(ilts);
            LevelTextStyle dlts = new LevelTextStyle();
            dlts.Level = Level.Debug;
            dlts.TextColor = Color.SandyBrown;
            dlts.PointSize = 12.0f;
            rba.AddMapping(dlts);

            LevelTextStyle wlts = new LevelTextStyle();
            wlts.Level = Level.Warn;
            wlts.TextColor = Color.Chartreuse;
            wlts.PointSize = 12.0f;
            rba.AddMapping(wlts);

            LevelTextStyle elts = new LevelTextStyle();
            elts.Level = Level.Error;
            elts.TextColor = Color.Crimson;
            //    elts.BackColor      = Color.Cornsilk;
            elts.PointSize = 12.0f;
            rba.AddMapping(elts);

            BasicConfigurator.Configure(rba);
            rba.ActivateOptions();


            RollingFileAppender fa = new RollingFileAppender();
            fa.AppendToFile = true;
            fa.Threshold = log4net.Core.Level.All;
            fa.RollingStyle = RollingFileAppender.RollingMode.Size;
            fa.MaxFileSize = 100000;
            fa.MaxSizeRollBackups = 3;
            fa.File = Log4NetPath + @"\Log.txt";
            fa.Layout = new log4net.Layout.PatternLayout("%date{yyyy-MM-dd HH:mm:ss.fff} %5level %message (%logger{1}:%line)%n");
            log4net.Config.BasicConfigurator.Configure(fa);
            fa.ActivateOptions();

        }

        private void ListLocalIPaddrs()
        {
            // 取得本機名稱 '電腦名稱'
            String strHostName = Dns.GetHostName();

            IPHostEntry iphostentry = Dns.GetHostByName(strHostName);

            // 取得本機的  所有 IP 位址
            cboAvaiableIPaddr.Items.Clear();
            int num = 1;
            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                cboAvaiableIPaddr.Items.Add(ipaddress.ToString());
                Log.Info("List Servo IP #" + num + ": " + ipaddress.ToString());
                num = num + 1;
            }
            cboAvaiableIPaddr.SelectedIndex = 0;
        }

        MyServer appServer = null;
        bool IsServerStarded = false;

        private void ServerShutDown()
        {
            if (IsServerStarded)
            {
                appServer.Stop();
                appServer.Dispose();

                appServer = null;
                Log.Info("Server ShutDown !");
            }
            IsServerStarded = false;
        }

        private bool ServerStart(string IPaddr, int iPort)
        {
            bool bRet = false;

            if (appServer == null)
            {
                appServer = new MyServer();
            }

            if (appServer.Setup(IPaddr, iPort))   // 127.0.0.1:8888
            {
                Log.InfoFormat("The server setup to '{0}:{1}'", IPaddr, iPort);
                if (appServer.Start())
                {
                    Log.Info("The server started.");
                    bRet = true;
                }
            }
            else
            {
                Log.ErrorFormat("The server setup fail, '{0}:{1}'", IPaddr, iPort);
                bRet = false;
            }
            return bRet;
        }

        // 2017.12.21 
        // 2018.01.15增加傳入String cmd用來傳遞輸入的指令為何...Log要用...
        public bool SetInfoToClient(String cmd, String msg)
        {
            if (!IsServerStarded)
            {
                Log.InfoFormat("Server not started,Send fail msg:'{0}'", msg);
                return false;
            }
            appServer.SendMessageToLastClientSession(cmd, msg);
            return true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            IsServerStarded = ServerStart(cboAvaiableIPaddr.Text, (int)nUpDnPort.Value);
            if (IsServerStarded)
            {
                Log.InfoFormat("connect");
                cboAvaiableIPaddr.Enabled = false;
                nUpDnPort.Enabled = false;
                btnConnect.Enabled = false;
                btnDisConnect.Enabled = true;

            }
        }

        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            ServerShutDown();
            cboAvaiableIPaddr.Enabled = true;
            nUpDnPort.Enabled = true;
            btnConnect.Enabled = true;
            btnDisConnect.Enabled = false;
        }

        private void btn_LogClr_Click(object sender, EventArgs e)
        {
            richTextBoxLog.Text = "";
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            SetInfoToClient("esp8266", textBox1.Text);
        }

        private void btn_IPrefresh_Click(object sender, EventArgs e)
        {
            if (cboAvaiableIPaddr.Enabled == true)
                ListLocalIPaddrs();
        }

        private void btn_espIPset_Click(object sender, EventArgs e)
        {
            TCPCommandTable.EspIP = tb_EspIP.Text;
        }

        private void lb_findInc_SelectedIndexChanged(object sender, EventArgs e)
        {
            TCPCommandTable.Inc_degree = lb_findInc.SelectedItem.ToString();
        }

        private void btn_allOn_Click(object sender, EventArgs e)
        {
            SetInfoToClient("esp8266", "0_0_allon;0");
        }

        private void btn_allOff_Click(object sender, EventArgs e)
        {
            SetInfoToClient("esp8266", "0_0_alloff;0");
        }

        private void btn_allFind_Click(object sender, EventArgs e)
        {
            string inc_degree = TCPCommandTable.Inc_degree.Substring(TCPCommandTable.Inc_degree.LastIndexOf(" ") + 1, TCPCommandTable.Inc_degree.Length - TCPCommandTable.Inc_degree.LastIndexOf(" ") - 1);
            SetInfoToClient("esp8266", inc_degree + "_-60_allnfind;" + tb_dTime.Text);
        }

        private void richTextBoxLog_TextChanged(object sender, EventArgs e)
        {
            richTextBoxLog.SelectionStart = richTextBoxLog.TextLength;

            // Scrolls the contents of the control to the current caret position.
            richTextBoxLog.ScrollToCaret();
        }

        private void btn_output_Click(object sender, EventArgs e)
        {
            string inc_degree = TCPCommandTable.Inc_degree.Substring(TCPCommandTable.Inc_degree.LastIndexOf(" ") + 1, TCPCommandTable.Inc_degree.Length - TCPCommandTable.Inc_degree.LastIndexOf(" ") - 1);
            SetInfoToClient("esp8266", inc_degree + "_" + tb_server_ref.Text + "_n;0");
        }
    }
}
