using System;
using System.Collections.Generic;

namespace EjerciciosPilas
{
    /// <summary>
    /// Clase que implementa la verificación de paréntesis balanceados usando pilas
    /// Utiliza el principio LIFO para emparejar símbolos de apertura y cierre
    /// </summary>
    public class VerificadorParentesis
    {
        /// <summary>
        /// Verifica si los paréntesis, llaves y corchetes están balanceados en una expresión
        /// </summary>
        /// <param name="expresion">Expresión matemática a verificar</param>
        /// <returns>True si está balanceada, False en caso contrario</returns>
        public static bool EsFormulaBalanceada(string expresion)
        {
            // Pila para almacenar los símbolos de apertura
            Stack<char> pilaSimbolos = new Stack<char>();
            
            // Recorremos cada carácter de la expresión
            foreach (char caracter in expresion)
            {
                // Si es un símbolo de apertura, lo agregamos a la pila
                if (caracter == '(' || caracter == '[' || caracter == '{')
                {
                    pilaSimbolos.Push(caracter);
                }
                // Si es un símbolo de cierre, verificamos el emparejamiento
                else if (caracter == ')' || caracter == ']' || caracter == '}')
                {
                    // Si la pila está vacía, no hay símbolo de apertura correspondiente
                    if (pilaSimbolos.Count == 0)
                    {
                        return false;
                    }
                    
                    // Obtenemos el último símbolo de apertura
                    char simboloApertura = pilaSimbolos.Pop();
                    
                    // Verificamos si los símbolos coinciden
                    if (!SonParejasValidas(simboloApertura, caracter))
                    {
                        return false;
                    }
                }
            }
            
            // La expresión está balanceada si la pila queda vacía
            return pilaSimbolos.Count == 0;
        }
        
        /// <summary>
        /// Verifica si un par de símbolos forman una pareja válida
        /// </summary>
        /// <param name="apertura">Símbolo de apertura</param>
        /// <param name="cierre">Símbolo de cierre</param>
        /// <returns>True si forman una pareja válida</returns>
        private static bool SonParejasValidas(char apertura, char cierre)
        {
            return (apertura == '(' && cierre == ')') ||
                   (apertura == '[' && cierre == ']') ||
                   (apertura == '{' && cierre == '}');
        }
        
        /// <summary>
        /// Método principal para demostrar el funcionamiento
        /// </summary>
        public static void EjecutarPruebas()
        {
            Console.WriteLine("=== VERIFICACIÓN DE PARÉNTESIS BALANCEADOS ===\n");
            
            // Casos de prueba
            string[] expresiones = {
                "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}",
                "(a + b) * [c - d]",
                "{[(a + b) * c] - d}",
                "((a + b)",  // No balanceada
                "[{()}]",
                "([)]"       // No balanceada
            };
            
            foreach (string expresion in expresiones)
            {
                bool resultado = EsFormulaBalanceada(expresion);
                Console.WriteLine($"Expresión: {expresion}");
                Console.WriteLine($"Resultado: {(resultado ? "Fórmula balanceada" : "Fórmula NO balanceada")}");
                Console.WriteLine(new string('-', 50));
            }
        }
    }
}
