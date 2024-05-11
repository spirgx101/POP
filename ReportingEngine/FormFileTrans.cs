using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POP.Dao;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Net;
using System.Net.NetworkInformation;
using Pxmart.Log;


namespace ReportingEngine
{
    public partial class FormFileTrans : Form
    {
        private IAsyncResult iar;
        DaoPopStore daoStore = new DaoPopStore();
        public delegate void MyDelegate(string id, int status);
        private MonitorLog _log = new MonitorLog();

        public FormFileTrans()
        {
            InitializeComponent();
        }

        private void FormFileTrans_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("未下傳", 0));
            data.Add(new DictionaryEntry("下傳中", 1));
            data.Add(new DictionaryEntry("下傳完成", 2));
            data.Add(new DictionaryEntry("關閉下傳", 99));
            cbxStatus.DisplayMember = "Key";
            cbxStatus.ValueMember = "Value";
            cbxStatus.DataSource = data;

            dgViewer.DataSource = daoStore.Get_Store_Data();
        }

        private void dgViewer_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 )
            {
                string strStatus = ((DataGridView)sender).Rows[e.RowIndex].Cells["STATUS"].Value.ToString();
                switch (strStatus)
                {
                    case "0":
                        e.CellStyle.BackColor = Color.White;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    case "1":
                        e.CellStyle.BackColor = Color.Orange;
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    case "2":
                        e.CellStyle.BackColor = Color.LawnGreen;
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    case "99":
                        e.CellStyle.BackColor = Color.DimGray;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                }
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            Thread thProcess = new Thread(DoWork);
            thProcess.Start();
        }


        private void Update_Status(string id, int status)
        {          
            daoStore.Set_Store_Status(id, status);
            dgViewer.DataSource = daoStore.Get_Store_Data();
        }

        private void btnSetStatus_Click(object sender, EventArgs e)
        {
            daoStore.Reset_Store_Status(Convert.ToInt32(cbxStatus.SelectedValue.ToString()));
            dgViewer.DataSource = daoStore.Get_Store_Data();
        }


        ///*
        private void DoWork()
        {
            DataTable table = daoStore.Get_Store_Data(0);
            MyDelegate method = new MyDelegate(this.Update_Status);

            foreach (DataRow dr in table.Rows)
            {


                string store_id = dr["ID"].ToString().Trim();

                string store_ip = dr["IP"].ToString().Trim();



                iar = this.BeginInvoke(method, new object[] { store_id, 1 });
                this.EndInvoke(iar);

                if (!PingIP(store_ip))
                {
                    iar = this.BeginInvoke(method, new object[] { store_id, 2 });
                    this.EndInvoke(iar);
                    _log.Write(LogLevel.WARNING, store_id + " - IP ping failed.");
                    continue;
                }

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
                    //p1.StandardInput.WriteLine(@"net use p: \\" + store_ip + @"\C$\Pxmart px1812 /user:administrator");
                    p1.StandardInput.WriteLine(@"net use p: \\" + store_ip + @"\C$ px1812 /user:administrator");
                    //p1.StandardInput.WriteLine(@"XCOPY D:\POP_Install\POP p: /D /E /Y");
                    p1.StandardInput.WriteLine(@"XCOPY C:\POP_Install\POP p: /E /Y");
                    //p1.StandardInput.WriteLine(@"XCOPY D:\store_put\source p:\temp /E /Y");
                    p1.StandardInput.WriteLine(@"net use p: /del /y");
                    p1.StandardInput.WriteLine("exit");

                    string POutput = p1.StandardOutput.ReadToEnd();
                    p1.WaitForExit();
                    p1.Close();
                    _log.Write(LogLevel.WARNING, store_id + " - " + POutput.Substring(1,100));

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

                iar = this.BeginInvoke(method, new object[] { store_id, 2 });
                this.EndInvoke(iar);

                Thread.Sleep(1000);
            }
        }
        //*/

        public bool PingIP(string IPv4Address)
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

    }
}
