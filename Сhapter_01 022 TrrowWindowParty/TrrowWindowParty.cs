using System;
using System.Windows;
using System.Windows.Input;

namespace Petzold.ThrowWindowParty
{
    class ThrowWindowParty : Application // обьявление класса ThrowWindowParty наследника от Application
    {
        [STAThread]  // работа в одном потоке
        public static void Main()
        {
            ThrowWindowParty app = new ThrowWindowParty(); // создаем приложение
            app.Run(); // запускаем приложение
        }
        protected override void OnStartup(StartupEventArgs args) // переопределяем метод Application.OnStartup() для нашего класса ThrowWindowParty
        {
            Window winMain = new Window(); // создаем окно
            winMain.Title = "Main Window"; // называем это окно
            winMain.MouseDown += WindowOnMouseDown; // при нажатии на мышь вызываем функцию WindowOnMouseDown
            winMain.Show(); // показываем это окно
            for (int i = 0; i < 2; i++) // запускаем еще 2 дополнительных окна
            {
                Window win = new Window();
                win.Title = "Extra Window No. " + (i + 1);
                win.Show();
            }
        }
        void WindowOnMouseDown(object sender, MouseButtonEventArgs args) // при нажатии на мышь вызываем еще одно окно с которого нельзя переключиться без закрытия
        {
            Window win = new Window();
            win.Title = "Modal Dialog Box";
            win.ShowDialog();
        }
    }
}
