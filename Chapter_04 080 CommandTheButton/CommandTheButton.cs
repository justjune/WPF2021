using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

// Program will paste the clipboard content into main window title
namespace Chapter_04_xxx_CommandTheButton {
  public class CommandTheButton : Window {
    [STAThread]
    public static void Main() {
      new Application().Run(new CommandTheButton());
    }

    private CommandTheButton() {
      Title = "Command the Button";  // Create the Button and set as window content.
      
      // Bind the command to the event handlers.
      Content = new Button {
        // Centering the button in window
        HorizontalAlignment = HorizontalAlignment.Center,
        VerticalAlignment = VerticalAlignment.Center,
        // Application commands - class that contains special commands like copy/paste etc.
        Command = ApplicationCommands.Paste,
        Content = ApplicationCommands.Paste.Text
      }; 
      // Create new instance of CommandBinding class with command (property), executor and execution ability checker (functions)
      // Then bind this command to button binds
      CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, PasteOnExecute, PasteCanExecute));
    }
    
    // If clipboard not empty will change the window title with clipboard content
    private void PasteOnExecute(object sender, ExecutedRoutedEventArgs args) {
      Title = Clipboard.GetText();
    }
    
    // Check if clipboard not empty
    private static void PasteCanExecute(object sender, CanExecuteRoutedEventArgs args) {
      // Asks clipboard if it contains text in unicode (true) else (false)
      args.CanExecute = Clipboard.ContainsText();
    }

    protected override void OnMouseDown(MouseButtonEventArgs args) {
      base.OnMouseDown(args);
      Title = "Command the Button";
    }
  }
}