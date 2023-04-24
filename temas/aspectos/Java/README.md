# Práctica de aspectos
## Compilación y ejecución
Para compilar, ejecutaremos el comando:

    mvn compile
Y para ejecutar:

    mvn exec:java

## Implementación
Se han diseñado las siguientes clases:

[F1Car.java](aspectos/src/main/java/es/uca/iiss/aspectos/F1Car.java)

```java
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
```

[Turn.java](aspectos/src/main/java/es/uca/iiss/aspectos/Turn.java)

```java
package es.uca.iiss.aspectos;

public class Turn {
    private float maxSpeed;

    public Turn(float maxSpeed) {
        this.maxSpeed = maxSpeed;
    }

    public float getMaxSpeed() {
        return maxSpeed;
    }
}
```

[Fia.java](aspectos/src/main/java/es/uca/iiss/aspectos/Fia.java)

```java
package es.uca.iiss.aspectos;

import java.util.*;

public class Fia {
    private static Map<Integer, Integer> penalties = new HashMap<Integer, Integer>();

    public static void penalize(Integer car, int seconds) {
        if (penalties.containsKey(car)) {
            penalties.put(car, penalties.get(car) + seconds);
        } else {
            penalties.put(car, seconds);
        }
    }

    public static int getPenalty(Integer car) {
        if (penalties.containsKey(car)) {
            return penalties.get(car);
        } else {
            return 0;
        }
    }
}
```

Y el aspecto:

[TrackLimitsSensor.aj](aspectos/src/main/java/es/uca/iiss/aspectos/TrackLimitsSensor.aj)

```java
package es.uca.iiss.aspectos;

public aspect TrackLimitsSensor{
    pointcut turnMade(Turn turn, float speed, F1Car car): 
        call(boolean F1Car.makeTurn(Turn, float)) && args(turn, speed) && target(car);
    
    after(Turn turn, float speed, F1Car car): turnMade(turn, speed, car){
        if (speed > turn.getMaxSpeed()){
            Fia.penalize(car.getNumber(), 5);
        }
    }
}
```

El programa principal tiene el siguiente comportamiento:

[Main.java](aspectos/src/main/java/es/uca/iiss/aspectos/Main.java)

```java
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
```

Como se puede observar, el aspecto tiene un `pointcut` que se va a quedar escuchando llamadas al método `F1Car.makeTurn()`. Cuando se produzca una llamada a este método, se ejecutará el `after` que comprueba si la velocidad es mayor que la máxima permitida en la curva. En caso de que sea mayor, se penalizará al coche con 5 segundos. Estas penalizaciones las guarda la clase `Fia` en un `HashMap` que relaciona el número del coche con los segundos de penalización.

De esta manera, hemos evitado que la clase `F1Car` tenga que preocuparse de penalizar al coche cuando se exceda la velocidad máxima en una curva, lo que incurriría en un acoplamiento perjudicial.

Si ejecutamos el código, obtenemos:

    [INFO] --- exec-maven-plugin:1.2.1:java (default-cli) @ aspectos ---
    Penalty for car 14: 5
    Penalty for car 7: 0
Vemos como el coche 14 ha obtenido una penalización, ya que efectivamente, en el `Main` se ha creado un coche con el número 14 y se le ha hecho una curva con una velocidad mayor que la máxima permitida. Por el contrario, el coche 7 no ha obtenido penalización, ya que no se le ha hecho ninguna curva con una velocidad mayor a la permitida.
