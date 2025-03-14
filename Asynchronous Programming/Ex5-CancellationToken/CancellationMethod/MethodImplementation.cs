using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex5_CancellationToken.CancellationMethod
{
    class MethodImplementation
    {
        public static async void SomeMethod()
        {
            int count = 10;
            Console.WriteLine("Some method started");

            CancellationTokenSource cts = new CancellationTokenSource(5000);
            //cts.CancelAfter(5000);

            try
            {
                await LongRunningTask(count, cts.Token);
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            Console.WriteLine("\nSomeMethod Method Completed");
        }

        private static async Task LongRunningTask(int count, System.Threading.CancellationToken token)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("\nLongRunningTask Started");

            for (int i = 0; i <= count; i++)
            {
                await Task.Delay(1000);
                Console.WriteLine("LongRunningTask Processing....");
                if (token.IsCancellationRequested)
                {
                    throw new TaskCanceledException();
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"LongRunningTask Took {stopwatch.ElapsedMilliseconds / 1000.0} Seconds for Processing");
        }

        /// <summary>
        /// User initiated cancellation
        /// </summary>
        /// <returns></returns>
        public static async Task UserInitiatedCancellation()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            // Simulate user pressing a cancel button after 3 seconds
            await Task.Delay(3000).ContinueWith(_ => cts.Cancel());

            try
            {
                await Task.Run(async () =>
                {
                    if (cts.IsCancellationRequested)
                    {
                        return;
                    }

                    await Task.Delay(5000);  // Simulate long-running work
                    Console.WriteLine("LongRunningTask Processing...");
                }, cts.Token);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("The operation was canceled by the user.");
            }
        }


        /// <summary>
        /// Time Based Cancellation
        /// </summary>
        /// <returns></returns>
        public static async Task TimeBasedCancellation()
        {
            CancellationTokenSource cts = new CancellationTokenSource(5000);
            Timer timer = new Timer(_ => cts.Cancel(),
                                    null,
                                    TimeSpan.FromSeconds(5),
                                    Timeout.InfiniteTimeSpan);

            await Task.Run(() =>
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    Task.Delay(1000);
                    Console.WriteLine("LongRunningTask Processing...");
                }
            }, cts.Token);
        }

        /// <summary>
        /// Cooperative Cancellation
        /// </summary>
        /// <returns></returns>
        public static async Task CooperativeCancellation()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            Task task1 = Task.Run(async () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    cts.Token.ThrowIfCancellationRequested();

                    Console.WriteLine("Task 1 - Working...");
                    await Task.Delay(1000);  // Simulate work with async delay
                }
            }, cts.Token);

            Task task2 = Task.Run(async () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    cts.Token.ThrowIfCancellationRequested();

                    Console.WriteLine("Task 2 - Working...");
                    await Task.Delay(1000);  // Simulate work with async delay
                }
            }, cts.Token);

            // Simulate user canceling after 4 seconds
            await Task.Delay(4000).ContinueWith(_ => cts.Cancel());

            try
            {
                await Task.WhenAll(task1, task2);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("The operation was canceled cooperatively.");
            }
        }

        /// <summary>
        /// Run the api project in Ex2 before this method
        /// </summary>
        public static async Task IOOperationCancellation(string name)
        {
            Console.WriteLine("IO Operation Method Started");
            using (var client = new HttpClient())
            {
                CancellationTokenSource cts = new CancellationTokenSource(4000);

                client.BaseAddress = new Uri("http://localhost:5020");
                try
                {
                    Console.WriteLine("IO Operation Method calling web api");
                    HttpResponseMessage res = await client.GetAsync($"/greetings?name={name}", cts.Token);
                    string message = await res.Content.ReadAsStringAsync();
                    Console.WriteLine(message);
                }
                catch (TaskCanceledException ex)
                {
                    Console.WriteLine($"Task Execution Cancelled: {ex.Message}");
                }
                Console.WriteLine("Some Method Completed");
            }
        }
    }
}
