using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.RenderTheBetterEllipse
{
    public class BetterEllipse : FrameworkElement 
    {
        // Зависимые свойства
        public static readonly DependencyProperty FillProperty; // Заливка
        public static readonly DependencyProperty StrokeProperty; // Контур, обводка

        // Открытые интерфейсы к зависимым свойствам
        public Brush Fill 
        {
            // Устанавливаем геттер и сеттер свойства 
            set { SetValue(FillProperty, value); }
            get { return (Brush)GetValue(FillProperty); }
        }

        public Pen Stroke
        {
            // Аналогично
            set { SetValue(StrokeProperty, value); }
            get { return (Pen)GetValue(StrokeProperty); }
        }

        // Статический конструктор 
        static BetterEllipse()
        {

            //  Регистрируем свойство зависимостей. Указываем в DependencyProperty.Register имя свойства, его тип,
            //  а также тип владельца и метаданные свойства. В нашем случае Fill И Stroke
            FillProperty =
                DependencyProperty.Register("Fill", typeof(Brush), typeof(BetterEllipse),
                    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

            StrokeProperty =
                DependencyProperty.Register("Stroke", typeof(Pen), typeof(BetterEllipse),
                    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure));
        }

        // Переопределение MeasureOverride. Его вызов всегда предшествует первому вызову OnRender 
        // Посредством переопределения класс пользовательского элемента объявляет свой желательный размер
        protected override Size MeasureOverride(Size sizeAvailable)
        {
            // Определяем и возвращаем размер 
            Size sizeDesired = base.MeasureOverride(sizeAvailable);

            if (Stroke != null)
                sizeDesired = new Size(Stroke.Thickness, Stroke.Thickness);

            return sizeDesired;     
        }

        // Переопределение OnRender. Вызывается, когда требуется обновить визуальное представление элемента
        protected override void OnRender(DrawingContext dc)
        {
            Size size = RenderSize;
            
            // Регулировка размера воспроизведения с учетом толщины Pen
            if (Stroke != null)
            {
                size.Width =  Math.Max(0, size.Width - Stroke.Thickness); // Регулировка ширины на значение Thickness
                size.Height = Math.Max(0, size.Height - Stroke.Thickness);// Регулировка высоты на значение Thickness
            }

            // Рисование эллипса с нашими конкретными Brush и Pen
            dc.DrawEllipse(Fill, Stroke,
                new Point(RenderSize.Width / 2, RenderSize.Height / 2), size.Width / 2, size.Height / 2);
        }
    }
    public class RenderTheBetterEllipse : Window
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application app = new Application();
            app.Run(new RenderTheBetterEllipse()); // Запуск
        }

        public RenderTheBetterEllipse()
        {
            Title = "Render the Better Ellipse";

            BetterEllipse elips = new BetterEllipse(); // Создаем экземпляр описанного выше класса
            elips.Fill = Brushes.AliceBlue; // Цвет заливки внутри эллипса
            // Изменение цвета контура эллипса, указывается начальный цвет, конечный цвет, начальные и конечные точки, толщина 
            elips.Stroke = new Pen( 
                new LinearGradientBrush(Colors.CadetBlue, Colors.Chocolate,
                    new Point(1, 0), new Point(0, 1)), 24); 
            Content = elips; 
        }

    }
}
