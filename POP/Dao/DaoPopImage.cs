using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace POP.Dao
{
    public class DaoPopImage
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

        public DataTable Get_Image_List()
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"SELECT [IMG_ID]
                                      ,[IMG_NAME]
                                      ,[CRT_DATE]
                                      ,[CRT_USER]
                                 FROM [dbo].[POP_LABEL_IMG]
                                WHERE 1=1
                                ORDER BY CRT_DATE DESC";

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

        public DataTable Get_Image_Detail(string id)
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"SELECT [IMG_ID]
                                      ,[IMG_NAME]
                                      ,[IMG_PATH]
                                      ,[IMG_BYTE]
                                      ,[CRT_DATE]
                                      ,[CRT_USER]
                                      ,[MEMO] 
                                 FROM [dbo].[POP_LABEL_IMG]
                                WHERE 1=1 ";

                SqlCommand com = new SqlCommand(cmd, conn);

                if (id.Length > 0)
                {
                    cmd += @" AND IMG_ID=@ID ";
                    SqlParameter pId = new SqlParameter("@ID", SqlDbType.VarChar);
                    pId.Value = id;
                    com.Parameters.Add(pId);
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

        public byte[] Get_Image(string path)
        {
            byte[] img = null;
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"SELECT [IMG_BYTE]
                                 FROM [dbo].[POP_LABEL_IMG]
                                WHERE 1=1
                                  AND IMG_PATH = @IMG_PATH";

                SqlCommand com = new SqlCommand(cmd, conn);

                SqlParameter pPath = new SqlParameter("@IMG_PATH", SqlDbType.NVarChar);
                pPath.Value = path;
                com.Parameters.Add(pPath);

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

            if (table.Rows.Count > 0)
            {
                img = table.Rows[0]["IMG_BYTE"] as byte[];
            }

            return img;
        }

        public bool Exist_Image(string path)
        {            
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"SELECT *
                                 FROM [dbo].[POP_LABEL_IMG]
                                WHERE 1=1
                                  AND IMG_PATH = @IMG_PATH";

                SqlCommand com = new SqlCommand(cmd, conn);

                SqlParameter pPath = new SqlParameter("@IMG_PATH", SqlDbType.NVarChar);
                pPath.Value = path;
                com.Parameters.Add(pPath);

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

            if (table.Rows.Count == 0)
                return false;
            else
                return true;        
        }

        public bool Insert_Image(string id, string name, string path, byte[] image, string user, string memo)
        {
            bool blSec = false;
            SqlConnection SqlConn = new SqlConnection(Connect());

            try
            {
                string Sql_cmd = @" INSERT INTO [dbo].[POP_LABEL_IMG]
                                        (IMG_ID, IMG_NAME, IMG_PATH, IMG_BYTE, CRT_DATE, CRT_USER, MEMO)
                                    VALUES
                                        (@ID, @NAME, @PATH, @IMG, @DATE, @USER, @MEMO)";
                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);

                SqlParameter pID = new SqlParameter("@ID", SqlDbType.VarChar);
                pID.Value = id;
                com.Parameters.Add(pID);

                SqlParameter pName = new SqlParameter("@NAME", SqlDbType.VarChar);
                pName.Value = name;
                com.Parameters.Add(pName);

                SqlParameter pPath = new SqlParameter("@PATH", SqlDbType.VarChar);
                pPath.Value = path;
                com.Parameters.Add(pPath);

                SqlParameter pImg = new SqlParameter("@IMG", SqlDbType.Binary);
                pImg.Value = image;
                com.Parameters.Add(pImg);

                SqlParameter pDate = new SqlParameter("@DATE", SqlDbType.DateTime);
                pDate.Value = DateTime.Now;
                com.Parameters.Add(pDate);

                SqlParameter pUser = new SqlParameter("@USER", SqlDbType.VarChar);
                pUser.Value = user;
                com.Parameters.Add(pUser);

                SqlParameter pMemo = new SqlParameter("@MEMO", SqlDbType.VarChar);
                pMemo.Value = memo;
                com.Parameters.Add(pMemo);               

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

            return true;
        }

        public bool Delete_Image(string id)
        {
            bool blSec = false;
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"DELETE [dbo].[POP_LABEL_IMG]
                                WHERE IMG_ID=@ID";
                SqlCommand com = new SqlCommand(cmd, conn);

                SqlParameter pID = new SqlParameter("@ID", SqlDbType.VarChar);
                pID.Value = id;
                com.Parameters.Add(pID);

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

        public bool Delete_All_Image()
        {
            bool blSec = false;
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"TRUNCATE TABLE [dbo].[POP_LABEL_IMG] ";
                SqlCommand com = new SqlCommand(cmd, conn);

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

        public bool Sync_Image(string ip)
        {
            bool blSec = false;
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = string.Format(
                             @"INSERT [{0}].[PXMSDE].[dbo].[POP_LABEL_IMG] 
                               SELECT * FROM [dbo].[POP_LABEL_IMG] AS S
                                WHERE NOT EXISTS (
                                    SELECT 1 
                                    FROM [{0}].[PXMSDE].[dbo].[POP_LABEL_IMG]
                                    WHERE IMG_PATH = S.IMG_PATH);

                                DELETE FROM [{0}].[PXMSDE].[dbo].[POP_LABEL_IMG] 
                                WHERE NOT EXISTS
                                  ( SELECT 
		                                IMG_PATH
	                                FROM
		                                [dbo].[POP_LABEL_IMG] A
	                                 WHERE
		                                A.IMG_PATH = IMG_PATH); ", ip);
                SqlCommand com = new SqlCommand(cmd, conn);
                com.CommandTimeout = 0;

                conn.Open();
                com.ExecuteNonQuery();
                blSec = true;
            }
            catch (Exception ex)
            {
                blSec = false;
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return blSec;
        }
    }
}
