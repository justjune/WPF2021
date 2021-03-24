using System;
using System.ComponentModel;
using System.IO;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EditSomeText
{
    class EditSomeText : Window
    {
        private static string strFileName = Path.Combine(
 Environment.GetFolderPath(
 Environment.SpecialFolder
                                                                                           .LocalApplicationData),
                "Petzold\\EditSomeText\\EditSomeText.txt"); // создаем файл через комбинацию пути до папки AppData и строки "Petzold//..."

        private TextBox txtBox; // создаем приватный обьект типа TextBox

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new EditSomeText());
        }

        public EditSomeText()
        {
            Title = "Edit Some Text";

            txtBox = new TextBox(); // создаем текстбокс в котором можно будет вводить текст
            txtBox.AcceptsReturn = true; // задаем что будет происходить при нажатии на Enter
            txtBox.TextWrapping = TextWrapping.Wrap; // задаем перенос строки если текст дойдет до правого края окна
            txtBox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto; // задаем видимость полосы прокрутки (будет видна если текст по вертикали не будет умещаться в окне)
            txtBox.KeyDown += TxtBoxOnKeyDown; // ф-ия печати текста
            Content = txtBox; // помещаем этот текстбокс в контент окна

            try
            {
                txtBox.Text = File.ReadAllText(strFileName);
            }
            catch
            {
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(strFileName));
                File.WriteAllText(strFileName, txtBox.Text);
            }
            catch (Exception exc) //если при закрытии окна файл не может быть сохранен выводится окно с этой информацией и предложение все равно закрыть программу
            {
                MessageBoxResult result =
                        MessageBox.Show("File could not be saved: " +
                                        exc.Message +
                                        "\nClose program anyway?", Title, MessageBoxButton.YesNo,
                                MessageBoxImage.Exclamation);
                e.Cancel = (result == MessageBoxResult.No);
            }
        }

        private void TxtBoxOnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.Key == Key.F5) // если будет нажата f5 то печатается дата и время
            {
                txtBox.SelectedText = DateTime.Now.ToString();
                txtBox.CaretIndex = txtBox.SelectionStart + txtBox.SelectionLength;
            }
        }
    }
}