using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.DockAroundTheBlock
{
    class DockAroundTheBlock : Window // создание класса DockAroundTheBlock, наследника Window
    {
        [STAThread] // атрибут, который показывает, что управление программой осуществляется одним главным потоком.
        public static void Main() // точка входа выполняемой программы
        {
            Application app = new Application(); // создание нового приложения
            app.Run(new DockAroundTheBlock()); // обработка и отправка сообщений между приложением и операционной системой
        }
        public DockAroundTheBlock()
        {
            Title = "Dock Around the Block"; // заголовок окна
            DockPanel dock = new DockPanel(); // создаём пристыкованную панель
            Content = dock; // задаёт границы элемента управления

            for (int i = 0; i < 17; i++) // всего 17 дочерних кнопок
            {
                Button btn = new Button(); // создание новой границы
                btn.Content = "Button No. " + (i + 1);
                dock.Children.Add(btn); // добавление дочерних элементов
                btn.SetValue(DockPanel.DockProperty, (Dock)(i % 4)); // последовательно присваивает каждой кнопке значения из перечисления Dock:
                                                                     // Dock.Left, Dock.Top, Dock.Right и Dock.Bottom (числовые коды 0, 1, 2 и 3)
            }
        }
    }
}
