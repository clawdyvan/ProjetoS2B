using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DengueApp.Model
{
    public class NavigationUtils
    {

        public static Frame getFrame()
        {
            return Window.Current.Content as Frame;
        }
        
    }
}
