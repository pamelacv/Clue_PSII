using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clue.Models;
using System.Data.SqlClient;

namespace Clue.Controllers
{
    public class FavoritoBD
    {
        private static string conexaoBanco = ConfiguracoesBD.GetConexaoBanco();

        public static Favorito selecionar(long id)
        {
            Favorito retorno = null;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("select ID, USUARIO, FILME, SERIE from FAVORITO where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    retorno = new Favorito();

                    retorno.id = resultado.GetInt64(0);
                    retorno.usuario = UsuarioBD.selecionar(resultado.GetInt64(1));
                    retorno.filme = FilmeBD.selecionar(resultado.GetInt64(2));
                    retorno.serie = SerieBD.selecionar(resultado.GetInt64(3));
                }

                conexao.Close();
            }

            return retorno;
        }

        public static List<Favorito> selecionar()
        {
            List<Favorito> lista = new List<Favorito>();

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("select ID, USUARIO, FILME, SERIE from FAVORITO;", conexao);
                SqlDataReader resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Favorito retorno = new Favorito();

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

        public static List<Favorito> selecionarPorUsuario(long idUsuario)
        {
            List<Favorito> lista = new List<Favorito>();

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("select ID, USUARIO, FILME, SERIE from FAVORITO where USUARIO = @usuario;", conexao);
                comando.Parameters.AddWithValue("@usuario", idUsuario);
                SqlDataReader resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Favorito retorno = new Favorito();

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

        public static Favorito inserir(Favorito registro)
        {
            Favorito retorno = null;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("insert into FAVORITO values(NEWID(), @USUARIO, @FILME, @SERIE);", conexao);
                comando.Parameters.AddWithValue("@USUARIO", registro.usuario.id);
                comando.Parameters.AddWithValue("@FILME", registro.filme.id);
                comando.Parameters.AddWithValue("@SERIE", registro.serie.id);
                SqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    retorno = new Favorito();

                    retorno.id = resultado.GetInt64(0);
                    retorno.usuario = UsuarioBD.selecionar(resultado.GetInt64(1));
                    retorno.filme = FilmeBD.selecionar(resultado.GetInt64(2));
                    retorno.serie = SerieBD.selecionar(resultado.GetInt64(3));
                }

                conexao.Close();
            }
            return retorno;
        }

        public static bool atualizar(Favorito registro, long id)
        {
            int alterou = 0;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("update FAVORITO set USUARIO = @USUARIO, FILME = @FILME, SERIE = @SERIE where ID = @id;", conexao);
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

                SqlCommand comando = new SqlCommand("delete from FAVORITO where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@id", id);
                excluiu = comando.ExecuteNonQuery();

                conexao.Close();
            }

            return excluiu > 0;
        }
    }
}