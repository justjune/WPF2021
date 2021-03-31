using System;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace nikbarale.ExploreDirectories
{
    public class ExploreDirectories : Window //создаем наследника(ExploreDirectories) класса window
    {
        [STAThread] //атрибут означающий, что основной программный поток приложения должен использовать однопточную модель.это необходимо для взаимодействия с подсистемой COM.
        public static void Main()
        {
            Application app = new Application();//(обьект Application - производная от DispatcherObject) в программе может быть единственным
            app.Run(new ExploreDirectories());//метод Run(весь жизненый цикл программы проходит во время выполнения run, только после вызова метода Run объект Window может реагировать на действия пользователя)
        }
        public ExploreDirectories() //метод ExploreDirectories класса ExploreDirectories
        {
            Title = "Explore Directories";//заголовком является - "Explore Directories"
            ScrollViewer scroll = new ScrollViewer();//содержимое окна. Элемент ScrollViewer обеспечивает прокрутку содержимого. Может вмещать в себя только один элемент
            Content = scroll;
            WrapPanel wrap = new WrapPanel();//содержимое ScrollViewer. Размещает дочерние элементы последовательно слева направо, перенося содержимое на следующую строку на краю содержащего поля.
            scroll.Content = wrap;//содержимое ScrollViewer.
            wrap.Children.Add(new FileSystemInfoButton());//дочерний элемент- обьект типа FileSystemInfoButton(Размещает дочерние элементы последовательно слева направо, перенося содержимое на следующую строку на краю содержащего поля.)
        }
    }
    public class FileSystemInfoButton : Button//создаем наследника(FileSystemInfoButton) класса button
    {
        FileSystemInfo info;         // непараметризованный конструктор создает кнопку для каталога "мои документы".
        public FileSystemInfoButton()//используется только при запуске и при добавлении первого дочернего элемента в обьект WarpPanel
            :
            this(new DirectoryInfo(//инициализируем класс DirectoryInfo для пути
                Environment.GetFolderPath(//путь. Возвращает путь к особой системной папке, указанной в заданном перечислении.
                    Environment.SpecialFolder.MyDocuments)))//задаем перечисление. т.е. папку MyDocuments
        {
        }         // конструктор с одним аргументом создает кнопку для каталога или файла
        public FileSystemInfoButton(FileSystemInfo info)//класс FileSystemInfo содержит методы, которые являются общими для операций с файлами и каталогами.
        {
            this.info = info;//передаем информацию в наш класс FileSystemInfoButton 
            Content = info.Name;//задаем содержимое (имя файла/каталога)
            if (info is DirectoryInfo)//проверка каталог это или файл
                FontWeight = FontWeights.Bold;//для каталога текст выделяется жирным
            Margin = new Thickness(10); //внешний отступ от кнопки    
        }
        public FileSystemInfoButton(FileSystemInfo info, string str)// конструктор с 2 аргументрами создает кнопку родительского каталога.(кнопка позваляет вернуться к родительскому каталогу)
            :
            this(info)
        {
            Content = str;
        }
        protected override void OnClick()     // переопределение OnClick делает все остальное.    
        {
            if (info is FileInfo)//проверка является ли обьект Info, хранимый в поле, обьектом типа Fileinfo
            {
                Process.Start(info.FullName); //производитсязапуск приложения,елси это  обьект типа Fileinfo (файл)           
            }
            else if (info is DirectoryInfo) //если же это каталог            
            {
                DirectoryInfo dir = info as DirectoryInfo;//создаем класс dir (as преобразовывает 
                Application.Current.MainWindow.Title = dir.FullName;//отображаем в заголовке окна новое имя каталога
                Panel pnl = Parent as Panel;//получаем родительский логический элемент класса panel(Panel— Это элемент управления, который содержит другие элементы управления.)
                pnl.Children.Clear();//удалаяем текущие дочерние элементы с WarpPanel
                if (dir.Parent != null)//проверка есть ли родительский каталог
                    pnl.Children.Add(new FileSystemInfoButton(dir.Parent, ".."));//создаем кнопку ".." позвалающая вернуться к родительскому каталогу
                foreach (FileSystemInfo inf in dir.GetFileSystemInfos())//получаем содержимое каталога от GetFileSystemInfos
                    pnl.Children.Add(new FileSystemInfoButton(inf));//создаем обьекты FileSystemInfoButton для всех полученных элементов
            }
            base.OnClick();
        }
    }
}
