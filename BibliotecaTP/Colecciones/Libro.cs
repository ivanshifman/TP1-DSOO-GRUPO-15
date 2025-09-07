using System;
using BibliotecaTP.Colecciones;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaTP.Colecciones
{
    public class Libro
    {
        private string titulo;
        private string autor;
        private string editorial;

        public string validaTitulo
        {
            get => titulo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El título no puede estar vacío.");
                titulo = value;
            }
        }

        public string validaAutor
        {
            get => autor;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El autor no puede estar vacío.");
                autor = value;
            }
        }

        public string validaEditorial
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
            validaTitulo = titulo;
            validaAutor = autor;
            validaEditorial = editorial;
        }
        public string getTitulo() => titulo;
        public string getAutor() => autor;
        public string getEditorial() => editorial;

        public override string ToString()
        {
            return $"Tìtulo: {titulo} Autor: {autor} Editorial: {editorial}";
        }
    }
}
