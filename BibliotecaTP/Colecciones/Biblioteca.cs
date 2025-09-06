using BibliotecaTP.Colecciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BibliotecaTP.Colecciones
{
    public class Biblioteca
    {
        private readonly List<Libro> libros;
        private readonly List<Lector> lectoresRegistrados;

        public Biblioteca()
        {
            libros = new List<Libro>();
            lectoresRegistrados = new List<Lector>();
        }

        private Libro? BuscarLibro(string titulo)
        {
            return libros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
        }

        private Lector? BuscarLector(string dni)
        {
            return lectoresRegistrados.FirstOrDefault(l => l.Dni == dni);
        }

        public bool AgregarLibro(string titulo, string autor, string editorial)
        {
            if (BuscarLibro(titulo) != null) return false;
            libros.Add(new Libro(titulo, autor, editorial));
            return true;
        }

        public void ListarLibros()
        {
            if (libros.Count == 0)
            {
                Console.WriteLine("No hay libros en la biblioteca.");
                return;
            }

            Console.WriteLine("Libros en la biblioteca:");
            for (int i = 0; i < libros.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {libros[i]}");
            }
        }

        public bool EliminarLibro(string titulo)
        {
            Libro? libro = BuscarLibro(titulo);
            if (libro != null)
            {
                libros.Remove(libro);
                return true;
            }
            return false;
        }

        public string AltaLector(string nombre, string dni)
        {
            if (BuscarLector(dni) != null) return $"{dni} NO HA SIDO ENCONTRADO";
            lectoresRegistrados.Add(new Lector(nombre, dni));
            return $"SE DIO DE ALTA AL LECTOR {nombre}";
        }

        public string PrestarLibro(string titulo, string dni)
        {
            Lector? lector = BuscarLector(dni);
            if (lector == null) return $"LECTOR CON DNI {dni} INEXISTENTE";
            if (lector.CantidadLibrosPrestados >= 3) return "TOPE DE PRESTAMO ALCANZADO";

            Libro? libro = BuscarLibro(titulo);
            if (libro == null) return $"LIBRO CON TITULO {titulo} INEXISTENTE";

            libros.Remove(libro);
            lector.AgregarPrestamo(libro);
            return "PRESTAMO EXITOSO";
        }
    }
}
