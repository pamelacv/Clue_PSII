using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clue.Models
{
    public class Serie
    {
        public long id { get; set; }
        public string titulo { get; set; }
        public string sinopse { get; set; }
        public string diretor { get; set; }
        public string principaisAtores { get; set; }
        public string genero { get; set; }
        public int ano { get; set; }
        public int quantidadeTemporadas { get; set; }
        public int quantidadeEpisodios { get; set; }
    }
}