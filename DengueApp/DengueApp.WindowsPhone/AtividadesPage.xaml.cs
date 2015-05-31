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
using DengueApp.Model;

namespace DengueApp
{
    public sealed partial class AtividadesPage : Page
    {

        public IList<ItemListaAtividades> ListItems { get; set; }

        public AtividadesPage()
        {
            this.InitializeComponent();

            ListItems = AtividadesUtils.ObterListaAtividades();

            lvAtividades.ItemsSource = ListItems;
        }

        private void lvAtividades_ItemClick(object sender, ItemClickEventArgs e)
        {
            string str = sender.ToString();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
