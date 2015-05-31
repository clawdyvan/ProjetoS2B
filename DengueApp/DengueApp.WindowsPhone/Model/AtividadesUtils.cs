using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DengueApp.Model
{
    public class AtividadesUtils
    {

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
    }
}
