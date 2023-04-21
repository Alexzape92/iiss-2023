@EngineType(MercedesM14.class)
public class AstonMartinF1 {
    private Engine engine;
    private GetEngine getEngine;

    public AstonMartinF1() {
        getEngine = new GetEngine();
        engine = getEngine.getEngine(this);
    }

    public void start() {
        engine.start();
    }

    public void stop() {
        engine.stop();
    }

    public void accelerate() {
        engine.accelerate();
    }

    public void decelerate() {
        engine.decelerate();
    }

    public void turnLeft() {
        System.out.println("Turning left");
    }

    public void turnRight() {
        System.out.println("Turning right");
    }

    public void brake() {
        engine.decelerate();
        System.out.println("Braking");
    }

    public void displayRPM() {
        System.out.println("RPM: " + engine.getRPM());
    }
}
