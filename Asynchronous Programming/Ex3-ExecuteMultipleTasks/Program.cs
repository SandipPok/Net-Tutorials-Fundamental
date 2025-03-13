using Ex3_ExecuteMultipleTasks.Methods;
using System.Diagnostics;

namespace ExecuteMultipleTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"1. Run Method using WhenAll()
2. Run Method without using WhenAll()
3. Run Method using Task.Run()");
            Console.Write("Select the option: ");
            int.TryParse(Console.ReadLine(), out int res);
            Console.WriteLine("\n");

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"Main Thread Started");

            List<CreditCard> creditCards = CreditCard.GenerateCreditCards(10);
            Console.WriteLine($"Credit Card Generated: {creditCards.Count}");

            switch (res)
            {
                case 1:
                    Method.ProcessCreditCards(creditCards);
                    break;
                case 2:
                    Method.ProcessCreditCardsSync(creditCards);
                    break;
                case 3:
                    Method.ProcessCreditCardsTaskRun(creditCards);
                    break;
                default:
                    break;
            }

            Console.WriteLine($"Main Thread Completed");
            stopwatch.Stop();
            Console.WriteLine($"Main Thread Execution Time {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
            Console.ReadKey();
        }
    }
}