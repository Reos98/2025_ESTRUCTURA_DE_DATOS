using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaVacunacionCOVID
{
    /// <summary>
    /// Representa un ciudadano en el sistema de vacunación
    /// </summary>
    public class Ciudadano
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }

        public Ciudadano(int id, string nombre, string cedula)
        {
            Id = id;
            Nombre = nombre;
            Cedula = cedula;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Cédula: {Cedula}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Ciudadano other)
                return Id == other.Id;
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    /// <summary>
    /// Enumeración de tipos de vacunas disponibles
    /// </summary>
    public enum TipoVacuna
    {
        Pfizer,
        AstraZeneca
    }

    /// <summary>
    /// Representa un registro de vacunación
    /// </summary>
    public class RegistroVacunacion
    {
        public Ciudadano Ciudadano { get; set; }
        public TipoVacuna TipoVacuna { get; set; }
        public int NumeroDosis { get; set; } // 1 para primera dosis, 2 para segunda dosis
        public DateTime FechaVacunacion { get; set; }

        public RegistroVacunacion(Ciudadano ciudadano, TipoVacuna tipoVacuna, int numeroDosis, DateTime fechaVacunacion)
        {
            Ciudadano = ciudadano;
            TipoVacuna = tipoVacuna;
            NumeroDosis = numeroDosis;
            FechaVacunacion = fechaVacunacion;
        }

        public override string ToString()
        {
            return $"{Ciudadano} - Vacuna: {TipoVacuna}, Dosis: {NumeroDosis}, Fecha: {FechaVacunacion:yyyy-MM-dd}";
        }
    }

    /// <summary>
    /// Clase principal que maneja el sistema de vacunación usando teoría de conjuntos
    /// </summary>
    public class SistemaVacunacion
    {
        private HashSet<Ciudadano> todosCiudadanos;
        private HashSet<Ciudadano> vacunadosPfizer;
        private HashSet<Ciudadano> vacunadosAstraZeneca;
        private List<RegistroVacunacion> registrosVacunacion;
        private Random random;

        public SistemaVacunacion()
        {
            todosCiudadanos = new HashSet<Ciudadano>();
            vacunadosPfizer = new HashSet<Ciudadano>();
            vacunadosAstraZeneca = new HashSet<Ciudadano>();
            registrosVacunacion = new List<RegistroVacunacion>();
            random = new Random();
        }

        /// <summary>
        /// Genera datos ficticios de ciudadanos y vacunaciones
        /// </summary>
        public void GenerarDatosFicticios()
        {
            Console.WriteLine("Generando datos ficticios...\n");

            // Generar 500 ciudadanos
            GenerarCiudadanos(500);

            // Seleccionar aleatoriamente 75 ciudadanos para Pfizer
            var ciudadanosParaPfizer = todosCiudadanos.OrderBy(x => random.Next()).Take(75).ToList();
            foreach (var ciudadano in ciudadanosParaPfizer)
            {
                vacunadosPfizer.Add(ciudadano);
            }

            // Seleccionar aleatoriamente 75 ciudadanos para AstraZeneca (pueden coincidir con Pfizer)
            var ciudadanosParaAstraZeneca = todosCiudadanos.OrderBy(x => random.Next()).Take(75).ToList();
            foreach (var ciudadano in ciudadanosParaAstraZeneca)
            {
                vacunadosAstraZeneca.Add(ciudadano);
            }

            // Generar registros de vacunación
            GenerarRegistrosVacunacion();

            Console.WriteLine($"Total de ciudadanos: {todosCiudadanos.Count}");
            Console.WriteLine($"Ciudadanos vacunados con Pfizer: {vacunadosPfizer.Count}");
            Console.WriteLine($"Ciudadanos vacunados con AstraZeneca: {vacunadosAstraZeneca.Count}");
            Console.WriteLine($"Total de registros de vacunación: {registrosVacunacion.Count}\n");
        }

        /// <summary>
        /// Genera la lista de ciudadanos ficticios
        /// </summary>
        private void GenerarCiudadanos(int cantidad)
        {
            for (int i = 1; i <= cantidad; i++)
            {
                string nombre = $"Ciudadano {i:D3}";
                string cedula = GenerarCedula();
                todosCiudadanos.Add(new Ciudadano(i, nombre, cedula));
            }
        }

        /// <summary>
        /// Genera una cédula ficticia
        /// </summary>
        private string GenerarCedula()
        {
            return $"{random.Next(10000000, 99999999)}";
        }

        /// <summary>
        /// Genera registros de vacunación para los ciudadanos seleccionados
        /// </summary>
        private void GenerarRegistrosVacunacion()
        {
            DateTime fechaBase = DateTime.Now.AddDays(-365);

            // Registros para vacunados con Pfizer
            foreach (var ciudadano in vacunadosPfizer)
            {
                // Primera dosis
                DateTime fechaPrimera = fechaBase.AddDays(random.Next(0, 300));
                registrosVacunacion.Add(new RegistroVacunacion(ciudadano, TipoVacuna.Pfizer, 1, fechaPrimera));

                // Algunos reciben segunda dosis (simular que algunos tienen esquema completo)
                if (random.Next(1, 101) <= 80) // 80% recibe segunda dosis
                {
                    DateTime fechaSegunda = fechaPrimera.AddDays(21 + random.Next(0, 14));
                    registrosVacunacion.Add(new RegistroVacunacion(ciudadano, TipoVacuna.Pfizer, 2, fechaSegunda));
                }
            }

            // Registros para vacunados con AstraZeneca
            foreach (var ciudadano in vacunadosAstraZeneca)
            {
                // Verificar si ya tiene registro de Pfizer para evitar duplicados en el mismo día
                bool tienePfizer = vacunadosPfizer.Contains(ciudadano);
                
                DateTime fechaPrimera = fechaBase.AddDays(random.Next(0, 300));
                if (tienePfizer)
                {
                    // Si tiene Pfizer, programar AstraZeneca en fecha diferente
                    fechaPrimera = fechaBase.AddDays(random.Next(300, 365));
                }

                registrosVacunacion.Add(new RegistroVacunacion(ciudadano, TipoVacuna.AstraZeneca, 1, fechaPrimera));

                // Algunos reciben segunda dosis
                if (random.Next(1, 101) <= 75) // 75% recibe segunda dosis
                {
                    DateTime fechaSegunda = fechaPrimera.AddDays(28 + random.Next(0, 21));
                    registrosVacunacion.Add(new RegistroVacunacion(ciudadano, TipoVacuna.AstraZeneca, 2, fechaSegunda));
                }
            }
        }

        /// <summary>
        /// 1. Obtiene ciudadanos que NO se han vacunado
        /// Operación: TodosCiudadanos - (VacunadosPfizer ∪ VacunadosAstraZeneca)
        /// </summary>
        public HashSet<Ciudadano> ObtenerCiudadanosNoVacunados()
        {
            var vacunados = new HashSet<Ciudadano>(vacunadosPfizer);
            vacunados.UnionWith(vacunadosAstraZeneca);
            
            var noVacunados = new HashSet<Ciudadano>(todosCiudadanos);
            noVacunados.ExceptWith(vacunados);
            
            return noVacunados;
        }

        /// <summary>
        /// 2. Obtiene ciudadanos que han recibido ambas dosis (esquema completo)
        /// </summary>
        public HashSet<Ciudadano> ObtenerCiudadanosConAmbasDosis()
        {
            var conAmbasDosis = new HashSet<Ciudadano>();

            // Buscar ciudadanos que tienen 2 registros de la misma vacuna
            var ciudadanosConSegundaDosis = registrosVacunacion
                .Where(r => r.NumeroDosis == 2)
                .Select(r => r.Ciudadano)
                .Distinct();

            foreach (var ciudadano in ciudadanosConSegundaDosis)
            {
                // Verificar que tenga primera y segunda dosis de al menos una vacuna
                var registrosCiudadano = registrosVacunacion
                    .Where(r => r.Ciudadano.Equals(ciudadano))
                    .GroupBy(r => r.TipoVacuna);

                foreach (var grupo in registrosCiudadano)
                {
                    var dosis = grupo.Select(r => r.NumeroDosis).ToList();
                    if (dosis.Contains(1) && dosis.Contains(2))
                    {
                        conAmbasDosis.Add(ciudadano);
                        break;
                    }
                }
            }

            return conAmbasDosis;
        }

        /// <summary>
        /// 3. Obtiene ciudadanos que SOLO han recibido vacuna Pfizer
        /// Operación: VacunadosPfizer - VacunadosAstraZeneca
        /// </summary>
        public HashSet<Ciudadano> ObtenerCiudadanosSoloPfizer()
        {
            var soloPfizer = new HashSet<Ciudadano>(vacunadosPfizer);
            soloPfizer.ExceptWith(vacunadosAstraZeneca);
            return soloPfizer;
        }

        /// <summary>
        /// 4. Obtiene ciudadanos que SOLO han recibido vacuna AstraZeneca
        /// Operación: VacunadosAstraZeneca - VacunadosPfizer
        /// </summary>
        public HashSet<Ciudadano> ObtenerCiudadanosSoloAstraZeneca()
        {
            var soloAstraZeneca = new HashSet<Ciudadano>(vacunadosAstraZeneca);
            soloAstraZeneca.ExceptWith(vacunadosPfizer);
            return soloAstraZeneca;
        }

        /// <summary>
        /// Obtiene ciudadanos que han recibido ambas vacunas (Pfizer Y AstraZeneca)
        /// Operación: VacunadosPfizer ∩ VacunadosAstraZeneca
        /// </summary>
        public HashSet<Ciudadano> ObtenerCiudadanosConAmbasVacunas()
        {
            var conAmbasVacunas = new HashSet<Ciudadano>(vacunadosPfizer);
            conAmbasVacunas.IntersectWith(vacunadosAstraZeneca);
            return conAmbasVacunas;
        }

        /// <summary>
        /// Muestra los resultados de las consultas solicitadas
        /// </summary>
        public void MostrarResultados()
        {
            Console.WriteLine("=== RESULTADOS DEL ANÁLISIS DE VACUNACIÓN COVID-19 ===\n");

            // 1. Ciudadanos no vacunados
            var noVacunados = ObtenerCiudadanosNoVacunados();
            Console.WriteLine($"1. CIUDADANOS NO VACUNADOS ({noVacunados.Count}):");
            Console.WriteLine("   (TodosCiudadanos - (VacunadosPfizer ∪ VacunadosAstraZeneca))");
            MostrarListado(noVacunados, 10);

            // 2. Ciudadanos con ambas dosis
            var conAmbasDosis = ObtenerCiudadanosConAmbasDosis();
            Console.WriteLine($"\n2. CIUDADANOS CON ESQUEMA COMPLETO - AMBAS DOSIS ({conAmbasDosis.Count}):");
            Console.WriteLine("   (Ciudadanos que tienen 1ra y 2da dosis de al menos una vacuna)");
            MostrarListado(conAmbasDosis, 10);

            // 3. Ciudadanos solo con Pfizer
            var soloPfizer = ObtenerCiudadanosSoloPfizer();
            Console.WriteLine($"\n3. CIUDADANOS QUE SOLO HAN RECIBIDO PFIZER ({soloPfizer.Count}):");
            Console.WriteLine("   (VacunadosPfizer - VacunadosAstraZeneca)");
            MostrarListado(soloPfizer, 10);

            // 4. Ciudadanos solo con AstraZeneca
            var soloAstraZeneca = ObtenerCiudadanosSoloAstraZeneca();
            Console.WriteLine($"\n4. CIUDADANOS QUE SOLO HAN RECIBIDO ASTRAZENECA ({soloAstraZeneca.Count}):");
            Console.WriteLine("   (VacunadosAstraZeneca - VacunadosPfizer)");
            MostrarListado(soloAstraZeneca, 10);

            // Información adicional
            var conAmbasVacunas = ObtenerCiudadanosConAmbasVacunas();
            Console.WriteLine($"\n--- INFORMACIÓN ADICIONAL ---");
            Console.WriteLine($"Ciudadanos con ambas vacunas (Pfizer Y AstraZeneca): {conAmbasVacunas.Count}");
            Console.WriteLine("   (VacunadosPfizer ∩ VacunadosAstraZeneca)");

            // Verificación de conjuntos
            Console.WriteLine($"\n--- VERIFICACIÓN DE TEORÍA DE CONJUNTOS ---");
            Console.WriteLine($"Total ciudadanos: {todosCiudadanos.Count}");
            Console.WriteLine($"No vacunados: {noVacunados.Count}");
            Console.WriteLine($"Solo Pfizer: {soloPfizer.Count}");
            Console.WriteLine($"Solo AstraZeneca: {soloAstraZeneca.Count}");
            Console.WriteLine($"Ambas vacunas: {conAmbasVacunas.Count}");
            Console.WriteLine($"Suma: {noVacunados.Count + soloPfizer.Count + soloAstraZeneca.Count + conAmbasVacunas.Count}");
        }

        /// <summary>
        /// Muestra un listado de ciudadanos (limitado para legibilidad)
        /// </summary>
        private void MostrarListado(HashSet<Ciudadano> ciudadanos, int limite)
        {
            var lista = ciudadanos.Take(limite).ToList();
            foreach (var ciudadano in lista)
            {
                Console.WriteLine($"   {ciudadano}");
            }
            
            if (ciudadanos.Count > limite)
            {
                Console.WriteLine($"   ... y {ciudadanos.Count - limite} más");
            }
        }

        /// <summary>
        /// Exporta los resultados a un archivo de texto
        /// </summary>
        public void ExportarResultados(string nombreArchivo)
        {
            try
            {
                using (var writer = new System.IO.StreamWriter(nombreArchivo))
                {
                    writer.WriteLine("REPORTE DE VACUNACIÓN COVID-19");
                    writer.WriteLine("==============================");
                    writer.WriteLine($"Fecha de generación: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n");

                    var noVacunados = ObtenerCiudadanosNoVacunados();
                    writer.WriteLine($"1. CIUDADANOS NO VACUNADOS ({noVacunados.Count}):");
                    foreach (var ciudadano in noVacunados)
                    {
                        writer.WriteLine($"   {ciudadano}");
                    }

                    var conAmbasDosis = ObtenerCiudadanosConAmbasDosis();
                    writer.WriteLine($"\n2. CIUDADANOS CON AMBAS DOSIS ({conAmbasDosis.Count}):");
                    foreach (var ciudadano in conAmbasDosis)
                    {
                        writer.WriteLine($"   {ciudadano}");
                    }

                    var soloPfizer = ObtenerCiudadanosSoloPfizer();
                    writer.WriteLine($"\n3. CIUDADANOS SOLO CON PFIZER ({soloPfizer.Count}):");
                    foreach (var ciudadano in soloPfizer)
                    {
                        writer.WriteLine($"   {ciudadano}");
                    }

                    var soloAstraZeneca = ObtenerCiudadanosSoloAstraZeneca();
                    writer.WriteLine($"\n4. CIUDADANOS SOLO CON ASTRAZENECA ({soloAstraZeneca.Count}):");
                    foreach (var ciudadano in soloAstraZeneca)
                    {
                        writer.WriteLine($"   {ciudadano}");
                    }
                }

                Console.WriteLine($"\nReporte exportado exitosamente a: {nombreArchivo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al exportar el archivo: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Clase principal del programa
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE VACUNACIÓN COVID-19 ===");
            Console.WriteLine("Ministerio de Salud - República del Ecuador\n");

            try
            {
                // Crear instancia del sistema
                var sistema = new SistemaVacunacion();

                // Generar datos ficticios
                sistema.GenerarDatosFicticios();

                // Mostrar resultados
                sistema.MostrarResultados();

                // Preguntar si desea exportar resultados
                Console.WriteLine("\n¿Desea exportar los resultados a un archivo? (s/n): ");
                string respuesta = Console.ReadLine();
                
                if (respuesta?.ToLower() == "s" || respuesta?.ToLower() == "si")
                {
                    string nombreArchivo = $"ReporteVacunacion_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                    sistema.ExportarResultados(nombreArchivo);
                }

                Console.WriteLine("\nPresione cualquier tecla para salir...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la ejecución del programa: {ex.Message}");
                Console.WriteLine("Presione cualquier tecla para salir...");
                Console.ReadKey();
            }
        }
    }
}