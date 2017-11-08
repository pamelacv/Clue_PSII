using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Clue.Models
{
    public class Usuario
    {
        public long id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string descricao { get; set; }
        public byte[] foto { get; set; }
    }
}