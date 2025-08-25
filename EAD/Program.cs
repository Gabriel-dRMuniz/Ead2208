using EAD;
using System;

class Program
{
    static CinemaService cinemaService = new();

    static void Main()
    {
        int opcao;
        do
        {
            Console.WriteLine("\n==== CINEMA MANAGER ====");
            Console.WriteLine("1. Cadastrar Filme");
            Console.WriteLine("2. Listar Filmes");
            Console.WriteLine("3. Atualizar Filme");
            Console.WriteLine("4. Deletar Filme");
            Console.WriteLine("5. Cadastrar Sessão");
            Console.WriteLine("6. Listar Sessões por Filme");
            Console.WriteLine("7. Atualizar Sessão");
            Console.WriteLine("8. Deletar Sessão");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    cinemaService.CadastrarFilme();
                    break;
                case 2:
                    cinemaService.ListarFilmes();
                    break;
                case 3:
                    cinemaService.AtualizarFilme();
                    break;
                case 4:
                    cinemaService.DeletarFilme();
                    break;
                case 5:
                    cinemaService.CadastrarSessao();
                    break;
                case 6:
                    cinemaService.ListarSessoesPorFilme();
                    break;
                case 7:
                    cinemaService.AtualizarSessao();
                    break;
                case 8:
                    cinemaService.DeletarSessao();
                    break;
                case 0:
                    Console.WriteLine("Encerrando...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        } while (opcao != 0);
    }
}
