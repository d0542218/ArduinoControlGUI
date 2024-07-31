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

//輸出excel
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.Formula.Functions;
using MathNet.Numerics.Distributions;

namespace ArduinoControlGUI
{
    public partial class Form1 : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static string Log4NetPath = Environment.CurrentDirectory + "\\TCPIP_Logs";
        private static string Phase_Path = Environment.CurrentDirectory + "\\Phase";
        private RichTextBoxAppender2 rba;
        int inc_degree;
        int ref_degree;
        double frequency;
        int numX;
        int numY;
        bool connection = false;
        private RISBeamFormingBath cell;
        private EnhancedRISBeamFormingBath cell2;
        private Thread t;
        public Form1()
        {
            InitializeComponent();
            InitializeLog4netAppender();
            TCPCommandTable.Frm_ = this;
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


            string[] myPorts = SerialPort.GetPortNames(); //取得所有port的名字的方法

            lb_findRef.SelectedIndex = 0;
            //lb_findInc.SelectedIndex = 0;
            //初始化RIS
            cell = new RISBeamFormingBath(40, 40);
            cell2 = new EnhancedRISBeamFormingBath(40, 40);
            RISBeamForming(0, 0, 4.7);
            RISBeamForming_Ming(0, 0, 4.7);
            TCPCommandTable.EspIP = tb_EspIP.Text;
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
                //Log.Info("List Servo IP #" + num + ": " + ipaddress.ToString());
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
                //Log.Info("Server ShutDown !");
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
                //Log.InfoFormat("The server setup to '{0}:{1}'", IPaddr, iPort);
                if (appServer.Start())
                {
                    //Log.Info("The server started.");
                    bRet = true;
                }
            }
            else
            {
                //Log.ErrorFormat("The server setup fail, '{0}:{1}'", IPaddr, iPort);
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
                //Log.InfoFormat("Server not started,Send fail msg:'{0}'", msg);
                return false;
            }
            appServer.SendMessageToLastClientSession(cmd, msg);
            return true;
        }
        #region RISInit
        //2023.09.23修改數學
        private void RISBeamForming(int inc_degree, int ref_degree, double frequency)
        {
            cell = new RISBeamFormingBath(numX, numY)
            {
                f0 = frequency * Math.Pow(10, 9)
            };
            cell.lamda = cell.c0 / cell.f0;
            cell.d = 0.42 * cell.lamda;//squarecell  
            cell.k = 2 * Math.PI / cell.lamda;
            cell.feedR = cell.numX * cell.d * 0.5 / Math.Tan(Deg2Rad(33.71 / 2));
            IWorkbook workbook = new XSSFWorkbook();
            //feed horn position
            cell.Ri = cell.feedR;
            //inc angle & ref angle
            cell.incThdeg = inc_degree; cell.incTH = Deg2Rad(cell.incThdeg);
            cell.incPhdeg = 0; cell.incPH = Deg2Rad(cell.incPhdeg);
            cell.refThdeg = ref_degree; cell.refTH = Deg2Rad(cell.refThdeg);
            cell.refPhdeg = 0; cell.refPH = Deg2Rad(cell.refPhdeg);
            cell.xx = cell.Ri * Math.Sin(cell.incTH) * Math.Cos(cell.incPH);
            cell.yy = cell.Ri * Math.Sin(cell.incTH) * Math.Cos(cell.incPH);
            cell.zz = cell.Ri * Math.Cos(cell.incTH);
            cell.distz = cell.zz;
            cell.centerx = 0 - cell.xx;
            cell.centery = 0 - cell.yy;
            cell.centerz = 0 - cell.zz;
            cell.vectorz = 0 * cell.d - cell.zz;
            cell.feedVectorz = cell.centerz * cell.vectorz;
            ISheet MPD = workbook.CreateSheet("MPD");
            ISheet MPD_rot = workbook.CreateSheet("MPD_rot");
            //ISheet gamma = workbook.CreateSheet("gamma");
            //ISheet MPDview = workbook.CreateSheet("MPDview");            

            for (int i = 0; i < cell.numX; i++)
            {
                IRow MPDRow = MPD.CreateRow(i);
                //IRow gammaRow = gamma.CreateRow(i);
                //IRow MPDviewRow = MPDview.CreateRow(i);

                for (int j = 0; j < cell.numY; j++)
                {
                    cell.distx[i, j] = Math.Round(cell.xx - cell.eleM[i, j] * cell.d, 4);
                    cell.disty[i, j] = Math.Round(cell.yy - cell.eleN[i, j] * cell.d, 4);

                    cell.Rf[i, j] = Math.Round(Math.Sqrt(Math.Pow(cell.distx[i, j], 2) + Math.Pow(cell.disty[i, j], 2) + Math.Pow(cell.distz, 2)), 4);

                    cell.vectorx[i, j] = Math.Round(cell.eleM[i, j] * cell.d - cell.xx, 4);
                    cell.vectory[i, j] = Math.Round(cell.eleN[i, j] * cell.d - cell.yy, 4);
                    cell.feedVectorx[i, j] = Math.Round(cell.centerx * cell.vectorx[i, j], 4);
                    cell.feedVectory[i, j] = Math.Round(cell.centery * cell.vectory[i, j], 4);
                    cell.test[i, j] = cell.feedVectorx[i, j] + cell.feedVectory[i, j] + cell.feedVectorz;
                    cell.thetaf[i, j] = Math.Round(Math.Acos((cell.feedVectorx[i, j] + cell.feedVectory[i, j] + cell.feedVectorz) / (cell.Rf[i, j] * cell.Ri)), 4);

                    cell.amp[i, j] = Math.Round(Math.Pow(Math.Cos(cell.thetaf[i, j]), cell.qe) / cell.Rf[i, j], 4);

                    cell.incPD[i, j] = Math.Round(cell.k * Math.Sqrt(Math.Pow(cell.distx[i, j], 2) + Math.Pow(cell.disty[i, j], 2) + Math.Pow(cell.distz, 2)), 4);
                    cell.elePD[i, j] = Math.Round(cell.k * (Math.Sin(cell.refTH) * Math.Cos(cell.refPH) * cell.eleM[i, j] * cell.d + Math.Sin(cell.refTH) * Math.Sin(cell.refPH) * cell.eleN[i, j] * cell.d), 4);
                    cell.refPD[i, j] = (cell.incPD[i, j] - cell.elePD[i, j]) + cell.delta; //% refPD2=refPD
                    cell.MPD[i, j] = cell.refPD[i, j] % (2 * Math.PI); //% MPD(((0*pi/180)<=MPD&MPD<(cut_angle*pi/180)))=pi ;
                    //cell.MPDconti[i, j] = cell.MPD[i, j];

                    //% MPD(((0*pi/180)<=MPD&MPD<(cut_angle*pi/180)))=binary_on_phase ;
                    if ((cell.binary_on_phase - cell.cut_angle / 2) <= cell.MPD[i, j] && cell.MPD[i, j] < (cell.binary_on_phase + cell.cut_angle / 2))
                    {
                        cell.MPD[i, j] = 0;
                    }
                    else
                    {
                        cell.MPD[i, j] = 1;
                    }
                    ICell MPDRowCell = MPDRow.CreateCell(j);
                    MPDRowCell.SetCellValue(cell.MPD[i, j]);

                    /*%pd=readmatrix('phase.csv') ;
                    %MPD=pd*pi ;*/
                    cell.gamma[i, j] = cell.MPD[i, j];

                    if (cell.gamma[i, j] == cell.binary_on_phase)
                    {
                        cell.gamma[i, j] = cell.diodeOn;
                    }
                    else
                    {
                        cell.gamma[i, j] = cell.diodeOff;
                    }
                    //ICell gammaRowCell = gammaRow.CreateCell(j);
                    //gammaRowCell.SetCellValue(cell.gamma[i, j]);

                    cell.MPDview[i, j] = rad2Deg(cell.MPD[i, j]); // rad2deg is a function that converts radians to degrees
                    //ICell MPDviewRowCell = MPDviewRow.CreateCell(j);
                    //MPDviewRowCell.SetCellValue(cell.MPDview[i, j]);

                }
            }
            //順轉180度(處理由後往前的順序+逆轉90度)
            for (int i = 0; i < cell.numX; i++)
            {
                IRow MPDRow_rot = MPD_rot.CreateRow(i);
                for (int j = 0; j < cell.numX; j++)
                {
                    cell.MPDconti[i, j] = cell.MPD[cell.numX - 1 - i, cell.numX - 1 - j];
                    ICell MPDRowCell = MPDRow_rot.CreateCell(j);
                    MPDRowCell.SetCellValue(cell.MPDconti[i, j]);
                }
            }
            //儲存MPD
            string filePath = Path.Combine(Phase_Path, "MPD.xlsx");
            using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(stream);
            }

            double[] phase_arr = new double[cell.numX * cell.numY];
            if (frequency == 4.7)
            {
                phase_arr = phase_transfer_block();
            }else if(frequency == 28)
            {
                phase_arr = phase_transfer(cell.MPDconti);
            }
            int count = 0;
            string MPDBinaryString = "";
            for (int i = 0; i < cell.numX * cell.numY; i++)
            {
                MPDBinaryString += phase_arr[i];
                count++;
                if (count % 8 == 0 && count != 0)
                {
                    //cell.ArduinoCode += Convert.ToInt32(MPDBinaryString, 2).ToString()+",";//逗號
                    cell.ArduinoCode += Convert.ToInt32(MPDBinaryString, 2).ToString().PadLeft(3, '0');
                    MPDBinaryString = "";
                }
            }
            DateTime End = DateTime.Now;
        }

        private void RISBeamForming_Ming(int inc_degree, int ref_degree, double frequency)
        {
            cell2.lamda = cell2.c0 / cell2.f0;
            cell2.dx = cell2.lamda;
            cell2.dy = 0.5 * cell2.lamda;
            cell2.dz = double.IsNaN(0 / 8 * cell2.lamda) ? 0 : 0 / 8 * cell2.lamda;
            cell2.feed = Convert.ToDouble(tb_server_feed.Text); // unit: m
            cell2.k = 2 * Math.PI / cell2.lamda;
            cell2.f0 = frequency * Math.Pow(10, 9);
            cell2.lamda = cell2.c0 / cell2.f0;
            cell2.k = 2 * Math.PI / cell2.lamda;
            cell2.dx = cell2.lamda;
            cell2.dy = 0.5 * cell2.lamda;

            // 設置入射角和反射角
            cell2.incThdeg = inc_degree; cell2.incTH = Deg2Rad(cell2.incThdeg);
            cell2.incPhdeg = 0; cell2.incPH = Deg2Rad(cell2.incPhdeg);
            cell2.refThdeg = ref_degree; cell2.refTH = Deg2Rad(cell2.refThdeg);
            cell2.refPhdeg = 90; cell2.refPH = Deg2Rad(cell2.refPhdeg);

            // 計算饋源位置
            cell2.Ri = cell2.feed;
            cell2.xx = cell2.Ri * Math.Sin(cell2.incTH) * Math.Cos(cell2.incPH);
            cell2.yy = cell2.Ri * Math.Sin(cell2.incTH) * Math.Sin(cell2.incPH);
            cell2.zz = cell2.Ri * Math.Cos(cell2.incTH);
            //cell2.distz = cell2.zz;
            // 計算距離和相位
            for (int i = 0; i < cell2.numX; i++)
            {
                for (int j = 0; j < cell2.numY; j++)
                {
                    cell2.distx[i, j] = Math.Round(cell2.xx - cell2.eleM[i, j] * cell2.dx, 4);
                    cell2.disty[i, j] = Math.Round(cell2.yy - cell2.eleN[i, j] * cell2.dy, 4);
                    cell2.distZ[i, j] = Math.Round(cell2.zz - cell2.Z[i, j] * cell2.dz, 4);
                    cell2.incPD[i, j] = Math.Round(cell2.k * Math.Sqrt(Math.Pow(cell2.distx[i, j], 2) + Math.Pow(cell2.disty[i, j], 2) + Math.Pow(cell2.distZ[i, j], 2)), 4);
                    cell2.elePD[i, j] = Math.Round(cell2.k * (Math.Sin(cell2.refTH) * Math.Cos(cell2.refPH) * cell2.eleM[i, j] * cell2.dx + Math.Sin(cell2.refTH) * Math.Sin(cell2.refPH) * cell2.eleN[i, j] * cell2.dy), 4);
                    cell2.refPD[i, j] = -(cell2.incPD[i, j] + cell2.elePD[i, j]);
                    cell2.MPD[i, j] = Mod(cell2.refPD[i, j], 2 * Math.PI);

                    if (cell2.MPD[i, j] >= 0 && cell2.MPD[i, j] < Math.PI)
                    {
                        cell2.MPD[i, j] = 0;
                    }
                    else
                    {
                        //cell2.MPD[i, j] = Math.PI;
                        cell2.MPD[i, j] = 1;
                    }
                }
            }

            cell2.phase_arr = phase_transfer(cell2.MPD);
            int count = 0;
            string MPDBinaryString = "";
            for (int i = 0; i < cell2.numX * cell2.numY; i++)
            {
               MPDBinaryString += cell2.phase_arr[i];
               count++;
               if (count % 8 == 0 && count != 0)
               {
                   //cell.ArduinoCode += Convert.ToInt32(MPDBinaryString, 2).ToString()+",";//逗號
                   cell2.ArduinoCode += Convert.ToInt32(MPDBinaryString, 2).ToString().PadLeft(3, '0');
                   MPDBinaryString = "";
               }
            }
        }
        private double[] phase_transfer(double[,] MPD) { //將相位轉成一維陣列
            
            double[] phase_tmp = new double[MPD.GetLength(0)*MPD.GetLength(1)];
            int index = 0;
            for (int i = 0; i < MPD.GetLength(0); i++)
            {
                for (int j = 0; j < MPD.GetLength(1); j++)
                {
                    phase_tmp[index++] = MPD[i, j];
                }
            }
            return phase_tmp;
        }
        private double[] phase_transfer_block()//將相位切成對應的block並轉成一維陣列
        {
            int num = (cell.numX * cell.numX) / 100;
            double[,,] phase_block = new double[num, 10, 10];
            for (int i = 0; i < cell.numX; i++)
            {
                for (int j = 0; j < cell.numX; j++)
                {
                    if (i < 10 && j < 10)//block 1
                    {
                        phase_block[0, i, j] = cell.MPDconti[i, j];
                    }
                    else if (i < 10 && j >= 10 && j < 20)//block 2
                    {
                        phase_block[1, i, j - 10] = cell.MPDconti[i, j];
                    }
                    else if (i >= 10 && i < 20 && j < 10)//block 3
                    {
                        phase_block[2, i - 10, j] = cell.MPDconti[i, j];
                    }
                    else if (i >= 10 && i < 20 && j >= 10 && j < 20)//block 4
                    {
                        phase_block[3, i - 10, j - 10] = cell.MPDconti[i, j];
                    }
                    else if (i < 10 && j >= 20 && j < 30)//block 5
                    {
                        phase_block[4, i, j - 20] = cell.MPDconti[i, j];
                    }
                    else if (i < 10 && j >= 30 && j < 40)//block 6
                    {
                        phase_block[5, i, j - 30] = cell.MPDconti[i, j];
                    }
                    else if (i >= 10 && i < 20 && j >= 20 && j < 30)//block 7
                    {
                        phase_block[6, i - 10, j - 20] = cell.MPDconti[i, j];
                    }
                    else if (i >= 10 && i < 20 && j >= 30 && j < 40)//block 8
                    {
                        phase_block[7, i - 10, j - 30] = cell.MPDconti[i, j];
                    }
                    else if (i >= 20 && i < 30 && j < 10)//block 9
                    {
                        phase_block[8, i - 20, j] = cell.MPDconti[i, j];
                    }
                    else if (i >= 20 && i < 30 && j >= 10 && j < 20)//block 10
                    {
                        phase_block[9, i - 20, j - 10] = cell.MPDconti[i, j];
                    }
                    else if (i >= 30 && i < 40 && j < 10)//block 11
                    {
                        phase_block[10, i - 30, j] = cell.MPDconti[i, j];
                    }
                    else if (i >= 30 && i < 40 && j >= 10 && j < 20)//block 12
                    {
                        phase_block[11, i - 30, j - 10] = cell.MPDconti[i, j];
                    }
                    else if (i >= 20 && i < 30 && j >= 20 && j < 30)//block 13
                    {
                        phase_block[12, i - 20, j - 20] = cell.MPDconti[i, j];
                    }
                    else if (i >= 20 && i < 30 && j >= 30 && j < 40)//block 14
                    {
                        phase_block[13, i - 20, j - 30] = cell.MPDconti[i, j];
                    }
                    else if (i >= 30 && i < 40 && j >= 20 && j < 30)//block 15
                    {
                        phase_block[14, i - 30, j - 20] = cell.MPDconti[i, j];
                    }
                    else if (i >= 30 && i < 40 && j >= 30 && j < 40)//block 16
                    {
                        phase_block[15, i - 30, j - 30] = cell.MPDconti[i, j];
                    }
                }
            }
            
            
            phase_block = block_reverse(phase_block);
            double[] phase_tmp = new double[cell.numX * cell.numY];
            int cnt = 0;
            for (int k = 0; k < num; k++)
            {
                for (int m = 0; m < 10; m++)
                {
                    for (int n = 0; n < 10; n++)
                    {
                        phase_tmp[cnt] = phase_block[k, n, m];
                        cnt++;
                    }
                }
            }
            return phase_tmp;
        }

        private double[,,] block_reverse(double[,,] block)//將偶數行反轉0.2.4...
        {
            double[] tmp = new double[block.GetLength(1)];
            for (int m = 0; m < (cell.numX * cell.numX) / 100; m++)
            {
                for (int k = 0; k < 10; k += 2)
                {
                    for (int i = 0; i < block.GetLength(1); i++)
                    {
                        tmp[i] = block[m, i, k];
                    }
                    Array.Reverse(tmp);
                    for (int j = 0; j < block.GetLength(1); j++)
                    {
                        block[m, j, k] = tmp[j];
                    }
                }
            }
            return block;
        }

        private class RISBeamFormingBath
        {
            public double f0;
            public double c0;
            public double lamda;
            public double d;
            public double dx;
            public double dy;
            public double dz;
            public double feed;
            public double k;
            public int delta;
            public double cut_angle;
            public double binary_on_phase;
            public int numX;
            public int numY;
            public int[] M;
            public int[] N;
            public double feedR;
            public int[] theDeg;
            public double[] theta;
            public int[] phiDeg;
            public double[] phi;
            public double[,] u;
            public double[,] v;
            public int incThdeg;
            public double incTH;
            public int incPhdeg;
            public double incPH;
            public int refThdeg;
            public double refTH;
            public int refPhdeg;
            public double refPH;
            public double Ri;
            public double xx;
            public double yy;
            public double zz;
            public double q;
            public int qe;
            public double[,] eleFactor;
            public double[,] eleM;
            public double[,] eleN;
            public double[,] distx;
            public double[,] disty;
            public double distz;
            public double[,] Rf;
            public double centerx;
            public double centery;
            public double centerz;
            public double[,] vectorx;
            public double[,] vectory;
            public double vectorz;
            public double[,] feedVectorx;
            public double[,] feedVectory;
            public double feedVectorz;
            public double[,] test;
            public double[,] thetaf;
            public double[,] amp;
            public double diodeOn;
            public double diodeOff;
            public double[,] incPD;
            public double[,] elePD;
            public double[,] refPD;
            public double[,] MPD;
            public double[,] MPDconti;
            public double[,] gamma;
            public double[,] MPDview;
            public string ArduinoCode;
            public double[] phase_arr;
            public RISBeamFormingBath(int numX, int numY)
            {
                //this.f0 = frequency*Math.Pow(10,9);
                this.c0 = 3e8;
                //this.lamda = c0 / f0;
                //double d = 0.5 * lamda; //PEI
                //this.d = 0.42 * lamda;//squarecell                           
                //double feed = 0.35 //unit : m
                //double feed = 1.48; //1600
                //this.feed = 1.7697;
                //this.k = 2 * Math.PI / lamda;
                this.delta = 0;
                this.cut_angle = Deg2Rad(180);
                this.binary_on_phase = Deg2Rad(180);
                this.numX = numX;
                this.numY = numY;


                //this.M = Enumerable.Range(1, numX).ToArray();
                //this.N = Enumerable.Range(1, numY).ToArray();
                this.feedR = numX * d * 0.5 / Math.Tan(Deg2Rad(33.71 / 2));///unit : m 

                //可能不用(matlab繪圖用)
                this.theDeg = Enumerable.Range(-180, 361).ToArray();
                this.theta = theDeg.Select(deg => Deg2Rad(deg)).ToArray();
                this.phiDeg = Enumerable.Range(0, 181).Select(deg => deg * 2).ToArray();
                this.phi = phiDeg.Select(deg => Deg2Rad(deg)).ToArray();
                this.u = new double[361, 181];
                this.v = new double[361, 181];
                for (int i = 0; i <= 360; i++)
                {
                    for (int j = 0; j <= 180; j++)
                    {
                        this.u[i, j] = Math.Sin(theta[i]) * Math.Cos(phi[j]);
                        this.v[i, j] = Math.Sin(theta[i]) * Math.Sin(phi[j]);
                    }
                }




                // pattern power factor
                this.q = 0.85; //element pattern factor
                this.qe = 11; //horn pattern factor

                //element factor
                this.eleFactor = new double[361, 181];
                for (int i = 0; i <= 360; i++)
                {
                    for (int j = 0; j <= 180; j++)
                    {
                        this.eleFactor[i, j] = Math.Pow(Math.Cos(theta[i]), q);
                    }
                }

                this.eleM = new double[numX, numY];
                this.eleN = new double[numX, numY];

                //% calculate feed to element distance
                this.distx = new double[numX, numY];
                this.disty = new double[numX, numY];

                this.Rf = new double[numX, numY];

                this.vectorx = new double[numX, numY];
                this.vectory = new double[numX, numY];

                this.feedVectorx = new double[numX, numY];
                this.feedVectory = new double[numX, numY];

                this.test = new double[numX, numY];
                this.thetaf = new double[numX, numY];
                this.amp = new double[numX, numY]; //%gamma=(cos(thetap)).^q ;

                //% diodeOn = 0.6367;
                this.diodeOn = 0.93;
                this.incPD = new double[numX, numY];
                this.elePD = new double[numX, numY];
                this.refPD = new double[numX, numY];
                this.MPD = new double[numX, numY];
                this.MPDconti = new double[numX, numY];
                this.gamma = new double[numX, numY];
                this.MPDview = new double[numX, numY];
                this.ArduinoCode = "";
                this.phase_arr = new double[numX * numY];

                this.diodeOff = 0.91;
                for (int i = 0; i < numX; i++)
                {
                    for (int j = 0; j < numY; j++)
                    {
                        eleM[i, j] = (i + 1) - (numX + 1) / 2.0;
                        eleN[i, j] = (j + 1) - (numY + 1) / 2.0;
                    }
                }

            }


        }
        private class EnhancedRISBeamFormingBath : RISBeamFormingBath
        {
            public double[,] Z; // 新的Z矩陣
            public double[,] distZ;
            public EnhancedRISBeamFormingBath(int numX, int numY) : base(numX, numY)
            {
                // 初始化 Z 矩陣
                Z = new double[numX, numY];
                distZ = new double[numX, numY];
                // 計算 rows_per_quarter 和 cols_per_quarter
                int rows_per_quarter = numX / 2;
                int cols_per_quarter = numY / 2;

                // 設置 Z 矩陣的四分之一區域內的值為 1
                for (int i = 0; i < rows_per_quarter; i++)
                {
                    for (int j = 0; j < cols_per_quarter; j++)
                    {
                        Z[i, j] = 1;
                    }
                }

                for (int i = numX - rows_per_quarter; i < numX; i++)
                {
                    for (int j = numY - cols_per_quarter; j < numY; j++)
                    {
                        Z[i, j] = 1;
                    }
                }
            }
        }
        #endregion
        #region math
        private static double Deg2Rad(double degrees)
        {
            return Math.Round(degrees * Math.PI / 180.0, 4);
        }

        private static double rad2Deg(double radians)
        {
            return radians * (180.0 / Math.PI);
        }
        private Tuple<double[,], double[,]> meshgrid(double[] x, double[] y)
        {
            double[,] X;
            double[,] Y;
            X = new double[x.Length, y.Length];
            Y = new double[x.Length, y.Length];
            for (int i = 0; i < x.Length; i++)
            {
                for (int j = 0; j < y.Length; j++)
                {
                    X[i, j] = x[i];
                    Y[i, j] = y[j];
                }
            }
            return Tuple.Create(X, Y);
        }

        private static double Mod(double a, double n)
        {
            return a - n * Math.Floor(a / n);
        }
        #endregion
        #region GUI動作

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                //serialPort1.PortName = cb_port.SelectedItem.ToString();
                serialPort1.Open();
                connection = true;
                t = new Thread(Receive);
                t.IsBackground = true;
                t.Start();
                //cb_port.Enabled = false;
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
            //cb_port.Enabled = true;
        }


        private void btn_WideBeamFind_Click(object sender, EventArgs e)
        {
            try
            {
                //string s = lb_findInc.SelectedItem.ToString();
                string s = tb_server_inc.Text.ToString();
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
                //string s1 = lb_findInc.SelectedItem.ToString();
                string s1 = tb_server_inc.Text.ToString();
                inc_degree = Convert.ToInt16(s1.Substring(s1.LastIndexOf(" ") + 1, s1.Length - s1.LastIndexOf(" ") - 1));
                serialPort1.Write(inc_degree + "_-60_allnfind;" + tb_delayTime.Text);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            tb_com.Text = "";
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            IsServerStarded = ServerStart(cboAvaiableIPaddr.Text, (int)nUpDnPort.Value);
            if (IsServerStarded)
            {
                //Log.InfoFormat("connect");
                cboAvaiableIPaddr.Enabled = false;
                nUpDnPort.Enabled = false;
                btnConnect.Enabled = false;
                btnDisConnect.Enabled = true;
                linkImg.Image = Properties.Resources.connect;

            }
        }

        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            ServerShutDown();
            cboAvaiableIPaddr.Enabled = true;
            nUpDnPort.Enabled = true;
            btnConnect.Enabled = true;
            btnDisConnect.Enabled = false;
            linkImg.Image = Properties.Resources.disconnect;
        }

        private void btn_LogClr_Click(object sender, EventArgs e)
        {
            richTextBoxLog.Text = "";
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

        private void btn_allOn_Click(object sender, EventArgs e)
        {
            SetInfoToClient("esp32", "0_0_allon_0_0;0");
        }

        private void btn_allOff_Click(object sender, EventArgs e)
        {
            SetInfoToClient("esp32", "0_0_alloff_0_0;0");
        }

        private void btn_allFind_Click(object sender, EventArgs e)
        {
            string inc_degree = TCPCommandTable.Inc_degree.Substring(TCPCommandTable.Inc_degree.LastIndexOf(" ") + 1, TCPCommandTable.Inc_degree.Length - TCPCommandTable.Inc_degree.LastIndexOf(" ") - 1);
            SetInfoToClient("esp32", inc_degree + "_-60_allnfind_0_0;" + tb_dTime.Text);
        }

        private void richTextBoxLog_TextChanged(object sender, EventArgs e)
        {
            richTextBoxLog.SelectionStart = richTextBoxLog.TextLength;

            // Scrolls the contents of the control to the current caret position.
            richTextBoxLog.ScrollToCaret();
        }

        private void btn_output_Click(object sender, EventArgs e)
        {
            TCPCommandTable.stopwatch.Reset();
            //Start the stopwatch
            TCPCommandTable.stopwatch.Start();

            //string inc_degree = TCPCommandTable.Inc_degree.Substring(TCPCommandTable.Inc_degree.LastIndexOf(" ") + 1, TCPCommandTable.Inc_degree.Length - TCPCommandTable.Inc_degree.LastIndexOf(" ") - 1);           
            frequency = Convert.ToDouble(tb_server_fre_combox.Text);
            string[] cb_server_num_parts = cb_server_num.Text.Split('X');
            numX = Convert.ToInt16(cb_server_num_parts[0]);
            numY = Convert.ToInt16(cb_server_num_parts[1]);
            if (tb_server_default.Checked)
            {
                SetInfoToClient("esp32", tb_server_inc.Text + "_" + tb_server_ref.Text + "_Y_" + cb_server_num_parts[0].PadLeft(3, '0') + "_" + cb_server_num_parts[1].PadLeft(3, '0') + ";0");
            }
            else
            {
                if (numX == 32 & numY == 64)
                {
                    cell2 = new EnhancedRISBeamFormingBath(numX, numY);
                    RISBeamForming_Ming(inc_degree, ref_degree, frequency);
                    SetInfoToClient("esp32", tb_server_inc.Text + "_" + tb_server_ref.Text + "_n_" + cb_server_num_parts[0].PadLeft(3, '0') + "_" + cb_server_num_parts[1].PadLeft(3, '0') + "_" + cell2.ArduinoCode + ";0");
                }
                else
                {
                    RISBeamForming(inc_degree, ref_degree, frequency);
                    SetInfoToClient("esp32", tb_server_inc.Text + "_" + tb_server_ref.Text + "_n_" + cb_server_num_parts[0].PadLeft(3, '0') + "_" + cb_server_num_parts[1].PadLeft(3, '0') + "_" + cell.ArduinoCode + ";0");
                }

            }
            TimeSpan elapsedTime = TCPCommandTable.stopwatch.Elapsed;
            Log.InfoFormat("PC count RIS : " + elapsedTime.TotalMilliseconds + " ms");
        }

        private void tb_server_inc_Leave(object sender, EventArgs e)
        {
            if ((Convert.ToInt16(tb_server_inc.Text) < -90) || (Convert.ToInt16(tb_server_inc.Text) > 90))
            {
                tb_server_inc.Text = "0";
            }
            else
            {
                inc_degree = Convert.ToInt16(tb_server_inc.Text);
            }

        }
        private void tb_server_ref_Leave(object sender, EventArgs e)
        {
            if ((Convert.ToInt16(tb_server_ref.Text) < -90) || (Convert.ToInt16(tb_server_ref.Text) > 90))
            {
                tb_server_ref.Text = "0";
            }
            else
            {
                ref_degree = Convert.ToInt16(tb_server_ref.Text);
            }
        }


        #endregion
    }
}
