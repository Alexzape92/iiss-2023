using System;
using System.Threading;

public class Asincrono{

    public string ObtenerDatosAsincronos(){
        Thread.Sleep(5000);
        return "Datos obtenidos";
    }

    public static void Main(){
        var asincrono = new Asincrono();
        var datos = asincrono.ObtenerDatosAsincronos();
        Console.WriteLine("Obteniendo datos...");

        Console.WriteLine(datos);
    }
}