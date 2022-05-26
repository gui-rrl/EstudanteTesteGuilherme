using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Models
{
    public class Estudante
    {
        public int Identificador { get; set; }
        public string Nome { get; set; }
        public string Curso { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Status { get; set; }

        public class Filtro
        {
            public string Identificador { get; set; }
            public string Nome { get; set; }
            public string Curso { get; set; }
            public int Status { get; set; }
        }
        public static List<Estudante> SelecionarFiltro(Filtro filtro)
        {
            SqlConnection connection = new SqlConnection("Server=GUILHERME;Database=Estudantes;" +
               "Trusted_Connection=True");

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand cmd = new SqlCommand("spo_EstudanteTesteGuilherme_SelecionarFiltro", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            if (filtro.Identificador != default)
            {
                cmd.Parameters.AddWithValue("@Identificador", filtro.Identificador);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Identificador", DBNull.Value);
            }

            if (filtro.Nome != default)
            {
                cmd.Parameters.AddWithValue("@Nome", filtro.Nome);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Nome", DBNull.Value);
            }

            if (filtro.Curso != default)
            {
                cmd.Parameters.AddWithValue("@Curso", filtro.Curso);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Curso", DBNull.Value);
            }

            if (filtro.Status != default)
            {
                cmd.Parameters.AddWithValue("@Status", filtro.Status);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Status", DBNull.Value);
            }

            SqlDataReader dr = cmd.ExecuteReader();
            List<Estudante> listaEstudante = new List<Estudante>();

            while (dr.Read())
            {
                Estudante estudante = new Estudante();
                estudante.Identificador = Convert.ToInt32(dr["Identificador"].ToString());
                estudante.Nome = dr["Nome"].ToString();
                estudante.Curso = dr["Curso"].ToString();
                estudante.Status = Convert.ToBoolean(dr["Status"].ToString());

                listaEstudante.Add(estudante);
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            return listaEstudante;
        }

        public static Estudante Selecionar(int identificador)
        {
            SqlConnection connection = new SqlConnection("Server=GUILHERME;Database=Estudantes;" +
               "Trusted_Connection=True");

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand cmd = new SqlCommand("spo_EstudanteTesteGuilherme_Selecionar", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Identificador", identificador);
            SqlDataReader dr = cmd.ExecuteReader();
            Estudante estudante = new Estudante();

            while (dr.Read())
            {
                estudante.Identificador = Convert.ToInt32(dr["Identificador"].ToString());
                estudante.Nome = dr["Nome"].ToString();
                estudante.Curso = dr["Curso"].ToString();
                estudante.DataNascimento = Convert.ToDateTime(dr["DataNascimento"].ToString());
                estudante.Status = Convert.ToBoolean(dr["Status"].ToString());
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return estudante;
        }

        public static int Inserir(Estudante estudante)
        {
            SqlConnection connection = new SqlConnection("Server=GUILHERME;Database=Estudantes;" +
               "Trusted_Connection=True");

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand cmd = new SqlCommand("spo_EstudanteTesteGuilherme_Inserir", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nome", estudante.Nome);
            cmd.Parameters.AddWithValue("@Curso", estudante.Curso);
            cmd.Parameters.AddWithValue("@DataNascimento", estudante.DataNascimento);
            cmd.Parameters.AddWithValue("@Status", estudante.Status);
            int resultado = Convert.ToInt32(cmd.ExecuteScalar());

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            return resultado;
        }

        public static void Alterar(Estudante estudante)
        {
            SqlConnection connection = new SqlConnection("Server=GUILHERME;Database=Estudantes;" +
               "Trusted_Connection=True");

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand cmd = new SqlCommand("ADM2.spo_EstudanteTesteGuilherme_Alterar", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Identificador", estudante.Identificador);

            cmd.Parameters.AddWithValue("@Nome", estudante.Nome);
            cmd.Parameters.AddWithValue("@Curso", estudante.Curso);
            cmd.Parameters.AddWithValue("@DataNascimento", estudante.DataNascimento);
            cmd.Parameters.AddWithValue("@Status", estudante.Status);
            cmd.ExecuteNonQuery();

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        //public static List<Estudante> Selecionar()
        //{
        //    SqlConnection connection = new SqlConnection("Server=GUILHERME;Database=Estudantes;" +
        //       "Trusted_Connection=True");
        //    if (connection.State == ConnectionState.Closed)  //System.Data.ConnectionState.Closed
        //    {
        //        connection.Open();
        //    }
        //    SqlCommand cmd = new SqlCommand("ADM2.spo_EstudanteTesteGuilherme_SelecionarTodos", connection);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataReader dr = cmd.ExecuteReader();

        //    List<Estudante> lista = new List<Estudante>();
        //    while (dr.Read())
        //    {
        //        Estudante estudante = new Estudante();
        //        estudante.Identificador = int.Parse(dr["Identificador"].ToString());
        //        estudante.Nome = dr["Nome"].ToString();
        //        estudante.Curso = dr["Curso"].ToString();
        //        estudante.DataNascimento = Convert.ToDateTime(dr["DataNascimento"].ToString());
        //        estudante.Status = Convert.ToBoolean(dr["Status"].ToString());

        //        lista.Add(estudante);
        //    }

        //    if (connection.State == ConnectionState.Open)
        //    {
        //        connection.Close();
        //    }
        //    return lista;
        //}
    }
}
