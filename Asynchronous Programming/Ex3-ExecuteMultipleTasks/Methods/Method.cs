using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3_ExecuteMultipleTasks.Methods
{
    class Method
    {
        public static async void ProcessCreditCards(List<CreditCard> creditCards)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var tasks = new List<Task<string>>();

            foreach (var creditCard in creditCards)
            {
                var response = ProcessCard(creditCard);
                tasks.Add(response);
            }

            await Task.WhenAll(tasks);
            stopwatch.Stop();
            Console.WriteLine($"Processing of {creditCards.Count} Credit Cards Done in {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
        }
        public static async void ProcessCreditCardsSync(List<CreditCard> creditCards)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var creditCard in creditCards)
            {
                var response = await ProcessCard(creditCard);
            }

            stopwatch.Stop();
            Console.WriteLine($"Processing of {creditCards.Count} Credit Cards Done in {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
        }

        public static async void ProcessCreditCardsTaskRun(List<CreditCard> creditCards)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var tasks = new List<Task<string>>();

            await Task.Run(() =>
            {
                foreach (var creditCard in creditCards)
                {
                    var response = ProcessCard(creditCard);
                    tasks.Add(response);
                }
            });

            await Task.WhenAll(tasks);
            stopwatch.Stop();
            Console.WriteLine($"Processing of {creditCards.Count} Credit Cards Done in {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
        }

        public static async Task<string> ProcessCard(CreditCard creditCard)
        {
            await Task.Delay(1000);
            string message = $"Credit Card Number: {creditCard.CardNumber} Name: {creditCard.Name} Processed";
            Console.WriteLine($"Credit Card Number: {creditCard.CardNumber} Processed");
            return message;
        }
    }
}
