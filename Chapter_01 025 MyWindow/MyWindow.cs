// Dependencies are the same as in the first task

using System;
using System.Windows;
using System.Windows.Input;

namespace Task_4 {
  // Class MyApplication inherits from Application
  internal class MyApplication : Application {
    // Here we overriding the inherited from Application.OnStartup() virtual method
    protected override void OnStartup(StartupEventArgs args) {
      // As I understand the base keyword is used to get OnStartup() method from base (Application) class
      base.OnStartup(args);  
      var win = new MyWindow();  // Creating a new Window instance with Title = "Inherit App & Window"  
      win.Show();                // Show it to the user
    }
  }
  
  // Class MyWindow inherits from Window
  internal class MyWindow : Window {
    public MyWindow() { Title = "Inherit App & Window"; }  // This line allows us to create a new instance of Window

    protected override void OnMouseDown(MouseButtonEventArgs args) {
      base.OnMouseDown(args);  // Track ANY mouse click from user (left, right, middle) 
      // Args contains all information of mouse state and changes
      // args.ChangedButton - button what was pressed
      // args.GetPosition   - returns the Point object with x,y coordinates of the click location
      var strMessage =
        string.Format("Window clicked with {0} button at point ({1})", args.ChangedButton, args.GetPosition(this));
      MessageBox.Show(strMessage, Title);  // Show the message box with click coordinates
    }
  }


  internal static class EntryPoint {
    [STAThread]
    public static void Main() {
      var app = new MyApplication();  // Creating a new object of MyApplication class
      app.Run();                      // Start an event loop
    }
  }
}