namespace BibliotecaTP.Colecciones
{
    internal class Libro
    {
        private string titulo = string.Empty;
        private string autor = string.Empty;
        private string editorial = string.Empty;

        public Libro(string titulo, string autor, string editorial)
        {
            Titulo = titulo;
            Autor = autor;
            Editorial = editorial;
        }

        public string Titulo
        {
            get => titulo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El título no puede estar vacío.");
                }

                titulo = value;
            }
        }

        public string Autor
        {
            get => autor;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El autor no puede estar vacío.");
                }

                autor = value;
            }
        }

        public string Editorial
        {
            get => editorial;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("La editorial no puede estar vacía.");
                }

                editorial = value;
            }
        }

        public override string ToString()
        {
            return $"Título: {Titulo} | Autor: {Autor} | Editorial: {Editorial}";
        }
    }
}
