using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace ExamineKeystrokes
{
    class ExamineKeystrokes : Window
    {
        StackPanel stack;   // Экземпляр StackPanel
        ScrollViewer scroll;  // кнопка прокрутки 
        string strHeader = "Event Key Sys-Key Text " + "Ctrl-Text Sys-Text Ime  KeyStates " + "IsDown IsUp IsToggled IsRepeat ";   // для вывода заголовка
        string strFormatKey = "{0,-10}{1,-20}{2 ,-10} " + " {3,-10}{4,-15 }{5,-8}{6,-7}{7,-10}{8,-10}";
        string strFormatText = "{0,-10} " + "{1,-10}{2,-10}{3 ,-10}";
        [STAThread] public static void Main()
        {
            Application app = new Application(); 
            app.Run(new ExamineKeystrokes()); 
        }
        
        public ExamineKeystrokes()
        {
            Title = "Examine Keystrokes";
            FontFamily = new FontFamily("Courier  New");
            Grid grid = new Grid(); 
            Content = grid;           
            
            // Одна строка в режиме Auto  другая заполняет всё оставшееся место       
            RowDefinition rowdef = new  RowDefinition();          
            rowdef.Height = GridLength.Auto;            
            grid.RowDefinitions.Add(rowdef);            
            grid.RowDefinitions.Add(new  RowDefinition());       
            
            // Вывод заголовка         
            TextBlock textHeader = new TextBlock();    
            textHeader.FontWeight = FontWeights.Bold;  
            textHeader.Text = strHeader;        
            grid.Children.Add(textHeader);       
            
            // Создание StackPanel как дочернего объекта ScrollViewer для обработки событий
            scroll = new ScrollViewer();      
            grid.Children.Add(scroll);  
            Grid.SetRow(scroll, 1);     
            stack = new StackPanel();   
            scroll.Content = stack;   
        }        
        protected override void OnKeyDown (KeyEventArgs args)  
        {           
            base.OnKeyDown(args);        
            DisplayKeyInfo(args);        
        }        
        protected override void OnKeyUp (KeyEventArgs args)    
        {           
            base.OnKeyUp(args);      
            DisplayKeyInfo(args);    
        }      
        protected override void OnTextInput (TextCompositionEventArgs args)   
        {           
            base.OnTextInput(args);     
            string str = String.Format(strFormatText, args.RoutedEvent.Name, args.Text, args.ControlText, args.SystemText);        
            DisplayInfo(str);   
        }      
        void DisplayKeyInfo(KeyEventArgs args)   // вывод данных на окно для клавиш 
        {            
            string str = String.Format(strFormatKey, args.RoutedEvent.Name, args.Key, args.SystemKey, args.ImeProcessedKey, args.KeyStates, args.IsDown, args.IsUp, args.IsToggled, args.IsRepeat);         
            DisplayInfo(str);       
        }      
        void DisplayInfo(string str)   // вывод данных на окно для текста 
        {           
            TextBlock text = new TextBlock();    
            text.Text = str;          
            stack.Children.Add(text);   
            scroll.ScrollToBottom();  
        }   
    }
} 

