// Este programa demuestra cómo implementar una lista enlazada simple
// y una función para contar el número de elementos que contiene,
// simulando el recorrido de nodos.

using System; // Importa el espacio de nombres System para funcionalidades básicas como Console.

// 1. Definición de la clase Nodo
// Representa un elemento individual en la lista enlazada.
public class Nodo
{
    // Valor que almacena el nodo. En este ejemplo, es un entero.
    public int Valor { get; set; }

    // Referencia al siguiente nodo en la lista.
    // Si es 'null', significa que es el último nodo.
    public Nodo Siguiente { get; set; }

    // Constructor del nodo.
    // Se utiliza para crear una nueva instancia de Nodo con un valor dado.
    public Nodo(int valor)
    {
        Valor = valor; // Inicializa el valor del nodo.
        Siguiente = null; // Por defecto, el siguiente nodo es nulo.
    }
}

// 2. Definición de la clase CustomLinkedList (Lista Enlazada Personalizada)
// Esta clase gestiona la colección de nodos.
public class CustomLinkedList
{
    // El 'cabeza' (head) es el primer nodo de la lista.
    // Si la lista está vacía, 'cabeza' será 'null'.
    private Nodo cabeza;

    // Constructor de la lista enlazada.
    public CustomLinkedList()
    {
        cabeza = null; // La lista se inicializa vacía.
    }

    // Método para añadir un nuevo elemento al final de la lista.
    // Esto nos permite construir la lista para poder contar sus elementos.
    public void Agregar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor); // Crea un nuevo nodo con el valor dado.

        if (cabeza == null) // Si la lista está vacía, el nuevo nodo es la cabeza.
        {
            cabeza = nuevoNodo;
        }
        else // Si la lista no está vacía, recorre hasta el final y añade el nuevo nodo.
        {
            Nodo actual = cabeza; // Empieza desde la cabeza.
            while (actual.Siguiente != null) // Recorre hasta encontrar el último nodo.
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo; // El último nodo apunta al nuevo nodo.
        }
        Console.WriteLine($"Elemento '{valor}' agregado a la lista.");
    }

    // 3. Función que calcula el número de elementos de la lista.
    // La idea de este algoritmo es bastante sencilla: lo que haremos para ver la longitud de
    // una lista es simplemente recorrer la lista hasta el final e ir contando el número de saltos (nodos).
    // El principal motivo por el que deberíamos implementar esto es que nos permite
    // aprender y comprender el manejo de los nodos en una estructura de datos enlazada.
    public int ContarElementos()
    {
        int contador = 0; // Inicializa el contador de elementos.
        Nodo actual = cabeza; // Empieza a recorrer la lista desde el primer nodo (cabeza).

        // Mientras el nodo actual no sea nulo (es decir, mientras no hayamos llegado al final de la lista).
        while (actual != null)
        {
            contador++; // Incrementa el contador por cada nodo que visitamos.
            actual = actual.Siguiente; // Mueve al siguiente nodo en la secuencia.
        }
        return contador; // Devuelve el número total de elementos contados.
    }

    // Método para imprimir los elementos de la lista (opcional, para verificación).
    public void ImprimirLista()
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Console.Write("Elementos de la lista: ");
        Nodo actual = cabeza;
        while (actual != null)
        {
            Console.Write($"{actual.Valor} ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }
}

// Clase principal del programa para la demostración.
public class Programa
{
    public static void Main(string[] args)
    {
        // Creamos una nueva instancia de nuestra lista enlazada personalizada.
        CustomLinkedList miLista = new CustomLinkedList();

        // Agregamos algunos elementos a la lista.
        miLista.Agregar(10);
        miLista.Agregar(20);
        miLista.Agregar(30);
        miLista.Agregar(40);

        // Imprimimos la lista para verificar su contenido.
        miLista.ImprimirLista();

        // Llamamos a la función ContarElementos y mostramos el resultado.
        int numeroDeElementos = miLista.ContarElementos();
        Console.WriteLine($"El número de elementos en la lista es: {numeroDeElementos}");

        Console.WriteLine("\n--- Probando con una lista vacía ---");
        CustomLinkedList listaVacia = new CustomLinkedList();
        listaVacia.ImprimirLista();
        int elementosListaVacia = listaVacia.ContarElementos();
        Console.WriteLine($"El número de elementos en la lista vacía es: {elementosListaVacia}");

        Console.WriteLine("\n--- Probando con un solo elemento ---");
        CustomLinkedList listaUnElemento = new CustomLinkedList();
        listaUnElemento.Agregar(100);
        listaUnElemento.ImprimirLista();
        int elementosUnElemento = listaUnElemento.ContarElementos();
        Console.WriteLine($"El número de elementos en la lista de un elemento es: {elementosUnElemento}");
    }
}
