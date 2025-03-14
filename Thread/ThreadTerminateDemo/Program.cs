﻿namespace ThreadStateDemo
{
    public class Program
    {
        //static void Main(string[] args)
        //{
        //    //Creating an object Thread class
        //    Thread thread = new Thread(SomeMethod)
        //    {
        //        Name = "My Thread1"
        //    };
        //    thread.Start();
        //    //Making the main Thread sleep for 1 second
        //    //Giving the child thread enough time to start its execution
        //    Thread.Sleep(1000);
        //    //Calling the Abort() on thread object
        //    //This will abort the new thread and throw ThreadAbortException in it
        //    thread.Abort();
        //    Console.ReadKey();
        //}
        //public static void SomeMethod()
        //{
        //    try
        //    {
        //        Console.WriteLine($"{Thread.CurrentThread.Name} Has Started its Execution");
        //        for (int i = 0; i < 3; i++)
        //        {
        //            Console.WriteLine($"{Thread.CurrentThread.Name} is printing {i}");
        //            //Calling the Sleep() method to make it sleep and 
        //            //suspend for 2 seconds after printing a number
        //            Thread.Sleep(1000);
        //        }
        //        Console.WriteLine($"{Thread.CurrentThread.Name} Has Finished its Execution");
        //    }
        //    catch (ThreadAbortException e)
        //    {
        //        Console.WriteLine($"ThreadAbortException Occurred, Message : {e.Message}");
        //    }
        //}

        static async Task Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            Task task = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Task cancellation completed.");
                        break;
                    }
                    Console.WriteLine($"Task running.... {i}");
                    Thread.Sleep(500);
                }
            }, token);

            // Cancel after 3 seconds
            await Task.Delay(3000);
            cts.Cancel();

            await task; // Wait for the task to complete
            Console.WriteLine("Main thread completed.");

            Console.ReadKey();
        }
    }
}