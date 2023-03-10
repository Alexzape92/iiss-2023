# Práctica de Herencia
## Reglas de Compilación y Ejecución
Para compilar en entorno Linux, ejecutamos:

    mcs Figuras.cs && mcs Instrumentos.cs
Y para ejecutar:

    mono Figuras.exe
    mono Instrumentos.exe

## Ejemplos
### Figuras
Comenzaremos con el siguiente código:

[Figuras.cs](Figuras.cs)
```csharp
using System;

public interface Figura{

    //Tendremos un getter para Area
    float Area{get;}
    float Perimetro{get;}
}

public class Rectangulo: Figura{
    private float ancho, altura;
    public Rectangulo(float b, float h){
        ancho = b; altura = h;
    }

    public float Area{
        get{return ancho * altura;}
    }

    public float Perimetro{
        get{return 2*ancho + 2*altura;}
    }
}

public class Circulo: Figura{
    private float radio;
    private const float PI = 3.141592f;
    public Circulo(float r){radio = r;}

    public float Area{
        get{return PI * radio * radio;}
    }

    public float Perimetro{
        get{return 2 * PI * radio;}
    }
}

class Figuras{
    public static void Main(string[] args){
        Figura cuadrado = new Rectangulo(2, 3), circulo = new Circulo(2);

        Console.WriteLine(cuadrado.Area);
        Console.WriteLine(cuadrado.Perimetro);
        Console.WriteLine(circulo.Area);
        Console.WriteLine(circulo.Perimetro);
    }
}
```

En este ejemplo, estamos usando una `interface` como método de herencia de interfaz en `C#`. En este caso, estamos heredando un setter llamado `Area` y otro `Perimetro`, ambos de tipo `float`. Las clases que implementan esta interfaz, la heredan como cualquier otra clase, y se encargan de definir el comportamiento de dichos setters. Esta es la manera más útil de implementar la herencia sin perder calidad de código.
### Instrumentos
Veamos el siguiente ejemplo:
[Instrumentos.cs](Instrumentos.cs)
```csharp
using System;

public abstract class Instrumento{
    public virtual void tocar(){
        Console.WriteLine("*Suenan sonidos desafinados y generales*");
    }

    public abstract void afinar();
}

public class Viola: Instrumento{
    private bool afinado = false;

    public override void afinar(){
        afinado = true;
    }
    public override void tocar(){
        if(afinado)
            Console.WriteLine("*Suena la V sinfonía de Beethoven*");
        else
            Console.WriteLine("*Suenan sonidos horripilantes y agudos*");
    }
}

public class Piano: Instrumento{
    public override void afinar(){
        Console.WriteLine("El piano siempre está afinado");
    }
    public new void tocar(){
        Console.WriteLine("*Suena la IV sinfonía de Beethoven*");
    }
}

class Instrumentos{
    public static void Main(string[] args){
        Instrumento viola = new Viola();
        Instrumento piano = new Piano();

        viola.afinar(); piano.afinar();
        viola.tocar();
        piano.tocar();
        ((Piano)piano).tocar();
    }

    
}
```
En este ejemplo, estamos usando herencia de comportamiento. Tenemos una clase abstracta, `Instrumento`, que tiene definido un método `tocar`, y otro abstracto llamado `afinar`. Además, `tocar` es polimórfico, ya que está marcado con la palabra `virtual`.

Tenemos dos subclases, `Viola` y `Piano`. Ambos tienen definido su comportamiento de la función `afinar`, que debe ser marcada como `override` al ser una función abstracta en la clase base. En cuanto a la función polimórfica, vemos que `Viola` la marca como `override` y `Piano` como `new`. Esto es, la primera "sobreescribe" la función, usando siempre el comportamiento de la clase derivada, y la segunda "añade" un nuevo comportamiento, de manera que usará el comportamiento del tipo con el que se trate el objeto `Piano`. Es por esto que la salida de este programa es:

    El piano siempre está afinado
    *Suena la V sinfonía de Beethoven*
    *Suenan sonidos desafinados y generales*
    *Suena la IV sinfonía de Beethoven*

Si el objeto piano se trata como `Instrumento` se utiliza el método `tocar` de la superclase, mientras que si le hacemos un Downcasting (técnica poco recomendada) a `Piano`, se usará su propia versión del método.
