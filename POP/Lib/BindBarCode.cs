﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace POP.Lib
{
    public class BindBarCode
    {
        private DataTable m_Code128 = new DataTable();
        private uint m_Height = 40;
        /// <summary>
        /// 高度
        /// </summary>
        public uint Height { get { return m_Height; } set { m_Height = value; } }


        private Font m_ValueFont = null;
        /// <summary>
        /// 是否顯示可見號碼 如果為Null不顯示號碼
        /// </summary>
        public Font ValueFont { get { return m_ValueFont; } set { m_ValueFont = value; } }


        private byte m_Magnify = 0;
        /// <summary>
        /// 放大倍數
        /// </summary>
        public byte Magnify { get { return m_Magnify; } set { m_Magnify = value; } }
        /// <summary>
        /// 條碼類別
        /// </summary>
        public enum Encode
        {
            Code128A,
            Code128B,
            Code128C,
            EAN128,
            EAN13,
            EAN8,
            Code39,
            Codabar
        }


        public void CCode128()
        {
            m_Code128.Columns.Add("ID");
            m_Code128.Columns.Add("Code128A");
            m_Code128.Columns.Add("Code128B");
            m_Code128.Columns.Add("Code128C");
            m_Code128.Columns.Add("BandCode");

            m_Code128.CaseSensitive = true;

            #region 資料表
            m_Code128.Rows.Add("0", " ", " ", "00", "212222");
            m_Code128.Rows.Add("1", "!", "!", "01", "222122");
            m_Code128.Rows.Add("2", "\"", "\"", "02", "222221");
            m_Code128.Rows.Add("3", "#", "#", "03", "121223");
            m_Code128.Rows.Add("4", "$", "$", "04", "121322");
            m_Code128.Rows.Add("5", "%", "%", "05", "131222");
            m_Code128.Rows.Add("6", "&", "&", "06", "122213");
            m_Code128.Rows.Add("7", "'", "'", "07", "122312");
            m_Code128.Rows.Add("8", "(", "(", "08", "132212");
            m_Code128.Rows.Add("9", ")", ")", "09", "221213");
            m_Code128.Rows.Add("10", "*", "*", "10", "221312");
            m_Code128.Rows.Add("11", "+", "+", "11", "231212");
            m_Code128.Rows.Add("12", ",", ",", "12", "112232");
            m_Code128.Rows.Add("13", "-", "-", "13", "122132");
            m_Code128.Rows.Add("14", ".", ".", "14", "122231");
            m_Code128.Rows.Add("15", "/", "/", "15", "113222");
            m_Code128.Rows.Add("16", "0", "0", "16", "123122");
            m_Code128.Rows.Add("17", "1", "1", "17", "123221");
            m_Code128.Rows.Add("18", "2", "2", "18", "223211");
            m_Code128.Rows.Add("19", "3", "3", "19", "221132");
            m_Code128.Rows.Add("20", "4", "4", "20", "221231");
            m_Code128.Rows.Add("21", "5", "5", "21", "213212");
            m_Code128.Rows.Add("22", "6", "6", "22", "223112");
            m_Code128.Rows.Add("23", "7", "7", "23", "312131");
            m_Code128.Rows.Add("24", "8", "8", "24", "311222");
            m_Code128.Rows.Add("25", "9", "9", "25", "321122");
            m_Code128.Rows.Add("26", ":", ":", "26", "321221");
            m_Code128.Rows.Add("27", ";", ";", "27", "312212");
            m_Code128.Rows.Add("28", "<", "<", "28", "322112");
            m_Code128.Rows.Add("29", "=", "=", "29", "322211");
            m_Code128.Rows.Add("30", ">", ">", "30", "212123");
            m_Code128.Rows.Add("31", "?", "?", "31", "212321");
            m_Code128.Rows.Add("32", "@", "@", "32", "232121");
            m_Code128.Rows.Add("33", "A", "A", "33", "111323");
            m_Code128.Rows.Add("34", "B", "B", "34", "131123");
            m_Code128.Rows.Add("35", "C", "C", "35", "131321");
            m_Code128.Rows.Add("36", "D", "D", "36", "112313");
            m_Code128.Rows.Add("37", "E", "E", "37", "132113");
            m_Code128.Rows.Add("38", "F", "F", "38", "132311");
            m_Code128.Rows.Add("39", "G", "G", "39", "211313");
            m_Code128.Rows.Add("40", "H", "H", "40", "231113");
            m_Code128.Rows.Add("41", "I", "I", "41", "231311");
            m_Code128.Rows.Add("42", "J", "J", "42", "112133");
            m_Code128.Rows.Add("43", "K", "K", "43", "112331");
            m_Code128.Rows.Add("44", "L", "L", "44", "132131");
            m_Code128.Rows.Add("45", "M", "M", "45", "113123");
            m_Code128.Rows.Add("46", "N", "N", "46", "113321");
            m_Code128.Rows.Add("47", "O", "O", "47", "133121");
            m_Code128.Rows.Add("48", "P", "P", "48", "313121");
            m_Code128.Rows.Add("49", "Q", "Q", "49", "211331");
            m_Code128.Rows.Add("50", "R", "R", "50", "231131");
            m_Code128.Rows.Add("51", "S", "S", "51", "213113");
            m_Code128.Rows.Add("52", "T", "T", "52", "213311");
            m_Code128.Rows.Add("53", "U", "U", "53", "213131");
            m_Code128.Rows.Add("54", "V", "V", "54", "311123");
            m_Code128.Rows.Add("55", "W", "W", "55", "311321");
            m_Code128.Rows.Add("56", "X", "X", "56", "331121");
            m_Code128.Rows.Add("57", "Y", "Y", "57", "312113");
            m_Code128.Rows.Add("58", "Z", "Z", "58", "312311");
            m_Code128.Rows.Add("59", "[", "[", "59", "332111");
            m_Code128.Rows.Add("60", "//", "//", "60", "314111");
            m_Code128.Rows.Add("61", "]", "]", "61", "221411");
            m_Code128.Rows.Add("62", "^", "^", "62", "431111");
            m_Code128.Rows.Add("63", "_", "_", "63", "111224");
            m_Code128.Rows.Add("64", "NUL", "`", "64", "111422");
            m_Code128.Rows.Add("65", "SOH", "a", "65", "121124");
            m_Code128.Rows.Add("66", "STX", "b", "66", "121421");
            m_Code128.Rows.Add("67", "ETX", "c", "67", "141122");
            m_Code128.Rows.Add("68", "EOT", "d", "68", "141221");
            m_Code128.Rows.Add("69", "ENQ", "e", "69", "112214");
            m_Code128.Rows.Add("70", "ACK", "f", "70", "112412");
            m_Code128.Rows.Add("71", "BEL", "g", "71", "122114");
            m_Code128.Rows.Add("72", "BS", "h", "72", "122411");
            m_Code128.Rows.Add("73", "HT", "i", "73", "142112");
            m_Code128.Rows.Add("74", "LF", "j", "74", "142211");
            m_Code128.Rows.Add("75", "VT", "k", "75", "241211");
            m_Code128.Rows.Add("76", "FF", "I", "76", "221114");
            m_Code128.Rows.Add("77", "CR", "m", "77", "413111");
            m_Code128.Rows.Add("78", "SO", "n", "78", "241112");
            m_Code128.Rows.Add("79", "SI", "o", "79", "134111");
            m_Code128.Rows.Add("80", "DLE", "p", "80", "111242");
            m_Code128.Rows.Add("81", "DC1", "q", "81", "121142");
            m_Code128.Rows.Add("82", "DC2", "r", "82", "121241");
            m_Code128.Rows.Add("83", "DC3", "s", "83", "114212");
            m_Code128.Rows.Add("84", "DC4", "t", "84", "124112");
            m_Code128.Rows.Add("85", "NAK", "u", "85", "124211");
            m_Code128.Rows.Add("86", "SYN", "v", "86", "411212");
            m_Code128.Rows.Add("87", "ETB", "w", "87", "421112");
            m_Code128.Rows.Add("88", "CAN", "x", "88", "421211");
            m_Code128.Rows.Add("89", "EM", "y", "89", "212141");
            m_Code128.Rows.Add("90", "SUB", "z", "90", "214121");
            m_Code128.Rows.Add("91", "ESC", "{", "91", "412121");
            m_Code128.Rows.Add("92", "FS", "|", "92", "111143");
            m_Code128.Rows.Add("93", "GS", "}", "93", "111341");
            m_Code128.Rows.Add("94", "RS", "~", "94", "131141");
            m_Code128.Rows.Add("95", "US", "DEL", "95", "114113");
            m_Code128.Rows.Add("96", "FNC3", "FNC3", "96", "114311");
            m_Code128.Rows.Add("97", "FNC2", "FNC2", "97", "411113");
            m_Code128.Rows.Add("98", "SHIFT", "SHIFT", "98", "411311");
            m_Code128.Rows.Add("99", "CODEC", "CODEC", "99", "113141");
            m_Code128.Rows.Add("100", "CODEB", "FNC4", "CODEB", "114131");
            m_Code128.Rows.Add("101", "FNC4", "CODEA", "CODEA", "311141");
            m_Code128.Rows.Add("102", "FNC1", "FNC1", "FNC1", "411131");
            m_Code128.Rows.Add("103", "StartA", "StartA", "StartA", "211412");
            m_Code128.Rows.Add("104", "StartB", "StartB", "StartB", "211214");
            m_Code128.Rows.Add("105", "StartC", "StartC", "StartC", "211232");
            m_Code128.Rows.Add("106", "Stop", "Stop", "Stop", "2331112");
            #endregion
        }

        /// <summary>
        /// 獲取128圖形
        /// </summary>
        /// <param name="p_Text">文字</param>
        /// <param name="p_Code">編碼</param>
        /// <returns>圖形</returns>
        public Bitmap GetCodeImage(string p_Text, Encode p_Code)
        {
            CCode128();
            string _ViewText = p_Text;
            string _Text = "";
            IList<int> _TextNumb = new List<int>();
            int _Examine = 0; //首位
            switch (p_Code)
            {
                case Encode.Code128C:
                    _Examine = 105;
                    if (!((p_Text.Length & 1) == 0)) throw new Exception("128C長度必須是偶數");
                    while (p_Text.Length != 0)
                    {
                        int _Temp = 0;
                        try
                        {
                            int _CodeNumb128 = Int32.Parse(p_Text.Substring(0, 2));
                        }
                        catch
                        {
                            throw new Exception("128C必須是數位！");
                        }
                        _Text += GetValue(p_Code, p_Text.Substring(0, 2), ref _Temp);
                        _TextNumb.Add(_Temp);
                        p_Text = p_Text.Remove(0, 2);
                    }
                    break;
                case Encode.EAN128:
                    _Examine = 105;
                    if (!((p_Text.Length & 1) == 0)) throw new Exception("EAN128長度必須是偶數");
                    _TextNumb.Add(102);
                    _Text += "411131";
                    while (p_Text.Length != 0)
                    {
                        int _Temp = 0;
                        try
                        {
                            int _CodeNumb128 = Int32.Parse(p_Text.Substring(0, 2));
                        }
                        catch
                        {
                            throw new Exception("128C必須是數位！");
                        }
                        _Text += GetValue(Encode.Code128C, p_Text.Substring(0, 2), ref _Temp);
                        _TextNumb.Add(_Temp);
                        p_Text = p_Text.Remove(0, 2);
                    }
                    break;
                default:
                    if (p_Code == Encode.Code128A)
                    {
                        _Examine = 103;
                    }
                    else
                    {
                        _Examine = 104;
                    }

                    while (p_Text.Length != 0)
                    {
                        int _Temp = 0;
                        string _ValueCode = GetValue(p_Code, p_Text.Substring(0, 1), ref _Temp);
                        if (_ValueCode.Length == 0) throw new Exception("不正確字元集!" + p_Text.Substring(0, 1).ToString());
                        _Text += _ValueCode;
                        _TextNumb.Add(_Temp);
                        p_Text = p_Text.Remove(0, 1);
                    }
                    break;
            }

            if (_TextNumb.Count == 0) throw new Exception("錯誤的編碼,無資料");
            _Text = _Text.Insert(0, GetValue(_Examine)); //獲取開始位

            for (int i = 0; i != _TextNumb.Count; i++)
            {
                _Examine += _TextNumb[i] * (i + 1);
            }
            _Examine = _Examine % 103; //獲得嚴效位
            _Text += GetValue(_Examine); //獲取嚴效位

            _Text += "2331112"; //結束位

            Bitmap _CodeImage = GetImage(_Text);
            GetViewText(_CodeImage, _ViewText);
            return _CodeImage;
        }

        /// <summary>
        /// 獲取目標對應的資料
        /// </summary>
        /// <param name="p_Code">編碼</param>
        /// <param name="p_Value">數值 A b 30</param>
        /// <param name="p_SetID">返回編號</param>
        /// <returns>編碼</returns>
        private string GetValue(Encode p_Code, string p_Value, ref int p_SetID)
        {
            if (m_Code128 == null) return "";
            DataRow[] _Row = m_Code128.Select(p_Code.ToString() + "='" + p_Value + "'");
            if (_Row.Length != 1) throw new Exception("錯誤的編碼" + p_Value.ToString());
            p_SetID = Int32.Parse(_Row[0]["ID"].ToString());
            return _Row[0]["BandCode"].ToString();
        }
        /// <summary>
        /// 根據編號獲得條紋
        /// </summary>
        /// <param name="p_CodeId"></param>
        /// <returns></returns>
        private string GetValue(int p_CodeId)
        {
            DataRow[] _Row = m_Code128.Select("ID='" + p_CodeId.ToString() + "'");
            if (_Row.Length != 1) throw new Exception("驗效位的編碼錯誤" + p_CodeId.ToString());
            return _Row[0]["BandCode"].ToString();
        }

        /// <summary>
        /// 獲得條碼圖形
        /// </summary>
        /// <param name="p_Text">文字</param>
        /// <returns>圖形</returns>
        private Bitmap GetImage(string p_Text)
        {
            char[] _Value = p_Text.ToCharArray();
            int _Width = 0;
            for (int i = 0; i != _Value.Length; i++)
            {
                _Width += Int32.Parse(_Value[i].ToString()) * (m_Magnify + 1);
            }

            Bitmap _CodeImage = new Bitmap(_Width, (int)m_Height);
            Graphics _Garphics = Graphics.FromImage(_CodeImage);
            //Pen _Pen;
            int _LenEx = 0;
            for (int i = 0; i != _Value.Length; i++)
            {
                int _ValueNumb = Int32.Parse(_Value[i].ToString()) * (m_Magnify + 1); //獲取寬和放大係數

                if (!((i & 1) == 0))
                {
                    //_Pen = new Pen(Brushes.White, _ValueNumb);
                    _Garphics.FillRectangle(Brushes.White, new Rectangle(_LenEx, 0, _ValueNumb, (int)m_Height));
                }
                else
                {
                    //_Pen = new Pen(Brushes.Black, _ValueNumb);
                    _Garphics.FillRectangle(Brushes.Black, new Rectangle(_LenEx, 0, _ValueNumb, (int)m_Height));
                }
                //_Garphics.(_Pen, new Point(_LenEx, 0), new Point(_LenEx, m_Height));
                _LenEx += _ValueNumb;

            }

            _Garphics.Dispose();
            return _CodeImage;
        }
        /// <summary>
        /// 顯示可見條碼文字 如果小於40 不顯示文字
        /// </summary>
        /// <param name="p_Bitmap">圖形</param>
        private void GetViewText(Bitmap p_Bitmap, string p_ViewText)
        {
            if (m_ValueFont == null) return;

            Graphics _Graphics = Graphics.FromImage(p_Bitmap);
            SizeF _DrawSize = _Graphics.MeasureString(p_ViewText, m_ValueFont);
            if (_DrawSize.Height > p_Bitmap.Height - 10 || _DrawSize.Width > p_Bitmap.Width)
            {
                _Graphics.Dispose();
                return;
            }

            int _StarY = p_Bitmap.Height - (int)_DrawSize.Height;

            _Graphics.FillRectangle(Brushes.White, new Rectangle(0, _StarY, p_Bitmap.Width, (int)_DrawSize.Height));
            _Graphics.DrawString(p_ViewText, m_ValueFont, Brushes.Black, 0, _StarY);
        }

        public Bitmap GetCode39(string strSource)
        {
            int x = 5; //左邊界
            int y = 0; //上邊界
            int WidLength = 2; //粗BarCode長度
            int NarrowLength = 1; //細BarCode長度
            int BarCodeHeight = 24; //BarCode高度
            int intSourceLength = strSource.Length;
            string strEncode = "010010100"; //編碼字串 初值為 起始符號 *

            string AlphaBet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*"; //Code39的字母

            string[] Code39 = //Code39的各字母對應碼
                            {
                                /**//* 0 */ "000110100",  
                                /**//* 1 */ "100100001",  
                                /**//* 2 */ "001100001",  
                                /**//* 3 */ "101100000",
                                /**//* 4 */ "000110001",  
                                /**//* 5 */ "100110000",  
                                /**//* 6 */ "001110000",  
                                /**//* 7 */ "000100101",
                                /**//* 8 */ "100100100",  
                                /**//* 9 */ "001100100",  
                                /**//* A */ "100001001",  
                                /**//* B */ "001001001",
                                /**//* C */ "101001000",  
                                /**//* D */ "000011001",  
                                /**//* E */ "100011000",  
                                /**//* F */ "001011000",
                                /**//* G */ "000001101",  
                                /**//* H */ "100001100",  
                                /**//* I */ "001001100",  
                                /**//* J */ "000011100",
                                /**//* K */ "100000011",  
                                /**//* L */ "001000011",  
                                /**//* M */ "101000010",  
                                /**//* N */ "000010011",
                                /**//* O */ "100010010",  
                                /**//* P */ "001010010",  
                                /**//* Q */ "000000111",  
                                /**//* R */ "100000110",
                                /**//* S */ "001000110",  
                                /**//* T */ "000010110",  
                                /**//* U */ "110000001",  
                                /**//* V */ "011000001",
                                /**//* W */ "111000000",  
                                /**//* X */ "010010001",  
                                /**//* Y */ "110010000",  
                                /**//* Z */ "011010000",
                                /**//* - */ "010000101",  
                                /**//* . */ "110000100",  
                                /**//*' '*/ "011000100",
                                /**//* $ */ "010101000",
                                /**//* / */ "010100010",  
                                /**//* + */ "010001010",  
                                /**//* % */ "000101010",  
                                /**//* * */ "010010100"
                            };
            strSource = strSource.ToUpper();
            //實作圖片
            Bitmap objBitmap = new Bitmap(
              ((WidLength * 3 + NarrowLength * 7) * (intSourceLength + 2)) + (x * 2),
              BarCodeHeight + (y * 2));
            Graphics objGraphics = Graphics.FromImage(objBitmap); //宣告GDI+繪圖介面
                                                                  //填上底色
            objGraphics.FillRectangle(Brushes.White, 0, 0, objBitmap.Width, objBitmap.Height);

            for (int i = 0; i < intSourceLength; i++)
            {
                //檢查是否有非法字元
                if (AlphaBet.IndexOf(strSource[i]) == -1 || strSource[i] == '*')
                {
                    objGraphics.DrawString("含有非法字元",
                      SystemFonts.DefaultFont, Brushes.Red, x, y);
                    return objBitmap;
                }
                //查表編碼
                strEncode = string.Format("{0}0{1}", strEncode,
                 Code39[AlphaBet.IndexOf(strSource[i])]);
            }

            strEncode = string.Format("{0}0010010100", strEncode); //補上結束符號 *

            int intEncodeLength = strEncode.Length; //編碼後長度
            int intBarWidth;

            for (int i = 0; i < intEncodeLength; i++) //依碼畫出Code39 BarCode
            {
                intBarWidth = strEncode[i] == '1' ? WidLength : NarrowLength;
                objGraphics.FillRectangle(i % 2 == 0 ? Brushes.Black : Brushes.White,
                 x, y, intBarWidth, BarCodeHeight);
                x += intBarWidth;
            }
            return objBitmap;
        }
    }
}
