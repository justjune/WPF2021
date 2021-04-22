using Chapter_13_295_SelectColorFromWheel; // подключение пространства имён из одного из прошлых проектов из главы 13
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Chapter_19_494_UseCustomClass
{
    public partial class UseCustomClass : Window  // новый класс производный от Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new UseCustomClass());
        }
        public UseCustomClass()  // конструктор класса 
        {
            InitializeComponent(); // метод задающий поля для различных элементов 
        }

        void ColorGridBoxOnSelectionChanged(object sender, SelectionChangedEventArgs args) // содержит обработчик событий для элемента ColorWheel
        {
            ColorWheel clrbox = args.Source as ColorWheel;
            Background = (Brush)clrbox.SelectedValue;
        }
    }
}