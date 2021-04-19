using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.ListNamedBrushes
{
    public class ListNamedBrushes : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ListNamedBrushes());
        }
        public ListNamedBrushes()
        {
            Title = "List Named Brushes";

            //Создание обьекта listBox как содержимого окна
            ListBox lstbox = new ListBox();
            lstbox.Width = 150;
            lstbox.Height = 150;
            Content = lstbox;

            // Заполнение списка и задание свойств
            lstbox.ItemsSource = NamedBrush.All;
            lstbox.DisplayMemberPath = "Name";
            lstbox.SelectedValuePath = "Brush";

            // Привязка SelectedValue к свойству Background окна
            lstbox.SetBinding(ListBox.SelectedValueProperty, "Background");
            lstbox.DataContext = this;
        }
    }//если listBox будет находиться в состоянии невыделенного варианта или значение свойства Background будет равно null, то все будет просто закрашиваться черным
}
