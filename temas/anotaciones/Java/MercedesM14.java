public class MercedesM14 implements Engine {
    private boolean running = false;
    private int rpm = 0;
    public void start() {
        running = true;
        rpm = 1000;
    }
    public void stop() {
        running = false;
        rpm = 0;
    }

    public void accelerate() {
        if (running)
            rpm = 15000;
    }

    public void decelerate() {
        if (running) {
            rpm = 1000;
        }
    }

    public boolean isRunning() {
        return running;
    }

    public int getRPM() {
        return rpm;
    }
}