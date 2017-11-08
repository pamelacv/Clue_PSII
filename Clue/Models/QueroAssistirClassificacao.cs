using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clue.Models
{
    public class QueroAssistirClassificacao
    {
        public long id { get; set; }
        public Usuario usuario { get; set; }
        public QueroAssistir registroPai { get; set; }
        public int classificacao { get; set; }
        public string texto { get; set; }
    }
}