using System.Diagnostics.Metrics;
using System.Threading;

namespace MutexDemo
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    using (Mutex mutex = new Mutex(false, "MutexDemo"))
        //    {
        //        //Checking if Other External Thread is Running
        //        if (!mutex.WaitOne(5000, false))
        //        {
        //            Console.WriteLine("An Instance of the Application is Already Running");
        //            Console.ReadKey();
        //            return;
        //        }
        //        Console.WriteLine("Application is running..................");
        //        Console.ReadKey();
        //    }
        //}

        private static Mutex Mutex = new Mutex();

        static void Main(string[] args)
        {
            //Create multiple threads to understand Mutex
            for (int i = 1; i <= 5; i++)
            {
                Thread threadObject = new Thread(MutexDemo)
                {
                    Name = "Thread " + i
                };
                threadObject.Start();
            }

            //If IsSingleInstance returns true continue with the Program else Exit the Program
            if (!IsSingleInstance())
            {
                Console.WriteLine("More than one instance"); // Exit program.
            }
            else
            {
                Console.WriteLine("One instance"); // Continue with program.
            }

            Console.ReadKey();
        }

        //Method to implement syncronization using Mutex  
        static void MutexDemo()
        {
            // Wait until it is safe to enter, and do not enter if the request times out.
            Console.WriteLine(Thread.CurrentThread.Name + " Wants to Enter Critical Section for processing");
            if (Mutex.WaitOne(1000))
            {
                try
                {
                    Console.WriteLine("Success: " + Thread.CurrentThread.Name + " is Processing now");
                    Thread.Sleep(2000);
                    Console.WriteLine("Exit: " + Thread.CurrentThread.Name + " is Completed its task");
                }
                finally
                {
                    //Call the ReleaseMutex method to unblock so that other threads
                    //that are trying to gain ownership of the mutex can enter  
                    Mutex.ReleaseMutex();
                    Console.WriteLine(Thread.CurrentThread.Name + " Has Released the mutex");
                }
            }
            else
            {
                Console.WriteLine(Thread.CurrentThread.Name + " will not acquire the mutex");
            }
        }

        static bool IsSingleInstance()
        {
            try
            {
                // Try to open Existing Mutex.
                //If MyMutex is not opened, then it will throw an exception
                Mutex.OpenExisting("MyMutex");
            }
            catch
            {
                // If exception occurred, there is no such mutex.
                Mutex = new Mutex(true, "MyMutex");
                // Only one instance.
                return true;
            }
            // More than one instance.
            return false;
        }

        ~Program()
        {
            Mutex.Dispose();
        }
    }
}