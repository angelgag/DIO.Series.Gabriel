using System;

namespace DIO.Series.Gabriel
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1"://Listar séries
                    ListarSeries();
                        break;
                    case "2"://adicionar série
                    InserirSerie();
                        break;
                    case "3":// atualizar série
                    AtualizarSerie();
                        break;
                    case "4"://excluir série
                    ExcluirSerie();
                        break;
                    case "5"://visualizar série
                    VisualizarSerie();
                        break;
                    case "6"://Listar Filmes
                    ListarFilmes();
                        break;
                    case "7"://adicionar Filme
                    InserirFilme();
                        break;
                    case "8":// atualizar Filme
                    AtualizarFilme();
                        break;
                    case "9"://excluir Filme
                    ExcluirFilme();
                        break;
                    case "0"://visualizar Filme
                    VisualizarFilme();
                        break;
                    case "C"://Limpar tela
                        Console.Clear();
                        break;
                    case "X":
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("Obrigado por utilizar nossos serviços!!!");
            System.Console.WriteLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visuzlizar série");
            Console.WriteLine("6- Listar filmes");
            Console.WriteLine("7- Inserir novo filme");
            Console.WriteLine("8- Atualizar filme");
            Console.WriteLine("9- Excluir filme");
            Console.WriteLine("0- Visuzlizar filme");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        
    #region Series
        private static void AtualizarSerie() 
        {
            System.Console.Write("Digite o Id da série: ");
            int indicaSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            
            System.Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o Ano de Inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a Descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indicaSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Atualiza(indicaSerie, atualizaSerie);

        }
        private static void ExcluirSerie() 
        {
            System.Console.Write("Digite o Id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(indiceSerie);
        }
        private static void InserirSerie() 
        {
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o Ano de Inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a Descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }
        private static void ListarSeries()
        {
            System.Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();
            if(lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada");
                return;
            }
            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                if(!excluido)
                    System.Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }
        private static void VisualizarSerie()
        {
            System.Console.Write("Digite o Id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            
            var serie = repositorio.RetornaPorId(indiceSerie);

            var excluido = serie.retornaExcluido();
            if(!excluido)
            {
                System.Console.WriteLine(serie);
            }
        }
    #endregion

    #region Filmes
    
        private static void AtualizarFilme() 
        {
            System.Console.Write("Digite o Id do filme: ");
            int indicaFilme = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            
            System.Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o Título do filme: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o Ano de lançamento do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a Descrição do filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(id: indicaFilme,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorioFilme.Atualiza(indicaFilme, atualizaFilme);

        }
        private static void ExcluirFilme() 
        {
            System.Console.Write("Digite o Id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());
            repositorioFilme.Exclui(indiceFilme);
        }
        private static void InserirFilme() 
        {
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o Título do filme: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o Ano lançamento do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a Descrição do filme: ");
            string entradaDescricao = Console.ReadLine();
            Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorioFilme.Insere(novoFilme);
        }
        private static void ListarFilmes()
        {
            System.Console.WriteLine("Listar filmes");

            var lista = repositorioFilme.Lista();
            if(lista.Count == 0)
            {
                System.Console.WriteLine("Nenhum filme cadastrado");
                return;
            }
            foreach(var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                if(!excluido)
                    System.Console.WriteLine("#ID {0}: - {1}", filme.retornaId(), filme.retornaTitulo());
            }
        }
        private static void VisualizarFilme()
        {
            System.Console.Write("Digite o Id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());
            
            var filme = repositorioFilme.RetornaPorId(indiceFilme);

            var excluido = filme.retornaExcluido();
            if(!excluido)
            {
                System.Console.WriteLine(filme);
            }
        }
    #endregion
    }
}
