using System;
using System.Windows;
using System.Windows.Controls;

namespace SimpleBrowser
{
    class ABrowser
    {
        [STAThread]
        public static void Main()
        {
            Window w = new Window();
            Frame f = new Frame();
            f.Source = new Uri("http://ya.ru");
            w.Content = f;
            w.Show();
            Application a = new Application();
            a.MainWindow = w;
            a.Run();

        }
    }
}