namespace SemaphoreSlimDemo
{
    //class Program
    //{
    //    //only 3 threads can access resource simulteneously
    //    static SemaphoreSlim Semaphore = new SemaphoreSlim(3);

    //    static void Main(string[] args)
    //    {
    //        for (int i = 1; i <= 5; i++)
    //        {
    //            int count = i;
    //            Thread t = new Thread(() => SemaphoreSlimFunction("Thread " + count, 1000 * count));
    //            t.Name = "Thread " + count;
    //            t.Start();
    //        }
    //        Console.ReadLine();
    //    }

    //    static void SemaphoreSlimFunction(string name, int seconds)
    //    {
    //        Console.WriteLine($"{name} waits to access resource");
    //        Semaphore.Wait();
    //        Console.WriteLine($"{name} was granted access to resource");

    //        Thread.Sleep(seconds);
    //        Console.WriteLine($"{name} is completed");
    //        Semaphore.Release();
    //    }
    //}

    class Example
    {
        //Create the semaphore
        private static SemaphoreSlim Semaphore = new SemaphoreSlim(0, 3);

        //A padding interval to make the output more orderly.
        private static int Padding;

        public static void Main(string[] args)
        {
            Console.WriteLine($"{Semaphore.CurrentCount} tasks can enter the semaphore");
            Task[] tasks = new Task[5];

            //Create and start five numbered tasks.
            for (int i = 0; i <= 4; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    //Each task begins by requesting the semaphore.
                    Console.WriteLine($"Task {Task.CurrentId} begins and waits for the semaphore");
                    int semaphoreCount;
                    Semaphore.Wait();
                    try
                    {
                        Interlocked.Add(ref Padding, 100);
                        Console.WriteLine($"Task {Task.CurrentId} enters the semaphore");

                        //The task just sleeps for 1+ seconds.
                        Thread.Sleep(1000 + Padding);
                    }
                    finally
                    {
                        semaphoreCount = Semaphore.Release();
                    }
                    Console.WriteLine($"Task {Task.CurrentId} releases the semaphore; previous count: {semaphoreCount}");
                });
            }

            //Wait for one second, to allow all the tasks to start and block.
            Thread.Sleep(1000);

            //Restore the semaphore count to its maximum value.
            Console.Write("Main thread calls Release(3 --> ");
            Semaphore.Release(3);
            Console.WriteLine($"{Semaphore.CurrentCount} tasks can enter the semaphore");

            //Main thread waits for the tasks to complete.
            Task.WaitAll(tasks);

            Console.WriteLine("Main thread Exists");
            Console.ReadKey();
        }
    }
}