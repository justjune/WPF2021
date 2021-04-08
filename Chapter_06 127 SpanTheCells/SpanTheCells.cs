/////////////////////////
//   Ярослав Бренчук   //
/////////////////////////

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Chapter_06_127_SpanTheCells
{
    class SpanTheCells : Window // создание класса SpanTheCells, наследника Window
    {
        [STAThread] // основной программный поток приложения использует однопотопную модель
        public static void Main()
        {
            Application app = new Application();
            app.Run(new SpanTheCells());
        }

        public SpanTheCells()
        {
            Title = "Span the Cells"; // свойство Title определяет заголовок окна
            SizeToContent = SizeToContent.WidthAndHeight; //Возвращает или задает значение, указывающее, изменится ли автоматически размер окна в соответствии с размером его содержимого.

            // Создание объекта Grid
            Grid grid = new Grid(); // создание разметки
            grid.Margin = new Thickness(5); // поделить окно на 5 частей
            Content = grid;

            // Создание определений строк
            for (int i = 0; i < 6; ++i)
            {
                RowDefinition rowdef = new RowDefinition(); // Определяет специфические для строки свойства, применимые к элементам Grid.
                rowdef.Height = GridLength.Auto; //Получает вычисляемую высоту элемента RowDefinition или задает значение GridLength строки, которая определяется RowDefinition.
                grid.RowDefinitions.Add(rowdef);
            }

            // Создание определений столбцов 
            for (int i = 0; i < 4; ++i)
            {
                ColumnDefinition coldef = new ColumnDefinition(); // Определяет свойства столбца, которые применяются к элементам Grid.
                if (i == 1)
                    coldef.Width = new GridLength(100, GridUnitType.Star); // Получает вычисляемую ширину элемента ColumnDefinition или задает значение GridLength столбца, которое определяется ColumnDefinition.
                else
                    coldef.Width = GridLength.Auto; //Представляет длину элементов, которые явным образом поддерживают типы единиц Star.
                grid.ColumnDefinitions.Add(coldef); // Определяет свойства столбца, которые применяются к элементам Grid.
            }

            // Создание надписей и текстовых полей 
            string[] astrLaber = {"_First name:", "_Last name:",
                                  "_Social securitu namber:",
                                  "_Credit card nubmer:",
                                  "_Other personal stuff:"};
            for (int i = 0; i < astrLaber.Length; ++i)
            {
                Label ldl = new Label(); // Представляет текстовую подпись для элемента управления и обеспечивает поддержку клавиш доступа.
                ldl.Content = astrLaber[i]; // Получает или задает содержимое объекта ContentControl.(Унаследовано от ContentControl)
                ldl.VerticalContentAlignment = VerticalAlignment.Center; // Возвращает или задает способ вертикального выравнивания содержимого элемента управления.(Унаследовано от Control)
                grid.Children.Add(ldl); // добавление в родителя 
                Grid.SetRow(ldl, i); // расположение 
                Grid.SetColumn(ldl, 0);// расположение по левой стороне 

                TextBox textBox = new TextBox(); // Представляет элемент управления, который может быть использован для отображения или редактирования неформатированного текста.
                textBox.Margin = new Thickness(5); // Получает или задает значение внешнего поля элемента.(Унаследовано от FrameworkElement)
                grid.Children.Add(textBox); // добавление в grid 
                Grid.SetRow(textBox, i); // расположение 
                Grid.SetColumn(textBox, 1); // расположение 
                Grid.SetColumn(textBox, 3); // расположение 
            }

            //Создание кнопок
            Button btn = new Button(); // Представляет элемент управления "Кнопка Windows", который будет реагировать на событие Click.
            btn.Content = "Submit"; // Получает или задает содержимое объекта ContentControl.(Унаследовано от ContentControl)
            btn.Margin = new Thickness(5); // Получает или задает значение внешнего поля элемента.(Унаследовано от FrameworkElement)
            btn.Click += delegate { Close(); }; // действие при нажатии 
            grid.Children.Add(btn); // добавление в grid
            Grid.SetRow(btn, 5); // расположение кнопки 
            Grid.SetColumn(btn, 2); // расположение кнопки 

            btn = new Button(); // Представляет элемент управления "Кнопка Windows", который будет реагировать на событие Click.
            btn.Content = "Cancel"; // Получает или задает содержимое объекта ContentControl.(Унаследовано от ContentControl)
            btn.Margin = new Thickness(5); // Получает или задает значение внешнего поля элемента.(Унаследовано от FrameworkElement)
            btn.Click += delegate { Close(); }; // действие при нажатии
            grid.Children.Add(btn); // добавление в grid
            Grid.SetRow(btn, 5); // расположение кнопки 
            Grid.SetColumn(btn, 3); // расположение кнопки 

            //Передача фокуса первому текстовому полю
            grid.Children[1].Focus();

        }
    }
}
