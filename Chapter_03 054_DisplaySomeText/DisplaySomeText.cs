using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.DisplaySomeText
{
    class DisplaySomeText : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new DisplaySomeText());
        }

        public DisplaySomeText() // метод выводящий в окно какой то контент(строка в данном случае)
        {
            Title = "Display Some Text";
            Content = "Content can be simple text!";
        }
    }
}