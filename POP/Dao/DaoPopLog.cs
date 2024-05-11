using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace POP.Dao
{
    public class DaoPopLog
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

        public bool Create_Log_Process()
        {
            bool blSec = false;
            SqlConnection SqlConn = new SqlConnection(Connect());

            try
            {
                string Sql_cmd = @" USE [PXMSDE];

                                    IF NOT EXISTS( SELECT * FROM SYS.TABLES WHERE NAME = 'POP_LABLE_LOG' )
                                    BEGIN
	                                    CREATE TABLE [DBO].[POP_LABLE_LOG](
	                                      [SNO] [INT] IDENTITY(1,1) NOT NULL,
	                                      [STOREID] [VARCHAR](10) NOT NULL,
	                                      [PRINTDATE] [VARCHAR](10) NOT NULL,
	                                      [PRINTIP] [VARCHAR](15) NOT NULL,
	                                      [PRINTVERSION] [VARCHAR](50) NOT NULL,
	                                      [PRINTCOUNT] [INT] NOT NULL,
	                                      [PRINTPAPER] [INT] NOT NULL,
	                                      [PRINTTIME_FIRST] [DATETIME] NOT NULL,
	                                      [PRINTTIME_LAST] [DATETIME] NULL,
                                          [PRINTMEMO] [VARCHAR](100) NULL,
	                                    CONSTRAINT [PK_POP_LABLE_LOG] PRIMARY KEY CLUSTERED 
	                                    (
	                                      [STOREID] ASC,
	                                      [PRINTDATE] ASC,
	                                      [PRINTIP] ASC,
                                          [PRINTVERSION] ASC
	                                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	                                    ) ON [PRIMARY]

	                                    ALTER TABLE [DBO].[POP_LABLE_LOG] ADD  CONSTRAINT [DF_POP_LABLE_LOG_PRINTCOUNT]  DEFAULT ((1)) FOR [PRINTCOUNT]
	                                    ALTER TABLE [DBO].[POP_LABLE_LOG] ADD  CONSTRAINT [DF_POP_LABLE_LOG_PRINTPAPER]  DEFAULT ((0)) FOR [PRINTPAPER]
	                                    ALTER TABLE [DBO].[POP_LABLE_LOG] ADD  CONSTRAINT [DF_POP_LABLE_LOG_PRINTTIME_FIRST]  DEFAULT (GETDATE()) FOR [PRINTTIME_FIRST]
                                    END


                                    IF NOT EXISTS ( SELECT * 
                                                FROM   SYSOBJECTS 
                                                WHERE  ID = OBJECT_ID(N'[DBO].[spPOP_LABLE_LOG_INSERT]') 
                                                       AND OBJECTPROPERTY(ID, N'ISPROCEDURE') = 1 )
                                    BEGIN

DECLARE @STOREPROC AS VARCHAR(4000);
SET @STOREPROC = '
CREATE PROCEDURE spPOP_LABLE_LOG_INSERT
	@PRINTIP VARCHAR(15)
	,@PRINTVERSION VARCHAR(50)
    ,@PRINTPAPER INT
AS
BEGIN
	SET NOCOUNT ON;

    IF @PRINTPAPER <= 0 RETURN;

	DECLARE @STOREID   AS VARCHAR(10);
	DECLARE @PRINTDATE AS VARCHAR(10);

	SELECT TOP 1 @STOREID = ISNULL([deptcode], '') FROM [dbo].[dp1mprd];
	SET @PRINTDATE = CONVERT(VARCHAR(10), GETDATE(), 111);

	UPDATE POP_LABLE_LOG
	SET 
			PRINTCOUNT=PRINTCOUNT+1
            ,PRINTPAPER=PRINTPAPER+@PRINTPAPER
			,PRINTTIME_LAST=GETDATE()
	WHERE
			STOREID=@STOREID
			AND PRINTDATE=@PRINTDATE
			AND PRINTIP=@PRINTIP
            AND PRINTVERSION=@PRINTVERSION
  
	IF (@@ROWCOUNT=0)
	BEGIN 
			INSERT INTO POP_LABLE_LOG(STOREID ,PRINTDATE ,PRINTIP ,PRINTVERSION,PRINTCOUNT,PRINTPAPER)
			VALUES(
					@STOREID
					,@PRINTDATE
					,@PRINTIP
					,@PRINTVERSION
					,1
					,@PRINTPAPER)
	END
END	'

	                                    EXEC (@STOREPROC);
                                    END  

                                    IF NOT EXISTS ( SELECT * 
                                                FROM   SYSOBJECTS 
                                                WHERE  ID = OBJECT_ID(N'[DBO].[spHTPOP_PRINT]') 
                                                       AND OBJECTPROPERTY(ID, N'ISPROCEDURE') = 1 )
                                    BEGIN
DECLARE @HTPOPPROC AS VARCHAR(4000);
SET @HTPOPPROC = 'CREATE PROCEDURE [dbo].[spHTPOP_PRINT]
	@GUID VARCHAR(36) = ''''
	,@PRINTTYPE VARCHAR(10) = ''''    
AS
BEGIN

	SET NOCOUNT OFF;
	--SELECT * FROM sys.configurations WHERE name = ''xp_cmdshell''
	
	EXEC sp_configure ''show advanced'',1
	reconfigure;

	--EXEC sp_configure
	
  
	-- 開啟 xp_cmdshell
	EXEC sp_configure ''xp_cmdshell'',1
	reconfigure;
	

	DECLARE @STR AS VARCHAR(2000);
	SET @STR = ''C:\pxmart\POP\ReportingService.exe  '' + @PRINTTYPE + ''  '' +  @GUID ;
	CREATE TABLE #Output (output varchar(100))            
    INSERT INTO #Output     
	EXEC xp_cmdshell @STR
	--PRINT @STR

	--關閉 xp_cmdshell
	EXEC sp_configure ''xp_cmdshell'',0
	reconfigure;
END'
                                    EXEC (@HTPOPPROC);

                                    END";
                SqlCommand com = new SqlCommand(Sql_cmd, SqlConn);

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

        public bool Insert_Log(string ip, string print_version, int print_paper)
        {
            bool blSec = false;
            SqlConnection conn = new SqlConnection(Connect());
            DataTable dt = new DataTable();

            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "spPOP_LABLE_LOG_INSERT";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@PRINTIP", SqlDbType.VarChar);
                cmd.Parameters["@PRINTIP"].Value = ip;

                cmd.Parameters.Add("@PRINTVERSION", SqlDbType.VarChar);
                cmd.Parameters["@PRINTVERSION"].Value = print_version;

                cmd.Parameters.Add("@PRINTPAPER", SqlDbType.Int);
                cmd.Parameters["@PRINTPAPER"].Value = print_paper;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                blSec = true;
            }
            catch (Exception ex)
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

    }
}
