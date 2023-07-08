using System;

public static class IntExtensions
{
    public static bool IsOdd(this int number)
    {
        return number % 2 != 0;
    }

    public static bool IsEven(this int number)
    {
        return number % 2 == 0;
    }

    public static bool IsPrime(this int number)
    {
        if (number < 2)
            return false;

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
                return false;
        }

        return true;
    }

    public static bool IsDivisibleBy(this int number, int divisor)
    {
        if (divisor == 0)
            throw new ArgumentException("Divisor cannot be zero.");

        return number % divisor == 0;
    }
}

class Program
{
    static void Main()
    {
        int number = 17;

        bool isOdd = number.IsOdd();  // true
        bool isEven = number.IsEven();  // false
        bool isPrime = number.IsPrime();  // true
        bool isDivisibleBy3 = number.IsDivisibleBy(3);  // false

        Console.WriteLine($"Is Odd: {isOdd}");
        Console.WriteLine($"Is Even: {isEven}");
        Console.WriteLine($"Is Prime: {isPrime}");
        Console.WriteLine($"Is Divisible by 3: {isDivisibleBy3}");
    }
}
