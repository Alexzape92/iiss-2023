public interface Engine {
    public void start();
    public void stop();
    public boolean isRunning();
    public int getRPM();
    public void accelerate();
    public void decelerate();
}