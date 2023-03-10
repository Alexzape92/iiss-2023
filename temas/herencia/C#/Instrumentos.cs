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