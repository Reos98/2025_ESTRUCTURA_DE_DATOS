using System;

// La clase circulo representa un círculo geométrico y encapsula el valor de su radio
public class Circulo
{
    // El atributo 'radio' representa el radio del círculo, es de tipo double
    private double radio;

    // Constructor que recibe el valor del radio y lo asigna al atributo privado
    public Circulo(double radio)
    {
        this.radio = radio;
    }

    // Método que devuelve el radio actual del círculo
    public double getradio()
    {
        return radio;
    }

    // Método que permite cambiar el valor del radio si es mayor que 0
    public void setradio(double nuevoradio)
    {
        if (nuevoradio > 0)
            radio = nuevoradio;
    }

    // calculararea es una función que devuelve un valor double,
    // se utiliza para calcular el área de un círculo usando su radio
    public double calculararea()
    {
        return Math.PI * radio * radio;
    }

    // calcularperimetro es una función que devuelve el perímetro (longitud de la circunferencia)
    public double calcularperimetro()
    {
        return 2 * Math.PI * radio;
    }
}

// La clase cuadrado representa un cuadrado geométrico y encapsula el valor de su lado
public class Cuadrado
{
    // El atributo 'lado' representa la longitud del lado del cuadrado
    private double lado;

    // Constructor que inicializa el lado del cuadrado
    public Cuadrado(double lado)
    {
        this.lado = lado;
    }

    // Método que devuelve el valor actual del lado
    public double getlado()
    {
        return lado;
    }

    // Método que permite actualizar el lado si es mayor que 0
    public void setlado(double nuevolado)
    {
        if (nuevolado > 0)
            lado = nuevolado;
    }

    // calculararea devuelve el área del cuadrado: lado * lado
    public double calculararea()
    {
        return lado * lado;
    }

    // calcularperimetro devuelve el perímetro del cuadrado: 4 * lado
    public double calcularperimetro()
    {
        return 4 * lado;
    }
}

// Clase principal donde se prueban las otras clases
class Program
{
    static void Main(string[] args)
    {
        // Crear un objeto de tipo circulo con radio 3
        Circulo miCirculo = new Circulo(3);

        Console.WriteLine("🔵 CÍRCULO");
        Console.WriteLine($"Radio: {miCirculo.getradio()}");
        Console.WriteLine($"Área: {miCirculo.calculararea()}");
        Console.WriteLine($"Perímetro: {miCirculo.calcularperimetro()}");

        Console.WriteLine();

        // Crear un objeto de tipo cuadrado con lado 4
        Cuadrado miCuadrado = new Cuadrado(4);

        Console.WriteLine("🔷 CUADRADO");
        Console.WriteLine($"Lado: {miCuadrado.getlado()}");
        Console.WriteLine($"Área: {miCuadrado.calculararea()}");
        Console.WriteLine($"Perímetro: {miCuadrado.calcularperimetro()}");
    }
}
