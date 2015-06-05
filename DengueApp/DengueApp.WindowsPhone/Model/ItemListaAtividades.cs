using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DengueApp.Model
{
    public class ItemListaAtividades
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int DiasDeValidade { get; set; }
        public string DiasRestantesMensagem { get; set; }
        public string DataUltimaConclusao { get; set; }
        public bool AtividadeConcluida { get; set; }
    }
}
