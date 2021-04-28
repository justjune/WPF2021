using Petzold.SelectColorFromGrid;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.SelectColorFromMenuGrid
{
    public class SelectColorFromMenuGrid : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new SelectColorFromMenuGrid());
        }
        public SelectColorFromMenuGrid()
        {
            Title = "Select Color from Menu Grid"; //заголовок окна

            DockPanel dock = new DockPanel(); //создать панель
            Content = dock; //показывать панель

            // Create Menu docked at top.
            Menu menu = new Menu(); //создать меню
            dock.Children.Add(menu); //добавить меню в дочение элементы панели
            DockPanel.SetDock(menu, Dock.Top); //создать верхнюю панель

            // Create TextBlock filling the rest.
            TextBlock text = new TextBlock(); //создать блок текста
            text.Text = Title; //блок наполняется текстом из заголовка окна 
            text.FontSize = 32; //размер шрифта (ебал)
            text.TextAlignment = TextAlignment.Center; //выравнивание текста по центру
            dock.Children.Add(text); //добавить текст в дочение элементы панели

            MenuItem itemColor = new MenuItem(); //создать объект класса MenuItem
            itemColor.Header = "_Color"; //заголовок itemColor
            menu.Items.Add(itemColor); //добавить itemColor в меню

            MenuItem itemForeground = new MenuItem(); //создать объект класса MenuItem
            itemForeground.Header = "_Foreground"; //заголовок itemColor
            itemColor.Items.Add(itemForeground); //добавить itemColor в меню

            ColorGridBox clrbox = new ColorGridBox(); //создать объект класса ColorGridBox
            clrbox.SetBinding(ColorGridBox.SelectedValueProperty, "Foreground");
            clrbox.DataContext = this;
            itemForeground.Items.Add(clrbox); //добавить clrbox в меню

            MenuItem itemBackground = new MenuItem(); //создать объект класса MenuItem
            itemBackground.Header = "_Background"; //заголовок itemBackground
            itemColor.Items.Add(itemBackground); //добавить itemColor в меню

            clrbox = new ColorGridBox(); //создать объект класса ColorGridBox
            clrbox.SetBinding(ColorGridBox.SelectedValueProperty, "Background");
            clrbox.DataContext = this;
            itemBackground.Items.Add(clrbox); //добавить clrbox в меню
        }
    }
}
