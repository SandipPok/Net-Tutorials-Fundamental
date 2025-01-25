using System.Diagnostics;

namespace ThreadPoolDemo
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        for (int i = 0; i < 10; i++)
    //        {
    //            System.Threading.ThreadPool.QueueUserWorkItem(new WaitCallback(MyMethod));
    //        }
    //        Console.Read();
    //    }

    //    public static void MyMethod(object obje)
    //    {
    //        Thread thread = Thread.CurrentThread;
    //        string message = $"Background: {thread.IsBackground}, Thread Pool: {thread.IsThreadPoolThread}, Thread ID: {thread.ManagedThreadId}";
    //        Console.WriteLine(message);
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            //Warmup Code start
            for (int i = 0; i < 10; i++)
            {
                MethodWithThread();
                MethodWithThreadPool();
            }

            //Warmup Code start
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Exection using Thread");
            stopwatch.Start();
            MethodWithThread();
            stopwatch.Stop();
            Console.WriteLine("Time consumed by MethodWithThread is: " + stopwatch.ElapsedTicks.ToString());

            stopwatch.Reset();

            Console.WriteLine("Exection using thread pool");
            stopwatch.Start();
            MethodWithThreadPool();
            stopwatch.Stop();
            Console.WriteLine("Time consumed by MethodWithThreadPool is: " + stopwatch.ElapsedTicks.ToString());

            Console.Read();
        }

        public static void MethodWithThread()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(Test);
                thread.Start();
            }
        }
        public static void MethodWithThreadPool()
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Test));
            }
        }
        public static void Test(object obj)
        {
        }
    }
}