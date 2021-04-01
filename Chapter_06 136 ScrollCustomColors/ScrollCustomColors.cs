using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Brigada
{
    class ScrollCustomColors : Window
    {
        ScrollBar[] scrolls = new ScrollBar[3]; // Полосы прокрутки
        TextBlock[] txtValue = new TextBlock[3]; // Текстовая информация

        Panel pnlColor; // Необхоим для размещения дочерних элементов, использутеся чуть позже

        [STAThread] 
        public static void Main(string[] args) // Запуск
        {
            Application app = new Application();
            app.Run(new ScrollCustomColors());
        }

        public ScrollCustomColors()
        {
            // Титульник, ширина, высота
            Title = "Color Scroll";
            Width = 500;
            Height = 300;

            // Панель gridMain содержит вертикальную вешку разбивки
            Grid gridMain = new Grid();
            Content = gridMain;

            // Определения столбцов gridMain
            ColumnDefinition coldef = new ColumnDefinition();
            coldef.Width = new GridLength(200, GridUnitType.Pixel); // Задание ширины 
            gridMain.ColumnDefinitions.Add(coldef); // Добавление к коллекции таких обеъектов. Далее аналогично

            coldef = new ColumnDefinition();
            coldef.Width = GridLength.Auto;
            gridMain.ColumnDefinitions.Add(coldef);

            coldef = new ColumnDefinition();
            coldef.Width = new GridLength(100, GridUnitType.Star);
            gridMain.ColumnDefinitions.Add(coldef);

            // Вертикальная вешка разбивки 
            GridSplitter split = new GridSplitter();
            split.HorizontalAlignment = HorizontalAlignment.Center;
            split.VerticalAlignment = VerticalAlignment.Stretch;
            split.Width = 6;
            gridMain.Children.Add(split);
            Grid.SetRow(split, 0);
            Grid.SetColumn(split, 1);

            // Отображение цвета фона от вешки справа 
            pnlColor = new StackPanel();
            pnlColor.Background = new SolidColorBrush(SystemColors.WindowColor); // "Сплошная" кисть
            gridMain.Children.Add(pnlColor);  // Добавление в колекцию дочерних элементов
            Grid.SetRow(pnlColor, 0); // Отображение
            Grid.SetColumn(pnlColor, 2);

            // Вторичная панель Grid слева от вешки
            Grid grid = new Grid(); // 6 надписей и 3 полосы прокрутки 
            gridMain.Children.Add(grid); // Добавление в колекцию дочерних элементов
            Grid.SetRow(grid, 0); // Отображение
            Grid.SetColumn(grid, 0);

            // Три строки: надпись, полоса прокрутки и надпись. Аналогичный код уже был прокомментирован
            RowDefinition rowdef = new RowDefinition();
            rowdef.Height = GridLength.Auto;
            grid.RowDefinitions.Add(rowdef);

            rowdef = new RowDefinition();
            rowdef.Height = new GridLength(100, GridUnitType.Star);
            grid.RowDefinitions.Add(rowdef);

            rowdef = new RowDefinition();
            rowdef.Height = GridLength.Auto;
            grid.RowDefinitions.Add(rowdef);

            // 3 столбца для красной, зеленой и синей составляющих
            for (int i = 0; i < 3; ++i)
            {
                // Хотим, чтобы каждая полоса прокрутки занимала треть grid
                coldef = new ColumnDefinition();
                coldef.Width = new GridLength(33, GridUnitType.Star);
                grid.ColumnDefinitions.Add(coldef);
            }

            for (int i = 0; i < 3; ++i)
            {
                // Размещение надписей для полос прокуртки
                Label lbl = new Label();
                lbl.Content = new string[] { "Red", "Green", "Blue" }[i];
                lbl.HorizontalContentAlignment = HorizontalAlignment.Center;
                grid.Children.Add(lbl);

                Grid.SetRow(lbl, 0);
                Grid.SetColumn(lbl, i);

                scrolls[i] = new ScrollBar();
                scrolls[i].Focusable = true; // Определение возможности получение фокуса элементом
                scrolls[i].Orientation = Orientation.Vertical; // Вертикальная ориентация. 
                scrolls[i].Minimum = 0; // Минимальное значение
                scrolls[i].Maximum = 255; // Максимальное значение 
                scrolls[i].SmallChange = 1; // Изменение величины при нажатии на стрелочку прокрутки
                scrolls[i].LargeChange = 1; // Изменение величины при нажатии на саму полосу прокрутки  
                scrolls[i].ValueChanged += ScrollOnValueChanged; // Выполняется при измении значений в диапазоне
                grid.Children.Add(scrolls[i]); 
                Grid.SetRow(scrolls[i], 1);
                Grid.SetColumn(scrolls[i], i);

                txtValue[i] = new TextBlock(); // Размещение текста. Не допускаем наложения друг на друга
                txtValue[i].TextAlignment = TextAlignment.Center;
                txtValue[i].HorizontalAlignment = HorizontalAlignment.Center;
                txtValue[i].Margin = new Thickness(5);
                grid.Children.Add(txtValue[i]);
                Grid.SetRow(txtValue[i], 2);
                Grid.SetColumn(txtValue[i], i);
            }

            // Необходимо для отображения значений цвета, иначе отобразиться только при прокрутке
            Color clr = (pnlColor.Background as SolidColorBrush).Color;
            scrolls[0].Value = clr.R;
            scrolls[1].Value = clr.G;
            scrolls[2].Value = clr.B;

            //Передаём фокус
            scrolls[0].Focus();
        }

        void ScrollOnValueChanged(object sender, RoutedEventArgs args)
        {
            // Обновление объекта TextBlock, который связан со скролом, у которого меняется значение.
            // И вычисление цвета
            ScrollBar scroll = sender as ScrollBar;
            Panel pnl = scroll.Parent as Panel;
            TextBlock txt = pnl.Children[1 +
                pnl.Children.IndexOf(scroll)] as TextBlock;

            txt.Text = String.Format("{0}\n0x{0:X2}", (int)scroll.Value);
            pnlColor.Background = new SolidColorBrush(Color.FromRgb((byte)scrolls[0].Value, (byte)scrolls[1].Value, (byte)scrolls[2].Value));
        }
    }
}
