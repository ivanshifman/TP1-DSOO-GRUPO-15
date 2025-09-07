using BibliotecaTP.Colecciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaTP.Colecciones
{
    internal class Lector
    {
        private string nombre;
        private string dni;
        private List<Libro> librosPrestados;

        public Lector(string nombre, string dni)
        {
            validaNombre = nombre;
            validaDni = dni;
            this.librosPrestados = new List<Libro>();
        }

        public string validaNombre
        {
            get => nombre;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                nombre = value;
            }
        }

        public string validaDni
        {
            get => dni;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 7)
                    throw new ArgumentException("El DNI no es válido.");
                dni = value;
            }
        }
        public string getNombre() => nombre;
        public string getDni() => dni;

        // Método para agregar un libro a la lista de préstamos
        public void agregarLibro(Libro libro)
        {
            this.librosPrestados.Add(libro);
        }

        public override string ToString()
        {
            return $"Nombre: {nombre} DNI: {dni}";
        }

        // Método para obtener la lista de libros prestados
        public List<Libro> getLibrosPrestados() => this.librosPrestados;

        // Método opcional: para devolver un libro (útil para futuros métodos)
        public void devolverLibroPorTitulo(string titulo)
        {
            for (int i = 0; i < librosPrestados.Count; i++)
            {
                if (librosPrestados[i].getTitulo().Equals(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    librosPrestados.RemoveAt(i);
                    break;
                }
            }
        }

        // Método opcional: para verificar si tiene un libro específico
        public bool tieneLibro(string titulo)
        {
            for (int i = 0; i < librosPrestados.Count; i++)
            {
                if (librosPrestados[i].getTitulo().Equals(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
