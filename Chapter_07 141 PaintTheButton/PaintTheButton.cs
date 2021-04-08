using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
namespace Petzold.PaintTheButton
{
    public class PaintTheButton : Window // создание класса PaintTheButton, наследника Window
    {
        [STAThread] // атрибут, который показывает, что управление программой осуществляется одним главным потоком
        public static void Main() // точка входа выполняемой программы
        { 
            Application app = new Application(); 
            app.Run(new PaintTheButton()); 
        }
        public PaintTheButton()
        {
            Title = "Paint the Button"; // заголовок        

            // создание объекта Button как содержимого окна
            Button btn = new Button();         
            btn.HorizontalAlignment =  HorizontalAlignment.Center;   
            btn.VerticalAlignment =  VerticalAlignment.Center; // т.к свойствам HorizontalAlignment и VerticalAlignment кнопки задано значение Center,
                                                               // кнопка автоматически изменяет свои размеры по размерам панели Canvas
            Content = btn;

            // создание объекта Canvas как содержимого кнопки
            Canvas canv = new Canvas();        
            canv.Width = 144;         
            canv.Height = 144;   
            btn.Content = canv;     

            // создание Rectangle как дочернего объекта Сanvas
            Rectangle rect = new Rectangle();   
            rect.Width = canv.Width;    
            rect.Height = canv.Height; // задаёт свойствам Width и Height те же значения, что у Сanvas    
            rect.RadiusX = 24;            
            rect.RadiusY = 24;          
            rect.Fill = Brushes.Blue;     
            canv.Children.Add(rect); // объект включается в коллекцию дочерних объектов объекта Сanvas так же, как другие панели
                                     
            Canvas.SetLeft(rect, 0);        
            Canvas.SetRight(rect, 0); // обеспечивает размещение объекта Rectangle в левом верхнем углу панели Сanvas

            // создание Polygon как дочернего объекта Сanvas
            Polygon poly = new Polygon();        
            poly.Fill = Brushes.Yellow;       
            poly.Points = new PointCollection(); // создаёт объекта PointCollection и задаёт его свойству Points
                                                 
            for (int i = 0; i < 5; i++)  // цикл вычисляет вершины звезды    
            {           
                double angle = i * 4 * Math.PI / 5;           
                Point pt = new Point(48 * Math.Sin (angle),  // координаты точек лежат в имнтервале от -48 до 48             
                                    -48 * Math.Cos (angle)); // (центр эллипса находится в точке (0, 0))
                poly.Points.Add(pt); // точки добавляются в коллекцию методом Add         
            }            

            canv.Children.Add(poly); // объект включается в коллекцию дочерних объектов Сanvas      

            Canvas.SetLeft(poly, canv.Width / 2);  // чтобы эллипс отображался по центру Canvas, смещает все вершины
            Canvas.SetTop(poly, canv.Height / 2);               // многоугольника на половину ширины и высоты Canvas 

        }
    } 
} 

