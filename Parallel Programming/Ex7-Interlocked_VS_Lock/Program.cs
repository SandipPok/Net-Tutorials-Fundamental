using System.Diagnostics;

class Program
{
    static object LockObject = new object();
    static long X;
    static void Main(string[] args)
    {
    LOOP:
        Stopwatch sw = new Stopwatch();
        Console.WriteLine(@"1. InterLock Increment Method Demo
2. Interlocked.Add Method
3. Exchange and CompareExchange Method of Interlocked Class
4. Interlocked vs Lock from a Performance Point of View
5. Solve the above Race Condition");

        Console.Write("Enter the option: ");
        int.TryParse(Console.ReadLine(), out int choice);

        switch (choice)
        {
            case 1:
                int incrementLockValue = 0;
                Parallel.For(0, 100000, i =>
                {
                    Interlocked.Increment(ref incrementLockValue);
                });
                Console.WriteLine($"Actual Result: {incrementLockValue}");
                break;
            case 2:
                long sumValueWithoutInterLock = 0;
                long sumValueWithInterLock = 0;
                Parallel.For(0, 100000, i =>
                {
                    sumValueWithoutInterLock += i;
                    Interlocked.Add(ref sumValueWithInterLock, i);
                });
                Console.WriteLine($"Sum Value Without Interlocked: {sumValueWithoutInterLock}");
                Console.WriteLine($"Sum Value With Interlocked: {sumValueWithInterLock}");
                break;
            case 3:
                Thread t1 = new Thread(new ThreadStart(SomeMethod));
                t1.Start();
                t1.Join();

                Console.WriteLine(Interlocked.Read(ref Program.X));
                break;
            case 4:
                int incrementValue = 0;
                sw.Start();
                Parallel.For(0, 10000000, num =>
                {
                    lock (LockObject)
                    {
                        incrementValue++;
                    }
                });
                sw.Stop();
                Console.WriteLine($"Result using Lock: {incrementValue}");
                Console.WriteLine($"Lock took {sw.ElapsedMilliseconds} Milliseconds");

                incrementValue = 0;
                sw.Restart();

                Parallel.For(0, 10000000, number =>
                {
                    Interlocked.Increment(ref incrementValue);
                });
                sw.Stop();
                Console.WriteLine($"Result using Interlocked: {incrementValue}");
                Console.WriteLine($"Interlocked took {sw.ElapsedMilliseconds} Milliseconds");
                break;
            case 5:
                long incrementValueLong = 0;
                long sumValue = 0;
                Parallel.For(0, 100000, num =>
                {
                    Interlocked.Increment(ref incrementValueLong);
                    Interlocked.Add(ref sumValue, incrementValueLong);
                });
                Console.WriteLine($"Increment Value With Interlocked: {incrementValueLong}");
                Console.WriteLine($"Sum Value With Interlocked: {sumValue}");

                incrementValueLong = 0;
                sumValue = 0;

                Parallel.For(0, 100000, num =>
                {
                    lock (LockObject)
                    {
                        incrementValueLong++;
                        sumValue += incrementValueLong;
                    }
                });
                Console.WriteLine($"Increment Value with lock: {incrementValueLong}");
                Console.WriteLine($"Sum value with lock: {sumValue}");
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
    
    static void SomeMethod()
    {
        Interlocked.Exchange(ref Program.X, 20);

        long result = Interlocked.CompareExchange(ref Program.X, 50, 20);

        Console.WriteLine(result);
    }
}