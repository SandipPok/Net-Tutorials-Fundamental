using System.Diagnostics;

namespace Ex4_LimitConcurrentTask.Methods
{
    class MethodImplementation
    {
        static SemaphoreSlim SemaphoreSlim = new SemaphoreSlim(5);
        public static async void ProssCreditCards(List<CreditCard> creditCards)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var tasks = new List<Task<string>>();

            //await Task.Run(() =>
            //{
            //    foreach (var creditCard in creditCards)
            //    {
            //        var response = ProcessCard(creditCard);
            //        tasks.Add(response);
            //    }
            //});

            tasks = creditCards.Select(async card =>
            {
                await SemaphoreSlim.WaitAsync();
                try
                {
                    return await ProcessCard(card);
                }
                finally
                {
                    SemaphoreSlim.Release();
                }
            }).ToList();

            string[] res = await Task.WhenAll(tasks);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            stopwatch.Stop();
            Console.WriteLine($"Processing of {creditCards.Count} Credit Cards Done in {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
        }

        private async static Task<string> ProcessCard(CreditCard creditCard)
        {
            await Task.Delay(1000);
            string message = $"Credit Card Number: {creditCard.CardNumber} Name: {creditCard.Name} Processed";
            //Console.WriteLine($"Credit Card Number: {creditCard.CardNumber} Processed");
            return message;
        }
    }
}
