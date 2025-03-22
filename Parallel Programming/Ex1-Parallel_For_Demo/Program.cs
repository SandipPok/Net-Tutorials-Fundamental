namespace Ex1_Parallel_For_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
        LOOP:
            Console.WriteLine(@"1. Demo for Simple and Parallel For Loop
2. ParallelOptions Demo in Parallel For Loop
3. Terminating a Parallel For Loop Demo");

            Console.Write("Enter your choice: ");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    int num = 10;
                    SimpleLoop(num);
                    ParallelLoop(num);
                    break;
                case 2:
                    DemoParallelOptions();
                    break;
                case 3:
                    TerminateParallelLoop();
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

        static void SimpleLoop(int num)
        {
            Console.WriteLine("C# For Loop");
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"Value of i = {i}, thread = {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(10);
            }
            Console.WriteLine();
        }
        static void ParallelLoop(int num)
        {
            Console.WriteLine("Parallel for Loop");
            Parallel.For(0, num, i =>
            {
                Console.WriteLine($"Value of i = {i}, thread = {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(10);
            });
            Console.WriteLine();
        }

        static void DemoParallelOptions()
        {
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 2;
            Console.WriteLine("Parallel for Loop with ParallelOptions");
            Parallel.For(0, 10, options, i =>
            {
                Console.WriteLine($"Value of i = {i}, thread = {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(10);
            });
            Console.WriteLine();
        }

        static void TerminateParallelLoop()
        {
            var breakSource = Enumerable.Range(0, 1000).ToList();
            int breakData = 0;
            Console.WriteLine("Using loopstate break method");
            Parallel.For(0, breakSource.Count, (i, loopState) =>
            {
                breakData += i;
                if (breakData > 100)
                {
                    loopState.Break();
                    Console.WriteLine("Break called iteration {0}. data = {1} ", i, breakData);
                }
            });
            Console.WriteLine("Break called data = {0} ", breakData);

            var stopSource = Enumerable.Range(0, 1000).ToList();
            int stopData = 0;
            Console.WriteLine("Using loopstate Stop Method");
            Parallel.For(0, stopSource.Count, (i, loopState) =>
            {
                stopData += i;
                if (stopData > 100)
                {
                    loopState.Stop();
                    Console.WriteLine("Stop called iteration {0}. data = {1} ", i, stopData);
                }
            });
            Console.WriteLine("Stop called data = {0} ", stopData);
        }
    }
}