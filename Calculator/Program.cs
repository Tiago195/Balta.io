using System;

namespace Calculator;

public class Program
{
  static void Main(string[] args)
  {
    Menu();
  }

  static void Menu()
  {
    Console.Clear();

    Console.WriteLine("O que deseja fazer?");
    Console.WriteLine("1 - Soma");
    Console.WriteLine("2 - Subtração");
    Console.WriteLine("3 - Divisão");
    Console.WriteLine("4 - Multiplicação");

    System.Console.WriteLine("");
    Console.WriteLine("Selecione uma opção:");

    short res = short.Parse(Console.ReadLine());
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
  static void Divisao()
  {
    Console.Clear();
    Console.Write("Primeiro valor: ");
    double v1 = double.Parse(Console.ReadLine());

    Console.Write("Segundo valor: ");
    double v2 = double.Parse(Console.ReadLine());

    System.Console.WriteLine("");

    Console.WriteLine($"Resultado da divisão é {v1 / v2}");
    Console.ReadKey();
  }
  static void Multiplicacao()
  {
    Console.Clear();
    Console.Write("Primeiro valor: ");
    double v1 = double.Parse(Console.ReadLine());

    Console.Write("Segundo valor: ");
    double v2 = double.Parse(Console.ReadLine());

    System.Console.WriteLine("");

    Console.WriteLine($"Resultado da multiplicação é {v1 * v2}");
    Console.ReadKey();
  }
}