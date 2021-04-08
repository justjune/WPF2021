/////////////////////////
//   Ярослав Бренчук   //
/////////////////////////

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Media;
using System.Windows.Documents;

namespace Chapter_08_161_SetFrontSizeProperty
{
    class SetFrontSizeProperty : Window // Класс SplitNine наследуется от Window
    {
        [STAThread] // Атрибут означающий, что основной программный поток приложения должен использовать однопточную модель. Это необходимо для взаимодействия с подсистемой COM.
        public static void Main()
        {
            Application app = new Application();
            app.Run(new SetFrontSizeProperty());
        }

        public SetFrontSizeProperty()
        {
            Title = "Set FrontSize Property"; // Устанавливаем заголовок окна
            SizeToContent = SizeToContent.WidthAndHeight;
            ResizeMode = ResizeMode.CanMinimize;
            FontSize = 16;
            double[] fntsizes = { 8, 16, 32 };

            //Создание панели Grid
            Grid grid = new Grid(); // Создаём объект класса Grid (таблицу)
            Content = grid; // Задаёт значение ContentControl класса Grid

            //Определение строк и столбцов
            for(int i=0; i< 2; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = GridLength.Auto; //размер автоматический 
                grid.RowDefinitions.Add(row); // Добавляем новую строку в таблицу
            }

            for(int i =0; i < fntsizes.Length; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                column.Width = GridLength.Auto; // размер автоматический 
                grid.ColumnDefinitions.Add(column); // Добавляем новый столбец в таблицу
            }

            // Создание 6 кнопко
            for(int i =0; i < fntsizes.Length; i++)
            {
                Button button = new Button(); // Создаём объект класса Button (кнопку)
                button.Content = new TextBlock(
                    new Run("Set window FontSize to " + fntsizes[i])); // Задаёт значение ContentControl класса Button
                button.Tag = fntsizes[i];
                button.HorizontalAlignment = HorizontalAlignment.Center; // Получение или установка характеристик выравнивания по горизонтали, применяемых к этому элементу при его размещении в родительском элементе управления, например в панели или элементе управления элементами.(Унаследовано от FrameworkElement)
                button.VerticalAlignment = VerticalAlignment.Center; //Получает или задает характеристики выравнивания по вертикали, применяемые к этому элементу при его размещении в родительском элементе, например в панели или элементе управления элементами.(Унаследовано от FrameworkElement)
                button.Click += WindowFontSizeOnClick; // действие кнопки 
                grid.Children.Add(button); // Добавление элементов управления на панель Grid
                Grid.SetRow(button, 0); // Задаём строку для отображения элемента
                Grid.SetColumn(button, i); // Задаём столбец для отображения элемента

                button = new Button(); // Создаём объект класса Button (кнопку)
                button.Content = new TextBlock(
                    new Run("Set window FontSize to " + fntsizes[i])); // Задаёт значение ContentControl класса Button
                button.Tag = fntsizes[i]; // Получение или установка произвольного значения объекта, которое может использоваться для хранения особых сведений об этом элементе.(Унаследовано от FrameworkElement)
                button.HorizontalAlignment = HorizontalAlignment.Center; // Получение или установка характеристик выравнивания по горизонтали, применяемых к этому элементу при его размещении в родительском элементе управления, например в панели или элементе управления элементами.(Унаследовано от FrameworkElement)
                button.VerticalAlignment = VerticalAlignment.Center; // Получает или задает характеристики выравнивания по вертикали, применяемые к этому элементу при его размещении в родительском элементе, например в панели или элементе управления элементами.(Унаследовано от FrameworkElement)
                button.Click += ButtonFontSizeOnClick; // действие кнопки 
                grid.Children.Add(button); // Добавление элементов управления на панель Grid
                Grid.SetRow(button, 1); // Задаём строку для отображения элемента
                Grid.SetColumn(button, i); // Задаём столбец для отображения элемента

            }
        }

        private void ButtonFontSizeOnClick(object sender, RoutedEventArgs e)
        {
            Button button = e.Source as Button;
            FontSize = (double)button.Tag; // установление размера кнопки 
        }

        private void WindowFontSizeOnClick(object sender, RoutedEventArgs e)
        {
            Button button = e.Source as Button;
            FontSize = (double)button.Tag; // установление размера кнопки 
        }
    }
}
