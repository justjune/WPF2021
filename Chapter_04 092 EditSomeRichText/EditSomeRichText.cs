using Microsoft.Win32; 
using System; 
using System.IO;
using System.Windows; 
using System.Windows.Controls; 
using System.Windows.Documents; 
using System.Windows.Input;
using System.Windows.Media; 

namespace EditSomeRichText
{
    public class EditSomeRichText : Window // класс EditSomeRichText - наследник класса Window, содержащий точку входа в программу
    {
        private RichTextBox txtBox; // элемент, содержимое которого всегда явлется текстом, к нему можно применять разное форматирование 
        private string strFilter = "Document files (*.xaml)|*.xaml|All files (*.*)|*.*"; // строка фильтра, содержащая типы файлов

        [STAThread] // основной программный поток приложения использует однопоточную модель
        public static void Main()
        {
            Application app = new Application(); // создаем объект класса, инкапсулирующего функции WPF, относящиеся к приложению
            app.Run(new EditSomeRichText());  // запускаем приложение WPF, передавая в качестве аргумента динамически выделенный объект окна EditSomeRichText, 
                                              // благодаря чему метод Run организует для него вызов метода Show
        }

        public EditSomeRichText() // конструктор класса EditSomeRichText  ("макет" окна)
        {
            Title = "Edit Some Rich Text"; // заголовок
            txtBox = new RichTextBox(); // создаём элемент, содержимое которого всегда явлется текстом, к нему можно применять разное форматирование 
            txtBox.VerticalScrollBarVisibility /*указываем способ отображения вертикальной полосы прокрутки*/ = ScrollBarVisibility.Auto; 
            // Объект ScrollBar отображается и измерение объекта ScrollViewer применяется к содержимому, когда окно просмотра не может отобразить все содержимое
            Content = txtBox; //делаем txtBox содержимым окна
            txtBox.Focus(); // вызывается Focus метод для установки фокуса на txtBox
        }

        protected override void OnPreviewTextInput(TextCompositionEventArgs args) // переопределяем этот метод, чтобы добавить для класса обработчик события PreviewTextInput

        {
            if (args.ControlText.Length > 0 && args.ControlText[0] == '\x0F') // если длина строки > 0 и шестнадцатиричный код её первого символа = '\x0F'
            {
                OpenFileDialog dlg = new OpenFileDialog(); // создаем диалоговое окно, позволяющее пользователю задать имя файла для одного или нескольких открываемых файлов
                dlg.CheckFileExists = true; // задаем значение, указывающее, отображается ли в диалоговом окне предупреждение, если пользователь указывает несуществующее имя файла
                dlg.Filter = strFilter; // задаем строку фильтра, определяющую, какие типы файлов отображаются в диалоговом окне OpenFileDialog

                if ((bool)dlg.ShowDialog(this))
                {
                    FlowDocument flow = txtBox.Document; // FlowDocument позволет форматировать содержимое txtBox.Document с помощью дополнительных возможностей работы с документами, таких как разбивка на страницы и столбцы
                    TextRange range = new TextRange(flow.ContentStart, flow.ContentEnd); // инициализируем новый экземпляр класса TextRange, принимая две указанных позиции TextPointer в качестве начальной и конечной позиций для нового интервала
                    Stream strm = null;

                    try
                    {
                        strm = new FileStream(dlg.FileName, FileMode.Open); // Класс FileStream представляет возможности по считыванию из файла и записи в файл
                                                                            // dlg.FileName - путь к файлу
                                                                            // FileMode.Open - открывает файл. Если файл не существует, выбрасывается исключение
                        range.Load(strm, DataFormats.Xaml); // загружает текущее выделение в формате Xaml данных из потока strm 
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, Title); // отображает окно с сообщением исключения и заголовком
                    }
                    finally
                    {
                        if (strm != null)
                            strm.Close();
                    }
                }
                args.Handled = true; // задаем значение, обозначающее текущее состояние обработки события
            }

            if (args.ControlText.Length > 0 && args.ControlText[0] == '\x13') // если длина строки > 0 и шестнадцатиричный код её первого символа = '\x13'
            {
                SaveFileDialog dlg = new SaveFileDialog(); // запрашивает у пользователя местоположение для сохранения файла
                dlg.Filter = strFilter; // задаем строку фильтра, определяющую, какие типы файлов отображаются в диалоговом окне SaveFileDialog

                if ((bool)dlg.ShowDialog(this))
                {
                    FlowDocument flow = txtBox.Document; // FlowDocument позволет форматировать содержимое txtBox.Document с помощью дополнительных возможностей работы с документами, таких как разбивка на страницы и столбцы
                    TextRange range = new TextRange(flow.ContentStart, flow.ContentEnd); // инициализируем новый экземпляр класса TextRange, принимая две указанных позиции TextPointer в качестве начальной и конечной позиций для нового интервала.

                    Stream strm = null;

                    try
                    {
                        strm = new FileStream(dlg.FileName, FileMode.Create); // Класс FileStream представляет возможности по считыванию из файла и записи в файл.
                                                                              // dlg.FileName - путь к файлу
                                                                              // FileMode.Open - открывает файл. Если файл не существует, выбрасывается исключение
                        range.Save(strm, DataFormats.Xaml); // Сохраняет текущее выделение в формате Xaml данных из потока strm 
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, Title); // Отображает окно с сообщением исключения и заголовком
                    }
                    finally
                    {
                        if (strm != null)
                            strm.Close();
                    }
                }
                args.Handled = true; // задаем значение, обозначающее текущее состояние обработки события
            }
            base.OnPreviewTextInput(args); // ключевое слово base используется для вызова метода из базового класса
        }
    }
}