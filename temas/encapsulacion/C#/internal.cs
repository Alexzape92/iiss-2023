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