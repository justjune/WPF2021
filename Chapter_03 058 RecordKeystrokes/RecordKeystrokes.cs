using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.RecordKeystrokes 
{ 
    public class RecordKeystrokes : Window // создание класса RecordKeystrokes, наследника Window
    {
        [STAThread] // основной программный поток приложения использует однопточную модель
        public static void Main() // точка входа
        { 
            Application app = new Application();
            app.Run(new RecordKeystrokes()); 
        } 
        public RecordKeystrokes()
        { 
            Title = "Record Keystrokes"; // свойство Title определяет заголовок окна
            Content = ""; // программа задаёт свойству Content пустую текстовую строку
                          // значением свойства Content является объект, который должен отображаться в клиентской области окна
        }
        protected override void OnTextInput(TextCompositionEventArgs args) // переопределение метода OnTextInput
        { 
            base.OnTextInput(args); // base используется для вызова метода из базового класса
            string str = Content as string;
            if (args.Text == "\b") // метод поддерживает управляющий символ Backspace ("\b")
            { 
                if (str.Length > 0) // если str содержит хотя бы один символ
                    str = str.Substring(0, str.Length - 1); // выделение подстроки без последнего символа (удаление последнего символа)
            } 
            else // в противном случае метод присоединяет текст, введённый с клавиатуры, к текущему содержимому
            { 
                str += args.Text; // команда присваивания
            } 
            Content = str; // добавление символов, введённых с клавиатуры, в строку Content
        } 
    } 
}