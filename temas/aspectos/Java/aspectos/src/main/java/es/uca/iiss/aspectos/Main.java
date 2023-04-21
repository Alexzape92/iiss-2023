package es.uca.iiss.aspectos;

public class Main {
    public static void main(String[] args) {
        F1Car car1 = new F1Car(14, "Fernando Alonso");
        F1Car car2 = new F1Car(7, "Kimi Raikkonen");
        Turn turn1 = new Turn(200);

        car1.makeTurn(turn1, 210);
        car2.makeTurn(turn1, 190);

        System.out.println("Penalty for car " + car1.getNumber() + ": " + Fia.getPenalty(car1.getNumber()));
        System.out.println("Penalty for car " + car2.getNumber() + ": " + Fia.getPenalty(car2.getNumber()));
    }
}
