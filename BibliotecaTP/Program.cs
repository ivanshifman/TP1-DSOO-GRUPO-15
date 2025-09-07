using BibliotecaTP.Colecciones;
using System;
using System.Collections.Generic;
using System.Text;

internal class Program
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca();

        cargarLibros(10, biblioteca);
        cargarLibros(2, biblioteca);
        biblioteca.listarLibros();
        Console.WriteLine("Eliminamos el Libro5 de la biblioteca:");
        biblioteca.eliminarLibro("Libro5");
        biblioteca.listarLibros();

        // ultima consigna Semana 5

        Console.WriteLine("TEST alta de Lector:");
        Console.WriteLine(biblioteca.altaLector("Pepe", "12345678"));

        Console.WriteLine("TEST alta de Lector YA EXISTE:");
        Console.WriteLine(biblioteca.altaLector("Pepe", "12345678"));

        Console.WriteLine("TEST Presta Libro a Lector DNI inexistente:");
        Console.WriteLine(biblioteca.prestarLibro("Libro3", "12345679"));

        Console.WriteLine("TEST Presta Libro inexistente a Lector:");
        Console.WriteLine(biblioteca.prestarLibro("Libr3", "12345678"));

        Console.WriteLine("Prestando Libro3:");
        Console.WriteLine(biblioteca.prestarLibro("Libro3", "12345678"));

        Console.WriteLine("Prestando Libro4:");
        Console.WriteLine(biblioteca.prestarLibro("Libro4", "12345678"));

        Console.WriteLine("Prestando Libro6:");
        Console.WriteLine(biblioteca.prestarLibro("Libro6", "12345678"));

        Console.WriteLine("TEST Tope de prestamo:");
        Console.WriteLine(biblioteca.prestarLibro("Libro2", "12345678"));

        Console.WriteLine("Listado actualizado de libros disponibles en la biblioteca:");
        biblioteca.listarLibros();

        Console.WriteLine("TEST MUESTRA Los libros prestados al lector:");
        Console.WriteLine(biblioteca.librosPrestadosAlLector("12345678"));

        Console.WriteLine("TEST DEVUELVE Libro 4:");
        Console.WriteLine(biblioteca.devolverLibro("Libro4", "12345678"));

        Console.WriteLine("TEST DEVUELVE Libro 411 inexistente:");
        Console.WriteLine(biblioteca.devolverLibro("Libro411", "12345678"));

        Console.WriteLine("TEST DEVUELVE Libro4 lector no existe:");
        Console.WriteLine(biblioteca.devolverLibro("Libro4", "12345679"));

        Console.WriteLine("TEST MUESTRA Los libros prestados al lector:");
        Console.WriteLine(biblioteca.librosPrestadosAlLector("12345678"));

        Console.WriteLine("Listado actualizado de libros disponibles en la biblioteca:");
        biblioteca.listarLibros();

        Console.WriteLine("Presione una tecla para finalizar...");
        Console.ReadKey();
    }

    static void cargarLibros(int cantidad, Biblioteca biblioteca)
    {
        for (int i = 1; i <= cantidad; i++)
        {
            bool agregado = biblioteca.agregarLibro($"Libro{i}", $"Autor{i}", $"Editorial{i}");
            Console.WriteLine(agregado
                ? $"Libro{i} agregado correctamente."
                : $"Libro{i} ya existe en la biblioteca.");
        }
    }
}