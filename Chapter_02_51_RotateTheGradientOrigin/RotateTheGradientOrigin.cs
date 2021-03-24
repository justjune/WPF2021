//--------------------------------------------------------
// RotateTheGradientOrigin.cs (c) 2006 by Charles Petzold
//--------------------------------------------------------
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Petzold.RotateTheGradientOrigin
{
    public class RotateTheGradientOrigin : Window // класс наследник от Window
    {
        RadialGradientBrush brush;
        double angle;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();    //новое приложение и запускаем его с созданием градиента
            app.Run(new RotateTheGradientOrigin());
        }
        public RotateTheGradientOrigin() //метод создающий крутящийся градиент
        {
            Title = "Rotate the Gradient Origin";
            WindowStartupLocation = WindowStartupLocation.CenterScreen; // задаем место появления окна и размер окна
            Width = 384;        // ie, 4 inches
            Height = 384;

            brush = new RadialGradientBrush(Colors.Pink, Colors.Blue); // задаем цвет градиентной кисти
            brush.Center = brush.GradientOrigin = new Point(0.5, 0.5); // задаем центр градиента
            brush.RadiusX = brush.RadiusY = 0.1; // радиус градиента
            brush.SpreadMethod = GradientSpreadMethod.Repeat; // вид градиента
            Background = brush; // на фоне тоже градиент

            DispatcherTimer tmr = new DispatcherTimer(); // создаем таймер который влияет на скорость кручения градиента
            tmr.Interval = TimeSpan.FromMilliseconds(10); // задаем интервал этого таймера
            tmr.Tick += TimerOnTick; // вызываем функцию TimerOnTick
            tmr.Start();
        }
        void TimerOnTick(object sender, EventArgs args)
        {
            Point pt = new Point(0.5 + 0.05 * Math.Cos(angle),
                                 0.5 + 0.05 * Math.Sin(angle));
            brush.GradientOrigin = pt;
            angle += Math.PI / 12;      // ie, 30 degrees
        }
    }
}
