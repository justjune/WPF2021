using System;
using System.IO; // Расположенные классы в этом пространстве имен позволяют управлять файловым вводом-выводом
using System.Windows;
using System.Windows.Controls; // Предоставляет классы для создания элементов, называемых элементами управления, которые позволяют пользователю взаимодействовать с приложением
using System.Windows.Markup; // Предоставляет типы, поддерживающие XAML
using System.Xml; // В пространстве имён определен ряд классов, которые позволяют манипулировать xml-документом

namespace Petzold.LoadEmbeddedXaml 
{
    public class LoadEmbeddedXaml : Window  // создание класса
    {
        [STAThread]   // атрибут, который показывает, что управление программой осуществляется одним главным потоком 
        public static void Main()  // точка входа выполняемой программы
        {
            Application app = new Application();  // создание нового приложения 
            app.Run(new LoadEmbeddedXaml());  // обработка и отправка сообщений между приложением и операционной системой
        }
        public LoadEmbeddedXaml()
        { 
            Title = "Load Embedded Xaml";  // заголовок окна

            // strXaml - строковая переменная, которая содержит небольшой, но законченный документ XAML
            string strXaml = 
                "<Button xmlns='http://schemas.microsoft.com/" + "winfx/2006/xaml/presentation'" +  // определение пространства имён
                " Foreground='LightSeaGreen' FontSize='24pt'>" +  // задание характеристик фона и текста
                " Click me!" + "</Button>";  // создание кнопки

            StringReader strreader = new StringReader(strXaml);  // создание экземпляра класса StringReader, который считывает из указанной строки 
            XmlTextReader xmlreader = new XmlTextReader(strreader);  // создание экземпляра класса XmlTextReader, который обеспечивает доступ к данным xml 

            object obj = XamlReader.Load(xmlreader);  // преобразовывает документ XAML в объект 
            Content = obj;  // задаёт объект свойству Content окна
        }
    } 
}