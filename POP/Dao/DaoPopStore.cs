using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace POP.Dao
{
    public class DaoPopStore
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

        public DataTable Get_Store_Data()
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"SELECT * 
                                 FROM [dbo].[POP_LABEL_STORE]
                                WHERE 1=1";

                SqlCommand com = new SqlCommand(cmd, conn);

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

        public DataTable Get_Store_Data(int status = 99)
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"SELECT [ID]
                                      ,[NAME]
                                      ,[IP]
                                      ,[STATUS]
                                 FROM [dbo].[POP_LABEL_STORE]
                                WHERE 1=1";

                SqlCommand com = new SqlCommand(cmd, conn);

                if (status != 99)
                {
                    cmd += @" AND STATUS=@STATUS ";
                    SqlParameter pStatus = new SqlParameter("@STATUS", SqlDbType.TinyInt);
                    pStatus.Value = status;
                    com.Parameters.Add(pStatus);
                }

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

        public bool Set_Store_Status(string store_id, int status)
        {
            bool blSec = false;
            SqlConnection SqlConn = new SqlConnection(Connect());

            try
            {
                string Sql_cmd = string.Empty;

                if (status == 1)
                {
                    Sql_cmd = @" UPDATE [dbo].[POP_LABEL_STORE]
                                    SET STATUS=@STATUS,  
                                        B_DATE = GETDATE()                           
                                  WHERE ID=@ID ";
                }
                else if (status == 2)
                {
                    Sql_cmd = @" UPDATE [dbo].[POP_LABEL_STORE]
                                    SET STATUS=@STATUS,
                                        E_DATE = GETDATE(),
	                                    INTERVAL = DATEDIFF(S, B_DATE ,GETDATE())                                                             
                                  WHERE ID=@ID ";                
                }

                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);

                SqlParameter pID = new SqlParameter("@ID", SqlDbType.VarChar);
                pID.Value = store_id;
                com.Parameters.Add(pID);

                SqlParameter pStatus = new SqlParameter("@STATUS", SqlDbType.Int);
                pStatus.Value = status;
                com.Parameters.Add(pStatus);

                SqlConn.Open();
                com.ExecuteNonQuery();
                blSec = true;
            }
            catch
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

        public bool Reset_Store_Status(int status)
        {
            bool blSec = false;
            SqlConnection SqlConn = new SqlConnection(Connect());

            try
            {
                string Sql_cmd = @" UPDATE [PXMSDE].[dbo].[POP_LABEL_STORE]
                                       SET [STATUS] = @STATUS,
	                                       B_DATE = NULL,
	                                       E_DATE = NULL,
	                                       INTERVAL = NULL                          
                                     WHERE 1=1 ";                

                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);

                SqlParameter pStatus = new SqlParameter("@STATUS", SqlDbType.Int);
                pStatus.Value = status;
                com.Parameters.Add(pStatus);

                SqlConn.Open();
                com.ExecuteNonQuery();
                blSec = true;
            }
            catch
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

/*
        public bool Set_Store_Status(string store_id, int status)
        {
            bool blSec = false;
            SqlConnection SqlConn = new SqlConnection(Connect());

            try
            {
                string Sql_cmd = @" UPDATE [dbo].[POP_LABEL_STORE]
                                       SET STATUS=@STATUS                                                                     
                                     WHERE ID=@ID ";
                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);

                SqlParameter pID = new SqlParameter("@ID", SqlDbType.VarChar);
                pID.Value = store_id;
                com.Parameters.Add(pID);

                SqlParameter pStatus = new SqlParameter("@STATUS", SqlDbType.Int);
                pStatus.Value = status;
                com.Parameters.Add(pStatus);

                SqlConn.Open();
                com.ExecuteNonQuery();
                blSec = true;
            }
            catch
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
*/

    }

}
