using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Chapter_13_295_SelectColorFromWheel {
  public class SelectColorFromWheel : Window {
    [STAThread]
    public static void Main() => new Application().Run(new SelectColorFromWheel());

    private SelectColorFromWheel() {
      Title = $"Select Color from Wheel";            // Title of the window
      SizeToContent = SizeToContent.WidthAndHeight;  // Gain ability to resize window size in relation to the content

      // Create StackPanel as content of the window
      var stack = new StackPanel {Orientation = Orientation.Horizontal};
      Content = stack;

      // Create do-nothing button to test tabbing {- Button add 1 -}
      var btn = new Button {
        Content = "Do-nothing button\nto test tabbing",      // Button text
        Margin = new Thickness(48),             // Spaces outside the button 
        HorizontalAlignment = HorizontalAlignment.Center,    // Center horizontally
        VerticalAlignment = VerticalAlignment.Center         // Center vertically
      };
      stack.Children.Add(btn);                               // Add button to the stack panel

      // Create ColorWheel control (same as {- Button add 1 -})
      var clrwheel = new ColorWheel {
        Margin = new Thickness(24),
        HorizontalAlignment = HorizontalAlignment.Center,
        VerticalAlignment = VerticalAlignment.Center
      };
      stack.Children.Add(clrwheel);
              // Bind Background of window to selected value of ColorWheel
              clrwheel.SetBinding(ColorWheel.SelectedValueProperty, "Background");
      clrwheel.DataContext = this;

      // Create another do-nothing button (same as {- Button add 1 -})
      btn = new Button {
        Content = "Do-nothing button\nto test tabbing",
        Margin = new Thickness(24),
        HorizontalAlignment = HorizontalAlignment.Center,
        VerticalAlignment = VerticalAlignment.Center
      };
      stack.Children.Add(btn);
    }
  }


  public class ColorWheel : ListBox {
    public ColorWheel() {
      // Define the ItemsPanel template
      var factoryRadialPanel = new FrameworkElementFactory(typeof(RadialPanel));
      ItemsPanel = new ItemsPanelTemplate(factoryRadialPanel);

      // Create the DataTemplate for the items
      var template = new DataTemplate(typeof(Brush));
      ItemTemplate = template;

      // Create a FrameworkElementFactory based on Rectangle with specific properties (like width, margin, etc.)
      var elRectangle = new FrameworkElementFactory(typeof(Rectangle));
      elRectangle.SetValue(Rectangle.WidthProperty, 4.0);
      elRectangle.SetValue(Rectangle.HeightProperty, 12.0);
      elRectangle.SetValue(Rectangle.MarginProperty,
        new Thickness(1, 8, 1, 8));
      elRectangle.SetBinding(Rectangle.FillProperty, new Binding(""));

      // Use that factory for the visual tree
      template.VisualTree = elRectangle;

      // Set the items in the ListBox
      var props = typeof(Brushes).GetProperties();
      
      // Add color selection into our panel
      foreach (var prop in props) Items.Add((Brush) prop.GetValue(null, null));
    }
  }
}