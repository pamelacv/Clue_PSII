using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clue.Controllers;
using Clue.Models;

namespace Clue.Views
{
    public partial class ListaFavoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Favorito> favoritosUsuario = FavoritoBD.selecionarPorUsuario(Convert.ToInt64(Session["Usuario"]));

            List<InfFilmeSerieAuxiliar> lista = new List<InfFilmeSerieAuxiliar>();
            foreach (Favorito fav in favoritosUsuario)
            {
                InfFilmeSerieAuxiliar auxiliar = new InfFilmeSerieAuxiliar();
                auxiliar.id = fav.id;

                if (fav.filme != null)
                {
                    auxiliar.nome = fav.filme.titulo;
                }
                else if (fav.serie != null)
                {
                    auxiliar.nome = fav.serie.titulo;
                }

                lista.Add(auxiliar);
            }

            if (lista.Count > 0)
            {
                grid.DataSource = lista;
                grid.DataBind();
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            long idUsuarioLogado = Convert.ToInt64(Session["Usuario"]);


        }
    }
}