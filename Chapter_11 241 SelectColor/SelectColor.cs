using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.SelectColor
{
    public class SelectColor : Window // создание класса SelectColor, наследника Window
    {
        [STAThread] // атрибут, который показывает, что управление программой осуществляется одним главным потоком
        public static void Main() // точка входа выполняемой программы
        { 
            Application app = new Application(); 
            app.Run(new SelectColor()); 
        }
        public SelectColor() 
        {
            Title = "Select Color"; // заголовок

            SizeToContent = SizeToContent.WidthAndHeight;         
            
            // создание объекта StackPanel как содержимого окна
            StackPanel stack = new StackPanel();             
            stack.Orientation = Orientation .Horizontal;            
            Content = stack;            

            // создание фиктивной кнопки для проверки передачи корпуса
            Button btn = new Button();             
            btn.Content = "Do-nothing button\nto  test tabbing";         
            btn.Margin = new Thickness(24); // задаёт значение внешнего поля элемента         
            btn.HorizontalAlignment =  HorizontalAlignment.Center; // горизонтальное выравнивание     
            btn.VerticalAlignment =  VerticalAlignment.Center;  // вертикальное выравнивание        
            stack.Children.Add(btn); // объект включается в коллекцию дочерних объектов StackPanel    

            // создание элемента ColorGrid
            ColorGrid clrgrid = new ColorGrid();            
            clrgrid.Margin = new Thickness(24); // задаёт значение внешнего поля элемента          
            clrgrid.HorizontalAlignment =  HorizontalAlignment.Center; // горизонтальное выравнивание         
            clrgrid.VerticalAlignment =  VerticalAlignment.Center; // вертикальное выравнивание           
            clrgrid.SelectedColorChanged += ColorGridOnSelectedColorChanged; // // обработчик события SelectedColorChanged   
            stack.Children.Add(clrgrid); // объект включается в коллекцию дочерних объектов StackPanel    

            // создание другой фиктивной кнопки
            btn = new Button();       
            btn.Content = "Do-nothing button\nto  test tabbing";    
            btn.Margin = new Thickness(24);  // задаёт значение внешнего поля элемента           
            btn.HorizontalAlignment =  HorizontalAlignment.Center; // горизонтальное выравнивание
            btn.VerticalAlignment =  VerticalAlignment.Center; // вертикальное выравнивание        
            stack.Children.Add(btn); // объект включается в коллекцию дочерних объектов StackPanel         
        }

        // обработчик события SelectedColorChanged устанавливает окно
        void ColorGridOnSelectedColorChanged (object sender, EventArgs args)
        {
            ColorGrid clrgrid = sender as ColorGrid;     
            Background = new SolidColorBrush (clrgrid.SelectedColor); // изменяет фон окна в зависимости от свойства SelectedColor элемента     
        }  
    } 
} 


