using System;

namespace Stopwatch;

public class Program
{
  static void Main(string[] args)
  {
    Start(6);
  }

  static void Start(int time)
  {
    int currentTime = 0;

    while (currentTime != time)
    {
      System.Console.Clear();

      currentTime++;

      System.Console.WriteLine(currentTime);

      Thread.Sleep(1000);
    }

    System.Console.Clear();
    System.Console.WriteLine("Stopwatch finalizado");
    Thread.Sleep(2000);
  }
}