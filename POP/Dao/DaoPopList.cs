using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace POP.Dao
{
    public class DaoPopList
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

        public DataTable Get_List(string id)
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"SELECT 
	                                A.ID, A.NAME, A.PAPER_ID, A.AREA, A.PRINTER, B.KIND, A.B_DATE, A.E_DATE, A.MEMO, 
	                                CASE A.STATUS
	                                 WHEN 0 THEN '未處理'
	                                 WHEN 1 THEN '處理中'
	                                 WHEN 2 THEN '處理完成'
	                                 WHEN 9 THEN '錯誤'
	                                 ELSE '無法識別' 
	                                END AS STATUS
                                FROM 
	                                [dbo].[POP_LABEL_LIST] A
	                                LEFT JOIN
		                                [dbo].[POP_LABEL_PAPER] B
		                                ON A.PAPER_ID = B.PAPER_ID
                                WHERE 1=1
                                  AND A.STATUS = 0";

                SqlCommand com = new SqlCommand(cmd, conn);

                if (id.Length > 0)
                {
                    cmd += @" AND ID=@ID ";
                    SqlParameter pId = new SqlParameter("@ID", SqlDbType.VarChar);
                    pId.Value = id;
                    com.Parameters.Add(pId);
                }

                cmd += @" ORDER BY A.B_DATE ";

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

        public DataTable Get_List(int status = 99)
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"SELECT 
	                                A.ID, A.NAME, A.PAPER_ID, A.AREA, A.PRINTER, B.KIND, A.B_DATE, A.E_DATE, A.MEMO, 
	                                CASE A.STATUS
	                                 WHEN 0 THEN '未處理'
	                                 WHEN 1 THEN '處理中'
	                                 WHEN 2 THEN '處理完成'
	                                 WHEN 9 THEN '錯誤'
	                                 ELSE '無法識別' 
	                                END AS STATUS
                                FROM 
	                                [dbo].[POP_LABEL_LIST] A
	                                LEFT JOIN
		                                [dbo].[POP_LABEL_PAPER] B
		                                ON A.PAPER_ID = B.PAPER_ID
                                WHERE 1=1";

                SqlCommand com = new SqlCommand(cmd, conn);
                
                cmd += @" AND CONVERT(CHAR, A.B_DATE, 112)=@B_DATE ";
                SqlParameter pDate = new SqlParameter("@B_DATE", SqlDbType.VarChar);
                pDate.Value = DateTime.Now.Date.ToString("yyyyMMdd");
                com.Parameters.Add(pDate);

                if (status != 99)
                {
                    cmd += @" AND STATUS = @STATUS";
                    SqlParameter pStatus = new SqlParameter("@STATUS", SqlDbType.Int);
                    pStatus.Value = status;
                    com.Parameters.Add(pStatus);
                }

                cmd += @" ORDER BY A.B_DATE DESC";

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

        public DataTable Get_One_Work()
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"SELECT TOP 1
	                                A.ID, A.NAME, A.PAPER_ID, A.AREA, A.PRINTER, B.KIND, A.B_DATE, A.E_DATE, A.MEMO, 
	                                CASE A.[STATUS]
	                                 WHEN 0 THEN '未處理'
	                                 WHEN 1 THEN '處理中'
	                                 WHEN 2 THEN '處理完成'
	                                 WHEN 9 THEN '錯誤'
	                                 ELSE '無法識別' 
	                                END AS [STATUS]
                                FROM 
	                                [dbo].[POP_LABEL_LIST] A
	                                LEFT JOIN
		                                [dbo].[POP_LABEL_PAPER] B
		                                ON A.PAPER_ID = B.PAPER_ID
                                WHERE 1=1 
                                AND A.[STATUS] = 0 ";

                SqlCommand com = new SqlCommand(cmd, conn);

                cmd += @" AND CONVERT(CHAR, A.B_DATE, 112) = CONVERT(CHAR, GETDATE(), 112) ";             
                cmd += @" ORDER BY A.B_DATE DESC ";

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

        public DataTable Get_One_Work(string id)
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"SELECT TOP 1
	                                A.ID, A.NAME, A.PAPER_ID, A.AREA, A.PRINTER, B.KIND, A.B_DATE, A.E_DATE, A.MEMO, 
	                                CASE A.[STATUS]
	                                 WHEN 0 THEN '未處理'
	                                 WHEN 1 THEN '處理中'
	                                 WHEN 2 THEN '處理完成'
	                                 WHEN 9 THEN '錯誤'
	                                 ELSE '無法識別' 
	                                END AS [STATUS]
                                FROM 
	                                [dbo].[POP_LABEL_LIST] A
	                                LEFT JOIN
		                                [dbo].[POP_LABEL_PAPER] B
		                                ON A.PAPER_ID = B.PAPER_ID
                                WHERE 1=1 
                                AND A.[STATUS] = 0 ";

                SqlCommand com = new SqlCommand(cmd, conn);

                if (id.Length > 0)
                {
                    cmd += @" AND ID=@ID ";
                    SqlParameter pId = new SqlParameter("@ID", SqlDbType.VarChar);
                    pId.Value = id;
                    com.Parameters.Add(pId);
                }

                //cmd += @" AND CONVERT(CHAR, A.B_DATE, 112) = CONVERT(CHAR, GETDATE(), 112) ";
                //cmd += @" ORDER BY A.B_DATE DESC ";

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

        public bool Update_ListStatus(string list_id, int status)
        {
            bool blSec = false;
            SqlConnection SqlConn = new SqlConnection(Connect());

            try
            {
                string Sql_cmd = @" UPDATE [dbo].[POP_LABEL_LIST]
                                       SET E_DATE=@E_DATE,
                                           STATUS=@STATUS                                                                     
                                     WHERE ID=@ID ";
                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);

                SqlParameter pID = new SqlParameter("@ID", SqlDbType.VarChar);
                pID.Value = list_id;
                com.Parameters.Add(pID);

                SqlParameter pEDate = new SqlParameter("@E_DATE", SqlDbType.DateTime);
                pEDate.Value = DateTime.Now;
                com.Parameters.Add(pEDate);

                SqlParameter pStatus = new SqlParameter("@STATUS", SqlDbType.Int);
                pStatus.Value = status;
                com.Parameters.Add(pStatus);

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

        public bool Delete_List(int days)
        {
            bool blSec = false;
            SqlConnection SqlConn = new SqlConnection(Connect());

            try
            {
                string Sql_cmd = @"DELETE [dbo].[POP_LABEL_LIST]
                                    WHERE B_DATE < GETDATE() - @DAYS ";
                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);

                SqlParameter pDays = new SqlParameter("@DAYS", SqlDbType.Int);
                pDays.Value = days;
                com.Parameters.Add(pDays);

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

        public bool Update_ListMemo(string list_id, string memo)
        {
            bool blSec = false;
            SqlConnection SqlConn = new SqlConnection(Connect());

            try
            {
                string Sql_cmd = @" UPDATE [dbo].[POP_LABEL_LIST]
                                       SET MEMO=@MEMO                                                                     
                                     WHERE ID=@ID ";
                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);

                SqlParameter pID = new SqlParameter("@ID", SqlDbType.VarChar);
                pID.Value = list_id;
                com.Parameters.Add(pID);

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

            return blSec;
        }
    }
}
