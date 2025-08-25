using EAD;
using System.Data.SqlClient;

namespace EAD
{
    public class FilmeRepositorio
    {
        public void Adicionar(Filmes filme)
        {
            using SqlConnection conn = new(DB.ConnectionString);
            conn.Open();
            var cmd = new SqlCommand("INSERT INTO Filmes (Titulo, Genero, Ano) VALUES (@Titulo, @Genero, @Ano)", conn);
            cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
            cmd.Parameters.AddWithValue("@Genero", filme.Genero);
            cmd.Parameters.AddWithValue("@Ano", filme.Ano);
            cmd.ExecuteNonQuery();
        }

        public List<Filmes> Listar()
        {
            List<Filmes> filmes = new();
            using SqlConnection conn = new(DB.ConnectionString);
            conn.Open();
            var cmd = new SqlCommand("SELECT * FROM Filmes", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                filmes.Add(new Filmes
                {
                    IdFilme = (int)reader["IdFilme"],
                    Titulo = reader["Titulo"].ToString(),
                    Genero = reader["Genero"].ToString(),
                    Ano = (int)reader["Ano"]
                });
            }
            return filmes;
        }

        public void Atualizar(Filmes filme)
        {
            using SqlConnection conn = new(DB.ConnectionString);
            conn.Open();
            var cmd = new SqlCommand("UPDATE Filmes SET Titulo=@Titulo, Genero=@Genero, Ano=@Ano WHERE IdFilme=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", filme.IdFilme);
            cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
            cmd.Parameters.AddWithValue("@Genero", filme.Genero);
            cmd.Parameters.AddWithValue("@Ano", filme.Ano);
            cmd.ExecuteNonQuery();
        }

        public void Deletar(int id)
        {
            using SqlConnection conn = new(DB.ConnectionString);
            conn.Open();
            var cmd = new SqlCommand("DELETE FROM Filmes WHERE IdFilme=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
    }
}