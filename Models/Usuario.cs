using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Models
{
    public class Usuario
    {
        public int Identificador { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public static int Inserir(Usuario usuario)
        {
            SqlConnection connection = new SqlConnection("Server=GUILHERME;Database=Estudantes;" +
            "Trusted_Connection=True");

            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand cmd = new SqlCommand("ADM2.spo_Usuario_Inserir", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("Email", usuario.Email);
            cmd.Parameters.AddWithValue("Senha", usuario.Senha);
            int resultado = Convert.ToInt32(cmd.ExecuteScalar());
            
            if(connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return resultado;
        }

        public static void Alterar(Usuario usuario)
        {
            SqlConnection connection = new SqlConnection("Server=GUILHERME;Database=Estudantes;" +
            "Trusted_Connection=True");

            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand cmd = new SqlCommand("ADM2.spo_Usuario_Alterar", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Identificador", usuario.Identificador);
            cmd.Parameters.AddWithValue("@Email", usuario.Email);
            cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
            cmd.ExecuteNonQuery();

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        [HttpPost]
        public static bool Logar(Usuario usuario)
        {

            SqlConnection connection = new SqlConnection("Server=GUILHERME;Database=Estudantes;" +
            "Trusted_Connection=True");

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand cmd = new SqlCommand("ADM2.spo_Usuario_Login", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("Email", usuario.Email);
            cmd.Parameters.AddWithValue("Senha", usuario.Senha);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.HasRows && dr.Read())
            {
                if (usuario.Email == dr["Email"].ToString() && usuario.Senha == dr["Senha"].ToString())
                return true;
            }
            return false;
        }

        public static Usuario SelecionarPorIdentificador(int identificador)
        {
            SqlConnection connection = new SqlConnection("Server=GUILHERME;Database=Cliente;" +
               "Trusted_Connection=True");
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand cmd = new SqlCommand("ADM2.spo_Usuario_SelecionarPorIdentificador", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Identificador", identificador);
            SqlDataReader dr = cmd.ExecuteReader();

            Usuario usuario = new Usuario();

            while (dr.Read())
            {
                usuario.Identificador = int.Parse(dr["Identificador"].ToString());
                usuario.Email = dr["Email"].ToString();
                usuario.Senha = dr["Senha"].ToString();                
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return usuario;
        }
    }
}