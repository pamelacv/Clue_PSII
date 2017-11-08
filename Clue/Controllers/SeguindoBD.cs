using Clue.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Clue.Controllers
{
    public class SeguindoBD
    {
        private static string conexaoBanco = ConfiguracoesBD.GetConexaoBanco();

        public static Seguindo selecionar(long id)
        {
            Seguindo retorno = null;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("select ID, USUARIO, USUARIO_DESTINO from SEGUINDO where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    retorno = new Seguindo();

                    retorno.id = resultado.GetInt64(0);
                    retorno.usuario = UsuarioBD.selecionar(resultado.GetInt64(1));
                    retorno.usuarioDestino = UsuarioBD.selecionar(resultado.GetInt64(2));
                }

                conexao.Close();
            }

            return retorno;
        }

        public static List<Seguindo> selecionar()
        {
            List<Seguindo> lista = new List<Seguindo>();

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("select ID, USUARIO, USUARIO_DESTINO from SEGUINDO;", conexao);
                SqlDataReader resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Seguindo retorno = new Seguindo();

                    retorno.id = resultado.GetInt64(0);
                    retorno.usuario = UsuarioBD.selecionar(resultado.GetInt64(1));
                    retorno.usuarioDestino = UsuarioBD.selecionar(resultado.GetInt64(2));

                    lista.Add(retorno);
                }

                conexao.Close();
            }

            return lista;
        }

        public static Seguindo inserir(Seguindo registro)
        {
            Seguindo retorno = null;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("insert into SEGUINDO values(NEWID(), @USUARIO, @USUARIO_DESTINO);", conexao);
                comando.Parameters.AddWithValue("@USUARIO", registro.usuario.id);
                comando.Parameters.AddWithValue("@USUARIO_DESTINO", registro.usuarioDestino.id);
                SqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    retorno = new Seguindo();

                    retorno.id = resultado.GetInt64(0);
                    retorno.usuario = UsuarioBD.selecionar(resultado.GetInt64(1));
                    retorno.usuarioDestino = UsuarioBD.selecionar(resultado.GetInt64(2));
                }

                conexao.Close();
            }
            return retorno;
        }

        public static bool atualizar(Seguindo registro, long id)
        {
            int alterou = 0;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("update SEGUINDO set USUARIO = @USUARIO, USUARIO_DESTINO = @USUARIO_DESTINO where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@USUARIO", registro.usuario.id);
                comando.Parameters.AddWithValue("@USUARIO_DESTINO", registro.usuarioDestino.id);
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

                SqlCommand comando = new SqlCommand("delete from SEGUINDO where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@id", id);
                excluiu = comando.ExecuteNonQuery();

                conexao.Close();
            }

            return excluiu > 0;
        }
    }
}