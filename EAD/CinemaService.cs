using EAD;
using System;

namespace EAD
{
    public class CinemaService
    {
        private FilmeRepositorio filmeRepo = new();
        private SessaoRepositorio sessaoRepo = new();

        public void CadastrarFilme()
        {
            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Gênero: ");
            string genero = Console.ReadLine();
            Console.Write("Ano: ");
            int ano = int.Parse(Console.ReadLine());

            filmeRepo.Adicionar(new Filmes { Titulo = titulo, Genero = genero, Ano = ano });
            Console.WriteLine("Filme cadastrado com sucesso!");
        }

        public void ListarFilmes()
        {
            var filmes = filmeRepo.Listar();
            foreach (var f in filmes)
                Console.WriteLine($"{f.IdFilme}: {f.Titulo} - {f.Genero} - {f.Ano}");
        }

        public void AtualizarFilme()
        {
            Console.Write("ID do Filme: ");
            int idUp = int.Parse(Console.ReadLine());
            Console.Write("Novo Título: ");
            string newTitulo = Console.ReadLine();
            Console.Write("Novo Gênero: ");
            string newGenero = Console.ReadLine();
            Console.Write("Novo Ano: ");
            int newAno = int.Parse(Console.ReadLine());

            filmeRepo.Atualizar(new Filmes { IdFilme = idUp, Titulo = newTitulo, Genero = newGenero, Ano = newAno });
            Console.WriteLine("Filme atualizado com sucesso!");
        }

        public void DeletarFilme()
        {
            Console.Write("ID do Filme a deletar: ");
            int idDel = int.Parse(Console.ReadLine());
            filmeRepo.Deletar(idDel);
            Console.WriteLine("Filme deletado com sucesso!");
        }

        public void CadastrarSessao()
        {
            Console.Write("ID do Filme: ");
            int idFilme = int.Parse(Console.ReadLine());
            Console.Write("Data (yyyy-mm-dd): ");
            DateTime data = DateTime.Parse(Console.ReadLine());
            Console.Write("Hora (HH:mm): ");
            TimeSpan hora = TimeSpan.Parse(Console.ReadLine());

            sessaoRepo.Adicionar(new Sessao { IdFilme = idFilme, Data = data, Hora = hora });
            Console.WriteLine("Sessão cadastrada com sucesso!");
        }

        public void ListarSessoesPorFilme()
        {
            Console.Write("ID do Filme: ");
            int idList = int.Parse(Console.ReadLine());
            var sessoes = sessaoRepo.ListarPorFilme(idList);
            foreach (var s in sessoes)
                Console.WriteLine($"{s.IdSessao}: {s.Data.ToShortDateString()} às {s.Hora}");
        }

        public void AtualizarSessao()
        {
            Console.Write("ID da Sessão: ");
            int idS = int.Parse(Console.ReadLine());
            Console.Write("Nova Data (yyyy-mm-dd): ");
            DateTime newData = DateTime.Parse(Console.ReadLine());
            Console.Write("Nova Hora (HH:mm): ");
            TimeSpan newHora = TimeSpan.Parse(Console.ReadLine());

            sessaoRepo.Atualizar(new Sessao { IdSessao = idS, Data = newData, Hora = newHora });
            Console.WriteLine("Sessão atualizada com sucesso!");
        }

        public void DeletarSessao()
        {
            Console.Write("ID da Sessão a deletar: ");
            int idSessaoDel = int.Parse(Console.ReadLine());
            sessaoRepo.Deletar(idSessaoDel);
            Console.WriteLine("Sessão deletada com sucesso!");
        }
    }
}

