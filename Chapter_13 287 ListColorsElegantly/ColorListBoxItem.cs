using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
namespace ListColorsElegantly 
{
    class ColorListBoxItem : ListBoxItem 
    {
        string str;
        Rectangle rect;
        TextBlock text;
        public ColorListBoxItem() 
        {
            // Создание панели StackPanel для вывода Rectangle и TextBlock
            StackPanel stack = new StackPanel();    
            stack.Orientation = Orientation .Horizontal;  
            Content = stack;     
            // Создание объекта Rectangle для вывода образца цвета
            rect = new Rectangle();    
            rect.Width = 16;  
            rect.Height = 16;  
            rect.Margin = new Thickness(2);    
            rect.Stroke = SystemColors .WindowTextBrush;   
            stack.Children.Add(rect);        
            // Создание объекта TextBlock для вывода названия цвета
            text = new TextBlock();     
            text.VerticalAlignment =  VerticalAlignment.Center;    
            stack.Children.Add(text);    
        }
        // свойство Text становится свойством Brush объекта TextBlock.
        public string Text        
        {
            set
            {            
                str = value;    
                string strSpaced = str[0].ToString();    
                for (int i = 1; i < str.Length; i++)     
                    strSpaced += (char.IsUpper (str[i]) ? " " : "") + str[i].ToString();      
                text.Text = strSpaced;        
            }
            get
            {
                return str; 
            }
        }
        // свойство Color становится свойством Brush объекта Rectangle.
        public Color Color   
        {         
            set
            {
                rect.Fill = new SolidColorBrush (value);
            }          
            get      
            {          
                SolidColorBrush brush = rect.Fill  as SolidColorBrush;   
                return brush == null ? Colors .Transparent : brush.Color;   
            }
        }
        // Выделенный вариант помечается жирным шрифтом
        protected override void OnSelected (RoutedEventArgs args)   
        {
            base.OnSelected(args);       
            text.FontWeight = FontWeights.Bold;    
        }
        protected override void OnUnselected (RoutedEventArgs args)  
        {
            base.OnUnselected(args);      
            text.FontWeight = FontWeights.Regular;     
        }
        // Реализация ToString для клавиатурного интерфейса
        public override string ToString()       
        {
            return str;      
        }
    }
}