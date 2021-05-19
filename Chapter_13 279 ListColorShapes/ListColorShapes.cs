using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
namespace Petzold.ListColorShapes
{
    class ListColorShapes : Window//создаем наследника класса window
    {
        [STAThread]//используем однопоточность
        public static void Main()// метод main
        {
            Application app = new Application();//запускаем наше окно
            app.Run(new ListColorShapes());
        }
        public ListColorShapes()
        {
            Title = "List Color Shapes";// заголовок окна            
            ListBox lstbox = new ListBox();// создаем listbox             
            lstbox.Width = 150;//ширина listbox'a            
            lstbox.Height = 150; //высота           
            lstbox.SelectionChanged += ListBoxOnSelectionChanged;//назначем обработчику событий ( если мы выбрали цвет) метод ListBoxOnSelectionChanged
            Content = lstbox;// контентом нашего окна будет listbox             
            PropertyInfo[] props = typeof(Brushes).GetProperties();//создаем массив классов PropertyInfo и заполняем его обьектами типа PropertyInfo(именами свойств) при помощи метода GetProperties от каждого цвета  ( от цвета)  (механизм рефлексии)(что бы не вводить все названия цветов)             
            foreach (PropertyInfo prop in props)//пробегаем весь массив наших цветов             
            {
                Ellipse ellip = new Ellipse();// создаем эллипс                 
                ellip.Width = 100;// ширина эллипса               
                ellip.Height = 25;// высота                 
                ellip.Margin = new Thickness(10, 5, 0, 5);// выставляем отступ                 
                ellip.Fill = prop.GetValue(null, null) as Brush;//закрашиваем наш эллипс одним из цветов (из нашего массива) при помощи получения информации о свойстве                   
                lstbox.Items.Add(ellip);  // добавляем вариант цвета(в виде эллипса) в наш listbox           
            }
        }
        void ListBoxOnSelectionChanged(object sender, SelectionChangedEventArgs args) // метод если для события (мы выбрали цвет )       
        {
            ListBox lstbox = sender as ListBox;// предоставляет ссылку на объект, который вызвал событие             
            if (lstbox.SelectedIndex != -1)//проверка выбрали ли мы цвета               
                Background = (lstbox.SelectedItem as Shape).Fill;// меняем цвета фона на цвет выбранный в listbox        
        }
    }
}
