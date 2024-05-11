using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Pxmart.Log;

namespace ReportingService
{
    static class Program
    {
       
        private static MonitorLog _log = new MonitorLog();

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 0)
            {         
                Application.Run(new FormMain());                
            }
            else if (args.Length == 1)
            {
                Application.Run(new FormMain(args[0].Trim().ToUpper()));
            }
            else if (args.Length == 2)
            {               
                Application.Run(new FormMain(args[0].Trim().ToUpper(), args[1].Trim().ToUpper()));
            }
        }
    }
}
