using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
namespace Petzold.EnlargeButtonWithAnimation 
{ 
    public class EnlargeButtonWithAnimation : Window 
    { 
        const double initFontSize = 12; // исходный размер шрифта кнопки равен 12 
        const double maxFontSize = 48; // максимальный размер шрифта кнопки 48
        Button btn;
        
        [STAThread] // управление программой осуществляется одним главным потоком
        public static void Main() // точка входа выполняемой программы
        { 
            Application app = new Application(); 
            app.Run(new EnlargeButtonWithAnimation()); 
        } 
        public EnlargeButtonWithAnimation() 
        { 
            Title = "Enlarge Button with Animation"; // заголовок
            btn = new Button(); // создание кнопки
            btn.Content = "Expanding Button"; // текст кнопки
            btn.FontSize = initFontSize;
            btn.HorizontalAlignment = HorizontalAlignment.Center; 
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.Click += ButtonOnClick; 
            Content = btn; 
        } 
        void ButtonOnClick(object sender, RoutedEventArgs args) 
        {
            DoubleAnimation anima = new DoubleAnimation(); // создаёт объект DoubleAnimation
            anima.Duration = new Duration(TimeSpan.FromSeconds(2)); // продолжительность анимации 2 секунды (задаётся свойством Duration)
            anima.From = initFontSize; // задаёт свойство From (от 12)
            anima.To = maxFontSize; // задаёт свойство To (до 48)
            anima.FillBehavior = FillBehavior.Stop; // когда значение достигает 48, анимация завершается
            btn.BeginAnimation(Button.FontSizeProperty, anima); 
        } 
    } 
}
