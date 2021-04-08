using System;
using System.Reflection;
using System.Windows.Media;

namespace Chapter_13_288_ListColorsEvenElegantlier
{
    class NamedBrush
    {
        static NamedBrush[] nbrushes; 
        Brush brush; 
        string str;   
        //Создание конструктора
        static NamedBrush()     
        {         
            PropertyInfo[] props = typeof(Brushes).GetProperties();   // Выявляет атрибуты свойства и обеспечивает доступ к его метаданным.
            nbrushes = new NamedBrush[props.Length];         
            for (int i = 0; i < props.Length; i++)
            {
                nbrushes[i] = new NamedBrush(props[i].Name,
                    (Brush)props[i].GetValue(null, null)); // Возвращает значение свойства заданного объекта с дополнительными значениями индекса для индексированных свойств.
            }          
                
        }        
        // Приватный конструктор   
        private NamedBrush(string str, Brush brush)   
        {           
            this.str = str;      
            this.brush = brush;    
        }        
        
        // Статическое свойство только для чтения.
        public static NamedBrush[] All   
        {           
            get { return nbrushes; }  
        }        
        // Свойства только для чтения.  
        public Brush Brush      
        {             
            get { return brush; }   
        }         
        public string Name   
        {            
            get      
            {        
                string strSpaced = str[0].ToString();       
                for (int i = 1; i < str.Length; i++)     
                    strSpaced += (char.IsUpper (str[i]) ? " " : "") +      
                        str[i] .ToString();               
                return strSpaced;             
            }         
        }        
        // Переопределение метода toString.
        public override string ToString()    
        {            
            return str;  
        }  
    }
}
