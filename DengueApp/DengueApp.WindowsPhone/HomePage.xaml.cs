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
using Windows.UI;

namespace DengueApp
{

    public sealed partial class HomePage : Page, IQuantidadeListener 
    {

        public HomePage()
        {
            this.InitializeComponent();
            MainPage.QuantidadeAlteradaListeners.Add(this);
        }

        private void MenuHomeButtonClick(object sender, RoutedEventArgs e)
        {
            
            var frame = Window.Current.Content as Frame;
            var button = (Button) sender;
            var type = GetPageForHomeButtonClick(button.Name);
            frame.Navigate(type);
        }
       
        private Type GetPageForHomeButtonClick(String sectionName)
        {

            switch (sectionName)
            {
                case "btOqeDengue":
                    return typeof(OqeDenguePage);

                case "btSintomas":
                    return typeof(SintomasPage);

                case "btIndica":
                    return typeof(IndicacoesPage);

                case "btContraidicação":
                    return typeof(ContraIndicacoesPage);

                case "btOqfazer":
                    return typeof(OqFazerPage);

                 default:
                    return null;
            }
        }

        private void IrParaSectionDois(object sender, RoutedEventArgs e)
        {
            MainPage.SingletonPage.IrParaSectionDois();
        }

        public void AlterarQuantidade(int numeroDeConcluídas, int totalDeAtividades)
        {

            if (numeroDeConcluídas == totalDeAtividades)
            {
                btAtividades.Background = new SolidColorBrush(Color.FromArgb(255, 17, 255, 41));
                btAtividades.Content = "Parabéns, tudo concluído! =)";
            }
            else
            {
                btAtividades.Background = new SolidColorBrush(Color.FromArgb(255, 255, 17, 17));
                btAtividades.Content = "Ainda faltam atividades! =(";
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
