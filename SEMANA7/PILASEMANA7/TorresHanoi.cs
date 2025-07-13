using System;
using System.Collections.Generic;
using System.Linq;

namespace EjerciciosPilas
{
    /// <summary>
    /// Clase que implementa la solución del problema de las Torres de Hanoi
    /// utilizando pilas para representar las torres y algoritmo recursivo
    /// </summary>
    public class TorresHanoi
    {
        // Pilas que representan las tres torres
        private Stack<int> torreA;    // Torre origen
        private Stack<int> torreB;    // Torre auxiliar  
        private Stack<int> torreC;    // Torre destino
        
        private int numeroMovimientos;
        
        /// <summary>
        /// Constructor que inicializa las torres
        /// </summary>
        /// <param name="numeroDiscos">Cantidad de discos a utilizar</param>
        public TorresHanoi(int numeroDiscos)
        {
            // Inicializar las tres pilas (torres)
            torreA = new Stack<int>();
            torreB = new Stack<int>();
            torreC = new Stack<int>();
            numeroMovimientos = 0;
            
            // Llenar la torre A con discos ordenados de mayor a menor
            // El disco más grande tiene el número más alto
            for (int i = numeroDiscos; i >= 1; i--)
            {
                torreA.Push(i);
            }
        }
        
        /// <summary>
        /// Método principal que resuelve el problema de las Torres de Hanoi
        /// </summary>
        /// <param name="numeroDiscos">Cantidad de discos a mover</param>
        /// <param name="origen">Torre origen</param>
        /// <param name="destino">Torre destino</param>
        /// <param name="auxiliar">Torre auxiliar</param>
        public void ResolverHanoi(int numeroDiscos, char origen, char destino, char auxiliar)
        {
            // Caso base: si solo hay un disco, moverlo directamente
            if (numeroDiscos == 1)
            {
                MoverDisco(origen, destino);
                return;
            }
            
            // Paso 1: Mover n-1 discos del origen al auxiliar
            ResolverHanoi(numeroDiscos - 1, origen, auxiliar, destino);
            
            // Paso 2: Mover el disco más grande del origen al destino
            MoverDisco(origen, destino);
            
            // Paso 3: Mover n-1 discos del auxiliar al destino
            ResolverHanoi(numeroDiscos - 1, auxiliar, destino, origen);
        }
        
        /// <summary>
        /// Mueve un disco de una torre a otra
        /// </summary>
        /// <param name="origen">Torre origen</param>
        /// <param name="destino">Torre destino</param>
        private void MoverDisco(char origen, char destino)
        {
            Stack<int> pilaOrigen = ObtenerTorre(origen);
            Stack<int> pilaDestino = ObtenerTorre(destino);
            
            // Verificar que la torre origen no esté vacía
            if (pilaOrigen.Count == 0)
            {
                Console.WriteLine($"Error: No hay discos en la torre {origen}");
                return;
            }
            
            // Mover el disco
            int disco = pilaOrigen.Pop();
            pilaDestino.Push(disco);
            
            numeroMovimientos++;
            
            // Mostrar el movimiento realizado
            Console.WriteLine($"Movimiento {numeroMovimientos}: Mover disco {disco} de torre {origen} a torre {destino}");
            
            // Mostrar el estado actual de las torres
            MostrarEstadoTorres();
            Console.WriteLine();
        }
        
        /// <summary>
        /// Obtiene la referencia a la pila correspondiente según el identificador
        /// </summary>
        /// <param name="identificador">Identificador de la torre (A, B, C)</param>
        /// <returns>Referencia a la pila correspondiente</returns>
        private Stack<int> ObtenerTorre(char identificador)
        {
            switch (identificador)
            {
                case 'A': return torreA;
                case 'B': return torreB;
                case 'C': return torreC;
                default: throw new ArgumentException($"Torre {identificador} no válida");
            }
        }
        
        /// <summary>
        /// Muestra el estado actual de las tres torres
        /// </summary>
        private void MostrarEstadoTorres()
        {
            Console.WriteLine("Estado actual:");
            Console.WriteLine($"Torre A: [{string.Join(", ", torreA.Reverse())}]");
            Console.WriteLine($"Torre B: [{string.Join(", ", torreB.Reverse())}]");
            Console.WriteLine($"Torre C: [{string.Join(", ", torreC.Reverse())}]");
        }
        
        /// <summary>
        /// Inicia la resolución del problema y muestra el estado inicial
        /// </summary>
        /// <param name="numeroDiscos">Cantidad de discos</param>
        public void IniciarResolucion(int numeroDiscos)
        {
            Console.WriteLine("=== TORRES DE HANOI ===\n");
            Console.WriteLine($"Resolviendo Torres de Hanoi con {numeroDiscos} discos");
            Console.WriteLine("Estado inicial:");
            MostrarEstadoTorres();
            Console.WriteLine("\nIniciando resolución...\n");
            
            ResolverHanoi(numeroDiscos, 'A', 'C', 'B');
            
            Console.WriteLine($"\n¡Problema resuelto en {numeroMovimientos} movimientos!");
            Console.WriteLine($"Número mínimo teórico de movimientos: {Math.Pow(2, numeroDiscos) - 1}");
        }
    }
}
