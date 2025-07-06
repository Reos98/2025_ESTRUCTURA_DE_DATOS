using System;

// Clase para representar un nodo de la lista enlazada
public class Nodo<T>
{
    public T Dato { get; set; }
    public Nodo<T> Siguiente { get; set; }

    public Nodo(T dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

// Clase para la lista enlazada
public class ListaEnlazada<T>
{
    private Nodo<T> cabeza;
    private int tamaño;

    public ListaEnlazada()
    {
        cabeza = null;
        tamaño = 0;
    }

    // Método para agregar un elemento al final de la lista
    public void Agregar(T dato)
    {
        Nodo<T> nuevoNodo = new Nodo<T>(dato);
        
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            Nodo<T> actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
        tamaño++;
    }

    // Método para mostrar la lista
    public void MostrarLista()
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía");
            return;
        }

        Nodo<T> actual = cabeza;
        Console.Write("Lista: ");
        while (actual != null)
        {
            Console.Write(actual.Dato + " -> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("null");
    }

    // Método principal para invertir la lista enlazada
    public void InvertirLista()
    {
        if (cabeza == null || cabeza.Siguiente == null)
        {
            // Lista vacía o con un solo elemento, no hay nada que invertir
            return;
        }

        Nodo<T> anterior = null;
        Nodo<T> actual = cabeza;
        Nodo<T> siguiente = null;

        // Recorrer la lista invirtiendo las referencias
        while (actual != null)
        {
            siguiente = actual.Siguiente;  // Guardar el siguiente nodo
            actual.Siguiente = anterior;   // Invertir la referencia
            anterior = actual;             // Mover anterior al nodo actual
            actual = siguiente;            // Mover actual al siguiente nodo
        }

        // Actualizar la cabeza para que apunte al último nodo (que ahora es el primero)
        cabeza = anterior;
    }

    // Método alternativo recursivo para invertir la lista
    public void InvertirListaRecursivo()
    {
        cabeza = InvertirRecursivo(cabeza);
    }

    private Nodo<T> InvertirRecursivo(Nodo<T> nodo)
    {
        // Caso base: si el nodo es null o es el último nodo
        if (nodo == null || nodo.Siguiente == null)
        {
            return nodo;
        }

        // Invertir recursivamente el resto de la lista
        Nodo<T> nuevaCabeza = InvertirRecursivo(nodo.Siguiente);

        // Invertir la conexión actual
        nodo.Siguiente.Siguiente = nodo;
        nodo.Siguiente = null;

        return nuevaCabeza;
    }

    // Método para obtener el tamaño de la lista
    public int ObtenerTamaño()
    {
        return tamaño;
    }

    // Método para verificar si la lista está vacía
    public bool EstaVacia()
    {
        return cabeza == null;
    }
}

// Programa principal para demostrar el funcionamiento
class Program
{
    static void Main(string[] args)
    {
        // Crear una lista enlazada de enteros
        ListaEnlazada<int> lista = new ListaEnlazada<int>();

        // Agregar elementos a la lista
        Console.WriteLine("=== Agregando elementos a la lista ===");
        for (int i = 1; i <= 5; i++)
        {
            lista.Agregar(i);
            Console.WriteLine($"Agregado: {i}");
        }

        // Mostrar la lista original
        Console.WriteLine("\n=== Lista original ===");
        lista.MostrarLista();

        // Invertir la lista usando el método iterativo
        Console.WriteLine("\n=== Invirtiendo la lista (método iterativo) ===");
        lista.InvertirLista();
        lista.MostrarLista();

        // Volver a invertir para demostrar que funciona en ambas direcciones
        Console.WriteLine("\n=== Invirtiendo nuevamente ===");
        lista.InvertirLista();
        lista.MostrarLista();

        // Crear otra lista para demostrar el método recursivo
        Console.WriteLine("\n=== Demostrando método recursivo ===");
        ListaEnlazada<string> listaTexto = new ListaEnlazada<string>();
        string[] palabras = { "Primero", "Segundo", "Tercero", "Cuarto", "Quinto" };

        foreach (string palabra in palabras)
        {
            listaTexto.Agregar(palabra);
        }

        Console.WriteLine("Lista de texto original:");
        listaTexto.MostrarLista();

        listaTexto.InvertirListaRecursivo();
        Console.WriteLine("Lista de texto invertida (recursivo):");
        listaTexto.MostrarLista();

        // Ejemplo con lista vacía
        Console.WriteLine("\n=== Probando con lista vacía ===");
        ListaEnlazada<int> listaVacia = new ListaEnlazada<int>();
        Console.WriteLine("Lista vacía antes de invertir:");
        listaVacia.MostrarLista();
        listaVacia.InvertirLista();
        Console.WriteLine("Lista vacía después de invertir:");
        listaVacia.MostrarLista();

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}