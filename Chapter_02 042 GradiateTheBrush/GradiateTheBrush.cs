// Dependencies are the same as in the first task

using System;
using System.Windows;
using System.Windows.Media;

namespace GradiateTheBrush {
  // Our class GradiateTheBrush inherits from Window base class
  public class GradiateTheBrush : Window {
    [STAThread]
    public static void Main() {
      var app = new Application();
      app.Run(new GradiateTheBrush());

      /*
       *
       * The same as:
       * var win = new GradiateTheBrush();
       * win.Show()
       * 
       * var app = new Application();
       * app.Run();
       * 
       */
    }

    // The window that we will show to the user with background set to linear-gradient
    private GradiateTheBrush() {
      Title = "Gradiate the Brush";
      Background = new LinearGradientBrush(Colors.Red, Colors.Blue, new Point(0, 0), new Point(1, 1));
    }
  }
}

// Also this code can be simply transformed into this one (more clear IMHO) without heap of inheritances 
/*
*  namespace GradiateTheBrush {
*    public static class GradiateTheBrush {
*      [STAThread]
*      public static void Main() {
*        var app = new Application();
*        app.Run(
*          new Window() {
*            Title = "Gradiate the Brush",
*            Background =
*              new LinearGradientBrush(
*                Colors.Red, Colors.Blue, new Point(0, 0), 
*                new Point(1, 1)
*              )
*          }
*        );
*      }
*    }
*  }
*/