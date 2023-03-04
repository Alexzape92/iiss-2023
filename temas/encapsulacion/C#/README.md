# Ejemplo de Encapsulación C#
## Visibilidades Public y Private
Estas visibilidades son bien conocidas, igual que en el resto de lenguajes. En este ejemplo se busca demostrar que establecer los atributos de la clase a `public` no es buena idea. Si lo hacemos así, perdemos el control sobre qué posibles valores serán asignados a dicho atributo. Así podemos comprobar que la opción más correcta es tener al atributo como `private` y crear métodos públicos para editarlos, en los que podemos controlar los valores.

```csharp
using System;

class StudentPu{
    public string DNI = "12345678S";

    public void dni(){
        Console.WriteLine(DNI);
    }
}

class StudentPr{
    private string DNI = "12345678S";

    public void editDni(string mydni){
        if(mydni.Length != 9)
            Console.WriteLine("El DNI tiene que tener 9 caracteres");
        else
            DNI = mydni;
    }

    public void dni(){
        Console.WriteLine(DNI);
    }
}

class myMain{
    public static void Main(string[] args){
        StudentPu st1 = new StudentPu();
        StudentPr st2 = new StudentPr();

        st1.DNI = "estoestamal";
        st1.dni();

        st2.editDni("estoestamal");
        st2.dni();
    }
}
```
## Visibilidad Internal
Esta visibilidad es exlusiva de `C#`, y se asemeja bastante a la visivilidad de paquete de `Java`. Si la establecemos para un atributo, solo las clases que estén en el mismo "Assembly", que sería en el mismo fichero, podrán verlo. Esto se puede ver en el siguiente ejemplo:

```csharp
//internal.cs
using System;

class StudentI{
    internal string DNI = "12345678S";

    public void dni(){
        Console.WriteLine(DNI);
    }
}

internal class myMain2{
    public static void Main(string[] args){
        StudentI st = new StudentI();

        st.DNI = "12123222F";
        st.dni();
    }
}

//public_private.cs
using System;

...

class myMain{
    public static void Main(string[] args){
        StudentPu st1 = new StudentPu();
        StudentPr st2 = new StudentPr();
        StudentI st3 = new StudentI();

        st1.DNI = "estoestamal";
        st1.dni();

        st2.editDni("estoestamal");
        st2.dni();

        st3.DNI = "12312323F";
        st3.DNI();
    }
}
```
Si ejecutamos el primer Main, funcionará correctamente y editaremos el atributo correspondiente. Sin embargo, si ejecutamos el segundo, que está en diferente fichero, obtendremos el siguiente error de compilación:

    public_private.cs(39,13): error CS0122: 

    `StudentI.DNI' is inaccessible due to its protection level
    public_private.cs(39,13): error CS1955: The member `StudentI.DNI' cannot be used as method or delegate

    Compilation failed: 2 error(s), 0 warnings

## Otras visibilidades
Además, `C#` ofrece otras visibilidades, como `protected`, aunque esta no la comentaremos aquí porque tiene más que ver con la herencia. Además, se pueden mezclar entre ellas, como es el caso de:
* `protected internal`: Se aplica la visibilidad `internal`, salvo que si una clase hereda de esta, podrá ver los miembros que sean `protected internal`, incluso si está en otro fichero.
