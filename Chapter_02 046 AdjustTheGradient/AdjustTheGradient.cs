using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_02_046_AdjustTheGradient
{
    class AdjustTheGradient : Window // Наследование от класса "Window" для облегчения использования метово "Window"
    {
        private LinearGradientBrush brush; // Поле Градиентной кисти
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new AdjustTheGradient());
        }

        public AdjustTheGradient()
        {
            Title = "Adjust The Gradient"; // Присваивание заголовку текста
            SizeChanged += WindowOnSizeChanged; // Обработчик событий, срабатывающий при каждом изменении размеров окна

            brush = new LinearGradientBrush(Colors.Red, Colors.Blue, 0); // Присваивание полю brush, горизонтального градиента от Красного к Черному
            brush.MappingMode = BrushMappingMode.Absolute; // Абсолютный режим отображения
            Background = brush; // Присваивание заднему фону цвет кисти
        }

        void WindowOnSizeChanged(object sender, SizeChangedEventArgs args)
        {
            double width = ActualWidth 
                - 2 * SystemParameters.ResizeFrameVerticalBorderWidth; // Вычисление ширины и высоты клиентской области
            double height = ActualHeight 
                - 2 * SystemParameters.ResizeFrameHorizontalBorderHeight 
                - SystemParameters.CaptionHeight; 

            Point ptCenter = new Point(width / 2, height / 2); //Расчет центра
            Vector vectDiag = new Vector(width, -height); // Расчет Вектора диагонали
            Vector vectPerp = new Vector(vectDiag.Y, -vectDiag.X); // Расчет Вектора  Нормали к диагонали

            vectPerp.Normalize(); // Нормирование вектора
            vectPerp *= width * height / vectDiag.Length; // Умножаем вектор на длину диагонали 
            brush.StartPoint = ptCenter + vectPerp; // Начало градиента
            brush.EndPoint = ptCenter - vectPerp; // Конец градиента
        }
    }
}
