//-----------------------------------------------
// MeetTheDockers.cs (c) 2006 by Charles Petzold
//-----------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.MeetTheDockers
{
    public class MeetTheDockers : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new MeetTheDockers());
        }
        public MeetTheDockers()
        {
            Title = "Meet the Dockers"; //Заголовок окнв

            DockPanel dock = new DockPanel(); //Создаётся объект dock класса DockPanel
            Content = dock; //Атрибуту Content присваивается значение объекта dock

            Menu menu = new Menu(); //Создаётся объект menu класса Menu
            MenuItem item = new MenuItem(); //Создаётся объект item класса MenuItem
            item.Header = "Menu"; //Атрибуту Header объекта item присваивается значение "Menu"
            menu.Items.Add(item); //Добавление item в меню

            // Dock menu at top of panel.
            DockPanel.SetDock(menu, Dock.Top); //Распологаем menu в верхней панели
            dock.Children.Add(menu); //menu добавляется в дочерние элементы dock

            // Create tool bar.
            ToolBar tool = new ToolBar(); //Создаётся объект tool класса ToolBar
            tool.Header = "Toolbar"; //Атрибуту Header объекта tool присваивается значение "Toolbar"

            // Dock tool bar at top of panel.
            DockPanel.SetDock(tool, Dock.Top); //Распологаем tool в верхней панели
            dock.Children.Add(tool); //tool добавляется в дочерние элементы dock

            // Create status bar.
            StatusBar status = new StatusBar(); //Создаётся объект status класса StatusBar
            StatusBarItem statitem = new StatusBarItem(); //Создаётся объект statitem класса StatusBarItem
            statitem.Content = "Status"; //Атрибуту Content объекта statitem присваивается значение "Status"
            status.Items.Add(statitem); //Добавление statitem в status

            // Dock status bar at bottom of panel.
            DockPanel.SetDock(status, Dock.Bottom); //Распологаем status в нижней панели
            dock.Children.Add(status); //status добавляется в дочерние элементы dock

            // Create list box.
            ListBox lstbox = new ListBox(); //Создаётся объект lstbox класса ListBox
            lstbox.Items.Add("List Box Item"); //Добавление строки "List Box Item" в меню

            // Dock list box at left of panel.
            DockPanel.SetDock(lstbox, Dock.Left); //Распологаем lstbox в левой панели
            dock.Children.Add(lstbox); //lstbox добавляется в дочерние элементы dock

            // Create text box.
            TextBox txtbox = new TextBox(); //Создаётся объект txtbox класса ListBox
            txtbox.AcceptsReturn = true; //Если атрибут AcceptsReturn = true, то при нажатии Enter создаётся новая строка

            // Add text box to panel & give it input focus.
            dock.Children.Add(txtbox); //txtbox добавляется в дочерние элементы dock
            txtbox.Focus(); /*Возвращает значение, указывающее, имеется ли на элементе управления фокус ввода. 
                              Значение true, если фокус находится на элементе управления; в противном случае — значение false.
                              Фокус, фокус ввода — концептуальное понятие в построении графического пользовательского интерфейса, 
                              означающее наличие у определённого элемента этого интерфейса исключительного права принимать клавиатурный ввод.*/
        }
    }
}