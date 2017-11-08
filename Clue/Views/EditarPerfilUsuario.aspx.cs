using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clue.Models;
using Clue.Controllers;

namespace Clue.Views
{
    public partial class EditarPerfilUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                long idUsuarioLogado = Convert.ToInt64(Session["Usuario"]);

                Usuario usuario = UsuarioBD.selecionar(idUsuarioLogado);

                textNome.Value = usuario.nome;
                textDescricao.Text = usuario.descricao;
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                long idUsuarioLogado = Convert.ToInt64(Session["Usuario"]);

                Usuario usuario = UsuarioBD.selecionar(idUsuarioLogado);

                usuario.nome = textNome.Value;
                usuario.descricao = textDescricao.Text;
                //imagem

                UsuarioBD.atualizar(usuario, idUsuarioLogado);
            }
        }

        protected void btnEscolherFoto_Click(object sender, EventArgs e)
        {

        }
    }
}