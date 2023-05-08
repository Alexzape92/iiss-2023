# Ejemplo de asíncrono
## Compilación y ejecución
Para compilar el programa, se pueden ejecutar:

    mcs SinAsincrono.cs
    mcs Asincrono.cs
Y para ejecutarlo:

    mono SinAsincrono.exe
    mono Asincrono.exe
## Ejemplo
En este ejemplo, se realiza una comparación entre un código asíncrono y otro no asíncrono. Veremos primero el normal:

[SinAsincrono.cs](SinAsincrono.cs)
```csharp
using System;
using System.Threading;

public class SinAsincrono{

    public string ObtenerDatos(){
        Thread.Sleep(5000);
        return "Datos obtenidos";
    }

    public static void Main(){
        var asincrono = new SinAsincrono();
        var datos = asincrono.ObtenerDatos();
        Console.WriteLine("Obteniendo datos...");

        Console.WriteLine(datos);
    }
}
```

Al ejecutarlo, el programa se quedará bloqueado 5 segundos, que es lo que tarda en ejecutarse el método `ObtenerDatos()`. Esto es un problema, ya que si el método tarda mucho en ejecutarse, el programa se quedará bloqueado durante ese tiempo. Se propone la siguiente solución:

[Asincrono.cs](Asincrono.cs)
```csharp
using System;
using System.Threading.Tasks;
using System.Threading;

public class Asincrono{

    public async Task<string> ObtenerDatosAsincronos(){
        return await Task.Run(() => {
            Thread.Sleep(5000);
            return "Datos obtenidos";
        });
    }

    public static void Main(){
        var asincrono = new Asincrono();
        var datos = asincrono.ObtenerDatosAsincronos();
        Console.WriteLine("Obteniendo datos...");

        Console.WriteLine(datos.Result);
    }
}
```
En este caso, se usan `async` y `await`. De esta manera, el método `ObtenerDatosAsincronos()` se ejecuta en un hilo aparte, y el programa no se bloquea. El método `Main()` se ejecuta en el hilo principal, y cuando se llama al método `ObtenerDatosAsincronos()`, se crea un hilo aparte para ejecutarlo. Mientras tanto, el hilo principal sigue ejecutando el resto del código. Cuando el método `ObtenerDatosAsincronos()` termina, el hilo principal sigue ejecutando el resto del código, y cuando se llama a `datos.Result`, el hilo principal se bloquea hasta que el hilo secundario termina de ejecutarse. Si se ejecuta el programa, se puede ver que el mensaje "Obteniendo datos..." se muestra antes de que se muestren los datos, lo que indica que el programa no se bloquea.
