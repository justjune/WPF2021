using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CTB

{
    public class ClickTheButton : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ClickTheButton());
        }

        public ClickTheButton() // Button - кнопка, прародитель элементов управления в WPF
        {
            Title = "Click the Button";
            Button btn = new Button(); // класс Button обладает свойством Content и событием Click, срабатывающим при нажатии кнопки пользователем
            btn.Content = "_Click me, please!";
            /* 
               1) свойство Content объекта Button задает текстовую строку;
               2) нижний пробел в начале строки используется для ускоренного вызова,
               здесь он требуется для расширения возможностей управления диалоговыми окнами с помощью клавиатуры
            */
            btn.Click += ButtonOnClick; // Click - обработчик события
            Content = btn; // объект Button задается свойством Content объекта Window 
        }

        void ButtonOnClick(object sender, RoutedEventArgs args)
        { // показывает окно сообщения в ответ на клик или нажатие клавиши
            MessageBox.Show("The button has been clicked and all is well.", Title);
        }
    }
}