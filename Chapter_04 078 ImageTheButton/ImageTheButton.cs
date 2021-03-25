/////////////////////////
//   Ярослав Бренчук   //
/////////////////////////

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace Chapter_04_078_ImageTheButton
{
    class ImageTheButton : Window
    {
        [STAThread]  //атрибут для исполнения одопоточной модели
        public static void Main()
        {
            Application app = new Application();    // создаем объект класса, инкапсулирующего функции WPF, относящиеся к приложению
            app.Run(new ImageTheButton());          // запускаем приложение WPF, передавая в качестве аргумента динамически выделенный объект окна  ImageTheButton, 
        }                                           // благодаря чему метод Run организует для него вызов метода Show

        public ImageTheButton() // создаем класс GrowAndShrink  ("макет" окна)
        {
            Title = "Image the button"; // заголовок
            Uri uri = new Uri(@"pack://application:,,,/test.jpg"); // место хранения фотографии 
            BitmapImage bitmap = new BitmapImage(uri);
            Image img = new Image();  // создание кортики 
            img.Source = bitmap; // присвоение картики картинки
            img.Stretch = Stretch.None; // сохранить исходный размер картинки

            Button btn = new Button(); // создание кнопки
            btn.Content = img; // присвоение картики кнопке 
            btn.HorizontalAlignment = HorizontalAlignment.Center;// Расположение кнопки
            btn.VerticalAlignment = VerticalAlignment.Center;// Расположение кнопки

            Content = btn;
        }
    }
}
