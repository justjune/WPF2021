using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_24_666_StyleWithTargetTypes
{
    public partial class StyleWithTargetTypes
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new StyleWithTargetTypes());
        }
    }
}
