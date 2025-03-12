namespace AsyncAwaitDemo;

class Program
{
    static void Main()
    {
        Console.WriteLine("Main thread started");

        SomeMethodAsync();

        Console.WriteLine("Main thread finished");
        Console.ReadKey();
    }
    public static void SomeMethod()
    {
        Console.WriteLine("SomeMethod started");
        Thread.Sleep(TimeSpan.FromSeconds(10));
        Console.WriteLine("\n");
        Console.WriteLine("SomeMethod finished");
    }
    public async static Task SomeMethodAsync()
    {
        Console.WriteLine("SomeMethodAsync started");
        // await Task.Delay(TimeSpan.FromSeconds(10));
        // Console.WriteLine("\n");
        await Wait();
        Console.WriteLine("SomeMethodAsync finished");
    }

    private async static Task Wait()
    {
        await Task.Delay(TimeSpan.FromSeconds(10));
        Console.WriteLine("\n10 Seconds wait Completed\n");
    }
}