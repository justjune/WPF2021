using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Chapter_12_250_PaintOnCanvasClone
{
    class PaintOnCanvasClone : Window// создание класса PaintOnCanvasClone, наследника Window
    {
        [STAThread] // основной программный поток приложения использует однопотопную модель
        public static void Main() 
        { 
            Application app = new Application();
            app.Run(new PaintOnCanvasClone());
        }
        public PaintOnCanvasClone() 
        { 
            Title = "Paint on Canvas Clone"; // свойство Title определяет заголовок окна
            Canvas canv = new Canvas(); // Определяет область, внутри которой можно явным образом разместить дочерние элементы с помощью координат, относящихся к области Canvas.
            Content = canv; 
            SolidColorBrush[] brushes = 
                { 
                    Brushes.Red, 
                    Brushes.Green, 
                    Brushes.Blue 
                }; // Закрашивает область сплошным цветом.
            for (int i = 0; i < brushes.Length; i++)
            { 
                
                Rectangle rect = new Rectangle(); // Рисует прямоугольник.
                rect.Fill = brushes[i]; // Получает или задает структуру Brush, определяющую способ рисования внутренней области фигуры.(Унаследовано от Shape)
                rect.Width = 200; // Получение или установка ширины элемента.(Унаследовано от FrameworkElement)
                 rect.Height = 200; // Получает или задает предлагаемую высоту элемента.(Унаследовано от FrameworkElement)
                canv.Children.Add(rect); // добавление  в канвас 
                Canvas.SetLeft(rect, 100 * (i + 1)); // положение 
                Canvas.SetTop(rect, 100 * (i + 1)); // положение 
            }
        }
    }
}
