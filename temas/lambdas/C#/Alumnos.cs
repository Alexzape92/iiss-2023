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