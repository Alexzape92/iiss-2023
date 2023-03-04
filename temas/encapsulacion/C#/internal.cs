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