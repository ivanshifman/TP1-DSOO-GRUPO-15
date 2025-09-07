using BibliotecaTP.Colecciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaTP.Colecciones
{
    internal class Biblioteca
    {
        private List<Libro> libros;
        private List<Lector> lectores;

        public Biblioteca()
        {
            this.libros = new List<Libro>();
            this.lectores = new List<Lector>();
        }

        private Libro? buscarLibro(string titulo)
        {
            return libros.FirstOrDefault(l => l.validaTitulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
        }

        private Lector? buscarLector(string dni)
        {
            return lectores.FirstOrDefault(l => l.validaDni == dni);
        }

        public bool agregarLibro(string titulo, string autor, string editorial)
        {
            if (buscarLibro(titulo) != null) return false;
            libros.Add(new Libro(titulo, autor, editorial));
            return true;
        }

        public void listarLibros()
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

        public bool eliminarLibro(string titulo)
        {
            Libro? libro = buscarLibro(titulo);
            if (libro != null)
            {
                libros.Remove(libro);
                Console.WriteLine($"El libro {titulo} ha sido eliminado de la biblioteca.");
                return true;
            }
            return false;
        }

        public string altaLector(string nombre, string dni)
        {
            if (buscarLector(dni) != null)
            {
                //Console.WriteLine($"LECTOR CON DNI {dni} YA EXISTE");
                return $"LECTOR CON DNI {dni} YA EXISTE";
            }
            lectores.Add(new Lector(nombre, dni));
            //Console.WriteLine($"SE DIO DE ALTA AL LECTOR {nombre}");
            return $"SE DIO DE ALTA AL LECTOR {nombre}";
        }

        public string prestarLibro(string titulo, string dni)
        {
            // 1. Buscar el lector por DNI
            Lector lectorSolicitante = buscarLector(dni);
            if (lectorSolicitante == null)
            {
                Console.WriteLine("No se puede realizar el prestamo del libro " + titulo + ", ya que el lector con dni " + dni + " no existe.");
                return "LECTOR INEXISTENTE";
            }

            // 2. Verificar que el lector no haya alcanzado el tope de préstamos (3 libros)
            if (lectorSolicitante.getLibrosPrestados().Count >= 3)
            {
                Console.WriteLine("El Lector con dni " + dni + " ha alcanzado su tope de prèstamos.");
                return "TOPE DE PRESTAMO ALCAZADO";
            }

            // 3. Buscar el libro por título en la colección de libros disponibles
            Libro libroSolicitado = buscarLibroPorTitulo(titulo);
            if (libroSolicitado == null)
            {
                Console.WriteLine("LIBRO CON TITULO " + titulo +" INEXISTENTE");
                return "LIBRO INEXISTENTE";
            }


            // 4. Si llegamos aquí, el préstamo es posible
            // Quitar el libro de la biblioteca
            libros.Remove(libroSolicitado);

            // Asignar el libro al lector
            lectorSolicitante.agregarLibro(libroSolicitado);
            Console.WriteLine("Se prestò el libro:" + titulo + " al lector con DNI: " + dni);
            return "PRESTAMO EXITOSO";
        }

        // Método auxiliar para buscar libro por título
        private Libro buscarLibroPorTitulo(string titulo)
        {
            for (int i = 0; i < libros.Count; i++)
            {
                if (libros[i].getTitulo().Equals(titulo))
                {
                    return libros[i];
                }
            }
            return null;
        }


        public string devolverLibro(string titulo, string dni)
        {
            // 1. Buscar el lector por DNI
            Lector lectorSolicitante = buscarLector(dni);
            if (lectorSolicitante == null)
            {
                Console.WriteLine("No se puede realizar la devolucion del prestamo del libro " + titulo + ", ya que el lector con dni " + dni + " no existe.");
                return "LECTOR INEXISTENTE";
            }

            // 2. Buscar el libro por título en la colección de libros del Lector
            if (lectorSolicitante.tieneLibro(titulo) == false)
            {
                Console.WriteLine("No se encontró el libro: " + titulo);
                return "EL LIBRO INFORMADO NO LO TIENE EL LECTOR";
            }

            // 3. OBTENER LOS DATOS DEL LIBRO
            string autor = "";
            string editorial = "";
            foreach (Libro libro in lectorSolicitante.getLibrosPrestados())
            {
                if (libro.getTitulo() == titulo)
                {
                    autor = libro.getAutor();
                    editorial = libro.getEditorial();
                    break;
                }
            }

            // 4. Quitar el libro del lector
            lectorSolicitante.devolverLibroPorTitulo(titulo);

            // 5. AGREGAR EL LIBRO DE VUELTA A LA BIBLIOTECA
            agregarLibro(titulo, autor, editorial);

            Console.WriteLine($"Libro '{titulo}' devuelto correctamente y agregado al catálogo.");
            return "DEVOLUCION EXITOSA";
        }

        public string librosPrestadosAlLector(string dni)
        {
            // 1. Buscar el lector por DNI
            Lector lectorSolicitante = buscarLector(dni);
            if (lectorSolicitante == null)
            {
                Console.WriteLine("No se puede encontrar prestamos de libros, ya que el lector con dni " + dni + " no existe.");
                return "LECTOR INEXISTENTE";
            }

            // 2. Verificar que el lector tenga libros prestados
            if (lectorSolicitante.getLibrosPrestados().Count == 0)
            {
                Console.WriteLine("No tiene libros prestados.");
                return "LECTOR NO CUENTA CON LIBROS PRESTADOS";
            }
            // 3. si tiene libros recorre la lista de libros e imprime el titulo de los que tiene el lector
            Console.WriteLine($"El lector con DNI {dni} tiene {lectorSolicitante.getLibrosPrestados().Count} libros.");
            // Recorrer la lista de libros prestados
            for (int i = 0; i < lectorSolicitante.getLibrosPrestados().Count; i++)
            {
                // Obtener el libro en la posición i
                Libro libro = lectorSolicitante.getLibrosPrestados()[i];

                // Imprimir el título del libro
                Console.WriteLine($"  {i + 1}. {libro.getTitulo()}");
            }
            return "FIN DE LA LISTA DE LIBROS PRESTADO";
        }
    }
}
