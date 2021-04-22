using Chapter_13_295_SelectColorFromWheel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Chapter_19_494_UseCustomClass
{
    public partial class UseCustomClass : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new UseCustomClass());
        }
        public UseCustomClass()
        {
            InitializeComponent();
        }

        void ColorGridBoxOnSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            ColorWheel clrbox = args.Source as ColorWheel;
            Background = (Brush)clrbox.SelectedValue;
        }
    }
}