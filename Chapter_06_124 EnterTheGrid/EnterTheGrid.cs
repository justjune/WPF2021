using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
//Программа создает две панели Grid как дочерние обьекты для StackPanel. Первая панель Grid состоит из 2 столбцов и 5 строк для надписей
//и элементов TextBox(Предоставляет элемент управления "текстовое поле" Windows), а вторая из одной строки и 2 столбцов для кнопок Ok и Cancel

namespace Petzold.EnterTheGrid
{
    public class EnterTheGrid : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new EnterTheGrid());
        }
        public EnterTheGrid()
        {
            Title = "Enter the Grid";
            MinWidth = 300;
            SizeToContent = SizeToContent.WidthAndHeight;

            // Создание обьекта StackPanel(Занимает полную ширину окна. Он располагает все элементы в ряд либо по горизонтали, либо по вертикали в зависимости от ориентации.)
            // для содержимого окна.
            StackPanel stack = new StackPanel();
            Content = stack;

            // Создаем Grid(реализуется вешка разбивки, отображает дочерние элементы в виде набора ячеек, упорядоченных по строкам и столбцам) и добавляем его в StackPanel.
            Grid grid1 = new Grid();
            grid1.Margin = new Thickness(5);
            stack.Children.Add(grid1);

            // Создание определений строк.
            for (int i = 0; i < 5; i++)
            {
                RowDefinition rowdef = new RowDefinition();
                rowdef.Height = GridLength.Auto;
                grid1.RowDefinitions.Add(rowdef);
            }

            // Создание определений столбцов.
            ColumnDefinition coldef = new ColumnDefinition();
            coldef.Width = GridLength.Auto;
            grid1.ColumnDefinitions.Add(coldef);

            coldef = new ColumnDefinition();
            coldef.Width = new GridLength(100, GridUnitType.Star);
            grid1.ColumnDefinitions.Add(coldef);

            // Создание надписей и текстовых полей.
            string[] strLabels = { "_First name:", "_Last name:",
                                   "_Social security number:",
                                   "_Credit card number:",
                                   "_Other personal stuff:" };

            for (int i = 0; i < strLabels.Length; i++)
            {
                Label lbl = new Label();
                lbl.Content = strLabels[i];
                lbl.VerticalContentAlignment = VerticalAlignment.Center;
                grid1.Children.Add(lbl);
                Grid.SetRow(lbl, i);
                Grid.SetColumn(lbl, 0);

                TextBox txtbox = new TextBox(); //При увеличении ширины окна, элементы TextBox автоматически расширяются
                txtbox.Margin = new Thickness(5);
                grid1.Children.Add(txtbox);
                Grid.SetRow(txtbox, i);
                Grid.SetColumn(txtbox, 1);
            }

            // Создаем второй Grid и добавляем его в StackPanel.
            Grid grid2 = new Grid();
            grid2.Margin = new Thickness(10);
            stack.Children.Add(grid2);

            // Для одной строки создавать определение не обязательно.
            // В дефолтном определении строк стоит режим "star"(Готовый для повторного использования объект GridLength типа GridUnitType.Star со значением 1).
            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            grid2.ColumnDefinitions.Add(new ColumnDefinition());

            // Создаем кнопки.
            Button btn = new Button();
            btn.Content = "Submit";
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.IsDefault = true;
            btn.Click += delegate { Close(); };
            grid2.Children.Add(btn);    // Строка и столбец 0.

            btn = new Button();
            btn.Content = "Cancel";
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.IsCancel = true;
            btn.Click += delegate { Close(); };
            grid2.Children.Add(btn);
            Grid.SetColumn(btn, 1);     // Строка 0.

            // Передача фокуса первому текстовому полю.
            (stack.Children[0] as Panel).Children[1].Focus();
        }
    }
}
