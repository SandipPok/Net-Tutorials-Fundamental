using System.Diagnostics;

namespace LimitConcurrentTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Main Thread Started");

            Console.WriteLine("Main Thread Completed");
            stopwatch.Stop();
            Console.WriteLine($"Main Thread Execution Time {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
            Console.ReadKey();
        }
    }
}