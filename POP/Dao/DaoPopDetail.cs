using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace POP.Dao
{
    public class DaoPopDetail
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

        public DataTable Get_Detail(string id)
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"SELECT * 
                                 FROM [dbo].[POP_LABEL_DETAIL]
                                WHERE 1=1";

                SqlCommand com = new SqlCommand(cmd, conn);
                if (id.Length > 0)
                {
                    cmd += @" and ID=@ID ";
                    com.Parameters.Add("@ID", SqlDbType.VarChar).Value = id;
                }

                cmd += @" ORDER BY PRINT_SEQ ";

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

        public bool Delete_Detail(int days)
        {
            bool blSec = false;
            SqlConnection SqlConn = new SqlConnection(Connect());

            try
            {
                string Sql_cmd = @"DELETE [dbo].[POP_LABEL_DETAIL]
                                    WHERE CRT_DATE < GETDATE() - @DAYS ";
                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);

                com.Parameters.Add("@DAYS", SqlDbType.Int).Value = days;

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
