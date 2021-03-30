using System;
using System.Windows;
using System.Windows.Media;

namespace Petzold.RenderTheGraphic
{
    class SimpleEllipse : FrameworkElement //создаем класс эллипса, который мы будем использлвать в RenderTheGraphic
    {
        protected override void OnRender(DrawingContext dc)
        {
            dc.DrawEllipse(Brushes.Blue, new Pen(Brushes.Red, 24),
                new Point(RenderSize.Width / 2, RenderSize.Height / 2), 
                //Свойство RenderSize определяется до вызова OnRender(обеспечивает визувльное представление обьекта на основе возможной ширины и
                //параметра высоты и согласования между этим классом и контейнером, в котором он появится.
                RenderSize.Width / 2, RenderSize.Height / 2);
        }
    }
}
