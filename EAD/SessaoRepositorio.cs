using EAD;
using System.Data.SqlClient;

namespace EAD
{
    public class SessaoRepositorio
    {
        public void Adicionar(Sessao sessao)
        {
            using SqlConnection conn = new(DB.ConnectionString);
            conn.Open();
            var cmd = new SqlCommand("INSERT INTO Sessoes (IdFilme, Data, Hora) VALUES (@IdFilme, @Data, @Hora)", conn);
            cmd.Parameters.AddWithValue("@IdFilme", sessao.IdFilme);
            cmd.Parameters.AddWithValue("@Data", sessao.Data);
            cmd.Parameters.AddWithValue("@Hora", sessao.Hora);
            cmd.ExecuteNonQuery();
        }

        public List<Sessao> ListarPorFilme(int idFilme)
        {
            List<Sessao> sessoes = new();
            using SqlConnection conn = new(DB.ConnectionString);
            conn.Open();
            var cmd = new SqlCommand("SELECT * FROM Sessoes WHERE IdFilme=@IdFilme", conn);
            cmd.Parameters.AddWithValue("@IdFilme", idFilme);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                sessoes.Add(new Sessao
                {
                    IdSessao = (int)reader["IdSessao"],
                    IdFilme = (int)reader["IdFilme"],
                    Data = (DateTime)reader["Data"],
                    Hora = (TimeSpan)reader["Hora"]
                });
            }
            return sessoes;
        }

        public void Atualizar(Sessao sessao)
        {
            using SqlConnection conn = new(DB.ConnectionString);
            conn.Open();
            var cmd = new SqlCommand("UPDATE Sessoes SET Data=@Data, Hora=@Hora WHERE IdSessao=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", sessao.IdSessao);
            cmd.Parameters.AddWithValue("@Data", sessao.Data);
            cmd.Parameters.AddWithValue("@Hora", sessao.Hora);
            cmd.ExecuteNonQuery();
        }

        public void Deletar(int id)
        {
            using SqlConnection conn = new(DB.ConnectionString);
            conn.Open();
            var cmd = new SqlCommand("DELETE FROM Sessoes WHERE IdSessao=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
    }
}