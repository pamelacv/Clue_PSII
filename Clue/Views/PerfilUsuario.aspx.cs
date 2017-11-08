using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clue.Views
{
    public partial class PerfilUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Pega imagem da tabela de Usuarios, transforma os bytes em imagem e carrega na tela
            imgPerfil.Src = @"..\images\logo.png";

            nomeUsuario.InnerText = "Pâmela Vieira";
        }

        protected void btnListaFavoritos_Click(object sender, EventArgs e)
        {
            frame_paginas.Attributes.Add("src", "../Views/ListaFavoritos.aspx");
        }

        protected void btnListaIndicacoes_Click(object sender, EventArgs e)
        {

        }

        protected void btnListaSugestoes_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Views/EditarPerfilUsuario.aspx");
        }
    }
}