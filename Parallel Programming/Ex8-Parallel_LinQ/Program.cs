using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();
    LOOP:
        Console.WriteLine(@"1. Example to Understand Parallel LINQ
2. Maintain the Original Order in Parallel LINQ
3. Difference Between OrderBy and AsOrdered Method
4. Maximum Degree of Parallelism and Cancellation Token in Parallel LINQ
5. Doing Aggregates in Parallel LINQ
6. Parallel LINQ Improving the Performance of an Application Test Demo");

        Console.Write("Enter the option: ");
        int.TryParse(Console.ReadLine(), out int choice);

        switch (choice)
        {
            case 1:
                ParallelLinqDemo(sw);
                break;
            case 2:
                MaintainOrderInParallelLinq();
                break;
            case 3:
                DifferenceBetweenOrderByAndAsOrdered();
                break;
            case 4:
                MaximumDegreeOfParallelismAndCancellationToken();
                break;
            case 5:
                DoingAggregatesInParallelLinq();
                break;
            case 6:
                ParallelLinqImprovingPerformanceTest();
                break;
            default:
                Console.WriteLine("Invalid Choice");
                break;
        }
        Console.WriteLine("Do you want to continue? (y/n)");
        char.TryParse(Console.ReadLine(), out char res);

        if (res == 'y')
        {
            goto LOOP;
        }
    }
    /// <summary>
    /// Parallel LINQ Demo
    /// </summary>
    /// <param name="sw"></param>
    static void ParallelLinqDemo(Stopwatch sw)
    {
        Console.WriteLine("\nSequential LINQ");
        sw.Start();
        var numbers = Enumerable.Range(1, 20);
        var even = numbers.Where(x => x % 2 == 0).ToList();

        Console.WriteLine("Even Numbers Between 1 and 20");
        foreach (var number in even)
        {
            Console.WriteLine(number);
        }
        sw.Stop();
        Console.WriteLine("Sequential LINQ Time taken: {0} ms", sw.ElapsedMilliseconds);

        Console.WriteLine("\nParallel LINQ");
        sw.Restart();
        var evenParallel = numbers.AsParallel().Where(x => x % 2 == 0).ToList();
        Console.WriteLine("Even Numbers Between 1 and 20");
        foreach (var number in even)
        {
            Console.WriteLine(number);
        }
        sw.Stop();
        Console.WriteLine("Parallel LINQ Time taken: {0} ms", sw.ElapsedMilliseconds);
    }
    /// <summary>
    /// Maintain Order in Parallel LINQ
    /// </summary>
    static void MaintainOrderInParallelLinq()
    {
        var numbers = Enumerable.Range(1, 20);
        var even = numbers.AsParallel().AsOrdered().Where(x => x % 2 == 0).ToList();
        Console.WriteLine("Even Numbers Between 1 and 20");
        foreach (var number in even)
        {
            Console.WriteLine(number);
        }
    }
    /// <summary>
    /// Difference Between OrderBy and AsOrdered Method
    /// </summary>
    static void DifferenceBetweenOrderByAndAsOrdered()
    {
        List<int> numbers = new List<int>() { 1, 2, 6, 7, 5, 4, 10, 12, 13, 20, 18, 9, 11, 15, 14, 3, 8, 16, 17, 19 };
        
        var evenAsParallel = numbers.AsParallel()
                                    .Where(x => x % 2 == 0)
                                    .ToList();
        Console.WriteLine("Even Numbers Between 1 and 20");
        foreach (var number in evenAsParallel)
        {
            Console.WriteLine(number);
        }

        var evenOrderBy = numbers.AsParallel()
                                 .Where(x => x % 2 == 0)
                                 .OrderBy(x => x)
                                 .ToList();

        Console.WriteLine("\nEven Numbers Between 1 and 20 using OrderBy");
        foreach (var number in evenOrderBy)
        {
            Console.WriteLine(number);
        }
    }
    /// <summary>
    /// Maximum Degree of Parallelism and Cancellation Token in Parallel LINQ
    /// </summary>
    static void MaximumDegreeOfParallelismAndCancellationToken()
    {
        var cts = new CancellationTokenSource();
        cts.CancelAfter(2000);

        var numbers = Enumerable.Range(1, 20);

        var even = numbers.AsParallel()
                          .AsOrdered()
                          .WithDegreeOfParallelism(2)
                          .WithCancellation(cts.Token)
                          .Where(x => x % 2 == 0)
                          .ToList();

        Console.WriteLine("Even Numbers Between 1 and 20");
        foreach (var number in even)
        {
            Console.WriteLine(number);
        }
    }
    /// <summary>
    /// Doing Aggregates in Parallel LINQ
    /// </summary>
    static void DoingAggregatesInParallelLinq()
    {
        var numbers = Enumerable.Range(1, 10000);

        Console.WriteLine("\nSum, Min, Max and Average with LINQ");

        var sum = numbers.AsParallel().Sum();
        var min = numbers.AsParallel().Min();
        var max = numbers.AsParallel().Max();
        var avg = numbers.AsParallel().Average();
        Console.WriteLine($"Sum:{sum}\nMin: {min}\nMax: {max}\nAverage:{avg}\n");
    }
    /// <summary>
    /// Parallel LINQ Improving the Performance of an Application Test Demo
    /// </summary>
    static void ParallelLinqImprovingPerformanceTest()
    {
        var random = new Random();
        int[] values = Enumerable.Range(1, 99999999)
                                 .Select(x => random.Next(1, 1000))
                                 .ToArray();

        //Min, Max and Average LINQ extension methods
        Console.WriteLine("Min, Max and Average with LINQ");

        Stopwatch sw = new Stopwatch();
        sw.Start();

        var linqMin = values.Min();
        var linqMax = values.Max();
        var linqAvg = values.Average();
        sw.Stop();

        var linqTimeMS = sw.ElapsedMilliseconds;

        Console.WriteLine($"Min: {linqMin}\nMax: {linqMax}\nAverage: {linqAvg}\nTime taken: {linqTimeMS} ms");

        Console.WriteLine("\nMin, Max and Average with PLINQ");
        sw.Restart();
        var pLinqMin = values.AsParallel().Min();
        var pLinqMax = values.AsParallel().Max();
        var pLinqAverage = values.AsParallel().Average();
        sw.Stop();
        var pLinqTimeMS = sw.ElapsedMilliseconds;

        Console.WriteLine($"Min: {pLinqMin}\nMax: {pLinqMax}\nAverage: {pLinqAverage}\nTime taken: {pLinqTimeMS} ms");
    }   
}