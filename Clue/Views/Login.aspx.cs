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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verifica campos obrigatórios
                if (string.IsNullOrEmpty(textEmail.Value))
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('O campo 'E-mail' é obrigatório para fazer login.')", true);

                //if (string.IsNullOrEmpty(passwordSenha.Value))
                //    throw new Exception("O campo 'Senha' é obrigatório para fazer login.");

                //Faz validação

                //Verifica se usuário e senha existem
                Usuario usuarioLogado = UsuarioBD.selecionar(textEmail.Value, passwordSenha.Value);

                //Valida sessão do usuário
                if (usuarioLogado != null)
                {
                    Session["Usuario"] = usuarioLogado.id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message + " - StackTrace: " + ex.StackTrace);
            }
        }

        protected void bCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verifica campos obrigatórios
                //if (string.IsNullOrEmpty(textEmail.Value))
                //   Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('O campo 'E-mail' é obrigatório para fazer login.')", true);

                //if (string.IsNullOrEmpty(passwordSenha.Value))
                //    throw new Exception("O campo 'Senha' é obrigatório para fazer login.");

                //Faz validação

                //Verifica se usuário e senha existem
                Usuario usuarioCadastrar = UsuarioBD.selecionar(textEmail.Value, passwordSenha.Value);

                //Cadastra usuário e valida sessão
                if (UsuarioBD.selecionar(textEmail.Value, passwordSenha.Value) == null)
                {
                    usuarioCadastrar = new Usuario();
                    usuarioCadastrar.nome = textNomeCadastro.Value;
                    usuarioCadastrar.email = textEmailCadastro.Value;
                    usuarioCadastrar.senha = passwordSenhaCadastro.Value;
                    usuarioCadastrar.descricao = "";
                    usuarioCadastrar.foto = new byte[0];

                    UsuarioBD.inserir(usuarioCadastrar);

                    Session["Usuario"] = usuarioCadastrar.id;

                    Response.Redirect("../Views/PerfilUsuario.aspx");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message + " - StackTrace: " + ex.StackTrace);
            }
        }
    }
}