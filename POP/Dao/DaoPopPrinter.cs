using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace POP.Dao
{
    public class DaoPopPrinter
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

        public DataTable Get_Printer(string id)
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"SELECT PRINTER_ID, PRINTER_NAME, PRINTER_IP, PRINTER_TYPE, USE_YN, WORK_YN, MEMO
                                 FROM [dbo].[POP_LABEL_PRINTER]
                                WHERE 1=1";

                SqlCommand com = new SqlCommand(cmd, conn);
                if (id.Length > 0)
                {
                    cmd += @" AND PRINTER_ID=@ID ";
                    SqlParameter pId = new SqlParameter("@ID", SqlDbType.VarChar);
                    pId.Value = id;
                    com.Parameters.Add(pId);
                }

                cmd += @" ORDER BY PRINTER_ID ";

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

        public DataTable Get_Use_Printer()
        {
            DataTable table = new DataTable();
            SqlConnection SqlConn = new SqlConnection(Connect());

            try
            {
                string Sql_cmd = @"Select PRINTER_ID,  PRINTER_IP
                                     From dbo.POP_LABEL_PRINTER 
                                    Where USE_YN='1' ";

                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);

                SqlConn.Open();
                SqlDataReader dr = com.ExecuteReader();
                table.Load(dr);
                dr.Close();
            }
            catch (Exception ex)
            { }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }

            return table;


        }

        public bool UpdatePrinterStatus(string ip, bool work)
        {
            bool blSec = false;
            SqlConnection SqlConn = new SqlConnection(Connect());

            try
            {
                string Sql_cmd = @"UPDATE dbo.POP_LABEL_PRINTER
                                      SET WORK_YN=@WORK                                                                       
                                    WHERE PRINTER_IP=@IP";
                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);

                SqlParameter pIP = new SqlParameter("@IP", SqlDbType.VarChar);
                pIP.Value = ip;
                com.Parameters.Add(pIP);

                SqlParameter pWork = new SqlParameter("@WORK", SqlDbType.Bit);
                pWork.Value = work;
                com.Parameters.Add(pWork);

                SqlConn.Open();
                com.ExecuteNonQuery();
                blSec = true;
            }
            catch (Exception ex)
            {
                blSec = false;
            }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }

            return blSec;
        }

        public string Get_Printer_Name(string id)
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());
            string printer = string.Empty;

            try
            {
                string cmd = @" SELECT TOP(1) PRINTER_NAME
	                              FROM [dbo].[POP_LABEL_PRINTER]
	                             WHERE PRINTER_ID = @PRINTER_ID ";

                SqlCommand com = new SqlCommand(cmd, conn);
                conn.Open();

                if (id.Length > 0)
                {
                    SqlParameter pID = new SqlParameter("@PRINTER_ID", SqlDbType.VarChar);
                    pID.Value = id;
                    com.Parameters.Add(pID);
                    SqlDataAdapter dapter = new SqlDataAdapter(com);
                    dapter.SelectCommand.Connection = conn;
                    dapter.SelectCommand.CommandText = cmd;
                    DataSet ds = new DataSet();
                    dapter.Fill(ds);
                    table = ds.Tables[0];

                    foreach (DataRow dr in table.Rows)
                    {
                        printer = dr[0].ToString();
                    }
                }
                else
                {
                    printer = string.Empty;
                }
            }
            catch
            { }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return printer;

        }


    }
}
