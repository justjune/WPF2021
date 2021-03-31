using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace BindTheButton
{
    public class BindTheButton : Window // Класс BindTheButton наследуется от Window
    {
        [STAThread] //атрибут означающий, что основной программный поток приложения должен использовать однопточную модель. это необходимо для взаимодействия с подсистемой COM.
        public static void Main()
        {
            Application app = new Application();
            app.Run(new BindTheButton());
        }
        public BindTheButton()
        {
            Title = "Bind theButton"; // Устанавливаем заголовок окна
            ToggleButton btn = new ToggleButton(); // Создаём объект класса ToggleButton
            btn.Content = "Make _Topmost"; // Задаёт значение ContentControl класса ToggleButton
            btn.HorizontalAlignment = HorizontalAlignment.Center; // Установка кнопки по горизонтали в центре
            btn.VerticalAlignment = VerticalAlignment.Center; // Установка кнопки по вертикали в центре
            btn.SetBinding(ToggleButton.IsCheckedProperty, "Topmost"); // Установка привязки статического поля IsCheckedProperty со строкой с именем свойства,
            // ассоциируемой с состоянием кнопки IsChecked
            btn.DataContext = this; // задает объект к которому принадлежит Topmost
            Content = btn; // получает содержимое IsChecked
            ToolTip tip = new ToolTip(); // Создаёт объект класса ToolTip
            tip.Content = "Toggle the button on to  make " + "the window topmost on  the desktop"; // Задаёт значение атрибута Content объекта ToolTip
            btn.ToolTip = tip; // Задает объект подсказки, отображаемый для этого элемента в пользовательском интерфейсе
        }
    }
}
