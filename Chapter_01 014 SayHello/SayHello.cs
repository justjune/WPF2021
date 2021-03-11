/*
 Program dependencies:   <-- Need to include to blank c# project
    System
    PresentationCore
    PresentationCoreFramework
    System.Windows 
    WindowsBase 
    System.Xaml
*/

using System;
using System.Windows;

namespace Project1 {
  internal static class SayHello {
    [STAThread] // Program will use single-threaded model to run
    public static void Main() {
      var window = new Window {Title = "Say Hello"}; // Initializing the new object "window" - white box with title "Say Hello"  
      window.Show(); // Display that white box to user on desktop

      var application = new Application();
      application.Run(); // Run the main event cycle that will keep the window open and track all user actions

      /*
        // Also the previous code can be simplified into:
        var window = new Window {Title = "Say Hello"};
        var application = new Application();
        application.Run(window); // The Run() method will also execute the Show() method of window object
      */
    }
  }
}