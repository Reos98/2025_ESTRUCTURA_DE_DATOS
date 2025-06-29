import java.util.*;
public class ManipuladorAbecedario {
    private List<Character> abecedario;

    public ManipuladorAbecedario() {
        this.abecedario = new ArrayList<>();
        inicializarAbecedario();
    }

    private void inicializarAbecedario() {
        for (char letra = 'A'; letra <= 'Z'; letra++) {
            abecedario.add(letra);
        }
    }

    public void eliminarMultiplosDeTres() {
        List<Character> nuevaLista = new ArrayList<>();
        for (int i = 0; i < abecedario.size(); i++) {
            if ((i + 1) % 3 != 0) {
                nuevaLista.add(abecedario.get(i));
            }
        }
        abecedario = nuevaLista;
    }

    public void mostrarAbecedario() {
        System.out.println("Abecedario resultante:");
        for (Character c : abecedario) {
            System.out.print(c + " ");
        }
        System.out.println();
    }

    public static void main(String[] args) {
        ManipuladorAbecedario manip = new ManipuladorAbecedario();
        manip.eliminarMultiplosDeTres();
        manip.mostrarAbecedario();
    }
}