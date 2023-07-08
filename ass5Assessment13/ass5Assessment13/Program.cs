using System;
using System.Collections.Generic;
using System.Linq;

public static class EnumerableExtensions
{
    public static bool CustomAll<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if (!predicate(item))
                return false;
        }
        return true;
    }

    public static bool CustomAny<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
                return true;
        }
        return false;
    }

    public static T CustomMax<T>(this IEnumerable<T> source, Func<T, IComparable> selector)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (selector == null)
            throw new ArgumentNullException(nameof(selector));

        bool found = false;
        T max = default(T);

        foreach (T item in source)
        {
            if (!found || selector(item).CompareTo(selector(max)) > 0)
            {
                max = item;
                found = true;
            }
        }

        if (!found)
            throw new InvalidOperationException("Sequence contains no elements.");

        return max;
    }

    public static T CustomMin<T>(this IEnumerable<T> source, Func<T, IComparable> selector)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (selector == null)
            throw new ArgumentNullException(nameof(selector));

        bool found = false;
        T min = default(T);

        foreach (T item in source)
        {
            if (!found || selector(item).CompareTo(selector(min)) < 0)
            {
                min = item;
                found = true;
            }
        }

        if (!found)
            throw new InvalidOperationException("Sequence contains no elements.");

        return min;
    }

    public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));

        foreach (T item in source)
        {
            if (predicate(item))
                yield return item;
        }
    }

    public static IEnumerable<TResult> CustomSelect<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (selector == null)
            throw new ArgumentNullException(nameof(selector));

        foreach (T item in source)
        {
            yield return selector(item);
        }
    }
}



class Program
    {
        static void Main()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            bool allEven = numbers.CustomAll(x => x % 2 == 0);
            bool anyOdd = numbers.CustomAny(x => x % 2 != 0);
            int maxNumber = numbers.CustomMax(x => x);
            int minNumber = numbers.CustomMin(x => x);
            var evenNumbers = numbers.CustomWhere(x => x % 2 == 0);
            var squaredNumbers = numbers.CustomSelect(x => x * x);

        }
}

