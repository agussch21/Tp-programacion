using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("¿Cómo te llamás?");
        
        string? nombre = Console.ReadLine();

        Console.WriteLine("y tu edad cual es?");

        int edad = int.Parse(Console.ReadLine());
        

        Console.WriteLine("Tu nombre es: " + nombre);
        Console.WriteLine("tu edad es:"+edad.ToString());
    }
}