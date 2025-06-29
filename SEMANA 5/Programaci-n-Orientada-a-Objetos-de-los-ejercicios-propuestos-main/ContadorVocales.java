import java.util.*;

public class ContadorVocales {
    private Scanner scanner;

    public ContadorVocales() {
        scanner = new Scanner(System.in);
    }

    public void contarVocales() {
        System.out.print("Ingrese una palabra: ");
        String palabra = scanner.nextLine().toLowerCase();
        int a = 0, e = 0, i = 0, o = 0, u = 0;

        for (char c : palabra.toCharArray()) {
            switch (c) {
                case 'a': a++; break;
                case 'e': e++; break;
                case 'i': i++; break;
                case 'o': o++; break;
                case 'u': u++; break;
            }
        }

        System.out.println("A: " + a);
        System.out.println("E: " + e);
        System.out.println("I: " + i);
        System.out.println("O: " + o);
        System.out.println("U: " + u);
    }

    public static void main(String[] args) {
        new ContadorVocales().contarVocales();
    }
}