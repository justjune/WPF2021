//--------------------------------------------------
// SplitNine.cs (c) 2006 by Charles Petzold
//--------------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.SplitNine
{
    public class SplitNine : Window // Класс SplitNine наследуется от Window
    {
        [STAThread] // Атрибут означающий, что основной программный поток приложения должен использовать однопточную модель. Это необходимо для взаимодействия с подсистемой COM.
        public static void Main()
        {
            Application app = new Application(); 
            app.Run(new SplitNine());
        }
        public SplitNine()
        {
            Title = "Split Nine"; // Устанавливаем заголовок окна

            Grid grid = new Grid(); // Создаём объект класса Grid (таблицу)
            Content = grid; // Задаёт значение ContentControl класса Grid

            // Set row and column definitions.
            for (int i = 0; i < 3; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition()); // Добавляем новый столбец в таблицу
                grid.RowDefinitions.Add(new RowDefinition()); // Добавляем новую строку в таблицу
            }

            // Create 9 buttons.
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                {
                    Button btn = new Button(); // Создаём объект класса Button (кнопку)
                    btn.Content = "Row " + y + " and Column " + x; // Задаёт значение ContentControl класса Button
                    grid.Children.Add(btn); // Добавление элементов управления на панель Grid
                    Grid.SetRow(btn, y); // Задаём строку для отображения элемента
                    Grid.SetColumn(btn, x); // Задаём столбец для отображения элемента
                }

            // Create splitter.
            GridSplitter split = new GridSplitter(); // Создаём объект класса GridSplitter
            split.Width = 6; // Задаём ширину
            grid.Children.Add(split); // Добавление элементов управления на панель GridSplitter
            Grid.SetRow(split, 1); // Задаём строку для отображения элемента
            Grid.SetColumn(split, 1); // Задаём столбец для отображения элемента
        }
    }
}