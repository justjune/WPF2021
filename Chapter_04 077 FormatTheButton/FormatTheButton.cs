using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF_Petzold
{
    public class FormatTheButton : Window
    {
        Run runButton;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new FormatTheButton());
        }

        public FormatTheButton()
        {
            Title = "Format the Button";

            // Создание обьекта Button, назначаемого содержимым окна
            Button btn = new Button();
           
            // Выравнивание положения кнопки
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            
            // Назначение обработчиков событий
            btn.MouseEnter += ButtonOnMouseEnter;  // Когда курсор находится в пределах границ кнопки
            btn.MouseLeave += ButtonOnMouseLeave;  // Когда курсор вне границ кнопки
            Content = btn;  // Кнопка устанавливается в качестве содержимого окна

            
            // Созадние объекта TextBlock, назанчаемого содержимым кнопки
            TextBlock txtblk = new TextBlock();  // Класс TextBlock используется для управления небольшим объемом текста
            txtblk.FontSize = 24;  // Задаем размер шрифта верхнего уровня
            txtblk.TextAlignment = TextAlignment.Center;  // Задаем горизонтальное выравнивание текстового содрежимого
            btn.Content = txtblk;  // TextBlock назначается в качестве содержимого кнопки

            
            // Добавление отформатированного текста к TextBlock.
            // Классы всех объектов, передаваемых в метод Add
            // наследуются от абстрактного класса Inline и представляют
            // элементы внутреннего содержимого
            txtblk.Inlines.Add(new Italic(new Run("Click")));
            txtblk.Inlines.Add(" the ");
            
            // Здесь мы сохраняем объект Run, чтобы в дальнейшем изменять его состояние
            txtblk.Inlines.Add(runButton = new Run("Button"));
            
            txtblk.Inlines.Add(new LineBreak());
            txtblk.Inlines.Add("to launch the ");
            txtblk.Inlines.Add(new Bold(new Run("rocket")));
        }

        void ButtonOnMouseEnter(object sender, MouseEventArgs args)
        {
            runButton.Foreground = Brushes.Red;  // Изменяем цвет содержимого элемента на красный
        }

        void ButtonOnMouseLeave(object sender, MouseEventArgs args)
        {
            runButton.Foreground = SystemColors.ControlTextBrush;  // Ставим цвет текста по умолчанию
        }
    }
}