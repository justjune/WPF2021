using System;
using System.Windows;
using System.Windows.Controls;

namespace Сhapter05_097_StackTenButtons
{
    class StackTenButtons : Window
    {

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new StackTenButtons());
        }
        public StackTenButtons() // Конструктор класса StackTenButtons
        {
            Title = "Stack ten buttons"; // Название приложения

            StackPanel stack = new StackPanel(); // Создание нового вертикального ряда
            Content = stack;
            Random rand = new Random(); // Случайная переменная
            for (int i = 0; i < 10; i++)
            {
                Button btn = new Button(); // Создает новую кнопку
                btn.Name = ((char)('A' + i)).ToString(); // Алфавитное перечисление A,B,C...
                btn.FontSize += rand.Next(10); // Задает случайный размер кнопки
                btn.Content = "Button" + btn.Name + " says Click me"; // Дает название кнопке
                btn.Click += ButtonOnClick; // Отслеживает нажатие по кнопке
                stack.Children.Add(btn); // Добавляет кнопку в приложение
            };
        }

        void ButtonOnClick(object sender, RoutedEventArgs args) // Функция вызываетмая при нажатии на кнопку
        {
            Button btn = args.Source as Button; // Создает новое окно приложения
            MessageBox.Show("Button" + btn.Name + " has been clicked", "Button click"); // Добавляет текст в новое окно
        }
    }
}