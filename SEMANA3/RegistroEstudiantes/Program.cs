using System;

namespace RegistroEstudiantes
{
    /// <summary>
    /// Clase que representa un estudiante con sus datos personales
    /// </summary>
    public class Estudiante
    {
        // Propiedades privadas para encapsulamiento
        private int id;
        private string nombres;
        private string apellidos;
        private string direccion;
        private string[] telefonos; // Array para almacenar hasta 3 teléfonos

        /// <summary>
        /// Constructor de la clase Estudiante
        /// </summary>
        /// <param name="id">Identificador único del estudiante</param>
        /// <param name="nombres">Nombres del estudiante</param>
        /// <param name="apellidos">Apellidos del estudiante</param>
        /// <param name="direccion">Dirección de residencia</param>
        public Estudiante(int id, string nombres, string apellidos, string direccion)
        {
            this.id = id;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.direccion = direccion;
            this.telefonos = new string[3]; // Inicializar array para 3 teléfonos
        }

        // Propiedades públicas con getters y setters
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        /// <summary>
        /// Método para agregar un teléfono al array
        /// </summary>
        /// <param name="telefono">Número telefónico a agregar</param>
        /// <param name="posicion">Posición en el array (0-2)</param>
        public void AgregarTelefono(string telefono, int posicion)
        {
            if (posicion >= 0 && posicion < 3)
            {
                telefonos[posicion] = telefono;
            }
            else
            {
                Console.WriteLine("Posición inválida. Use valores entre 0 y 2.");
            }
        }

        /// <summary>
        /// Método para obtener un teléfono específico
        /// </summary>
        /// <param name="posicion">Posición del teléfono (0-2)</param>
        /// <returns>Número telefónico o mensaje de error</returns>
        public string ObtenerTelefono(int posicion)
        {
            if (posicion >= 0 && posicion < 3)
            {
                return telefonos[posicion] ?? "No asignado";
            }
            return "Posición inválida";
        }

        /// <summary>
        /// Método para obtener todos los teléfonos
        /// </summary>
        /// <returns>Array de teléfonos</returns>
        public string[] ObtenerTodosLosTelefonos()
        {
            return telefonos;
        }

        /// <summary>
        /// Método para mostrar toda la información del estudiante
        /// </summary>
        public void MostrarInformacion()
        {
            Console.WriteLine("=== INFORMACIÓN DEL ESTUDIANTE ===");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Nombres: {nombres}");
            Console.WriteLine($"Apellidos: {apellidos}");
            Console.WriteLine($"Dirección: {direccion}");
            Console.WriteLine("Teléfonos:");
            
            for (int i = 0; i < telefonos.Length; i++)
            {
                Console.WriteLine($"  Teléfono {i + 1}: {(telefonos[i] ?? "No asignado")}");
            }
            Console.WriteLine("================================");
        }
    }

    /// <summary>
    /// Clase principal para demostrar el uso del sistema
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE REGISTRO DE ESTUDIANTES ===");
            Console.WriteLine();

            // Crear una instancia de estudiante
            Estudiante estudiante1 = new Estudiante(1001, "Juan Carlos", "Pérez García", "Av. Principal #123, Ciudad");

            // Agregar teléfonos usando el array
            estudiante1.AgregarTelefono("555-0123", 0); // Teléfono principal
            estudiante1.AgregarTelefono("555-0456", 1); // Teléfono secundario
            estudiante1.AgregarTelefono("555-0789", 2); // Teléfono de emergencia

            // Mostrar información completa
            estudiante1.MostrarInformacion();

            Console.WriteLine();

            // Demostrar acceso individual a teléfonos
            Console.WriteLine("=== ACCESO INDIVIDUAL A TELÉFONOS ===");
            Console.WriteLine($"Teléfono principal: {estudiante1.ObtenerTelefono(0)}");
            Console.WriteLine($"Teléfono secundario: {estudiante1.ObtenerTelefono(1)}");
            Console.WriteLine($"Teléfono de emergencia: {estudiante1.ObtenerTelefono(2)}");

            Console.WriteLine();

            // Crear otro estudiante para demostrar flexibilidad
            Estudiante estudiante2 = new Estudiante(1002, "María Elena", "López Martínez", "Calle Secundaria #456, Ciudad");
            estudiante2.AgregarTelefono("555-1111", 0);
            estudiante2.AgregarTelefono("555-2222", 1);
            // Dejamos el tercer teléfono sin asignar intencionalmente

            estudiante2.MostrarInformacion();

            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}