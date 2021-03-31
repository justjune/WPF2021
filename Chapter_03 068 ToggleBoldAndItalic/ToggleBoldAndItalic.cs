using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.ToggleBoldAndItalic
{
    public class ToggleBoldAndItalic : Window // Создание класса ToggleBoldAndItalic, наследника Window
    {
        [STAThread] // аттрибут, который показывает, что управление программой осуществляется одним главным потоком.
        public static void Main() // точка входа выполняемой программы
        {
            Application app = new Application(); // создание нового приложения
            app.Run(new ToggleBoldAndItalic()); // обработка и отправка сообщений между приложением и операционной системой
        }
        public ToggleBoldAndItalic()
        {
            Title = "Toggle Bold & Italic";
            TextBlock text = new TextBlock(); // создание текстового блока
            text.FontSize = 32; // выставление размера текста
            text.HorizontalAlignment = HorizontalAlignment.Center; // горизонтальное выравнивание
            text.VerticalAlignment = VerticalAlignment.Center; // вертикальное выравнивание
            Content = text;
            string strQuote = "To be, or not to be, that is the question";
            string[] strWords = strQuote.Split(); // разделение по пробелу
            foreach (string str in strWords) // выполнение оператора для каждого элемента
            {
                Run run = new Run(str);
                run.MouseDown += RunOnMouseDown; // это событие происходит при нажатии пользователем кнопки мыши, когда указатель мыши находится на элементе управления
                text.Inlines.Add(run); // добавление в конец текста
                text.Inlines.Add(" ");
            }
        }
        void RunOnMouseDown(object sender, MouseButtonEventArgs args) // первый параметр, sender, предоставляет ссылку на объект, который вызвал событие
        {
            Run run = sender as Run;
            if (args.ChangedButton == MouseButton.Left) // при нажатии на кнопку стиль текста меняется
                run.FontStyle = run.FontStyle == FontStyles.Italic ?
                FontStyles.Normal : FontStyles.Italic; // Italic - при нажатии на левую кнопку мыши
            if (args.ChangedButton == MouseButton.Right)
                run.FontWeight = run.FontWeight == FontWeights.Bold ?
                FontWeights.Normal : FontWeights.Bold; // Bold - при нажатии на правую кнопку мыши
        }

    }
}
