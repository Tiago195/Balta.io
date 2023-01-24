using System;

namespace Stopwatch;

public class Program
{
  static void Main(string[] args)
  {
    Menu();
  }

  static void Menu()
  {
    Console.Clear();

    Console.WriteLine("S = Segundos => 10s = 10 segundos");
    Console.WriteLine("M = Minutos => 10m = 10 minutos");
    Console.WriteLine("0s = Sair");
    Console.WriteLine("Quanto tempo deseja contar?");

    string data = Console.ReadLine().ToLower();
    // char type = data[data.Length - 1];
    char type = char.Parse(data.Substring(data.Length - 1, 1));
    int time = int.Parse(data[..^1]);
    int multiplier = 1;

    if (type == 'm') multiplier = 60;

    if (time == 0) Environment.Exit(0);

    PreStart(time * multiplier);
  }

  static void PreStart(int time)
  {
    Console.Clear();

    System.Console.WriteLine("Ready.");
    Thread.Sleep(1000);

    System.Console.WriteLine("Set..");
    Thread.Sleep(1000);

    System.Console.WriteLine("Go...");
    Thread.Sleep(1000);

    Start(time);
  }

  static void Start(int time)
  {
    int currentTime = 0;

    while (currentTime != time)
    {
      Console.Clear();

      currentTime++;

      Console.WriteLine(currentTime);

      Thread.Sleep(1000);
    }

    Console.Clear();
    Console.WriteLine("Stopwatch finalizado");
    Thread.Sleep(2000);
    Menu();
  }
}