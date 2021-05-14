using System;

namespace DIO.Chosen
{
  class Program
  {
    static SerieRepositorio repositorio = new SerieRepositorio();
    static string generalista;
    static void Main(string[] args)
    {
     Categoria();
    }

    private static void ListarSerie()
    {
      Console.WriteLine("Listar {0}", generalista);
      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine();
        Console.WriteLine("Você não possui nada cadastrado.");
        Console.WriteLine("Pressione qualquer tecla para continuar.");
        Console.ReadKey();
        return;
      }
      try{
        foreach (var serie in lista)
      {
        var excluido = serie.retornaExcluido();
        Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
      
       
      }
      
      }catch(Exception erro){
        Console.WriteLine();
        Console.WriteLine("===============ERRO==================");
        Console.WriteLine(" Tipo do erro: {0}", erro.GetType());
        Console.WriteLine(" Formato digitado não foi aceito.");
        Console.WriteLine("=====================================");
        Console.ReadKey();
      }
      
      
    }


    private static void InserirSerie()
    {
      Console.WriteLine("Inserir novo(a) {0}", generalista);

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
      try
      {
        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Título do(a) {0}: ", generalista);
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano de Início do(a) {0}: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a Descrição do {0}: ", generalista);
        string entradaDescricao = Console.ReadLine();

        Serie novaSerie = new Serie(id: repositorio.ProximoId(),
        genero: (Genero)entradaGenero,
        titulo: entradaTitulo,
        ano: entradaAno,
        descricao: entradaDescricao);

        repositorio.Insere(novaSerie);
      }
      catch (Exception erro)
      {
        Console.WriteLine();
        Console.WriteLine("===============ERRO==================");
        Console.WriteLine(" Tipo do erro: {0}", erro.GetType());
        Console.WriteLine(" Formato digitado não foi aceito.");
        Console.WriteLine("=====================================");
        Console.ReadKey();
      }



    }

    private static void AtualizarSerie()
    {
      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine();
        Console.WriteLine("Você não possui nada cadastrado.");
        Console.WriteLine("Pressione qualquer tecla para continuar.");
        Console.ReadKey();
        return;
      }
      
      try{
      Console.Write("Digite o id do(a) {0}: ", generalista);
      int indiceSerie = int.Parse(Console.ReadLine());

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
      Console.Write("Digite o gênero entre as opções acima:");
      int entradaGenero = int.Parse(Console.ReadLine());

      Console.Write("Digite o Título do(a) {0}: ", generalista);
      string entradaTitulo = Console.ReadLine();

      Console.Write("Digite o Ano de Início do(a) {0}: ", generalista);
      int entradaAno = int.Parse(Console.ReadLine());

      Console.Write("Digite a Descrição da {0}: ", generalista);
      string entradaDescricao = Console.ReadLine();

      Serie atualizaSerie = new Serie(id: indiceSerie,
      genero: (Genero)entradaGenero,
      titulo: entradaTitulo,
      ano: entradaAno,
      descricao: entradaDescricao);

      repositorio.Atualiza(indiceSerie, atualizaSerie);
      }catch(ArgumentOutOfRangeException erro)
      {
        Console.WriteLine();
        Console.WriteLine("===============ERRO==================");
        Console.WriteLine(" Tipo do erro: {0}", erro.GetType());
        Console.WriteLine(" Argumento fora do range de exceção.");
        Console.WriteLine("=====================================");
        Console.ReadKey();
      }catch(Exception erro)
      {
        Console.WriteLine();
        Console.WriteLine("===============ERRO==================");
        Console.WriteLine(" Tipo do erro: {0}", erro.GetType());
        Console.WriteLine(" Dado informado não aceito.");
        Console.WriteLine("=====================================");
        Console.ReadKey();
      }
    }

    private static void ExcluirSerie()
    {
      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine();
        Console.WriteLine("Você não possui nada cadastrado.");
        Console.WriteLine("Pressione qualquer tecla para continuar.");
        Console.ReadKey();
        return;
      } 
      
      try
      {
        Console.Write("Digite o id do(a) {0}: ", generalista);
        int indiceSerie = int.Parse(Console.ReadLine());
        
        repositorio.Exclui(indiceSerie);
      
      }catch(Exception erro){
        Console.WriteLine();
        Console.WriteLine("===============ERRO==================");
        Console.WriteLine();
        Console.WriteLine("Tipo do erro: {0}", erro.GetType());
        Console.WriteLine("Formato digitado não aceito.");
        Console.WriteLine("=====================================");
        Console.ReadKey();
      }
    }

    private static void VisualizarSerie()
    {
       var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine();
        Console.WriteLine("Você não possui nada cadastrado.");
        Console.WriteLine("Pressione qualquer tecla para continuar.");
        Console.ReadKey();
        return;
      }
      try{
      Console.Write("Digite o id do(a) {0}: ", generalista);
      int indiceSerie = int.Parse(Console.ReadLine());

      var serie = repositorio.RetornaPorId(indiceSerie);

      Console.WriteLine(serie);
      
      }catch(Exception erro){
        Console.WriteLine();
        Console.WriteLine("================ERRO==================");
        Console.WriteLine(" Tipo do erro: {0}", erro.GetType());
        Console.WriteLine(" Formato digitado não foi aceito.");
        Console.WriteLine("======================================");
        Console.ReadKey();
      }
      
    }

    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Organizador de vídeos a seus dispor!!");
      Console.WriteLine();
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1- Listar {0}", generalista);
      Console.WriteLine("2- Inserir novo(a) {0}", generalista);
      Console.WriteLine("3- Atualizar {0} ", generalista);
      Console.WriteLine("4- Excluir {0}", generalista);
      Console.WriteLine("5- Visualizar {0}", generalista);
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }

    private static string Categoria()
    {
      Console.WriteLine();
      Console.WriteLine("Organizador de vídeos a seus dispor!!");
      Console.WriteLine();
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1- Filmes");
      Console.WriteLine("2- Séries");
      Console.WriteLine("3- Animes");
      Console.WriteLine("X- Sair");
      Console.WriteLine();
      
      string classificado = Console.ReadLine().ToUpper();
      Console.WriteLine();
      
      if (classificado == "1")
      {
        generalista = "Filmes";
        Menu();
      }
      else if (classificado == "2")
      {
        generalista = "Series";
        Menu();
      }
      else if (classificado == "3")
      {
        generalista = "Animes";
        Menu();
      }else
      {
        Console.WriteLine("A opção digitada não é válida!!");
      }
      return classificado;
    }

    private static string Menu()
    {
      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarSerie();
            break;
          case "2":
            InserirSerie();
            break;
          case "3":
            AtualizarSerie();
            break;
          case "4":
            ExcluirSerie();
            break;
          case "5":
            VisualizarSerie();
            break;
          case "C":
            Console.Clear();
            break;

          default:
            throw new ArgumentOutOfRangeException();
        }
        opcaoUsuario = ObterOpcaoUsuario();
      }
      Console.WriteLine("Obrigado por utilizar nossos serviços.");
      Console.WriteLine();
      return opcaoUsuario;
    }

  }
}
