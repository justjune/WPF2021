using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.CommandTheMenu
{
    public class CommandTheMenu : Window
    {
        TextBlock text;    // Получает или задает текстовое содержимое элемента управления TextBlock     
        [STAThread]
        public static void Main()
        {
            Application app = new Application(); // Инициализирует новый экземпляр класса Application            
            app.Run(new CommandTheMenu());    // Запускает стандартный цикл обработки сообщений приложения в текущем потоке     
        }
        public CommandTheMenu()
        {
            Title = "Command the Menu";

            // Создание объекта DockPanel
            DockPanel dock = new DockPanel();
            Content = dock;

            // Создание меню, пристыкованного у верхнего края окна
            Menu menu = new Menu();
            dock.Children.Add(menu);
            DockPanel.SetDock(menu, Dock.Top);

            // Создание объекта TextBlock, заполняющего оставшуюся площадь
            text = new TextBlock();
            text.Text = "Sample clipboard text";  // Пример текста буфера обмена           
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            text.FontSize = 32; // 24 пункта
            text.TextWrapping = TextWrapping.Wrap;
            dock.Children.Add(text);

            // Создаёт меню Edit
            MenuItem itemEdit = new MenuItem();
            itemEdit.Header = "_Edit";
            menu.Items.Add(itemEdit);

            // Создание команд меню Edit
            MenuItem itemCut = new MenuItem();
            itemCut.Header = "Cu_t"; // вырезать
            itemCut.Command = ApplicationCommands.Cut;
            itemEdit.Items.Add(itemCut);
            MenuItem itemCopy = new MenuItem();
            itemCopy.Header = "_Copy"; // копировать
            itemCopy.Command = ApplicationCommands.Copy;
            itemEdit.Items.Add(itemCopy);
            MenuItem itemPaste = new MenuItem();
            itemPaste.Header = "_Paste"; // вставить
            itemPaste.Command = ApplicationCommands.Paste;
            itemEdit.Items.Add(itemPaste);
            MenuItem itemDelete = new MenuItem();
            itemDelete.Header = "_Delete"; // удалить
            itemDelete.Command = ApplicationCommands.Delete;
            itemEdit.Items.Add(itemDelete);

            // Включение привязок команд в коллекцию окна
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Cut,
                CutOnExecute, CutCanExecute)); // привязка связывает команду с событиями Execute и CanExecute 
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Copy,
                CopyOnExecute, CutCanExecute));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste,
                PasteOnExecute, PasteCanExecute));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Delete,
                DeleteOnExecute, CutCanExecute));
        }

        // управление блокировкой осуществляется через обработчики CanExecute
        // свойству CanExecute объекта CanExecuteRoutedEventArgs задаётся значение true или false
        void CutCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = text.Text != null && text.Text.Length > 0;
        }
        void PasteCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = Clipboard.ContainsText();
        }

        void CutOnExecute(object sender, ExecutedRoutedEventArgs args) // определение CutOnExecute
        {
            ApplicationCommands.Copy.Execute(null, this); // Копирует данные
            ApplicationCommands.Delete.Execute(null, this); // Удаляет данные
        }
        void CopyOnExecute(object sender, ExecutedRoutedEventArgs args) // определение CopyOnExecute
        {
            Clipboard.SetText(text.Text); // Очищает буфер обмена и добавляет в него текстовые данные
        }
        void PasteOnExecute(object sender, ExecutedRoutedEventArgs args) // определение PasteOnExecute
        {
            text.Text = Clipboard.GetText(); // Добавляет текстовые данные из буфера обмена
        }
        void DeleteOnExecute(object sender, ExecutedRoutedEventArgs args) // определение DeleteOnExecute
        {
            text.Text = null;   // Удаляет текстовые данные (ключевое слово null является литералом, представляющим пустую ссылку, которая не ссылается на объект)
        }
    }
}