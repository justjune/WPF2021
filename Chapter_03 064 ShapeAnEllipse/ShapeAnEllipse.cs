using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Chapter_03_xx_ShapeAnEllipse {
  internal class ShapeAnEllipse : Window {
    [STAThread]
    public static void Main() {
      new Application().Run(new ShapeAnEllipse());  // Standard program run
    }
    
    // My sub function that create a new LinearGradientBrush object and return it
    private static LinearGradientBrush CreateGradient() {
      // LinearGradient params: startColor, endColor, startPoint, endPoint
      return new LinearGradientBrush(Colors.CadetBlue, Colors.Chocolate, new Point(1, 0), new Point(0, 1));
    }
    
    // Ellipse class itself
    private ShapeAnEllipse() {
      Title = "Shape an Ellipse";
      // Fill - color inside ellipse, StrokeThickness - width of ellipse outline, Stroke - fill color of outline
      Content = new Ellipse {Fill = Brushes.AliceBlue, StrokeThickness = 24, Stroke = CreateGradient()};;
    }
  }
}