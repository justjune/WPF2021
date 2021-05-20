using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Petzold.RenderTheAnimation
{
    class AnimatedCircle : FrameworkElement
    {
        protected override void OnRender(DrawingContext dc) // переопределяем метод OnRender
        {
            DoubleAnimation anima = new DoubleAnimation(); // создаём объект класса, предназначенного для изменения таких свойств, как длина, ширина, которые представляют тип double 
            // свойства управления анимацией
            anima.From = 0; // начальное значение, с которого будет начинается анимация
            anima.To = 100; // конечное значение
            anima.Duration = new Duration(TimeSpan.FromSeconds(1)); // время анимации в виде объекта TimeSpan//TimeSpan - структура, представляющая интервал времени
            anima.AutoReverse = true; // при значении true анимация выполняется в противоположную сторону
            anima.RepeatBehavior = RepeatBehavior.Forever;  // позволяет установить, как анимация будет повторяться
            AnimationClock clock = anima.CreateClock(); // создаем часы AnimationClock на основе AnimationTimeline()
            // AnimationTimeline определяет интервал времени, в течение которого создаются выходные значения. 
            // Эти значения используются для анимации целевого свойства.

            // рисует эллипс заданными Brush и Pen и применяет заданные часы анимации
            dc.DrawEllipse(Brushes.Blue/*кисть для рисования эллипса*/,
               new Pen(Brushes.Red, 3)/*перо для обводки эллипса*/,
               new Point(125, 125)/*местоположение центра эллипса*/,
               null,/*часы, с использованием которых следует анимировать позицию центра эллипса, или null, чтобы анимация не выполнялась*/
               0, /*горизонтальный радиус эллипса*/
               clock, /*часы, с использованием которых следует анимировать x-радиус эллипса, или null, чтобы анимация не выполнялась*/
               0, /*вертикальный радиус эллипса*/
               clock);/*часы, с использованием которых следует анимировать y-радиус эллипса, или null, чтобы анимация не выполнялась*/


        }
    }
}