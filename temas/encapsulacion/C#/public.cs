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