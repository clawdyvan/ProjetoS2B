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
using System.Collections.ObjectModel;

namespace DengueApp
{
    public sealed partial class AtividadesPage : Page, IQuantidadeListener
    {

        public AtividadesPage()
        {
            this.InitializeComponent();
            this.LerEstadoDasAtividades();
        }

        private void LvAtividades_CheckBox_Changed(object sender, RoutedEventArgs e)
        {

            var checkbox = (CheckBox)sender;
            var grid = (Grid)checkbox.Parent;
            var tbData = (TextBlock)grid.FindName("teste");

            if ((bool)checkbox.IsChecked)
            {
                tbData.Text = DateTime.Today.ToString("dd/MM/yyyy");
            }

            this.GravarEstadoDasAtividades();
        }

        private void LvAtividades_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(AividadeDetalhesPage));
        }




        private void GravarEstadoDasAtividades()
        {

            var listItems = (IList<ItemListaAtividades>)lvAtividades.ItemsSource;
            AtividadesUtils.GravarEstadoDasAtividades(listItems);

            this.atualizarQuantidade(listItems);
        }

        private async void LerEstadoDasAtividades()
        {
            var ListItems = await AtividadesUtils.LerEstadoDasAtividades();
            if (ListItems == null)
            {
                ListItems = AtividadesUtils.ObterListaAtividadesEstaticas();
            }

            var dataDeHoje = DateTime.Today;

            foreach(var item in ListItems) {

                var dataUltimaConclusao = item.DataUltimaConclusao;

                if (dataUltimaConclusao == null)
                {
                    continue;
                }

                var dataFormatada = dataUltimaConclusao.Split('/');
                var dataUltimaConclusaoItem = new DateTime(
                    Convert.ToInt16(dataFormatada[2]),
                    Convert.ToInt16(dataFormatada[1]),
                    Convert.ToInt16(dataFormatada[0])
                    );

                var totalDeDiasDesdeUltimaConclusao = (dataDeHoje - dataUltimaConclusaoItem).TotalDays;

                if (totalDeDiasDesdeUltimaConclusao > item.DiasDeValidade)
                {
                    item.AtividadeConcluida = false;
                }

            }


            lvAtividades.ItemsSource = ListItems;
            this.atualizarQuantidade(ListItems);
        }




        private void atualizarQuantidade(IList<ItemListaAtividades> list)
        {
            var numeroDeConcluídas = list.Where(a => a.AtividadeConcluida).ToList<ItemListaAtividades>().Count;
            int totalDeAtividades = list.Count;

            this.AlterarQuantidade(numeroDeConcluídas, totalDeAtividades);
        }

        public void AlterarQuantidade(int quantidade, int total)
        {
            MainPage.SingletonPage.AlterarQuantidade(quantidade, total);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
