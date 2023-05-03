using System;

public class NullExample{
    /*private static void invalidNullAssignment(){
        int number = null;
        System.Console.WriteLine(number);
    }*/

    private static void validNullAssignment(){
        int? number = null;
        System.Console.WriteLine(number);
    }

    private static void nullableType(){
        Nullable<int> number1 = null, number2 = 10;
        if(number1.HasValue)
            System.Console.WriteLine(number1.Value);
        else
            System.Console.WriteLine("number1 is null");
        
        if(number2.HasValue)
            System.Console.WriteLine(number2.Value);
        else
            System.Console.WriteLine("number2 is null");
    }

    private static void nullCollation(){
        int? number1 = null;
        int? number2 = 10;
        
        //This should print 5
        System.Console.WriteLine(number1 ?? 5);
        //This should print 10
        System.Console.WriteLine(number2 ?? 5);
    }

    public static void Main(string[] args){
        //invalidNullAssignment();
        validNullAssignment();
        nullableType();
        nullCollation();
    }
}