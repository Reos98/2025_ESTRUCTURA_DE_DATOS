import java.util.*;
public class GestorAsignaturas {
    private List<String> asignaturas;
    private Map<String, Double> notas;
    private Scanner scanner;
    private static final double NOTA_APROBADO = 6.0;

    public GestorAsignaturas() {
        this.asignaturas = new ArrayList<>();
        this.notas = new HashMap<>();
        this.scanner = new Scanner(System.in);
        inicializarAsignaturas();
    }

    private void inicializarAsignaturas() {
        asignaturas.add("Matemáticas");
        asignaturas.add("Física");
        asignaturas.add("Química");
        asignaturas.add("Historia");
        asignaturas.add("Lengua");
    }

    public void solicitarNotas() {
        System.out.println("=== REGISTRO DE CALIFICACIONES ===");
        for (String asignatura : asignaturas) {
            System.out.print("Ingrese la nota de " + asignatura + ": ");
            double nota = scanner.nextDouble();
            notas.put(asignatura, nota);
        }
    }

    public void procesarAsignaturas() {
        Iterator<String> iterator = asignaturas.iterator();
        while (iterator.hasNext()) {
            String asignatura = iterator.next();
            if (notas.get(asignatura) >= NOTA_APROBADO) {
                iterator.remove();
            }
        }
    }

    public void mostrarAsignaturasARepetir() {
        System.out.println("\n=== ASIGNATURAS A REPETIR ===");
        if (asignaturas.isEmpty()) {
            System.out.println("¡Felicidades! Has aprobado todas las asignaturas.");
        } else {
            for (int i = 0; i < asignaturas.size(); i++) {
                String asignatura = asignaturas.get(i);
                System.out.println((i + 1) + ". " + asignatura + " (Nota: " + notas.get(asignatura) + ")");
            }
        }
    }

    public static void main(String[] args) {
        GestorAsignaturas gestor = new GestorAsignaturas();
        gestor.solicitarNotas();
        gestor.procesarAsignaturas();
        gestor.mostrarAsignaturasARepetir();
    }
}