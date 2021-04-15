using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.ListColorNames
{
    class ListColorNames : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application(); //создаем объект класса, инкапсулирующего функции WPF, относящиеся к приложению
            app.Run(new ListColorNames()); // запускаем приложение WPF, передавая в качестве аргумента динамически выделенный объект окна ListColorNames, 
                                           // благодаря чему метод Run организует для него вызов метода Show
        }
        public ListColorNames()
        {
            Title = "List Color Names";

            // создание объекта ListBox
            ListBox lstbox = new ListBox();
            lstbox.Width = 150; // ширина списка
            lstbox.Height = 150; // высота списка
            lstbox.SelectionChanged += ListBoxOnSelectionChanged; // указываем событию SelectionChanged обрботчик  
            Content = lstbox; // делаем lstbox содержимым окна

            // заполнение списка названими цветов
            PropertyInfo[] props = typeof(Colors).GetProperties();

            foreach (PropertyInfo prop in props)
                lstbox.Items.Add(prop.Name);
        }
        // код обработчика
        void ListBoxOnSelectionChanged(object sender,
                                       SelectionChangedEventArgs args)
        {
            ListBox lstbox = sender as ListBox; // проверяем, является ли sender объектом ListBox
            string str = lstbox.SelectedItem as string; // проверяем, является ли выбранный элемент списка строкой

            if (str != null)
            {
                Color clr =
                    (Color)typeof(Colors).GetProperty(str).GetValue(null, null); // GetProperty возвращает объект PropertyInfo, а вызов GetValue - объект Color
                Background = new SolidColorBrush(clr); // закрашиваем фон
            }
        }
    }
}