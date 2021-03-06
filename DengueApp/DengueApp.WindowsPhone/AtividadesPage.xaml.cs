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
using DengueApp.Model;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Windows.UI;

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
            var panel = (Panel)checkbox.Parent;

            if ((bool)checkbox.IsChecked)
            {
                var tbDataUltimaConclusao = (TextBlock)panel.FindName("tbDataUltimaConclusao");
                tbDataUltimaConclusao.Text = DateTime.Today.ToString("dd/MM/yyyy");
            }

            var listItems = (IList<ItemListaAtividades>)lvAtividades.ItemsSource;

            listItems = ProcessarDadosLista(listItems);

            lvAtividades.ItemsSource = null;
            lvAtividades.ItemsSource = listItems;

            this.GravarEstadoDasAtividades(listItems);
        }

        private void LvAtividades_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frame = Window.Current.Content as Frame;

            var item = (ItemListaAtividades)e.ClickedItem;

            var parametros = GetParametersForItemClick(item.Id);

            frame.Navigate(typeof(AividadeDetalhesPage), parametros);
                          
        }

        public dynamic GetParametersForItemClick(int itemId)
        {
                       
            switch (itemId)
            {
                case 0:
                    return new 
                    { 
                        Texto = Textos.text0, 
                        StrUriImagem = "ms-appx:///ImagensParaAsTelas/CAIXA DA AGUA.png",
                        SolidColorBrush = new SolidColorBrush(Color.FromArgb(255, 67, 197, 155))
                    };
                case 1:
                    return new
                    {
                        Texto = Textos.text1,
                        StrUriImagem = "ms-appx:///ImagensParaAsTelas/OLHAR AS CALHAS.png",
                        SolidColorBrush = new SolidColorBrush(Color.FromArgb(255, 249, 143, 107))
                    };

               
                case 2:
                    return new
                    {
                        Texto = Textos.text2,
                        StrUriImagem = "ms-appx:///ImagensParaAsTelas/RESERVATORIO.png",
                        SolidColorBrush = new SolidColorBrush(Color.FromArgb(255, 184, 77, 212))
                    };

                case 3:
                    return new
                    {
                        Texto = Textos.text3,
                        StrUriImagem = "ms-appx:///ImagensParaAsTelas/ARCONDI.png",
                        SolidColorBrush = new SolidColorBrush(Color.FromArgb(255, 48, 75, 122))
                    };

                case 4:
                    return new
                    {
                        
                        Texto = Textos.text4,
                        StrUriImagem = "ms-appx:///ImagensParaAsTelas/PRATINHO DE PLANTAS.png",
                        SolidColorBrush = new SolidColorBrush(Color.FromArgb(255, 238, 61, 61))
                    };

                case 5:
                    return new
                    {
                        Texto = Textos.text5,
                        StrUriImagem = "ms-appx:///ImagensParaAsTelas/AQUAR.png",
                        SolidColorBrush = new SolidColorBrush(Color.FromArgb(255, 96, 151, 245))
                    };

                
                case 6:
                    return new
                    {
                        Texto = Textos.text6,
                        StrUriImagem = "ms-appx:///ImagensParaAsTelas/GUARRAFAS.png",
                        SolidColorBrush = new SolidColorBrush(Color.FromArgb(255, 210, 157, 64))
                    };


                case 7:
                    return new
                    {
                        Texto = Textos.text7,
                        StrUriImagem = "ms-appx:///ImagensParaAsTelas/DOG.png",
                        SolidColorBrush = new SolidColorBrush(Color.FromArgb(255, 145, 180, 111))
                    };


                case 8:
                    return new
                    {
                        Texto = Textos.text8,
                        StrUriImagem = "ms-appx:///ImagensParaAsTelas/LIXO.png",
                        SolidColorBrush = new SolidColorBrush(Color.FromArgb(255, 195, 194, 194))
                    };
                

                default:
                    return null;
            }

            
        }

        private void GravarEstadoDasAtividades(IList<ItemListaAtividades> listItems)
        {
            AtividadesUtils.GravarEstadoDasAtividades(listItems);
            this.atualizarQuantidade(listItems);
        }

        private async void LerEstadoDasAtividades()
        {
            var listItems = await AtividadesUtils.LerEstadoDasAtividades();
            if (listItems == null)
            {
                listItems = AtividadesUtils.ObterListaAtividadesEstaticas();
            }

            listItems = ProcessarDadosLista(listItems);

            lvAtividades.ItemsSource = listItems;
            this.atualizarQuantidade(listItems);
        }

        private IList<ItemListaAtividades> ProcessarDadosLista(IList<ItemListaAtividades> listItems)
        {
            var dataDeHoje = DateTime.Today;

            foreach (var item in listItems)
            {
                try
                {
                    var dataFormatada = item.DataUltimaConclusao.Split('/');
                    var dataUltimaConclusaoItem = new DateTime(
                        Convert.ToInt16(dataFormatada[2]),
                        Convert.ToInt16(dataFormatada[1]),
                        Convert.ToInt16(dataFormatada[0]));

                    var totalDeDiasDesdeUltimaConclusao = (int)(dataDeHoje - dataUltimaConclusaoItem).TotalDays;

                    if (totalDeDiasDesdeUltimaConclusao >= item.DiasDeValidade || !item.AtividadeConcluida)
                    {
                        item.AtividadeConcluida = false;
                        item.DiasRestantesMensagem = "";
                        item.DataUltimaConclusao = "";
                    }
                    else
                    {
                        var diferencaDias = item.DiasDeValidade - totalDeDiasDesdeUltimaConclusao;
                        item.DiasRestantesMensagem = diferencaDias < 0 ? "" :
                            (" -  Resta" + (diferencaDias > 1 ? "m" : "") + " " + diferencaDias + " dia" + (diferencaDias > 1 ? "s" : ""));
                    }
                }
                catch (Exception) { }
            }

            return listItems;
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
