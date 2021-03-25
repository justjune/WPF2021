using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chapter_05_106_DesignAButton
{
    public class DesignAButton: Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new DesignAButton());
        }
        public DesignAButton()
        {
            Title = "Desing a Button";

            //Cоздание объекта Button как содержимого окна
            Button btn = new Button();
            btn.HorizontalAlignment = HorizontalAlignment.Stretch;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.Click += ButtonOnClick;
            Content = btn;

            //Создание обьекта StackPanel как содержимого Button
            StackPanel stack = new StackPanel();
            btn.Content = stack;

            //Добавление обьекта Polyline k StackPanel
            stack.Children.Add(ZigZag(10));

            //Добавление обьекта Image
            Uri uri = new Uri((@"pack://application:,,,/test.jpg"));
            BitmapImage bitmap = new BitmapImage(uri);
            Image img = new Image();
            img.Margin = new Thickness(0, 10, 0, 0);
            img.Source = bitmap;
            img.Stretch = Stretch.None;
            stack.Children.Add(img);

            // Добавление объекта Label
            Label lbl = new Label();
            lbl.Content = "_Read books!";
            lbl.HorizontalContentAlignment = HorizontalAlignment.Center;
            stack.Children.Add(lbl);

            // Добавление обьекта Polyline 
            stack.Children.Add(ZigZag(0));
        }

        Polyline ZigZag(int offset)
        {
            Polyline poly = new Polyline();
            poly.Stroke = SystemColors.ControlTextBrush;
            poly.Points = new PointCollection();
            for (int x = 0; x <= 1000; x += 10)
                poly.Points.Add(new Point(x, (x + offset) % 20));
            return poly;
        }

        void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            MessageBox.Show("The button has been clicked", Title);
        }
    }
}
