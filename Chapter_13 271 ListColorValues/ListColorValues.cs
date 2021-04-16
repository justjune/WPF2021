using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;
using System.Reflection;

namespace Chapter_13_271_ListColorValues
{
    class ListColorValues : Window
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application app = new Application();
            app.Run(new ListColorValues());
        }

        public ListColorValues()
        {
            Title = "List Color Values";
            
            // Создание объекта ListBox как содержимого окна
            ListBox lstbox = new ListBox();
            lstbox.Width = 150;
            lstbox.Height = 150;
            lstbox.SelectionChanged += ListBoxOnSelectionChanged;  // Назначаем обработчик события SelectionChanged
            Content = lstbox;

            // Заполнение ListBox объектами Color
            PropertyInfo[] props = typeof(Colors).GetProperties();  // Получаем информацию о свойствах класса Color

            foreach (PropertyInfo prop in props)
                lstbox.Items.Add( // Добавляем новый элемент в ListBox
                    prop.GetValue(null, null));  // Получаем объект (цвет) из Colors
        }

        void ListBoxOnSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            ListBox lstbox = sender as ListBox;

            if (lstbox.SelectedIndex != -1)  // Проверяем, что есть выделение
            {
                Color clr = (Color)lstbox.SelectedItem;  // Получаем выбранный цвет
                Background = new SolidColorBrush(clr);  // Закрашиваем фон этим цветом
            }
        }
    }
}
