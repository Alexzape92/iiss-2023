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