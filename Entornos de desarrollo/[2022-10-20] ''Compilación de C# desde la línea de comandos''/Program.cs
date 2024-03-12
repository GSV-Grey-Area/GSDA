using System;

namespace Vientoporlamanana
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombre;
            Console.WriteLine("Buenos días, usuario. ¿Cómo te llamas?");
            nombre = Console.ReadLine();
            Console.WriteLine("Hola, " + nombre + ".");
        }
    }
}
