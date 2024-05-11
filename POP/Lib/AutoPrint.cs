using System;
using System.Data;
using POP.Dao;
using CoolPrintPreview;
using System.Windows.Forms;
using System.Drawing.Printing;
using Pxmart.Log;


namespace POP.Lib
{  
    public class AutoPrint
    {
        private static readonly float INCH = 0.254f;
        private string PRINT_STATUS;
        private MonitorLog _log = new MonitorLog();
        private bool Printed = false;
        private string IP = string.Empty;
        private string VERSION = string.Empty;
        private string PRINT_SOURCE = string.Empty;
        
        public AutoPrint(string ip, string version, string print_source)
        {
            IP = ip;
            VERSION = version;
            PRINT_SOURCE = print_source;
        }   

        public void PrintSchedule(string print_status, string print_id)
        {
            PRINT_STATUS = print_status;
            //MessageBox.Show(print_status);
            DO_Work(print_id.Trim());
        }

        private void DO_Work(string id)
        {
           
            DaoPopList list = new DaoPopList();
            DataTable work = new DataTable();
            if (id == string.Empty)
                work = list.Get_One_Work();
            else
                work = list.Get_One_Work(id);

            string print_id = string.Empty;
            string paper_id = string.Empty;
            string printer_id = string.Empty;
            string printer = string.Empty;

            if (work.Rows.Count == 1)
            {
                if (PrinterSettings.InstalledPrinters.Count == 0)
                {
                    MessageBox.Show("沒有安裝印表機，請聯絡資訊部(1999)，謝謝。", "錯誤",
                              MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    list.Update_ListStatus(print_id, 2);
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                    Environment.Exit(Environment.ExitCode);
                }

                PrintDocument printDoc = new PrintDocument();
                print_id = work.Rows[0]["ID"].ToString().Trim();
                paper_id = work.Rows[0]["PAPER_ID"].ToString().Trim();
                printer_id = work.Rows[0]["PRINTER"].ToString().Trim() ?? string.Empty;
                printer = (new DaoPopPrinter()).Get_Printer_Name(printer_id);

               
                if (printer == string.Empty)
                {
                    DaoPopArea daoArea = new DaoPopArea();
                    string area = work.Rows[0]["AREA"].ToString().Trim();
                    printer = daoArea.Get_Printer(area);
                }

                printDoc.PrinterSettings.PrinterName = printer;
                
                if (!printDoc.PrinterSettings.IsValid)
                {
                    string printerlike = string.Empty;
                    if (printer.LastIndexOf('_') != -1)
                    {
                        printerlike = printer.Substring(0, printer.LastIndexOf('_'));
                    }

                    // 如果設定的印表機沒有安裝，自動取得預設印表機名稱
                    for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
                    {
                        printer = PrinterSettings.InstalledPrinters[i];

                        if (printer.StartsWith(printerlike))
                        {                          
                            printDoc.PrinterSettings.PrinterName = printer;

                            break;
                        }
                    }
                }

                if (!printDoc.PrinterSettings.IsValid)
                {
                    for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
                    {
                        printer = PrinterSettings.InstalledPrinters[i];
                        printDoc.PrinterSettings.PrinterName = printer;

                        if (printDoc.PrinterSettings.IsDefaultPrinter)
                        {
                            break;
                        }
                    }

                }

                //MessageBox.Show(printer);

                Print_List(print_id, paper_id, printer);
            }

        }

        private void Print_List(string print_id, string paper_id, string printer)
        {
            DaoPopPaper paper = new DaoPopPaper(paper_id);

            string paper_kind = paper.Kind;


            if (paper_kind.ToUpper() == "EXCEL")
            {
                Print_With_Excel(print_id, paper_id, printer);
            }
            else
            {
                Print_With_POP(print_id, paper_id, printer);
            }            
        }

        private void Print_With_Excel(string batch_id, string paper_id, string printer)
        {
            ExcelLayout excel = new ExcelLayout();
            DaoPopList list = new DaoPopList();
            DaoPopDetail detail = new DaoPopDetail();

            if (PRINT_STATUS == "PRINT")
            {
                excel.Batch_Excel_Layout(batch_id, paper_id, printer, true);
                list.Update_ListMemo(batch_id, "Pages：" + Convert.ToString(detail.Get_Detail(batch_id).Rows.Count));
                list.Update_ListStatus(batch_id, 3);
            }
            else
            {
                excel.Batch_Excel_Layout(batch_id, paper_id, printer, false);
                list.Update_ListStatus(batch_id, 2);
            }
        }

        private void Print_With_POP(string print_id, string paper_id, string printer)
        {
            int page_id = 1;

            DaoPopList list = new DaoPopList();
            DaoPopDetail detail = new DaoPopDetail();
            DataTable dtDetail = detail.Get_Detail(print_id);

            if (dtDetail.Rows.Count == 0)
            {
                MessageBox.Show("沒有列印資料!");
                return;
            }

            list.Update_ListStatus(print_id, 1);

            DataColumn pageColumn = new DataColumn("PAGE_ID", typeof(Int32));
            pageColumn.DefaultValue = 0;
            dtDetail.Columns.Add(pageColumn);

            DaoPopPaper paper = new DaoPopPaper(paper_id);
            int paper_width = mmToInch(paper.Width);
            int paper_height = mmToInch(paper.Height);

            DaoPopFormat format = new DaoPopFormat();
            DataTable format_headers = format.Get_Format_All_Headers();
            DataTable format_details = format.Get_Format_All_Details();
            //DataTable dtFormat = null;

            int shiftX = 0;
            int shiftY = 0;
            int max_shittY = 0;
            int max_page = 0;

            ProgressBox proBox = new ProgressBox();
            proBox.TopMost = true;
            proBox.progress.Minimum = 0;
            proBox.progress.Maximum = dtDetail.Rows.Count;
            proBox.progress.Value = 0;
            proBox.Show();

            for (int i = 0; i < dtDetail.Rows.Count; i++)
            {
                string format_id = dtDetail.Rows[i]["FORMAT_ID"] == DBNull.Value ? string.Empty : dtDetail.Rows[i]["FORMAT_ID"].ToString();
                int format_width = mmToInch(Convert.ToSingle(Get_Filter_Format_Data(format_headers, format_id).Rows[0]["FORMAT_WIDTH"]));
                int format_height = mmToInch(Convert.ToSingle(Get_Filter_Format_Data(format_headers, format_id).Rows[0]["FORMAT_HEIGHT"]));

                string next_format_id = string.Empty;
                int next_format_width = 0;
                int next_format_height = 0;

                shiftX += format_width;
                if (max_shittY < shiftY + format_height) max_shittY = shiftY + format_height;

                if (i + 1 < dtDetail.Rows.Count)
                {
                    next_format_id = dtDetail.Rows[i + 1]["FORMAT_ID"] == null ? string.Empty : dtDetail.Rows[i + 1]["FORMAT_ID"].ToString();
                    next_format_width = mmToInch(Convert.ToSingle(Get_Filter_Format_Data(format_headers, next_format_id).Rows[0]["FORMAT_WIDTH"]));
                    next_format_height = mmToInch(Convert.ToSingle(Get_Filter_Format_Data(format_headers, next_format_id).Rows[0]["FORMAT_HEIGHT"]));

                    /***********************************************************
                     * 2019/06/01
                     * 解決HT POP列印A4時,1個2X2格式接著2個1X2格式，產生重疊的bug。
                     ***********************************************************/
                    if (shiftX + next_format_width > paper_width || shiftX >= paper_width)
                    {
                        shiftX = 0;
                        shiftY = max_shittY;
                    }
                }

                if (shiftY >= paper_height || shiftY + next_format_height > paper_height) //大於頁高，換頁
                {
                    dtDetail.Rows[i]["PAGE_ID"] = page_id++;
                    shiftX = 0;
                    shiftY = 0;
                    max_shittY = 0;
                    max_page = page_id;
                }
                else
                {
                    dtDetail.Rows[i]["PAGE_ID"] = page_id;
                }
                proBox.progress.Value = i;
            }

            proBox.Close();

            DaoPopLog log = new DaoPopLog();

            list.Update_ListMemo(print_id, "Pages：" + Convert.ToString(page_id));
            _log.Write(LogLevel.INFO, "STATUS：" + PRINT_STATUS + "\tID：" + print_id + "\tPage：" + page_id);

            if (PRINT_STATUS == "PREVIEW")
            {
                CoolPrintPreviewDialog ppd = new CoolPrintPreviewDialog(dtDetail, format_headers, format_details, paper_id, page_id, printer, PRINT_SOURCE);
                ppd.WindowState = FormWindowState.Maximized;
                //ppd.TopMost = true;
                list.Update_ListStatus(print_id, 2);
                ppd.ShowDialog();
                //Printed = ppd.Printed;
                if (ppd.Printed)
                {
                    log.Insert_Log(IP, VERSION, page_id);
                    list.Update_ListStatus(print_id, 3);
                }

            }
            else if (PRINT_STATUS == "PRINT")
            {
                for (int i = 1; i < page_id + 1; i++)
                {
                    DataTable dtPage = DataTableFilterSort(dtDetail, "PAGE_ID = " + i.ToString(), "PRINT_SEQ asc");
                    PageLayout pageLayout = new PageLayout(dtPage, format_headers, format_details, paper_id, printer);
                    PrintDocument pd = pageLayout.Get_Document();
                    pd.DocumentName = PRINT_SOURCE;
                    pd.Print();
                    pd.Dispose();
                    GC.Collect();
                }
                Printed = true;
                log.Insert_Log(IP, VERSION, page_id);
                list.Update_ListStatus(print_id, 3);
            }
        }

        private DataTable Get_Filter_Format_Data(DataTable oTable, string id)
        {
            return DataTableFilter(oTable, "FORMAT_ID = '" + id + "'");
        }

        private DataTable DataTableFilterSort(DataTable oTable, string filterExpression, string sortExpression)
        {
            DataTable nTable = oTable.Select(filterExpression, sortExpression).CopyToDataTable();
            return nTable;
        }

        private DataTable DataTableFilter(DataTable oTable, string filterExpression)
        {
            DataTable nTable = oTable.Select(filterExpression).CopyToDataTable();
            return nTable;
        }

        private int mmToInch(int mm)
        {
            return (int)(mm / INCH);
        }
        private int mmToInch(float mm)
        {
            return (int)(mm / INCH);
        }
    }
}
