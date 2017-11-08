using Clue.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Clue.Controllers
{
    public class QueroAssistirClassificacaoBD
    {
        private static string conexaoBanco = ConfiguracoesBD.GetConexaoBanco();

        public static QueroAssistirClassificacao selecionar(long id)
        {
            QueroAssistirClassificacao retorno = null;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("select ID, USUARIO, REGISTRO_PAI, CLASSIFICACAO, TEXTO from QUERO_ASSISTIR_CLASSIFICACAO where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    retorno = new QueroAssistirClassificacao();

                    retorno.id = resultado.GetInt64(0);
                    retorno.usuario = UsuarioBD.selecionar(resultado.GetInt64(1));
                    retorno.registroPai = QueroAssistirBD.selecionar(resultado.GetInt64(2));
                    retorno.classificacao = resultado.GetInt32(3);
                    retorno.texto = resultado.GetString(4);
                }

                conexao.Close();
            }

            return retorno;
        }

        public static List<QueroAssistirClassificacao> selecionar()
        {
            List<QueroAssistirClassificacao> lista = new List<QueroAssistirClassificacao>();

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("select ID, USUARIO, REGISTRO_PAI, CLASSIFICACAO, TEXTO from QUERO_ASSISTIR_CLASSIFICACAO;", conexao);
                SqlDataReader resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    QueroAssistirClassificacao retorno = new QueroAssistirClassificacao();

                    retorno.id = resultado.GetInt64(0);
                    retorno.usuario = UsuarioBD.selecionar(resultado.GetInt64(1));
                    retorno.registroPai = QueroAssistirBD.selecionar(resultado.GetInt64(2));
                    retorno.classificacao = resultado.GetInt32(3);
                    retorno.texto = resultado.GetString(4);

                    lista.Add(retorno);
                }

                conexao.Close();
            }

            return lista;
        }

        public static QueroAssistirClassificacao inserir(QueroAssistirClassificacao registro)
        {
            QueroAssistirClassificacao retorno = null;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("insert into QUERO_ASSISTIR_CLASSIFICACAO values(NEWID(), @USUARIO, @REGISTRO_PAI, @CLASSIFICACAO, @TEXTO);", conexao);
                comando.Parameters.AddWithValue("@USUARIO", registro.usuario.id);
                comando.Parameters.AddWithValue("@REGISTRO_PAI", registro.registroPai.id);
                comando.Parameters.AddWithValue("@CLASSIFICACAO", registro.classificacao);
                comando.Parameters.AddWithValue("@TEXTO", registro.texto);
                SqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    retorno = new QueroAssistirClassificacao();

                    retorno.id = resultado.GetInt64(0);
                    retorno.usuario = UsuarioBD.selecionar(resultado.GetInt64(1));
                    retorno.registroPai = QueroAssistirBD.selecionar(resultado.GetInt64(2));
                    retorno.classificacao = resultado.GetInt32(3);
                    retorno.texto = resultado.GetString(4);
                }

                conexao.Close();
            }
            return retorno;
        }

        public static bool atualizar(QueroAssistirClassificacao registro, string id)
        {
            int alterou = 0;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("update QUERO_ASSISTIR_CLASSIFICACAO set USUARIO = @USUARIO, REGISTRO_PAI = @REGISTRO_PAI, CLASSIFICACAO = @CLASSIFICACAO, TEXTO = @TEXTO where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@USUARIO", registro.usuario.id);
                comando.Parameters.AddWithValue("@REGISTRO_PAI", registro.registroPai.id);
                comando.Parameters.AddWithValue("@CLASSIFICACAO", registro.classificacao);
                comando.Parameters.AddWithValue("@TEXTO", registro.texto);
                comando.Parameters.AddWithValue("@id", id);
                alterou = comando.ExecuteNonQuery();

                conexao.Close();
            }

            return alterou > 0;
        }

        public static bool excluir(long id)
        {
            int excluiu = 0;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("delete from QUERO_ASSISTIR_CLASSIFICACAO where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@id", id);
                excluiu = comando.ExecuteNonQuery();

                conexao.Close();
            }

            return excluiu > 0;
        }
    }
}