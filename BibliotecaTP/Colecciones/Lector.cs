using BibliotecaTP.Colecciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BibliotecaTP.Colecciones
{
    public class Lector
    {
        private string nombre = string.Empty;
        private string dni = string.Empty;

        public string Nombre
        {
            get => nombre;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                nombre = value;
            }
        }

        public string Dni
        {
            get => dni;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 7)
                    throw new ArgumentException("El DNI no es válido.");
                dni = value;
            }
        }

        public List<Libro> LibrosPrestados { get; } = new List<Libro>();

        public int CantidadLibrosPrestados => LibrosPrestados.Count;

        public Lector(string nombre, string dni)
        {
            Nombre = nombre;
            Dni = dni;
        }

        public void AgregarPrestamo(Libro libro)
        {
            if (CantidadLibrosPrestados >= 3)
                throw new InvalidOperationException("El lector ya tiene 3 libros prestados.");
            LibrosPrestados.Add(libro);
        }

        public override string ToString()
        {
            string prestamos = LibrosPrestados.Count == 0
                ? "Ninguno"
                : string.Join(", ", LibrosPrestados.Select(l => l.Titulo));

            return $"Nombre: {Nombre}, Dni: {Dni}, Libros prestados: {prestamos}";
        }
    }
}
