using Clue.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Clue.Controllers
{
    public class QueroAssistirBD
    {
        private static string conexaoBanco = ConfiguracoesBD.GetConexaoBanco();

        public static QueroAssistir selecionar(long id)
        {
            QueroAssistir retorno = null;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("select ID, USUARIO, FILME, SERIE from QUERO_ASSISTIR where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    retorno = new QueroAssistir();

                    retorno.id = resultado.GetInt64(0);
                    retorno.usuario = UsuarioBD.selecionar(resultado.GetInt64(1));
                    retorno.filme = FilmeBD.selecionar(resultado.GetInt64(2));
                    retorno.serie = SerieBD.selecionar(resultado.GetInt64(3));
                }

                conexao.Close();
            }

            return retorno;
        }

        public static List<QueroAssistir> selecionar()
        {
            List<QueroAssistir> lista = new List<QueroAssistir>();

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("select ID, USUARIO, FILME, SERIE from QUERO_ASSISTIR;", conexao);
                SqlDataReader resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    QueroAssistir retorno = new QueroAssistir();

                    retorno.id = resultado.GetInt64(0);
                    retorno.usuario = UsuarioBD.selecionar(resultado.GetInt64(1));
                    retorno.filme = FilmeBD.selecionar(resultado.GetInt64(2));
                    retorno.serie = SerieBD.selecionar(resultado.GetInt64(3));

                    lista.Add(retorno);
                }

                conexao.Close();
            }

            return lista;
        }

        public static QueroAssistir inserir(QueroAssistir registro)
        {
            QueroAssistir retorno = null;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("insert into QUERO_ASSISTIR values(NEWID(), @USUARIO, @FILME, @SERIE);", conexao);
                comando.Parameters.AddWithValue("@USUARIO", registro.usuario.id);
                comando.Parameters.AddWithValue("@FILME", registro.filme.id);
                comando.Parameters.AddWithValue("@SERIE", registro.serie.id);
                SqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    retorno = new QueroAssistir();

                    retorno.id = resultado.GetInt64(0);
                    retorno.usuario = UsuarioBD.selecionar(resultado.GetInt64(1));
                    retorno.filme = FilmeBD.selecionar(resultado.GetInt64(2));
                    retorno.serie = SerieBD.selecionar(resultado.GetInt64(3));
                }

                conexao.Close();
            }
            return retorno;
        }

        public static bool atualizar(QueroAssistir registro, long id)
        {
            int alterou = 0;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("update QUERO_ASSISTIR set USUARIO = @USUARIO, FILME = @FILME, SERIE = @SERIE where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@USUARIO", registro.usuario.id);
                comando.Parameters.AddWithValue("@FILME", registro.filme.id);
                comando.Parameters.AddWithValue("@SERIE", registro.serie.id);
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

                SqlCommand comando = new SqlCommand("delete from QUERO_ASSISTIR where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@id", id);
                excluiu = comando.ExecuteNonQuery();

                conexao.Close();
            }

            return excluiu > 0;
        }
    }
}