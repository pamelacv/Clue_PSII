using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clue.Controllers
{
    public class ConfiguracoesBD
    {
        private const string conexaoBanco = @"server=DESKTOP-9N5UBV0\SQLEXPRESS; Database=CLUE_BD;Integrated Security=SSPI;";

        public static string GetConexaoBanco()
        {
            return conexaoBanco;
        }
    }
}