using System;
using System.IO;
using System.Text;

public class Editor
{
  public static void Show()
  {
    System.Console.Clear();

    System.Console.BackgroundColor = ConsoleColor.White;
    System.Console.ForegroundColor = ConsoleColor.Black;

    System.Console.Clear();

    System.Console.WriteLine("MODO EDITOR");
    System.Console.WriteLine("===========");
    System.Console.WriteLine(" ");

    Start();
  }

  public static void Start()
  {
    var file = new StringBuilder();
    do
    {
      file.Append(Console.ReadLine());
      file.Append(Environment.NewLine);

    } while (Console.ReadKey().Key != ConsoleKey.Escape);

    System.Console.WriteLine("===============================");
    System.Console.WriteLine("Deseja salvar o arquivo? (s/n)");
    var isSave = Console.ReadKey().Key == ConsoleKey.S;

    if (isSave) Save(file.ToString());
    else
    {
      System.Console.WriteLine("");
      System.Console.WriteLine("Excluindo texto...");
      System.Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
      System.Console.ReadKey();
      Menu.Show();
    }
  }

  static void Save(string text)
  {
    System.Console.Clear();
    System.Console.WriteLine("Onde devo salvar o arquivo");

    var path = Console.ReadLine();
    using (var file = new StreamWriter(path))
    {
      file.Write(text);
    }
    System.Console.WriteLine("==================================");
    System.Console.WriteLine($"Arquivo {path} salvo com sucesso.");
    System.Console.WriteLine("");
    System.Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
    System.Console.ReadKey();

    Menu.Show();

  }
}