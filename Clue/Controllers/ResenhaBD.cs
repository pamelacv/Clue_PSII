using Clue.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Clue.Controllers
{
    public class ResenhaBD
    {
        private static string conexaoBanco = ConfiguracoesBD.GetConexaoBanco();

        public static Resenha selecionar(long id)
        {
            Resenha retorno = null;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("select ID, USUARIO, FILME, SERIE, TITULO, TEXTO from RESENHA where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    retorno = new Resenha();

                    retorno.id = resultado.GetInt64(0);
                    retorno.usuario = UsuarioBD.selecionar(resultado.GetInt64(1));
                    retorno.filme = FilmeBD.selecionar(resultado.GetInt64(2));
                    retorno.serie = SerieBD.selecionar(resultado.GetInt64(3));
                    retorno.titulo = resultado.GetString(4);
                    retorno.texto = resultado.GetString(5);
                }

                conexao.Close();
            }

            return retorno;
        }

        public static List<Resenha> selecionar()
        {
            List<Resenha> lista = new List<Resenha>();

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("select ID, USUARIO, FILME, SERIE, TITULO, TEXTO from RESENHA;", conexao);
                SqlDataReader resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Resenha retorno = new Resenha();

                    retorno.id = resultado.GetInt64(0);
                    retorno.usuario = UsuarioBD.selecionar(resultado.GetInt64(1));
                    retorno.filme = FilmeBD.selecionar(resultado.GetInt64(2));
                    retorno.serie = SerieBD.selecionar(resultado.GetInt64(3));
                    retorno.titulo = resultado.GetString(4);
                    retorno.texto = resultado.GetString(5);

                    lista.Add(retorno);
                }

                conexao.Close();
            }

            return lista;
        }

        public static Resenha inserir(Resenha registro)
        {
            Resenha retorno = null;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("insert into RESENHA values(NEWID(), @USUARIO, @FILME, @SERIE, @TITULO, @TEXTO);", conexao);
                comando.Parameters.AddWithValue("@USUARIO", registro.usuario.id);
                comando.Parameters.AddWithValue("@FILME", registro.filme.id);
                comando.Parameters.AddWithValue("@SERIE", registro.serie.id);
                comando.Parameters.AddWithValue("@TITULO", registro.titulo);
                comando.Parameters.AddWithValue("@TEXTO", registro.texto);
                SqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    retorno = new Resenha();

                    retorno.id = resultado.GetInt64(0);
                    retorno.usuario = UsuarioBD.selecionar(resultado.GetInt64(1));
                    retorno.filme = FilmeBD.selecionar(resultado.GetInt64(2));
                    retorno.serie = SerieBD.selecionar(resultado.GetInt64(3));
                    retorno.titulo = resultado.GetString(4);
                    retorno.texto = resultado.GetString(5);
                }

                conexao.Close();
            }
            return retorno;
        }

        public static bool atualizar(Resenha registro, string id)
        {
            int alterou = 0;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("update RESENHA set USUARIO = @USUARIO, FILME = @FILME, SERIE = @SERIE, TITULO = @TITULO, TEXTO = @TEXTO where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@USUARIO", registro.usuario.id);
                comando.Parameters.AddWithValue("@FILME", registro.filme.id);
                comando.Parameters.AddWithValue("@SERIE", registro.serie.id);
                comando.Parameters.AddWithValue("@TITULO", registro.titulo);
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

                SqlCommand comando = new SqlCommand("delete from RESENHA where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@id", id);
                excluiu = comando.ExecuteNonQuery();

                conexao.Close();
            }

            return excluiu > 0;
        }
    }
}