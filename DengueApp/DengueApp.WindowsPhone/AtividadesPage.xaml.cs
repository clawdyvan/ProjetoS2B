using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace DengueApp
{
    public sealed partial class AtividadesPage : Page
    {

        public List<String> ListItems { get; set; }

        public AtividadesPage()
        {
            this.InitializeComponent();

            ListItems = new List<string>();

            ListItems.Add("Item1");
            ListItems.Add("Item2");
            ListItems.Add("Item3");
            ListItems.Add("Item4");
            ListItems.Add("Item5");
            ListItems.Add("Item6");

            lvAtividades.ItemsSource = ListItems;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
