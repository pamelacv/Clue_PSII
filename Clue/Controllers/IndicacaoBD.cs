using Clue.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Clue.Controllers
{
    public class IndicacaoBD
    {
        private static string conexaoBanco = ConfiguracoesBD.GetConexaoBanco();

        public static Indicacao selecionar(long id)
        {
            Indicacao retorno = null;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("select ID, USUARIO, FILME, SERIE, CLASSIFICACAO, TEXTO from INDICACAO where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    retorno = new Indicacao();

                    retorno.id = resultado.GetInt64(0);
                    retorno.usuario = UsuarioBD.selecionar(resultado.GetInt64(1));
                    retorno.filme = FilmeBD.selecionar(resultado.GetInt64(2));
                    retorno.serie = SerieBD.selecionar(resultado.GetInt64(3));
                    retorno.classificacao = resultado.GetInt32(4);
                    retorno.texto = resultado.GetString(5);
                }

                conexao.Close();
            }

            return retorno;
        }

        public static List<Indicacao> selecionar()
        {
            List<Indicacao> lista = new List<Indicacao>();

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("select ID, USUARIO, FILME, SERIE, CLASSIFICACAO, TEXTO from INDICACAO;", conexao);
                SqlDataReader resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Indicacao retorno = new Indicacao();

                    retorno.id = resultado.GetInt64(0);
                    retorno.usuario = UsuarioBD.selecionar(resultado.GetInt64(1));
                    retorno.filme = FilmeBD.selecionar(resultado.GetInt64(2));
                    retorno.serie = SerieBD.selecionar(resultado.GetInt64(3));
                    retorno.classificacao = resultado.GetInt32(4);
                    retorno.texto = resultado.GetString(5);

                    lista.Add(retorno);
                }

                conexao.Close();
            }

            return lista;
        }

        public static Indicacao inserir(Indicacao registro)
        {
            Indicacao retorno = null;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("insert into INDICACAO values(NEWID(), @USUARIO, @FILME, @SERIE, @CLASSIFICACAO, @TEXTO);", conexao);
                comando.Parameters.AddWithValue("@USUARIO", registro.usuario.id);
                comando.Parameters.AddWithValue("@FILME", registro.filme.id);
                comando.Parameters.AddWithValue("@SERIE", registro.serie.id);
                comando.Parameters.AddWithValue("@CLASSIFICACAO", registro.classificacao);
                comando.Parameters.AddWithValue("@TEXTO", registro.texto);
                SqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    retorno = new Indicacao();

                    retorno.id = resultado.GetInt64(0);
                    retorno.usuario = UsuarioBD.selecionar(resultado.GetInt64(1));
                    retorno.filme = FilmeBD.selecionar(resultado.GetInt64(2));
                    retorno.serie = SerieBD.selecionar(resultado.GetInt64(3));
                    retorno.classificacao = resultado.GetInt32(4);
                    retorno.texto = resultado.GetString(5);
                }

                conexao.Close();
            }
            return retorno;
        }

        public static bool atualizar(Indicacao registro, string id)
        {
            int alterou = 0;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("update INDICACAO set USUARIO = @USUARIO, FILME = @FILME, SERIE = @SERIE, CLASSIFICACAO = @CLASSIFICACAO, TEXTO = @TEXTO where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@USUARIO", registro.usuario.id);
                comando.Parameters.AddWithValue("@FILME", registro.filme.id);
                comando.Parameters.AddWithValue("@SERIE", registro.serie.id);
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

                SqlCommand comando = new SqlCommand("delete from INDICACAO where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@id", id);
                excluiu = comando.ExecuteNonQuery();

                conexao.Close();
            }

            return excluiu > 0;
        }
    }
}