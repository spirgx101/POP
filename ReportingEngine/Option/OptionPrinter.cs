using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using POP.Dao;

namespace ReportingEngine.Option
{
    public partial class OptionPrinter : UserControl
    {
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public OptionPrinter()
        {
            InitializeComponent();
        }

        private void tsb_New_Click(object sender, EventArgs e)
        {
            bindingSource1.EndEdit();
            dataAdapter.Update((DataTable)bindingSource1.DataSource);
            GetData();
        }

        private void OptionPrinter_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;
            GetData();
        }

        private void GetData()
        {
            try
            {
                string selectCommand = @"SELECT * FROM [dbo].[POP_LABEL_PRINTER] ORDER BY PRINTER_ID";
                String connectionString = (new POP_DBConn(
                            ConfigurationManager.AppSettings["Data-Source"].ToString(),
                            new ConfigCipher().Verify("Initial-Catalog"),
                            new ConfigCipher().Verify("User-Id"),
                            new ConfigCipher().Verify("Password")
                        )
                    ).GetConnString(); ;

                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                #region Insert Command
                dataAdapter.InsertCommand = new SqlCommand(
                    @"INSERT INTO [dbo].[POP_LABEL_PRINTER]
                                  (PRINTER_ID, PRINTER_NAME, PRINTER_IP, PRINTER_TYPE, USE_YN, WORK_YN, MEMO)
                           VALUES (@PRINTER_ID, @PRINTER_NAME, @PRINTER_IP, @PRINTER_TYPE, @USE_YN, @WORK_YN, @MEMO)",
                    new SqlConnection(connectionString));

                dataAdapter.InsertCommand.Parameters.Add(
                    "@PRINTER_ID", SqlDbType.VarChar, 50, "PRINTER_ID");
                dataAdapter.InsertCommand.Parameters.Add(
                    "@PRINTER_NAME", SqlDbType.VarChar, 100, "PRINTER_NAME");
                dataAdapter.InsertCommand.Parameters.Add(
                    "@PRINTER_IP", SqlDbType.VarChar, 15, "PRINTER_IP");
                dataAdapter.InsertCommand.Parameters.Add(
                    "@PRINTER_TYPE", SqlDbType.VarChar, 30, "PRINTER_TYPE");
                dataAdapter.InsertCommand.Parameters.Add(
                    "@USE_YN", SqlDbType.Bit, 1, "USE_YN");
                dataAdapter.InsertCommand.Parameters.Add(
                    "@WORK_YN", SqlDbType.Bit, 1, "WORK_YN");
                dataAdapter.InsertCommand.Parameters.Add(
                    "@MEMO", SqlDbType.VarChar, 200, "MEMO");
                #endregion

                #region Update Command
                dataAdapter.UpdateCommand = new SqlCommand(
                    @"UPDATE [dbo].[POP_LABEL_PRINTER]
                         SET PRINTER_NAME = @PRINTER_NAME,
                             PRINTER_IP = @PRINTER_IP,                            
                             PRINTER_TYPE = @PRINTER_TYPE,
                             USE_YN = @USE_YN,
                             WORK_YN = @WORK_YN,
                             MEMO = @MEMO
                       WHERE PRINTER_ID = @PRINTER_ID",
                            new SqlConnection(connectionString));

                dataAdapter.UpdateCommand.Parameters.Add(
                    "@PRINTER_NAME", SqlDbType.VarChar, 100, "PRINTER_NAME");
                dataAdapter.UpdateCommand.Parameters.Add(
                    "@PRINTER_IP", SqlDbType.VarChar, 15, "PRINTER_IP");
                dataAdapter.UpdateCommand.Parameters.Add(
                    "@PRINTER_TYPE", SqlDbType.VarChar, 30, "PRINTER_TYPE");
                dataAdapter.UpdateCommand.Parameters.Add(
                    "@USE_YN", SqlDbType.Bit, 1, "USE_YN");
                dataAdapter.UpdateCommand.Parameters.Add(
                    "@WORK_YN", SqlDbType.Bit, 1, "WORK_YN");                
                dataAdapter.UpdateCommand.Parameters.Add(
                    "@MEMO", SqlDbType.NVarChar, 200, "MEMO");

                SqlParameter parameter = dataAdapter.UpdateCommand.Parameters.Add(
                                                "@PRINTER_ID", SqlDbType.VarChar);
                parameter.SourceColumn = "PRINTER_ID";
                parameter.SourceVersion = DataRowVersion.Original;
                #endregion

                #region Delete Command
                dataAdapter.DeleteCommand = new SqlCommand(
                    @"DELETE FROM [dbo].[POP_LABEL_PRINTER]
                       WHERE PRINTER_ID = @PRINTER_ID",
                                    new SqlConnection(connectionString));
                dataAdapter.DeleteCommand.Parameters.Add(
                    "@PRINTER_ID", SqlDbType.VarChar, 50, "PRINTER_ID");
                #endregion


                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                table.Columns["USE_YN"].DefaultValue = false;
                table.Columns["WORK_YN"].DefaultValue = false;
                bindingSource1.DataSource = table;

                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.DisplayedCells);

            }
            catch (SqlException)
            {
                MessageBox.Show("資料錯誤，請連絡資訊部。");
            }
        }
    }
}
