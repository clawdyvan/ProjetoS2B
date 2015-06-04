using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DengueApp.Model
{

    public class AtividadesUtils
    {

        private const string PASTA_ATIVIDADES = "PastaAtividades";
        private const string ARQUIVO_ATIVIDADES = "ArquivoAtividades.ser";

        public static IList<ItemListaAtividades> ObterListaAtividadesEstaticas()
        {

            var listaAtividades = new List<ItemListaAtividades>();

            listaAtividades.Add(new ItemListaAtividades
            {
                Id = 0,
                Titulo = "Lavar pratinho da planta",
                DiasDeValidade = 1
            });
            listaAtividades.Add(new ItemListaAtividades
            {
                Id = 1,
                Titulo = "Olhar atrás da geladeira",
                DiasDeValidade = 2
            });
            listaAtividades.Add(new ItemListaAtividades
            {
                Id = 2,
                Titulo = "Limpar calhas",
                DiasDeValidade = 1
            });
            listaAtividades.Add(new ItemListaAtividades
            {
                Id = 3,
                Titulo = "Verificar o quintal",
                DiasDeValidade = 4
            });

            return listaAtividades;
        }

        private static StorageFolder ObterPastaLocalDoAplicativo()
        {
            return Windows.Storage.ApplicationData.Current.LocalFolder;
        }

        public static async void GravarEstadoDasAtividades(IList<ItemListaAtividades> list)
        {

            var pastaAtividades = await ObterPastaLocalDoAplicativo()
                .CreateFolderAsync(PASTA_ATIVIDADES, CreationCollisionOption.OpenIfExists);

            var arquivoAtividades = await pastaAtividades
                .CreateFileAsync(ARQUIVO_ATIVIDADES, CreationCollisionOption.ReplaceExisting);

            var serializer = new DataContractSerializer(typeof(IList<ItemListaAtividades>));

            using (var streamForWrite = await arquivoAtividades.OpenStreamForWriteAsync())
            {
                serializer.WriteObject(streamForWrite, list);
            }
        }

        public static async Task<IList<ItemListaAtividades>> LerEstadoDasAtividades() 
        {

            var pastaAtividades = await ObterPastaLocalDoAplicativo()
                .CreateFolderAsync(PASTA_ATIVIDADES, CreationCollisionOption.OpenIfExists);

            var arquivoAtividades = await pastaAtividades
                .CreateFileAsync(ARQUIVO_ATIVIDADES, CreationCollisionOption.OpenIfExists);

            var serializer = new DataContractSerializer(typeof(IList<ItemListaAtividades>));

            IList<ItemListaAtividades> list = null;

            using (var streamForRead = await arquivoAtividades.OpenStreamForReadAsync())
            {
                try
                {
                    list = (IList<ItemListaAtividades>)serializer.ReadObject(streamForRead);
                }
                catch (Exception) { }
            }

            return list;

        }

    }
}
