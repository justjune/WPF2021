using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
namespace Petzold.TextGeometryDemo
{
    public class TextGeometry
    {
        // Приватные поля, используемые открытыми свойствами         
        string txt = "";
        FontFamily fntfam = new FontFamily(); // FontFamily представляет семейство связанных шрифтов
        FontStyle fntstyle = FontStyles.Normal; // объект FontStyle отвечает за наклон текста      
        FontWeight fntwt = FontWeights.Normal;    //  объект FontWeight отвечает за плотность текста    
        FontStretch fntstr = FontStretches.Normal;  // объект FontStretch отвечает за коэффициент растяжения или сжатия текста       
        double emsize = 24;
        Point ptOrigin = new Point(0, 0); // начало координат

        // открытые свойства с сеттерами и геттерами     
        public string Text
        {
            set { txt = value; }
            get { return txt; }
        }
        public FontFamily FontFamily
        {
            set { fntfam = value; }
            get { return fntfam; }
        }
        public FontStyle FontStyle
        {
            set { fntstyle = value; }
            get { return fntstyle; }
        }
        public FontWeight FontWeight
        {
            set { fntwt = value; }
            get { return fntwt; }
        }
        public FontStretch FontStretch
        {
            set { fntstr = value; }
            get { return fntstr; }
        }
        public double FontSize
        {
            set { emsize = value; }
            get { return emsize; }
        }
        public Point Origin
        {
            set { ptOrigin = value; }
            get { return ptOrigin; }
        }
        // открытое свойство, возвращающее объект Geometry (класс, описывающий геометрию двухмерной фигуры)        
        public Geometry Geometry
        {
            get
            {
                // объект FormattedText позволяет рисовать многострочный текст, в котором каждый символ в тексте можно форматировать отдельно
                FormattedText formtxt =
                    new FormattedText(Text, CultureInfo.CurrentCulture,
                        FlowDirection.LeftToRight,
                        new Typeface(FontFamily, FontStyle, FontWeight, FontStretch),
                        FontSize, Brushes.Black);
                return formtxt.BuildGeometry(Origin); //возвращаем представление форматированного текста в виде объекта Geometry        
            }
        }
        // необходимо для анимации       
        public PathGeometry PathGeometry
        {
            get
            {
                return PathGeometry.CreateFromGeometry(Geometry);  // возвращаем объект PathGeometry, созданный из текущих значений заданного Geometry.  
                                                                   // PathGeometry представляет сложную фигуру, которая может состоять из дуг, кривых, эллипсов, линий и прямоугольников
            }
        }
    }
}