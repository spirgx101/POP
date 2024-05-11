using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace POP.Dao
{
    public class DaoPopFormat
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

        public DataTable Get_Format_All_Details()
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());
            try
            {

                string cmd = @"SELECT * 
                                 FROM [dbo].[POP_LABEL_FORMAT_DETAIL]
                                ORDER BY FORMAT_ID,FORMAT_SEQ";

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

        public DataTable Get_Format_All_Headers()
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());
            try
            {

                string cmd = @"SELECT * 
                                 FROM [dbo].[POP_LABEL_FORMAT_HEADER]
                                ORDER BY FORMAT_ID ";

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

        /*
        private DataTable Get_Format_Header(string id)
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"SELECT * 
                                 FROM [dbo].[POP_LABEL_FORMAT_HEADER]
                                WHERE FORMAT_ID=@ID";

                SqlCommand com = new SqlCommand(cmd, conn);

                SqlParameter pId = new SqlParameter("@ID", SqlDbType.VarChar);
                pId.Value = id;
                com.Parameters.Add(pId);

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
        */
        public float Get_Format_Width(string id)
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"SELECT FORMAT_WIDTH 
                                 FROM [dbo].[POP_LABEL_FORMAT_HEADER]
                                WHERE FORMAT_ID=@ID";

                SqlCommand com = new SqlCommand(cmd, conn);

                SqlParameter pId = new SqlParameter("@ID", SqlDbType.VarChar);
                pId.Value = id;
                com.Parameters.Add(pId);

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
            return Convert.ToSingle(table.Rows[0]["FORMAT_WIDTH"]);
        }

        public float Get_Format_Height(string id)
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"SELECT FORMAT_HEIGHT 
                                 FROM [dbo].[POP_LABEL_FORMAT_HEADER]
                                WHERE FORMAT_ID=@ID";

                SqlCommand com = new SqlCommand(cmd, conn);

                SqlParameter pId = new SqlParameter("@ID", SqlDbType.VarChar);
                pId.Value = id;
                com.Parameters.Add(pId);

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
            return Convert.ToSingle(table.Rows[0]["FORMAT_HEIGHT"]);
        }

        public DataTable Get_Format_Detail(string id)
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"SELECT * 
                                 FROM [dbo].[POP_LABEL_FORMAT_DETAIL]
                                WHERE FORMAT_ID=@ID 
                                ORDER BY FORMAT_SEQ";

                SqlCommand com = new SqlCommand(cmd, conn);

                SqlParameter pId = new SqlParameter("@ID", SqlDbType.VarChar);
                pId.Value = id;
                com.Parameters.Add(pId);

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

        public DataTable Get_Format_Header(string id)
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"SELECT * 
                                 FROM [dbo].[POP_LABEL_FORMAT_HEADER]
                                WHERE FORMAT_ID=@ID";

                SqlCommand com = new SqlCommand(cmd, conn);

                SqlParameter pId = new SqlParameter("@ID", SqlDbType.VarChar);
                pId.Value = id;
                com.Parameters.Add(pId);

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


        public bool Copy_Format(string old_id, string new_id)
        {
            bool blSec = false;

            DataTable tableHeader = Get_Format_Header(old_id);
            DataTable tableDetail = Get_Format_Detail(old_id);

            for (int i = 0; i < tableHeader.Rows.Count; i++)
            {
                tableHeader.Rows[i]["FORMAT_ID"] = new_id;
            }

            for (int i = 0; i < tableDetail.Rows.Count; i++)
            {
                tableDetail.Rows[i]["FORMAT_ID"] = new_id;
            }

            using (SqlConnection conn = new SqlConnection(Connect()))
            {
                conn.Open();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName =
                        "dbo.POP_LABEL_FORMAT_HEADER";
                    bulkCopy.BulkCopyTimeout = 0;

                    try
                    {
                        bulkCopy.WriteToServer(tableHeader);
                    }
                    catch
                    {
                        blSec = false;
                    }
                    finally
                    {
                        tableHeader.Dispose();
                    }
                }

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName =
                        "dbo.POP_LABEL_FORMAT_DETAIL";
                    bulkCopy.BulkCopyTimeout = 0;

                    try
                    {
                        bulkCopy.WriteToServer(tableDetail);
                    }
                    catch
                    {
                        blSec = false;
                    }
                    finally
                    {
                        tableDetail.Dispose();
                    }
                }

                blSec = true;
            }

            return blSec;
        }

    }
}
