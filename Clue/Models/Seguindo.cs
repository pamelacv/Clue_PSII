using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clue.Models
{
    public class Seguindo
    {
        public long id { get; set; }
        public Usuario usuario { get; set; }
        public Usuario usuarioDestino { get; set; }
    }
}