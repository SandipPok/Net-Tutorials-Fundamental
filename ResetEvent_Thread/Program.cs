namespace ResetEvent
{
    //class Program
    //{
    //    static AutoResetEvent AutoResetEvent = new AutoResetEvent(false);
    //    static ManualResetEvent ManualResetEvent = new ManualResetEvent(false);
    //    static void Main(string[] args)
    //    {
    //        Thread newThread = new Thread(SomeMethod)
    //        {
    //            Name = "New Thread"
    //        };
    //        newThread.Start(); //It will invoke the SomeMethod in a different thread

    //        //To See how the SomeMethod goes in halt mode
    //        //Once we enter any key it will call set method and the SomeMethod will Resume its work

    //        Console.ReadLine();

    //        //It will send a signal to other threads to resume their work
    //        //AutoResetEvent.Set();

    //        ManualResetEvent.Set();
    //    }
    //    static void SomeMethod()
    //    {
    //        Console.WriteLine("Starting............");
    //        //Put the current thread into waiting state until it receives the signal

    //        //AutoResetEvent.WaitOne(); //It will make the thread in halt mode

    //        ManualResetEvent.WaitOne();

    //        Console.WriteLine("Finishing........");
    //        Console.ReadLine(); //To see the output in the console
    //    }
    //}

    class Program
    {
        static AutoResetEvent ManualResetEvent = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Thread newThread = new Thread(SomeMethod)
            {
                Name = "NewThread"
            };
            newThread.Start(); //It will invoke the SomeMethod in a different thread
            //To See how the SomeMethod goes in halt state let sleep the main thread for 3 secs
            Thread.Sleep(3000);
            Console.WriteLine("Releasing the WaitOne 1 by Set 1");
            ManualResetEvent.Set(); //Set 1 will relase the Wait 1
            //To See how the SomeMethod goes in halt state let sleep the main thread for 3 secs
            Thread.Sleep(5000);
            Console.WriteLine("Releasing the WaitOne 2 by Set 2");
            ManualResetEvent.Set(); //Set 2 will relase the Wait 2
            Console.ReadKey();
        }
        static void SomeMethod()
        {
            Console.WriteLine("Starting 1........");
            ManualResetEvent.WaitOne(); //Wait 1
            Console.WriteLine("Finishing 1........");
            Console.WriteLine();
            Console.WriteLine("Starting 2........");
            ManualResetEvent.WaitOne(); //Wait 2
            Console.WriteLine("Finishing 2........");
        }
    }
}