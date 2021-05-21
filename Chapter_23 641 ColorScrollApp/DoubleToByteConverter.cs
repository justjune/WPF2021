//------------------------------------------------------
// DoubleToByteConverter.cs (c) 2006 by Charles Petzold
//------------------------------------------------------
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Chapter_23_641_ColorScrollApp
{
    //Конвертирует Double в Byte
    [ValueConversion(typeof(double), typeof(byte))]
    public class DoubleToByteConverter : IValueConverter
    {
        public object Convert(object value, Type typeTarget,
                              object param, CultureInfo culture)
        {
            return (byte)(double)value;
        }
        public object ConvertBack(object value, Type typeTarget,
                                  object param, CultureInfo culture)
        {
            return (double)value;
        }
    }
}