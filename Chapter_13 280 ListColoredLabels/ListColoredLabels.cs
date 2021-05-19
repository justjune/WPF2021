//--------------------------------------------------
// ListColoredLabels.cs (c) 2006 by Charles Petzold
//--------------------------------------------------
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.ListColoredLabels
{
    class ListColoredLabels : Window //создаем наследника класса window
    {
        [STAThread] //используем однопоточность
        public static void Main() // метод main
        {
            Application app = new Application(); //запускаем наше окно
            app.Run(new ListColoredLabels());
        }
        public ListColoredLabels()
        {
            Title = "List Colored Labels"; // заголовок окна

            // Create ListBox as content of window.
            ListBox lstbox = new ListBox(); // создаем listbox
            lstbox.Height = 150; //высота listbox
            lstbox.Width = 150; //ширина listbox
            lstbox.SelectionChanged += ListBoxOnSelectionChanged; //назначем обработчику событий ( если мы выбрали цвет) метод ListBoxOnSelectionChanged
            Content = lstbox; // контентом нашего окна будет listbox

            // Fill ListBox with label controls.
            PropertyInfo[] props = typeof(Colors).GetProperties(); //создаем массив классов PropertyInfo и заполняем его обьектами типа PropertyInfo(именами свойств) при помощи метода GetProperties от каждого цвета  ( от цвета)  (механизм рефлексии)(что бы не вводить все названия цветов)

            foreach (PropertyInfo prop in props) //пробегаем весь массив наших цветов
            {
                Color clr = (Color)prop.GetValue(null, null); // isBlack по средневзвешенному значению трёх цветовых составляющих определяет текст
                bool isBlack = .222 * clr.R + .707 * clr.G + .071 * clr.B > 128; //  должен быть чёрного или белого цвета

                Label lbl = new Label(); // создаём объект lbl класса Label
                lbl.Content = prop.Name; // контентом label будет prop.Name
                lbl.Background = new SolidColorBrush(clr); // закрашивает background цветом, полученный из массива props
                lbl.Foreground = isBlack ? Brushes.Black : Brushes.White; // определяет цвет текст через переменную isBlack
                lbl.Width = 100; // //ширина label
                lbl.Margin = new Thickness(15, 0, 0, 0); // отступ слева в 15 единиц
                lbl.Tag = clr; // задаёт значение фоновой кисти окна
                lstbox.Items.Add(lbl); // заполняем listbox label
            }
        }
        void ListBoxOnSelectionChanged(object sender,
                                       SelectionChangedEventArgs args) // метод если для события (мы выбрали цвет ) 
        {
            ListBox lstbox = sender as ListBox; // предоставляет ссылку на объект, который вызвал событие
            Label lbl = lstbox.SelectedItem as Label;

            if (lbl != null) //проверка выбрали ли мы цвета 
            {
                Color clr = (Color)lbl.Tag; // задаёт значение фоновой кисти окна
                Background = new SolidColorBrush(clr); // меняем цвета фона на цвет выбранный в listbox
            }
        }
    }
}
