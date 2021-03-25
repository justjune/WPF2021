using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace nikbarale.NavigateTheWeb
{
    class UriDialog : Window//Uri dialog наследик Window
    {
        TextBox txtbox;//создаем класс txtboc с помощью которого пользователь может вводить текст в приложении
        public UriDialog()//задаем значения нескольких свойств класса
        {
            Title = "Enter a URI";//заголовок окна
            ShowInTaskbar = false;//не показывается в панеле задач
            SizeToContent = SizeToContent.WidthAndHeight;//автоматически изменяет размер по размеру содержимого
            WindowStyle = WindowStyle.ToolWindow;//задаем стиль границы окна( допускается изменение размеров окна, но не имеет кнопок сворачивания/разворачивания)
            WindowStartupLocation = WindowStartupLocation.CenterOwner;// открывется по центру своего владельца
            txtbox = new TextBox();//инициализируем класс txtbox
            txtbox.Margin = new Thickness(48);//Свойство Margin определяет поле вокруг элемента управления, Thickness определяет толщину рамки
            Content = txtbox;//задаем содержимое обьекта ContentControl в виде нашего txtbox
            txtbox.Focus();//Возвращает значение, указывающее, имеется ли на txtbox фокус ввода.
        }
        public string Text//предоставляем доступ к свойству text элемента txtbox
        {
            set
            {
                txtbox.Text = value;//получаем строку
                txtbox.SelectionStart = txtbox.Text.Length;//перемещаем точку вставки справа от последнего символа
            }
            get
            {
                return txtbox.Text;//возвращаем полученную строку
            }
        }
        protected override void OnKeyDown(KeyEventArgs args)//переопределяем метод OnKeyDown, что бы можно было закрыть окно клавишей enter, KeyEventArgs - класс включающий в себя Key 
        {
            if (args.Key == Key.Enter) Close();// args.key получет данные с клавиатуры  
        }
    }
    public class NavigateTheWeb : Window
    {
        Frame frm; // объявление класса Frame
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new NavigateTheWeb());
        }
        public NavigateTheWeb()
        {
            Title = "Navigate the Web"; // Название главного окна
            frm = new Frame(); // создание объекта класса Frame
            Content = frm; // установка контента на главное окно
            Loaded += OnWindowLoaded; // Покажет результат, только когда dlg в 57-ой строке будет создан и готов к использованию
        }
        void OnWindowLoaded(object sender, RoutedEventArgs args)
        {
            UriDialog dlg = new UriDialog(); // создание диалогового окна window с использованием класса UriDialog
            dlg.Owner = this; // Владельцем становится текущий объект
            dlg.Text = "http://"; // Задаёт значение атрибута Text txtbox
            dlg.ShowDialog(); // Показывает это окно внутри главного окна
            try
            {
                frm.Source = new Uri(dlg.Text); // frm пытается получить ввод от пользователя и открыть веб страницу по этой ссылке
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, Title); // В случае любого исключения показать диалоговое окно пользователю с ошибкой
            }
        }
    }
}