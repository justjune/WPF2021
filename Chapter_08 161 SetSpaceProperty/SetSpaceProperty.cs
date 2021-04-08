using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Chapter_08_161_SetSpaceProperty {
  // Class SpaceButton is not my but has to be included in the program for it to work properly 
  public class SpaceButton : Button {
    private string _txt;
    
    // Public field with getter and setter available
    public string Text {
      // Setter -> set the value by calling the SpaceOutText method
      // SpaceOutText add spaces between letters and set the result to Content property 
      set { _txt = value; Content = SpaceOutText(_txt); }
      get => _txt;                                         // Getter -> return the set value
    }
    
    
    public static readonly DependencyProperty SpaceProperty;

    public int Space {
      set => SetValue(SpaceProperty, value);  // Setter -> set the value
      get => (int) GetValue(SpaceProperty);   // Getter -> return the set value
    } // Static constructor.

    static SpaceButton() {
      // Define the metadata.
      var metadata = new FrameworkPropertyMetadata {DefaultValue = 1, AffectsMeasure = true, Inherits = true};
      metadata.PropertyChangedCallback += OnSpacePropertyChanged;

      // Register the DependencyProperty.
      SpaceProperty = DependencyProperty.Register(
        "Space", typeof(int), typeof(SpaceButton), metadata, ValidateSpaceValue
      );
    }

    // Method for spaces value validation (if x < 0 => false)
    private static bool ValidateSpaceValue(object obj) => (int) obj >= 0;

    // Special method that is called at each SpaceProperty changing
    private static void OnSpacePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args) {
      // Method to insert spaces in the text
      if (obj is SpaceButton btn) btn.Content = btn.SpaceOutText(btn._txt);
    }
    
    // Method returns the spaced string value that will be add into Content property
    private string SpaceOutText(string str) {
      if (str == null) return null;
      var build = new StringBuilder();
      foreach (var ch in str) build.Append(ch + new string(' ', Space));
      return build.ToString();
    }
  }
  
  // Class SpaceWindow is not my but has to be included in the program for it to work properly
  public class SpaceWindow : Window {
    public static readonly DependencyProperty SpaceProperty;
    // Protected field with getter and setter available
    protected int Space {
      set => SetValue(SpaceProperty, value);  // Setter -> set the value
      get => (int) GetValue(SpaceProperty);   // Getter -> return the set value   
    }
    
    // Static constructor.
    static SpaceWindow() {
      // Define metadata.
      var metadata = new FrameworkPropertyMetadata {Inherits = true};
      
      // Add owner to SpaceProperty and  override metadata.
      SpaceProperty = SpaceButton.SpaceProperty.AddOwner(typeof(SpaceWindow));
      SpaceProperty.OverrideMetadata(typeof(SpaceWindow), metadata);
    }
  }
  
  // ---------------------------------- My part of program starts here ---------------------------------- \\
  public class SetSpaceProperty : SpaceWindow {
    [STAThread]
    public static void Main() => new Application().Run(new SetSpaceProperty());  // Entry point

    private SetSpaceProperty() {
      Title = "Set Space Property";                     // Window title
      SizeToContent = SizeToContent.WidthAndHeight;     // Automatically resize height and width relative to content
      ResizeMode = ResizeMode.CanMinimize;              // We can only hide the window (_ button) but can't open in fullscreen
      int[] iSpaces = {0, 1, 2};                        // Array of integers
      var grid = new Grid();                            // Grid layout implementation
      Content = grid;                                   // Set the Content of the window as a grid layout
      
      // Add 2 rows into grid layout with height set to auto
      for (var i = 0; i < 2; i++) 
        grid.RowDefinitions.Add(new RowDefinition {Height = GridLength.Auto});
      
      // Add 3 columns into grid layout with width set to auto
      for (var i = 0; i < iSpaces.Length; i++)
        grid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Auto});
      
      // Add 3 buttons into first row of grid layout
      for (var i = 0; i < iSpaces.Length; i++) {
        var btn = new SpaceButton {
          Text = "Set window Space to " + iSpaces[i],        // Text
          Tag = iSpaces[i],                                  // Tag to be able to find this button
          HorizontalAlignment = HorizontalAlignment.Center,  // Horizontal alignment 
          VerticalAlignment = VerticalAlignment.Center       // Vertical alignment
        };
        btn.Click += WindowPropertyOnClick;                  // Set the event handler to each button object
        grid.Children.Add(btn);                              // Add created button to grid
        Grid.SetRow(btn, 0);                           // Set the position in grid for this button
        Grid.SetColumn(btn, i);
        
        // Absolutely the same actions for the second grid row
        btn = new SpaceButton {
          Text = "Set button Space to " + iSpaces[i],
          Tag = iSpaces[i],
          HorizontalAlignment = HorizontalAlignment.Center,
          VerticalAlignment = VerticalAlignment.Center
        };
        btn.Click += ButtonPropertyOnClick;
        grid.Children.Add(btn);
        Grid.SetRow(btn, 1);
        Grid.SetColumn(btn, i);
      }
    }
    
    // Method will check if button is the SpaceButton object and set the window size based on button.tag value (int) set in for 
    private void WindowPropertyOnClick(object sender, RoutedEventArgs args) {
      if (args.Source is SpaceButton btn) Space = (int) btn.Tag;
    }
    
    // Method will check if button is the SpaceButton object and set the button space property based on button.tag value (int) set in for
    private static void ButtonPropertyOnClick(object sender, RoutedEventArgs args) {
      // Space property => spaces between letters in button Content
      if (args.Source is SpaceButton btn) btn.Space = (int) btn.Tag;
    }
  }
}