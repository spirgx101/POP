using System;
using System.Windows.Forms;
using System.Configuration;
using System.Net;
using POP.Dao;
using Pxmart.Log;
using System.IO;
using POP.Lib;
using Microsoft.Win32;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;

namespace ReportingService
{
    public partial class FormMain : Form
    {
        public delegate void MyDelegate(string parameter, string paper_id, string list_id, string printer, bool draw_rect, DaoPopList list);
        private MonitorLog _log = new MonitorLog();

        private int DELETE_DAYS = 0;
        private string PREVIEW = string.Empty;
        private string PRINT_ID = string.Empty;
        private string PRINT_STATUS = string.Empty;
        private string PRINT_SOURCE = string.Empty;
        private string IMG_PATH = string.Empty;

        #region 小白電腦檢查圖檔、字型
        private void CheckIsWhitePC()
        {
            string ip = GetLocalIP();

            /* 小黑、小白相互複製刊頭圖檔 */
            if (ip.Substring(ip.Length - 1, 1) != "3")
                ip = ip.Substring(0, ip.LastIndexOf(".") + 1) + "3";
            else
                ip = ip.Substring(0, ip.LastIndexOf(".") + 1) + "9";

            if (PingIP(ip))
            {
                //MessageBox.Show(ip);
                CopyImageFromOther(ip);

                CheckFont("華康細黑體 & 華康細黑體(P) (TrueType)", "DFT_B3.TTC", ip);
                CheckFont("華康中黑體 & 華康中黑體(P) (TrueType)", "DFT_B5.TTC", ip);
                CheckFont("華康粗黑體 & 華康粗黑體(P) (TrueType)", "DFT_B7.TTC", ip);
                CheckFont("華康新特黑體 & 華康新特黑體(P) (TrueType)", "DFT_B9.TTC", ip);
                CheckFont("華康超黑體 & 華康超黑體(P) (TrueType)", "DFT_BC.TTC", ip);
                //CheckFont("微軟正黑體 (TrueType)", "msjh.ttf", ip);
                //CheckFont("微軟正黑體 Bold (TrueType)", "msjhbd.ttf", ip);
            }
        }

        private void CopyImageFromOther(string ip)
        {
            Process p1 = new Process();
            p1.StartInfo.FileName = @"cmd.exe";
            p1.StartInfo.UseShellExecute = false;
            p1.StartInfo.RedirectStandardInput = true;
            p1.StartInfo.RedirectStandardOutput = true;
            p1.StartInfo.RedirectStandardError = true;
            p1.StartInfo.CreateNoWindow = true;

            try
            {
                p1.Start();
                p1.StandardInput.WriteLine(@"net use p: \\" + ip + @"\C$\pxmart\pop px1812 /user:administrator");
                p1.StandardInput.WriteLine(@"XCOPY p:\img C:\pxmart\pop\img /S /D /Y");
                p1.StandardInput.WriteLine(@"net use p: /del /y");
                p1.StandardInput.WriteLine(@"exit");
                string POutput = p1.StandardOutput.ReadToEnd();

                p1.WaitForExit();
                p1.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CopyFontFromBlack(string font_file, string ip)
        {
            Process p1 = new Process();
            p1.StartInfo.FileName = @"cmd.exe";
            p1.StartInfo.UseShellExecute = false;
            p1.StartInfo.RedirectStandardInput = true;
            p1.StartInfo.RedirectStandardOutput = true;
            p1.StartInfo.RedirectStandardError = true;
            p1.StartInfo.CreateNoWindow = true;
            string winFontPath = Environment.GetEnvironmentVariable("WinDir") + "\\Fonts";

            try
            {
                p1.Start();
                p1.StandardInput.WriteLine(@"net use p: \\" + ip + @"\C$\Windows\Fonts px1812 /user:administrator");
                p1.StandardInput.WriteLine(@"XCOPY p:\" + font_file + @"  " + winFontPath + @" /Y");
                p1.StandardInput.WriteLine(@"net use p: /del /y");
                p1.StandardInput.WriteLine(@"exit");
                string POutput = p1.StandardOutput.ReadToEnd();

                p1.WaitForExit();
                p1.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private string GetLocalIP()
        {
            string localIP = "";
            //取得本機IP
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("10.0.2.4", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }

            return localIP;
        }

        private string GetAppVersion()
        {             
            string path = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string file = System.IO.Path.GetFileNameWithoutExtension(path);
            FileInfo f = new FileInfo(path);
            string version = file + "-" + f.LastWriteTime.ToString("yyyy.MM.dd.hh.mm.ss");

            return version;
        }

        static bool PingIP(string IPv4Address)
        {
            IPAddress ip = IPAddress.Parse(IPv4Address);
            Ping pingControl = new Ping();
            PingReply reply = pingControl.Send(ip);
            pingControl.Dispose();
            if (reply.Status != IPStatus.Success)
                return false;
            else
                return true;
        }

        private void CheckFont(string font_name, string font_file, string ip)
        {
            string winFontPath = Environment.GetEnvironmentVariable("WinDir") + "\\Fonts\\" + font_file;

            if (!File.Exists(winFontPath))
            {
                CopyFontFromBlack(font_file, ip);
                try
                {
                    Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts", font_name, font_file, RegistryValueKind.String);
                }
                catch { };
            }
        }
        #endregion

        public FormMain(string status = "PREVIEW")
        {
            PRINT_STATUS = status;
            InitializeComponent();            
        }

        public FormMain(string status, string id) : this(status)
        {
            this.PRINT_ID = id;            
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            DaoPopLog log = new DaoPopLog();
            log.Create_Log_Process();

            Thread thWhitePC = new Thread(CheckIsWhitePC);
            thWhitePC.Start();
            //thWhitePC.Join();

            this.WindowState = FormWindowState.Minimized;

            PREVIEW = ConfigurationManager.AppSettings["PREVIEW"].ToString().Trim();
            if (PREVIEW != "0" && PREVIEW != "1" && PREVIEW != string.Empty)
            {
                _log.Write(LogLevel.ERROE, "PREVIEW參數設定錯誤，程式關閉，請洽詢資訊部，謝謝。");
                MessageBox.Show("PREVIEW參數設定錯誤，程式關閉，請洽詢資訊部，謝謝。", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                Environment.Exit(Environment.ExitCode);
            }
            else
            {
                if (PREVIEW == "0") PRINT_STATUS = "PRINT";
                if (PREVIEW == "1") PRINT_STATUS = "PREVIEW";
            }

            DELETE_DAYS = Convert.ToInt32(ConfigurationManager.AppSettings["DELETE-DAYS"].ToString());
            if (DELETE_DAYS < 0 || DELETE_DAYS > 365)
            {
                _log.Write(LogLevel.ERROE, "DELETE-DAYS參數設定錯誤，程式關閉，請洽詢資訊部，謝謝。");
                MessageBox.Show("DELETE-DAYS參數設定錯誤，程式關閉，請洽詢資訊部，謝謝。", "錯誤",
                   MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                Environment.Exit(Environment.ExitCode);
            }

            try
            {
                PRINT_SOURCE = ConfigurationManager.AppSettings["PRINT-SOURCE"].ToString().Trim();
            }
            catch
            {
                _log.Write(LogLevel.ERROE, "PRINT-SOURCE參數設定錯誤，程式關閉，請洽詢資訊部，謝謝。");
                MessageBox.Show("PRINT-SOURCE參數設定錯誤，程式關閉，請洽詢資訊部，謝謝。", "錯誤",
                   MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                Environment.Exit(Environment.ExitCode);
            }


            this.Text = "POP列印 - " + GetLocalIP();

            //Thread workThread = new Thread(DoWorkingList);
            //workThread.Start(PRINT_ID);
            //MessageBox.Show(GetAppVersion());


            AutoPrint ap = new AutoPrint(GetLocalIP(), GetAppVersion(), PRINT_SOURCE);
            ap.PrintSchedule(PRINT_STATUS, PRINT_ID);



            Application.Exit();
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DaoPopList daoList = new DaoPopList();
            DaoPopDetail daoDetail = new DaoPopDetail();
            daoList.Delete_List(DELETE_DAYS);
            daoDetail.Delete_Detail(DELETE_DAYS);
            Delete_Log(DELETE_DAYS);

            Environment.Exit(Environment.ExitCode);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void Delete_Log(int days)
        {
            foreach (string fname in System.IO.Directory.GetFileSystemEntries(Application.StartupPath + "\\Log"))
            {                
                if (Directory.Exists(fname)) continue;

                FileInfo file = new FileInfo(fname);

                if (DateTime.Now.Subtract(file.CreationTime).TotalDays > days)
                {
                    File.Delete(fname);
                }                
            }
        }
    }
}
