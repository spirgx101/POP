using POP.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportingEngine
{
    public partial class FormImageTest : Form
    {
        //string SourceConn = "Data Source=172.31.31.250;Initial Catalog=PXMSDE;User Id=ncf;Password=ksi";
        //string DestConn = "Data Source=172.31.34.3;Initial Catalog=PXMSDE;User Id=sa;Password=px1812";

        public FormImageTest()
        {
            InitializeComponent();
        }

        private void btnTransImag_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;
            lbStartValue.Text = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            string souceConnString = (new POP_DBConn(txtSourceIp.Text.Trim(), txtSourceDB.Text.Trim(), "ncf", "ksi")).GetConnString();
            string destConnString = (new POP_DBConn(txtDestIp.Text.Trim(), txtDestDB.Text.Trim(), "sa", "px1812")).GetConnString();

            SqlConnection sourceConn = new SqlConnection(souceConnString);

            DataTable table = new DataTable();

            try
            {
                string sourceCmdString = @" SELECT *
                                              FROM [dbo].[POP_LABEL_IMG] ";

                //string sourceCmdString = @"SELECT TOP 50 [IMG_ID]
                //                                  ,[IMG_NAME]
                //                                  ,[IMG_PATH]
                //                                  ,[IMG_BYTE]
                //                               ,DATALENGTH([IMG_BYTE]) AS IMG_SIZE
                //                                  ,[CRT_DATE]
                //                                  ,[CRT_USER]
                //                                  ,[MEMO]
                //                              FROM [PXMSDE].[dbo].[POP_LABEL_IMG]
                //                            ORDER BY DATALENGTH([IMG_BYTE]) DESC ";

                SqlCommand sourceComm = new SqlCommand(sourceCmdString, sourceConn);

                sourceConn.Open();

                SqlDataAdapter dapter = new SqlDataAdapter(sourceComm);
                dapter.SelectCommand.Connection = sourceConn;
                dapter.SelectCommand.CommandText = sourceCmdString;
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
                sourceConn.Close();
                sourceConn.Dispose();
            }


            using (SqlConnection destinationConnection = new SqlConnection(destConnString))
            {

                destinationConnection.Open();

                using (SqlBulkCopy bulkCopy =
                           new SqlBulkCopy(destinationConnection))
                {
                    bulkCopy.DestinationTableName =
                        "dbo.POP_LABEL_IMG";
                    bulkCopy.BulkCopyTimeout = 0;

                    try
                    {
                        // Write from the source to the destination.
                        bulkCopy.WriteToServer(table);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        table.Dispose();
                    }
                }

                DateTime end = DateTime.Now;
                lbEndValue.Text = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

                lbBetweenValue.Text = (end - start).ToString();
            }
        }
    }
}
