using Ex5_CancellationToken.CancellationMethod;

namespace CancellationToken
{
    class Program
    {
        static void Main(string[] args)
        {
        LOOP:
            Console.WriteLine(@"1. CancellationToken Demo
2. User-Initiated Cancellation
3. Time-Based Cancellation
4. Cooperative Cancellation
5. I/O Operation Cancellation");
            Console.Write("Enter your choice: ");
            int.TryParse(Console.ReadLine(), out int choice);
            Console.WriteLine("\n");
            switch (choice)
            {
                case 1:
                    MethodImplementation.SomeMethod();
                    break;
                case 2:
                    MethodImplementation.UserInitiatedCancellation().GetAwaiter();
                    break;
                case 3:
                    MethodImplementation.TimeBasedCancellation().GetAwaiter();
                    break;
                case 4:
                    MethodImplementation.CooperativeCancellation().GetAwaiter();
                    break;
                case 5:
                    Console.Write("Write Name: ");
                    var task = Task.Run(() => MethodImplementation.IOOperationCancellation(Console.ReadLine() ?? "Ram"));
                    task.Wait();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine("Do you want to continue? (y/n)");

            char.TryParse(Console.ReadLine(), out char c);

            if (c == 'y')
            {
                goto LOOP;
            }

            Console.ReadKey();
        }
    }
}