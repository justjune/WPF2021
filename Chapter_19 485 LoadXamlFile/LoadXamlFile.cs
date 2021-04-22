using Microsoft.Win32;
using System.IO;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace Chapter_19_485_LoadXamlFile
{
    public class LoadXamlFile : Window//создаем наследника класса window
    {
        Frame frame;// Это элемент управления содержимым, который предоставляет возможность переходить по содержимому и отображать его
        [STAThread]
        public static void Main()//метод main
        {
            Application app = new Application();//запускаем наше окно
            app.Run(new LoadXamlFile());
        }
        public LoadXamlFile()// метод LoadXamlFile
        {
            Title = "Load XAML File";// заголовок окна
            DockPanel dock = new DockPanel();// создаем DockPanel 
            Content = dock;             // контентом нашего окна будет   DockPanel           
            Button btn = new Button();// создаем кноку
            btn.Content = "Open File...";// на кнопке пишем Open File...
            btn.Margin = new Thickness(12);// задаем отступ
            btn.HorizontalAlignment = HorizontalAlignment.Left;// задаем расположение кнопки
            btn.Click += ButtonOnClick;//при нажатии на кнопку срабатывает наш обработчик событий ButtonOnClick 
            dock.Children.Add(btn);//добавляем нашу кнопку в DockPanel
            DockPanel.SetDock(btn, Dock.Top);// задаем расположение нашей кнопки в DockPanel             
            frame = new Frame();// создаем Frame
            dock.Children.Add(frame);// добавляем Frame в наш DockPanel
        }
        void ButtonOnClick(object sender, RoutedEventArgs args)// обработчик событий
        {
            OpenFileDialog dlg = new OpenFileDialog();//создаем OpenFileDialog - Отображает диалоговое окно, позволяющее пользователю открыть файл
            dlg.Filter = "XAML Files (*.xaml)|* .xaml|All files (*.*)|*.*";// добавляем 2 фильтра (файлы Xaml или же все файлы) фильтруем файлы
            if ((bool)dlg.ShowDialog())// проверка открылось ли диалогове окно
            {
                try//пробуем открыть файл
                {
                    XmlTextReader xmlreader = new XmlTextReader(dlg.FileName);// создаем обьект XmlTextReader от имени переданного нашим диалоговым окном                      
                    object obj = XamlReader.Load(xmlreader);// конвертируем наш xaml в обьект                    
                    if (obj is Window)//  обьект является ли окномнаш обьект
                    {
                        Window win = obj as Window;// инициализируем наш файл как окно
                        win.Owner = this;// задаем владельца окна
                        win.Show();// отображаем наше окно(файл xaml)
                    }
                    else//если наш обьект не окно
                        frame.Content = obj;//отображаем наш xaml файл в диалоговм окне
                }
                catch (Exception exc)//если не получилось открыть файл
                {
                    MessageBox.Show(exc.Message, Title);//выводим ошибку из за которой не смогли открыть файл
                }
            }
        }
    }
}
