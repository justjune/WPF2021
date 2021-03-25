using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Documents;

namespace FormatTheText
{
    class FormatTheText : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new FormatTheText());
        }

        public FormatTheText() //Функция форматирования текста
        {
            Title = "Format The Text"; //Заголовок
            TextBlock txt = new TextBlock(); //Объявляется текст - объект класса TextBlock
            txt.FontSize = 32; //Задаётся размер шрифта текста
            txt.Inlines.Add("This is some "); //Строка "This is some " добавляется в текст
            txt.Inlines.Add(new Italic(new Run("italic"))); //Строка "italic", выделенная курсивом добавляется в текст
            txt.Inlines.Add(" text, and this is some "); //Строка " text, and this is some " добавляется в текст
            txt.Inlines.Add(new Bold(new Run("bold"))); //Строка "bold", выделенная жирным добавляется в текст
            txt.Inlines.Add(" text, and let's cap it off with some "); //Строка " text, and let's cap it off with some " добавляется в текст
            txt.Inlines.Add(new Bold(new Italic(new Run("bold italic")))); //Строка "bold italic", выделенная жирным курсивом добавляется в текст
            txt.Inlines.Add(" text."); //Строка " text." добавляется в текст
            txt.TextWrapping = TextWrapping.Wrap; //Перенос текста на новую строку в случае недостаточного размера окна

            Content = txt; //Свойству класса ContentControl задаётся значение получившегося текста
        }
    }
}
