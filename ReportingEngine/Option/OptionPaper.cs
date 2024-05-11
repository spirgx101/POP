using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POP.Dao;
using System.Configuration;
using System.Data.SqlClient;

namespace ReportingEngine.Option
{
    public partial class OptionPaper : UserControl
    {
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();


        public OptionPaper()
        {
            InitializeComponent();

        }

        private void OptionPaper_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;
            GetData();           
        }

        private void GetData()
        {
            try
            {
                string selectCommand = @"SELECT 
                                                PAPER_ID, NAME, KIND, DIRECTION, WIDTH, HEIGHT, ROW, COL, Date, MEMO 
                                           FROM 
                                                [dbo].[POP_LABEL_PAPER] ORDER BY PAPER_ID ";
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
                    @"INSERT INTO [dbo].[POP_LABEL_PAPER]
                                  (PAPER_ID, NAME, KIND, DIRECTION, WIDTH, HEIGHT, ROW, COL, Date, MEMO)
                           VALUES (@PAPER_ID, @NAME, @KIND, @DIRECTION, @WIDTH, @HEIGHT, @ROW, @COL, getdate(), @MEMO)",
                    new SqlConnection(connectionString));

                dataAdapter.InsertCommand.Parameters.Add(
                    "@PAPER_ID", SqlDbType.VarChar, 36, "PAPER_ID");
                dataAdapter.InsertCommand.Parameters.Add(
                    "@NAME", SqlDbType.VarChar, 100, "NAME");
                dataAdapter.InsertCommand.Parameters.Add(
                    "@KIND", SqlDbType.VarChar, 10, "KIND");
                dataAdapter.InsertCommand.Parameters.Add(
                    "@DIRECTION", SqlDbType.Bit, 1, "DIRECTION");
                dataAdapter.InsertCommand.Parameters.Add(
                    "@WIDTH", SqlDbType.Int, 1, "WIDTH");
                dataAdapter.InsertCommand.Parameters.Add(
                    "@HEIGHT", SqlDbType.Int, 1, "HEIGHT");
                dataAdapter.InsertCommand.Parameters.Add(
                    "@ROW", SqlDbType.TinyInt, 1, "ROW");
                dataAdapter.InsertCommand.Parameters.Add(
                    "@COL", SqlDbType.TinyInt, 1, "COL");
                dataAdapter.InsertCommand.Parameters.Add(
                    "@MEMO", SqlDbType.NVarChar, 200, "MEMO");
                #endregion

                #region Update Command
                dataAdapter.UpdateCommand = new SqlCommand(
                    @"UPDATE [dbo].[POP_LABEL_PAPER]
                         SET NAME = @NAME,
                             KIND = @KIND,
                             DIRECTION = @DIRECTION,
                             WIDTH = @WIDTH,
                             HEIGHT = @HEIGHT,
                             ROW = @ROW,
                             COL = @COL,
                             DATE = @DATE,
                             MEMO = @MEMO
                       WHERE PAPER_ID = @PAPER_ID",
                            new SqlConnection(connectionString));

                dataAdapter.UpdateCommand.Parameters.Add(
                    "@NAME", SqlDbType.VarChar, 100, "NAME");
                dataAdapter.UpdateCommand.Parameters.Add(
                    "@KIND", SqlDbType.VarChar, 10, "KIND");
                dataAdapter.UpdateCommand.Parameters.Add(
                    "@DIRECTION", SqlDbType.Bit, 1, "DIRECTION");
                dataAdapter.UpdateCommand.Parameters.Add(
                    "@WIDTH", SqlDbType.Int, 1, "WIDTH");
                dataAdapter.UpdateCommand.Parameters.Add(
                    "@HEIGHT", SqlDbType.Int, 1, "HEIGHT");
                dataAdapter.UpdateCommand.Parameters.Add(
                    "@ROW", SqlDbType.TinyInt, 1, "ROW");
                dataAdapter.UpdateCommand.Parameters.Add(
                    "@COL", SqlDbType.TinyInt, 1, "COL");
                dataAdapter.UpdateCommand.Parameters.Add(
                    "@DATE", SqlDbType.DateTime, 1, "DATE");
                dataAdapter.UpdateCommand.Parameters.Add(
                    "@MEMO", SqlDbType.NVarChar, 200, "MEMO");

                SqlParameter parameter = dataAdapter.UpdateCommand.Parameters.Add(
                                                "@PAPER_ID", SqlDbType.VarChar);
                parameter.SourceColumn = "PAPER_ID";
                parameter.SourceVersion = DataRowVersion.Original;
                #endregion

                #region Delete Command
                dataAdapter.DeleteCommand = new SqlCommand(
                    @"DELETE FROM [dbo].[POP_LABEL_PAPER]
                       WHERE PAPER_ID = @PAPER_ID",
                                    new SqlConnection(connectionString));
                dataAdapter.DeleteCommand.Parameters.Add(
                    "@PAPER_ID", SqlDbType.VarChar, 36, "PAPER_ID");
                #endregion

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                table.Columns["DIRECTION"].DefaultValue = false;
                bindingSource1.DataSource = table;

                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            catch (SqlException)
            {
                MessageBox.Show("資料錯誤，請連絡資訊部。");
            }
        }

        private void tsb_New_Click(object sender, EventArgs e)
        {
            bindingSource1.EndEdit();
            dataAdapter.Update((DataTable)bindingSource1.DataSource);
            GetData();
        }

    }
}
