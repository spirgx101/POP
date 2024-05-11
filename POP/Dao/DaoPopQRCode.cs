using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace POP.Dao
{
    public class DaoPopQRCode
    {
        private string Connect()
        {
            return (new POP_DBConn(
                    ConfigurationManager.AppSettings["Data-Source"].ToString(),
                    new ConfigCipher().Verify("Initial-Catalog"),
                    new ConfigCipher().Verify("User-Id"),
                    new ConfigCipher().Verify("Password")
                )
            ).GetConnString();
            //return ConfigurationManager.AppSettings["PRINT-DB"].ToString();
        }

        public DataTable Get_QRData(string id)
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"SELECT * 
                                 FROM [dbo].[POP_LABEL_QRCODE]
                                WHERE 1=1";

                SqlCommand com = new SqlCommand(cmd, conn);
                if (id.Length > 0)
                {
                    cmd += @" and ID=@ID ";
                    SqlParameter pId = new SqlParameter("@ID", SqlDbType.VarChar);
                    pId.Value = id;
                    com.Parameters.Add(pId);
                }

                cmd += @" ORDER BY QR_SEQ ";

                conn.Open();
                SqlDataAdapter dapter = new SqlDataAdapter(com);
                dapter.SelectCommand.Connection = conn;
                dapter.SelectCommand.CommandText = cmd;
                DataSet ds = new DataSet();
                dapter.Fill(ds);
                table = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return table;
        }
    }
}
