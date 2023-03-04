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
        StudentI st3 = new StudentI();

        st1.DNI = "estoestamal";
        st1.dni();

        st2.editDni("estoestamal");
        st2.dni();

        st3.DNI = "12312323F";
        st3.DNI();
    }
}