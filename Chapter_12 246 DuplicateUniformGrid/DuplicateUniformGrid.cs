using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;


namespace Chapter_12_246_DuplicateUniformGrid {
  internal class UniformGridAlmost : Panel {
    // Public static readonly dependency properties
    public static readonly DependencyProperty ColumnsProperty;

    // Static constructor to create dependency property
    static UniformGridAlmost() {
      ColumnsProperty = DependencyProperty.Register(
          "Columns", typeof(int), typeof(UniformGridAlmost), 
          new FrameworkPropertyMetadata(1, FrameworkPropertyMetadataOptions.AffectsMeasure));
    }

    // Columns property.
    public int Columns {
      set => SetValue(ColumnsProperty, value);
      get => (int) GetValue(ColumnsProperty);
    }

    // Read-Only Rows property
    private int Rows => (InternalChildren.Count + Columns - 1) / Columns;

    // Override of MeasureOverride apportions space.
    protected override Size MeasureOverride(Size sizeAvailable) {
      // Calculate a child size based on uniform rows and columns
      var sizeChild = new Size(sizeAvailable.Width / Columns, sizeAvailable.Height / Rows);

      // Variables to accumulate maximum widths and heights.
      double maxWidth = 0, maxHeight = 0;
      
      // Calculate the max size
      foreach (UIElement child in InternalChildren) {
        // Call Measure for each child ...
        child.Measure(sizeChild);

        // ... and then examine DesiredSize property of child
        maxWidth = Math.Max(maxWidth, child.DesiredSize.Width);
        maxHeight = Math.Max(maxHeight, child.DesiredSize.Height);
      }

      // Now calculate a desired size for the grid itself
      return new Size(Columns * maxWidth, Rows * maxHeight);
    }

    // Override of ArrangeOverride positions children -> same size for all child (rectangles) in our grid layout
    protected override Size ArrangeOverride(Size sizeFinal) {
      // Calculate a child size based on uniform rows and columns.
      var sizeChild = new Size(sizeFinal.Width / Columns, sizeFinal.Height / Rows);

      for (var index = 0; index < InternalChildren.Count; index++) {
        var row = index / Columns;
        var col = index % Columns;

        // Calculate a rectangle for each child within sizeFinal ...
        var rectChild = new Rect(new Point(col * sizeChild.Width, row * sizeChild.Height), sizeChild);

        // ... and call Arrange for that child.
        InternalChildren[index].Arrange(rectChild);
      }

      return sizeFinal;
    }
  }


  internal class DuplicateUniformGrid : Window {
    [STAThread]
    public static void Main() => new Application().Run(new DuplicateUniformGrid());

    private DuplicateUniformGrid() {
      Title = "Duplicate Uniform Grid";

      // Create UniformGridAlmost instance as content of window
      var uniformGrid = new UniformGridAlmost {Columns = 5};
      Content = uniformGrid;

      // Fill UniformGridAlmost with randomly-sized buttons
      var rand = new Random();

      for (var index = 0; index < 48; index++) {
        var btn = new Button {Name = "Button" + index};
        btn.Content = btn.Name;
        btn.FontSize += rand.Next(10);
        uniformGrid.Children.Add(btn);
      }
      
      // Bind event handler to each button
      AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ButtonOnClick));
    }
    
    // Simple event handler -> if we click on Button instance -> message box with it's number == name
    private void ButtonOnClick(object sender, RoutedEventArgs args) {
      if (args.Source is Button btn) MessageBox.Show(btn.Name + " has been clicked", Title);
    }
  }
}