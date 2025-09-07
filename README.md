# Sistema de Biblioteca

## Materia: Desarrollo de Software Orientado a Objetos  
## Comisión: A  
## Grupo: 15  

### Integrantes del Equipo

Este proyecto fue desarrollado por el siguiente equipo de trabajo:

- **Iván Shifman**  
  Email: ivanshifman1300@gmail.com  
  Nombre Completo: Iván Ezequiel Shifman  

- **Ángel Sabato**  
  Email: 19angel.s89@gmail.com  
  Nombre Completo: Ángel Sabato  

- **Flavio Rinaldi**  
  Email: flaviorin@gmail.com  
  Nombre Completo: Flavio Rinaldi 

- **Marcelo Zárate**  
  Email: mandrakes@gmail.com  
  Nombre Completo: Marcelo Zárate

- **Ana Schneider**  
  Email: anaesneider@gmail.com  
  Nombre Completo: Ana Schneider  

---

## Descripción

Este proyecto simula una biblioteca en la que los usuarios pueden:  

- Registrar lectores.  
- Agregar libros a la biblioteca.
- Eliminar libros de la biblioteca.
- Listar los libros disponibles.  
- Realizar préstamos de libros.
- Visualizar los libros prestados.
- Devolver libros prestados.


Se aplican restricciones en los préstamos: cada lector puede tener como máximo **3 libros en préstamo al mismo tiempo**.  

---

## Objetivo del Trabajo Práctico

El objetivo es desarrollar un **sistema de gestión de biblioteca** aplicando principios de **programación orientada a objetos en C#**, con la implementación de:  

- **Colección de libros** en la biblioteca.  
- **Colección de lectores registrados**.  
- **Método AltaLector**, para dar de alta un lector si no estaba previamente registrado.  
- **Método PrestarLibro**, que recibe el título de un libro y el DNI del lector solicitante, y retorna un string con alguno de los siguientes valores:  
  - `"PRESTAMO EXITOSO"`: si el préstamo se concretó y el libro fue asignado al lector.  
  - `"LIBRO CON TITULO {titulo} INEXISTENTE"`: si el libro no está en la colección.  
  - `"TOPE DE PRESTAMO ALCANZADO"`: si el lector ya posee 3 préstamos vigentes.  
  - `"LECTOR CON DNI {dni} INEXISTENTE"`: si el lector no está registrado en la biblioteca.  


---

## Funcionalidades implementadas

- **Alta de Lector**: Registra un nuevo lector con nombre y DNI.  
- **Agregar Libro**: Agrega un libro con título, autor y editorial a la biblioteca.  
- **Prestar Libro**: Gestiona préstamos con las validaciones mencionadas en la consigna.  
- **Listado de Libros**: Muestra los libros actualmente disponibles.  
- **Eliminar Libro**: Permite quitar un libro existente de la biblioteca.  

Adicionalmente se implementaron las siguientes funciones:
- **librosPrestadosAlLector**, muestra los libros de un lector.
- **Método devolverLibro** , que recibe el título de un libro y el DNI del lector solicitante, y retorna un string con alguno de los siguientes valores:  
  - `"LECTOR INEXISTENTE"`: si el lector no existe.  
  - `"EL LIBRO INFORMADO NO LO TIENE EL LECTOR"`: si el libro no se le ha prestado al lector.
  - `"DEVOLUCION EXITOSA"`: si la devolucion del libro se concretó, el libro fue devuelto a la biblioteca.


---

## Diseño del Sistema

El sistema se compone de las siguientes clases principales:  

- **Libro**  
  Representa un libro, con atributos `Titulo`, `Autor` y `Editorial`.  

- **Lector**  
  Representa un lector registrado, con `Nombre`, `Dni` y la lista de `LibrosPrestados`.  
  Permite controlar la cantidad máxima de préstamos (3).  

- **Biblioteca**  
  Gestiona los libros y lectores. Contiene los métodos `agregarLibro`, `listarLibros`, `eliminarLibro`, `altaLector` y `prestarLibro`.  

Adicionalmente se agregaron los siguientes métodos: `devolverLibro`, `librosPrestadosAlLector`.


## Diagrama UML

![Diagrama UML de CLASES](https://drive.google.com/file/d/1p0kvMnxoTTPzupLIMOrqZpyjdCSe8sM_/view?usp=sharing)

---

## Casos de Prueba y Ejemplos

Ejemplos de uso según lo implementado:  

1. **Alta de un lector**  
   - Entrada: `Nombre = "Pepe"`, `DNI = "12345678"`  
   - Salida:  
     ```
     SE DIO DE ALTA AL LECTOR Pepe
     ```

2. **Préstamo de un libro existente**  
   - Entrada: `Título = "Libro3"`, `DNI = "12345678"`  
   - Salida:  
     ```
     PRESTAMO EXITOSO
     ```

3. **Préstamo con lector inexistente**  
   - Entrada: `Título = "Libro3"`, `DNI = "12345679"`  
   - Salida:  
     ```
     LECTOR CON DNI 12345679 INEXISTENTE
     ```

4. **Préstamo con libro inexistente**  
   - Entrada: `Título = "Libr3"`, `DNI = "12345678"`  
   - Salida:  
     ```
     LIBRO CON TITULO Libr3 INEXISTENTE
     ```

5. **Préstamo con tope de préstamos alcanzado**  
   - Entrada: `Título = "Libro5"`, `DNI = "12345678"` (lector ya tiene 3 libros prestados)  
   - Salida:  
     ```
     TOPE DE PRESTAMO ALCANZADO
     ```

---

## Requisitos

- **.NET 6 o superior**  
- **Visual Studio 2019/2022** o cualquier IDE compatible con C#  

---

## Tecnologías utilizadas

- **C#**: Lenguaje de programación.  
- **.NET**: Framework utilizado.  
- **POO (Programación Orientada a Objetos)**: Encapsulamiento, clases, objetos y colecciones genéricas (`List<T>`).  

---

## Conclusiones

El desarrollo de este sistema permitió:  

- Aplicar conceptos de **POO en C#**.  
- Implementar y gestionar colecciones de objetos (`libros` y `lectores`).  
- Controlar restricciones de negocio (máximo de 3 préstamos por lector).  
- Simular un sistema de biblioteca básico con validaciones de datos y operaciones esenciales.  
