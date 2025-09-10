namespace BibliotecaTP.Colecciones
{
    internal class Lector
    {
        private string nombre = string.Empty;
        private string dni = string.Empty;
        private readonly List<Libro> librosPrestados;

        public Lector(string nombre, string dni)
        {
            Nombre = nombre;
            Dni = dni;
            librosPrestados = [];
        }

        public string Nombre
        {
            get => nombre;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre no puede estar vacío.");
                }

                nombre = value;
            }
        }

        public string Dni
        {
            get => dni;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 7)
                {
                    throw new ArgumentException("El DNI no es válido.");
                }

                dni = value;
            }
        }

        // Método para obtener la lista de libros prestados
        public List<Libro> GetLibrosPrestados()
        {
            return librosPrestados;
        }

        // Método para agregar un libro a la lista de préstamos
        public void AgregarLibro(Libro libro)
        {
            librosPrestados.Add(libro);
        }

        // Método opcional: para devolver un libro (útil para futuros métodos)
        public void DevolverLibroPorTitulo(string titulo)
        {
            for (int i = 0; i < librosPrestados.Count; i++)
            {
                if (librosPrestados[i].Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    librosPrestados.RemoveAt(i);
                    break;
                }
            }
        }

        // Método opcional: para verificar si tiene un libro específico
        public bool TieneLibro(string titulo)
        {
            for (int i = 0; i < librosPrestados.Count; i++)
            {
                if (librosPrestados[i].Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre} DNI: {Dni}";
        }
    }
}
