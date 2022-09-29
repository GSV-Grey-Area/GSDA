using System;

namespace PruebasDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            char ope;
            string line;
            Console.WriteLine("Este programa manejará dos números.");
            Console.WriteLine("Escriba el primer número: ");
            line = Console.ReadLine();
            a = int.Parse(line);
            Console.WriteLine("Escriba el símbolo de la operación.");
            line = Console.ReadLine();
            ope = char.Parse(line);
            Console.WriteLine("Escriba el segundo número: ");
            line = Console.ReadLine();
            b = int.Parse(line);
            opera(a, ope, b);
        }

        static void opera(int a, char ope, int b)
        {
            int c = 0;
            if (ope == '+')
            {
                c = a + b;
                Console.WriteLine("El resultado de la suma de " + a + " y " + b + " es " + c + ".");
            }
            else if (ope == '-')
            {
                c = a - b;
                Console.WriteLine("El resultado de la resta de " + a + " y " + b + " es " + c + ".");
            }
            else if (ope == '*')
            {
                c = a * b;
                Console.WriteLine("El resultado de la multiplicación de " + a + " y " + b + " es " + c + ".");
            }
            else if (ope == '/')
            {
                c = a / b;
                Console.WriteLine("El resultado de la división de " + a + " entre " + b + " es " + c + ".");
            }
            else
            {
                Console.WriteLine("Error.");
            }
        }
    }
}

