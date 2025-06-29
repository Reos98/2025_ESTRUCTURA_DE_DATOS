import java.util.Scanner;
public class DetectorPalindromo {
    private Scanner scanner;

    public DetectorPalindromo() {
        scanner = new Scanner(System.in);
    }

    public boolean esPalindromo(String palabra) {
        String invertida = new StringBuilder(palabra.toLowerCase()).reverse().toString();
        return palabra.toLowerCase().equals(invertida);
    }

    public void ejecutar() {
        System.out.print("Ingrese una palabra: ");
        String palabra = scanner.nextLine();
        if (esPalindromo(palabra)) {
            System.out.println("Es un palíndromo.");
        } else {
            System.out.println("No es un palíndromo.");
        }
    }

    public static void main(String[] args) {
        new DetectorPalindromo().ejecutar();
    }
}