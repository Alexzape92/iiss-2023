using System;

public class invalidNullExample{
    private static void invalidNullAssignment(){
        int number = null;
        System.Console.WriteLine(number);
    }

    public static void Main(string[] args){
        invalidNullAssignment();
    }
}