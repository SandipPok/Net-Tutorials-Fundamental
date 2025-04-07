using System.Collections;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
    LOOP:
        Console.WriteLine(@"1. Asynchronous Streams in C#
2. Example to Understand Synchronous Stream
3. Asynchronous Stream for above example
4. Example showing the use of Cancellation Token
5. ConfigureAwait Method in C#");

        Console.Write("Enter the option: ");
        int.TryParse(Console.ReadLine(), out int choice);
        Console.WriteLine("");
        switch (choice)
        {
            case 1:
                await foreach (var number in GenerateSequence())
                {
                    Console.WriteLine(number);
                }
                break;
            case 2:
                Console.WriteLine($"Start: {DateTime.Now.ToLongTimeString()}");
                var numbers = GetNumbers(1, 10);
                foreach (var number in numbers)
                {
                    Console.WriteLine(number);
                }
                Console.WriteLine($"End: {DateTime.Now.ToLongTimeString()}");
                break;
            case 3:
                Console.WriteLine($"Start: {DateTime.Now.ToLongTimeString()}");
                var numbersAsync = GetNumbersAsync(1, 10);
                await foreach (var number in numbersAsync)
                {
                    Console.WriteLine(number);
                }
                Console.WriteLine($"End: {DateTime.Now.ToLongTimeString()}");
                break;
            case 4:
                Console.WriteLine($"Start: {DateTime.Now.ToLongTimeString()}");
                var cts = new CancellationTokenSource();
                cts.CancelAfter(millisecondsDelay: 3000);

                var numbersAsyncCancel = GetNumbersAsync(1, 10, cts.Token);

                await foreach (var number in numbersAsyncCancel)
                {
                    Console.WriteLine(number);
                }
                Console.WriteLine($"End: {DateTime.Now.ToLongTimeString()}");
                break;
            case 5:
                Console.WriteLine($"Start: {DateTime.Now.ToLongTimeString()}");
                var cts1 = new CancellationTokenSource();
                cts1.CancelAfter(millisecondsDelay: 3000);

                var numbersAsyncCancel1 = GetNumbersAsync(1, 10, cts1.Token).ConfigureAwait(false);
                await foreach (var number in numbersAsyncCancel1)
                {
                    Console.WriteLine(number);
                }
                Console.WriteLine($"End: {DateTime.Now.ToLongTimeString()}");
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
    static async IAsyncEnumerable<int> GenerateSequence()
    {
        for (int i = 0; i < 20; i++)
        {
            await Task.Delay(100);
            yield return i;
        }
    }
    static IEnumerable<int> GetNumbers(int start, int end)
    {
        var random = new Random();
        var returnList = new List<int>();

        for (int i = start; i < end; i++)
        {
            returnList.Add(i);
            Thread.Sleep(millisecondsTimeout: random.Next(500, 1500));
        }

        return returnList;
    }
    static async IAsyncEnumerable<int> GetNumbersAsync(int start, int end)
    {
        var random = new Random();
        
        for (int i = start; i < end; i++)
        {
            await Task.Delay(random.Next(500, 1500));
            yield return i;
        }
    }
    static async IAsyncEnumerable<int> GetNumbersAsync(int start, int end, [EnumeratorCancellation] CancellationToken token = default)
    {
        var random = new Random();
        for (int i = start; i < end; i++)
        {
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Cancellation has been requested...");
                break;
            }
            await Task.Delay(random.Next(500, 1500));
            yield return i;
        }
    }
}