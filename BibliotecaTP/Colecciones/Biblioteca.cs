namespace BibliotecaTP.Colecciones
{
    public class Biblioteca
    {
        private readonly List<Libro> libros;
        private readonly List<Lector> lectores;

        public Biblioteca()
        {
            libros = [];
            lectores = [];
        }

        private Libro? BuscarLibro(string titulo)
        {
            return libros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
        }

        private Lector? BuscarLector(string dni)
        {
            return lectores.FirstOrDefault(l => l.Dni == dni);
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

        public string EliminarLibro(string titulo)
        {
            Libro? libro = BuscarLibro(titulo);
            if (libro != null)
            {
                libros.Remove(libro);
                return $"El libro '{titulo}' ha sido eliminado de la biblioteca.";
            }
            return "LIBRO INEXISTENTE";
        }

        public string AltaLector(string nombre, string dni)
        {
            if (BuscarLector(dni) != null)
            {
                return $"LECTOR CON DNI {dni} YA EXISTE";
            }

            lectores.Add(new Lector(nombre, dni));
            return $"SE DIO DE ALTA AL LECTOR {nombre}";
        }

        public string PrestarLibro(string titulo, string dni)
        {
            // 1. Buscar el lector por DNI
            Lector? lectorSolicitante = BuscarLector(dni);
            if (lectorSolicitante == null)
            {
                return $"No se puede realizar el préstamo: lector con DNI {dni} no existe.";
            }

            // 2. Verificar que el lector no haya alcanzado el tope de préstamos (3 libros)
            if (lectorSolicitante.GetLibrosPrestados().Count >= 3)
            {
                return $"El lector con DNI {dni} ha alcanzado su tope de préstamos. \nTOPE DE PRESTAMO ALCANZADO";
            }

            // 3. Buscar el libro por título en la colección de libros disponibles
            Libro? libroSolicitado = BuscarLibro(titulo);
            if (libroSolicitado == null)
            {
                return $"El libro con título '{titulo}' no existe en la biblioteca. \nLIBRO INEXISTENTE";
            }

            // 4. Si llegamos aquí, el préstamo es posible
            // Quitar el libro de la biblioteca
            libros.Remove(libroSolicitado);

            // Asignar el libro al lector
            lectorSolicitante.AgregarLibro(libroSolicitado);
            return $"Se prestó el libro '{titulo}' al lector con DNI {dni}. \nPRESTAMO EXITOSO";
        }

        public string DevolverLibro(string titulo, string dni)
        {
            // 1. Buscar el lector por DNI
            Lector? lectorSolicitante = BuscarLector(dni);
            if (lectorSolicitante == null)
            {
                return $"No se puede devolver: lector con DNI {dni} no existe. \nLECTOR INEXISTENTE";
            }

            // 2. Buscar el libro por título en la colección de libros del Lector
            if (lectorSolicitante.TieneLibro(titulo) == false)
            {
                return $"El lector con DNI {dni} no tiene el libro '{titulo}'. \nEL LIBRO INFORMADO NO LO TIENE EL LECTOR";
            }

            // 3. OBTENER LOS DATOS DEL LIBRO
            string autor = "";
            string editorial = "";
            foreach (Libro libro in lectorSolicitante.GetLibrosPrestados())
            {
                if (libro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    autor = libro.Autor;
                    editorial = libro.Editorial;
                    break;
                }
            }

            // 4. Quitar el libro del lector
            lectorSolicitante.DevolverLibroPorTitulo(titulo);

            // 5. AGREGAR EL LIBRO DE VUELTA A LA BIBLIOTECA
            AgregarLibro(titulo, autor, editorial);

            return $"Libro '{titulo}' devuelto correctamente y agregado al catálogo. \nDEVOLUCION EXITOSA";
        }

        public string LibrosPrestadosAlLector(string dni)
        {
            // 1. Buscar el lector por DNI
            Lector? lectorSolicitante = BuscarLector(dni);
            if (lectorSolicitante == null)
            {
                return $"No se puede encontrar préstamos: lector con DNI {dni} no existe. \nLECTOR INEXISTENTE";
            }

            // 2. Verificar que el lector tenga libros prestados
            if (lectorSolicitante.GetLibrosPrestados().Count == 0)
            {
                return $"El lector con DNI {dni} no tiene libros prestados. \nLECTOR NO CUENTA CON LIBROS PRESTADOS";
            }

            // 3. si tiene libros recorre la lista de libros e imprime el titulo de los que tiene el lector
            string resultado = $"El lector con DNI {dni} tiene {lectorSolicitante.GetLibrosPrestados().Count} libros:\n";
            // Recorrer la lista de libros prestados
            for (int i = 0; i < lectorSolicitante.GetLibrosPrestados().Count; i++)
            {
                // Obtener el libro en la posición i
                Libro libro = lectorSolicitante.GetLibrosPrestados()[i];

                // Imprimir el título del libro
                resultado += $"  {i + 1}. {libro.Titulo}\n";
            }

            resultado += "FIN DE LA LISTA DE LIBROS PRESTADOS";

            return resultado;
        }
    }
}
