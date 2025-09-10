using BibliotecaTP.Colecciones;

internal class Program
{
    private static void Main(string[] _)
    {
        Biblioteca biblioteca = new();

        CargarLibros(10, biblioteca);
        Console.WriteLine(biblioteca.ListarLibros());

        Console.WriteLine("Eliminamos el Libro5 de la biblioteca:");
        Console.WriteLine(biblioteca.EliminarLibro("Libro5"));
        Console.WriteLine(biblioteca.ListarLibros());

        // ultima consigna Semana 5

        Console.WriteLine("TEST alta de Lector:");
        Console.WriteLine(biblioteca.AltaLector("Pepe", "12345678"));

        Console.WriteLine("TEST alta de Lector YA EXISTE:");
        Console.WriteLine(biblioteca.AltaLector("Pepe", "12345678"));

        Console.WriteLine("TEST Presta Libro a Lector DNI inexistente:");
        Console.WriteLine(biblioteca.PrestarLibro("Libro3", "12345679"));

        Console.WriteLine("TEST Presta Libro inexistente a Lector:");
        Console.WriteLine(biblioteca.PrestarLibro("Libr3", "12345678"));

        Console.WriteLine("Prestando Libro3:");
        Console.WriteLine(biblioteca.PrestarLibro("Libro3", "12345678"));

        Console.WriteLine("Prestando Libro4:");
        Console.WriteLine(biblioteca.PrestarLibro("Libro4", "12345678"));

        Console.WriteLine("Prestando Libro6:");
        Console.WriteLine(biblioteca.PrestarLibro("Libro6", "12345678"));

        Console.WriteLine("TEST Tope de prestamo:");
        Console.WriteLine(biblioteca.PrestarLibro("Libro2", "12345678"));

        Console.WriteLine("Listado actualizado de libros disponibles en la biblioteca:");
        Console.WriteLine(biblioteca.ListarLibros());

        Console.WriteLine("TEST MUESTRA Los libros prestados al lector:");
        Console.WriteLine(biblioteca.LibrosPrestadosAlLector("12345678"));

        Console.WriteLine("TEST DEVUELVE Libro 4:");
        Console.WriteLine(biblioteca.DevolverLibro("Libro4", "12345678"));

        Console.WriteLine("TEST DEVUELVE Libro 411 inexistente:");
        Console.WriteLine(biblioteca.DevolverLibro("Libro411", "12345678"));

        Console.WriteLine("TEST DEVUELVE Libro4 lector no existe:");
        Console.WriteLine(biblioteca.DevolverLibro("Libro4", "12345679"));

        Console.WriteLine("TEST MUESTRA Los libros prestados al lector:");
        Console.WriteLine(biblioteca.LibrosPrestadosAlLector("12345678"));

        Console.WriteLine("Listado actualizado de libros disponibles en la biblioteca:");
        Console.WriteLine(biblioteca.ListarLibros());

        Console.WriteLine("Presione una tecla para finalizar...");
        Console.ReadKey();
    }

    private static void CargarLibros(int cantidad, Biblioteca biblioteca)
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
