using Clue.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Clue.Controllers
{
    public class UsuarioBD
    {
        private static string conexaoBanco = ConfiguracoesBD.GetConexaoBanco();

        public static Usuario selecionar(string email)
        {
            Usuario retorno = null;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("select ID, NOME, EMAIL, SENHA, DESCRICAO, FOTO from USUARIO where EMAIL = @email;", conexao);
                comando.Parameters.AddWithValue("@email", email);
                SqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    retorno = new Usuario();

                    retorno.id = resultado.GetInt64(0);
                    retorno.nome = resultado.GetString(1);
                    retorno.email = resultado.GetString(2);
                    retorno.senha = resultado.GetString(3);
                    retorno.descricao = resultado.GetString(4);
                    retorno.foto = resultado.GetSqlBytes(5).Buffer;
                }

                conexao.Close();
            }

            return retorno;
        }

        public static Usuario selecionar(string email, string senha)
        {
            Usuario retorno = null;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("select ID, NOME, EMAIL, SENHA, DESCRICAO, FOTO from USUARIO where EMAIL = @email AND SENHA = @senha;", conexao);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@senha", senha);
                SqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    retorno = new Usuario();

                    retorno.id = resultado.GetInt64(0);
                    retorno.nome = resultado.GetString(1);
                    retorno.email = resultado.GetString(2);
                    retorno.senha = resultado.GetString(3);
                    retorno.descricao = resultado.GetString(4);
                    retorno.foto = resultado.GetSqlBytes(5).Buffer;
                }

                conexao.Close();
            }

            return retorno;
        }

        public static Usuario selecionar(long id)
        {
            Usuario retorno = null;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("select ID, NOME, EMAIL, SENHA, DESCRICAO, FOTO from USUARIO where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    retorno = new Usuario();

                    retorno.id = resultado.GetInt64(0);
                    retorno.nome = resultado.GetString(1);
                    retorno.email = resultado.GetString(2);
                    retorno.senha = resultado.GetString(3);
                    retorno.descricao = resultado.GetString(4);
                    retorno.foto = resultado.GetSqlBytes(5).Buffer;
                }

                conexao.Close();
            }

            return retorno;
        }

        public static List<Usuario> selecionar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("select ID, NOME, EMAIL, SENHA, DESCRICAO, FOTO from USUARIO;", conexao);
                SqlDataReader resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    Usuario retorno = new Usuario();

                    retorno.id = resultado.GetInt64(0);
                    retorno.nome = resultado.GetString(1);
                    retorno.email = resultado.GetString(2);
                    retorno.senha = resultado.GetString(3);
                    retorno.descricao = resultado.GetString(4);
                    retorno.foto = resultado.GetSqlBytes(5).Buffer;

                    lista.Add(retorno);
                }

                conexao.Close();
            }

            return lista;
        }

        public static Usuario inserir(Usuario registro)
        {
            Usuario retorno = null;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("insert into USUARIO values(NEWID(), @NOME, @EMAIL, @SENHA, @DESCRICAO, @FOTO);", conexao);
                comando.Parameters.AddWithValue("@NOME", registro.nome);
                comando.Parameters.AddWithValue("@EMAIL", registro.email);
                comando.Parameters.AddWithValue("@SENHA", registro.senha);
                comando.Parameters.AddWithValue("@DESCRICAO", registro.descricao);
                comando.Parameters.AddWithValue("@FOTO", registro.foto);
                SqlDataReader resultado = comando.ExecuteReader();

                if (resultado.Read())
                {
                    retorno = new Usuario();

                    retorno.id = resultado.GetInt64(0);
                    retorno.nome = resultado.GetString(1);
                    retorno.email = resultado.GetString(2);
                    retorno.senha = resultado.GetString(3);
                    retorno.descricao = resultado.GetString(4);
                    retorno.foto = resultado.GetSqlBytes(5).Buffer;
                }

                conexao.Close();
            }
            return retorno;
        }

        public static bool atualizar(Usuario registro, long id)
        {
            int alterou = 0;

            using (SqlConnection conexao = new SqlConnection(conexaoBanco))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("update USUARIO set NOME = @NOME, EMAIL = @EMAIL, SENHA = @SENHA, DESCRICAO = @DESCRICAO, FOTO = @FOTO where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@NOME", registro.nome);
                comando.Parameters.AddWithValue("@EMAIL", registro.email);
                comando.Parameters.AddWithValue("@SENHA", registro.senha);
                comando.Parameters.AddWithValue("@DESCRICAO", registro.descricao);
                comando.Parameters.AddWithValue("@FOTO", registro.foto);
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

                SqlCommand comando = new SqlCommand("delete from USUARIO where ID = @id;", conexao);
                comando.Parameters.AddWithValue("@id", id);
                excluiu = comando.ExecuteNonQuery();

                conexao.Close();
            }

            return excluiu > 0;
        }
    }
}