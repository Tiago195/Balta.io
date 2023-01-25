using System;
using System.IO;

public class Program
{
  static void Main(string[] args)
  {
    Menu();
  }

  static void Menu()
  {
    System.Console.Clear();
    System.Console.WriteLine("O que deseja?");

    System.Console.WriteLine("1 - Abrir arquivo");
    System.Console.WriteLine("2 - Criar novo arquivo");
    System.Console.WriteLine("0 - Sair");

    short option = short.Parse(Console.ReadLine());

    switch (option)
    {
      case 1: Open(); break;
      case 2: New(); break;
      case 0: Environment.Exit(0); break;
      default: Menu(); break;
    }
  }

  static void Open()
  {
    System.Console.Clear();

    System.Console.WriteLine("Qual arquivo deseja abrir?");

    string path = System.Console.ReadLine();

    using (var file = new StreamReader(path))
    {
      System.Console.WriteLine("Seu arquivo abaixo");
      System.Console.WriteLine("");
      System.Console.WriteLine(file.ReadToEnd());
    }

    System.Console.WriteLine("");
    System.Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
    System.Console.ReadKey();

    Menu();
  }

  static void New()
  {
    System.Console.Clear();

    System.Console.WriteLine("Digite seu texto abaixo");
    System.Console.WriteLine("");

    string text = "";

    do
    {
      text += Console.ReadLine();
      text += Environment.NewLine;
    }
    while (Console.ReadKey().Key != ConsoleKey.Escape);

    Save(text);
  }

  static void Save(string text)
  {
    System.Console.Clear();

    System.Console.WriteLine("Onde devo salvar o arquivo? me passe o caminho.");

    string path = System.Console.ReadLine();

    using (var file = new StreamWriter(path))
    {
      file.Write(text);
    }

    System.Console.WriteLine($"Arquivo {path} salvo com sucesso!");
    System.Console.ReadKey();
    Menu();
  }
}