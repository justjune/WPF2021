using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
namespace Petzold.EnlargeButtonWithTimer 
{ 
    public class EnlargeButtonWithTimer : Window 
    { 
        const double initFontSize = 12; // исходный размер шрифта кнопки равен 12 
        const double maxFontSize = 48; // максимальный размер шрифта кнопки 48
        Button btn; 

        [STAThread] // управление программой осуществляется одним главным потоком
        public static void Main() // точка входа выполняемой программы
        { 
            Application app = new Application();
            app.Run(new EnlargeButtonWithTimer()); 
        } 
        public EnlargeButtonWithTimer() 
        { 
            Title = "Enlarge Button with Timer"; // заголовок
            btn = new Button(); // создание кнопки
            btn.Content = "Expanding Button"; // текст в кнопке
            btn.FontSize = initFontSize; 
            btn.HorizontalAlignment = HorizontalAlignment.Center; 
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.Click += ButtonOnClick; 
            Content = btn; 
        } 
        void ButtonOnClick(object sender, RoutedEventArgs args) 
        { 
            DispatcherTimer tmr = new DispatcherTimer(); // при щелчке создает объект DispatcherTimer, который 
            tmr.Interval = TimeSpan.FromSeconds(0.1);    // каждую десятую долю секунды 
            tmr.Tick += TimerOnTick;                     // генерирует события Tick
            tmr.Start(); 
        } 
        void TimerOnTick(object sender, EventArgs args)
        { 
            btn.FontSize += 2; // увеличивает FontSize на 2 едицины каждую 0.1 секунды

            if (btn.FontSize >= maxFontSize) // если размер кнопки достигает 48 единиц
            { 
                btn.FontSize = initFontSize; // кнопка восстанавливается в исходном размере
                (sender as DispatcherTimer).Stop(); // таймер останавливается
            } 
        } 
    } 
}