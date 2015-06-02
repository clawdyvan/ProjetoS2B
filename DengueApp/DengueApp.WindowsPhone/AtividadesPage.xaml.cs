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
using System.Threading.Tasks;

namespace DengueApp
{
    public sealed partial class AtividadesPage : Page
    {

        public IList<ItemListaAtividades> ListItems { get; set; }

        public AtividadesPage()
        {
            this.InitializeComponent();
            this.LerEstadoDasAtividades();
        }

        private void LvAtividades_CheckBox_Changed(object sender, RoutedEventArgs e)
        {
            this.GravarEstadoDasAtividades();
        }

        private void LvAtividades_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(AividadeDetalhesPage));
        }

        private void GravarEstadoDasAtividades()
        {
            AtividadesUtils.GravarEstadoDasAtividades(ListItems);
        }

        private async void LerEstadoDasAtividades()
        {
            ListItems = await AtividadesUtils.LerEstadoDasAtividades();
            if (ListItems == null)
            {
                ListItems = AtividadesUtils.ObterListaAtividadesEstaticas();
            }
            lvAtividades.ItemsSource = ListItems;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
