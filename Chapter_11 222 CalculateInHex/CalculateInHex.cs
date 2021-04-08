using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Chapter_11_222_CalculateInHex
{
    class CalculateInHex : Window // создание класса CalculateInHex, наследника Window
    {
        // Частные поля.
        RoundedButton btnDisplay; // создание объекта класса 
        ulong numDisplay;
        ulong numFirst;
        bool bNewNumber = true;
        char chOperation = '=';
        [STAThread] // основной программный поток приложения использует однопотопную модель
        public static void Main()
        {
            Application app = new Application();
            app.Run(new CalculateInHex());
        }
        // Конструктор        
        public CalculateInHex()
        {
            Title = "Calculate in Hex"; // свойство Title определяет заголовок окна
            SizeToContent = SizeToContent.WidthAndHeight; //Возвращает или задает значение, указывающее, изменится ли автоматически размер окна в соответствии с размером его содержимого.
            ResizeMode = ResizeMode.CanMinimize;
            // Создайте сетку в качестве содержимого окна. 
            // Создание объекта Grid       
            Grid grid = new Grid(); // создание разметки
            grid.Margin = new Thickness(4);// поделить окно на 4 частей
            Content = grid;
            // Создайте пять столбцов.              
            for (int i = 0; i < 5; i++)
            {
                ColumnDefinition col = new ColumnDefinition();// Определяет свойства столбца, которые применяются к элементам Grid.
                col.Width = GridLength.Auto; //Представляет длину элементов, которые явным образом поддерживают типы единиц Star.
                grid.ColumnDefinitions.Add(col);// Определяет свойства столбца, которые применяются к элементам Grid.
            }
            // Создайте семь рядов.           
            for (int i = 0; i < 7; i++)
            {
                RowDefinition row = new RowDefinition();// Определяет специфические для строки свойства, применимые к элементам Grid.
                row.Height = GridLength.Auto;//Получает вычисляемую высоту элемента RowDefinition или задает значение GridLength строки, которая определяется RowDefinition.
                grid.RowDefinitions.Add(row);// Определяет свойства строки, которые применяются к элементам Grid.
            }         
             // Текст, который будет отображаться в кнопках.          
            string[] strButtons = { "0",
                "D", "E", "F" , "+", "&",
                "A", "B", "C" , "-", "|",
                "7", "8", "9" , "*", "^",
                "4", "5", "6" , "/", "<<",
                "1", "2", "3" , "%", ">>",
                "0", "Back",  "Equals" };
            int iRow = 0, iCol = 0;
            // Создайте кнопки.            
            foreach (string str in strButtons)
            {
                // Создать RoundedButton.          
                RoundedButton btn = new RoundedButton();
                btn.Focusable = false;
                btn.Height = 32;
                btn.Margin = new Thickness(4);
                btn.Click += ButtonOnClick; // вызов действия 
                // Создать текстовый блок для дочернего элемента RoundedButton.                
                TextBlock txt = new TextBlock(); // Предоставляет легковесный элемент управления для отображения небольших объемов размещения содержимого.
                txt.Text = str; // Получает или задает текстовое содержимое элемента управления TextBlock.
                btn.Child = txt; // Присвоение текста кнопкам
                // Добавить RoundedButton в сетку.
                grid.Children.Add(btn); // добавление в родителя 
                Grid.SetRow(btn, iRow); // расположение
                Grid.SetColumn(btn, iCol); // расположение
                // Особая обработка для кнопки Display            
                if (iRow == 0 && iCol == 0)
                {
                    btnDisplay = btn;
                    btn.Margin = new Thickness(4, 4, 4, 6);
                    Grid.SetColumnSpan(btn, 5);
                    iRow = 1;
                }
                // А так же для кнопок Back и Equals.                 
                else if (iRow == 6 && iCol > 0)
                {
                    Grid.SetColumnSpan(btn, 2);
                    iCol += 2;
                }
                // Для всех остальных кнопок.                
                else
                {
                    btn.Width = 32;
                    if (0 == (iCol = (iCol + 1) % 5))
                        iRow++;
                }
            }
        }
        // Click обработчик событий
        void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            // Получить нажатую кнопку.            
            RoundedButton btn = args.Source as RoundedButton;
            if (btn == null) return;
            // Получите текст кнопки и первый символ.        
            string strButton = (btn.Child as TextBlock).Text;
            char chButton = strButton[0];
            // Некоторые особые случаи..             
            if (strButton == "Equals")
                chButton = '=';
            if (btn == btnDisplay)
                numDisplay = 0;
            else if (strButton == "Back")
                numDisplay /= 16;
            // Шестнадцатеричные цифры.           
            else if (Char.IsLetterOrDigit(chButton))
            {
                if (bNewNumber)
                {
                    numFirst = numDisplay;
                    numDisplay = 0;
                    bNewNumber = false;
                }
                if (numDisplay <= ulong.MaxValue >> 4)
                    numDisplay = 16 * numDisplay + (ulong)(chButton -
                        (Char.IsDigit(chButton) ? '0' : 'A' - 10));
            }             
            // Рабочкий режим.            
            else
            {
                if (!bNewNumber)
                {
                    switch (chOperation)
                    {
                        case '=':
                            break;
                        case '+':
                            numDisplay = numFirst + numDisplay;
                            break;
                        case '-':
                            numDisplay = numFirst - numDisplay;
                            break;
                        case '*':
                            numDisplay = numFirst * numDisplay;
                            break;
                        case '&':
                            numDisplay = numFirst & numDisplay;
                            break;
                        case '|':
                            numDisplay = numFirst | numDisplay;
                            break;
                        case '^':
                            numDisplay = numFirst ^ numDisplay;
                            break;
                        case '<':
                            numDisplay = numFirst << (int)numDisplay;
                            break;
                        case '>':
                            numDisplay = numFirst >> (int)numDisplay;
                            break;
                        case '/':
                            numDisplay =
                                numDisplay != 0 ? numFirst / numDisplay :
                                ulong.MaxValue;
                            break;
                        case '%':
                            numDisplay =
                                numDisplay != 0 ? numFirst % numDisplay :
                                ulong.MaxValue;
                            break;
                        default:
                            numDisplay = 0;
                            break;
                    }
                }
                bNewNumber = true;
                chOperation = chButton;
            }
            // Форматирование вывода.  
            TextBlock text = new TextBlock(); // Предоставляет легковесный элемент управления для отображения небольших объемов размещения содержимого.
            text.Text = String.Format("{0:X}", numDisplay);// Предоставляет легковесный элемент управления для отображения небольших объемов размещения содержимого.
            btnDisplay.Child = text; // добавление текста в дисплей 
        }
        protected override void OnTextInput(TextCompositionEventArgs args)
        {
            base.OnTextInput(args);
            if (args.Text.Length == 0)
                return;
            // Получение нажатой клавиши
            char chKey = Char.ToUpper(args.Text[0]);
            // Перебор кнопок             
            foreach (UIElement child in (Content as Grid).Children)
            {
                RoundedButton btn = child as RoundedButton;
                string strButton = (btn.Child as TextBlock).Text;
                // Грязная логика для проверки соответствия кнопки.               
                if ((chKey == strButton[0] && btn != btnDisplay &&
                    strButton != "Equals" && strButton != "Back") ||
                    (chKey == '=' && strButton == "Equals") ||
                    (chKey == '\r' && strButton == "Equals") ||
                    (chKey == '\b' && strButton == "Back") ||
                    (chKey == '\x1B' && btn == btnDisplay))
                {
                    // Имитация события щелчка для обработки нажатия клавиши.                    
                    RoutedEventArgs argsClick =
                        new RoutedEventArgs(RoundedButton.ClickEvent, btn);
                    btn.RaiseEvent(argsClick);
                    // Сделайте так, чтобы кнопка выглядела так, как будто она нажата.                  
                    btn.IsPressed = true;
                    // Установите таймер на кнопку распаковки.
                    DispatcherTimer tmr = new DispatcherTimer();
                    tmr.Interval = TimeSpan.FromMilliseconds(100);
                    tmr.Tag = btn;
                    tmr.Tick += TimerOnTick;
                    tmr.Start();
                    args.Handled = true;
                }
            }
        }
        void TimerOnTick(object sender, EventArgs args)
        {
            // Отпустите кнопку.          
            DispatcherTimer tmr = sender as DispatcherTimer;
            RoundedButton btn = tmr.Tag as RoundedButton;
            btn.IsPressed = false;
            // Отключите время и удалите обработчик событий.            
            tmr.Stop();
            tmr.Tick -= TimerOnTick;
        }
    }
}

