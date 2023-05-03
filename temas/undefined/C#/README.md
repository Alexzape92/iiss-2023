# Práctica de Indefinidos
## Compilación y ejecución
Para compilar el código, se puede usar el siguiente comando:

    mcs NullExample.cs
    mcs InvalidNullExample.cs

Y para ejecutar (sólo el primero, el segundo no compila):

    mono NullExample.exe

## Ejemplo
En este ejemplo, se muestra el uso de los tipos indefinidos (null) en `C#`. Para ello, se ha creado primero este código, que se corresponde con la primera aproximación al problema:

[InvalidNullExample.cs](InvalidNullExample.cs)
```csharp
using System;

public class invalidNullExample{
    private static void invalidNullAssignment(){
        int number = null;
        System.Console.WriteLine(number);
    }

    public static void Main(string[] args){
        invalidNullAssignment();
    }
}
```
Este código no va a compilar. Esto es porque el tipo `int` es un `non-nullable type`, es decir, no puede ser asignado a ǹull`. Esta es la salida del compilador:

    InvalidNullExample.cs(5,22): error CS0037: Cannot convert null to `int' because it is a value type
    Compilation failed: 1 error(s), 0 warnings
Para solucionar este problema, se han recogido varias alternativas que ofrece `C#`, en el siguiente código:

[NullExample.cs](NullExample.cs)
```csharp
using System;

public class NullExample{
    private static void validNullAssignment(){
        int? number = null;
        System.Console.WriteLine(number);
    }

    private static void nullableType(){
        Nullable<int> number1 = null, number2 = 10;
        if(number1.HasValue)
            System.Console.WriteLine(number1.Value);
        else
            System.Console.WriteLine("number1 is null");
        
        if(number2.HasValue)
            System.Console.WriteLine(number2.Value);
        else
            System.Console.WriteLine("number2 is null");
    }

    private static void nullCollation(){
        int? number1 = null;
        int? number2 = 10;
        
        //This should print 5
        System.Console.WriteLine(number1 ?? 5);
        //This should print 10
        System.Console.WriteLine(number2 ?? 5);
    }

    public static void Main(string[] args){
        validNullAssignment();
        nullableType();
        nullCollation();
    }
}
```

La primera viene en el método `validNullAssignment()`. En este caso, se ha declarado la variable `number` como un `nullable type`, es decir, un tipo que puede ser asignado a `null`. Para ello, se ha añadido el símbolo `?` al final del tipo. Esto no imprimirá nada, ya que el valor de `number` es `null`.

La segunda viene en el método `nullableType()`. En este caso, se ha declarado la variable `number1` como un `nullable type`, y se ha inicializado a `null`. En cambio, la variable `number2` se ha inicializado a `10`. Para comprobar si un `nullable type` tiene un valor, se puede usar la propiedad `HasValue`. Para obtener el valor de un `nullable type`, se puede usar la propiedad `Value`. En este caso, se imprime `number1 is null` y `10`.

Un operador adicional muy útil que nos ofrece `C#` es el operador `??`. Este operador se puede usar para asignar un valor por defecto a una variable en caso de que esta sea `null`. En el método `nullCollation()`, se han inicializado dos variables `number1` a `null` y `number2` a `10`. A continuación, se imprime el valor de `number1` usando el operador `??`. Esto imprimirá `5`, ya que `number1` es `null`. En cambio, al imprimir `number2` usando el operador `??`, se imprimirá `10`, ya que `number2` no es `null`.