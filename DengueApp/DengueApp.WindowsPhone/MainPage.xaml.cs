using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DengueApp.Model;

namespace DengueApp
{
    public sealed partial class MainPage : Page, IQuantidadeListener
    {

        public static MainPage SingletonPage { get; set; }
        public static IList<IQuantidadeListener> QuantidadeAlteradaListeners { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;

            SingletonPage = this;
            QuantidadeAlteradaListeners = new List<IQuantidadeListener>();
        }

        public void AlterarQuantidade(int quantidade, int total)
        {
            foreach (var listener in QuantidadeAlteradaListeners)
            {
                listener.AlterarQuantidade(quantidade, total);
            }
        }

        private void HubSectionLoaded(object sender, RoutedEventArgs e)
        {
            var grid = (Grid)sender;
            var page = this.GetPageForSection(grid.Name);

            grid.Children.Add(page);
        }

        private Page GetPageForSection(String sectionName)
        {

            switch (sectionName)
            {
                case "section1":
                    return new HomePage();

                case "section2":
                    return new AtividadesPage();

                default:
                    return null;
            }
        }

        void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }
    }
}
