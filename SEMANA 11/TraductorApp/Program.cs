using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TraductorApp
{
    class Program
    {
        // Diccionario principal para almacenar las traducciones
        private static Dictionary<string, string> diccionarioInglesEspanol;
        private static Dictionary<string, string> diccionarioEspanolIngles;

        static void Main(string[] args)
        {
            InicializarDiccionarios();
            MostrarBienvenida();
            
            bool continuar = true;
            while (continuar)
            {
                continuar = MostrarMenuYProcesar();
            }
            
            Console.WriteLine("\n¡Gracias por usar el traductor! ¡Hasta pronto!");
        }

        private static void InicializarDiccionarios()
        {
            // Inicializar diccionario Inglés -> Español
            diccionarioInglesEspanol = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {"time", "tiempo"},
                {"person", "persona"},
                {"year", "año"},
                {"way", "camino"},
                {"day", "día"},
                {"thing", "cosa"},
                {"man", "hombre"},
                {"world", "mundo"},
                {"life", "vida"},
                {"hand", "mano"},
                {"part", "parte"},
                {"child", "niño"},
                {"eye", "ojo"},
                {"woman", "mujer"},
                {"place", "lugar"},
                {"work", "trabajo"},
                {"week", "semana"},
                {"case", "caso"},
                {"point", "punto"},
                {"government", "gobierno"},
                {"company", "empresa"}
            };

            // Inicializar diccionario Español -> Inglés (inverso)
            diccionarioEspanolIngles = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var kvp in diccionarioInglesEspanol)
            {
                diccionarioEspanolIngles[kvp.Value] = kvp.Key;
            }
        }

        private static void MostrarBienvenida()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("═══════════════════════════════════════════════════════");
            Console.WriteLine("           TRADUCTOR INGLÉS ↔ ESPAÑOL");
            Console.WriteLine("═══════════════════════════════════════════════════════");
            Console.ResetColor();
            Console.WriteLine("¡Bienvenido al traductor básico!\n");
            Console.WriteLine($"Diccionario actual: {diccionarioInglesEspanol.Count} palabras disponibles");
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static bool MostrarMenuYProcesar()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==================== MENÚ ====================");
            Console.ResetColor();
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("3. Ver diccionario completo");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    TraducirFrase();
                    break;
                case "2":
                    AgregarPalabra();
                    break;
                case "3":
                    MostrarDiccionario();
                    break;
                case "0":
                    return false;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción no válida. Presiona cualquier tecla para continuar...");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
            }

            return true;
        }

        private static void TraducirFrase()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== TRADUCIR FRASE ===");
            Console.ResetColor();
            
            Console.WriteLine("\nSelecciona el idioma de origen:");
            Console.WriteLine("1. Inglés → Español");
            Console.WriteLine("2. Español → Inglés");
            Console.Write("Opción: ");
            
            string direccion = Console.ReadLine();
            
            Console.Write("\nIngresa la frase a traducir: ");
            string frase = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(frase))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se ingresó ninguna frase.");
                Console.ResetColor();
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            string fraseTraducida = string.Empty;
            
            if (direccion == "1")
            {
                fraseTraducida = TraducirTexto(frase, diccionarioInglesEspanol);
                Console.WriteLine($"\nTexto original (Inglés): {frase}");
                Console.WriteLine($"Traducción (Español): {fraseTraducida}");
            }
            else if (direccion == "2")
            {
                fraseTraducida = TraducirTexto(frase, diccionarioEspanolIngles);
                Console.WriteLine($"\nTexto original (Español): {frase}");
                Console.WriteLine($"Traducción (Inglés): {fraseTraducida}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opción no válida.");
                Console.ResetColor();
            }

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static string TraducirTexto(string texto, Dictionary<string, string> diccionario)
        {
            // Usar expresión regular para separar palabras manteniendo puntuación y espacios
            string patron = @"(\b\w+\b)";
            
            return Regex.Replace(texto, patron, match =>
            {
                string palabra = match.Value;
                
                // Verificar si la palabra existe en el diccionario
                if (diccionario.ContainsKey(palabra))
                {
                    return diccionario[palabra];
                }
                
                // Si no existe, devolver la palabra original
                return palabra;
            });
        }

        private static void AgregarPalabra()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("=== AGREGAR PALABRA AL DICCIONARIO ===");
            Console.ResetColor();

            Console.Write("\nIngresa la palabra en inglés: ");
            string palabraIngles = Console.ReadLine()?.Trim();

            Console.Write("Ingresa la traducción en español: ");
            string palabraEspanol = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(palabraIngles) || string.IsNullOrWhiteSpace(palabraEspanol))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ambas palabras son requeridas.");
                Console.ResetColor();
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            // Verificar si la palabra ya existe
            if (diccionarioInglesEspanol.ContainsKey(palabraIngles))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"La palabra '{palabraIngles}' ya existe en el diccionario.");
                Console.WriteLine($"Traducción actual: {diccionarioInglesEspanol[palabraIngles]}");
                Console.Write("¿Deseas actualizarla? (s/n): ");
                Console.ResetColor();
                
                string respuesta = Console.ReadLine()?.ToLower();
                if (respuesta != "s" && respuesta != "si" && respuesta != "sí")
                {
                    Console.WriteLine("Operación cancelada.");
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    return;
                }
            }

            // Agregar o actualizar la palabra en ambos diccionarios
            diccionarioInglesEspanol[palabraIngles.ToLower()] = palabraEspanol.ToLower();
            diccionarioEspanolIngles[palabraEspanol.ToLower()] = palabraIngles.ToLower();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n✓ Palabra agregada exitosamente:");
            Console.WriteLine($"  {palabraIngles} → {palabraEspanol}");
            Console.WriteLine($"  {palabraEspanol} → {palabraIngles}");
            Console.ResetColor();

            Console.WriteLine($"\nTotal de palabras en el diccionario: {diccionarioInglesEspanol.Count}");
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void MostrarDiccionario()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== DICCIONARIO COMPLETO ===");
            Console.ResetColor();

            Console.WriteLine($"\nTotal de palabras: {diccionarioInglesEspanol.Count}\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("INGLÉS → ESPAÑOL");
            Console.WriteLine("─────────────────────────────");
            Console.ResetColor();

            var palabrasOrdenadas = diccionarioInglesEspanol.OrderBy(kvp => kvp.Key);
            
            foreach (var palabra in palabrasOrdenadas)
            {
                Console.WriteLine($"{palabra.Key.PadRight(15)} → {palabra.Value}");
            }

            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}