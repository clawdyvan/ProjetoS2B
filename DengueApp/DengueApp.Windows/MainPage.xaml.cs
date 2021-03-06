﻿using System;
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

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
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
/*
        void HardwareButtons_BackPressed(object sender)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }
*/
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

    }
}
