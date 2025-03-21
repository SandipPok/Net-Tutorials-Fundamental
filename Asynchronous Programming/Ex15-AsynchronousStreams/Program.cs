using Ex15_AsynchronousStreams;

namespace Ex15_AsynchronousStreamsDemo
{
    class Program
    {
        public static async Task Main(string[] args)
        {
        LOOP:
            Console.WriteLine(@"1. Yield Return Demo
2. Asynchronous Steam Operations");

            Console.Write("Enter your choice: ");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    foreach (var name in MethodImpl.GenerateNames())
                    {
                        Console.Write(name + " ");
                    }
                    Console.WriteLine("\n");
                    break;
                case 2:
                    await foreach (var item in MethodImpl.GenerateNamesAsync())
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine("\n");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.Write("Do you want to continue? (y/n): ");
            char.TryParse(Console.ReadLine(), out char c);
            if (c == 'y')
            {
                goto LOOP;
            }
        }
    }
}