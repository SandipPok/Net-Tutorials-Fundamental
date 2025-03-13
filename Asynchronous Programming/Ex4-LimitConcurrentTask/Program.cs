using Ex4_LimitConcurrentTask.Methods;
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

            List<CreditCard> creditCards = CreditCard.GenerateCreditCards(50);
            Console.WriteLine($"Credit Card Generated : {creditCards.Count}");

            MethodImplementation.ProssCreditCards(creditCards);

            Console.WriteLine("Main Thread Completed");
            stopwatch.Stop();
            Console.WriteLine($"Main Thread Execution Time {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
            Console.ReadKey();
        }
    }
}