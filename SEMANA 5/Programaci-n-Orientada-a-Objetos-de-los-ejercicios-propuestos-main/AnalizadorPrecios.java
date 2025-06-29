import java.util.*;

public class AnalizadorPrecios {
    private List<Double> precios;

    public AnalizadorPrecios() {
        precios = Arrays.asList(50.0, 75.0, 46.0, 22.0, 80.0, 65.0, 8.0);
    }

    public void mostrarMinimoMaximo() {
        double min = Collections.min(precios);
        double max = Collections.max(precios);
        System.out.println("Precio mínimo: " + min);
        System.out.println("Precio máximo: " + max);
    }

    public static void main(String[] args) {
        new AnalizadorPrecios().mostrarMinimoMaximo();
    }
}