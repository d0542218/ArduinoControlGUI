using log4net;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// SuperSocket 版本 :1.6.6.0 , 注意它自帶 log4net v1.2.13.0
using SuperSocket.Common;

// 版本 : 1.2.13.0
using System.IO.Ports;
using System.Diagnostics;

namespace ArduinoControlGUI
{
    static class TCPCommandTable
    {
        public static System.Windows.Forms.Control Frm_;
        public static bool isRxReply = false;
        public static string EspIP = "";
        public static string Inc_degree = "degree 0";
        public static MySession EspSection = new MySession();
        public static MySession RxSection = new MySession();
        public static Stopwatch stopwatch = new Stopwatch();
    }
    internal class Server
    {
    }
    public class MySession : AppSession<MySession>
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int UserId { get; internal set; }
        public string Username { get; internal set; }

        protected override void OnSessionStarted()
        {
            UserId = 1;
            Username = "test";

            //Log.InfoFormat("Welcome to CCU AILab Server! friend:'{0}'", this.RemoteEndPoint.Address.ToString());
            if (SocketSession.RemoteEndPoint.Address.ToString() != TCPCommandTable.EspIP)
                this.Send("Welcome to CCU AILab Server!");
        }

        //針對 要送字的字串,若要加料 ,可在此過載 ...
        public override void Send(string message)
        {
            //   string prefix = Username + "(" + UserId + "):";
            //   base.Send(prefix + message);
            base.Send(message);
        }

        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            if (requestInfo.Key != "")
            {
                if (SocketSession.RemoteEndPoint.Address.ToString() == TCPCommandTable.EspIP) //esp8266 ip
                {
                    Log.InfoFormat("ESP8266: '{0}'", requestInfo.Key);
                    if (requestInfo.Key == "1")
                    {
                        TCPCommandTable.stopwatch.Stop();
                        //Get the elapsed time
                        TimeSpan elapsedTime = TCPCommandTable.stopwatch.Elapsed;
                        Log.InfoFormat("Program execution time: " + elapsedTime.TotalMilliseconds + " ms");
                    }
                }
                else
                {
                    //Log.InfoFormat("UnknownRequest!('{0}')", requestInfo.Key);
                    this.Send("-1");
                }
            }
        }
        protected override void HandleException(Exception e)
        {
            if (SocketSession.RemoteEndPoint.Address.ToString() == TCPCommandTable.EspIP)
            {
                Log.Warn("ESP8266_Exception:", e);
            }
            else
            {
                Log.Warn("HandleException:", e);
                this.Send("-1");
            }
        }
        protected override void OnSessionClosed(CloseReason reason)
        {
            //Log.InfoFormat("OnSessionClosed! reason: '{0}'", reason);
            base.OnSessionClosed(reason);
        }
    }

    public class Ver : CommandBase<MySession, StringRequestInfo>
    {

        public override void ExecuteCommand(MySession session, StringRequestInfo requestInfo)
        {
            // 取出應用程式本身 '檔案版本'

            //((Form1)TCPCommandTable.Frm_).serialPort1.Write("0_-30_allnfind;" + ((Form1)TCPCommandTable.Frm_).tb_delayTime.Text);
            //form.serialPort1.Write("0_-30_allnfind;" + form.tb_delayTime.Text);
            //TCPCommandTable.Frm_ = ArduinoControlGUI.Form1;
            session.Send("ok");

        }
    }

    public class txall : CommandBase<MySession, StringRequestInfo>
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public override void ExecuteCommand(MySession session, StringRequestInfo requestInfo)
        {
            //Log.InfoFormat("(rx)TXALL: '{0}'", requestInfo.Body);
            TCPCommandTable.isRxReply = true;
            if (TCPCommandTable.EspSection.SessionID != null)
            {
                string inc_degree = TCPCommandTable.Inc_degree.Substring(TCPCommandTable.Inc_degree.LastIndexOf(" ") + 1, TCPCommandTable.Inc_degree.Length - TCPCommandTable.Inc_degree.LastIndexOf(" ") - 1);
                TCPCommandTable.EspSection.Send(inc_degree + "_-60_allnfind;" + string.Join(",", requestInfo.Parameters) + "!");
            }
        }
    }

    public class tx : CommandBase<MySession, StringRequestInfo>
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public override void ExecuteCommand(MySession session, StringRequestInfo requestInfo)
        {
            //Log.InfoFormat("(rx)TX: '{0}'", requestInfo.Body);
            TCPCommandTable.isRxReply = true;
            if (TCPCommandTable.EspSection.SessionID != null)
            {
                string inc_degree = TCPCommandTable.Inc_degree.Substring(TCPCommandTable.Inc_degree.LastIndexOf(" ") + 1, TCPCommandTable.Inc_degree.Length - TCPCommandTable.Inc_degree.LastIndexOf(" ") - 1);
                TCPCommandTable.EspSection.Send(inc_degree + "_" + requestInfo.Body + "_n;0!");
            }
        }
    }

    public class rxall : CommandBase<MySession, StringRequestInfo>
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public override void ExecuteCommand(MySession session, StringRequestInfo requestInfo)
        {
            //Log.InfoFormat("(rx)RX SINR: '{0}'", requestInfo.Body);
            string inc_degree = TCPCommandTable.Inc_degree.Substring(TCPCommandTable.Inc_degree.LastIndexOf(" ") + 1, TCPCommandTable.Inc_degree.Length - TCPCommandTable.Inc_degree.LastIndexOf(" ") - 1);
            int[] SINR = Array.ConvertAll(requestInfo.Parameters, int.Parse);
            int index = Array.IndexOf(SINR, SINR.Max());
            int ref_degree = -70;
            if (inc_degree == "14")
            {
                ref_degree = -60 + (index * 5);
            }
            else
            {
                ref_degree = (index - 6) * 10;
            }
            TCPCommandTable.EspSection.Send(inc_degree + "_" + ref_degree.ToString() + "_n;0!");
        }
    }

    public class rx : CommandBase<MySession, StringRequestInfo>
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public override void ExecuteCommand(MySession session, StringRequestInfo requestInfo)
        {
            //Log.InfoFormat("(rx)RX SINR: '{0}'", requestInfo.Body);
            string inc_degree = TCPCommandTable.Inc_degree.Substring(TCPCommandTable.Inc_degree.LastIndexOf(" ") + 1, TCPCommandTable.Inc_degree.Length - TCPCommandTable.Inc_degree.LastIndexOf(" ") - 1);
            int[] SINR = Array.ConvertAll(requestInfo.Parameters, int.Parse);
        }
    }
    public class Running_time_total : CommandBase<MySession, StringRequestInfo>
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public override void ExecuteCommand(MySession session, StringRequestInfo requestInfo)
        {
            //Log.InfoFormat("ESP8266: '{0}'", requestInfo.Key);

            if (TCPCommandTable.isRxReply)
            {
                TCPCommandTable.RxSection.Send("1");
                TCPCommandTable.isRxReply = false;
            }
        }
    }

    public class MyServer : AppServer<MySession>  //, MyRequestInfo >
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MyServer()  // 字串語法 格式  "LOGIN:kerry,12345" + NewLine  
            : base(new CommandLineReceiveFilterFactory(Encoding.Default, new BasicRequestInfoParser(":", ",")))
        { }

        public void SendMessageToLastClientSession(string cmd, string msg)
        {
            if (TCPCommandTable.RxSection == null && TCPCommandTable.EspSection == null)
            {
                Log.WarnFormat("Client section not connect yet!,fail to send msg:'{0}'", msg);
                return;
            }
            if (cmd == "esp8266")
                TCPCommandTable.EspSection.Send(msg + "!");
            else
            {
                TCPCommandTable.RxSection.Send(msg);
            }

            //Log.InfoFormat("(TX)    ({0})   Reply: {1}", cmd, msg);
        }

        // // if (appServer.Setup("127.0.0.1", 8888))  
        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
        }

        protected override void OnStarted()
        {
            //    Log.InfoFormat("Server:'{0}' OnStarted!", this.LocalEndPoint.Address.ToString());
            //Log.Info("Server OnStarted!");
            base.OnStarted();
        }
        protected override void OnNewSessionConnected(MySession session)
        {
            if (session.RemoteEndPoint.Address.ToString() == TCPCommandTable.EspIP)
                TCPCommandTable.EspSection = GetSessionByID(session.SessionID);
            else
                TCPCommandTable.RxSection = GetSessionByID(session.SessionID);
            base.OnNewSessionConnected(session);
            //Log.InfoFormat("RemoteEndPoint:'{0}', OnNewSessionConnected", session.RemoteEndPoint.Address.ToString());
        }

        protected override void OnSessionClosed(MySession session, CloseReason reason)
        {
            if (session.RemoteEndPoint.Address.ToString() == TCPCommandTable.EspIP)
                TCPCommandTable.EspSection = null;
            else
                TCPCommandTable.RxSection = null;
            base.OnSessionClosed(session, reason);
            //Log.InfoFormat("RemoteEndPoint:'{0}', OnSessionClosed,reason:{1}", session.RemoteEndPoint.Address.ToString(), reason);
        }
        protected override void OnStopped()
        {
            base.OnStopped();
            //Log.InfoFormat("Servo OnStopped");
        }
    }
}
