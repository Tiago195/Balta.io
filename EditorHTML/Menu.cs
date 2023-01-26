using System;

public class Menu
{
  public static int qtdLines = 11;
  public static int qtdColun = 30;
  public static void Show()
  {
    System.Console.Clear();
    System.Console.BackgroundColor = ConsoleColor.Cyan;
    System.Console.ForegroundColor = ConsoleColor.Black;

    DrawScreen();
    WriteOptions();

    var option = short.Parse(Console.ReadLine());

    HandleMenuOptions(option);
  }

  public static void DrawScreen()
  {
    DrawLine(qtdColun, '+', '-');

    for (var line = 0; line < qtdLines; line++) DrawLine(qtdColun, '|', ' ');

    DrawLine(qtdColun, '+', '-');
  }

  static void DrawLine(int qtdColun, char FirstAndLastChar, char spaces)
  {
    System.Console.Write(FirstAndLastChar);
    for (var i = 0; i < qtdColun; i++)
    {
      System.Console.Write(spaces);
    }

    System.Console.Write(FirstAndLastChar);
    System.Console.Write("\n");
  }

  public static void WriteOptions()
  {
    System.Console.SetCursorPosition(3, 2);
    System.Console.WriteLine("Editor HTML");

    System.Console.SetCursorPosition(3, 4);
    System.Console.WriteLine("Selecione uma opção abaixo");

    System.Console.SetCursorPosition(3, 6);
    System.Console.WriteLine("1 - Novo arquivo");
    System.Console.SetCursorPosition(3, 7);
    System.Console.WriteLine("2 - Abrir");
    System.Console.SetCursorPosition(3, 9);
    System.Console.WriteLine("0 - Sair");

    System.Console.SetCursorPosition(3, 10);
    System.Console.Write("Opção: ");

  }

  public static void HandleMenuOptions(short option)
  {
    switch (option)
    {
      case 1: Editor.Show(); break;
      case 2: Viewer.Show(); break;
      case 0:
        {
          System.Console.Clear();
          Environment.Exit(0);
          break;
        }
      default: Show(); break;
    }
  }
}