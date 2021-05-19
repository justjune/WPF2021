using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;


namespace Chapter_05_103_ScrollFiftyButtons {
  internal class ScrollFiftyButtons : Window {
    // Entry point as usual
    [STAThread]
    public static void Main() {
      new Application().Run(new ScrollFiftyButtons());
    }

    private ScrollFiftyButtons() {
      Title = "Scroll Fifty Buttons";
      SizeToContent = SizeToContent.Width;
      // Adding an event handler (click event) to each button
      AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(ButtonOnClick));

      // Block that allows us to use left scroll bar
      var scroll = new ScrollViewer();
      Content = scroll;

      // Block that allows us to store content in it
      // Margin - indents from outside the block while padding - indents from the inside of the block
      var stack = new StackPanel {Margin = new Thickness(5)};

      // Adding "stack" block into scroll block -> able scroll content into inner "stack block" 
      scroll.Content = stack;
      
      // Loop that ads 50 buttons into stack
      for (var i = 0; i < 50; i++) {
        var btn = new Button {Name = "Button" + (i + 1)};  // Creating a new button object with specified name
        btn.Content = btn.Name + " says  'Click me'";      // Adding some text into created button
        // Margin - indents from outside the block while padding - indents from the inside of the block
        btn.Margin = new Thickness(5);        // Adding margin to each button from all 4 sides
        stack.Children.Add(btn);                           // Adding created button into stack block
      }
    }

    // Event handler implementation
    private static void ButtonOnClick(object sender, RoutedEventArgs args) {
      // Check if we click on button
      if (args.Source is Button btn)
        // Create and show message window with the clicked button number
        MessageBox.Show(btn.Name + " has  been clicked", "Button Click");
    }
  }
}