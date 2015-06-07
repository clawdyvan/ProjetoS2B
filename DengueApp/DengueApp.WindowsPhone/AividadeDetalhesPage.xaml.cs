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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Media;
using Windows.UI;
using System.Globalization;

namespace DengueApp
{
    
    public sealed partial class AividadeDetalhesPage : Page
    {
        public AividadeDetalhesPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var parametros = (dynamic)e.Parameter;

            tbTexto.Text = parametros.Texto;

            string strUriImagem = parametros.StrUriImagem;

            BitmapImage bitmapImage = new BitmapImage();
            Uri uri = new Uri(strUriImagem);
            bitmapImage.UriSource = uri;

            imImagem.Source = bitmapImage;
            gdRetangulo.Background = parametros.SolidColorBrush;

        }
    }
}
