using BibliotecaTP.Colecciones;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        public string eliminarLibro(string titulo)
        {
            Libro? libro = buscarLibro(titulo);
            if (libro != null)
            {
                libros.Remove(libro);
                return $"El libro '{titulo}' ha sido eliminado de la biblioteca.";
            }
            return "LIBRO INEXISTENTE";
        }

        public string altaLector(string nombre, string dni)
        {
            if (buscarLector(dni) != null)
            {
                return $"LECTOR CON DNI {dni} YA EXISTE";
            }

            lectores.Add(new Lector(nombre, dni));
            return $"SE DIO DE ALTA AL LECTOR {nombre}";
        }

        public string prestarLibro(string titulo, string dni)
        {
            // 1. Buscar el lector por DNI
            Lector? lectorSolicitante = buscarLector(dni);
            if (lectorSolicitante == null)
            {
                return $"No se puede realizar el préstamo: lector con DNI {dni} no existe.";
            }

            // 2. Verificar que el lector no haya alcanzado el tope de préstamos (3 libros)
            if (lectorSolicitante.getLibrosPrestados().Count >= 3)
            {
                return $"El lector con DNI {dni} ha alcanzado su tope de préstamos. \nTOPE DE PRESTAMO ALCANZADO";
            }

            // 3. Buscar el libro por título en la colección de libros disponibles
            Libro? libroSolicitado = buscarLibroPorTitulo(titulo);
            if (libroSolicitado == null)
            {
                return $"El libro con título '{titulo}' no existe en la biblioteca. \nLIBRO INEXISTENTE";
            }

            // 4. Si llegamos aquí, el préstamo es posible
            // Quitar el libro de la biblioteca
            libros.Remove(libroSolicitado);

            // Asignar el libro al lector
            lectorSolicitante.agregarLibro(libroSolicitado);
            return $"Se prestó el libro '{titulo}' al lector con DNI {dni}. \nPRESTAMO EXITOSO";
        }

        // Método auxiliar para buscar libro por título
        private Libro? buscarLibroPorTitulo(string titulo)
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
            Lector? lectorSolicitante = buscarLector(dni);
            if (lectorSolicitante == null)
            {
                return $"No se puede devolver: lector con DNI {dni} no existe. \nLECTOR INEXISTENTE";
            }

            // 2. Buscar el libro por título en la colección de libros del Lector
            if (lectorSolicitante.tieneLibro(titulo) == false)
            {
                return $"El lector con DNI {dni} no tiene el libro '{titulo}'. \nEL LIBRO INFORMADO NO LO TIENE EL LECTOR";
            }

            // 3. OBTENER LOS DATOS DEL LIBRO
            string autor = "";
            string editorial = "";
            foreach (Libro libro in lectorSolicitante.getLibrosPrestados())
            {
                if (libro.getTitulo().Equals(titulo, StringComparison.OrdinalIgnoreCase))
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

            return $"Libro '{titulo}' devuelto correctamente y agregado al catálogo. \nDEVOLUCION EXITOSA";
        }

        public string librosPrestadosAlLector(string dni)
        {
            // 1. Buscar el lector por DNI
            Lector? lectorSolicitante = buscarLector(dni);
            if (lectorSolicitante == null)
            {
                return $"No se puede encontrar préstamos: lector con DNI {dni} no existe. \nLECTOR INEXISTENTE";
            }

            // 2. Verificar que el lector tenga libros prestados
            if (lectorSolicitante.getLibrosPrestados().Count == 0)
            {
                return $"El lector con DNI {dni} no tiene libros prestados. \nLECTOR NO CUENTA CON LIBROS PRESTADOS";
            }

            // 3. si tiene libros recorre la lista de libros e imprime el titulo de los que tiene el lector
            string resultado = $"El lector con DNI {dni} tiene {lectorSolicitante.getLibrosPrestados().Count} libros:\n";
            // Recorrer la lista de libros prestados
            for (int i = 0; i < lectorSolicitante.getLibrosPrestados().Count; i++)
            {
                // Obtener el libro en la posición i
                Libro libro = lectorSolicitante.getLibrosPrestados()[i];

                // Imprimir el título del libro
                resultado += $"  {i + 1}. {libro.getTitulo()}\n";
            }

            resultado += "FIN DE LA LISTA DE LIBROS PRESTADOS";

            return resultado;
        }
    }
}
