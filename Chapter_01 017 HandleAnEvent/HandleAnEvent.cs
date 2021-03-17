using System;
using System.Windows;
using System.Windows.Input;

namespace HAE 
{ class HandleAnEvent 
    {
        [STAThread]
        public static void Main()
        { 
            Application app = new Application(); // создание объекта Application, при к-ом запускается цикл сообщений с ожиданием ввода пользователя 
            Window win = new Window(); // создание объекта Window, к-ое пользователь увидит при запуске программы
            win.Title = "Handle An Event"; // заголовок окна Window
            win.MouseDown += WindowOnMouseDown; // MouseDown активируется при клике пользователя мышкой в области работы окна
            app.Run(win); // вызывает объект Window, с чего начинается работа программы, жизненный цикл к-ой проходит за время выполнения Run
        } 
        static void WindowOnMouseDown(object sender, MouseButtonEventArgs args) // обработчик для MouseDown, где аргумент - объект Window
        {
            Window win = sender as Window; // аргумент sender преобразуется в Window
            string strMessage = string.Format("Window clicked with  {0} button at point ({1})", args.ChangedButton, args.GetPosition(win)); // GetPosition использует Window и возвращает объект типа Point с координатами указателя мыши
            MessageBox.Show(strMessage, win.Title); // содержит 12 перегруженных методов Show, по умолчанию есть только кнопка "ОК", обработчик использует свойство Title у Window, используя его как заголовок окна сообщения
        }
    }
}