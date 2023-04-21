# Práctica de Anotaciones
## Compilación y Ejecución
Para compilar y ejecutar, bastará con ejecutar los dos siguientes comandos:

    javac *.java
    java Main
## Ejemplo
En este ejemplo, se realiza una inyección de dependencias utilizando anotaciones en Java. El ejemplo trata sobre coches de fórmula 1, que tienen un motor, cada uno de los cuales llega a unas ciertas revoluciones al acelerarlo. Tenemos las siguientes clases:

[AstonMartinF1.java](AstonMartinF1.java)
```java
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
```

[Engine.java](Engine.java)
```java
public interface Engine {
    public void start();
    public void stop();
    public boolean isRunning();
    public int getRPM();
    public void accelerate();
    public void decelerate();
}
```

[MercedesM14.java](MercedesM14.java)
```java
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
```

[EngineType.java](EngineType.java)
```java
import java.lang.annotation.Retention;
import java.lang.annotation.Target;

@Retention(java.lang.annotation.RetentionPolicy.RUNTIME)
@Target({java.lang.annotation.ElementType.TYPE})
public @interface EngineType {
    Class<?> value();
}
```

[GetEngine.java](GetEngine.java)
```java
public class GetEngine {
    public Engine getEngine(Object obj) {
        Class<?> c = obj.getClass();
        EngineType engineType = c.getAnnotation(EngineType.class);
        Class<?> engineClass = engineType.value();
        Engine engine = null;
        try {
            engine = (Engine) engineClass.getDeclaredConstructor().newInstance();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return engine;
    }
}
```

[Main.java](Main.java)
```java
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
```

Vemos que en la clase `AstonMartinF1` tenemos una anotación `@EngineType(MercedesM14.class)`, que indica que el motor que tiene el coche es de la clase `MercedesM14`. En la clase `GetEngine` tenemos un método `getEngine`, que recibe un objeto de la clase `AstonMartinF1` y devuelve un objeto `Engine`. Para ello, primero se obtiene la clase del objeto que se le pasa como parámetro, y se obtiene la anotación `@EngineType` de dicha clase. A continuación, se obtiene la clase del motor que se ha indicado en la anotación, y se crea un objeto de dicha clase. Finalmente, se devuelve el objeto creado.

Así, si en las temporadas siguientes, Aston Martin cambiar de motor a Ferrari (esperemos que no...), bastaría con cambiar la anotación `@EngineType(MercedesM14.class)` por `@EngineType(FerrariF1.class)`, y el coche seguirá funcionando correctamente.