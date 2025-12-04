using System;

class Program
{
    static void Main(string[] args)
    {
        string name = args.Length > 0 ? args[0] : "Mundo";
        Console.WriteLine($"Hola, {name}!");
    }
}