using BibliotecaTP.Colecciones;
using System;

class Program
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca();

        CargarLibros(10, biblioteca);
        biblioteca.ListarLibros();

        Console.WriteLine("TEST Lector existente:");
        Console.WriteLine(biblioteca.AltaLector("Pepe", "12345678"));

        Console.WriteLine("TEST Lector inexistente:");
        Console.WriteLine(biblioteca.PrestarLibro("Libro3", "12345679"));

        Console.WriteLine("TEST Libro inexistente:");
        Console.WriteLine(biblioteca.PrestarLibro("Libr3", "12345678"));

        Console.WriteLine("TEST Exitoso:");
        Console.WriteLine("Prestando Libro3:");
        Console.WriteLine(biblioteca.PrestarLibro("Libro3", "12345678"));

        Console.WriteLine("Prestando Libro4:");
        Console.WriteLine(biblioteca.PrestarLibro("Libro4", "12345678"));

        Console.WriteLine("Prestando Libro5:");
        Console.WriteLine(biblioteca.PrestarLibro("Libro5", "12345678"));

        Console.WriteLine("TEST Tope:");
        Console.WriteLine(biblioteca.PrestarLibro("Libro2", "12345678"));

        biblioteca.ListarLibros();

        Console.ReadKey();
    }

    static void CargarLibros(int cantidad, Biblioteca biblioteca)
    {
        for (int i = 1; i <= cantidad; i++)
        {
            bool agregado = biblioteca.AgregarLibro($"Libro{i}", $"Autor{i}", $"Editorial{i}");
            Console.WriteLine(agregado
                ? $"Libro{i} agregado correctamente."
                : $"Libro{i} ya existe en la biblioteca.");
        }
    }
}