# Ejemplo de Encapsulación C#
## Instrucciones de Compilación y Ejecución en Linux
Para compilar estos ficheros en linux, necesitaremos la herramienta `mono`. De esta manera, se compilaría de la siguiente manera:

    mcs *fichero.cs*

Lo cual nos generará un archivo .exe. Para ejecutar:

    mono *fichero.exe*

## Visibilidades Public y Private
Estas visibilidades son bien conocidas, igual que en el resto de lenguajes. En este ejemplo se busca demostrar que establecer los atributos de la clase a `public` no es buena idea. Si lo hacemos así, perdemos el control sobre qué posibles valores serán asignados a dicho atributo. Así podemos comprobar que la opción más correcta es tener al atributo como `private` y crear métodos públicos para editarlos, en los que podemos controlar los valores.

[public.cs](public.cs)
```csharp
using System;

class Student{
    public string DNI = "12345678S";

    public string Dni{
        get{return DNI;}
    }
}

class main{
    public static void Main(string[] args){
        Student st1 = new Student();

        st1.DNI = "estoestamal";
        Console.WriteLine(st1.Dni);
    }
}
```
En este ejemplo, tenemos el problema de que, al ser el atributo DNI público, se le pueden asignar valores sin comprobar si estos són válidos o no, como ocurre al ejecutar el ejemplo anterior.

[private.cs](private.cs)
```csharp
using System;

class Student{
    private string DNI = "12345678S";

    private static bool check(string mydni){
        if(mydni.Length != 9)
            return false;
        else
            return true;
    }

    public string Dni{
        get{return DNI;}
        set{if(check(value)) DNI = value;}
    }
}

class main{
    public static void Main(string[] args){
        Student st = new Student();

        st.Dni = "estoestamal";
        Console.WriteLine(st.Dni);

        st.Dni = "32092222S";
        Console.WriteLine(st.Dni);
    }
}
```

En este caso, tenemos el atributo DNI privado, de manera que no se puede modificar desde el Main. La herramienta pública que tenemos para modificar el DNI es el Setter Dni, el cual antes de cambiar el valor comprueba si el dni es válido. Esta comprobación la hace una función privada estática llamada check(). Si ejecutamos lo anterior, primero se imprimirá el valor que tenía DNI por defecto, ya que la primera llamada al setter no va a surgir efecto, y después se imprimirá el dni válido introducido. 

## Visibilidad Internal
Esta visibilidad es exclusiva de `C#`, y se asemeja bastante a la visibilidad de paquete de `Java`. Si la establecemos para un atributo, solo las clases que estén en el mismo "Assembly", que sería en el mismo fichero, podrán verlo. Esto se puede ver en el siguiente ejemplo:

[internal.cs](internal.cs)
```csharp
using System;

class Student{
    internal string DNI = "12345678S";

    public string Dni{
        get{return DNI;}
    }
}

class main{
    public static void Main(string[] args){
        Student st = new Student();

        st.DNI = "12123222F";
        Console.WriteLine(st.Dni);
    }
}
```

Si ejecutamos el programa, funcionará correctamente y editaremos el atributo correspondiente. Sin embargo, si tratamos de acceder a dicho atributo desde una clase definida en otro fichero, el programa no compilará, avisando de que el atributo DNI es inaccesible debido a su visibilidad.

## Otras visibilidades
Además, `C#` ofrece otras visibilidades, como `protected`, aunque esta no la comentaremos aquí porque tiene más que ver con la herencia. Además, se pueden mezclar entre ellas, como es el caso de:
* `protected internal`: Se aplica la visibilidad `internal`, salvo que si una clase hereda de esta, podrá ver los miembros que sean `protected internal`, incluso si está en otro fichero.
