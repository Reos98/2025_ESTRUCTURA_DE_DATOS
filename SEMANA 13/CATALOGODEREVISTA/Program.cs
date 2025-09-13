using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoRevistas
{
    /// <summary>
    /// Clase que representa una revista en el catálogo
    /// </summary>
    public class Revista
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public int AñoPublicacion { get; set; }

        public Revista(int id, string titulo, string categoria, int añoPublicacion)
        {
            Id = id;
            Titulo = titulo;
            Categoria = categoria;
            AñoPublicacion = añoPublicacion;
        }

        public override string ToString()
        {
            return $"ID: {Id} - {Titulo} ({Categoria}, {AñoPublicacion})";
        }
    }

    /// <summary>
    /// Clase principal que gestiona el catálogo de revistas
    /// </summary>
    public class CatalogoRevistas
    {
        private List<Revista> revistas;

        public CatalogoRevistas()
        {
            revistas = new List<Revista>();
            InicializarCatalogo();
        }

        /// <summary>
        /// Inicializa el catálogo con 10 revistas predefinidas
        /// </summary>
        private void InicializarCatalogo()
        {
            revistas.Add(new Revista(1, "National Geographic", "Ciencia", 2023));
            revistas.Add(new Revista(2, "Time Magazine", "Actualidad", 2023));
            revistas.Add(new Revista(3, "Scientific American", "Ciencia", 2023));
            revistas.Add(new Revista(4, "Forbes", "Negocios", 2023));
            revistas.Add(new Revista(5, "Wired", "Tecnología", 2023));
            revistas.Add(new Revista(6, "The Economist", "Economía", 2023));
            revistas.Add(new Revista(7, "Sports Illustrated", "Deportes", 2023));
            revistas.Add(new Revista(8, "Vogue", "Moda", 2023));
            revistas.Add(new Revista(9, "Popular Science", "Ciencia", 2023));
            revistas.Add(new Revista(10, "Harvard Business Review", "Negocios", 2023));

            Console.WriteLine("Catálogo inicializado con 10 revistas.");
        }

        /// <summary>
        /// Búsqueda iterativa de una revista por título
        /// </summary>
        /// <param name="titulo">Título a buscar</param>
        /// <returns>La revista encontrada o null si no existe</returns>
        public Revista BusquedaIterativa(string titulo)
        {
            // Normalizar el título de búsqueda para comparación insensible a mayúsculas
            string tituloBusqueda = titulo.ToLower().Trim();

            // Recorrer toda la lista de forma iterativa
            for (int i = 0; i < revistas.Count; i++)
            {
                if (revistas[i].Titulo.ToLower().Contains(tituloBusqueda))
                {
                    return revistas[i];
                }
            }

            return null; // No encontrado
        }

        /// <summary>
        /// Búsqueda recursiva de una revista por título
        /// </summary>
        /// <param name="titulo">Título a buscar</param>
        /// <returns>La revista encontrada o null si no existe</returns>
        public Revista BusquedaRecursiva(string titulo)
        {
            string tituloBusqueda = titulo.ToLower().Trim();
            return BusquedaRecursivaHelper(tituloBusqueda, 0);
        }

        /// <summary>
        /// Método auxiliar para la búsqueda recursiva
        /// </summary>
        /// <param name="titulo">Título a buscar (normalizado)</param>
        /// <param name="indice">Índice actual en la búsqueda</param>
        /// <returns>La revista encontrada o null si no existe</returns>
        private Revista BusquedaRecursivaHelper(string titulo, int indice)
        {
            // Caso base: si hemos llegado al final de la lista
            if (indice >= revistas.Count)
            {
                return null;
            }

            // Caso base: si encontramos el título
            if (revistas[indice].Titulo.ToLower().Contains(titulo))
            {
                return revistas[indice];
            }

            // Llamada recursiva con el siguiente índice
            return BusquedaRecursivaHelper(titulo, indice + 1);
        }

        /// <summary>
        /// Muestra todas las revistas del catálogo
        /// </summary>
        public void MostrarCatalogo()
        {
            Console.WriteLine("\n=== CATÁLOGO COMPLETO DE REVISTAS ===");
            foreach (var revista in revistas)
            {
                Console.WriteLine(revista);
            }
            Console.WriteLine($"Total de revistas: {revistas.Count}\n");
        }

        /// <summary>
        /// Agrega una nueva revista al catálogo
        /// </summary>
        public void AgregarRevista()
        {
            Console.Write("Ingrese el título de la revista: ");
            string titulo = Console.ReadLine();

            Console.Write("Ingrese la categoría: ");
            string categoria = Console.ReadLine();

            Console.Write("Ingrese el año de publicación: ");
            if (int.TryParse(Console.ReadLine(), out int año))
            {
                int nuevoId = revistas.Max(r => r.Id) + 1;
                revistas.Add(new Revista(nuevoId, titulo, categoria, año));
                Console.WriteLine("¡Revista agregada exitosamente!");
            }
            else
            {
                Console.WriteLine("Año inválido. La revista no fue agregada.");
            }
        }

        /// <summary>
        /// Realiza una búsqueda y muestra el resultado
        /// </summary>
        /// <param name="titulo">Título a buscar</param>
        /// <param name="metodo">Método de búsqueda (1=Iterativa, 2=Recursiva)</param>
        public void RealizarBusqueda(string titulo, int metodo)
        {
            Revista resultado = null;
            string metodoBusqueda = "";

            // Medir tiempo de ejecución
            var inicio = DateTime.Now;

            switch (metodo)
            {
                case 1:
                    resultado = BusquedaIterativa(titulo);
                    metodoBusqueda = "Iterativa";
                    break;
                case 2:
                    resultado = BusquedaRecursiva(titulo);
                    metodoBusqueda = "Recursiva";
                    break;
            }

            var fin = DateTime.Now;
            var tiempoEjecucion = (fin - inicio).TotalMilliseconds;

            // Mostrar resultado
            Console.WriteLine($"\n=== RESULTADO DE BÚSQUEDA {metodoBusqueda.ToUpper()} ===");
            Console.WriteLine($"Término buscado: '{titulo}'");
            Console.WriteLine($"Tiempo de ejecución: {tiempoEjecucion:F4} ms");

            if (resultado != null)
            {
                Console.WriteLine("Estado: ENCONTRADO");
                Console.WriteLine($"Revista encontrada: {resultado}");
            }
            else
            {
                Console.WriteLine("Estado: NO ENCONTRADO");
                Console.WriteLine("La revista no existe en el catálogo.");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Clase principal del programa
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            CatalogoRevistas catalogo = new CatalogoRevistas();
            bool continuar = true;

            Console.WriteLine("🔍 SISTEMA DE BÚSQUEDA EN CATÁLOGO DE REVISTAS");
            Console.WriteLine("==============================================");

            while (continuar)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RealizarBusquedaInteractiva(catalogo, 1); // Búsqueda iterativa
                        break;

                    case "2":
                        RealizarBusquedaInteractiva(catalogo, 2); // Búsqueda recursiva
                        break;

                    case "3":
                        catalogo.MostrarCatalogo();
                        break;

                    case "4":
                        catalogo.AgregarRevista();
                        break;

                    case "5":
                        CompararMetodosBusqueda(catalogo);
                        break;

                    case "6":
                        continuar = false;
                        Console.WriteLine("¡Gracias por usar el sistema de catálogo de revistas!");
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción del 1 al 6.");
                        break;
                }

                if (continuar)
                {
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// Muestra el menú principal de la aplicación
        /// </summary>
        static void MostrarMenu()
        {
            Console.WriteLine("\n📋 MENÚ PRINCIPAL");
            Console.WriteLine("==================");
            Console.WriteLine("1. Buscar revista (Método Iterativo)");
            Console.WriteLine("2. Buscar revista (Método Recursivo)");
            Console.WriteLine("3. Mostrar catálogo completo");
            Console.WriteLine("4. Agregar nueva revista");
            Console.WriteLine("5. Comparar métodos de búsqueda");
            Console.WriteLine("6. Salir");
            Console.WriteLine("==================");
            Console.Write("Seleccione una opción (1-6): ");
        }

        /// <summary>
        /// Solicita al usuario el término de búsqueda y ejecuta la búsqueda
        /// </summary>
        /// <param name="catalogo">Instancia del catálogo</param>
        /// <param name="metodo">Método de búsqueda a utilizar</param>
        static void RealizarBusquedaInteractiva(CatalogoRevistas catalogo, int metodo)
        {
            Console.Write("\nIngrese el título de la revista a buscar: ");
            string titulo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(titulo))
            {
                Console.WriteLine("El título no puede estar vacío.");
                return;
            }

            catalogo.RealizarBusqueda(titulo, metodo);
        }

        /// <summary>
        /// Compara el rendimiento entre búsqueda iterativa y recursiva
        /// </summary>
        /// <param name="catalogo">Instancia del catálogo</param>
        static void CompararMetodosBusqueda(CatalogoRevistas catalogo)
        {
            Console.Write("\nIngrese el título para comparar ambos métodos: ");
            string titulo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(titulo))
            {
                Console.WriteLine("El título no puede estar vacío.");
                return;
            }

            Console.WriteLine("\n🔄 COMPARACIÓN DE MÉTODOS DE BÚSQUEDA");
            Console.WriteLine("=====================================");

            // Ejecutar ambos métodos
            catalogo.RealizarBusqueda(titulo, 1); // Iterativa
            catalogo.RealizarBusqueda(titulo, 2); // Recursiva

            Console.WriteLine("📊 ANÁLISIS:");
            Console.WriteLine("- El método iterativo generalmente es más eficiente en memoria");
            Console.WriteLine("- El método recursivo puede ser más legible pero usa más memoria (stack)");
            Console.WriteLine("- Para listas pequeñas, la diferencia es mínima");
        }
    }
}