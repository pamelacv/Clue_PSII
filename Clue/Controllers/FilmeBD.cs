using Clue.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Clue.Controllers
{
    public class FilmeBD
    {
        private static string conexaoBanco = ConfiguracoesBD.GetConexaoBanco();

        public static Filme selecionar(long id)
        {
            Filme retorno = null;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("select ID, TITULO, SINOPSE, DIRETOR, PRINCIPAIS_ATORES, GENERO, ANO from FILME where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    retorno = new Filme();

                    retorno.id = resultado.GetInt64(0);
                    retorno.titulo = resultado.GetString(1);
                    retorno.sinopse = resultado.GetString(2);
                    retorno.diretor = resultado.GetString(3);
                    retorno.principaisAtores = resultado.GetString(4);
                    retorno.genero = resultado.GetString(5);
                    retorno.ano = resultado.GetInt32(6);
                }

                conexao.Close();
            }

            return retorno;
        }

        public static List<Filme> selecionar()
        {
            List<Filme> lista = new List<Filme>();

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("select ID, TITULO, SINOPSE, DIRETOR, PRINCIPAIS_ATORES, GENERO, ANO from FILME;", conexao);
                SqlDataReader resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Filme retorno = new Filme();

                    retorno.id = resultado.GetInt64(0);
                    retorno.titulo = resultado.GetString(1);
                    retorno.sinopse = resultado.GetString(2);
                    retorno.diretor = resultado.GetString(3);
                    retorno.principaisAtores = resultado.GetString(4);
                    retorno.genero = resultado.GetString(5);
                    retorno.ano = resultado.GetInt32(6);

                    lista.Add(retorno);
                }

                conexao.Close();
            }

            return lista;
        }

        public static Filme inserir(Filme registro)
        {
            Filme retorno = null;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("insert into FILME values(NEWID(), @TITULO, @SINOPSE, @DIRETOR, @PRINCIPAIS_ATORES, @GENERO, @ANO);", conexao);
                comando.Parameters.AddWithValue("@TITULO", registro.titulo);
                comando.Parameters.AddWithValue("@SINOPSE", registro.sinopse);
                comando.Parameters.AddWithValue("@DIRETOR", registro.diretor);
                comando.Parameters.AddWithValue("@PRINCIPAIS_ATORES", registro.principaisAtores);
                comando.Parameters.AddWithValue("@GENERO", registro.genero);
                comando.Parameters.AddWithValue("@ANO", registro.ano);
                SqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    retorno = new Filme();

                    retorno.id = resultado.GetInt64(0);
                    retorno.titulo = resultado.GetString(1);
                    retorno.sinopse = resultado.GetString(2);
                    retorno.diretor = resultado.GetString(3);
                    retorno.principaisAtores = resultado.GetString(4);
                    retorno.genero = resultado.GetString(5);
                    retorno.ano = resultado.GetInt32(6);
                }

                conexao.Close();
            }
            return retorno;
        }

        public static bool atualizar(Filme registro, string id)
        {
            int alterou = 0;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("update FILME set TITULO = @TITULO, SINOPSE = @SINOPSE, DIRETOR = @DIRETOR, PRINCIPAIS_ATORES = @PRINCIPAIS_ATORES, GENERO = @GENERO, ANO = @ANO where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@TITULO", registro.titulo);
                comando.Parameters.AddWithValue("@SINOPSE", registro.sinopse);
                comando.Parameters.AddWithValue("@DIRETOR", registro.diretor);
                comando.Parameters.AddWithValue("@PRINCIPAIS_ATORES", registro.principaisAtores);
                comando.Parameters.AddWithValue("@GENERO", registro.genero);
                comando.Parameters.AddWithValue("@ANO", registro.ano);
                comando.Parameters.AddWithValue("@id", id);
                alterou = comando.ExecuteNonQuery();

                conexao.Close();
            }

            return alterou > 0;
        }

        public static bool excluir(string id)
        {
            int excluiu = 0;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("delete from FILME where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@id", id);
                excluiu = comando.ExecuteNonQuery();

                conexao.Close();
            }

            return excluiu > 0;
        }
    }
}