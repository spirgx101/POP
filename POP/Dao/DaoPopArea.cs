using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace POP.Dao
{
    public class DaoPopArea
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

        public DataTable Get_Area(string area)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"SELECT A.[ID] AS [ID], 
                                          A.[AREA] AS [AREA], 
                                          A.[TYPE] AS [TYPE], 
                                          A.[PRINTER_ID] AS [PRINTER_ID],
                                          B.[PRINTER_NAME] AS [PRINTER_NAME],
                                          A.[WORK_YN] AS [WORK_YN],
                                          A.[MEMO] AS [MEMO]
                                     FROM [dbo].[POP_LABEL_AREA] A,
                                          [dbo].[POP_LABEL_PRINTER] B 
                                    WHERE A.[PRINTER_ID]=B.[PRINTER_ID] ";
                if (area.Length > 0)
                    cmd += " AND A.[AREA]=@AREA ";

                cmd += " ORDER BY A.[AREA], A.[TYPE], A.[PRINTER_ID] ";

                SqlCommand com = new SqlCommand(cmd, conn);

                if (area.Length > 0)
                {
                    com.Parameters.Add("@AREA", SqlDbType.VarChar).Value = area;
                }

                conn.Open();
                SqlDataReader dr = com.ExecuteReader();
                dt.Load(dr);
                dr.Close();
            }
            catch (Exception ex)
            { }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return dt;
        }

        public bool Insert_Area(string area, string type, string printer, bool work, string memo)
        {
            bool blSec = false;
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string Sql_cmd = @"INSERT INTO [dbo].[POP_LABEL_AREA]
                                        ([AREA], [TYPE], [PRINTER_ID], [WORK_YN], [MEMO])
                                   VALUES 
                                        (@AREA, @TYPE, @PRINTER_ID, @WORK_YN, @MEMO) ";
                SqlCommand com = new SqlCommand(Sql_cmd, conn);

                com.Parameters.Add("@AREA", SqlDbType.VarChar).Value = area;
                com.Parameters.Add("@TYPE", SqlDbType.VarChar).Value = type;
                com.Parameters.Add("@PRINTER_ID", SqlDbType.VarChar).Value = printer;
                com.Parameters.Add("@WORK_YN", SqlDbType.Bit).Value = work;
                com.Parameters.Add("@MEMO", SqlDbType.VarChar).Value = memo;

                conn.Open();
                com.ExecuteNonQuery();
                blSec = true;
            }
            catch
            {
                blSec = false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return blSec;
        }

        public bool Delete_Area(int id)
        {
            bool blSec = false;
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"DELETE [dbo].[POP_LABEL_AREA]
                                WHERE ID=@ID";
                SqlCommand com = new SqlCommand(cmd, conn);

                com.Parameters.Add("@ID", SqlDbType.VarChar).Value = id;

                conn.Open();
                com.ExecuteNonQuery();
                blSec = true;
            }
            catch
            {
                blSec = false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return blSec;
        }

        public bool Has_Area_Row(string area, string type, string printer)
        {
            bool blSec = false;
            DataTable dt = new DataTable();
            SqlConnection SqlConn = new SqlConnection(Connect());

            try
            {
                string Sql_cmd = @"SELECT 
                                        [ID], [AREA], [TYPE], [PRINTER_ID], [MEMO]
                                    FROM
                                        [dbo].[POP_LABEL_AREA]
                                    WHERE 1=1 
                                        AND [AREA]=@AREA
                                        AND [TYPE]=@TYPE
                                        AND [PRINTER_ID]=@PRINTER_ID ";
                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);

                com.Parameters.Add("@AREA", SqlDbType.VarChar).Value = area;
                com.Parameters.Add("@TYPE", SqlDbType.VarChar).Value = type;
                com.Parameters.Add("@PRINTER_ID", SqlDbType.VarChar).Value = printer;

                SqlConn.Open();
                SqlDataReader dr = com.ExecuteReader();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                    blSec = true;
                else
                    blSec = false;
                dr.Close();
            }
            catch { }
            finally
            {
                SqlConn.Close();
                SqlConn.Dispose();
            }

            return blSec;
        }

        public bool Update_Area(int id, string device, bool work, string memo)
        {
            bool blSec = false;
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"UPDATE [dbo].[POP_LABEL_AREA]
                                  SET [MEMO]=@MEMO,
                                      [WORK_YN]=@WORK_YN,
                                      [PRINTER_ID]=@PRINTER_ID                                          
                                WHERE ID=@ID    ";
                SqlCommand com = new SqlCommand(cmd, conn);

                com.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                com.Parameters.Add("@MEMO", SqlDbType.VarChar).Value = memo;
                com.Parameters.Add("@WORK_YN", SqlDbType.Bit).Value = work;
                com.Parameters.Add("@PRINTER_ID", SqlDbType.VarChar).Value = device;

                conn.Open();
                com.ExecuteNonQuery();
                blSec = true;
            }
            catch
            {
                blSec = false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return blSec;
        }

        public bool Update_AreaStatus(string ip, bool work)
        {
            bool blSec = false;
            SqlConnection SqlConn = new SqlConnection(Connect());

            try
            {
                string Sql_cmd = @"UPDATE [dbo].[POP_LABEL_AREA]
                                      SET WORK_YN = @WORK
                                     FROM [dbo].[POP_LABEL_PRINTER] B
                                    WHERE [dbo].[POP_LABEL_AREA].PRINTER_ID = B.PRINTER_ID
                                      AND B.PRINTER_IP = @IP";

                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);


                com.Parameters.Add("@IP", SqlDbType.VarChar).Value = ip;
                com.Parameters.Add("@WORK", SqlDbType.VarChar).Value = work;

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

        public string Get_Printer(string area)
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());
            string printer = string.Empty;

            try
            {
                string cmd = @" SELECT TOP(1) 
	                                   B.PRINTER_NAME
	                              FROM [dbo].[POP_LABEL_AREA] A,
		                               [dbo].[POP_LABEL_PRINTER] B
	                             WHERE A.AREA = @AREA
	                               AND A.PRINTER_ID = B.PRINTER_ID
	                               AND A.WORK_YN = '1'
	                             ORDER BY A.[TYPE] ";

                SqlCommand com = new SqlCommand(cmd, conn);
                conn.Open();

                if (area.Length > 0)
                {
                    com.Parameters.Add("@AREA", SqlDbType.VarChar).Value = area;
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
