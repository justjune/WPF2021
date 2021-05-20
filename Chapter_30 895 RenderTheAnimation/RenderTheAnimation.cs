using System;
using System.Windows;
namespace Petzold.RenderTheAnimation
{
    class RenderTheAnimation : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();// создаем объект класса, инкапсулирующего функции WPF, относящиеся к приложению
            app.Run(new RenderTheAnimation());  // запускаем приложение WPF, передавая в качестве аргумента динамически выделенный объект окна RenderTheAnimation, 
                                                // благодаря чему метод Run организует для него вызов метода Show
        }
        public RenderTheAnimation()
        {
            Title = "Render the Animation"; // заголовок окна 
            Content = new AnimatedCircle(); // содержимое окна берём из AnimatedCircle.cs 
        }
    }
}
