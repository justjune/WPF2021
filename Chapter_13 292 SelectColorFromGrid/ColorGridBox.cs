//--------------------------------------------- 
// ColorGridBox.cs (c) 2006 by Charles Petzold 
//---------------------------------------------
using System; using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media; 
using System.Windows.Shapes; 
namespace Petzold.SelectColorFromGrid 
{     
    class ColorGridBox : ListBox     
    { //Отображаемые цвета
        string[] strColors = 
        {
            "Black", "Brown", "DarkGreen",  "MidnightBlue",                 
            "Navy", "DarkBlue", "Indigo",  "DimGray",             
            "DarkRed", "OrangeRed", "Olive", "Green",                 
            "Teal", "Blue", "SlateGray", "Gray",             
            "Red", "Orange", "YellowGreen",  "SeaGreen",                 
            "Aqua", "LightBlue", "Violet",  "DarkGray",             
            "Pink", "Gold", "Yellow", "Lime",                 
            "Turquoise", "SkyBlue", "Plum",  "LightGray",             
            "LightPink", "Tan", "LightYellow",  "LightGreen",                 
            "LightCyan", "LightSkyBlue",  "Lavender", "White"
        };         
        
        public ColorGridBox()         
        { 
            //Определение шаблона и его включение в ListBox
            FrameworkElementFactory factoryUnigrid = new  FrameworkElementFactory(typeof(UniformGrid));             
            factoryUnigrid.SetValue(UniformGrid .ColumnsProperty, 8);             
            ItemsPanel = new ItemsPanelTemplate (factoryUnigrid); 
            
            //заполнение списка         
            foreach (string strColor in strColors)             
            { 
                //Создание объекта Rectangle и включение его в ListBox               
                Rectangle rect = new Rectangle();                 
                rect.Width = 12;                 
                rect.Height = 12;                 
                rect.Margin = new Thickness(4);                 
                rect.Fill = (Brush)                     
                typeof(Brushes).GetProperty (strColor).GetValue(null, null);                 
                Items.Add(rect); 
                
                //Создание объекта ToolTip для Rectangle
                ToolTip tip = new ToolTip();                 
                tip.Content = strColor;                 
                rect.ToolTip = tip;             
            }
            //В качестве выбранного значения выбирается свойствo fill объекта Rectangle         
            SelectedValuePath = "Fill";         
        }     
    } 
} 
