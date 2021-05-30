using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Petzold.CreateFullColorBitmap
{
    public class CreateFullColorBitmap : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new CreateFullColorBitmap());
        }
        public CreateFullColorBitmap()
        {
            Title = "Create Full-Color Bitmap";

            //Создание битовый массив растрового изображения
            int[] array = new int[256 * 256];

            for (int x = 0; x < 256; x++)
                for (int y = 0; y < 256; y++)
                {
                    int b = x;
                    int g = 0;
                    int r = y;

                    array[256 * y + x] = b | (g << 8) | (r << 16);
                }

            //Создание растрового изображения
            BitmapSource bitmap =
                BitmapSource.Create(256, 256, 96, 96, PixelFormats.Bgr32,
                                    null, array, 256 * 4);

            //Создание объекта Image и установка его атрибута Source равным растровому изображению
            Image img = new Image();
            img.Source = bitmap;

            //Картинка становится контентом окна
            Content = img;
        }
    }
}
