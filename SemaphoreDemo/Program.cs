namespace SemaphoreDemo
{
    //class Program
    //{
    //    public static Semaphore Semaphore { get; set; }
    //    static void Main(string[] args)
    //    {
    //        try
    //        {
    //            //Try to Open the Semaphore if Exists, if not throw an exception
    //            Semaphore = Semaphore.OpenExisting("SemaphoreDemo");
    //        }
    //        catch
    //        {
    //            //If Semaphore not Exists, create a semaphore instance
    //            //Here Maximum 2 external threads can access the code at the same time
    //            Semaphore = new Semaphore(2, 2, "SemaphoreDemo");
    //        }

    //        Console.WriteLine("External Thread Trying to Acquiring");
    //        Semaphore.WaitOne();
    //        //This section can be access by maximum two external threads: Start
    //        Console.WriteLine("External Thread Acquired");
    //        Console.ReadKey();
    //        //This section can be access by maximum two external threads: End

    //        Semaphore.Release();
    //    }
    //}

    class Program
    {
        public static Semaphore Semaphore = new Semaphore(2, 3);

        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                Thread threadObject = new Thread(DoSomeTask)
                {
                    Name = "Thread " + i
                };
                threadObject.Start();
            }
            Console.ReadKey();
        }

        static void DoSomeTask()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " Wants to Enter the Critical Section for processing");
            try
            {
                //Blocks the current thread until the current WaitHandle receives a signal.
                Semaphore.WaitOne();

                //Decrease the Initial Count Variable by 1
                Console.WriteLine("Success: " + Thread.CurrentThread.Name + " is Doing its work");
                Thread.Sleep(5000);
                Console.WriteLine(Thread.CurrentThread.Name + "Exit.");
            }
            finally
            {
                //Release() method to release semaphore  
                //Increase the Initial Count Variable by 1
                Semaphore.Release();
            }
        }
    }
}