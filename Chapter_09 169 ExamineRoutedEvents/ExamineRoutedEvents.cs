using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
namespace nikbarale.ExamineRoutedEvents
{
    public class ExamineRoutedEvents : Application//производный класс от Application
    {
        static readonly FontFamily fontfam = new FontFamily("Lucida Console");//FontFamaly - класс Семейство шрифтов создаем класс шрифта Lucida Console(статичен, доступен только для чтения)
        const string strFormat = "{0,-30} {1,-15}  {2,-15} {3,-15}";// задаем значения для метода String.Format(как будет выводиться текст(положение в окне))
        StackPanel stackOutput; // класс StackPanel(Выравнивает дочерние элементы в одну линию, ориентированную горизонтально или вертикально.)
        DateTime dtLast;//DateTime Структура(Представляет текущее время, обычно выраженное как дата и время суток.)
        [STAThread] //атрибут означающий, что основной программный поток приложения должен использовать однопточную модель. это необходимо для взаимодействия с подсистемой COM.
        public static void Main()
        {
            ExamineRoutedEvents app = new ExamineRoutedEvents();//бьект ExamineRoutedEvents - производная от Application ) в программе может быть единственным
            app.Run(); //метод Run(весь жизненый цикл программы проходит во время выполнения run, только после вызова метода Run объект Window может реагировать на действия пользователя)
        }
        protected override void OnStartup(StartupEventArgs args)//перегружаем OnStartup
        {
            base.OnStartup(args);//base позволяет запускать любую логику базового класса
            Window win = new Window();//создаем окно
            win.Title = "Examine Routed Events";//
            Grid grid = new Grid();//создаем grid (Задание области с таблицей переменного размера)      
            win.Content = grid;//контентом окна задаем grid            
            RowDefinition rowdef = new RowDefinition();   //инициализируем класс RowDefinition(Определяет специфические для строки свойства, применимые к элементам Grid.)    
            rowdef.Height = GridLength.Auto;    //    высота строки выставляется автоматически   
            grid.RowDefinitions.Add(rowdef);//добавляем строку             
            rowdef = new RowDefinition();
            rowdef.Height = GridLength.Auto;
            grid.RowDefinitions.Add(rowdef);
            rowdef = new RowDefinition();
            rowdef.Height = new GridLength(100, GridUnitType.Star); //высота строки 100 star(            
            grid.RowDefinitions.Add(rowdef); //добавляем строку
            Button btn = new Button();//создаем кнопку             
            btn.HorizontalAlignment = HorizontalAlignment.Center;//ставим кнопку по центру         
            btn.Margin = new Thickness(24); // выставляем margin            
            btn.Padding = new Thickness(24);  //  выставляем padding         
            grid.Children.Add(btn);             // добавляем в наш grid             
            TextBlock text = new TextBlock(); //создаем textblock            
            text.FontSize = 24;   // размер шрифта          
            text.Text = win.Title;   // задаем значение текстового поля нашего  textblock          
            btn.Content = text;//добавляем наш текст в кнопку                          
            TextBlock textHeadings = new TextBlock(); //задаем  заголовок для вывода над scroll viewer  :)         
            textHeadings.FontFamily = fontfam;// шрифтом   Lucida Console          
            textHeadings.Inlines.Add(new Underline(new Run(String.Format(strFormat, "Routed Event", "sender", "Source", "OriginalSource"))));// задаем то как будет выводиться в консоле описание для scrolviewer 
            grid.Children.Add(textHeadings);//добавляем строку с вышезаданаыми параметрами
            Grid.SetRow(textHeadings, 1);//выводим ее первой             
            ScrollViewer scroll = new ScrollViewer();//создаем   ScrollViewer        
            grid.Children.Add(scroll); //добавляем ScrollViewer в наш grid           
            Grid.SetRow(scroll, 2);  //выводим его вторым         
            stackOutput = new StackPanel();//создаем   StackPanel для отображения событий          
            scroll.Content = stackOutput; //задаем контент для нашегоScrollViewer  (StackPanel )          
            UIElement[] els = { win, grid, btn, text };//добвляем обработчика событий/ создаем массив класса UIElement ( из окна , grid, кнопки и текста)(принимаем весь ввод)         
            foreach (UIElement el in els)
            {  // для каждого элемента                                
                el.PreviewKeyDown += AllPurposeEventHandler;  //клавиатура               
                el.PreviewKeyUp += AllPurposeEventHandler;
                el.PreviewTextInput += AllPurposeEventHandler;
                el.KeyDown += AllPurposeEventHandler;
                el.KeyUp += AllPurposeEventHandler;
                el.TextInput += AllPurposeEventHandler;//мыш
                el.MouseDown += AllPurposeEventHandler;
                el.MouseUp += AllPurposeEventHandler;
                el.PreviewMouseDown += AllPurposeEventHandler;
                el.PreviewMouseUp += AllPurposeEventHandler;//стилус
                el.StylusDown += AllPurposeEventHandler;
                el.StylusUp += AllPurposeEventHandler;
                el.PreviewStylusDown += AllPurposeEventHandler;
                el.PreviewStylusUp += AllPurposeEventHandler;//клики
                el.AddHandler(Button.ClickEvent, new RoutedEventHandler(AllPurposeEventHandler));// убираем лишний клик мыши при нажатии кнопки              
            }
            win.Show();// показываем окно   
        }
        void AllPurposeEventHandler(object sender, RoutedEventArgs args)
        {             //обработчик событий (кто отправил и что)           
            DateTime dtNow = DateTime.Now;//создаем переменную с нынешним временем 
            if (dtNow - dtLast > TimeSpan.FromMilliseconds(100))// если разница между действиями более 100 милисекунд выводим пустую строку              
                stackOutput.Children.Add(new TextBlock(new Run(" ")));//выводим пустую строку     
            dtLast = dtNow;             //обнавляем данные о времени             
            TextBlock text = new TextBlock();  // создаем textblock           
            text.FontFamily = fontfam;// с нашим шрифтом    
            text.Text = String.Format(strFormat, args.RoutedEvent.Name, TypeWithoutNamespace(sender), TypeWithoutNamespace(args.Source), TypeWithoutNamespace(args.OriginalSource));//текст = красиво отформатированному( что произошло, кто отправил приложению , откуда отправил, из которого места) 
            stackOutput.Children.Add(text);    // добавляем         
            (stackOutput.Parent as ScrollViewer).ScrollToBottom(); // отправялем в scrolviewer        
        }
        string TypeWithoutNamespace(object obj)
        {// убираем пробелы             
            string[] astr = obj.GetType().ToString().Split('.');
            return astr[astr.Length - 1];
        }
    }
}
