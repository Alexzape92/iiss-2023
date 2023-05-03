# Práctica de Expresiones Lambda
## Compilación y ejecución
Para compilar los programas, se puede utilizar:

    mcs Alumnos.cs
    mcs Mutador.cs
Para ejecutar los programas, se puede utilizar:

    mono Alumnos.exe
    mono Mutador.exe
## Ejemplo
En este ejemplo, se va a mostrar como se pueden utilizar las expresiones lambda en C# de diferentes maneras.

[Alumnos.cs](Alumnos.cs)
```csharp
using System;
using System.Linq;

public class Alumnos
{
    public string[] alumnos = {"Alejandro", "Manuel", "Violeta", "Pakito", "Miriam"};

    public void ImprimirAlumnosMayusculas(){
        var alumnosMayusculas = alumnos.Select(alumno => alumno.ToUpper());
        Console.WriteLine(string.Join(", ", alumnosMayusculas));
    }

    public static void Main(string[] args)
    {
        Alumnos alumnos = new Alumnos();
        alumnos.ImprimirAlumnosMayusculas();
    }
}
```
En este ejemplo, se puede ver como se utiliza la expresión lambda para convertir todos los nombres de los alumnos a mayúsculas. Es un ejemplo de uso de una expresión lambda para evitar tener que crear un método que haga lo mismo.

[Mutador.cs](Mutador.cs)
```csharp
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
```
En este ejemplo, hemos cambiado el punto de vista. Tenemos una propiedad que queremos modificar, y en vez de modificarla directamente, le pasamos una función que la modifique. En este caso, la función que le pasamos es una expresión lambda. Esto nos permite modificar la propiedad de diferentes maneras, sin tener que crear un método para cada una de ellas. Esto se realiza en el método `mutar`. Se puede ver como este método recibe un tipo `Func<string, string>`, que es una función lambda que recibe un string y devuelve otro. En el primer caso, la función que le pasamos es una expresión lambda que recibe un string y lo convierte a mayúsculas. En el segundo caso, se puede ver como la expresión lambda recibe un string, lo convierte a minúsculas, y si contiene la palabra "ejemplo", devuelve "He sido modificado". En caso contrario, devuelve el string original pasado a minúsculas.