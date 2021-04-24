using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace CheckTheWindowStyle 
{
    public class CheckTheWindowStyle : Window 
    {
        MenuItem itemChecked;
        [STAThread]
        public static void Main() 
        {
            Application app = new Application();
            app.Run(new CheckTheWindowStyle());
        }
        public CheckTheWindowStyle()
        {
            Title = "Check the Window Style";   
            // Создание объекта DockPanel  
            DockPanel dock = new DockPanel();       
            Content = dock;       
            // Создание меню, пристыкованного к верхнему краю окна
            Menu menu = new Menu();     
            dock.Children.Add(menu);    
            DockPanel.SetDock(menu, Dock.Top);     
            // Создание объекта TextBlock, заполняющего оставшуюся область
            TextBlock text = new TextBlock();     
            text.Text = Title;     
            text.FontSize = 32;   
            text.TextAlignment = TextAlignment.Center;    
            dock.Children.Add(text);
            // Создание объекта TextBlock для изменения WindowStyle  
            MenuItem itemStyle = new MenuItem();   
            itemStyle.Header = "_Style";     
            menu.Items.Add(itemStyle);       
            // 4 команды Style используют общий обработочик события Click
            itemStyle.Items.Add(CreateMenuItem("_No border or  caption", WindowStyle.None));   
            itemStyle.Items.Add(CreateMenuItem("_Single-border  window", WindowStyle .SingleBorderWindow));     
            itemStyle.Items.Add(CreateMenuItem("3_D-border window", WindowStyle .ThreeDBorderWindow));   
            itemStyle.Items.Add(CreateMenuItem("_Tool window", WindowStyle .ToolWindow));        
        }
        MenuItem CreateMenuItem(string str, WindowStyle style) // создает те 4 команды Style
        {
            MenuItem item = new MenuItem();       
            item.Header = str;         
            item.Tag = style; // свойство Tag объекта MenuItem передает значение перечисления WindowStyle
            item.IsChecked = (style == WindowStyle);     
            item.Click += StyleOnClick; // Click снимает пометку с itemChecked и сохраняет в itemChecked объект команды, на которую был сделан щелчок, а напоследок задает свойству WindowStyle значение свойства Tag этой команды
            if (item.IsChecked)               
                itemChecked = item;        
            return item;        
        }
        void StyleOnClick(object sender,  RoutedEventArgs args)    
        {
            itemChecked.IsChecked = false;     
            itemChecked = args.Source as MenuItem;     
            itemChecked.IsChecked = true;      
            WindowStyle = (WindowStyle)itemChecked .Tag;   
        }
    }
} 