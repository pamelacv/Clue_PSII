using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clue.Models
{
    public class Filme
    {
        public long id { get; set; }
        public string titulo { get; set; }
        public string sinopse { get; set; }
        public string diretor { get; set; }
        public string principaisAtores { get; set; }
        public string genero { get; set; }
        public int ano { get; set; }
    }
}