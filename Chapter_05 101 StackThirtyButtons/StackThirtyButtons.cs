using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.StackThirtyButtons
{
    class StackThirtyButtons : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new StackThirtyButtons());
        }
        public StackThirtyButtons()
        {
            Title = "Stack Thirty Buttons";
            SizeToContent = SizeToContent.WidthAndHeight; // задаем размер окна по размеру контента в нем
            ResizeMode = ResizeMode.CanMinimize; // убираем кнопку которая разворачивает окно по размеру дисплея
            AddHandler(Button.ClickEvent, new RoutedEventHandler(ButtonOnClick)); //при нажатии на кнопку вызываем ф-ию ButtonOnClick

            StackPanel stackMain = new StackPanel(); // объединяем кнопки в группы, задаем им ориентацию и отступы вокруг
            stackMain.Orientation = Orientation.Horizontal;
            stackMain.Margin = new Thickness(5);
            Content = stackMain;

            for (int i = 0; i < 3; i++)    // объединяем кнопки в группы по 3
            {
                StackPanel stackChild = new StackPanel();
                stackMain.Children.Add(stackChild);

                for (int j = 0; j < 10; j++)
                {
                    Button btn = new Button(); // создаем кнопки, задаем отступ и надпись в них
                    btn.Content = "Button No. " + (10 * i + j + 1);
                    btn.Margin = new Thickness(5);
                    stackChild.Children.Add(btn);
                }
            }
        }
        void ButtonOnClick(object sender, RoutedEventArgs args) // при нажатии на кнопку выводим в новом окне текст
        {
            MessageBox.Show("You clicked the button labeled " +
                            (args.Source as Button).Content);
        }
    }
}