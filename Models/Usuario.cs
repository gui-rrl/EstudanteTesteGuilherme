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
        public string Email { get; set; }
        public string Senha { get; set; }

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
    }
}