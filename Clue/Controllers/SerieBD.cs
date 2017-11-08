using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clue.Models;
using System.Data.SqlClient;

namespace Clue.Controllers
{
    public class SerieBD
    {
        private static string conexaoBanco = ConfiguracoesBD.GetConexaoBanco();

        public static Serie selecionar(long id)
        {
            Serie retorno = null;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("select ID, TITULO, SINOPSE, DIRETOR, PRINCIPAIS_ATORES, GENERO, ANO, QTD_TEMPORADAS, QTD_EPISODIOS from SERIE where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    retorno = new Serie();

                    retorno.id = resultado.GetInt64(0);
                    retorno.titulo = resultado.GetString(1);
                    retorno.sinopse = resultado.GetString(2);
                    retorno.diretor = resultado.GetString(3);
                    retorno.principaisAtores = resultado.GetString(4);
                    retorno.genero = resultado.GetString(5);
                    retorno.ano = resultado.GetInt32(6);
                    retorno.quantidadeTemporadas = resultado.GetInt32(7);
                    retorno.quantidadeEpisodios = resultado.GetInt32(8);
                }

                conexao.Close();
            }

            return retorno;
        }

        public static List<Serie> selecionar()
        {
            List<Serie> lista = new List<Serie>();

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();
                
                SqlCommand comando = new SqlCommand("select ID, TITULO, SINOPSE, DIRETOR, PRINCIPAIS_ATORES, GENERO, ANO, QTD_TEMPORADAS, QTD_EPISODIOS from SERIE;", conexao);
                SqlDataReader resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Serie retorno = new Serie();

                    retorno.id = resultado.GetInt64(0);
                    retorno.titulo = resultado.GetString(1);
                    retorno.sinopse = resultado.GetString(2);
                    retorno.diretor = resultado.GetString(3);
                    retorno.principaisAtores = resultado.GetString(4);
                    retorno.genero = resultado.GetString(5);
                    retorno.ano = resultado.GetInt32(6);
                    retorno.quantidadeTemporadas = resultado.GetInt32(7);
                    retorno.quantidadeEpisodios = resultado.GetInt32(8);

                    lista.Add(retorno);
                }

                conexao.Close();
            }

            return lista;
        }

        public static Serie inserir(Serie registro)
        {
            Serie retorno = null;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("insert into SERIE values(NEWID(), @TITULO, @SINOPSE, @DIRETOR, @PRINCIPAIS_ATORES, @GENERO, @ANO, @QTD_TEMPORADAS, @QTD_EPISODIOS);", conexao);
                comando.Parameters.AddWithValue("@TITULO", registro.titulo);
                comando.Parameters.AddWithValue("@SINOPSE", registro.sinopse);
                comando.Parameters.AddWithValue("@DIRETOR", registro.diretor);
                comando.Parameters.AddWithValue("@PRINCIPAIS_ATORES", registro.principaisAtores);
                comando.Parameters.AddWithValue("@GENERO", registro.genero);
                comando.Parameters.AddWithValue("@ANO", registro.ano);
                comando.Parameters.AddWithValue("@QTD_TEMPORADAS", registro.quantidadeTemporadas);
                comando.Parameters.AddWithValue("@QTD_EPISODIOS", registro.quantidadeEpisodios);
                SqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    retorno = new Serie();

                    retorno.id = resultado.GetInt64(0);
                    retorno.titulo = resultado.GetString(1);
                    retorno.sinopse = resultado.GetString(2);
                    retorno.diretor = resultado.GetString(3);
                    retorno.principaisAtores = resultado.GetString(4);
                    retorno.genero = resultado.GetString(5);
                    retorno.ano = resultado.GetInt32(6);
                    retorno.quantidadeTemporadas = resultado.GetInt32(7);
                    retorno.quantidadeEpisodios = resultado.GetInt32(8);
                }

                conexao.Close();
            }
            return retorno;
        }

        public static bool atualizar(Serie registro, string id)
        {
            int alterou = 0;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();
                
                SqlCommand comando = new SqlCommand("update SERIE set TITULO = @TITULO, SINOPSE = @SINOPSE, DIRETOR = @DIRETOR, PRINCIPAIS_ATORES = @PRINCIPAIS_ATORES, " +
                    "GENERO = @GENERO, ANO = @ANO, QTD_TEMPORADAS = @QTD_TEMPORADAS, QTD_EPISODIOS = @QTD_EPISODIOS where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@TITULO", registro.titulo);
                comando.Parameters.AddWithValue("@SINOPSE", registro.sinopse);
                comando.Parameters.AddWithValue("@DIRETOR", registro.diretor);
                comando.Parameters.AddWithValue("@PRINCIPAIS_ATORES", registro.principaisAtores);
                comando.Parameters.AddWithValue("@GENERO", registro.genero);
                comando.Parameters.AddWithValue("@ANO", registro.ano);
                comando.Parameters.AddWithValue("@QTD_TEMPORADAS", registro.quantidadeTemporadas);
                comando.Parameters.AddWithValue("@QTD_EPISODIOS", registro.quantidadeEpisodios);
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

                SqlCommand comando = new SqlCommand("delete from SERIE where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@id", id);
                excluiu = comando.ExecuteNonQuery();

                conexao.Close();
            }

            return excluiu > 0;
        }
    }
}