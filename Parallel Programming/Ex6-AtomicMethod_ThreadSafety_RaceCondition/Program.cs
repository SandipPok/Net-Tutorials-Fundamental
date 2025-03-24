using System.Diagnostics;

class Program
{
    static object LockObject = new object();
    static void Main(string[] args)
    {
    LOOP:
        Console.WriteLine(@"1. Example using Interlocked Class
2. Parallel Execution Using Parallel.ForEach loop");

        Console.Write("Enter the option: ");
        int.TryParse(Console.ReadLine(), out int choice);

        switch (choice)
        {
            case 1:
                int valueInterLocked = 0;
                Parallel.For(0, 1000000, i =>
                {
                    Interlocked.Increment(ref valueInterLocked);
                });
                Console.WriteLine("Expected Result: 100000");
                Console.WriteLine($"Actual Result: {valueInterLocked}");
                break;
            case 2:
                var valueWithLock = 0;
                Parallel.For(0, 100000, _ =>
                {
                    lock (LockObject)
                    {
                        valueWithLock++;
                    }
                });
                Console.WriteLine("Expected Result: 100000");
                Console.WriteLine($"Actual Result: {valueWithLock}");
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
}