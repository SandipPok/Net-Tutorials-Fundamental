namespace odd_even_sequence
{
    class Program
    {
        //Upto the limit numbers will be printed on the Console
        const int NUMBER_LIMIT = 20;

        static readonly object LOCK_MONITOR = new object();

        static void Main(string[] args)
        {
            Thread evenThread = new Thread(PrintEvenNumbers);
            Thread oddThread = new Thread(PrintOddNumbers);

            //First Start the Even thread.
            evenThread.Start();

            //Puase for 10 ms, to make sure Even thread has started 
            //or else Odd thread may start first resulting different sequence.
            Thread.Sleep(100);

            //Next, Start the Odd thread.
            oddThread.Start();

            //Wait for all the childs threads to complete
            oddThread.Join();
            evenThread.Join();

            Console.WriteLine("\nMain method completed");
            Console.ReadKey();
        }

        //Printing of Even Numbers Function
        static void PrintEvenNumbers()
        {
            try
            {
                //Implement lock as the Console is shared between two threads
                Monitor.Enter(LOCK_MONITOR);
                for (int i = 0; i <= NUMBER_LIMIT; i = i + 2)
                {
                    //Printing Event Number on Console
                    Console.Write($"{i} ");

                    //Notify Odd threadd that I'm done, you do your job
                    //It notifies a thread in the waiting queue of a change in the
                    //locked object's state.
                    Monitor.Pulse(LOCK_MONITOR);

                    //I will wait here till Odd thread notify me 
                    //Monitor.Wait(monitor);
                    //Without this logic application will wait forever

                    bool isLast = false;
                    if (i == NUMBER_LIMIT)
                    {
                        isLast = true;
                    }

                    if (!isLast)
                    {
                        //I will wait here till Odd thread notify me
                        //Releases the lock on an object and blocks the current thread 
                        //until it reacquires the lock.
                        Monitor.Wait(LOCK_MONITOR);
                    }
                }
            }
            finally
            {
                //Release the lock
                Monitor.Exit(LOCK_MONITOR);
            }
        }

        //Printing of Odd Numbers Function
        static void PrintOddNumbers()
        {
            try
            {
                Monitor.Enter(LOCK_MONITOR);
                for (int i = 1; i <= NUMBER_LIMIT; i = i + 2)
                {
                    //Printing the odd numbers on the console
                    Console.Write($"{i} ");

                    //Notify Even thread that I'm done, you do your job
                    Monitor.Pulse(LOCK_MONITOR);

                    // I will wait here till even thread notify me
                    // Monitor.Wait(monitor);
                    // without this logic application will wait forever

                    bool isLast = false;
                    if (i == NUMBER_LIMIT - 1)
                    {
                        isLast = true;
                    }

                    if (!isLast)
                    {
                        //I will wait here till Even thread notify me
                        Monitor.Wait(LOCK_MONITOR);
                    }
                }
            }
            finally
            {
                //Release the lock
                Monitor.Exit(LOCK_MONITOR);
            }
        }
    }
}