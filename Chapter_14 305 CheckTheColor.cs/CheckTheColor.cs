using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Chapter_14_305_CheckTheColor.cs
{
    class CheckTheColor : Window //создаем наследника класса window 
    {
        TextBlock text;
        [STAThread] //используем однопоточность
        public static void Main() // метод main 
        {
            Application app = new Application();  //запускаем наше окно
            app.Run(new CheckTheColor());
        }

        public CheckTheColor()
        {
            Title = "Check the Color";  // заголовок окна                    
            // Создаем DockPanel.            
            DockPanel dock = new DockPanel(); //Элемент используется для размещения дочернего содержимого вдоль края контейнера макета.     
            Content = dock;
            // Create Menu docked at top.   
            Menu menu = new Menu();  //редставляет элемент управления меню Windows, дающий возможность иерархически организовывать элементы, связанные с командами и обработчиками событий.      
            dock.Children.Add(menu);  // добавляем меню в дочери к dock     
            DockPanel.SetDock(menu, Dock.Top);
            // Create TextBlock filling the rest. 
            text = new TextBlock();  // Предоставляет легковесный элемент управления для отображения небольших объемов размещения содержимого.        
            text.Text = Title; // Получает или задает текстовое содержимое элемента управления TextBlock.         
            text.TextAlignment = TextAlignment.Center;  // Получает или задает значение, указывающее горизонтальное выравнивание содержимого текста.
            text.FontSize = 32; //  Получает или задает размер шрифта верхнего уровня для TextBlock.      
            text.Background = SystemColors.WindowBrush; // Возвращает или задает Brush, используемого для заполнения фона области содержимого. 
            text.Foreground = SystemColors.WindowTextBrush;    // Возвращает или задает кисть Brush, которую следует применить к текстовому содержимому TextBlock.
            dock.Children.Add(text);    // добавление такста в доску       
            // Create menu items.         
            MenuItem itemColor = new MenuItem(); // Инициализирует новый экземпляр класса MenuItem.    
            itemColor.Header = "_Color";       // Получает или задает элемент, задающий подпись элементу управления.
            menu.Items.Add(itemColor); // добавление меню  в меню       
            MenuItem itemForeground = new MenuItem();  // Инициализирует новый экземпляр класса MenuItem.    
            itemForeground.Header = "_Foreground";     // Получает или задает элемент, задающий подпись элементу управления.
            itemForeground.SubmenuOpened += ForegroundOnOpened;   //Происходит при изменении значения свойства IsSubmenuOpen на true.
            itemColor.Items.Add(itemForeground);         // добавление меню  в меню       
            FillWithColors(itemForeground, ForegroundOnClick);
            MenuItem itemBackground = new MenuItem();        // Инициализирует новый экземпляр класса MenuItem.    
            itemBackground.Header = "_Background";        // Получает или задает элемент, задающий подпись элементу управления.
            itemBackground.SubmenuOpened += BackgroundOnOpened;
            itemColor.Items.Add(itemBackground);    // добавление меню  в меню 
            FillWithColors(itemBackground, BackgroundOnClick);
        }
        void FillWithColors(MenuItem itemParent, RoutedEventHandler handler)
        {
            foreach (PropertyInfo prop in typeof(Colors).GetProperties())
            {
                Color clr = (Color)prop.GetValue(null, null);
                int iCount = 0;
                iCount += clr.R == 0 || clr.R == 255 ? 1 : 0;
                iCount += clr.G == 0 || clr.G == 255 ? 1 : 0;
                iCount += clr.B == 0 || clr.B == 255 ? 1 : 0;
                if (clr.A == 255 && iCount > 1)
                {
                    MenuItem item = new MenuItem(); // Инициализирует новый экземпляр класса MenuItem.     
                    item.Header = "_" + prop.Name;  //Получает или задает элемент, задающий подпись элементу управления.   
                    item.Tag = clr;     // 	Получение или установка произвольного значения объекта, которое может использоваться для хранения особых сведений об этом элементе.          
                    item.Click += handler;  // 	Происходит при нажатии элемента управления MenuItem.       
                    itemParent.Items.Add(item);
                }
            }
        }
        void ForegroundOnOpened(object sender, RoutedEventArgs args)
        {
            MenuItem itemParent = sender as MenuItem;    //      Инициализирует новый экземпляр класса MenuItem.      
            foreach (MenuItem item in itemParent.Items)
                item.IsChecked =
                    ((text.Foreground as SolidColorBrush).Color == (Color)item.Tag);  // добавление в предка
        }
        void BackgroundOnOpened(object sender, RoutedEventArgs args)
        {
            MenuItem itemParent = sender as MenuItem;   // Инициализирует новый экземпляр класса MenuItem.     
            foreach (MenuItem item in itemParent.Items)
                item.IsChecked =
                    ((text.Background as SolidColorBrush).Color == (Color)item.Tag);  // добавление в предка   
        }
        void ForegroundOnClick(object sender, RoutedEventArgs args)
        {
            MenuItem item = sender as MenuItem;   // Инициализирует новый экземпляр класса MenuItem.              
            Color clr = (Color)item.Tag;
            text.Foreground = new SolidColorBrush(clr);    // Возвращает или задает кисть Brush, которую следует применить к текстовому содержимому TextBlock.  
        }
        void BackgroundOnClick(object sender, RoutedEventArgs args)
        {
            MenuItem item = sender as MenuItem;      // Инициализирует новый экземпляр класса MenuItem.     
            Color clr = (Color)item.Tag;
            text.Background = new SolidColorBrush(clr); // Возвращает или задает Brush, используемого для заполнения фона области содержимого.
        }
    }
}
