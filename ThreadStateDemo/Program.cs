﻿namespace ThreadStateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Creating and initializing threads Unstarted state
                Thread thread1 = new Thread(SomeMethod);
                Console.WriteLine($"Before Start, IsAlive: {thread1.IsAlive}, ThreadState: {thread1.ThreadState}");

                //Running State
                thread1.Start();
                Console.WriteLine($"After Start(), IsAlive: {thread1.IsAlive}, ThreadState: {thread1.ThreadState}");

                // thread1 is in suspended state
                thread1.Suspend();
                Console.WriteLine($"After Suspend(), IsAlive: {thread1.IsAlive}, ThreadState: {thread1.ThreadState}");

                //thread1 is resume to running state
                thread1.Resume();
                Console.WriteLine($"After Suspend(), IsAlive: {thread1.IsAlive}, ThreadState: {thread1.ThreadState}");

                // thread1 is in Abort stae
                // in this case, it will start the termination, IsAlive still gives you as true
                thread1.Abort();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }

            Console.ReadKey();
        }
        public static void SomeMethod()
        {
            for (int x = 0; x < 3; x++)
            {
                Thread.Sleep(1000);
            }
            Console.WriteLine("SomeMethod Completed...");
        }
    }
}