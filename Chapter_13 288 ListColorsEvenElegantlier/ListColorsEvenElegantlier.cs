using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Chapter_13_288_ListColorsEvenElegantlier
{
    class ListColorsEvenElegantlier : Window // создание класса ListColorsEvenElegantlier, наследника Window
    {
        [STAThread] // основной программный поток приложения использует однопотопную модель
        public static void Main() 
        { 
            Application app = new Application();
            app.Run(new ListColorsEvenElegantlier());
        }
        public ListColorsEvenElegantlier()
        {
            Title = "List Colors Even Elegantlier";   // // свойство Title определяет заголовок окна  
            // Создайте DataTemplate для элементов. 
            DataTemplate template = new  DataTemplate(typeof(NamedBrush));  
            // Создайте FrameworkElementFactory на основе StackPanel.      
            FrameworkElementFactory factoryStack =                   
                new  FrameworkElementFactory(typeof(StackPanel));   
            factoryStack.SetValue(StackPanel .OrientationProperty,  
                Orientation.Horizontal);            
            // Сделайте это корнем визуального дерева DataTemplate.
            template.VisualTree = factoryStack;          
            // Создайте FrameworkElementFactory на основе Rectangle. 
            FrameworkElementFactory factoryRectangle =             
                new  FrameworkElementFactory(typeof(Rectangle)); // Поддерживает создание шаблонов.   
            factoryRectangle.SetValue(Rectangle .WidthProperty, 16.0);   // Задает значение свойства зависимостей.
            factoryRectangle.SetValue(Rectangle .HeightProperty, 16.0);  // Задает значение свойства зависимостей. 
            factoryRectangle.SetValue(Rectangle .MarginProperty, new Thickness(2)); //Задает значение свойства зависимостей.   
            factoryRectangle.SetValue(Rectangle .StrokeProperty,          
                SystemColors.WindowTextBrush);   //Задает значение свойства зависимостей.   
            factoryRectangle.SetBinding(Rectangle .FillProperty,      
                new  Binding("Brush"));   // Задает привязку данных для свойства.      
            // Добавьте его в StackPanel.
            factoryStack.AppendChild (factoryRectangle);      
            // Создайте FrameworkElementFactory на основе TextBlock.
            FrameworkElementFactory factoryTextBlock =                 
                new  FrameworkElementFactory(typeof(TextBlock)); // Поддерживает создание шаблонов.   
            factoryTextBlock.SetValue(TextBlock .VerticalAlignmentProperty,  
                VerticalAlignment.Center);  // Задает значение свойства зависимостей.      
            factoryTextBlock.SetValue(TextBlock .TextProperty,    
                new  Binding("Name"));  // Задает значение свойства зависимостей.      
            // Добавьте его в StackPanel.       
            factoryStack.AppendChild (factoryTextBlock);    // Добавляет дочернюю фабрику к данной фабрике.
            // Создайте ListBox в качестве содержимого окна.   
            ListBox lstbox = new ListBox();    // Содержит список элементов для выбора.       
            lstbox.Width = 150;   // Получение или установка ширины элемента.(Унаследовано от FrameworkElement)
            lstbox.Height = 150;  // Получает или задает предлагаемую высоту элемента.(Унаследовано от FrameworkElement) 
            Content = lstbox;     // добавление     
            // Установите свойство ItemTemplate в шаблон, созданный выше.  
            lstbox.ItemTemplate = template;     
            // Set the ItemsSource to the array of  NamedBrush objects.   
            lstbox.ItemsSource = NamedBrush.All;     
            // Установите ItemsSource в массив объектов NamedBrush. 
            lstbox.SelectedValuePath = "Brush";     // Возвращает или задает путь, используемый для получения SelectedValue из SelectedItem.(Унаследовано от Selector)
            lstbox.SetBinding(ListBox .SelectedValueProperty, "Background");  // Прикрепляет привязку к данному элементу на основе указанного имени исходного свойства в виде классификационного пути к источнику данных.(Унаследовано от FrameworkElement)       
            lstbox.DataContext = this;        // Получает или задает контекст данных для элемента, участвующего в привязке данных.(Унаследовано от FrameworkElement)
        }    
    }

}
