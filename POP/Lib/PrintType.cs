using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POP.Lib
{
    public enum PrintType
    {
        Text = 0,
        Barcode = 1,
        Image = 2,
        QRCode = 3,
        Cell_Of_Text = 100,
        Cell_Of_Barcode = 101,
        Cell_Of_Image = 102,
        Cell_Of_QRCode = 103,
        Cell_Of_Formula = 104,
        Row_Head_Text = 210,
        Row_Head_Barcode = 211,
        Row_Head_Image = 212,
        Row_Head_QRCode = 213,
        Row_Head_Formula = 214,
        Row_Middle_Text = 220,
        Row_Middle_Barcode = 221,
        Row_Middle_Image = 222,
        Row_Middle_QrCode = 223,
        Row_Middle_Formula = 224,
        Row_End_Text = 230,
        Row_End_Barcode = 231,
        Row_End_Image = 232,
        Row_End_QrCode = 233,
        Row_End_Formula = 234
    }
}
