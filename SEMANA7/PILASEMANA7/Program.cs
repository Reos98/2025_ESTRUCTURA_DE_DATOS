using System;

namespace EjerciciosPilas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ESTRUCTURAS DE DATOS - EJERCICIOS CON PILAS (STACKS)");
            Console.WriteLine("====================================================\n");
            
            try
            {
                // Ejecutar Ejercicio 1: Verificación de paréntesis balanceados
                VerificadorParentesis.EjecutarPruebas();
                
                Console.WriteLine("\nPresione cualquier tecla para continuar con el siguiente ejercicio...");
                Console.ReadKey();
                Console.Clear();
                
                // Ejecutar Ejercicio 2: Torres de Hanoi
                Console.WriteLine("Ingrese el número de discos para las Torres de Hanoi (recomendado: 3-5): ");
                if (int.TryParse(Console.ReadLine(), out int numeroDiscos) && numeroDiscos > 0)
                {
                    TorresHanoi hanoi = new TorresHanoi(numeroDiscos);
                    hanoi.IniciarResolucion(numeroDiscos);
                }
                else
                {
                    Console.WriteLine("Número de discos no válido. Usando 3 discos por defecto.");
                    TorresHanoi hanoi = new TorresHanoi(3);
                    hanoi.IniciarResolucion(3);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error durante la ejecución: {ex.Message}");
            }
            
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
