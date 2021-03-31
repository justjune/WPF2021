//------------------------------------------------- 
// RenderTheGraphic.cs (c) 2006 by Charles Petzold 
//-------------------------------------------------

using System; 
using System.Windows; 

namespace Petzold.RenderTheGraphic 
{     
    class RenderTheGraphic : Window     
    {         
        [STAThread]
        public static void Main()
        {             
            Application app = new Application(); 
            app.Run(new RenderTheGraphic());
        }         
        public RenderTheGraphic()
        {

            Title = "Render the Graphic"; //Задаем заголовок окна
            SimpleEllipse elips = new SimpleEllipse(); //Создаем экземпляр нашего эллипса  
            Content = elips; // Задаем содержимое окна
        }     
    } 
} 
