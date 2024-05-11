using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Printing;
using POP.Dao;
using POP.Lib;
using System.Threading;

namespace ReportingEngine.Option
{
    public partial class OptionFormat : UserControl
    {
        private BindingSource bindingSourceHead = new BindingSource();
        private SqlDataAdapter dataAdapterHead = new SqlDataAdapter();

        private BindingSource bindingSourceDetail = new BindingSource();
        private SqlDataAdapter dataAdapterDetail = new SqlDataAdapter();

        public OptionFormat()
        {
            InitializeComponent();
        }

        private void OptionFormat_Load(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            String sDefaultPrinter = printDoc.PrinterSettings.PrinterName;  // 取得預設的印表機名稱

            // 取得安裝於電腦上的所有印表機名稱，加入 ListBox (Name : lbInstalledPrinters) 中
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                cbbPrinter.Items.Add(strPrinter);
            }

            // ListBox (Name : lbInstalledPrinters) 選擇在預設印表機
            this.cbbPrinter.SelectedIndex = this.cbbPrinter.FindString(sDefaultPrinter);

            dataGridViewHead.DataSource = bindingSourceHead;
            dataGridViewDetail.DataSource = bindingSourceDetail;
            GetHeadData();
            GetDetailData();
        }

        private void GetHeadData()
        {
            try
            {
                string selectCommand = @"SELECT * FROM [dbo].[POP_LABEL_FORMAT_HEADER] ORDER BY FORMAT_ID";
                String connectionString = (new POP_DBConn(
                            ConfigurationManager.AppSettings["Data-Source"].ToString(),
                            new ConfigCipher().Verify("Initial-Catalog"),
                            new ConfigCipher().Verify("User-Id"),
                            new ConfigCipher().Verify("Password")
                        )
                    ).GetConnString(); ;

                dataAdapterHead = new SqlDataAdapter(selectCommand, connectionString);

                #region Update Command
                dataAdapterHead.UpdateCommand = new SqlCommand(
                    @"UPDATE [dbo].[POP_LABEL_FORMAT_HEADER]
                         SET FORMAT_NAME = @FORMAT_NAME,
                             FORMAT_GROUP = @FORMAT_GROUP,
                             FORMAT_WIDTH = @FORMAT_WIDTH,
                             FORMAT_HEIGHT = @FORMAT_HEIGHT,
                             MEMO = @MEMO,
                             EXAMPLE = @EXAMPLE
                       WHERE FORMAT_ID = @FORMAT_ID", 
                    new SqlConnection(connectionString));

                dataAdapterHead.UpdateCommand.Parameters.Add(
                    "@FORMAT_NAME", SqlDbType.NVarChar, 20, "FORMAT_NAME");
                dataAdapterHead.UpdateCommand.Parameters.Add(
                    "@FORMAT_GROUP", SqlDbType.TinyInt, 1, "FORMAT_GROUP");
                dataAdapterHead.UpdateCommand.Parameters.Add(
                    "@FORMAT_WIDTH", SqlDbType.Float, 1, "FORMAT_WIDTH");
                dataAdapterHead.UpdateCommand.Parameters.Add(
                    "@FORMAT_HEIGHT", SqlDbType.Float, 1, "FORMAT_HEIGHT");
                dataAdapterHead.UpdateCommand.Parameters.Add(
                    "@MEMO", SqlDbType.NVarChar, 200, "MEMO");
                dataAdapterHead.UpdateCommand.Parameters.Add(
                    "@EXAMPLE", SqlDbType.NVarChar, 4000, "EXAMPLE");

                SqlParameter parameter = dataAdapterHead.UpdateCommand.Parameters.Add(
                                                "@FORMAT_ID", SqlDbType.VarChar);
                parameter.SourceColumn = "FORMAT_ID";
                parameter.SourceVersion = DataRowVersion.Original;
                #endregion

                #region Delete Command
                dataAdapterHead.DeleteCommand = new SqlCommand(
                    @"DELETE FROM [dbo].[POP_LABEL_FORMAT_HEADER]
                       WHERE FORMAT_ID = @FORMAT_ID",
                                    new SqlConnection(connectionString));
                dataAdapterHead.DeleteCommand.Parameters.Add(
                    "@FORMAT_ID", SqlDbType.VarChar, 20, "FORMAT_ID");
                #endregion

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapterHead);

                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapterHead.Fill(table);
                bindingSourceHead.DataSource = table;

                dataGridViewHead.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetDetailData()
        {
            try
            {
                string selectCommand = string.Format(
                    @"SELECT * FROM [dbo].[POP_LABEL_FORMAT_DETAIL] WHERE FORMAT_ID = '{0}' ORDER BY FORMAT_SEQ",
                        dataGridViewHead.CurrentRow.Cells["FORMAT_ID"].Value.ToString());

                String connectionString = (new POP_DBConn(
                            ConfigurationManager.AppSettings["Data-Source"].ToString(),
                            new ConfigCipher().Verify("Initial-Catalog"),
                            new ConfigCipher().Verify("User-Id"),
                            new ConfigCipher().Verify("Password")
                        )
                    ).GetConnString(); ;

                dataAdapterDetail = new SqlDataAdapter(selectCommand, connectionString);

                #region Update Command
                dataAdapterDetail.UpdateCommand = new SqlCommand(
                    @"UPDATE [dbo].[POP_LABEL_FORMAT_DETAIL]
                         SET PRINT_TYPE = @PRINT_TYPE
                            ,FONT_NAME = @FONT_NAME
                            ,FONT_SIZE = @FONT_SIZE
                            ,FONT_STYLE = @FONT_STYLE
                            ,FONT_COLOR = @FONT_COLOR
                            ,X_SITE = @X_SITE
                            ,Y_SITE = @Y_SITE
                            ,WIDTH = @WIDTH
                            ,HEIGHT = @HEIGHT
                            ,VERTICAL_ALIGN = @VERTICAL_ALIGN
                            ,HORIZONTAL_ALIGN = @HORIZONTAL_ALIGN
                            ,MATRIX = @MATRIX
                            ,X_ZOOM = @X_ZOOM
                            ,Y_ZOOM = @Y_ZOOM
                            ,DIRECTION_VERTICAL = @DIRECTION_VERTICAL
                            ,MEMO = @MEMO
                            ,CRT_DATE = getdate()
                       WHERE FORMAT_ID = @FORMAT_ID 
                         AND FORMAT_SEQ = @FORMAT_SEQ",
                    new SqlConnection(connectionString));

                dataAdapterDetail.UpdateCommand.Parameters.Add(
                    "@PRINT_TYPE", SqlDbType.TinyInt, 1, "PRINT_TYPE");
                dataAdapterDetail.UpdateCommand.Parameters.Add(
                    "@FONT_NAME", SqlDbType.NVarChar, 50, "FONT_NAME");
                dataAdapterDetail.UpdateCommand.Parameters.Add(
                    "@FONT_SIZE", SqlDbType.Float, 1, "FONT_SIZE");
                dataAdapterDetail.UpdateCommand.Parameters.Add(
                    "@FONT_STYLE", SqlDbType.VarChar, 20, "FONT_STYLE");
                dataAdapterDetail.UpdateCommand.Parameters.Add(
                    "@FONT_COLOR", SqlDbType.VarChar, 20, "FONT_COLOR");
                dataAdapterDetail.UpdateCommand.Parameters.Add(
                    "@X_SITE", SqlDbType.Float, 1, "X_SITE");
                dataAdapterDetail.UpdateCommand.Parameters.Add(
                    "@Y_SITE", SqlDbType.Float, 1, "Y_SITE");
                dataAdapterDetail.UpdateCommand.Parameters.Add(
                    "@WIDTH", SqlDbType.Float, 1, "WIDTH");
                dataAdapterDetail.UpdateCommand.Parameters.Add(
                    "@HEIGHT", SqlDbType.Float, 1, "HEIGHT");
                dataAdapterDetail.UpdateCommand.Parameters.Add(
                    "@VERTICAL_ALIGN", SqlDbType.TinyInt, 1, "VERTICAL_ALIGN");
                dataAdapterDetail.UpdateCommand.Parameters.Add(
                    "@HORIZONTAL_ALIGN", SqlDbType.TinyInt, 1, "HORIZONTAL_ALIGN");
                dataAdapterDetail.UpdateCommand.Parameters.Add(
                    "@MATRIX", SqlDbType.Bit, 1, "MATRIX");
                dataAdapterDetail.UpdateCommand.Parameters.Add(
                    "@X_ZOOM", SqlDbType.Float, 1, "X_ZOOM");
                dataAdapterDetail.UpdateCommand.Parameters.Add(
                    "@Y_ZOOM", SqlDbType.Float, 1, "Y_ZOOM");
                dataAdapterDetail.UpdateCommand.Parameters.Add(
                    "@DIRECTION_VERTICAL", SqlDbType.Bit, 1, "DIRECTION_VERTICAL");
                dataAdapterDetail.UpdateCommand.Parameters.Add(
                    "@MEMO", SqlDbType.NVarChar, 200, "MEMO");
                dataAdapterDetail.UpdateCommand.Parameters.Add(
                    "@CRT_DATE", SqlDbType.DateTime, 1, "CRT_DATE");

                SqlParameter parameter = dataAdapterDetail.UpdateCommand.Parameters.Add(
                                                "@FORMAT_ID", SqlDbType.VarChar);
                parameter.SourceColumn = "FORMAT_ID";
                parameter.SourceVersion = DataRowVersion.Original;

                SqlParameter parameter2 = dataAdapterDetail.UpdateCommand.Parameters.Add(
                                                "@FORMAT_SEQ", SqlDbType.TinyInt);
                parameter2.SourceColumn = "FORMAT_SEQ";
                parameter2.SourceVersion = DataRowVersion.Original;
                #endregion

                #region Insert Command
                dataAdapterDetail.InsertCommand = new SqlCommand(
                    @"INSERT INTO [dbo].[POP_LABEL_FORMAT_DETAIL]
                                (FORMAT_ID
                                ,FORMAT_SEQ
                                ,PRINT_TYPE
                                ,FONT_NAME
                                ,FONT_SIZE
                                ,FONT_STYLE
                                ,FONT_COLOR
                                ,X_SITE
                                ,Y_SITE
                                ,WIDTH
                                ,HEIGHT
                                ,VERTICAL_ALIGN
                                ,HORIZONTAL_ALIGN
                                ,MATRIX
                                ,X_ZOOM
                                ,Y_ZOOM
                                ,DIRECTION_VERTICAL
                                ,MEMO
                                ,CRT_DATE)
                         VALUES (@FORMAT_ID
                                ,@FORMAT_SEQ
                                ,@PRINT_TYPE
                                ,@FONT_NAME
                                ,@FONT_SIZE
                                ,@FONT_STYLE
                                ,@FONT_COLOR
                                ,@X_SITE
                                ,@Y_SITE
                                ,@WIDTH
                                ,@HEIGHT
                                ,@VERTICAL_ALIGN
                                ,@HORIZONTAL_ALIGN
                                ,@MATRIX
                                ,@X_ZOOM
                                ,@Y_ZOOM
                                ,@DIRECTION_VERTICAL
                                ,@MEMO
                                ,getdate())",
                    new SqlConnection(connectionString));

                dataAdapterDetail.InsertCommand.Parameters.Add(
                    "@FORMAT_ID", SqlDbType.VarChar, 20, "FORMAT_ID");
                dataAdapterDetail.InsertCommand.Parameters.Add(
                    "@FORMAT_SEQ", SqlDbType.TinyInt, 1, "FORMAT_SEQ");
                dataAdapterDetail.InsertCommand.Parameters.Add(
                    "@PRINT_TYPE", SqlDbType.TinyInt, 1, "PRINT_TYPE");
                dataAdapterDetail.InsertCommand.Parameters.Add(
                    "@FONT_NAME", SqlDbType.NVarChar, 50, "FONT_NAME");
                dataAdapterDetail.InsertCommand.Parameters.Add(
                    "@FONT_SIZE", SqlDbType.Float, 1, "FONT_SIZE");
                dataAdapterDetail.InsertCommand.Parameters.Add(
                    "@FONT_STYLE", SqlDbType.VarChar, 20, "FONT_STYLE");
                dataAdapterDetail.InsertCommand.Parameters.Add(
                    "@FONT_COLOR", SqlDbType.VarChar, 20, "FONT_COLOR");
                dataAdapterDetail.InsertCommand.Parameters.Add(
                    "@X_SITE", SqlDbType.Float, 1, "X_SITE");
                dataAdapterDetail.InsertCommand.Parameters.Add(
                    "@Y_SITE", SqlDbType.Float, 1, "Y_SITE");
                dataAdapterDetail.InsertCommand.Parameters.Add(
                    "@WIDTH", SqlDbType.Float, 1, "WIDTH");
                dataAdapterDetail.InsertCommand.Parameters.Add(
                    "@HEIGHT", SqlDbType.Float, 1, "HEIGHT");
                dataAdapterDetail.InsertCommand.Parameters.Add(
                    "@VERTICAL_ALIGN", SqlDbType.TinyInt, 1, "VERTICAL_ALIGN");
                dataAdapterDetail.InsertCommand.Parameters.Add(
                    "@HORIZONTAL_ALIGN", SqlDbType.TinyInt, 1, "HORIZONTAL_ALIGN");
                dataAdapterDetail.InsertCommand.Parameters.Add(
                    "@MATRIX", SqlDbType.Bit, 1, "MATRIX");
                dataAdapterDetail.InsertCommand.Parameters.Add(
                    "@X_ZOOM", SqlDbType.Float, 1, "X_ZOOM");
                dataAdapterDetail.InsertCommand.Parameters.Add(
                    "@Y_ZOOM", SqlDbType.Float, 1, "Y_ZOOM");
                dataAdapterDetail.InsertCommand.Parameters.Add(
                    "@DIRECTION_VERTICAL", SqlDbType.Bit, 1, "DIRECTION_VERTICAL");
                dataAdapterDetail.InsertCommand.Parameters.Add(
                    "@MEMO", SqlDbType.NVarChar, 200, "MEMO");
                dataAdapterDetail.InsertCommand.Parameters.Add(
                    "@CRT_DATE", SqlDbType.DateTime, 1, "CRT_DATE");
                #endregion

                #region Delete Command
                dataAdapterDetail.DeleteCommand = new SqlCommand(
                    @"DELETE FROM [dbo].[POP_LABEL_FORMAT_DETAIL]
                       WHERE FORMAT_ID = @FORMAT_ID 
                         AND FORMAT_SEQ = @FORMAT_SEQ",
                    new SqlConnection(connectionString));

                dataAdapterDetail.DeleteCommand.Parameters.Add(
                    "@FORMAT_ID", SqlDbType.VarChar, 20, "FORMAT_ID");
                dataAdapterDetail.DeleteCommand.Parameters.Add(
                    "@FORMAT_SEQ", SqlDbType.TinyInt, 1, "FORMAT_SEQ");
                #endregion

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapterHead);

                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapterDetail.Fill(table);
                bindingSourceDetail.DataSource = table;

                dataGridViewDetail.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            bindingSourceDetail.EndEdit();
            dataAdapterDetail.Update((DataTable)bindingSourceDetail.DataSource);
            GetDetailData();
            bindingSourceHead.EndEdit();
            dataAdapterHead.Update((DataTable)bindingSourceHead.DataSource);
            GetHeadData();
        }

        private void dataGridViewHead_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewHead.CurrentRow != null &&
                    dataGridViewHead.CurrentRow.Index >= 0 
                        && dataGridViewHead.CurrentRow.Index != dataGridViewHead.Rows.Count - 1)
            {
                GetDetailData();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

            DaoPopPaper paper = new DaoPopPaper(txtPaperId.Text.Trim());
            string message = dataGridViewHead.CurrentRow.Cells["EXAMPLE"].Value.ToString();
            string format_id = dataGridViewHead.CurrentRow.Cells["FORMAT_ID"].Value.ToString();
            string paper_id = txtPaperId.Text.Trim();
            string printer_id = cbbPrinter.Text.Trim();
            bool draw_rectangle = chkDrawRect.Checked;


            if (paper.Kind.ToUpper() == "EXCEL")
            {
                new Thread (() =>
                {
                    ExcelLayout excel = new ExcelLayout();
                    excel.Preview_Excel_Layout(message, format_id, paper_id, printer_id, draw_rectangle);
                }).Start();
            }
            else
            {
                PageLayout page = new PageLayout();
                page.Message_Preview(message, format_id, paper_id, printer_id, draw_rectangle);
            }

        }

        private void btnPreviewAll_Click(object sender, EventArgs e)
        {
            DaoPopPaper paper = new DaoPopPaper(txtPaperId.Text.Trim());
            string message = dataGridViewHead.CurrentRow.Cells["EXAMPLE"].Value.ToString();
            string format_id = dataGridViewHead.CurrentRow.Cells["FORMAT_ID"].Value.ToString();
            string paper_id = txtPaperId.Text.Trim();
            string batch_id = txtListId.Text.Trim();
            string printer_id = cbbPrinter.Text.Trim();
            bool draw_rectangle = chkDrawRect.Checked;

            if (paper.Kind.ToUpper() == "EXCEL")
            {
                new Thread(() =>
                {
                    ExcelLayout excel = new ExcelLayout();
                    excel.Batch_Excel_Layout(batch_id, paper_id, printer_id, draw_rectangle);
                }).Start();
            }
            else
            {
                PageLayout page = new PageLayout();
                page.Batch_Preview(txtListId.Text, txtPaperId.Text, cbbPrinter.Text, draw_rectangle);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (dataGridViewHead.CurrentRow != null &&
                    dataGridViewHead.CurrentRow.Index >= 0
                        && dataGridViewHead.CurrentRow.Index != dataGridViewHead.Rows.Count - 1)
            {
                string old_id = dataGridViewHead.CurrentRow.Cells["FORMAT_ID"].Value.ToString();
                string new_id = old_id;
                DaoPopFormat daoFormat = new DaoPopFormat();

                do
                {
                    if (InputBox("輸入", "請輸入新的Format ID：", ref new_id) != DialogResult.OK) return;

                    if (daoFormat.Get_Format_Header(new_id).Rows.Count == 0)
                    {
                        if (daoFormat.Copy_Format(old_id, new_id))
                        {
                            MessageBox.Show("複製成功！");
                        }
                        else
                        {
                            MessageBox.Show("複製失敗!");
                        }
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Format ID已存在！", "錯誤",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    }
                    new_id = "";
                }
                while (true);
            }

            btnRefresh_Click(null, null);
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
    }
}
