/////////////////////////
//   Ярослав Бренчук   //
/////////////////////////

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chapter_05_106_DesignAButton
{
    public class DesignAButton: Window // создание класса DesignAButton, наследника Window
    {
        [STAThread]// основной программный поток приложения использует однопотопную модель
        public static void Main()
        {
            Application app = new Application();
            app.Run(new DesignAButton());
        }
        public DesignAButton()
        {
            Title = "Desing a Button";// свойство Title определяет заголовок окна

            //Создание объекта Button как содержимого окна
            Button btn = new Button(); // Представляет элемент управления "Кнопка Windows", который будет реагировать на событие Click.
            btn.HorizontalAlignment = HorizontalAlignment.Stretch; // Получение или установка характеристик выравнивания по горизонтали, применяемых к этому элементу при его размещении в родительском элементе управления, например в панели или элементе управления элементами.
            btn.VerticalAlignment = VerticalAlignment.Center; // Получает или задает характеристики выравнивания по вертикали, применяемые к этому элементу при его размещении в родительском элементе, например в панели или элементе управления элементами.
            btn.Click += ButtonOnClick; // Происходит при нажатии элемента управления Button.
            Content = btn; // Представляет элемент управления с отдельным содержимым любого типа.

            //Создание обьекта StackPanel как содержимого Button
            StackPanel stack = new StackPanel(); // Выравнивает дочерние элементы в одну линию, ориентированную горизонтально или вертикально. Объект StackPanel содержит коллекцию UIElement объектов, которые находятся в Children свойстве.
            btn.Content = stack;

            //Добавление обьекта Polyline k StackPanel
            stack.Children.Add(ZigZag(10));

            //Добавление обьекта Image
            Uri uri = new Uri((@"pack://application:,,,/test.jpg")); // получение ссылки на объект 
            BitmapImage bitmap = new BitmapImage(uri); //Инициализирует новый экземпляр BitmapImage, используя предоставленный Uri.
            Image img = new Image(); // Абстрактный базовый класс, который предоставляет функциональные возможности для производных классов Bitmap и Metafile.
            img.Margin = new Thickness(0, 10, 0, 0);// Свойство Margin устанавливает отступы вокруг элемента. Синтаксис: Margin="левый_отступ верхний_отступ правый_отступ нижний_отступ".
            img.Source = bitmap; // Получает или задает тип ImageSource для изображения.
            img.Stretch = Stretch.None; //Возвращает или задает значение, которое описывает способ растягивания Image для заполнения прямоугольника назначения.
            stack.Children.Add(img); // добавления UIElement дочернего элемента к Image элементу.

            
            Label lbl = new Label(); // Добавление объекта Label
            lbl.Content = "_Read books!"; // вывод сообщения 
            lbl.HorizontalContentAlignment = HorizontalAlignment.Center; // ориентация по центру 
            stack.Children.Add(lbl); // добавление в родителя 
 
            stack.Children.Add(ZigZag(0)); // Добавление объекта Polyline 
        }

        Polyline ZigZag(int offset)
        {
            Polyline poly = new Polyline(); // Рисует последовательность соединенных прямых линий.
            poly.Stroke = SystemColors.ControlTextBrush; // Получает или задает Brush, задающий способ рисования контура Shape.
            poly.Points = new PointCollection(); // Получает или задает коллекцию, содержащую точки вершин Polyline.
            for (int x = 0; x <= 1000; x += 10)
                poly.Points.Add(new Point(x, (x + offset) % 20)); // создание линий
            return poly; // возращение фигуры
        }

        void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            MessageBox.Show("The button has been clicked", Title); // вызов сообщения при нажатии 
        }
    }
}
