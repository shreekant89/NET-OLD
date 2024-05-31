using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var numbers = Enumerable.Range(1, 1000).ToList();
        // Add 100 duplicate numbers (for example, duplicates of the first 100 numbers)
        numbers.AddRange(Enumerable.Range(1, 100));

        // Shuffle the list to mix the numbers (optional, but makes it more realistic)
        var rng = new Random();
        numbers = numbers.OrderBy(x => rng.Next()).ToList();

        //numbers = new List<int> { 5, 1, 3, 3, 4, 6, 7, 8, 9, 10, 10, 6,20,19,18,17,17,15,16,12,11,13,14,12,21,98,22,97 };

        // Measure time for Distinct().OrderBy()
        var stopwatch = Stopwatch.StartNew();
        var distinctThenOrderBy = numbers.Distinct().OrderBy(x => x).ToList();
        stopwatch.Stop();
        var distinctThenOrderByTime = stopwatch.ElapsedTicks;

        // Measure time for OrderBy().Distinct()
        stopwatch.Restart();
        var orderByThenDistinct = numbers.OrderBy(x => x).Distinct().ToList();
        stopwatch.Stop();
        var orderByThenDistinctTime = stopwatch.ElapsedTicks;

        // Output results
        Console.WriteLine("if you have 28 recored then:--------------------------- ");
        Console.WriteLine("Distinct().OrderBy(): ");
        //distinctThenOrderBy.ForEach(n => Console.Write(n + " "));
        Console.WriteLine($"\nExecution time (ticks): {distinctThenOrderByTime}");
        Console.WriteLine("\nOrderBy().Distinct(): ");
        //orderByThenDistinct.ForEach(n => Console.Write(n + " "));
        Console.WriteLine($"\nExecution time (ticks): {orderByThenDistinctTime}");
        Console.ReadLine();
    }
}
