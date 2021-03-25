/////////////////////////
//   Ярослав Бренчук   //
/////////////////////////

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace Chapter_03_061_ShowMyFace
{
    class ShowMyFace : Window    // класс ShowMyFace наследник класса Window, содержащий точку входа в программу
    {
        [STAThread] // основной программный поток приложения использует однопоточную модель
        public static void Main()
        {
            Application app = new Application(); // создаем объект класса, инкапсулирующего функции WPF, относящиеся к приложению
            app.Run(new ShowMyFace()); // запускаем приложение WPF, передавая в качестве аргумента динамически выделенный объект окна ShowMyFace,
                                       // благодаря чему метод Run организует для него вызов метода Show
        }

        public ShowMyFace() // создаем класс GrowAndShrink  ("макет" окна)
        {
            Title = "Show My Face"; // заголовок
            Uri uri = new Uri(@"pack://application:,,,/test.jpg"); // место хранения фотографии 
            BitmapImage bitmap = new BitmapImage(uri); // Инициализирует новый экземпляр класса BitmapImage
            Image img = new Image();  // создание кортики 
            img.Source = bitmap; // присвоение картики картинки

            Content = img;
        }
    }
}
