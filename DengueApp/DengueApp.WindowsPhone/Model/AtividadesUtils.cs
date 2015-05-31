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

        public static IList<ItemListaAtividades> ObterListaAtividades()
        {

            var listaAtividades = new List<ItemListaAtividades>();

            listaAtividades.Add(new ItemListaAtividades
            {
                Titulo = "Título1",
                Subtitulo = "Subtítulo1"
            });
            listaAtividades.Add(new ItemListaAtividades
            {
                Titulo = "Título2",
                Subtitulo = "Subtítulo2"
            });
            listaAtividades.Add(new ItemListaAtividades
            {
                Titulo = "Título3",
                Subtitulo = "Subtítulo3"
            });
            listaAtividades.Add(new ItemListaAtividades
            {
                Titulo = "Título4",
                Subtitulo = "Subtítulo4"
            });

            return listaAtividades;
        }

        private static StorageFolder ObterPastaLocalDoAplicativo()
        {
            return Windows.Storage.ApplicationData.Current.LocalFolder;
        }

        private static async Task GravarEstadoDasAtividades(IList<ItemListaAtividades> list)
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

            using (var streamForRead = await arquivoAtividades.OpenStreamForReadAsync())
            {
                var teste1 = serializer.ReadObject(streamForRead);
                var teste2 = teste1;
            }

        }



    }
}
