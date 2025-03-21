namespace Ex16_CancelAsyncStream
{
    public class Program
    {
        static async Task Main(string[] args)
        {
        LOOP:
            Console.WriteLine(@"1. Cancellation using break statement in the loop
2. Scheduling Different Continuation Tasks");

            Console.Write("Enter your choice: ");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    await foreach (var name in MethodImpl.GenerateNameAsync())
                    {
                        Console.Write(name + " ");

                        if (name == "Diana")
                        {
                            break;
                        }
                    }
                    Console.WriteLine("\n");
                    break;
                case 2:
                    var cts = new CancellationTokenSource();
                    cts.CancelAfter(TimeSpan.FromSeconds(5));

                    try
                    {
                        await foreach (var name in MethodImpl.GenerateNameAsync(cts.Token))
                        {
                            Console.Write(name + " ");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\n" + ex.Message);
                    }
                    finally
                    {
                        cts.Dispose();
                        cts = null;
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