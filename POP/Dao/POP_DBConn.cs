using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace POP.Dao
{
    public class POP_DBConn
    {
        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();

        public POP_DBConn(string dataSource, string initialCatalog, string userId, string password)
        {
            //string dataSource = string.Empty;  

            if (dataSource == string.Empty)
            {
                string ipaddress = GetLocalIP();
                dataSource = ipaddress.Substring(0, ipaddress.LastIndexOf(".") + 1) + "3";

                //IPHostEntry iphostentry = Dns.GetHostEntry(Dns.GetHostName());   //取得本機的 IpHostEntry 類別實體

                //foreach (IPAddress ipaddress in iphostentry.AddressList)
                //{
                //    if (ipaddress.AddressFamily == AddressFamily.InterNetwork)
                //    {
                //        if (ipaddress.ToString().StartsWith("172."))
                //        {
                //            dataSource = ipaddress.ToString();
                //            dataSource = dataSource.Substring(0, dataSource.LastIndexOf(".") + 1) + "3";
                //        }
                //    }
                //}
            }

            if (dataSource == string.Empty)
            {
                throw new Exception("Data Source is empty.");
            }

            //throw new Exception(dataSource);

            scsb.DataSource = dataSource;
            scsb.InitialCatalog = initialCatalog;
            scsb.UserID = userId;
            scsb.Password = password;
            scsb.IntegratedSecurity = false;
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

        public string GetConnString()
        {
            return scsb.ConnectionString;
        }

    }
}
