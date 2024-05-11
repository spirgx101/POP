using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using POP.Dao;
using Spire.Xls;
using ZXing;
using POP.Lib;
using System.Text.RegularExpressions;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace POP.Lib
{
    public class ExcelLayout
    {
        private string PAPER_ID = string.Empty;
        private string FORMAT_ID = string.Empty;
        private string PRINT_ID = string.Empty;
        private string PRINTER = string.Empty;
        private static readonly float INCH = 0.254f;
        private int DPI = 1200;

        public ExcelLayout() 
        { 
        
        }

        public void Preview_Excel_Layout(string excel_data, string format_id, string paper_id, string printer, bool print)
        {

            DaoPopPaper paper = new DaoPopPaper(paper_id);
            string file_name = paper.Memo;

            Workbook book = new Workbook();

            book.LoadFromFile(file_name);

            Worksheet sheet = book.Worksheets[0];
            sheet.Range.Style.Locked = true;
            sheet.Protect("", SheetProtectionType.All);

            Print_With_Format(sheet, excel_data, format_id, file_name, printer, print);



            #region excel print side

            if (print == true)
            {
                sheet.PageSetup.FitToPagesWide = 1;
                sheet.PageSetup.FitToPagesTall = 1;
                sheet.PageSetup.TopMargin = 0;
                sheet.PageSetup.LeftMargin = 0;
                sheet.PageSetup.RightMargin = 0.4;
                sheet.PageSetup.BottomMargin = 0.4;

                using (PrintDocument print_doc = book.PrintDocument)
                {
                    print_doc.DocumentName = "POP_EXCEL";
                    print_doc.PrinterSettings.PrinterName = printer;
                    print_doc.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A4Rotated;
                    print_doc.DefaultPageSettings.Landscape = true;

                    print_doc.Print();
                }
            }
            else
            {
                try
                {
                    string output_file = @"C:\temp\test_" + DateTime.Now.ToString("yyyyMMddHHmmss") + @".xlsx";
                    book.SaveToFile(output_file, ExcelVersion.Version2010);
                    System.Diagnostics.Process.Start(output_file);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            #endregion


        }


        public void Batch_Excel_Layout(string batch_id, string paper_id, string printer, bool print)
        {
            DaoPopPaper paper = new DaoPopPaper(paper_id);
            string file_name = paper.Memo;

            DaoPopDetail print_detail = new DaoPopDetail();
            DataTable print_table = print_detail.Get_Detail(batch_id);
            string format_id = string.Empty;
            string excel_data = string.Empty;

            Workbook source = new Workbook();
            Workbook target = new Workbook();
            target.Worksheets.Clear();
            
            source.LoadFromFile(file_name);
            Worksheet source_sheet = source.Worksheets[0];

            for(int i = 0; i < print_table.Rows.Count; i++)
            {

                if (i > 4 && print == false) //免費版最多5頁
                {
                    MessageBox.Show("只提供5頁預覽");
                    //break;
                }
                excel_data = print_table.Rows[i]["DATA"].ToString();
                format_id = print_table.Rows[i]["FORMAT_ID"].ToString();

                target.Worksheets.Add("new-" + (i+1).ToString());
                target.Worksheets[i].CopyFrom(source_sheet);
                target.Worksheets[i].Name = "Page-" + (i + 1).ToString();
                target.Worksheets[i].Range.Style.Locked = true;
                target.Worksheets[i].Protect("", SheetProtectionType.All);

                Print_With_Format(target.Worksheets[i], excel_data, format_id, file_name, printer, print);

            }


            if (print == false)
            {
                string output_file = @"C:\temp\test.xlsx";
                target.SaveToFile(output_file, ExcelVersion.Version2010);
                System.Diagnostics.Process.Start(output_file);
            }
            else
            {
                for(int i = 0; i < print_table.Rows.Count; i ++)
                {
                    Worksheet desiredSheet = target.Worksheets[i];

                    Workbook newBook = new Workbook();
                    newBook.Version = ExcelVersion.Version2010;
                    newBook.Worksheets.Clear();
                    newBook.Worksheets.AddCopy(desiredSheet);

                    newBook.Worksheets[0].PageSetup.FitToPagesWide = 1;
                    newBook.Worksheets[0].PageSetup.FitToPagesTall = 1;
                    newBook.Worksheets[0].PageSetup.TopMargin = 0;
                    newBook.Worksheets[0].PageSetup.LeftMargin = 0;
                    newBook.Worksheets[0].PageSetup.RightMargin = 0.4;
                    newBook.Worksheets[0].PageSetup.BottomMargin = 0.4;

                    using (PrintDocument print_doc = newBook.PrintDocument)
                    {
                        print_doc.DocumentName = "POP_EXCEL";
                        print_doc.PrinterSettings.PrinterName = printer;
                        print_doc.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A4Rotated;
                        print_doc.DefaultPageSettings.Landscape = true;

                        print_doc.Print();
                    }
                }
            }


        }


        private void Print_With_Format(Worksheet sheet, string excel_data, string format_id, string file_name, string printer, bool print = false)
        {

            DaoPopFormat format = new DaoPopFormat();
            DataTable format_header = format.Get_Format_Header(format_id);
            DataTable format_detail = format.Get_Format_Detail(format_id);

            DataTable cell_format = DataTableFilterSort(format_detail, "PRINT_TYPE >= 100 AND PRINT_TYPE <= 199", "FORMAT_SEQ");
            DataTable row_format = DataTableFilterSort(format_detail, "PRINT_TYPE >= 200 AND PRINT_TYPE <= 299", "FORMAT_SEQ");

            string[] message = excel_data.Split('^');
            List<string> cell_message = new List<string>();
            List<string> row_message = new List<string>();

            string cell_name = string.Empty;
            string row_name = string.Empty;
            string font_family = string.Empty;
            float font_size = 0f;
            string font_style = string.Empty;
            string font_color = string.Empty;
            PrintType print_type = PrintType.Text;
            int vertical_align = 0;
            int horizontal_align = 0;
            bool isDirectionVertical = false;
            int data_offset_row = 0;
            int data_offset_column = 0;
            int data_width = 0;
            int data_height = 0;

            

            foreach (string msg in message)
            {
                if (msg.StartsWith("[["))
                    row_message.Add(msg);
                else
                    cell_message.Add(msg);
            }

            try
            {
                #region cell message layout side
                for (int i = 0; i < cell_format.Rows.Count; i++)
                {
                    cell_name = cell_format.Rows[i]["MEMO"].ToString();
                    print_type = (PrintType)(cell_format.Rows[i]["PRINT_TYPE"] == DBNull.Value ? 0 : Convert.ToInt32(cell_format.Rows[i]["PRINT_TYPE"]));
                    font_family = cell_format.Rows[i]["FONT_NAME"] == DBNull.Value ? "微軟正黑體" : cell_format.Rows[i]["FONT_NAME"].ToString();          //文字字型
                    font_size = cell_format.Rows[i]["FONT_SIZE"] == DBNull.Value ? 1 : Convert.ToInt32(cell_format.Rows[i]["FONT_SIZE"]);                //文字大小
                    font_style = cell_format.Rows[i]["FONT_STYLE"] == DBNull.Value ? "" : cell_format.Rows[i]["FONT_STYLE"].ToString().ToUpper();        //文字Style 
                    font_color = cell_format.Rows[i]["FONT_COLOR"] == DBNull.Value ? "Black" : cell_format.Rows[i]["FONT_COLOR"].ToString();             //文字顏色 
                    data_width = cell_format.Rows[i]["WIDTH"] == DBNull.Value ? 0 : Convert.ToInt32(cell_format.Rows[i]["WIDTH"]);                       //文字最大寬度
                    data_height = cell_format.Rows[i]["HEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(cell_format.Rows[i]["HEIGHT"]);                    //文字最大高度
                    data_offset_column = cell_format.Rows[i]["X_SITE"] == DBNull.Value ? 0 : Convert.ToInt32(cell_format.Rows[i]["X_SITE"]);             //offset column位置                
                    data_offset_row = cell_format.Rows[i]["Y_SITE"] == DBNull.Value ? 0 : Convert.ToInt32(cell_format.Rows[i]["Y_SITE"]);                //offset row位置

                    vertical_align = cell_format.Rows[i]["VERTICAL_ALIGN"] == DBNull.Value ? 1 : Convert.ToInt32(cell_format.Rows[i]["VERTICAL_ALIGN"]); //文字垂直對齊
                    horizontal_align = cell_format.Rows[i]["HORIZONTAL_ALIGN"] == DBNull.Value ? 1 : Convert.ToInt32(cell_format.Rows[i]["HORIZONTAL_ALIGN"]); //文字水平對齊
                    isDirectionVertical = cell_format.Rows[i]["DIRECTION_VERTICAL"] == DBNull.Value ? false : Convert.ToBoolean(cell_format.Rows[i]["DIRECTION_VERTICAL"]);
                    string print_data = cell_message[i];


                    #region cell列印文字
                    if (print_type == PrintType.Cell_Of_Text)
                    {
                        sheet.Range[cell_name].Text = print_data;
                        sheet.Range[cell_name].Style.Font.Color = Color.FromName(font_color);
                        sheet.Range[cell_name].Style.Font.Size = font_size;
                        sheet.Range[cell_name].Style.Font.IsBold = Convert.ToBoolean(font_style.IndexOf("B") >= 0);
                        sheet.Range[cell_name].Style.Font.IsItalic = Convert.ToBoolean(font_style.IndexOf("I") >= 0);
                        sheet.Range[cell_name].Style.Font.IsStrikethrough = Convert.ToBoolean(font_style.IndexOf("S") >= 0);
                        if (Convert.ToBoolean(font_style.IndexOf("U") >= 0))
                        {
                            sheet.Range[cell_name].Style.Font.Underline = FontUnderlineType.Single;
                        }


                        switch (vertical_align)
                        {
                            case 0:
                                sheet.Range[cell_name].Style.VerticalAlignment = VerticalAlignType.Top;
                                break;
                            case 1:
                                sheet.Range[cell_name].Style.VerticalAlignment = VerticalAlignType.Center;
                                break;
                            case 2:
                                sheet.Range[cell_name].Style.VerticalAlignment = VerticalAlignType.Bottom;
                                break;
                            default:
                                sheet.Range[cell_name].Style.VerticalAlignment = VerticalAlignType.Center;
                                break;
                        }

                        switch (horizontal_align)
                        {
                            case 0:
                                sheet.Range[cell_name].Style.HorizontalAlignment = HorizontalAlignType.Left;
                                break;
                            case 1:
                                sheet.Range[cell_name].Style.HorizontalAlignment = HorizontalAlignType.Center;
                                break;
                            case 2:
                                sheet.Range[cell_name].Style.HorizontalAlignment = HorizontalAlignType.Right;
                                break;
                            default:
                                sheet.Range[cell_name].Style.HorizontalAlignment = HorizontalAlignType.Center;
                                break;

                        }

                        if (isDirectionVertical == true)
                        {
                            sheet.Range[cell_name].Style.Rotation = 90;
                        }

                    }
                    #endregion

                    #region cell列印Barcode
                    if (print_type == PrintType.Cell_Of_Barcode)
                    {
                        if (print_data == string.Empty || print_data.Length < 3)
                        {
                            continue;
                        }

                        BindBarCode BarCode = new BindBarCode();
                        BindBarCode.Encode encode = GetBarcodeEncode(font_family);
                        Image img = null;

                        if (encode == BindBarCode.Encode.Code128A || encode == BindBarCode.Encode.Code128B ||
                            encode == BindBarCode.Encode.Code128C || encode == BindBarCode.Encode.EAN128)
                        {
                            img = BarCode.GetCodeImage(print_data, encode);
                        }
                        else
                        {
                            BarcodeWriter bw = new BarcodeWriter();
                            switch (encode)
                            {
                                case BindBarCode.Encode.EAN13:
                                    bw.Format = BarcodeFormat.EAN_13;
                                    break;
                                case BindBarCode.Encode.EAN8:
                                    bw.Format = BarcodeFormat.EAN_8;
                                    break;
                                case BindBarCode.Encode.Code39:
                                    bw.Format = BarcodeFormat.CODE_39;
                                    break;
                                case BindBarCode.Encode.Codabar:
                                    bw.Format = BarcodeFormat.CODABAR;
                                    break;

                            }
                            bw.Options.PureBarcode = true;
                            img = bw.Write(print_data);
                        }

                        int[] range = Get_Image_Layout_Range(cell_name);
                        //ExcelPicture picture = sheet.Pictures.Add(range[0], range[1], range[2], range[3], img, ImageFormatType.Original);
                        ExcelPicture picture = sheet.Pictures.Add(range[0], range[1], img, ImageFormatType.Original);


                        picture.Width = data_width;
                        picture.Height = data_height;
                        //picture.ResizeBehave = ResizeBehaveType.FreeFloating;

                        picture.TopRowOffset = data_offset_row;
                        picture.LeftColumnOffset = data_offset_column;

                        //picture.RightColumnOffset = 50;
                        //picture.BottomRowOffset = 50;
                    }
                    #endregion

                    #region cell列印圖片
                    if (print_type == PrintType.Cell_Of_Image)
                    {
                        if (print_data == string.Empty || (!File.Exists(print_data)))
                        {
                            continue;
                        }

                        Image img = null;
                        if (print_data.ToUpper().IndexOf("HTTP") == -1)
                        {
                            DaoPopImage daoImage = new DaoPopImage();
                            if (daoImage.Exist_Image(print_data))
                            {
                                MemoryStream ms = new MemoryStream(daoImage.Get_Image(print_data));
                                img = Image.FromStream(ms);
                            }
                            else
                            {
                                using (FileStream fs = new FileStream(print_data, FileMode.Open))
                                {
                                    BinaryReader br = new BinaryReader(fs);
                                    img = Image.FromStream(br.BaseStream);
                                }
                            }
                        }
                        else
                        {
                            System.Net.WebClient WC = new System.Net.WebClient();
                            MemoryStream Ms = new MemoryStream(WC.DownloadData(print_data));
                            img = Image.FromStream(Ms);
                        }
                        int[] range = Get_Image_Layout_Range(cell_name);

                        ExcelPicture picture = sheet.Pictures.Add(range[0], range[1], img, ImageFormatType.Original);

                        picture.Width = data_width;
                        picture.Height = data_height;

                        picture.TopRowOffset = data_offset_row;
                        picture.LeftColumnOffset = data_offset_column;

                        img.Dispose();

                    }
                    #endregion

                    #region cell列印QRCode
                    if (print_type == PrintType.Cell_Of_QRCode)
                    {

                        Image img = null;

                        if (data_width > data_height)
                            data_width = data_height;
                        else
                            data_height = data_width;

                        IBarcodeWriter writer = new BarcodeWriter()
                        {
                            Format = BarcodeFormat.QR_CODE,
                            Options = new QrCodeEncodingOptions()
                            {
                                ErrorCorrection = ErrorCorrectionLevel.M,
                                Margin = 0,
                                Width = Convert.ToInt32(data_width),
                                Height = Convert.ToInt32(data_height),
                                CharacterSet = "UTF-8"   // 少了這一行中文就亂碼了
                            }
                        };

                        img = writer.Write(print_data);

                        int[] range = Get_Image_Layout_Range(cell_name);

                        ExcelPicture picture = sheet.Pictures.Add(range[0], range[1], img, ImageFormatType.Original);

                        picture.TopRowOffset = data_offset_row;
                        picture.LeftColumnOffset = data_offset_column;

                        img.Dispose();
                    }
                    #endregion

                    #region cell列印公式
                    if (print_type == PrintType.Cell_Of_Formula)
                    {
                        sheet.Range[cell_name].Formula = print_data;

                        sheet.Range[cell_name].Style.Font.Color = Color.FromName(font_color);
                        sheet.Range[cell_name].Style.Font.Size = font_size;
                        sheet.Range[cell_name].Style.Font.IsBold = Convert.ToBoolean(font_style.IndexOf("B") >= 0);
                        sheet.Range[cell_name].Style.Font.IsItalic = Convert.ToBoolean(font_style.IndexOf("I") >= 0);
                        sheet.Range[cell_name].Style.Font.IsStrikethrough = Convert.ToBoolean(font_style.IndexOf("S") >= 0);
                        if (Convert.ToBoolean(font_style.IndexOf("U") >= 0))
                        {
                            sheet.Range[cell_name].Style.Font.Underline = FontUnderlineType.Single;
                        }
                        //Console.WriteLine( Convert.ToBoolean(font_style.IndexOf("B")).ToString() );


                        switch (vertical_align)
                        {
                            case 0:
                                sheet.Range[cell_name].Style.VerticalAlignment = VerticalAlignType.Top;
                                break;
                            case 1:
                                sheet.Range[cell_name].Style.VerticalAlignment = VerticalAlignType.Center;
                                break;
                            case 2:
                                sheet.Range[cell_name].Style.VerticalAlignment = VerticalAlignType.Bottom;
                                break;
                            default:
                                sheet.Range[cell_name].Style.VerticalAlignment = VerticalAlignType.Center;
                                break;
                        }

                        switch (horizontal_align)
                        {
                            case 0:
                                sheet.Range[cell_name].Style.HorizontalAlignment = HorizontalAlignType.Left;
                                break;
                            case 1:
                                sheet.Range[cell_name].Style.HorizontalAlignment = HorizontalAlignType.Center;
                                break;
                            case 2:
                                sheet.Range[cell_name].Style.HorizontalAlignment = HorizontalAlignType.Right;
                                break;
                            default:
                                sheet.Range[cell_name].Style.HorizontalAlignment = HorizontalAlignType.Center;
                                break;

                        }

                        if (isDirectionVertical == true)
                        {
                            sheet.Range[cell_name].Style.Rotation = 90;
                        }
                    }
                    #endregion

                }
                #endregion



                #region row message layout side
                List<List<string>> cell_table = new List<List<string>>();

                for (int i = 0; i < row_format.Rows.Count; i++)
                {
                    string row_rang = row_format.Rows[i]["MEMO"].ToString();
                    string[] range = Get_Row_Name_Split(row_rang);
                    List<string> cell_list = new List<string>();

                    for (int j = int.Parse(range[1]); j <= int.Parse(range[3]); j++)
                    {
                        cell_list.Add(range[0] + j.ToString());
                    }

                    cell_table.Add(cell_list);
                }



                for (int i = 0; i < row_message.Count; i++)
                {
                    string[] row_print_list = row_message[i].Split(new string[] { @"$$" }, StringSplitOptions.None);

                    for (int j = 0; j < cell_table.Count; j++)
                    {
                        string print_data = row_print_list[j].Replace(@"[[", "").Replace(@"]]", "");
                        cell_name = cell_table[j][i];
                        print_type = (PrintType)(row_format.Rows[j]["PRINT_TYPE"] == DBNull.Value ? 0 : Convert.ToInt32(row_format.Rows[j]["PRINT_TYPE"]));
                        font_family = row_format.Rows[j]["FONT_NAME"] == DBNull.Value ? "微軟正黑體" : row_format.Rows[j]["FONT_NAME"].ToString();          //文字字型
                        font_size = row_format.Rows[j]["FONT_SIZE"] == DBNull.Value ? 1 : Convert.ToInt32(row_format.Rows[j]["FONT_SIZE"]);                //文字大小
                        font_style = row_format.Rows[j]["FONT_STYLE"] == DBNull.Value ? "" : row_format.Rows[j]["FONT_STYLE"].ToString().ToUpper();        //文字Style 
                        font_color = row_format.Rows[j]["FONT_COLOR"] == DBNull.Value ? "Black" : row_format.Rows[j]["FONT_COLOR"].ToString();             //文字顏色 

                        data_width = row_format.Rows[j]["WIDTH"] == DBNull.Value ? 0 : Convert.ToInt32(row_format.Rows[j]["WIDTH"]);                       //文字最大寬度
                        data_height = row_format.Rows[j]["HEIGHT"] == DBNull.Value ? 0 : Convert.ToInt32(row_format.Rows[j]["HEIGHT"]);                    //文字最大高度
                        data_offset_column = row_format.Rows[j]["X_SITE"] == DBNull.Value ? 0 : Convert.ToInt32(row_format.Rows[j]["X_SITE"]);             //offset column位置                
                        data_offset_row = row_format.Rows[j]["Y_SITE"] == DBNull.Value ? 0 : Convert.ToInt32(row_format.Rows[j]["Y_SITE"]);                //offset row位置

                        vertical_align = row_format.Rows[j]["VERTICAL_ALIGN"] == DBNull.Value ? 1 : Convert.ToInt32(row_format.Rows[j]["VERTICAL_ALIGN"]); //文字垂直對齊
                        horizontal_align = row_format.Rows[j]["HORIZONTAL_ALIGN"] == DBNull.Value ? 1 : Convert.ToInt32(row_format.Rows[j]["HORIZONTAL_ALIGN"]); //文字水平對齊
                        isDirectionVertical = row_format.Rows[j]["DIRECTION_VERTICAL"] == DBNull.Value ? false : Convert.ToBoolean(row_format.Rows[j]["DIRECTION_VERTICAL"]);


                        #region row列印文字
                        if (print_type == PrintType.Row_Head_Text || print_type == PrintType.Row_Middle_Text || print_type == PrintType.Row_End_Text)
                        {

                            //if (print_type == PrintType.Row_Head_Text) print_data = print_data.Replace(@"[[", "");
                            //if (print_type == PrintType.Row_End_Text) print_data = print_data.Replace(@"]]", "");

                            sheet.Range[cell_name].Text = print_data;
                            sheet.Range[cell_name].IsWrapText = true;
                            sheet.Range[cell_name].Style.Font.Color = Color.FromName(font_color);
                            sheet.Range[cell_name].Style.Font.Size = font_size;
                            sheet.Range[cell_name].Style.Font.IsBold = Convert.ToBoolean(font_style.IndexOf("B") >= 0);
                            sheet.Range[cell_name].Style.Font.IsItalic = Convert.ToBoolean(font_style.IndexOf("I") >= 0);
                            sheet.Range[cell_name].Style.Font.IsStrikethrough = Convert.ToBoolean(font_style.IndexOf("S") >= 0);
                            if (Convert.ToBoolean(font_style.IndexOf("U") >= 0))
                            {
                                sheet.Range[cell_name].Style.Font.Underline = FontUnderlineType.Single;
                            }

                            switch (vertical_align)
                            {
                                case 0:
                                    sheet.Range[cell_name].Style.VerticalAlignment = VerticalAlignType.Top;
                                    break;
                                case 1:
                                    sheet.Range[cell_name].Style.VerticalAlignment = VerticalAlignType.Center;
                                    break;
                                case 2:
                                    sheet.Range[cell_name].Style.VerticalAlignment = VerticalAlignType.Bottom;
                                    break;
                                default:
                                    sheet.Range[cell_name].Style.VerticalAlignment = VerticalAlignType.Center;
                                    break;
                            }

                            switch (horizontal_align)
                            {
                                case 0:
                                    sheet.Range[cell_name].Style.HorizontalAlignment = HorizontalAlignType.Left;
                                    break;
                                case 1:
                                    sheet.Range[cell_name].Style.HorizontalAlignment = HorizontalAlignType.Center;
                                    break;
                                case 2:
                                    sheet.Range[cell_name].Style.HorizontalAlignment = HorizontalAlignType.Right;
                                    break;
                                default:
                                    sheet.Range[cell_name].Style.HorizontalAlignment = HorizontalAlignType.Center;
                                    break;

                            }

                            if (isDirectionVertical == true)
                            {
                                sheet.Range[cell_name].Style.Rotation = 90;
                            }
                        }
                        #endregion


                        #region row列印barcode
                        if (print_type == PrintType.Row_Head_Barcode || print_type == PrintType.Row_Middle_Barcode || print_type == PrintType.Row_End_Barcode)
                        {
                            if (print_data == string.Empty || print_data.Length < 3)
                            {
                                continue;
                            }

                            BindBarCode BarCode = new BindBarCode();
                            BindBarCode.Encode encode = GetBarcodeEncode(font_family);
                            Image img = null;

                            if (encode == BindBarCode.Encode.Code128A || encode == BindBarCode.Encode.Code128B ||
                                encode == BindBarCode.Encode.Code128C || encode == BindBarCode.Encode.EAN128)
                            {
                                img = BarCode.GetCodeImage(print_data, encode);
                            }
                            else
                            {
                                BarcodeWriter bw = new BarcodeWriter();
                                switch (encode)
                                {
                                    case BindBarCode.Encode.EAN13:
                                        bw.Format = BarcodeFormat.EAN_13;
                                        break;
                                    case BindBarCode.Encode.EAN8:
                                        bw.Format = BarcodeFormat.EAN_8;
                                        break;
                                    case BindBarCode.Encode.Code39:
                                        bw.Format = BarcodeFormat.CODE_39;
                                        break;
                                    case BindBarCode.Encode.Codabar:
                                        bw.Format = BarcodeFormat.CODABAR;
                                        break;

                                }
                                bw.Options.PureBarcode = true;
                                img = bw.Write(print_data);
                            }

                            int[] range = Get_Image_Layout_Range(cell_name);
                            ExcelPicture picture = sheet.Pictures.Add(range[0], range[1], img, ImageFormatType.Original);



                            picture.Width = data_width;
                            picture.Height = data_height;
                            picture.ResizeBehave = ResizeBehaveType.FreeFloating;

                            picture.TopRowOffset = data_offset_row;
                            picture.LeftColumnOffset = data_offset_column;

                        }
                        #endregion


                        #region row列印圖片
                        if (print_type == PrintType.Row_Head_Image || print_type == PrintType.Row_Middle_Image || print_type == PrintType.Row_End_Image)
                        {
                            if (print_data == string.Empty || (!File.Exists(print_data)))
                            {
                                continue;
                            }

                            Image img = null;
                            if (print_data.ToUpper().IndexOf("HTTP") == -1)
                            {
                                DaoPopImage daoImage = new DaoPopImage();
                                if (daoImage.Exist_Image(print_data))
                                {
                                    MemoryStream ms = new MemoryStream(daoImage.Get_Image(print_data));
                                    img = Image.FromStream(ms);
                                }
                                else
                                {
                                    using (FileStream fs = new FileStream(print_data, FileMode.Open))
                                    {
                                        BinaryReader br = new BinaryReader(fs);
                                        img = Image.FromStream(br.BaseStream);
                                    }
                                }
                            }
                            else
                            {
                                System.Net.WebClient WC = new System.Net.WebClient();
                                MemoryStream Ms = new MemoryStream(WC.DownloadData(print_data));
                                img = Image.FromStream(Ms);
                            }
                            int[] range = Get_Image_Layout_Range(cell_name);

                            ExcelPicture picture = sheet.Pictures.Add(range[0], range[1], img, ImageFormatType.Original);

                            picture.Width = data_width;
                            picture.Height = data_height;

                            picture.TopRowOffset = data_offset_row;
                            picture.LeftColumnOffset = data_offset_column;

                            img.Dispose();

                        }
                        #endregion


                        #region row列印QRCode
                        if (print_type == PrintType.Row_Head_QRCode || print_type == PrintType.Row_Middle_QrCode || print_type == PrintType.Row_End_QrCode)
                        {

                            Image img = null;

                            if (data_width > data_height)
                                data_width = data_height;
                            else
                                data_height = data_width;

                            IBarcodeWriter writer = new BarcodeWriter()
                            {
                                Format = BarcodeFormat.QR_CODE,
                                Options = new QrCodeEncodingOptions()
                                {
                                    ErrorCorrection = ErrorCorrectionLevel.M,
                                    Margin = 0,
                                    Width = Convert.ToInt32(data_width),
                                    Height = Convert.ToInt32(data_height),
                                    CharacterSet = "UTF-8"   // 少了這一行中文就亂碼了
                                }
                            };

                            img = writer.Write(print_data);

                            int[] range = Get_Image_Layout_Range(cell_name);

                            ExcelPicture picture = sheet.Pictures.Add(range[0], range[1], img, ImageFormatType.Original);

                            picture.TopRowOffset = data_offset_row;
                            picture.LeftColumnOffset = data_offset_column;

                            img.Dispose();
                        }

                        #endregion


                        #region row列印公式
                        if (print_type == PrintType.Row_Head_Formula || print_type == PrintType.Row_Middle_Formula || print_type == PrintType.Row_End_Formula)
                        {
                            sheet.Range[cell_name].Formula = print_data;

                            sheet.Range[cell_name].Style.Font.Color = Color.FromName(font_color);
                            sheet.Range[cell_name].Style.Font.Size = font_size;
                            sheet.Range[cell_name].Style.Font.IsBold = Convert.ToBoolean(font_style.IndexOf("B") >= 0);
                            sheet.Range[cell_name].Style.Font.IsItalic = Convert.ToBoolean(font_style.IndexOf("I") >= 0);
                            sheet.Range[cell_name].Style.Font.IsStrikethrough = Convert.ToBoolean(font_style.IndexOf("S") >= 0);
                            if (Convert.ToBoolean(font_style.IndexOf("U") >= 0))
                            {
                                sheet.Range[cell_name].Style.Font.Underline = FontUnderlineType.Single;
                            }
                            //Console.WriteLine( Convert.ToBoolean(font_style.IndexOf("B")).ToString() );


                            switch (vertical_align)
                            {
                                case 0:
                                    sheet.Range[cell_name].Style.VerticalAlignment = VerticalAlignType.Top;
                                    break;
                                case 1:
                                    sheet.Range[cell_name].Style.VerticalAlignment = VerticalAlignType.Center;
                                    break;
                                case 2:
                                    sheet.Range[cell_name].Style.VerticalAlignment = VerticalAlignType.Bottom;
                                    break;
                                default:
                                    sheet.Range[cell_name].Style.VerticalAlignment = VerticalAlignType.Center;
                                    break;
                            }

                            switch (horizontal_align)
                            {
                                case 0:
                                    sheet.Range[cell_name].Style.HorizontalAlignment = HorizontalAlignType.Left;
                                    break;
                                case 1:
                                    sheet.Range[cell_name].Style.HorizontalAlignment = HorizontalAlignType.Center;
                                    break;
                                case 2:
                                    sheet.Range[cell_name].Style.HorizontalAlignment = HorizontalAlignType.Right;
                                    break;
                                default:
                                    sheet.Range[cell_name].Style.HorizontalAlignment = HorizontalAlignType.Center;
                                    break;

                            }

                            if (isDirectionVertical == true)
                            {
                                sheet.Range[cell_name].Style.Rotation = 90;
                            }
                        }
                        #endregion

                    }
                }
                #endregion
            }
            catch(Exception ex)
            {
                sheet.Range["A1"].Text = "資料錯誤：" + ex.Message;
            }

        }

        private string[] Get_Row_Name_Split(string excel_range)
        {
            string[] str = excel_range.ToUpper().Split(':');
            string[] range = new string[4];

            range[0] = Regex.Replace(str[0], "[0-9]", "", RegexOptions.IgnoreCase);
            range[1] = Regex.Replace(str[0], "[A-Z]", "", RegexOptions.IgnoreCase);
            range[2] = Regex.Replace(str[1], "[0-9]", "", RegexOptions.IgnoreCase);
            range[3] = Regex.Replace(str[1], "[A-Z]", "", RegexOptions.IgnoreCase);
            
            return range;
        }

        /*
        private int[] Get_Image_Layout_Range(string excel_range)
        {
            string[] str = excel_range.ToUpper().Split(':');
            int[] range = new int[4];           


            range[0] = Int32.Parse(Regex.Replace(str[0], "[A-Z]", "", RegexOptions.IgnoreCase));
            range[1] = str2int(Regex.Replace(str[0], "[0-9]", "", RegexOptions.IgnoreCase));
            range[2] = Int32.Parse(Regex.Replace(str[1], "[A-Z]", "", RegexOptions.IgnoreCase));
            range[3] = str2int(Regex.Replace(str[1], "[0-9]", "", RegexOptions.IgnoreCase));

            return range;
        }
        */

        private int[] Get_Image_Layout_Range(string excel_range)
        {
            int[] range = new int[2];

            range[0] = Int32.Parse(Regex.Replace(excel_range, "[A-Z]", "", RegexOptions.IgnoreCase));
            range[1] = str2int(Regex.Replace(excel_range, "[0-9]", "", RegexOptions.IgnoreCase));

            return range;
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



        #region Table Filter
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
        #endregion

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

        #region Excel 欄數轉換
        /*
         * 將字串(a-z)轉換成數字
         * 按照excel表格的列號(如：a-->1,z-->26,aa->27,az-52,....)
         */
        private int str2int(String str)
        {
            char[] array = str.ToCharArray();
            int result = 0;
            for (int j = 0; j < array.Length; j++)
            {
                result *= 26;
                result += char2int(array[j]);
            }
            return result;
        }

        /* 將字元轉換成整數 */
        private int char2int(char ch)
        {
            int result = -1;
            if (ch >= 'A' && ch <= 'Z')
            {
                result = ch - 'A' + 1;
            }
            else if (ch >= 'a' && ch <= 'z')
            {
                result = ch - 'a' + 1;
            }
            return result;
        }

        /* 將1轉換成A,26轉換成Z，無限往後推,對應excel表格的列 */
        private String int2Str(int num)
        {
            String result = "";
            num = num <= 0 ? 1 : num;//小於等於0是輸出A
            while (num > 0)
            {
                int m = num % 26;
                if (m == 0) m = 26;
                result = (char)(m + 64) + result;
                num = (num - m) / 26;
            }
            return result;
        }
        #endregion

    }
}


/*
   
    
    string output_file = @"C:\temp\test.xls";
    string image_file = @"C:\temp\Code128.png";
    string excel_path = @"C:\temp\excel.png";





    Workbook book = new Workbook();

    book.LoadFromFile(file_name);

    Worksheet sheet = book.Worksheets[0];

    sheet.Activate();
    sheet.PageSetup.FitToPagesWide = 0;
    sheet.PageSetup.FitToPagesTall = 0;
    sheet.PageSetup.TopMargin = 0;
    sheet.PageSetup.LeftMargin = 0;
    sheet.PageSetup.RightMargin = 0;
    sheet.PageSetup.BottomMargin = 0;
    
    
    
    
   sheet.Range["C2"].Text = DateTime.Now.ToString();
   sheet.Range["R2"].Text = "99/99";





   BarcodeWriter bw = new BarcodeWriter();
   bw.Format = BarcodeFormat.CODE_128;
   bw.Options.PureBarcode = true;
   Bitmap image = bw.Write("0351201214_972A7_U11");

   sheet.Pictures.Add(11, 5, 11, 8, image, ImageFormatType.Png);



   image.Save(image_file);

   sheet.SaveToImage(excel_path);

   book.SaveToFile(output_file, ExcelVersion.Version97to2003);

   //excel_image = Image.FromFile(excel_path);


   if (print == true)
   {
       using (PrintDocument print_doc = book.PrintDocument)
       {
           print_doc.DocumentName = "POP_EXCEL";
           print_doc.PrinterSettings.PrinterName = printer;
           print_doc.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A4Rotated;
           print_doc.DefaultPageSettings.Landscape = true;

           //print_doc.Print();
       }
   }
   else
   {
       System.Diagnostics.Process.Start(output_file);
   }
   */
