using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Chapter_06_127_SpanTheCells
{
    class SpanTheCells: Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new SpanTheCells());
        }

        public SpanTheCells()
        {
            Title = "Span the Cells";
            SizeToContent = SizeToContent.WidthAndHeight;

            // Создание обьекта Grid
            Grid grid = new Grid();
            grid.Margin = new Thickness(5);
            Content = grid;

            // Создание определений строк
            for(int i=0; i< 6; ++i)
            {
                RowDefinition rowdef = new RowDefinition();
                rowdef.Height = GridLength.Auto;
                grid.RowDefinitions.Add(rowdef);
            }

            // Создание определений столбцов 
            for(int i=0; i < 4; ++i)
            {
                ColumnDefinition coldef = new ColumnDefinition();
                if (i == 1)
                    coldef.Width = new GridLength(100, GridUnitType.Star);
                else
                    coldef.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(coldef);
            }

            // Создание надписей и текстовых полей 
            string[] astrLaber = {"_First name:", "_Last name:",
                                  "_Social securitu namber:",
                                  "_Credit card nubmer:",
                                  "_Other personal stuff:"};
            for(int i = 0; i < astrLaber.Length; ++i)
            {
                Label ldl = new Label();
                ldl.Content = astrLaber[i];
                ldl.VerticalContentAlignment = VerticalAlignment.Center;
                grid.Children.Add(ldl);
                Grid.SetRow(ldl, i);
                Grid.SetColumn(ldl, 0);

                TextBox textBox = new TextBox();
                textBox.Margin = new Thickness(5);
                grid.Children.Add(textBox);
                Grid.SetRow(textBox, i);
                Grid.SetColumn(textBox, 1);
                Grid.SetColumn(textBox, 3);
            }

            //Создание кнопок
            Button btn = new Button();
            btn.Content = "Submit";
            btn.Margin = new Thickness(5);
            btn.Click += delegate { Close(); };
            grid.Children.Add(btn);
            Grid.SetRow(btn, 5);
            Grid.SetColumn(btn, 2);

            btn = new Button();
            btn.Content = "Cancel";
            btn.Margin = new Thickness(5);
            btn.Click += delegate { Close(); };
            grid.Children.Add(btn);
            Grid.SetRow(btn, 5);
            Grid.SetColumn(btn, 3);

            //Передача фокуса первому текстовому полю
            grid.Children[1].Focus();

        }
    }
}
