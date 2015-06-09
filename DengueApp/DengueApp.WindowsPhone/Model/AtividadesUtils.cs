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
                Titulo = "Conferir caixa d’água",
                DiasDeValidade = 30
            });
            listaAtividades.Add(new ItemListaAtividades
            {
                Id = 1,
                Titulo = "Conferir calhas",
                DiasDeValidade = 15
            });
            listaAtividades.Add(new ItemListaAtividades
            {
                Id = 2,
                Titulo = "Conferir reservatórios d’água",
                DiasDeValidade = 14
            });
            listaAtividades.Add(new ItemListaAtividades
            {
                Id = 3,
                Titulo = "Conferir bandeja do ar-condicionado",
                DiasDeValidade = 15
            });

            listaAtividades.Add(new ItemListaAtividades
            {
                Id = 4,
                Titulo = "Conferir vasos de plantas",
                DiasDeValidade = 5
            });

            listaAtividades.Add(new ItemListaAtividades
            {
                Id = 5,
                Titulo = "Conferir aquário",
                DiasDeValidade = 2
            });

            listaAtividades.Add(new ItemListaAtividades
            {
                Id = 6,
                Titulo = "Conferir materiais variados",
                DiasDeValidade = 10
            });

            listaAtividades.Add(new ItemListaAtividades
            {
                Id = 7,
                Titulo = "Conferir bebedouros de animais.",
                DiasDeValidade = 2
            });

            listaAtividades.Add(new ItemListaAtividades
            {
                Id = 8,
                Titulo = "Conferir lixo",
                DiasDeValidade = 2
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
