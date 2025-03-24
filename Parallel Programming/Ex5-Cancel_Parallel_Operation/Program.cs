using System.Diagnostics;

namespace Ex5_Cancel_Parallel_Operation
{
    class Program
    {
        static void Main(string[] args)
        {
        LOOP:
            Stopwatch sw = new Stopwatch();
            Console.WriteLine(@"1. Cancel Parallel Operations
2. Canceling Parallel Operation Example using Parallel Foreach Loop
3. Canceling Parallel Operation Execution Example using Parallel For Loop");

            Console.Write("Enter the option: ");
            int.TryParse(Console.ReadLine(), out int choice);

            // Cancellation Token Initialization
            var cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(5));

            var parallelOptions = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 2,
                CancellationToken = cts.Token
            };

            switch (choice)
            {
                case 1:
                    try
                    {
                        sw.Start();
                        Parallel.Invoke(
                            parallelOptions,
                            () => DoSomeTask(1),
                            () => DoSomeTask(2),
                            () => DoSomeTask(3),
                            () => DoSomeTask(4),
                            () => DoSomeTask(5),
                            () => DoSomeTask(6),
                            () => DoSomeTask(7)
                            );
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        sw.Stop();
                        Console.WriteLine($"Time Taken to Execute all the Methods : {sw.ElapsedMilliseconds / 1000.0} Seconds");
                        cts.Dispose();
                        cts = null;
                        sw.Reset();
                    }
                    break;
                case 2:
                    try
                    {
                        List<int> integerList = Enumerable.Range(0, 20).ToList();

                        Parallel.ForEach(integerList, parallelOptions, i =>
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"Value of i = {i}, thread = {Thread.CurrentThread.ManagedThreadId}");
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        cts.Dispose();
                        cts = null;
                    }
                    break;
                case 3:
                    try
                    {
                        Parallel.For(1, 21, parallelOptions, i =>
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(1));
                            Console.WriteLine($"Value of i = {i}, thread = {Thread.CurrentThread.ManagedThreadId}");
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        cts.Dispose();
                        cts = null;
                    }
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
        static void DoSomeTask(int number)
        {
            Console.WriteLine($"DoSomeTask {number} started by Thread {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine($"DoSomeTask {number} completed by Thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}