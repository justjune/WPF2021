using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

class ListWithListBoxItems : Window
{
    [STAThread]
    public static void Main()
    {
        Application app = new Application();
        app.Run(new ListWithListBoxItems());
    }
    public ListWithListBoxItems()
    {
        Title = "List with ListBoxItem"; //заголовок окна

        ListBox lstbox = new ListBox(); //создаем объект lstbox класса ListBox
        lstbox.Height = 150; //высота lstbox
        lstbox.Width = 150; //ширина lstbox
        lstbox.SelectionChanged += ListBoxOnSelectionChanged; //при смене цвета вызывается метод ListBoxOnSelectionChanged
        Content = lstbox; //показывать lstbox

        PropertyInfo[] props = typeof(Colors).GetProperties(); //создаём массив props, содержащий названия цветов, получаемый методом GetProperties

        foreach (PropertyInfo prop in props)
        {
            Color clr = (Color)prop.GetValue(null, null);                    //isBlack вычисляется на основании яркости цвета, она равна стандартному
            bool isBlack = .222 * clr.R + .707 * clr.G + .071 * clr.B > 128; //средневзвешенному значению трёх цветовых составляющих

            ListBoxItem item = new ListBoxItem(); //создаем объект item класса ListBoxItem
            item.Content = prop.Name; //показывать название цвета из массива props
            item.Background = new SolidColorBrush(clr); //фон item окрашивается в цвет, полученный из массива props
            item.Foreground = isBlack ? Brushes.Black : Brushes.White; //цвет текста окрашивается в черный или белый, в зависимости от значения IsBlack
            item.HorizontalContentAlignment = HorizontalAlignment.Center; //горизонтальное выравнивание по центру
            item.Padding = new Thickness(2); //отступ между элементами списка
            lstbox.Items.Add(item); //добавление item в lstbox
        }
    }
    void ListBoxOnSelectionChanged(object sender, SelectionChangedEventArgs args) //метод для обработчика событий
    {
        ListBox lstbox = sender as ListBox; //предоставляет ссылку на объект, который вызвал событие
        ListBoxItem item; //создаем объект item класса ListBoxItem

        if (args.RemovedItems.Count > 0) //RemovedItems определяет, что с элемента списка снято выделение, затем его шрифт возвращается к обычному 
        {
            item = args.RemovedItems[0] as ListBoxItem;
            String str = item.Content as String;
            item.Content = str.Substring(2, str.Length - 4);
            item.FontWeight = FontWeights.Regular;
        }
        if (args.AddedItems.Count > 0) //AddedItems определяет, что элемент списка выделен, затем его шрифт выделяется жирным и заключается в квадратные скобки
        {
            item = args.AddedItems[0] as ListBoxItem;
            String str = item.Content as String;
            item.Content = "[ " + str + " ]";
            item.FontWeight = FontWeights.Bold;
        }

        item = lstbox.SelectedItem as ListBoxItem; //item присвается значение выбранного элемента в списке ListBoxItem

        if (item != null)
            Background = item.Background; //если элемент в списке цветов существует, то цвет фона меняется на него
    }
}
