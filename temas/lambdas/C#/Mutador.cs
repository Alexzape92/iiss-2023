using System;

public class Mutador{
    public string texto{get; set;} = "Texto de Ejemplo";

    public void mutar(Func<string, string> action){
        texto = action(texto);
    }

    public static void Main(string[] args)
    {
        Mutador mutador = new Mutador();

        mutador.mutar(texto => texto.ToUpper());
        Console.WriteLine(mutador.texto);

        mutador.mutar(t => {
            t = t.ToLower();
            if(t.Contains("ejemplo"))
                return "He sido modificado";
            return t;
        });
        Console.WriteLine(mutador.texto);
    }
}