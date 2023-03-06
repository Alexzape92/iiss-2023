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