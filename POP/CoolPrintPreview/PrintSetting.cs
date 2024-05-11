using System;
using System.Drawing.Printing;

namespace CoolPrintPreview
{
    public class PrintSetting
    {
        private int _from = 0;
        private int _to = 9999;
        private string _select = string.Empty;

        public String Printer { get; set; }
        public PaperSource Source { get; set; }
        public PrintRange Range { get; set; }
        public string SelectPage
        {
            get
            {
                return _select;
            }
            set
            {
                _select = value;
                string[] pages = value.Split('-');
                if (pages.Length == 1)
                {
                    if(!int.TryParse(pages[0], out _from))
                    {
                        FromPage = _from;
                        throw new Exception("輸入頁數錯誤");
                    }
                    if (!int.TryParse(pages[0], out _to))
                    {
                        ToPage = _to;
                        throw new Exception("輸入頁數錯誤");
                    }
                }
                else if (pages.Length == 2)
                {
                    if (!int.TryParse(pages[0], out _from))
                    {
                        FromPage = _from;
                        throw new Exception("輸入頁數錯誤");
                    }
                    if (!int.TryParse(pages[1], out _to))
                    {
                        ToPage = _to;
                        throw new Exception("輸入頁數錯誤");
                    }
                    if (_from>_to) throw new Exception("輸入頁數錯誤");
                }
                else
                {
                    throw new Exception("輸入頁數錯誤");
                }
            }
        }
        public int FromPage
        {
            get { return _from; }
            set { _from = value; }
        }
        public int ToPage
        {
            get { return _to; }
            set { _to = value; }
        } 
    }
}
