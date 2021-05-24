using System;

namespace Primeiro_Projeto
{
    class Program
    {
        static FilmeRepositorio repositorio = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoDoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        listarFilmes();
                        break;
                    case "2":
                        inserirFilmes();
                        break;
                    case "3":
                        atualizarFilme();
                        break;
                    case "4":
                        excluirFilme();
                        break;
                    case "5":
                        visualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                }

                opcaoUsuario = ObterOpcaoDoUsuario();
            }
        }
        private static void listarFilmes()
        {
            Console.WriteLine("Listar filmes");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado.");
                Console.ReadKey();
                return;
            }

            foreach(var filme in lista)
            {
                var excluido = filme.retornaExcluido();

                Console.WriteLine("#ID {0} - {1} - {2}", filme.retornaId(), filme.retornaTitulo(), excluido ? "Excluído" : "");
            }
            Console.ReadKey();
        }
        private static void inserirFilmes()
        {
            Console.WriteLine("Inserir novo filme");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite um gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(id: repositorio.ProximoId(),
                                        Genero: (Genero)entradaGenero,
                                        Titulo: entradaTitulo,
                                        Ano: entradaAno,
                                        Descricao: entradaDescricao
                                        );

            repositorio.Insere(novoFilme);
        }
        private static void atualizarFilme()
        {
            Console.WriteLine("Atualizar filme");

            Console.Write("Digite o ID do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite um gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(id: indiceFilme,
                                        Genero: (Genero)entradaGenero,
                                        Titulo: entradaTitulo,
                                        Ano: entradaAno,
                                        Descricao: entradaDescricao
                                        );

            repositorio.Atualiza(indiceFilme, atualizaFilme);
        }
        private static void excluirFilme()
        {
            Console.WriteLine("Excluir filme");

            Console.Write("Digite o ID do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceFilme);
        }
        private static void visualizarFilme()
        {
            Console.WriteLine("Visualizar filme");

            Console.Write("Digite o ID do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorio.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);
        }
        private static string ObterOpcaoDoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Filmes ao seu dispor!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar filmes");
            Console.WriteLine("2- Inserir novo filme");
            Console.WriteLine("3- Atualizar filme");
            Console.WriteLine("4- Excluir filme");
            Console.WriteLine("5- Visualizar filme");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
