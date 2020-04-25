using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaAtalhos
{
    public class Atalho
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Caminho { get; set; }
        public string Icone { get; set; }
        public string Extensao { get; set; }
        public int VezesAberto { get; set; }
    }
}
