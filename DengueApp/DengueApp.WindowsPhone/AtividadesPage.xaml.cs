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

        public List<ItemLista> ListItems { get; set; }

        public AtividadesPage()
        {
            this.InitializeComponent();

            ListItems = new List<ItemLista>();

            ListItems.Add(new ItemLista { 
                Titulo = "Título1",
                Subtitulo = "Subtítulo1"
            });
            ListItems.Add(new ItemLista
            {
                Titulo = "Título2",
                Subtitulo = "Subtítulo2"
            });
            ListItems.Add(new ItemLista
            {
                Titulo = "Título3",
                Subtitulo = "Subtítulo3"
            });
            ListItems.Add(new ItemLista
            {
                Titulo = "Título4",
                Subtitulo = "Subtítulo4"
            });

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

    public class ItemLista
    {
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
    }
}
