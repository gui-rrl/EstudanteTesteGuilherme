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
        public string Nome { get; set; }
        public string Senha { get; set; }

        public bool Login()
        {
            SqlConnection connection = new SqlConnection("Server=GUILHERME;Database=Estudantes;" +
            "Trusted_Connection=True");

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand cmd = new SqlCommand("ADM2.spo_Usuario_Login", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
                if (dr.Read())
                    if (this.Senha == dr["Senha"].ToString())
                        this.Identificador = Convert.ToInt32(dr["Identificador"]);
                        this.Nome = dr["Nome"].ToString();
                        return true;
        }

       
        //public static void Logar(string email, string senha)
        //{
        //    SqlConnection connection = new SqlConnection("Server = GUILHERME; Database = Estudantes;" +
        //       "Trusted_Connection=True");

        //    if (connection.State == ConnectionState.Closed)
        //    {
        //        connection.Open();
        //    }

        //    SqlCommand cmd = new SqlCommand($"SELECT Identificador, Email, Nome, Senha FROM ADM2.Usuarios WHERE Email = '{email}' AND Senha = '{senha}'");
        //    cmd.CommandType = CommandType.Text;
        //    SqlDataReader dr = cmd.ExecuteReader();

        //    if (dr.Read())
        //    {
        //        int usuarioId = dr.GetInt32(0);
        //        string nome = dr.GetString(1);

        //        // Claim/declaração permite o acesso a um recurso com base no valor e na política de autorização definida
        //        List<Claim> direitoAcesso = new List<Claim>
        //        {
        //            //Pega as informações do usuário, caso precise utiliza-las depois
        //            new Claim(ClaimTypes.NameIdentifier, usuarioId.ToString()),
        //            new Claim(ClaimTypes.Name, nome)
        //        };

        //        //Variavel vai salvar os direitos de acesso em um "cookie" 
        //        var identity = new ClaimsIdentity(direitoAcesso, "Identity.Login");

        //        //Seta um Claims Principal com o Claims identity
        //        var userPrincipal = new ClaimsPrincipal(new[] { identity });

        //        //SignInAsync do HttpContext pede um Claims Principal para logar
        //        HttpContext.SignInAsync(userPrincipal);
        //    }
        //}
    }
}
