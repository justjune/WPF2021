using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Chapter_11_216_EncloseElementInEllipse;

namespace Chapter_11_216_EncloseElementInEllipse {
  // Special class for rendering custom ellipse -> old, commented by other team
  public class BetterEllipse : FrameworkElement {
    // Dependency properties.
    public static readonly DependencyProperty FillProperty;
    public static readonly DependencyProperty StrokeProperty;

    public Brush Fill {
      set => SetValue(FillProperty, value);
      get => (Brush) GetValue(FillProperty);
    }

    public Pen Stroke {
      set => SetValue(StrokeProperty, value);
      get => (Pen) GetValue(StrokeProperty);
    }

    // Static constructor.
    static BetterEllipse() {
      FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(BetterEllipse),
        new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
      StrokeProperty = DependencyProperty.Register("Stroke", typeof(Pen), typeof(BetterEllipse),
        new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure));
    }

    // Override of MeasureOverride.
    protected override Size MeasureOverride(Size sizeAvailable) {
      var sizeDesired = base.MeasureOverride(sizeAvailable);
      if (Stroke != null) sizeDesired = new Size(Stroke.Thickness, Stroke.Thickness);
      return sizeDesired;
    }

    // Override of OnRender.
    protected override void OnRender(DrawingContext dc) {
      var size = RenderSize; // Adjust rendering size for width of Pen.
      if (Stroke != null) {
        size.Width = Math.Max(0, size.Width - Stroke.Thickness);
        size.Height = Math.Max(0, size.Height - Stroke.Thickness);
      }

      var point = new Point(RenderSize.Width / 2, RenderSize.Height / 2);

      // Draw the ellipse.
      dc.DrawEllipse(Fill, Stroke, point, size.Width / 2, size.Height / 2);
    }
  }
  
  // Special class for rendering custom ellipse -> old, commented by other team
  public class EllipseWithChild : BetterEllipse {
    // Public Child property.
    private UIElement _child;

    public UIElement Child {
      set {
        // Reset the previous child if exist
        if (_child != null) {
          RemoveVisualChild(_child);
          RemoveLogicalChild(_child);
        }
        
        // Strange line cause we reset the _child in previous if statement -> always true?
        if ((_child = value) == null) return;
        
        // Add the _child as a Child 
        AddVisualChild(_child);
        AddLogicalChild(_child);
      }
      get => _child;
    }
    
    // Override of VisualChildrenCount returns  1 if Child is non-null
    protected override int VisualChildrenCount => Child != null ? 1 : 0;

    // Override of GetVisualChildren returns  Child.
    protected override Visual GetVisualChild(int index) {
      if (index > 0 || Child == null) throw new ArgumentOutOfRangeException(nameof(index));
      return Child;
    }
    
    // Override of MeasureOverride calls  child's Measure method.
    protected override Size MeasureOverride(Size sizeAvailable) {
      var sizeDesired = new Size(0, 0);
      if (Stroke != null) {
        sizeDesired.Width += 2 * Stroke.Thickness;
        sizeDesired.Height += 2 * Stroke.Thickness;
        sizeAvailable.Width = Math.Max(0, sizeAvailable.Width - 2 * Stroke.Thickness);
        sizeAvailable.Height = Math.Max(0, sizeAvailable.Height - 2 * Stroke.Thickness);
      }

      if (Child == null) return sizeDesired;
      Child.Measure(sizeAvailable);
      sizeDesired.Width += Child.DesiredSize.Width;
      sizeDesired.Height += Child.DesiredSize.Height;

      return sizeDesired;
    }

    // Override of ArrangeOverride calls  child's Arrange method.
    protected override Size ArrangeOverride(Size sizeFinal) {
      if (Child == null) return sizeFinal;
      var point = new Point((sizeFinal.Width - Child.DesiredSize.Width) / 2,
        (sizeFinal.Height - Child.DesiredSize.Height) / 2);
      Child.Arrange(new Rect(point, Child.DesiredSize));

      return sizeFinal;
    }
  }
  
  // ---------------------------------- My part of program starts here ---------------------------------- \\
  internal class EncloseElementInEllipse : Window {
    [STAThread]
    // Entry point
    public static void Main() => new Application().Run(new EncloseElementInEllipse());

    private EncloseElementInEllipse() {
      Title = "Enclose Element in Ellipse";  // Set the title of the window
      //                                  Filling color               Border           Border color     Border width
      var ellipse = new EllipseWithChild {Fill = Brushes.ForestGreen, Stroke = new Pen(Brushes.Magenta, 48)};
      Content = ellipse;  // Set the ellipse as a content of a window
      
      // Text block that will be in the center of ellipse
      var text = new TextBlock {
        FontFamily = new FontFamily("Times New Roman"), FontSize = 48, Text = "Text inside ellipse"
      };
      
      // Set Child property of EllipseWithChild to TextBlock object
      ellipse.Child = text;
    }
  }
}