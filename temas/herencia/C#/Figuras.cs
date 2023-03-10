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