using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace GetMedieval
{ public class GetMedieval : Window
    {
        [STAThread] 
        public static void Main() 
        { 
            Application app = new Application(); 
            app.Run(new GetMedieval());
        }
        public GetMedieval() 
        {
            Title = "Get Medieval";  // название окна 
            MedievalButton btn = new MedievalButton(); // создание кнопки и присваивание ей экземпляр класса "MedievalButton", описанного в другом файле с кодом в этом проекте
            btn.Text = "Click this button"; // текст на кнопке
            btn.FontSize = 24; // установка размера кнопки
            btn.HorizontalAlignment = HorizontalAlignment.Center; // расположение (по горизонтали)
            btn.VerticalAlignment = VerticalAlignment.Center; // расположение (по вертикали)
            btn.Padding = new Thickness(5, 20, 5, 20); // отступы 
            btn.Knock += ButtonOnKnock; // событие "Knock" в "MedievalButton"
            Content = btn; // установка свойства "Content"
        } 

        // получения объекта, сгенерировавшего событие с помощью второго аргумента "args" 
        void ButtonOnKnock(object sender, RoutedEventArgs args) 
        { 
            MedievalButton btn = args.Source as MedievalButton;
            MessageBox.Show("The button labeled  \"" + btn.Text + "\" has been knocked.", Title);
        } 
    } 
}