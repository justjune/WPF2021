using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chapter_04_xxx_NavigateTheWeb {
  public class NavigateTheWeb : Window {
    private readonly Frame _frame;                                         // Frame instance

    private class UriDialog : Window {
      private readonly TextBox _textBox;                                   // TextBox instance

      public UriDialog() {
        Title = "Enter a URL";                                             // Title of frame
        ShowInTaskbar = false;                                             // Don't show this window in taskbar
        SizeToContent = SizeToContent.WidthAndHeight;                      // Dynamic sizing of the window for thw content 
        WindowStyle = WindowStyle.ToolWindow;                              // Setting the style for this window
        WindowStartupLocation = WindowStartupLocation.CenterOwner;         // Center the sub window in our main window 
        _textBox = new TextBox {Margin = new Thickness(48)};  // Some styles for the text box
        Content = _textBox;                                                // Content of dialog window is our TextBox
        _textBox.Focus();                                                  // Move cursor in input field at program start
      }
      
      // Method that will take and return the text from user input
      public string Text {
        // Take and set
        set {
          _textBox.Text = value;
          _textBox.SelectionStart = _textBox.Text.Length;
        }
        get => _textBox.Text;  // Return
      }

      protected override void OnKeyDown(KeyEventArgs args) { if (args.Key == Key.Enter) Close(); }
    }

    [STAThread]
    public static void Main() { new Application().Run(new NavigateTheWeb()); }

    private NavigateTheWeb() {
      Title = "Navigate the Web";  // Main window title   
      _frame = new Frame();        // Creating the new Frame instance 
      Content = _frame;            // Set the content of main window
      Loaded += OnWindowLoaded;    // Will show the result only then dlg in line 46 will be created and ready to use
    }

    private void OnWindowLoaded(object sender, RoutedEventArgs args) {
      var dlg = new UriDialog {Owner = this, Text = "http://"};  // Creating a dialog window using UriDialog class
      dlg.ShowDialog();                                          // Show this window inside main window
      
      // Here _frame is trying to get input from user and display the webpage by this url
      try { _frame.Source = new Uri(dlg.Text); }
      // And catching all exceptions during user input -> show them to user as message box 
      catch (Exception exception) { MessageBox.Show(exception.Message, Title); }
    }
  }
}