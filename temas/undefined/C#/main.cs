using System;

public class main{
    public static void Main(string[] args){
        /*int number = null;
        System.Console.WriteLine(number);*/

        int ?number1 = null;
        System.Console.WriteLine(number1);

        Nullable<int> number2 = null, number3 = 10;
        if(number2.HasValue)
            System.Console.WriteLine(number2.Value);
        else
            System.Console.WriteLine("number2 is null");
        
        int number4 = number2 ?? 5;
        System.Console.WriteLine(number4);

        int number5 = number3 ?? 5;
        System.Console.WriteLine(number5);
    }
}