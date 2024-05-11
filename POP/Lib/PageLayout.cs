using POP.Dao;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using Pxmart.Log;

namespace POP.Lib
{
    public class PageLayout
    {
        private MonitorLog _log = new MonitorLog();
        private string _paperId = string.Empty;
        private string _batchId = string.Empty;
        private string _message = string.Empty;
        private bool _drawRect = false;
        private string _formatId = string.Empty;
        private string _printer = string.Empty;
        private static readonly float INCH = 0.254f;
        private int DPI = 1200;
        //public enum PrintType { Text, Barcode, Image, QRCode }
        private int paper_width = 0;
        private int paper_height = 0;
        private PaperKind paperKind = PaperKind.B5;
        private DataTable _pageDetail = null;
        private DataTable _format_headers = null;
        private DataTable _format_details = null;
        private int start = 0;

        public PrintDocument Document { get; set; }

        public PageLayout()
        {
            
        }

        public PageLayout(DataTable pageDetial, DataTable format_headers, DataTable format_details, string paperId, string printer, bool drawRect = false)
        {
            _pageDetail = pageDetial;
            _format_headers = format_headers;
            _format_details = format_details;
            _paperId = paperId;
            _drawRect = drawRect;
            _printer = printer;
        }

        public void Message_Preview(string message, string format_id, string paper_id, string printer, bool drawRect = false)
        {
            _message = message;
            _formatId = format_id;
            _paperId = paper_id;
            _printer = printer;
            _drawRect = drawRect;

            try
            {
                DaoPopPaper paper = new DaoPopPaper(_paperId);

                paper_width = mmToInch(paper.Width);
                paper_height = mmToInch(paper.Height);

                paperKind = PaperKind.Custom;

                if (paper.Kind.ToUpper() == "B5")
                    paperKind = PaperKind.B5;

                if (paper.Kind.ToUpper() == "A4")
                    paperKind = PaperKind.A4;

                using (PrintDocument p = new PrintDocument())
                {
                    p.PrintPage += new PrintPageEventHandler(Message_PrintPage);
                    Design.CoolPrintPreviewDialog ppd = new Design.CoolPrintPreviewDialog();
                    ppd.WindowState = FormWindowState.Maximized;
                    PaperSize pageSize = null;

                    if (paper.Direction)
                        pageSize = new PaperSize("Default", paper_height, paper_width);
                    else
                        pageSize = new PaperSize("Default", paper_width, paper_height); //其中的数字为英寸

                    pageSize.RawKind = (int)paperKind;
                    p.DefaultPageSettings.PaperSize = pageSize;
                    p.PrinterSettings.PrinterName = _printer;
                    p.DefaultPageSettings.Landscape = paper.Direction;
                    ppd.Document = p;
                    ppd.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                _log.Write(LogLevel.ERROE, ex.Message);
                MessageBox.Show(ex.Message, "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void Message_PrintPage(object sender, PrintPageEventArgs e)
        {
            DaoPopFormat daoFormat = new DaoPopFormat();
            DataTable dtFormat = null;
            dtFormat = daoFormat.Get_Format_Detail(_formatId);
            int format_width = mmToInch(daoFormat.Get_Format_Width(_formatId));
            int format_height = mmToInch(daoFormat.Get_Format_Height(_formatId));
            string[] printList = _message.Split('^');

            if (_drawRect)
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, format_width, format_height);

            if (printList.Length != dtFormat.Rows.Count)
            {
                string msg = string.Format("資料字串個數不正確。\r\n字串： {0} 個，格式： {1} 個", printList.Length, dtFormat.Rows.Count);
                _log.Write(LogLevel.ERROE, msg);
                Font font = new Font("微軟正黑體", 12, FontStyle.Bold);
                e.Graphics.DrawString(msg, font, new SolidBrush(Color.Black), 5, 5);
                //MessageBox.Show(msg);
                return;
            }

            PrintWithFormat(e, printList, dtFormat, 0, 0);
            e.HasMorePages = false;
        }

        public void Batch_Preview(string batch_id, string paper_id, string printer, bool drawRect = false)
        {
            _batchId = batch_id;
            _paperId = paper_id;
            _printer = printer;
            _drawRect = drawRect;

            //int page = 0;
            start = 0;


            try
            {
                DaoPopPaper paper = new DaoPopPaper(_paperId);

                paper_width = mmToInch(paper.Width);
                paper_height = mmToInch(paper.Height);

                paperKind = PaperKind.Custom;

                if (paper.Kind.ToUpper() == "B5")
                    paperKind = PaperKind.B5;

                if (paper.Kind.ToUpper() == "A4")
                    paperKind = PaperKind.A4;

                using (PrintDocument p = new PrintDocument())
                {
                    p.PrintPage += new PrintPageEventHandler(Batch_PrintPage);
                    Design.CoolPrintPreviewDialog ppd = new Design.CoolPrintPreviewDialog();
                    ppd.WindowState = FormWindowState.Maximized;

                    p.DefaultPageSettings.Landscape = paper.Direction;
                    PaperSize pageSize = null;

                    if (paper.Direction)
                        pageSize = new PaperSize("Default", paper_height, paper_width);
                    else
                        pageSize = new PaperSize("Default", paper_width, paper_height);

                    pageSize.RawKind = (int)paperKind;
                    p.DefaultPageSettings.PaperSize = pageSize;
                    p.PrinterSettings.PrinterName = _printer;
                    ppd.Document = p;
                    ppd.ShowDialog();
                    //page = ppd._preview.PageCount;
                }

            }
            catch (Exception ex)
            {
                _log.Write(LogLevel.ERROE, ex.Message);
                MessageBox.Show(ex.Message, "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            //return page;
        }

        private void Batch_PrintPage(object sender, PrintPageEventArgs e)
        {
            DaoPopFormat daoFormat = new DaoPopFormat();
            DaoPopDetail daoDetail = new DaoPopDetail();

            DataTable detailTable = daoDetail.Get_Detail(_batchId);
            DataTable dtFormat = null;

            int shiftX = 0;
            int shiftY = 0;
            int max_shittY = 0;
            bool chPage = false;
            int i = 0;

            for (i = start; i < detailTable.Rows.Count; i++)
            {
                string[] printList = detailTable.Rows[i]["DATA"].ToString().Split('^');
                string fmtId = detailTable.Rows[i]["FORMAT_ID"] == DBNull.Value ? string.Empty : detailTable.Rows[i]["FORMAT_ID"].ToString();
                dtFormat = daoFormat.Get_Format_Detail(fmtId);
                int format_width = mmToInch(daoFormat.Get_Format_Width(fmtId));
                int format_height = mmToInch(daoFormat.Get_Format_Height(fmtId));

                if (_drawRect)
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 1), shiftX, shiftY, format_width, format_height);

                if (printList.Length != dtFormat.Rows.Count)
                {
                    string msg = string.Format("字串資料不正確，\r\n請洽詢資訊部，\r\n謝謝。\r\n字串： {0} 個，\r\n格式： {1} 個", printList.Length, dtFormat.Rows.Count);
                    _log.Write(LogLevel.ERROE, msg);
                    Font font = new Font("微軟正黑體", 12, FontStyle.Bold);
                    e.Graphics.DrawString(msg, font, new SolidBrush(Color.Black), shiftX + 5, shiftY + 5);
                }
                else
                {
                    PrintWithFormat(e, printList, dtFormat, shiftX, shiftY);
                }

                string next_format_id = string.Empty;
                int next_format_width = 0;
                int next_format_height = 0;

                shiftX += format_width;
                if (max_shittY < shiftY + format_height) max_shittY = shiftY + format_height;

                if (i + 1 < detailTable.Rows.Count)
                {
                    next_format_id = detailTable.Rows[i + 1]["FORMAT_ID"] == null ? string.Empty : detailTable.Rows[i + 1]["FORMAT_ID"].ToString();
                    next_format_width = mmToInch(daoFormat.Get_Format_Width(next_format_id));
                    next_format_height = mmToInch(daoFormat.Get_Format_Height(next_format_id));

                    if (shiftX + next_format_width > paper_width || shiftX >= paper_width)
                    {
                        shiftX = 0;
                        shiftY = max_shittY;
                    }
                }

                if (shiftY >= paper_height || shiftY + next_format_height > paper_height) //大於頁高，換頁
                {
                    chPage = true;
                    start = i + 1;
                    shiftX = 0;
                    shiftY = 0;
                    max_shittY = 0;
                    break;
                }
                else
                {
                    chPage = false;
                }
            }

            if (chPage)//設定換頁
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                start = 0;
            }
        }


        public PrintDocument Get_Document()
        {
            DaoPopPaper paper = new DaoPopPaper(_paperId);

            paper_width = mmToInch(paper.Width);
            paper_height = mmToInch(paper.Height);

            paperKind = PaperKind.Custom;

            if (paper.Kind.ToUpper() == "B5")
                paperKind = PaperKind.B5;

            if (paper.Kind.ToUpper() == "A4")
                paperKind = PaperKind.A4;

            using (PrintDocument p = new PrintDocument())
            { 
                p.PrintPage += new PrintPageEventHandler(Page_PrintPage);

                p.DefaultPageSettings.Landscape = paper.Direction;
                PaperSize pageSize = null;

                if (paper.Direction)
                    pageSize = new PaperSize("Default", paper_height, paper_width);
                else
                    pageSize = new PaperSize("Default", paper_width, paper_height);

                pageSize.RawKind = (int)paperKind;
                p.DefaultPageSettings.PaperSize = pageSize;
                p.PrinterSettings.PrinterName = _printer;
                Document = p;
            }
            GC.Collect();
            return Document;
        }

        private void Page_PrintPage(object sender, PrintPageEventArgs e)
        {
            //DaoPopFormat format = new DaoPopFormat();
            DataTable dtFormat = null;

            int shiftX = 0;
            int shiftY = 0;
            int max_shittY = 0;

            for (int i = 0; i < _pageDetail.Rows.Count; i++)
            {
                string[] printList = _pageDetail.Rows[i]["DATA"].ToString().Split('^');
                string format_id = _pageDetail.Rows[i]["FORMAT_ID"] == DBNull.Value ? string.Empty : _pageDetail.Rows[i]["FORMAT_ID"].ToString();
                string print_seq = _pageDetail.Rows[i]["PRINT_SEQ"] == DBNull.Value ? "---" : _pageDetail.Rows[i]["PRINT_SEQ"].ToString();
                dtFormat = Get_Filter_Format_Data(_format_details, format_id);
                int format_width = mmToInch(Convert.ToSingle(Get_Filter_Format_Data(_format_headers, format_id).Rows[0]["FORMAT_WIDTH"]));
                int format_height = mmToInch(Convert.ToSingle(Get_Filter_Format_Data(_format_headers, format_id).Rows[0]["FORMAT_HEIGHT"]));

                if (_drawRect)
                    e.Graphics.DrawRectangle(new Pen(Color.Black, 1), shiftX, shiftY, format_width, format_height);

                

                if (printList.Length != dtFormat.Rows.Count)
                {
                    string msg = string.Format("第{0}筆字串資料不正確，\r\n請洽詢資訊部，\r\n謝謝。\r\n字串： {1} 個，\r\n格式： {2} 個", print_seq, printList.Length, dtFormat.Rows.Count);
                    _log.Write(LogLevel.ERROE, msg);
                    Font font = new Font("微軟正黑體", 12, FontStyle.Bold);
                    e.Graphics.DrawString(msg, font, new SolidBrush(Color.Black), shiftX + 5, shiftY + 5);
                }
                else
                {
                    if (dtFormat.Rows.Count == 0)
                    {
                        string msg = string.Format("缺少 {0} 格式資料，\r\n請洽詢資訊部，\r\n謝謝。", format_id);
                        _log.Write(LogLevel.ERROE, msg);
                        Font font = new Font("微軟正黑體", 12, FontStyle.Bold);
                        e.Graphics.DrawString(msg, font, new SolidBrush(Color.Black), shiftX + 5, shiftY + 5);
                    }
                    else
                    {
                        PrintWithFormat(e, printList, dtFormat, shiftX, shiftY);
                    }
                }

                string next_format_id = string.Empty;
                int next_format_width = 0;
                int next_format_height = 0;


                shiftX += format_width;
                if (max_shittY < shiftY + format_height) max_shittY = shiftY + format_height;

                if (i + 1 < _pageDetail.Rows.Count)
                {
                    next_format_id = _pageDetail.Rows[i + 1]["FORMAT_ID"] == null ? string.Empty : _pageDetail.Rows[i + 1]["FORMAT_ID"].ToString();
                    next_format_width = mmToInch(Convert.ToSingle(Get_Filter_Format_Data(_format_headers, next_format_id).Rows[0]["FORMAT_WIDTH"]));
                    next_format_height = mmToInch(Convert.ToSingle(Get_Filter_Format_Data(_format_headers, next_format_id).Rows[0]["FORMAT_HEIGHT"]));

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
            }

        }

        private void PrintWithFormat(PrintPageEventArgs e, string[] list, DataTable format, int shiftX, int shiftY)
        {
            string fontFamily = string.Empty;
            float fontSize = 0f;
            string fontStyle = string.Empty;
            float textWidth = 0f;
            float textHeight = 0f;
            string fontColor = string.Empty;
            StringAlignment vAlign = StringAlignment.Near;
            StringAlignment hAlign = StringAlignment.Near;
            PrintType printType = PrintType.Text;
            bool isMatrix = false;
            bool dynamicMatrix = false;
            float zoomX = 1f;
            float zoomY = 1f;
            bool isDirectionVertical = false;
            bool isBox = false;
            StringFormat drawFormat = new StringFormat();
            int boxline = 2;

            int origX = 0;
            int origY = 0;

            for (int i = 0; i < format.Rows.Count; i++)
            {
                try
                {
                    /* 設定文字格式 */
                    fontFamily = format.Rows[i]["FONT_NAME"] == DBNull.Value ? "微軟正黑體" : format.Rows[i]["FONT_NAME"].ToString();            //文字字型
                    fontSize = format.Rows[i]["FONT_SIZE"] == DBNull.Value ? 1 : Convert.ToInt32(format.Rows[i]["FONT_SIZE"]);         //文字大小
                    fontStyle = format.Rows[i]["FONT_STYLE"] == DBNull.Value ? "REGULAR" : format.Rows[i]["FONT_STYLE"].ToString().ToUpper(); //文字Style 
                    textWidth = format.Rows[i]["WIDTH"] == DBNull.Value ? 0 : Convert.ToInt32(format.Rows[i]["WIDTH"]);                //文字最大寬度
                    textHeight = format.Rows[i]["HEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(format.Rows[i]["HEIGHT"]);             //文字最大高度
                    vAlign = (StringAlignment)(format.Rows[i]["VERTICAL_ALIGN"] == DBNull.Value ? 0 : Convert.ToInt32(format.Rows[i]["VERTICAL_ALIGN"])); //文字垂直對齊
                    hAlign = (StringAlignment)(format.Rows[i]["HORIZONTAL_ALIGN"] == DBNull.Value ? 0 : Convert.ToInt32(format.Rows[i]["HORIZONTAL_ALIGN"])); //文字水平對齊
                    FontStyle eFontStyle = GetFontStyle(fontStyle);

                    /* 設定列印起始位址 */
                    origX = format.Rows[i]["X_SITE"] == DBNull.Value ? 0 : Convert.ToInt32(format.Rows[i]["X_SITE"]); //X軸位置                
                    origY = format.Rows[i]["Y_SITE"] == DBNull.Value ? 0 : Convert.ToInt32(format.Rows[i]["Y_SITE"]); //Y軸位置
                    origX += shiftX; //計算X位移
                    origY += shiftY; //計算Y位移
                    Point PSite = new Point(origX, origY);

                    isMatrix = false;
                    isBox = false;
                    dynamicMatrix = false;
                    zoomX = 1.0f;
                    zoomY = 1.0f;
                    //*****  復原向量比例  *****//
                    Matrix oriMatrix = new Matrix();
                    oriMatrix.Scale(zoomX, zoomY);
                    e.Graphics.Transform = oriMatrix;

                    /* //////////對齊測試框線/////////////*/
                    //if (vAlign != StringAlignment.Near && hAlign != StringAlignment.Near)
                    if (_drawRect)
                        e.Graphics.DrawRectangle(new Pen(Color.Red, 1), origX, origY, textWidth, textHeight);

                    /* 設定文字顏色 */
                    fontColor = format.Rows[i]["FONT_COLOR"] == DBNull.Value ? "Black" : format.Rows[i]["FONT_COLOR"].ToString(); //文字顏色 
                    Color color = new Color();
                    color = Color.FromName(fontColor);

                    /* 文字特殊設定：文字大小、文字Style、文字顏色 */

                    string[] para = list[i].Split(new string[] { "@@" }, StringSplitOptions.RemoveEmptyEntries);

                    //取得列印資料
                    string printData = string.Empty;
                    if (i < list.Length && list[i] != string.Empty)
                    {
                        printData = para[0] == null ? "" : para[0].ToString();
                    }

                    printType = (PrintType)(format.Rows[i]["PRINT_TYPE"] == DBNull.Value ? 0 : Convert.ToInt32(format.Rows[i]["PRINT_TYPE"]));
                    isMatrix = format.Rows[i]["MATRIX"] == DBNull.Value ? false : Convert.ToBoolean(format.Rows[i]["MATRIX"]);
                    isDirectionVertical = format.Rows[i]["DIRECTION_VERTICAL"] == DBNull.Value ? false : Convert.ToBoolean(format.Rows[i]["DIRECTION_VERTICAL"]);

                    if (para.Length > 1)
                    {
                        para[1] = para[1].ToUpper();
                        string[] attribute = para[1].Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string str in attribute)
                        {
                            string[] value = str.Split(':');
                            switch (value[0])
                            {
                                case "SIZE":
                                    fontSize = Convert.ToInt32(value[1]);
                                    break;
                                case "STYLE":
                                    eFontStyle = GetFontStyle(value[1]);
                                    break;
                                case "COLOR":
                                    color = Color.FromName(value[1]);
                                    break;
                                case "ZOOMW":
                                    isMatrix = true;
                                    dynamicMatrix = true;
                                    zoomX = Convert.ToSingle(value[1]);
                                    break;
                                case "ZOOMH":
                                    isMatrix = true;
                                    dynamicMatrix = true;
                                    zoomY = Convert.ToSingle(value[1]);
                                    break;
                                case "BOX":
                                    isBox = true;
                                    if (value.Length == 2)
                                        boxline = int.Parse(value[1]);
                                    else
                                        boxline = 2;
                                    break;
                                case "BCODE":
                                    printType = PrintType.Barcode;
                                    fontFamily = value[1];
                                    break;
                                case "HEIGHT":
                                    textHeight = Convert.ToInt32(value[1]);
                                    break;
                            }
                        }
                    }

                    Font PrintFont = new Font(fontFamily, fontSize, eFontStyle, System.Drawing.GraphicsUnit.Point);

                    /* 垂直對齊、水平對齊 */
                    if (isDirectionVertical == true)
                        drawFormat = new StringFormat(StringFormatFlags.DirectionVertical);
                    else
                        drawFormat = new StringFormat();
                    drawFormat.LineAlignment = vAlign;
                    drawFormat.Alignment = hAlign;

                    #region 列印文字 
                    if (printType == PrintType.Text)
                    {
                        if (isBox == true && textWidth != 0 && textHeight != 0)
                        {
                            e.Graphics.DrawRectangle(new Pen(color, boxline), origX, origY, textWidth, textHeight);
                        }

                        Matrix matrix = new Matrix();
                        if (isMatrix == true) /* !!!!!有轉折才縮放，要再確定需求!!!!!!! */
                        {
                            if (dynamicMatrix == false)
                            {
                                zoomX = format.Rows[i]["X_ZOOM"] == DBNull.Value ? 1f : Convert.ToSingle(format.Rows[i]["X_ZOOM"]);
                                zoomY = format.Rows[i]["Y_ZOOM"] == DBNull.Value ? 1f : Convert.ToSingle(format.Rows[i]["Y_ZOOM"]);
                            }
                            matrix.Scale(zoomX, zoomY);
                            e.Graphics.Transform = matrix;
                            if (textWidth != 0 && textHeight != 0)
                                e.Graphics.DrawString(printData, PrintFont, new SolidBrush(color),
                                    new RectangleF((int)(origX / zoomX), (int)(origY / zoomY), (int)(textWidth / zoomX), (int)(textHeight / zoomY)), drawFormat);
                            else
                                e.Graphics.DrawString(printData, PrintFont, new SolidBrush(color),
                                    new Point((int)(origX / zoomX), (int)(origY / zoomY)), drawFormat);
                        }
                        else
                        {
                            matrix.Scale(1, 1);
                            e.Graphics.Transform = matrix;
                            if (textWidth != 0 && textHeight != 0)
                                e.Graphics.DrawString(printData, PrintFont, new SolidBrush(color), new RectangleF(origX, origY, textWidth, textHeight), drawFormat);
                            else
                                e.Graphics.DrawString(printData, PrintFont, new SolidBrush(color), PSite, drawFormat);
                        }
                    }
                    #endregion

                    #region 列印Barcode
                    if (printType == PrintType.Barcode)
                    {
                        if (printData == string.Empty || printData.Length < 3)
                        {
                            continue;
                        }

                        BindBarCode BarCode = new BindBarCode();
                        BindBarCode.Encode encode = GetBarcodeEncode(fontFamily);

                        BarCode.Height = (uint)fontSize;
                        Image img = null;

                        if (encode == BindBarCode.Encode.EAN13)
                        {
                            Ean13 ean13 = new Ean13(printData);
                            ean13.DrawEan13Barcode(e.Graphics, new System.Drawing.Point(origX + 1, origY), textHeight); // +1：讓EAN-13顯示數字位置正確。
                        }
                        else
                        {
                            if (encode == BindBarCode.Encode.Code39)
                            {
                                img = BarCode.GetCode39(printData);
                            }
                            else if (encode == BindBarCode.Encode.Codabar)
                            {
                                BarcodeWriter bw = new BarcodeWriter();
                                bw.Format = BarcodeFormat.CODABAR;
                                //bw.Options.Width = Convert.ToInt32(textWidth);
                                //bw.Options.Height = Convert.ToInt32(textHeight);
                                bw.Options.PureBarcode = true;
                                img = bw.Write(printData);                            
                            }
                            else
                            {
                                img = BarCode.GetCodeImage(printData, encode);
                            }

                            if (textWidth != 0 && textHeight != 0)
                                e.Graphics.DrawImage(img, origX, origY, textWidth, textHeight);
                            else
                                e.Graphics.DrawImage(img, origX, origY);
                        }
                        img.Dispose();
                    }
                    #endregion

                    #region 列印圖片
                    if (printType == PrintType.Image)
                    {
                        if (printData == string.Empty)
                        {
                            continue;
                        }

                        Image img = null;
                        if (printData.ToUpper().IndexOf("HTTP") == -1)
                        {
                            DaoPopImage daoImage = new DaoPopImage();
                            if (daoImage.Exist_Image(printData))
                            {
                                MemoryStream ms = new MemoryStream(daoImage.Get_Image(printData));
                                img = Image.FromStream(ms);
                            }
                            else
                            {
                                using (FileStream fs = new FileStream(printData, FileMode.Open))
                                {
                                    BinaryReader br = new BinaryReader(fs);
                                    img = Image.FromStream(br.BaseStream);
                                }
                            }
                        }
                        else
                        {
                            System.Net.WebClient WC = new System.Net.WebClient();
                            MemoryStream Ms = new MemoryStream(WC.DownloadData(printData));
                            img = Image.FromStream(Ms);
                        }

                        e.Graphics.DrawImage(img, origX, origY, textWidth, textHeight);
                        img.Dispose();
                    }

                    #endregion

                    #region 列印QRCODE
                    if (printType == PrintType.QRCode)
                    {
                        Image img = null;
                        IBarcodeWriter writer = new BarcodeWriter()
                        {
                            Format = BarcodeFormat.QR_CODE,
                            Options = new QrCodeEncodingOptions()
                            {
                                ErrorCorrection = ErrorCorrectionLevel.M,
                                Margin = 0,
                                Width = Convert.ToInt32(textWidth),
                                Height = Convert.ToInt32(textHeight),
                                CharacterSet = "UTF-8"   // 少了這一行中文就亂碼了
                            }
                        };

                        DaoPopQRCode daoQrCode = new DaoPopQRCode();
                        DataTable dt = daoQrCode.Get_QRData(printData);
                        string printStr = string.Empty;

                        foreach (DataRow dr in dt.Rows)
                        {
                            printStr += dr["QR_DATA"].ToString() + Environment.NewLine;
                        }

                        img = writer.Write(printStr);
                        e.Graphics.DrawImage(img, PSite);
                        img.Dispose();
                    }
                    #endregion
                }
                catch 
                {
                    //_log.Write(LogLevel.ERROE, "第" + i + "筆資料，"+ ex.Message);
                }               
            }
        }

        private FontStyle GetFontStyle(string fontStyle)
        {
            switch (fontStyle)
            {
                case "BOLD": //粗體字
                case "B":
                    return FontStyle.Bold;
                case "ITALIC"://斜體字
                case "I":
                    return FontStyle.Italic;
                case "REGULAR"://一般文字
                case "R":
                    return FontStyle.Regular;
                case "STRIKEOUT"://刪除線
                case "S":
                    return FontStyle.Strikeout;
                case "UNDERLINE"://加底線
                case "U":
                    return FontStyle.Underline;
                default:
                    return FontStyle.Regular;
            }
        }
        private BindBarCode.Encode GetBarcodeEncode(string barcode)
        {
            switch (barcode.ToUpper())
            {
                case "BARCODE128A":
                case "CODE128A":
                    return BindBarCode.Encode.Code128A;
                case "BARCODE128B":
                case "CODE128B":
                    return BindBarCode.Encode.Code128B;
                case "BARCODE128C":
                case "CODE128C":
                    return BindBarCode.Encode.Code128C;
                case "BARCODE39":
                case "CODE39":
                    return BindBarCode.Encode.Code39;
                case "EAN128":
                    return BindBarCode.Encode.EAN128;
                case "EAN13":
                    return BindBarCode.Encode.EAN13;
                case "EAN8":
                    return BindBarCode.Encode.EAN8;
                case "CODABAR":
                    return BindBarCode.Encode.Codabar;
                default:
                    return BindBarCode.Encode.Code128A;
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

        #region 單位轉換
        private int mmToInch(int mm)
        {
            return (int)(mm / INCH);
        }
        private int mmToInch(float mm)
        {
            return (int)(mm / INCH);
        }
        private int mmToPixel(int mm)
        {
            return Convert.ToInt32((mm - 4) * DPI / 254);
        }
        private int mmToPixel(float mm)
        {
            return Convert.ToInt32((mm - 4.0) * DPI / 254);
        }
        #endregion
    }
}
