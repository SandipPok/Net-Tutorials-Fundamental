using System.Threading;

namespace Thread_Join_Demo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread Started");

            Thread t1 = new Thread(Method1);
            Thread t2 = new Thread(Method2);
            Thread t3 = new Thread(Method3);

            t1.Start();
            t2.Start();
            t3.Start();

            #region Is Alive Example
            if (t2.IsAlive)  // Returns true is the thread is still running or return false
            {
                Console.WriteLine("Thread 2 is still executing");
            }
            #endregion

            #region Thread Example With Parameter Overloading
            if (t2.Join(TimeSpan.FromSeconds(3)))
            {
                Console.WriteLine("Thread 2 Execution Completed in 3 second");
            }
            else
            {
                Console.WriteLine("Thread 2 Execution Not Completed in 3 second");
            }

            //Now, Main Thread will block for 3 seconds and wait thread3 to complete its execution
            if (t3.Join(3000))
            {
                Console.WriteLine("Thread 3 Execution Completed in 3 second");
            }
            else
            {
                Console.WriteLine("Thread 3 Execution Not Completed in 3 second");
            }
            #endregion

            #region Thread Join Example
            //t1.Join(); //Block Main Thread until thread1 completes its execution
            //t2.Join(); //Block Main Thread until thread2 completes its execution
            //t3.Join(); //Block Main Thread until thread3 completes its execution
            #endregion

            Console.WriteLine("Main Thread Ended");
            Console.Read();
        }

        public static void Method1()
        {
            Console.WriteLine("Method 1: Thread 1 Started");
            Thread.Sleep(3000);
            Console.WriteLine("Method 1: Thread 1 Ended");
        }
        public static void Method2()
        {
            Console.WriteLine("Method 2: Thread 2 Started");
            Thread.Sleep(2000);
            Console.WriteLine("Method 2: Thread 2 Ended");
        }
        public static void Method3()
        {
            Console.WriteLine("Method 3: Thread 3 Started");
            Thread.Sleep(5000);
            Console.WriteLine("Method 3: Thread 3 Ended");
        }
    }
}