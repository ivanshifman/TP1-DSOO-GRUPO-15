using System;
using BibliotecaTP.Colecciones;

namespace BibliotecaTP.Colecciones
{
    public class Libro
    {
        private string titulo = string.Empty;
        private string autor = string.Empty;
        private string editorial = string.Empty;

        public string Titulo
        {
            get => titulo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El título no puede estar vacío.");
                titulo = value;
            }
        }

        public string Autor
        {
            get => autor;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El autor no puede estar vacío.");
                autor = value;
            }
        }

        public string Editorial
        {
            get => editorial;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La editorial no puede estar vacía.");
                editorial = value;
            }
        }

        public Libro(string titulo, string autor, string editorial)
        {
            Titulo = titulo;
            Autor = autor;
            Editorial = editorial;
        }

        public override string ToString()
        {
            return $"{Titulo} - {Autor} ({Editorial})";
        }
    }
}
