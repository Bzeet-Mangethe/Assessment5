using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        // 1. Find odd - Lambda Expression – without curly brackets
        var oddNumbers = numbers.Where(num => num % 2 != 0);
        PrintList("Odd Numbers", oddNumbers);

        // 2. Find Even - Lambda Expression – with curly brackets
        var evenNumbers = numbers.Where(num =>
        {
            return num % 2 == 0;
        });
        PrintList("Even Numbers", evenNumbers);

        // 3. Find Prime – Anonymous Method
        var primeNumbers = numbers.Where(delegate (int num)
        {
            if (num < 2) return false;
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        });
        PrintList("Prime Numbers", primeNumbers);

        // 4. Find Prime Another – Lambda Expression
        var primeNumbersLambda = numbers.Where(num =>
        {
            if (num < 2) return false;
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        });
        PrintList("Prime Numbers (Lambda)", primeNumbersLambda);

        // 5. Find Elements Greater Than Five – Method Group Conversion Syntax
        var greaterThanFive = numbers.Where(GreaterThanFive);
        PrintList("Numbers Greater Than Five", greaterThanFive);

        // 6. Find Less than Five – Delegate Object in Where – Method Group Conversion Syntax in Constructor of Object
        var lessThanFive = numbers.Where(new Func<int, bool>(LessThanFive));
        PrintList("Numbers Less Than Five", lessThanFive);

        // 7. Find 3k – Delegate Object in Where – Lambda Expression in Constructor of Object
        var multipleOf3 = numbers.Where(new Func<int, bool>(num => num % 3 == 0));
        PrintList("Numbers Multiple of 3", multipleOf3);

        // 8. Find 3k + 1 - Delegate Object in Where –Anonymous Method in Constructor of Object
        var multipleOf3Plus1 = numbers.Where(new Func<int, bool>(delegate (int num)
        {
            return num % 3 == 1;
        }));
        PrintList("Numbers (3k + 1)", multipleOf3Plus1);

        // 9. Find 3k + 2 - Delegate Object in Where –Lambda Expression Assignment
        Func<int, bool> multipleOf3Plus2 = num => num % 3 == 2;
        var numbersMultipleOf3Plus2 = numbers.Where(multipleOf3Plus2);
        PrintList("Numbers (3k + 2)", numbersMultipleOf3Plus2);

        // 10. Find anything - Delegate Object in Where – Anonymous Method Assignment
        Func<int, bool> anyCondition = delegate (int num)
        {
            // Define any custom condition here
            return num % 5 == 0;
        };
        var anythingNumbers = numbers.Where(anyCondition);
        PrintList("Numbers (Any Condition)", anythingNumbers);

        // 11. Find anything - Delegate Object in Where – Method Group Conversion Assignment
        Func<int, bool> anyConditionMethod = IsEven;
        var anythingNumbersMethod = numbers.Where(anyConditionMethod);
        PrintList("Numbers (Any Condition using Method Group Conversion)", anythingNumbersMethod);
    }

    static bool GreaterThanFive(int num)
    {
        return num > 5;
    }

    static bool LessThanFive(int num)
    {
        return num < 5;
    }

    static bool IsEven(int num)
    {
        return num % 2 == 0;
    }

    static void PrintList(string title, IEnumerable<int> numbers)
    {
        Console.WriteLine(title + ":");
        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }
        Console.WriteLine();
    }
}
