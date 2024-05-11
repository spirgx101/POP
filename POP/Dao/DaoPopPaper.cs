using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace POP.Dao
{
    public class DaoPopPaper
    {
        private DataTable _table = new DataTable();

        public string Kind
        {
            get
            {
                return _table.Rows[0]["KIND"].ToString().Trim();
            }
        }
        public bool Direction
        {
            get
            {
                return (bool)_table.Rows[0]["DIRECTION"];
            }
        }
        public int Width
        {
            get
            {
                return (int)_table.Rows[0]["WIDTH"];
            }
        }
        public int Height
        {
            get
            {
                return (int)_table.Rows[0]["HEIGHT"];
            }
        }
        public bool RowFirst
        {
            get
            {
                return (bool)_table.Rows[0]["ROW_FIRST"];
            }
        }
        public int RowSize
        {
            get
            {
                return (int)_table.Rows[0]["ROW"];
            }
        }
        public int ColumnSize
        {
            get
            {
                return (int)_table.Rows[0]["COL"];
            }
        }
        public string Memo
        {
            get
            {
                return _table.Rows[0]["MEMO"].ToString().Trim();
            }
        }
        public string PrinterName
        {
            get
            {
                return _table.Rows[0]["NAME"].ToString().Trim();
            }
        }

        public DaoPopPaper(string id)
        {
            _table = Get_Paper(id);
            if (_table.Rows.Count == 0)
                throw new Exception("沒有此Paper ID設定資料。");
            if (_table.Rows.Count > 1)
                throw new Exception("此Paper ID有多筆資料。");
        }

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

        private DataTable Get_Paper(string id)
        {
            DataTable table = new DataTable();
            SqlConnection conn = new SqlConnection(Connect());

            try
            {
                string cmd = @"SELECT [PAPER_ID]
	                                  ,[NAME]
	                                  ,[KIND]
	                                  ,[DIRECTION]
	                                  ,[WIDTH]
	                                  ,[HEIGHT]
	                                  ,[ROW]
	                                  ,[COL]
	                                  ,[DATE]
	                                  ,[MEMO]
                                  FROM [dbo].[POP_LABEL_PAPER]
                                 WHERE 1=1";

                SqlCommand com = new SqlCommand(cmd, conn);
                if (id.Length > 0)
                {
                    cmd += @" AND [PAPER_ID]=@ID ";
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

    }
}
