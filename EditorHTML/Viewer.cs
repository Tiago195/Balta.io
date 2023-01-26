using System;
using System.IO;
using System.Text.RegularExpressions;

public class Viewer
{
  public static void Show()
  {
    Console.Clear();

    Console.BackgroundColor = ConsoleColor.White;
    Console.ForegroundColor = ConsoleColor.Black;

    Console.Clear();

    Console.WriteLine("MODO VISUALIZAÇÃO");
    Console.WriteLine("=================");
    System.Console.WriteLine("Me informe o caminho do arquivo");
    var path = Console.ReadLine();

    ReadFile(path);

    Console.WriteLine("=================");
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
    Console.ReadKey();
    Menu.Show();
  }

  public static void Replace(string text)
  {
    var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
    var words = text.Split(' ');

    for (var i = 0; i < words.Length; i++)
    {
      if (strong.IsMatch(words[i]))
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(
          words[i].Substring(
            words[i].IndexOf('>') + 1,
            (words[i].LastIndexOf('<') - 1) - words[i].IndexOf('>')
          )
        );
        Console.Write(' ');
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write(words[i]);
        Console.Write(' ');
      }
    }
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Write(Environment.NewLine);
  }

  public static void ReadFile(string path)
  {
    using (var file = new StreamReader(path))
    {
      // System.Console.WriteLine(file.ReadToEnd());
      Replace(file.ReadToEnd());
    }
  }
}