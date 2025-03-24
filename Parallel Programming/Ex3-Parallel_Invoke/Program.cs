using System.Diagnostics;

namespace Ex3_Parallel_Invoke
{
    class Program
    {
        static void Main(string[] args)
        {
        LOOP:
            Stopwatch sw = new Stopwatch();
            Console.WriteLine(@"1. Sequential Execution Using forEach loop
2. Parallel Execution Using Parallel.ForEach loop
3. Invoke Different Types of Methods using Parallel.Invoke i.e. (delegate, lambda)
4. ParallelOptions Class with Parallel Invoke Method
5. Invoking Methods with Input and Return Type using Parallel.Invoke");

            Console.Write("Enter the option: ");
            int.TryParse(Console.ReadLine(), out int choice);

            switch (choice)
            {
                case 1:
                    sw.Start();
                    Method1();
                    Method2();
                    Method3();
                    sw.Stop();
                    Console.WriteLine($"Sequential Execution Took {sw.ElapsedMilliseconds} Milliseconds");
                    sw.Restart();
                    break;
                case 2:
                    sw.Start();
                    Parallel.Invoke(Method1, Method2, Method3);
                    sw.Stop();
                    Console.WriteLine($"Parallel Execution Took {sw.ElapsedMilliseconds} Milliseconds");
                    sw.Restart();
                    break;
                case 3:
                    Parallel.Invoke(
                        NormalAction,
                        delegate ()
                        {
                            Console.WriteLine($"Method 2, Thread={Thread.CurrentThread.ManagedThreadId}");
                        },
                        () =>
                        {
                            Console.WriteLine($"Method 3, Thread={Thread.CurrentThread.ManagedThreadId}");
                        });
                    break;
                case 4:
                    ParallelOptions options = new ParallelOptions()
                    {
                        MaxDegreeOfParallelism = 3,
                    };
                    Parallel.Invoke(
                        options,
                        () => DoSomeTask(1),
                        () => DoSomeTask(2),
                        () => DoSomeTask(3),
                        () => DoSomeTask(4),
                        () => DoSomeTask(5),
                        () => DoSomeTask(6),
                        () => DoSomeTask(7),
                        () => DoSomeTask(8));
                    break;
                case 5:
                    int intResult = 0;
                    string strResult = string.Empty;
                    Parallel.Invoke(
                        () => intResult = MethodInt(),
                        () => strResult = MethodString("Don Dai"),
                        () => MethodNull(100));
                    Console.WriteLine();
                    Console.WriteLine($"Method1 Result: {intResult}");
                    Console.WriteLine($"Method2 Result: {strResult}");
                    Console.WriteLine($"Parallel Execution Completed");
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
            Console.WriteLine("Do you want to continue? (y/n)");
            char.TryParse(Console.ReadLine(), out char res);

            if (res == 'y')
            {
                goto LOOP;
            }
        }
        static void Method1()
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Method 1 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
        }
        static void Method2()
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Method 2 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
        }
        static void Method3()
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Method 3 Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
        }
        static void NormalAction()
        {
            Console.WriteLine($"Method 1, Thread={Thread.CurrentThread.ManagedThreadId}");
        }
        static void DoSomeTask(int number)
        {
            Console.WriteLine($"DoSomeTask {number} started by Thread {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(5000);
            Console.WriteLine($"DoSomeTask {number} completed by Thread {Thread.CurrentThread.ManagedThreadId}");
        }

        static int MethodInt()
        {
            Task.Delay(1000);
            Console.WriteLine($"Method int Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
            return 100;
        }
        static string MethodString(string name)
        {
            Task.Delay(1000);
            Console.WriteLine($"Method string Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
            return "Hello:" + name;
        }
        static void MethodNull(int number)
        {
            Task.Delay(200);
            Console.WriteLine($"Method null Completed by Thread={Thread.CurrentThread.ManagedThreadId}");
        }
    }
}