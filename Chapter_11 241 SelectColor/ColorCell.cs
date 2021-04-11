using System;
using System.Windows;
using System.Windows.Media;
namespace Petzold.SelectColor
{
    class ColorCell : FrameworkElement // класс ColorCell наследует от FrameworkElement
    {
        // Приватные поля
        static readonly Size sizeCell = new Size(20, 20); // создаем квадрат со стороной в 20 аппаратно-независимых единиц
        DrawingVisual visColor; // создаем визуальный объект, который можно использовать для отрисовки векторной графики на экране
        Brush brush; // определяем объект, который будет использоваться для заливки внутри фигуры
        // Зависимые свойства
        public static readonly DependencyProperty IsSelectedProperty;
        public static readonly DependencyProperty IsHighlightedProperty;
        static ColorCell()
        {
            // Регистрируем свойства зависимостей с указанием именён свойств, типов свойств, типа владельца 
            // и устанавливаем дополнительные настройки свойств(рендеринга).
            IsSelectedProperty =
                DependencyProperty.Register("IsSelected", typeof(bool),
                typeof(ColorCell), new FrameworkPropertyMetadata(false,
                FrameworkPropertyMetadataOptions.AffectsRender));
            IsHighlightedProperty =
                DependencyProperty.Register("IsHighlighted", typeof(bool),
                typeof(ColorCell), new FrameworkPropertyMetadata(false,
                FrameworkPropertyMetadataOptions.AffectsRender));
        }
        // Свойства
        public bool IsSelected
        {
            set { SetValue(IsSelectedProperty, value); } // сеттер для IsSelectedProperty
            get { return (bool)GetValue(IsSelectedProperty); } // геттер для IsSelectedProperty
        }
        public bool IsHighlighted
        {
            set { SetValue(IsHighlightedProperty, value); } // сеттер для IsHighlightedProperty
            get { return (bool)GetValue(IsHighlightedProperty); } // геттер для IsHighlightedProperty
        }
        public Brush Brush
        {
            get { return brush; }
        }
        // Конструктор получает аргумент Color
        public ColorCell(Color clr)
        {
            // Создание нового объекта DrawingVisual и его сохранение в поле
            visColor = new DrawingVisual();
            DrawingContext dc = visColor.RenderOpen();
            // Рисование прямоугольника заданного цвета 
            Rect rect = new Rect(new Point(0, 0), sizeCell); // свойство Rect задает относительное расположение и размеры прямоугольника
            rect.Inflate(-4, -4); // Inflate увеличивает или уменьшает прямоугольник по всем направлениям с использованием указанных значений ширины и высоты
            Pen pen = new Pen(SystemColors.ControlTextBrush, 1); // инициализирует новый экземпляр класса Pen указанными свойствами Color и Width.
            brush = new SolidColorBrush(clr); // SolidColorBrush(clr) закрашивает область сплошным цветом clr
            dc.DrawRectangle(brush, pen, rect); // применяем параметры
            dc.Close(); // закрываем dc и сбрасываем содержимое, после этого изменение dc становится невозможным
            // вызов AddVisualChild нужен для маршрутизации событий
            AddVisualChild(visColor);
            AddLogicalChild(visColor); // добавляем visColor в логическое дерево
        }

        // Переопределение защищенных свойств и методов для визуального дочернего объекта
        protected override int VisualChildrenCount
        {
            get
            {
                return 1;
            }
        }
        protected override Visual GetVisualChild(int index)
        {
            if (index > 0)
                throw new ArgumentOutOfRangeException("index"); // генерируем исключение
            return visColor;
        }

        // Переопределение защищенных методов определения размеров и воспроизведения элемента
        protected override Size MeasureOverride(Size sizeAvailable)
        {
            return sizeCell;
        }
        protected override void OnRender(DrawingContext dc)
        {
            Rect rect = new Rect(new Point(0, 0), RenderSize); // свойство Rect задает относительное расположение и размеры прямоугольника
            rect.Inflate(-1, -1); // Inflate увеличивает или уменьшает прямоугольник по всем направлениям с использованием указанных значений ширины и высоты
            Pen pen = new Pen(SystemColors.HighlightBrush, 1); // кисть, которая закрашивает фон выбранных элементов
            if (IsHighlighted)
                dc.DrawRectangle(SystemColors.ControlDarkBrush, pen, rect); //рисуем прямоугольник заданными Brush(тёмный цвет) и Pen
            else if (IsSelected)
                dc.DrawRectangle(SystemColors.ControlLightBrush, pen, rect); //рисуем прямоугольник заданными Brush(светлый цвет) и Pen
            else
                dc.DrawRectangle(Brushes.Transparent/*цвет сплошной заливки с шестнадцатеричным значением #00FFFFFF*/, null, rect); // рисуем прямоугольник заданными Brush и Pen
        }
    }
}



