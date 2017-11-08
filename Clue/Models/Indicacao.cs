using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clue.Models
{
    public class Indicacao
    {
        public long id { get; set; }
        public Usuario usuario { get; set; }
        public Filme filme { get; set; }
        public Serie serie { get; set; }
        public int classificacao { get; set; }
        public string texto { get; set; }
    }
}