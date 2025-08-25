using EAD;

class Program
{
    static FilmeRepositorio filmeRepo = new();
    static SessaoRepositorio sessaoRepo = new();

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
                    Console.Write("Título: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Gênero: ");
                    string genero = Console.ReadLine();
                    Console.Write("Ano: ");
                    int ano = int.Parse(Console.ReadLine());
                    filmeRepo.Adicionar(new Filmes { Titulo = titulo, Genero = genero, Ano = ano });
                    break;

                case 2:
                    var filmes = filmeRepo.Listar();
                    foreach (var f in filmes)
                        Console.WriteLine($"{f.IdFilme}: {f.Titulo} - {f.Genero} - {f.Ano}");
                    break;

                case 3:
                    Console.Write("ID do Filme: ");
                    int idUp = int.Parse(Console.ReadLine());
                    Console.Write("Novo Título: ");
                    string newTitulo = Console.ReadLine();
                    Console.Write("Novo Gênero: ");
                    string newGenero = Console.ReadLine();
                    Console.Write("Novo Ano: ");
                    int newAno = int.Parse(Console.ReadLine());
                    filmeRepo.Atualizar(new Filmes { IdFilme = idUp, Titulo = newTitulo, Genero = newGenero, Ano = newAno });
                    break;

                case 4:
                    Console.Write("ID do Filme a deletar: ");
                    int idDel = int.Parse(Console.ReadLine());
                    filmeRepo.Deletar(idDel);
                    break;

                case 5:
                    Console.Write("ID do Filme: ");
                    int idFilme = int.Parse(Console.ReadLine());
                    Console.Write("Data (yyyy-mm-dd): ");
                    DateTime data = DateTime.Parse(Console.ReadLine());
                    Console.Write("Hora (HH:mm): ");
                    TimeSpan hora = TimeSpan.Parse(Console.ReadLine());
                    sessaoRepo.Adicionar(new Sessao { IdFilme = idFilme, Data = data, Hora = hora });
                    break;

                case 6:
                    Console.Write("ID do Filme: ");
                    int idList = int.Parse(Console.ReadLine());
                    var sessoes = sessaoRepo.ListarPorFilme(idList);
                    foreach (var s in sessoes)
                        Console.WriteLine($"{s.IdSessao}: {s.Data.ToShortDateString()} às {s.Hora}");
                    break;

                case 7:
                    Console.Write("ID da Sessão: ");
                    int idS = int.Parse(Console.ReadLine());
                    Console.Write("Nova Data (yyyy-mm-dd): ");
                    DateTime newData = DateTime.Parse(Console.ReadLine());
                    Console.Write("Nova Hora (HH:mm): ");
                    TimeSpan newHora = TimeSpan.Parse(Console.ReadLine());
                    sessaoRepo.Atualizar(new Sessao { IdSessao = idS, Data = newData, Hora = newHora });
                    break;

                case 8:
                    Console.Write("ID da Sessão a deletar: ");
                    int idSessaoDel = int.Parse(Console.ReadLine());
                    sessaoRepo.Deletar(idSessaoDel);
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
