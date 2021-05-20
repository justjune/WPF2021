//----------------------------------------------
// SimpleElement.cs (c) 2006 by Charles Petzold
//----------------------------------------------
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace Petzold.CustomElementBinding
{
    class SimpleElement : FrameworkElement
    {
        // Определение DependencyProperty.
        public static DependencyProperty NumberProperty;

        // Создать DependencyProperty в статическом конструкторе.
        static SimpleElement()
        {
            NumberProperty =
                DependencyProperty.Register("Number", typeof(double),
                                            typeof(SimpleElement),
                    new FrameworkPropertyMetadata(0.0,
                            FrameworkPropertyMetadataOptions.AffectsRender));
        }

        // DependencyProperty оформляется в виде свойства CLR.
        public double Number
        {
            set { SetValue(NumberProperty, value); }
            get { return (double)GetValue(NumberProperty); }
        }

        // Жёсткое кодирование размера для MeasureOverride.
        protected override Size MeasureOverride(Size sizeAvailable)
        {
            return new Size(200, 50);
        }

        // Метод OnRender выводит значения свойства Number.
        protected override void OnRender(DrawingContext dc)
        {
            dc.DrawText(
                new FormattedText(Number.ToString(),
                        CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                        new Typeface("Times New Roman"), 12,
                        SystemColors.WindowTextBrush),
                new Point(0, 0));
        }
    }
}
