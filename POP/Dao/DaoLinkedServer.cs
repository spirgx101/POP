using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace POP.Dao
{
    public class DaoLinkedServer
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


        public void RunSP_Linked_Server(string ip)
        {
            //bool isSuccess = false;
            SqlConnection conn = new SqlConnection(Connect());
            DataTable dt = new DataTable();

            try
            {
                //SqlCommand cmd = new SqlCommand("master.dbo.sp_addlinkedserver ", conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@server", SqlDbType.NVarChar);
                //cmd.Parameters["@server"].Value = ip;

                //cmd.Parameters.Add("@srvproduct", SqlDbType.NVarChar);
                //cmd.Parameters["@srvproduct"].Value = @"SQL Server";

                SqlCommand cmd2 = new SqlCommand("master.dbo.sp_addlinkedsrvlogin ", conn);
                cmd2.CommandType = CommandType.StoredProcedure;

                cmd2.Parameters.Add("@rmtsrvname", SqlDbType.NVarChar);
                cmd2.Parameters["@rmtsrvname"].Value = ip;

                cmd2.Parameters.Add("@useself", SqlDbType.NVarChar);
                cmd2.Parameters["@useself"].Value = @"False";

                cmd2.Parameters.Add("@locallogin", SqlDbType.NVarChar);
                cmd2.Parameters["@locallogin"].Value = @"ncf";

                cmd2.Parameters.Add("@rmtuser", SqlDbType.NVarChar);
                cmd2.Parameters["@rmtuser"].Value = @"sa";

                cmd2.Parameters.Add("@rmtpassword", SqlDbType.NVarChar);
                cmd2.Parameters["@rmtpassword"].Value = @"px1812";

                conn.Open();
                //cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();




                //SqlDataAdapter da3 = new SqlDataAdapter(cmd);
                //da3.Fill(dt);
                //isSuccess = true;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            //return isSuccess;


        }
    }
}
