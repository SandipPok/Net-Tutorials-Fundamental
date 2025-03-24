using System.Diagnostics;

namespace Ex2_Parallel_ForEach_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
        LOOP:
            Console.WriteLine(@"1. Sequential forEach loop demo
2. Parallel forEach loop demo");

            Console.Write("Enter your choice: ");
            int.TryParse(Console.ReadLine(), out int choice);

            switch (choice)
            {
                case 1:
                    sw.Start();
                    List<int> list = Enumerable.Range(1, 10).ToList();

                    foreach (var i in list)
                    {
                        long total = DoSomeIndependentTimeConsumingTask();
                        Console.WriteLine("{0} - {1}", i, total);
                    }

                    Console.WriteLine("Standard Foreach Loop Ended");
                    sw.Stop();
                    Console.WriteLine($"Time Taken by Standard Foreach Loop in Milliseconds {sw.ElapsedMilliseconds}");
                    Console.WriteLine();
                    Console.WriteLine("Parallel Foreach Loop Started");
                    sw.Reset();
                    break;
                case 2:
                    sw.Start();
                    var options = new ParallelOptions
                    {
                        MaxDegreeOfParallelism = 2
                    };
                    List<int> integerList = Enumerable.Range(1, 10).ToList();
                    Parallel.ForEach(integerList, options, i =>
                    {
                        long total = DoSomeIndependentTimeConsumingTask();
                        Console.WriteLine("{0} - {1}, thread = {2}", i, total, Thread.CurrentThread.ManagedThreadId);
                    });
                    Console.WriteLine("Parallel Foreach Loop Ended");
                    sw.Stop();
                    Console.WriteLine($"Time Taken by Parallel Foreach Loop in Milliseconds {sw.ElapsedMilliseconds}");
                    sw.Reset();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.Write("Do you want to continue? (y/n): ");
            char.TryParse(Console.ReadLine(), out char c);
            if (c == 'y')
            {
                goto LOOP;
            }
        }

        static long DoSomeIndependentTimeConsumingTask()
        {
            long total = 0;
            for (int i = 1; i < 100000000; i++)
            {
                total += i;
            }
            return total;
        }
    }
}