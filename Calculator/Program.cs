using System;

namespace Calculator;

public class Program
{
  static void Main(string[] args)
  {

  }

  static void Soma()
  {
    Console.Clear();
    Console.Write("Primeiro valor: ");
    double v1 = double.Parse(Console.ReadLine());

    Console.Write("Segundo valor: ");
    double v2 = double.Parse(Console.ReadLine());

    System.Console.WriteLine("");

    Console.WriteLine($"Resultado da soma é {v1 + v2}");
    Console.ReadKey();
  }
  static void Subtracao()
  {
    Console.Clear();
    Console.Write("Primeiro valor: ");
    double v1 = double.Parse(Console.ReadLine());

    Console.Write("Segundo valor: ");
    double v2 = double.Parse(Console.ReadLine());

    System.Console.WriteLine("");

    Console.WriteLine($"Resultado da subtração é {v1 - v2}");
    Console.ReadKey();
  }
}