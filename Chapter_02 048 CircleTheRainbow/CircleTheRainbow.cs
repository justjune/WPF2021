using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CircleTheRainbow_added
{
    public class CircleTheRainbow : Window
    {
        [STAThread] 
        public static void Main() 
        { 
            Application app = new Application(); 
            app.Run(new CircleTheRainbow());
        }
        public CircleTheRainbow()
        {
            Title = "Circle the Rainbow"; // установка названия создаваемого окна
            
            RadialGradientBrush brush = new RadialGradientBrush(); // создание экземпляра класса радиальной кисти RadialGradientBrush
            Background = brush; // установка цвета фона в соответствии с созданной кистью 

            brush.GradientStops.Add(new  GradientStop(Colors.Red, 0));        //    для созданной кисти создаются объекты GradientStop и для них устанавливаются параметры цвета 
            brush.GradientStops.Add(new  GradientStop(Colors.Orange, .17));   //    (для данной программы семь цветов радуги для семи объектов соответсвенно)       
            brush.GradientStops.Add(new  GradientStop(Colors.Yellow, .33));   //    и параматр offset определяющий положение конкретных цветов на окне 
            brush.GradientStops.Add(new  GradientStop(Colors.Green, .5));     //    ....
            brush.GradientStops.Add(new  GradientStop(Colors.Blue, .67));     //    ....
            brush.GradientStops.Add(new  GradientStop(Colors.Indigo, .84));   //    ....      
            brush.GradientStops.Add(new  GradientStop(Colors.Violet, 1));     //    ....
            
            brush.GradientOrigin = new Point(0.75, 0.75);   // дополнительная строка кода (по сравнению с примером из книги) которая изменяет свойство GradientOrigin для класса RadialGradientBrush, отвечающее начальную точку при построении градиента

        }     
    } 
} 
