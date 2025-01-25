using System.Xml.Linq;

namespace MonitorDemo
{
    class Program
    {
        private static readonly object LOCK_PRINT_NUMBERS = new object();
        public static void PrintNumbers()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " Trying to enter int the critical section");

            try
            {
                Monitor.Enter(LOCK_PRINT_NUMBERS);
                Console.WriteLine(Thread.CurrentThread.Name + " Entered into the critical section");
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(100);
                    Console.Write(i + ",");
                }
                Console.WriteLine();
            }
            finally
            {
                Monitor.Exit(LOCK_PRINT_NUMBERS);
                Console.WriteLine(Thread.CurrentThread.Name + " Exit from critical section");
            }
        }

        public static void PrintNumbersWithOverloadedParams()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " Trying to enter int the critical section");
            bool IsLockTaken = false;

            try
            {
                Monitor.Enter(LOCK_PRINT_NUMBERS, ref IsLockTaken);

                if (IsLockTaken)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " Entered into the critical section");
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(100);
                        Console.Write(i + ",");
                    }
                }
                Console.WriteLine();
            }
            finally
            {
                if (IsLockTaken)
                {
                    Monitor.Exit(LOCK_PRINT_NUMBERS);
                    Console.WriteLine(Thread.CurrentThread.Name + " Exit from critical section");
                }
            }
        }

        public static void PrintNumbersWithTryEnter()
        {
            TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
            bool lockTaken = false;

            try
            {
                Console.WriteLine(Thread.CurrentThread.Name + " Trying to enter int the critical section");
                Monitor.TryEnter(LOCK_PRINT_NUMBERS, timeout, ref lockTaken);
                if (lockTaken)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " Entered into the critical section");
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(100);
                        Console.Write(i + ",");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " Lock was not acquired");
                }
            }
            finally
            {
                if (lockTaken)
                {
                    Monitor.Exit(LOCK_PRINT_NUMBERS);
                    Console.WriteLine(Thread.CurrentThread.Name + " Exit from critical section");
                }
            }
        }

        static void Main(string[] args)
        {
            Thread[] Threads = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                // Enter Demo
                //Threads[i] = new Thread(PrintNumbers)
                //{
                //    Name = "Child Thread " + i
                //};

                // Enter with parameterize demo
                //Threads[i] = new Thread(PrintNumbersWithOverloadedParams)
                //{
                //    Name = "Child Thread " + i
                //};

                // Try Enter Demo
                Threads[i] = new Thread(PrintNumbersWithTryEnter)
                {
                    Name = "Child Thread " + i
                };
            }

            foreach (Thread t in Threads)
            {
                t.Start();
            }
            Console.ReadLine();
        }
    }
}