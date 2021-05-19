using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;

namespace TTR
{
    public class TuneTheRadio : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new TuneTheRadio());
        }

        public TuneTheRadio() //приложение TuneTheRadio с использованием объекта StackPanel показывает создание группы из 4 переключателей, динамически изменяющих свойство WindowStyle окна
        {
            Title = "Tune the Radio";
            SizeToContent = SizeToContent.WidthAndHeight;

            GroupBox group = new GroupBox(); //класс GroupBox(производный от HeaderedContentControl со свойством Control и Header) - это элемент управления(простая рамка с текстовым заголовком)
            group.Header = "Window Style"; //заголовок 
            group.Margin = new Thickness(96); //толщина внешнего отступа в 1 дюйм
            group.Padding = new Thickness(5); //толщина внутренего отступа в 1/20 дюйма
            Content = group;

            StackPanel stack = new StackPanel(); //класс StackPanel объединяет в вертикальный или горизонтальный стек дочерние элементы Children (например, другие панели или объекты типа UIElementCollection(объекты Image, Shape, TextBlock, Control))
            group.Content = stack;

            stack.Children.Add(CreateRadioButton("No border or  caption", WindowStyle.None));
            stack.Children.Add(CreateRadioButton("Single-border  window", WindowStyle.SingleBorderWindow));
            stack.Children.Add(CreateRadioButton("3D-border window", WindowStyle.ThreeDBorderWindow));
            stack.Children.Add(CreateRadioButton("Tool window", WindowStyle.ToolWindow));
            AddHandler(RadioButton.CheckedEvent, new RoutedEventHandler(RadioOnChecked));
        }

        RadioButton CreateRadioButton(string strText, WindowStyle winstyle)
        {//методы CreateRadioButton задают свойству Content каждой кнопки текстовую строку и свойству Tag соответствующее значение из списка WindowStyle
            RadioButton radio = new RadioButton();
            radio.Content = strText;
            radio.Tag = winstyle;
            radio.Margin = new Thickness(5); //толщина совпадает с внутренним отступом
            radio.IsChecked = (winstyle == WindowStyle); // устанавливается флаг переключателя, соответствующего текущему состоянию свойства WindowStyle окна
            return radio;
        }

        void RadioOnChecked(object sender, RoutedEventArgs args)
        {
            RadioButton radio = args.Source as RadioButton;
            WindowStyle = (WindowStyle)radio.Tag;
        }
    }
}