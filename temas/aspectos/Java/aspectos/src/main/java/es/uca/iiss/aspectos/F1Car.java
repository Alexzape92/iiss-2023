package es.uca.iiss.aspectos;

public class F1Car
{
    private int number;
    private String driver;

    public F1Car(int number, String driver)
    {
        this.number = number;
        this.driver = driver;
    }

    public boolean makeTurn(Turn turn, float speed)
    {
        if(speed > turn.getMaxSpeed())
            return false;
        else
            return true;
    }

    public int getNumber()
    {
        return number;
    }

    public String getDriver()
    {
        return driver;
    }
}
