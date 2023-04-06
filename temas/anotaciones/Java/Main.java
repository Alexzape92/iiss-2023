public class Main {
    public static void main(String[] args) {
        AstonMartinF1 car = new AstonMartinF1();
        car.start();
        car.accelerate();
        car.displayRPM();
        car.brake();
        car.displayRPM();
        car.stop();
    }
}
