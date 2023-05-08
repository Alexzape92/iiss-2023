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